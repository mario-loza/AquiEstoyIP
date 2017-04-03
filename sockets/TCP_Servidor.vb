Imports System.Threading
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class TCP_Servidor

#Region "VARIABLES"
    Dim serverSocket As Socket
    Private Clientes As New Hashtable     'Aqui se guarda la informacion de todos los clientes conectados 
    Dim connection_count As Int32
    Private tcpThd As Thread
    Private IDClienteActual As Net.IPEndPoint 'Ultimo cliente conectado 
    Private _PuertoDeEscucha As String
#End Region

#Region "EVENTOS"
    Public Event NuevaConexion(ByVal IDTerminal As Net.IPEndPoint)
    Public Event DatosRecibidos(ByVal IDTerminal As Net.IPEndPoint, ByVal cadena As String)
    Public Event ArchivoRecibido(ByVal IDTerminal As Net.IPEndPoint, ByVal ms As System.IO.MemoryStream)
    Public Event ConexionTerminada(ByVal IDTerminal As Net.IPEndPoint)
    Public Event Actualizacion(ByVal mensaje As String)
#End Region

#Region "PROPIEDADES"

    Property PuertoDeEscucha() As String
        Get
            PuertoDeEscucha = _PuertoDeEscucha
        End Get

        Set(ByVal Value As String)
            _PuertoDeEscucha = Value
        End Set
    End Property

#End Region

#Region "METODOS"

    Public Function IniciarServidor(ByVal ip As String) As Boolean
        Dim resultado As Boolean = False
        If ip.Trim = "" Then
            resultado = False
        Else

            Try
                RaiseEvent Actualizacion("[Servidor] Obteniendo informacion del IP Local " & ip) ' "Resolving local machine information")
                'Dim localMachineInfo As IPHostEntry = Dns.Resolve(Dns.GetHostName())
                'Dim myEndpoint As IPEndPoint = New IPEndPoint(localMachineInfo.AddressList(0), _PuertoDeEscucha)
                Dim myEndpoint As IPEndPoint = New IPEndPoint(IPAddress.Parse(ip), _PuertoDeEscucha)
                'updateLocalAddress(myEndpoint.ToString())
                RaiseEvent Actualizacion("[Servidor] Creando el Socket")
                serverSocket = New Socket(myEndpoint.Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp)
                RaiseEvent Actualizacion("[Servidor] Enlazando el Socket")
                serverSocket.Bind(myEndpoint)
                RaiseEvent Actualizacion("[Servidor] Comenzando a Escuchar")
                serverSocket.Listen(SocketOptionName.MaxConnections)
                resultado = True
            Catch socketException As SocketException
                RaiseEvent Actualizacion(socketException.ToString())
            Catch exception As Exception
                RaiseEvent Actualizacion(exception.ToString())
            End Try
        End If
        Return resultado
    End Function

    Public Sub AceptarConecciones()
        Try
            tcpThd = New Thread(New ThreadStart(AddressOf EsperarCliente))
            tcpThd.Start()
        Catch exception As Exception
            RaiseEvent Actualizacion(exception.ToString())
        End Try
    End Sub

    Public Function ObtenerDatos(ByVal IDCliente As Net.IPEndPoint) As String
        Dim InfoClienteSolicitado As clsInfoCliente

        'Obtengo la informacion del cliente solicitado 
        InfoClienteSolicitado = Clientes(IDCliente)

        ObtenerDatos = InfoClienteSolicitado.UltimosDatosRecibidos
    End Function

    Public Sub Cerrar(ByVal IDCliente As Net.IPEndPoint)
        Dim InfoClienteActual As clsInfoCliente
        'Obtengo la informacion del cliente solicitado 
        InfoClienteActual = Clientes(IDCliente)
        'Cierro la conexion con el cliente 
        InfoClienteActual.Thread.Abort()
        InfoClienteActual.Socket.Close()
    End Sub

    Public Sub Cerrar()
        Dim InfoClienteActual As clsInfoCliente
        'Recorro todos los clientes y voy cerrando las conexiones 
        For Each InfoClienteActual In Clientes.Values
            Call CerrarThread(InfoClienteActual.Socket.RemoteEndPoint)
        Next
        tcpThd.Abort()
        serverSocket.Close()
        SyncLock Me
            'Elimino el cliente del HashArray que guarda la informacion de los clientes 
            Clientes.Clear()
        End SyncLock

    End Sub

    Public Sub EnviarDatos(ByVal IDCliente As Net.IPEndPoint, ByVal Datos As String)
        Dim Cliente As clsInfoCliente

        'Obtengo la informacion del cliente al que se le quiere enviar el mensaje 
        Cliente = Clientes(IDCliente)

        'Le envio el mensaje 
        Cliente.Socket.Send(Encoding.ASCII.GetBytes(Datos))
    End Sub

    Public Sub EnviarDatos(ByVal Datos As String)
        Dim Cliente As clsInfoCliente

        'Recorro todos los clientes conectados, y les envio el mensaje recibido 
        'en el parametro Datos 
        For Each Cliente In Clientes
            EnviarDatos(Cliente.Socket.RemoteEndPoint, Datos)
        Next

    End Sub

#End Region

#Region "FUNCIONES PRIVADAS"

    Private Sub EsperarCliente()
        Try
            Dim connection_number As Long
            While True
                Dim new_connection As Socket = serverSocket.Accept()
                Dim connection As clsInfoCliente = New clsInfoCliente
                connection.Socket = new_connection
                IDClienteActual = new_connection.RemoteEndPoint
                'Create the thread for the receives.
                connection.Thread = New Thread(AddressOf RecivirDatos)
                SyncLock Me
                    Clientes.Add(IDClienteActual, connection)
                End SyncLock
                connection_number = Interlocked.Increment(connection_count)
                RaiseEvent NuevaConexion(IDClienteActual)
                connection.Thread.Start()
            End While
        Catch socketException As SocketException
            'WSAEINTR, this occurs if the form is shutting down
            If socketException.ErrorCode <> 10004 Then
                RaiseEvent Actualizacion(socketException.ToString())
            End If
        Catch exception As Exception
            RaiseEvent Actualizacion(exception.ToString())
        End Try
    End Sub

    Public Sub RecivirDatos()
        Dim IDReal As Net.IPEndPoint 'ID del cliente que se va a escuchar 
        Dim InfoClienteActual As clsInfoCliente  'Informacion del cliente que se va escuchar 
        Dim Ret As Integer = 0

        IDReal = IDClienteActual
        InfoClienteActual = Clientes(IDReal)

        Dim buffer(50) As Byte
        'Dim p As Integer
        'Dim res As String
        Try
            Dim done As Boolean = False
            While Not done
                Dim num_bytes As Int32 = InfoClienteActual.Socket.Receive(buffer)
                If 0 = num_bytes Then
                    'Genero el evento de la finalizacion de la conexion 
                    InfoClienteActual.Socket.Close()
                    SyncLock Me
                        Clientes.Remove(IDReal)
                    End SyncLock
                    done = True
                    Interlocked.Decrement(connection_count)
                    RaiseEvent ConexionTerminada(IDReal)
                Else
                    RaiseEvent DatosRecibidos(IDReal, Encoding.ASCII.GetString(buffer))
                End If
            End While
        Catch socketException As SocketException
            'WSAECONNRESET, the other side closed impolitely
            If socketException.ErrorCode = 10054 Then
                Interlocked.Decrement(connection_count)
                InfoClienteActual.Socket.Close()
                Clientes.Remove(IDReal)
                RaiseEvent ConexionTerminada(IDReal)
                'WSAEINTR, WSACONNABORTED this occurs if the form is shutting down
            ElseIf (socketException.ErrorCode <> 10004) And (socketException.ErrorCode <> 10053) Then
                RaiseEvent Actualizacion(socketException.ToString())
            End If
        Catch exception As Exception
            RaiseEvent Actualizacion(exception.Message)
        End Try
    End Sub

    Public Sub RecivirDatosArchivo()
        Dim IDReal As Net.IPEndPoint 'ID del cliente que se va a escuchar 
        Dim InfoClienteActual As clsInfoCliente  'Informacion del cliente que se va escuchar 
        Dim Ret As Integer = 0

        IDReal = IDClienteActual
        InfoClienteActual = Clientes(IDReal)

        Dim ms As New System.IO.MemoryStream
        Dim bytes() As Byte = New Byte(1024) {}
        Dim buffer(1024) As Byte
        'Dim p As Integer
        'Dim res As String
        Try
            Dim done As Boolean = False
            While Not done
                bytes = New Byte(1024) {}
                Dim num_bytes As Integer = InfoClienteActual.Socket.Receive(bytes)
                ms.Write(bytes, 0, num_bytes)
                System.Threading.Thread.Sleep(500)
                If num_bytes = 0 Then
                    'Genero el evento de la finalizacion de la conexion 
                    InfoClienteActual.Socket.Close()
                    SyncLock Me
                        Clientes.Remove(IDReal)
                    End SyncLock
                    done = True
                    Interlocked.Decrement(connection_count)
                    RaiseEvent ConexionTerminada(IDReal)
                End If
            End While
            RaiseEvent ArchivoRecibido(IDReal, ms)
        Catch socketException As SocketException
            'WSAECONNRESET, the other side closed impolitely
            If socketException.ErrorCode = 10054 Then
                Interlocked.Decrement(connection_count)
                InfoClienteActual.Socket.Close()
                Clientes.Remove(IDReal)
                RaiseEvent ConexionTerminada(IDReal)
                'WSAEINTR, WSACONNABORTED this occurs if the form is shutting down
            ElseIf (socketException.ErrorCode <> 10004) And (socketException.ErrorCode <> 10053) Then
                RaiseEvent Actualizacion(socketException.ToString())
            End If
        Catch exception As Exception
            RaiseEvent Actualizacion(exception.ToString())
        End Try
    End Sub

    Private Sub CerrarThread(ByVal IDCliente As Net.IPEndPoint)
        Dim InfoClienteActual As clsInfoCliente

        'Cierro el thread que se encargaba de escuchar al cliente especificado 
        InfoClienteActual = Clientes(IDCliente)

        Try
            InfoClienteActual.Socket.Close()
            InfoClienteActual.Thread.Abort()
        Catch e As Exception

        End Try
    End Sub

#End Region

End Class
