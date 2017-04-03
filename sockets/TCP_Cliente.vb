Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class TCP_Cliente
    Shared clientSocket As System.Net.Sockets.Socket
    Dim incomingMessage(256) As Byte
    Delegate Sub AppendTextDelegate(ByVal message As String)

    Public Event DatosRecibidos(ByVal cadena As String)
    Public Event Actualizacion(ByVal mensaje As String)

    Public Function Conectarse(ByVal ip As String, ByVal puerto As Integer) As Boolean
        Dim resultado As Boolean = True
        Try
            Dim localMachineInfo As IPHostEntry
            'Dim remoteMachineInfo As IPHostEntry
            Dim serverEndpoint As IPEndPoint
            Dim myEndpoint As IPEndPoint
            Dim callback As New AsyncCallback(AddressOf ReceiveCallback)

            If Not clientSocket Is Nothing Then
                clientSocket.Close()
            End If
            localMachineInfo = Dns.GetHostEntry(Dns.GetHostName())
            'remoteMachineInfo = Dns.GetHostEntry(nameField.Text)
            'serverEndpoint = New IPEndPoint(remoteMachineInfo.AddressList(0), Integer.Parse(portField.Text))
            serverEndpoint = New IPEndPoint(IPAddress.Parse(ip), Integer.Parse(CStr(puerto)))
            myEndpoint = New IPEndPoint(localMachineInfo.AddressList(0), 0)

            clientSocket = New Socket(myEndpoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
            clientSocket.Connect(serverEndpoint)
            RaiseEvent Actualizacion("Se Conecto con el Servidor")
            clientSocket.BeginReceive(incomingMessage, 0, 255, System.Net.Sockets.SocketFlags.None, callback, incomingMessage)
        Catch exception As Exception
            resultado = False
            RaiseEvent Actualizacion(exception.ToString())
        End Try
        Return resultado
    End Function

    Public Function EnviarMensaje(ByVal mensaje As String) As Boolean
        Dim resultado As Boolean = True
        If Not clientSocket Is Nothing Then
            Dim encoder As ASCIIEncoding = New System.Text.ASCIIEncoding
            clientSocket.Send(encoder.GetBytes(mensaje))
        Else
            resultado = False
        End If
        Return resultado
    End Function

    Public Function EnviarArchivo(ByVal path As String) As Boolean
        Dim resultado As Boolean = True
        If Not clientSocket Is Nothing Then
            clientSocket.SendFile(path)
        Else
            resultado = False
        End If
        Return resultado
    End Function

    'Public Function EnviarSaldos(ByVal codalmacen As Integer, ByVal coditem As String, ByVal cantidad As Double, ByVal cantidad_proformas As Double) As Boolean
    '    Dim resultado As Boolean = True
    '    Dim mensaje As String
    '    If Not clientSocket Is Nothing Then
    '        mensaje = pad(CStr(codalmacen), 3) & pad(CStr(coditem), 8) & pad(cantidad.ToString("######0.00"), 15) & pad(cantidad_proformas.ToString("######0.00"), 15) & "#"
    '        Dim encoder As ASCIIEncoding = New System.Text.ASCIIEncoding
    '        clientSocket.Send(encoder.GetBytes(mensaje))
    '    Else
    '        resultado = False
    '    End If
    '    Return resultado
    'End Function

    Public Sub Desconectarse()
        If Not clientSocket Is Nothing Then
            clientSocket.Shutdown(SocketShutdown.Both)
            clientSocket.Close()
            clientSocket = Nothing
        End If
    End Sub

    Public Sub ReceiveCallback(ByVal result As IAsyncResult)
        Try
            Dim callback As New AsyncCallback(AddressOf ReceiveCallback)
            Dim data() As Byte = result.AsyncState
            Dim num_read As Integer = clientSocket.EndReceive(result)
            If 0 <> num_read Then
                Dim encoder As ASCIIEncoding = New ASCIIEncoding
                'writeOutput(encoder.GetString(data, 0, num_read))
                RaiseEvent DatosRecibidos(encoder.GetString(data, 0, num_read))
                clientSocket.BeginReceive(data, 0, 255, SocketFlags.None, callback, data)
            Else
                clientSocket.Close()
                RaiseEvent Actualizacion("Se Corto la conexion con el Servidor")
            End If
        Catch exception As Exception
            'clientSocket.Close()
            RaiseEvent Actualizacion("Se Corto la conexion con el Servidor")
        End Try
    End Sub

    Public Function pad(ByVal cadena As String, ByVal ancho As Integer) As String
        Dim cadena2 As String = ""
        Dim i As Integer

        If cadena.Length > ancho Then
            cadena2 = cadena.Substring(cadena.Length - ancho, ancho)
        ElseIf cadena.Length = ancho Then
            cadena2 = cadena
        Else
            For i = 1 To (ancho - cadena.Length)
                cadena2 = cadena2 & " "
            Next
            cadena2 = cadena2 + cadena
        End If
        Return cadena2
    End Function



End Class
