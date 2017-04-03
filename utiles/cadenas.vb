Public Class cadenas

#Region "PATRON SINGLETON"

    Private Sub New()
    End Sub

    Public Shared ReadOnly Instancia As New cadenas

#End Region


    '///////////////////////////////////////////////////////////////////////////////
    'Esta funcion rellena una cadena hasta la longitud indicada, con el caracter indicado.
    '///////////////////////////////////////////////////////////////////////////////
    Public Function rellenar(ByVal cadena As String, ByVal ancho As Integer, ByVal relleno As String, Optional ByVal ElRellenoALaIzquierda As Boolean = True) As String
        Dim cadena2 As String = ""
        Dim i As Integer
        If ElRellenoALaIzquierda Then
            If cadena.Length > ancho Then
                cadena2 = cadena.Substring(cadena.Length - ancho, ancho)
            ElseIf cadena.Length = ancho Then
                cadena2 = cadena
            Else
                For i = 1 To (ancho - cadena.Length)
                    cadena2 = cadena2 + relleno
                Next
                cadena2 = cadena2 + cadena
            End If
        Else
            If cadena.Length > ancho Then
                cadena2 = cadena.Substring(cadena.Length - ancho, ancho)
            ElseIf cadena.Length = ancho Then
                cadena2 = cadena
            Else
                For i = 1 To (ancho - cadena.Length)
                    cadena2 = relleno + cadena2
                Next
                cadena2 = cadena + cadena2
            End If
        End If
        rellenar = cadena2
    End Function

End Class
