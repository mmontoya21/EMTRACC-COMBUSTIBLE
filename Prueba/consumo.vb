Public Class consumo
    Private Sub ButtonX1_Click(sender As Object, e As EventArgs) Handles ButtonX1.Click

    End Sub

    Private Sub PegarDesdeExcel(ByVal dgv As DataGridView)
        Dim clipboardText As String = Clipboard.GetText()

        If String.IsNullOrWhiteSpace(clipboardText) Then
            MessageBox.Show("El portapapeles está vacío o no contiene datos de Excel.")
            Exit Sub
        End If

        Dim lineas() As String = clipboardText.Split({vbCrLf}, StringSplitOptions.RemoveEmptyEntries)

        Dim filaActual As Integer = If(dgv.CurrentCell IsNot Nothing, dgv.CurrentCell.RowIndex, 0)

        For Each linea As String In lineas
            Dim celdas() As String = linea.Split(vbTab)

            If filaActual >= dgv.Rows.Count Then
                dgv.Rows.Add()
            End If

            For col As Integer = 0 To Math.Min(celdas.Length - 1, dgv.ColumnCount - 1)
                dgv.Rows(filaActual).Cells(col).Value = celdas(col)
            Next

            filaActual += 1
        Next
    End Sub

    Private Sub dgv_KeyDown(sender As Object, e As KeyEventArgs) Handles dgv.KeyDown
        If e.Control AndAlso e.KeyCode = Keys.V Then
            PegarDesdeExcel(dgv)
            e.Handled = True
        End If
    End Sub
End Class