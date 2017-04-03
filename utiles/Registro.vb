Imports Microsoft.Win32
Public Class Registro

#Region "PATRON SINGLETON"

    Private Sub New()
    End Sub

    Public Shared ReadOnly Instancia As New Registro

#End Region

    Public Sub AutostartUsuario(ByVal nombre As String, ByVal path As String, ByVal activar As Boolean)
        Try

            Dim regkey As RegistryKey
            regkey = Registry.CurrentUser.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            If activar Then
                regkey.SetValue(nombre, path)
            Else
                regkey.DeleteValue(nombre)
            End If
            regkey.Close()
        Catch ex As Exception

        End Try
    End Sub

    Public Sub AutostartMaquina(ByVal nombre As String, ByVal path As String, ByVal activar As Boolean)
        Try
            Dim regkey As RegistryKey
            regkey = Registry.LocalMachine.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
            If activar Then
                regkey.SetValue(nombre, path)
            Else
                regkey.DeleteValue(nombre)
            End If
            regkey.Close()
        Catch ex As Exception

        End Try
    End Sub

End Class