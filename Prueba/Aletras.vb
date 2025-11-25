Module Aletras
    Public Function LETRAS(ByVal NUMERO As String) As String
        '********DECLARA VARIABLES DE TIPO CADENA************
        Dim PALABRAS, ENTERO, DEC, FLAG As String

        '********DECLARA VARIABLES DE TIPO ENTERO***********
        Dim NUM, X, Y As Integer

        FLAG = "N"

        '**********NÚMERO NEGATIVO***********
        If Mid(NUMERO, 1, 1) = "-" Then
            NUMERO = Mid(NUMERO, 2, NUMERO.ToString.Length - 1).ToString
            PALABRAS = "MENOS "
        End If

        '**********SI TIENE CEROS A LA IZQUIERDA*************
        For X = 1 To NUMERO.ToString.Length
            If Mid(NUMERO, 1, 1) = "0" Then
                NUMERO = Trim(Mid(NUMERO, 2, NUMERO.ToString.Length).ToString)
                If Trim(NUMERO.ToString.Length) = 0 Then PALABRAS = ""
            Else
                Exit For
            End If
        Next

        '*********DIVIDIR PARTE ENTERA Y DECIMAL************
        For Y = 1 To Len(NUMERO)
            If Mid(NUMERO, Y, 1) = "." Then
                FLAG = "S"
            Else
                If FLAG = "N" Then
                    ENTERO = ENTERO + Mid(NUMERO, Y, 1)
                Else
                    DEC = DEC + Mid(NUMERO, Y, 1)
                End If
            End If
        Next Y

        If Len(DEC) = 1 Then DEC = DEC & "0"

        '**********PROCESO DE CONVERSIÓN***********
        FLAG = "N"

        If Val(NUMERO) <= 999999999 Then
            For Y = Len(ENTERO) To 1 Step -1
                NUM = Len(ENTERO) - (Y - 1)
                Select Case Y
                    Case 3, 6, 9
                        '**********ASIGNA LAS PALABRAS PARA LAS CENTENAS***********
                        Select Case Mid(ENTERO, NUM, 1)
                            Case "1"
                                If Mid(ENTERO, NUM + 1, 1) = "0" And Mid(ENTERO, NUM + 2, 1) = "0" Then
                                    PALABRAS = PALABRAS & "CIEN "
                                Else
                                    PALABRAS = PALABRAS & "CIENTO "
                                End If
                            Case "2"
                                PALABRAS = PALABRAS & "DOSCIENTOS "
                            Case "3"
                                PALABRAS = PALABRAS & "TRESCIENTOS "
                            Case "4"
                                PALABRAS = PALABRAS & "CUATROCIENTOS "
                            Case "5"
                                PALABRAS = PALABRAS & "QUINIENTOS "
                            Case "6"
                                PALABRAS = PALABRAS & "SEISCIENTOS "
                            Case "7"
                                PALABRAS = PALABRAS & "SETECIENTOS "
                            Case "8"
                                PALABRAS = PALABRAS & "OCHOCIENTOS "
                            Case "9"
                                PALABRAS = PALABRAS & "NOVECIENTOS "
                        End Select
                    Case 2, 5, 8
                        '*********ASIGNA LAS PALABRAS PARA LAS DECENAS************
                        Select Case Mid(ENTERO, NUM, 1)
                            Case "1"
                                If Mid(ENTERO, NUM + 1, 1) = "0" Then
                                    FLAG = "S"
                                    PALABRAS = PALABRAS & "DIEZ "
                                End If
                                If Mid(ENTERO, NUM + 1, 1) = "1" Then
                                    FLAG = "S"
                                    PALABRAS = PALABRAS & "ONCE "
                                End If
                                If Mid(ENTERO, NUM + 1, 1) = "2" Then
                                    FLAG = "S"
                                    PALABRAS = PALABRAS & "DOCE "
                                End If
                                If Mid(ENTERO, NUM + 1, 1) = "3" Then
                                    FLAG = "S"
                                    PALABRAS = PALABRAS & "TRECE "
                                End If
                                If Mid(ENTERO, NUM + 1, 1) = "4" Then
                                    FLAG = "S"
                                    PALABRAS = PALABRAS & "CATORCE "
                                End If
                                If Mid(ENTERO, NUM + 1, 1) = "5" Then
                                    FLAG = "S"
                                    PALABRAS = PALABRAS & "QUINCE "
                                End If
                                If Mid(ENTERO, NUM + 1, 1) > "5" Then
                                    FLAG = "N"
                                    PALABRAS = PALABRAS & "DIECI"
                                End If
                            Case "2"
                                If Mid(ENTERO, NUM + 1, 1) = "0" Then
                                    PALABRAS = PALABRAS & "VEINTE "
                                    FLAG = "S"
                                Else
                                    PALABRAS = PALABRAS & "VEINTI"
                                    FLAG = "N"
                                End If
                            Case "3"
                                If Mid(ENTERO, NUM + 1, 1) = "0" Then
                                    PALABRAS = PALABRAS & "TREINTA "
                                    FLAG = "S"
                                Else
                                    PALABRAS = PALABRAS & "TREINTA Y "
                                    FLAG = "N"
                                End If
                            Case "4"
                                If Mid(ENTERO, NUM + 1, 1) = "0" Then
                                    PALABRAS = PALABRAS & "CUARENTA "
                                    FLAG = "S"
                                Else
                                    PALABRAS = PALABRAS & "CUARENTA Y "
                                    FLAG = "N"
                                End If
                            Case "5"
                                If Mid(ENTERO, NUM + 1, 1) = "0" Then
                                    PALABRAS = PALABRAS & "CINCUENTA "
                                    FLAG = "S"
                                Else
                                    PALABRAS = PALABRAS & "CINCUENTA Y "
                                    FLAG = "N"
                                End If
                            Case "6"
                                If Mid(ENTERO, NUM + 1, 1) = "0" Then
                                    PALABRAS = PALABRAS & "SESENTA "
                                    FLAG = "S"
                                Else
                                    PALABRAS = PALABRAS & "SESENTA Y "
                                    FLAG = "N"
                                End If
                            Case "7"
                                If Mid(ENTERO, NUM + 1, 1) = "0" Then
                                    PALABRAS = PALABRAS & "SETENTA "
                                    FLAG = "S"
                                Else
                                    PALABRAS = PALABRAS & "SETENTA Y "
                                    FLAG = "N"
                                End If
                            Case "8"
                                If Mid(ENTERO, NUM + 1, 1) = "0" Then
                                    PALABRAS = PALABRAS & "OCHENTA "
                                    FLAG = "S"
                                Else
                                    PALABRAS = PALABRAS & "OCHENTA Y "
                                    FLAG = "N"
                                End If
                            Case "9"
                                If Mid(ENTERO, NUM + 1, 1) = "0" Then
                                    PALABRAS = PALABRAS & "NOVENTA "
                                    FLAG = "S"
                                Else
                                    PALABRAS = PALABRAS & "NOVENTA Y "
                                    FLAG = "N"
                                End If
                        End Select
                    Case 1, 4, 7
                        '*********ASIGNA LAS PALABRAS PARA LAS UNIDADES*********
                        Select Case Mid(ENTERO, NUM, 1)
                            Case "1"
                                If FLAG = "N" Then
                                    If Y = 1 Then
                                        PALABRAS = PALABRAS & "UNO "
                                    Else
                                        PALABRAS = PALABRAS & "UN "
                                    End If
                                End If
                            Case "2"
                                If FLAG = "N" Then PALABRAS = PALABRAS & "DOS "
                            Case "3"
                                If FLAG = "N" Then PALABRAS = PALABRAS & "TRES "
                            Case "4"
                                If FLAG = "N" Then PALABRAS = PALABRAS & "CUATRO "
                            Case "5"
                                If FLAG = "N" Then PALABRAS = PALABRAS & "CINCO "
                            Case "6"
                                If FLAG = "N" Then PALABRAS = PALABRAS & "SEIS "
                            Case "7"
                                If FLAG = "N" Then PALABRAS = PALABRAS & "SIETE "
                            Case "8"
                                If FLAG = "N" Then PALABRAS = PALABRAS & "OCHO "
                            Case "9"
                                If FLAG = "N" Then PALABRAS = PALABRAS & "NUEVE "
                        End Select
                End Select

                '***********ASIGNA LA PALABRA MIL***************
                If Y = 4 Then
                    If Mid(ENTERO, 6, 1) <> "0" Or Mid(ENTERO, 5, 1) <> "0" Or Mid(ENTERO, 4, 1) <> "0" Or
                    (Mid(ENTERO, 6, 1) = "0" And Mid(ENTERO, 5, 1) = "0" And Mid(ENTERO, 4, 1) = "0" And
                    Len(ENTERO) <= 6) Then PALABRAS = PALABRAS & "MIL "
                End If

                '**********ASIGNA LA PALABRA MILLÓN*************
                If Y = 7 Then
                    If Len(ENTERO) = 7 And Mid(ENTERO, 1, 1) = "1" Then
                        PALABRAS = PALABRAS & "MILLÓN "
                    Else
                        PALABRAS = PALABRAS & "MILLONES "
                    End If
                End If
            Next Y

            '**********UNE LA PARTE ENTERA Y LA PARTE DECIMAL*************
            If DEC <> "" Then
                LETRAS = PALABRAS & "CON " & DEC & " CTVS"
            Else
                LETRAS = PALABRAS
            End If
        Else
            LETRAS = ""
        End If
    End Function
End Module
