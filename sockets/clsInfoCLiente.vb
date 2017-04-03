
Imports System.Net.Sockets
Imports System.Threading
Public Class clsInfoCliente
    'Esta estructura permite guardar la información sobre un cliente 
    Public Socket As Socket 'Socket utilizado para mantener la conexion con el cliente 
    Public Thread As Thread 'Thread utilizado para escuchar al cliente 
    Public UltimosDatosRecibidos As String 'Ultimos datos enviados por el cliente 
End Class


