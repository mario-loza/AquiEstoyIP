Imports System.IO
Public Class Servidor
    Dim escuchando As Boolean = False

    Private Sub Servidor_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.LeerDatos()
        If chkAutostart.Checked = True Then
            btnComenzar.PerformClick()
            btnMinimizar.PerformClick()
        End If
    End Sub

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If escuchando Then
            btnComenzar.PerformClick()
        End If
        Me.Close()
    End Sub

    Private Sub btnComenzar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComenzar.Click
        If escuchando Then
            btnComenzar.Text = "Comenzar"
            Me.Registrar("[Servidor] Terminando recepciones ...")
            'registro autostart
            If chkAutostart.Checked Then
                'utiles.Registro.Instancia.AutostartUsuario("AquiEstoy", Application.ExecutablePath, True)
            Else
                utiles.Registro.Instancia.AutostartUsuario("AquiEstoy", Application.ExecutablePath, False)
            End If
            Me.terminar_de_escuchar()
        Else
            If Validar() Then
                btnComenzar.Text = "Terminar"
                Me.Registrar("[Servidor] Empezando recepciones ...")
                Me.comenzar_a_escuchar()
                If Not escuchando Then
                    btnComenzar.Text = "Comenzar"
                    Me.Registrar("[Servidor] Terminando recepciones ...")
                Else
                    'registro autostart
                    If chkAutostart.Checked Then
                        utiles.Registro.Instancia.AutostartUsuario("AquiEstoy", Application.ExecutablePath, True)
                    Else
                        utiles.Registro.Instancia.AutostartUsuario("AquiEstoy", Application.ExecutablePath, False)
                    End If
                    'guardar parametros
                    GuardarDatos(chkAutostart.Checked, txtMiIp.Text, txtPuerto.Text)
                End If
            End If
        End If
    End Sub

    Private Function Validar() As Boolean
        Dim resultado As Boolean = True
        If txtPuerto.Text = "" Then
            MessageBox.Show("Debe indicar el puerto de escucha para recibir mensajes.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            resultado = False
        ElseIf (CInt(txtPuerto.Text) < 1024) Then
            MessageBox.Show("Debe indicar un puerto mayor a 1024.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            resultado = False
        ElseIf (CInt(txtPuerto.Text) > 32000) Then
            MessageBox.Show("Debe indicar un puerto menor a 32000.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            resultado = False
        End If
        Return resultado
    End Function

    Private Sub GuardarDatos(ByVal autoinicio As Boolean, ByVal ipservidor As String, ByVal puertoservidor As String)
        Dim dt As New DataTable
        dt.Columns.Add("autostart", System.Type.GetType("System.Boolean"))
        dt.Columns.Add("ip", System.Type.GetType("System.String"))
        dt.Columns.Add("puerto", System.Type.GetType("System.String"))
        Dim dr As DataRow
        dr = dt.NewRow
        dr("autostart") = autoinicio
        dr("ip") = ipservidor.Trim
        dr("puerto") = puertoservidor.Trim
        dt.Rows.Add(dr)
        dt.TableName = "configuracion"
        If File.Exists(Application.StartupPath & "\configuracion.aqt") Then
            File.Delete(Application.StartupPath & "\configuracion.aqt")
        End If
        dt.WriteXml(Application.StartupPath & "\configuracion.aqt", XmlWriteMode.WriteSchema)
        dt.Dispose()
    End Sub

    Private Sub LeerDatos()
        If File.Exists(Application.StartupPath & "\configuracion.aqt") Then
            Dim dt As New DataTable
            dt.ReadXml(Application.StartupPath & "\configuracion.aqt")
            If dt.Rows.Count > 0 Then
                txtMiIp.Text = CStr(dt.Rows(0)("ip"))
                txtPuerto.Text = CStr(dt.Rows(0)("puerto"))
                chkAutostart.Checked = CBool(dt.Rows(0)("autostart"))
            Else
                txtMiIp.Text = ""
                txtPuerto.Text = ""
                chkAutostart.Checked = False
            End If
            dt.Dispose()
        Else
            txtMiIp.Text = ""
            txtPuerto.Text = ""
            chkAutostart.Checked = False
        End If

    End Sub

#Region "Registro"

    Private Sub btnBorrar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBorrar.Click
        lstRegistro.Items.Clear()
    End Sub

    Public Delegate Sub actualizaUIdelegate(ByVal progreso As String)

    Private Sub registrar_thread(ByVal mensaje As String)
        If lstRegistro.Items.Count > 30000 Then
            lstRegistro.Items.RemoveAt(0)
        End If
        mensaje = Now.Year.ToString("0000") & Now.Month.ToString("00") & Now.Day.ToString("00") & " " & Now.Hour.ToString("00") & ":" & Now.Minute.ToString("00") & " - " & mensaje
        lstRegistro.Items.Add(mensaje)
    End Sub

    Private Sub Registrar(ByVal mensaje As String)
        If Me.InvokeRequired Then
            Dim handler As New actualizaUIdelegate(AddressOf registrar_thread)
            Dim args() As Object = {mensaje} '{mensaje,customers}
            Me.BeginInvoke(handler, args)
        Else
            registrar_thread(mensaje)
        End If
    End Sub

#End Region

#Region "iconize"
    Private Sub nfi_DoubleClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles nfi.DoubleClick
        nfi.Visible = False
        Me.Visible = True
        Me.ShowInTaskbar = True
        Me.WindowState = FormWindowState.Normal
    End Sub

    

    Private Sub Servidor_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        If Me.WindowState = FormWindowState.Minimized Then
            Me.ShowInTaskbar = False
            nfi.Icon = Me.Icon
            Me.Visible = False
            nfi.Visible = True
        End If
    End Sub
#End Region

#Region "Socket"
    Dim WithEvents Servidor As New sockets.TCP_Servidor

    Private Sub comenzar_a_escuchar()
        'Me.coneccionSaldos = sia_DAL.Datos.Instancia.ConeccionIndividual()
        Servidor.PuertoDeEscucha = CInt(txtPuerto.Text)
        If Servidor.IniciarServidor(txtMiIp.Text) Then
            Servidor.AceptarConecciones()
            escuchando = True
        End If
    End Sub

    Private Sub terminar_de_escuchar()
        Servidor.Cerrar()
        escuchando = False
    End Sub

    Private Sub Servidor_actualizacion(ByVal mensaje As String) Handles Servidor.Actualizacion
        SyncLock Me
            Registrar(mensaje)
        End SyncLock
    End Sub

    Public Sub Servidor_NuevaConexion(ByVal IDTerminal As Net.IPEndPoint) Handles Servidor.NuevaConexion
        'SyncLock Me
        '    Me.Registrar("[Servidor] Conexion iniciada desde :" & IDTerminal.Address.ToString())
        'End SyncLock
    End Sub

    Private Sub Servidor_DatosRecibidos(ByVal IDTerminal As Net.IPEndPoint, ByVal mensaje As String) Handles Servidor.DatosRecibidos
        Try
            SyncLock Me
                Me.Registrar("[" & IDTerminal.Address.ToString() & "] " & CStr(mensaje) & " ")
            End SyncLock
        Catch ex As Exception
        End Try
    End Sub

#End Region

    Private Sub btnMinimizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub

End Class
