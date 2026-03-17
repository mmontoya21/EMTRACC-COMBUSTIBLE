using ClosedXML.Excel;
using EmtraccWeb.Data;
using EmtraccWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System.Security.Claims;

namespace EmtraccWeb.Controllers;

[Authorize]
public class ComprobantesController : Controller
{
    private readonly AppDbContext _db;
    private const int PageSize = 50;

    public ComprobantesController(AppDbContext db)
    {
        _db = db;
    }

    private IQueryable<Comprobante> AplicarFiltros(DateTime? fechaDesde, DateTime? fechaHasta, string? periodo, string? semana, string? boleta, string? comprobante, string? despachador, string? propietario, string? placa)
    {
        var query = _db.Comprobantes.AsQueryable();

        // Restricción por rol: DESPACHADOR solo ve sus registros
        var userRole = User.FindFirstValue(ClaimTypes.Role);
        var userName = User.Identity?.Name;
        if (userRole == "DESPACHADOR" && !string.IsNullOrEmpty(userName))
            query = query.Where(c => c.NombDesp == userName);

        if (fechaDesde.HasValue)
            query = query.Where(c => c.Fecha >= fechaDesde.Value);

        if (fechaHasta.HasValue)
            query = query.Where(c => c.Fecha <= fechaHasta.Value.Date.AddDays(1).AddTicks(-1));

        if (!string.IsNullOrEmpty(periodo))
            query = query.Where(c => c.Periodo == periodo);

        if (!string.IsNullOrEmpty(semana))
            query = query.Where(c => c.Semana == semana);

        if (!string.IsNullOrEmpty(boleta))
            query = query.Where(c => c.NBoleta != null && c.NBoleta.Contains(boleta));

        if (!string.IsNullOrEmpty(comprobante))
            query = query.Where(c => c.NCompro != null && c.NCompro.Contains(comprobante));

        if (!string.IsNullOrEmpty(despachador))
            query = query.Where(c => c.NombDesp == despachador);

        if (!string.IsNullOrEmpty(propietario))
            query = query.Where(c => c.PropCbz != null && c.PropCbz.Contains(propietario));

        if (!string.IsNullOrEmpty(placa))
            query = query.Where(c => c.PlacaCbz != null && c.PlacaCbz.Contains(placa));

        return query;
    }

    private static IQueryable<Comprobante> AplicarOrden(IQueryable<Comprobante> query, string? ordenar, string? dir)
    {
        var desc = string.Equals(dir, "desc", StringComparison.OrdinalIgnoreCase);
        return ordenar?.ToLower() switch
        {
            "compro" => desc ? query.OrderByDescending(c => c.NCompro) : query.OrderBy(c => c.NCompro),
            "boleta" => desc ? query.OrderByDescending(c => c.NBoleta) : query.OrderBy(c => c.NBoleta),
            "despachador" => desc ? query.OrderByDescending(c => c.NombDesp) : query.OrderBy(c => c.NombDesp),
            "propietario" => desc ? query.OrderByDescending(c => c.PropCbz) : query.OrderBy(c => c.PropCbz),
            "placa" => desc ? query.OrderByDescending(c => c.PlacaCbz) : query.OrderBy(c => c.PlacaCbz),
            "galones" => desc ? query.OrderByDescending(c => c.GalDesp) : query.OrderBy(c => c.GalDesp),
            "total" => desc ? query.OrderByDescending(c => c.Total) : query.OrderBy(c => c.Total),
            _ => desc ? query.OrderBy(c => c.Fecha) : query.OrderByDescending(c => c.Fecha),
        };
    }

    public async Task<IActionResult> Index(DateTime? fechaDesde, DateTime? fechaHasta, string? periodo, string? semana, string? boleta, string? comprobante, string? despachador, string? propietario, string? placa, string? ordenar, string? dir, int pagina = 1)
    {
        var query = AplicarFiltros(fechaDesde, fechaHasta, periodo, semana, boleta, comprobante, despachador, propietario, placa);

        // Resumen sobre TODOS los filtrados (antes de paginar)
        var totalRegistros = await query.CountAsync();
        var anuladosCount = await query.CountAsync(c => c.Anulado);
        var totalGalones = await query.Where(c => !c.Anulado).SumAsync(c => c.GalDesp ?? 0);
        var totalMonto = await query.Where(c => !c.Anulado).SumAsync(c => c.Total ?? 0);

        // Ordenar
        query = AplicarOrden(query, ordenar, dir);

        // Paginación
        var totalPaginas = (int)Math.Ceiling(totalRegistros / (double)PageSize);
        if (pagina < 1) pagina = 1;
        if (pagina > totalPaginas && totalPaginas > 0) pagina = totalPaginas;

        var comprobantes = await query.Skip((pagina - 1) * PageSize).Take(PageSize).ToListAsync();

        ViewBag.TotalRegistros = totalRegistros;
        ViewBag.RegistrosAnulados = anuladosCount;
        ViewBag.TotalGalones = totalGalones;
        ViewBag.TotalMonto = totalMonto;
        ViewBag.PaginaActual = pagina;
        ViewBag.TotalPaginas = totalPaginas;

        // Listas para filtros
        ViewBag.Periodos = await _db.Comprobantes.Select(c => c.Periodo).Distinct().OrderBy(p => p).ToListAsync();
        ViewBag.Semanas = await _db.Comprobantes.Select(c => c.Semana).Distinct().OrderBy(s => s).ToListAsync();
        ViewBag.Despachadores = await _db.Comprobantes.Where(c => c.NombDesp != null).Select(c => c.NombDesp).Distinct().OrderBy(d => d).ToListAsync();

        // Mantener valores
        ViewBag.FechaDesde = fechaDesde?.ToString("yyyy-MM-dd");
        ViewBag.FechaHasta = fechaHasta?.ToString("yyyy-MM-dd");
        ViewBag.PeriodoSeleccionado = periodo;
        ViewBag.SemanaSeleccionada = semana;
        ViewBag.Boleta = boleta;
        ViewBag.Comprobante = comprobante;
        ViewBag.DespachadorSeleccionado = despachador;
        ViewBag.Propietario = propietario;
        ViewBag.Placa = placa;
        ViewBag.Ordenar = ordenar;
        ViewBag.Dir = dir;

        return View(comprobantes);
    }

    public async Task<IActionResult> ExportarExcel(DateTime? fechaDesde, DateTime? fechaHasta, string? periodo, string? semana, string? boleta, string? comprobante, string? despachador, string? propietario, string? placa)
    {
        var query = AplicarFiltros(fechaDesde, fechaHasta, periodo, semana, boleta, comprobante, despachador, propietario, placa);
        var datos = await query.OrderByDescending(c => c.Fecha).ToListAsync();

        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Comprobantes");

        // Encabezados
        var headers = new[] { "No. Compro", "No. Boleta", "Fecha", "Despachador", "Propietario", "Placa", "Período", "Semana", "Ruta", "Galones", "Valor", "Total", "Contenedor", "Conductor", "Estado" };
        for (int i = 0; i < headers.Length; i++)
        {
            ws.Cell(1, i + 1).Value = headers[i];
            ws.Cell(1, i + 1).Style.Font.Bold = true;
            ws.Cell(1, i + 1).Style.Fill.BackgroundColor = XLColor.FromHtml("#333333");
            ws.Cell(1, i + 1).Style.Font.FontColor = XLColor.White;
        }

        // Datos
        for (int r = 0; r < datos.Count; r++)
        {
            var c = datos[r];
            var row = r + 2;
            ws.Cell(row, 1).Value = c.NCompro ?? "";
            ws.Cell(row, 2).Value = c.NBoleta ?? "";
            ws.Cell(row, 3).Value = c.Fecha?.ToString("dd/MM/yyyy") ?? "";
            ws.Cell(row, 4).Value = c.NombDesp ?? "";
            ws.Cell(row, 5).Value = c.PropCbz ?? "";
            ws.Cell(row, 6).Value = c.PlacaCbz ?? "";
            ws.Cell(row, 7).Value = c.Periodo ?? "";
            ws.Cell(row, 8).Value = c.Semana ?? "";
            ws.Cell(row, 9).Value = c.Ruta ?? "";
            ws.Cell(row, 10).Value = (double)(c.GalDesp ?? 0);
            ws.Cell(row, 11).Value = (double)(c.Valor ?? 0);
            ws.Cell(row, 12).Value = (double)(c.Total ?? 0);
            ws.Cell(row, 13).Value = c.NConte ?? "";
            ws.Cell(row, 14).Value = c.NombCond ?? "";
            ws.Cell(row, 15).Value = c.Anulado ? "ANULADO" : "ACTIVO";

            // Colores de fila
            XLColor bgColor;
            if (c.Anulado)
                bgColor = XLColor.FromHtml("#FFCCCC");
            else
                bgColor = r % 2 == 0 ? XLColor.White : XLColor.FromHtml("#DCE6F1");

            for (int col = 1; col <= 15; col++)
                ws.Cell(row, col).Style.Fill.BackgroundColor = bgColor;
        }

        // Resumen
        var resumenRow = datos.Count + 3;
        var activos = datos.Where(c => !c.Anulado).ToList();
        ws.Cell(resumenRow, 1).Value = $"Total registros: {datos.Count}";
        ws.Cell(resumenRow, 1).Style.Font.Bold = true;
        ws.Cell(resumenRow + 1, 1).Value = $"Anulados: {datos.Count(c => c.Anulado)}";
        ws.Cell(resumenRow + 2, 1).Value = $"Galones: {activos.Sum(c => c.GalDesp ?? 0):N2}";
        ws.Cell(resumenRow + 3, 1).Value = $"Total Q: {activos.Sum(c => c.Total ?? 0):N2}";

        ws.Columns().AdjustToContents();

        var stream = new MemoryStream();
        wb.SaveAs(stream);
        stream.Position = 0;

        return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", $"Comprobantes_{DateTime.Now:yyyyMMdd_HHmmss}.xlsx");
    }

    public async Task<IActionResult> ExportarPdf(DateTime? fechaDesde, DateTime? fechaHasta, string? periodo, string? semana, string? boleta, string? comprobante, string? despachador, string? propietario, string? placa)
    {
        var query = AplicarFiltros(fechaDesde, fechaHasta, periodo, semana, boleta, comprobante, despachador, propietario, placa);
        var datos = await query.OrderByDescending(c => c.Fecha).ToListAsync();
        var activos = datos.Where(c => !c.Anulado).ToList();

        var totalGalones = activos.Sum(c => c.GalDesp ?? 0);
        var totalMonto = activos.Sum(c => c.Total ?? 0);
        var totalRegistros = datos.Count;
        var anulados = datos.Count(c => c.Anulado);

        QuestPDF.Settings.License = LicenseType.Community;

        var pdf = Document.Create(container =>
        {
            container.Page(page =>
            {
                page.Size(PageSizes.Legal.Landscape());
                page.Margin(20);
                page.DefaultTextStyle(x => x.FontSize(8));

                page.Header().Column(col =>
                {
                    col.Item().Text("EMTRACC - Reporte de Comprobantes").Bold().FontSize(14).AlignCenter();
                    col.Item().Text($"Generado: {DateTime.Now:dd/MM/yyyy HH:mm}").FontSize(8).AlignCenter();
                    col.Item().PaddingTop(5).Row(row =>
                    {
                        row.RelativeItem().Text($"Total registros: {totalRegistros}  |  Anulados: {anulados}  |  Galones: {totalGalones:N2}  |  Total Q: {totalMonto:N2}").FontSize(9);
                    });
                    col.Item().PaddingBottom(5);
                });

                page.Content().Table(table =>
                {
                    table.ColumnsDefinition(cols =>
                    {
                        cols.RelativeColumn(1.2f);
                        cols.RelativeColumn(1);
                        cols.RelativeColumn(1.2f);
                        cols.RelativeColumn(2);
                        cols.RelativeColumn(2);
                        cols.RelativeColumn(1);
                        cols.RelativeColumn(0.8f);
                        cols.RelativeColumn(0.8f);
                        cols.RelativeColumn(1.5f);
                        cols.RelativeColumn(1);
                        cols.RelativeColumn(1);
                        cols.RelativeColumn(1);
                        cols.RelativeColumn(1);
                        cols.RelativeColumn(1.5f);
                        cols.RelativeColumn(0.8f);
                    });

                    var headers = new[] { "No. Compro", "No. Boleta", "Fecha", "Despachador", "Propietario", "Placa", "Período", "Semana", "Ruta", "Galones", "Valor", "Total", "Contenedor", "Conductor", "Estado" };
                    foreach (var h in headers)
                        table.Cell().Background("#333333").Padding(3).Text(h).Bold().FontColor("#FFFFFF").FontSize(7);

                    int idx = 0;
                    foreach (var c in datos)
                    {
                        string bgColor = c.Anulado ? "#FFCCCC" : idx % 2 == 0 ? "#FFFFFF" : "#DCE6F1";
                        idx++;

                        var vals = new[]
                        {
                            c.NCompro ?? "", c.NBoleta ?? "", c.Fecha?.ToString("dd/MM/yyyy") ?? "",
                            c.NombDesp ?? "", c.PropCbz ?? "", c.PlacaCbz ?? "",
                            c.Periodo ?? "", c.Semana ?? "", c.Ruta ?? "",
                            (c.GalDesp ?? 0).ToString("N2"), (c.Valor ?? 0).ToString("N2"), (c.Total ?? 0).ToString("N2"),
                            c.NConte ?? "", c.NombCond ?? "", c.Anulado ? "ANULADO" : "ACTIVO"
                        };

                        foreach (var v in vals)
                            table.Cell().Background(bgColor).Padding(2).Text(v).FontSize(7);
                    }
                });

                page.Footer().AlignCenter().Text(x =>
                {
                    x.Span("Página ");
                    x.CurrentPageNumber();
                    x.Span(" de ");
                    x.TotalPages();
                });
            });
        });

        var stream = new MemoryStream();
        pdf.GeneratePdf(stream);
        stream.Position = 0;
        return File(stream, "application/pdf", $"Comprobantes_{DateTime.Now:yyyyMMdd_HHmmss}.pdf");
    }

    // API para Dashboard (Chart.js)
    public async Task<IActionResult> DashboardData(string? periodo, string? semana)
    {
        var query = _db.Comprobantes.Where(c => !c.Anulado);

        // Restricción por rol
        var userRole = User.FindFirstValue(ClaimTypes.Role);
        var userName = User.Identity?.Name;
        if (userRole == "DESPACHADOR" && !string.IsNullOrEmpty(userName))
            query = query.Where(c => c.NombDesp == userName);

        if (!string.IsNullOrEmpty(periodo))
            query = query.Where(c => c.Periodo == periodo);

        if (!string.IsNullOrEmpty(semana))
            query = query.Where(c => c.Semana == semana);

        var datos = await query.ToListAsync();

        // Galones por despachador
        var porDespachador = datos.GroupBy(c => c.NombDesp ?? "Sin nombre")
            .Select(g => new { nombre = g.Key, galones = g.Sum(c => (double)(c.GalDesp ?? 0)), total = g.Sum(c => (double)(c.Total ?? 0)) })
            .OrderByDescending(x => x.galones).ToList();

        // Galones por fecha (últimos 30 días)
        var porFecha = datos.Where(c => c.Fecha.HasValue)
            .GroupBy(c => c.Fecha!.Value.Date)
            .Select(g => new { fecha = g.Key.ToString("dd/MM"), galones = g.Sum(c => (double)(c.GalDesp ?? 0)) })
            .OrderBy(x => x.fecha).ToList();

        // Por ruta
        var porRuta = datos.GroupBy(c => c.Ruta ?? "Sin ruta")
            .Select(g => new { ruta = g.Key, galones = g.Sum(c => (double)(c.GalDesp ?? 0)) })
            .OrderByDescending(x => x.galones).Take(10).ToList();

        return Json(new { porDespachador, porFecha, porRuta });
    }

    public async Task<IActionResult> Dashboard()
    {
        ViewBag.Periodos = await _db.Comprobantes.Select(c => c.Periodo).Distinct().OrderBy(p => p).ToListAsync();
        ViewBag.Semanas = await _db.Comprobantes.Select(c => c.Semana).Distinct().OrderBy(s => s).ToListAsync();
        return View();
    }
}
