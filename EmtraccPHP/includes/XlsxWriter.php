<?php
/**
 * Generador XLSX ligero sin dependencias externas.
 * Usa ZipArchive (incluido en PHP) para crear archivos Excel reales.
 */
class XlsxWriter
{
    private array $rows = [];
    private array $styles = []; // índice de fila => estilo
    private array $colWidths = [];

    public function addRow(array $cells, string $bgColor = '', bool $bold = false, string $fontColor = ''): void
    {
        $rowIndex = count($this->rows);
        $this->rows[] = $cells;
        if ($bgColor !== '' || $bold || $fontColor !== '') {
            $this->styles[$rowIndex] = ['bg' => $bgColor, 'bold' => $bold, 'fontColor' => $fontColor];
        }
        // Auto-ancho
        foreach ($cells as $i => $cell) {
            $len = mb_strlen((string)$cell) + 2;
            if (!isset($this->colWidths[$i]) || $len > $this->colWidths[$i]) {
                $this->colWidths[$i] = min($len, 40);
            }
        }
    }

    public function save(string $filePath): void
    {
        $zip = new ZipArchive();
        if ($zip->open($filePath, ZipArchive::CREATE | ZipArchive::OVERWRITE) !== true) {
            throw new RuntimeException("No se pudo crear el archivo XLSX");
        }

        $zip->addFromString('[Content_Types].xml', $this->contentTypes());
        $zip->addFromString('_rels/.rels', $this->rels());
        $zip->addFromString('xl/_rels/workbook.xml.rels', $this->workbookRels());
        $zip->addFromString('xl/workbook.xml', $this->workbook());
        $zip->addFromString('xl/styles.xml', $this->stylesXml());
        $zip->addFromString('xl/worksheets/sheet1.xml', $this->sheet());

        $zip->close();
    }

    public function output(string $filename): void
    {
        $tmp = tempnam(sys_get_temp_dir(), 'xlsx');
        $this->save($tmp);

        header('Content-Type: application/vnd.openxmlformats-officedocument.spreadsheetml.sheet');
        header('Content-Disposition: attachment; filename="' . $filename . '"');
        header('Content-Length: ' . filesize($tmp));
        header('Cache-Control: max-age=0');
        readfile($tmp);
        unlink($tmp);
        exit;
    }

    private function contentTypes(): string
    {
        return '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Types xmlns="http://schemas.openxmlformats.org/package/2006/content-types">
    <Default Extension="rels" ContentType="application/vnd.openxmlformats-package.relationships+xml"/>
    <Default Extension="xml" ContentType="application/xml"/>
    <Override PartName="/xl/workbook.xml" ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml"/>
    <Override PartName="/xl/worksheets/sheet1.xml" ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml"/>
    <Override PartName="/xl/styles.xml" ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.styles+xml"/>
</Types>';
    }

    private function rels(): string
    {
        return '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
    <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument" Target="xl/workbook.xml"/>
</Relationships>';
    }

    private function workbookRels(): string
    {
        return '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
    <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet" Target="worksheets/sheet1.xml"/>
    <Relationship Id="rId2" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/styles" Target="styles.xml"/>
</Relationships>';
    }

    private function workbook(): string
    {
        return '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<workbook xmlns="http://schemas.openxmlformats.org/spreadsheetml/2006/main"
          xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships">
    <sheets>
        <sheet name="Comprobantes" sheetId="1" r:id="rId1"/>
    </sheets>
</workbook>';
    }

    private function stylesXml(): string
    {
        // Recopilar colores únicos
        $fills = [
            'none'    => 0,
            'gray125' => 1,
        ];
        $fonts = [
            'normal' => 0,
        ];
        $xfs = [];

        // Estilo 0: default
        $xfs[] = ['fontId' => 0, 'fillId' => 0];

        // Crear estilos por cada fila con estilo
        foreach ($this->styles as $style) {
            $bg = strtoupper(ltrim($style['bg'], '#'));
            $fontColor = strtoupper(ltrim($style['fontColor'], '#'));
            $bold = $style['bold'];

            $fillKey = $bg ?: 'none';
            if (!isset($fills[$fillKey]) && $bg !== '') {
                $fills[$fillKey] = count($fills);
            }

            $fontKey = ($bold ? 'B' : '') . ($fontColor ?: '');
            if (!isset($fonts[$fontKey]) && ($bold || $fontColor)) {
                $fonts[$fontKey] = count($fonts);
            }

            $fillId = $fills[$fillKey] ?? 0;
            $fontId = $fonts[$fontKey] ?? 0;

            // Evitar duplicados de xf
            $xfKey = "$fontId-$fillId";
            $found = false;
            foreach ($xfs as $i => $xf) {
                if ($xf['fontId'] === $fontId && $xf['fillId'] === $fillId) {
                    $found = true;
                    break;
                }
            }
            if (!$found) {
                $xfs[] = ['fontId' => $fontId, 'fillId' => $fillId];
            }
        }

        // Fonts XML
        $fontsXml = '';
        foreach ($fonts as $key => $id) {
            $fontsXml .= '<font>';
            if (str_contains($key, 'B')) {
                $fontsXml .= '<b/>';
            }
            $fontsXml .= '<sz val="10"/><name val="Calibri"/>';
            // Extraer color de fuente
            $fc = str_replace('B', '', $key);
            if ($fc !== '' && $fc !== 'normal') {
                $fontsXml .= '<color rgb="FF' . $fc . '"/>';
            }
            $fontsXml .= '</font>';
        }

        // Fills XML
        $fillsXml = '<fill><patternFill patternType="none"/></fill>';
        $fillsXml .= '<fill><patternFill patternType="gray125"/></fill>';
        foreach ($fills as $color => $id) {
            if ($id < 2) continue;
            $fillsXml .= '<fill><patternFill patternType="solid"><fgColor rgb="FF' . $color . '"/></patternFill></fill>';
        }

        // Cell XFs
        $xfsXml = '';
        foreach ($xfs as $xf) {
            $applyFill = $xf['fillId'] > 0 ? ' applyFill="1"' : '';
            $applyFont = $xf['fontId'] > 0 ? ' applyFont="1"' : '';
            $xfsXml .= '<xf numFmtId="0" fontId="' . $xf['fontId'] . '" fillId="' . $xf['fillId'] . '" borderId="0"' . $applyFill . $applyFont . '/>';
        }

        return '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<styleSheet xmlns="http://schemas.openxmlformats.org/spreadsheetml/2006/main">
    <fonts count="' . count($fonts) . '">' . $fontsXml . '</fonts>
    <fills count="' . count($fills) . '">' . $fillsXml . '</fills>
    <borders count="1"><border><left/><right/><top/><bottom/><diagonal/></border></borders>
    <cellStyleXfs count="1"><xf numFmtId="0" fontId="0" fillId="0" borderId="0"/></cellStyleXfs>
    <cellXfs count="' . count($xfs) . '">' . $xfsXml . '</cellXfs>
</styleSheet>';
    }

    private function getStyleIndex(int $rowIndex): int
    {
        if (!isset($this->styles[$rowIndex])) return 0;

        $style = $this->styles[$rowIndex];
        $bg = strtoupper(ltrim($style['bg'], '#'));
        $fontColor = strtoupper(ltrim($style['fontColor'], '#'));
        $bold = $style['bold'];

        // Recalcular fills y fonts para encontrar el índice
        $fills = ['none' => 0, 'gray125' => 1];
        $fonts = ['normal' => 0];
        $xfs = [['fontId' => 0, 'fillId' => 0]];

        foreach ($this->styles as $s) {
            $sBg = strtoupper(ltrim($s['bg'], '#'));
            $sFc = strtoupper(ltrim($s['fontColor'], '#'));
            $sBold = $s['bold'];

            if ($sBg !== '' && !isset($fills[$sBg])) {
                $fills[$sBg] = count($fills);
            }
            $fontKey = ($sBold ? 'B' : '') . ($sFc ?: '');
            if ($fontKey !== '' && $fontKey !== 'normal' && !isset($fonts[$fontKey])) {
                $fonts[$fontKey] = count($fonts);
            }

            $fillId = $fills[$sBg] ?? 0;
            $fontId = $fonts[$fontKey] ?? 0;

            $found = false;
            foreach ($xfs as $xf) {
                if ($xf['fontId'] === $fontId && $xf['fillId'] === $fillId) {
                    $found = true;
                    break;
                }
            }
            if (!$found) {
                $xfs[] = ['fontId' => $fontId, 'fillId' => $fillId];
            }
        }

        // Encontrar el índice para este estilo
        $fillKey = $bg ?: 'none';
        $fillId = $fills[$fillKey] ?? 0;
        $fontKey = ($bold ? 'B' : '') . ($fontColor ?: '');
        $fontId = $fonts[$fontKey] ?? 0;

        foreach ($xfs as $i => $xf) {
            if ($xf['fontId'] === $fontId && $xf['fillId'] === $fillId) {
                return $i;
            }
        }
        return 0;
    }

    private function sheet(): string
    {
        $colsXml = '';
        if (!empty($this->colWidths)) {
            $colsXml = '<cols>';
            foreach ($this->colWidths as $i => $w) {
                $col = $i + 1;
                $colsXml .= '<col min="' . $col . '" max="' . $col . '" width="' . $w . '" customWidth="1"/>';
            }
            $colsXml .= '</cols>';
        }

        $sheetData = '';
        foreach ($this->rows as $r => $row) {
            $rowNum = $r + 1;
            $styleIdx = $this->getStyleIndex($r);
            $sheetData .= '<row r="' . $rowNum . '">';
            foreach ($row as $c => $value) {
                $colLetter = $this->colLetter($c);
                $ref = $colLetter . $rowNum;
                $val = htmlspecialchars((string)$value, ENT_XML1, 'UTF-8');

                if (is_numeric($value) && !is_string($value)) {
                    $sheetData .= '<c r="' . $ref . '" s="' . $styleIdx . '"><v>' . $val . '</v></c>';
                } else {
                    $sheetData .= '<c r="' . $ref . '" s="' . $styleIdx . '" t="inlineStr"><is><t>' . $val . '</t></is></c>';
                }
            }
            $sheetData .= '</row>';
        }

        return '<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<worksheet xmlns="http://schemas.openxmlformats.org/spreadsheetml/2006/main">
    ' . $colsXml . '
    <sheetData>' . $sheetData . '</sheetData>
</worksheet>';
    }

    private function colLetter(int $col): string
    {
        $letter = '';
        $col++;
        while ($col > 0) {
            $col--;
            $letter = chr(65 + ($col % 26)) . $letter;
            $col = intdiv($col, 26);
        }
        return $letter;
    }
}
