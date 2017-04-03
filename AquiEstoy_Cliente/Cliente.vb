Imports System.Threading
Imports System.ComponentModel
Imports System.IO
Public Class Cliente
    Dim enviando As Boolean = False

    Private Sub btnSalir_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSalir.Click
        If enviando Then
            btnComenzar.PerformClick()
        End If
        Me.Close()
    End Sub

    Private Sub btnComenzar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnComenzar.Click
        If enviando Then
            btnComenzar.Text = "Comenzar"
            Me.Registrar(" Terminando envios ...")
            'registro autostart
            If chkAutostart.Checked Then
                'utiles.Registro.Instancia.AutostartUsuario("AquiEstoy_Cliente", Application.ExecutablePath, True)
            Else
                utiles.Registro.Instancia.AutostartUsuario("AquiEstoy_Cliente", Application.ExecutablePath, False)
            End If
            Me.terminar_de_enviar()
        Else
            If Validar() Then
                btnComenzar.Text = "Terminar"
                Me.Registrar(" Comenzando envios ...")
                Me.comenzar_a_enviar()

                'registro autostart
                If chkAutostart.Checked Then
                    utiles.Registro.Instancia.AutostartUsuario("AquiEstoy_Cliente", Application.ExecutablePath, True)
                Else
                    utiles.Registro.Instancia.AutostartUsuario("AquiEstoy_Cliente", Application.ExecutablePath, False)
                End If
                'guardar parametros
                GuardarDatos(chkAutostart.Checked, txtIdentificacion.Text, txtIp.Text, txtPuerto.Text, CInt(cmbMinutos.Text))

            End If
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

#Region "Socket"

    Private Sub comenzar_a_enviar()
        tmrReloj.Interval = (1000 * 60) * CInt(cmbMinutos.Text)
        tmrReloj.Enabled = True
        tmrReloj.Start()
        enviando = True
        Me.enviarYa()
    End Sub

    Private Sub terminar_de_enviar()
        tmrReloj.Stop()
        tmrReloj.Enabled = False
        enviando = False
        bgWorker.CancelAsync()
    End Sub

    Private Sub timer_SaldosIP_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrReloj.Tick
        'Comenzar el hilo llamado a do_work
        Dim params As New utiles.parametros
        params.ip = txtIp.Text
        params.puerto = txtPuerto.Text
        params.mensaje = txtIdentificacion.Text
        
        bgWorker.RunWorkerAsync(params)
        enprogreso = True
        'fin de enviar
    End Sub

    Private Sub enviarYa()
        'Comenzar el hilo llamado a do_work
        Dim params As New utiles.parametros
        params.ip = txtIp.Text
        params.puerto = txtPuerto.Text
        params.mensaje = txtIdentificacion.Text

        bgWorker.RunWorkerAsync(params)
        enprogreso = True
        'fin de enviar
    End Sub

#End Region

#Region "CODIGO MULTIHILO"
    Dim WithEvents bgWorker As New System.ComponentModel.BackgroundWorker
    Dim enprogreso As Boolean = False

    Private Sub bgWorker_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgWorker.DoWork
        'este corre en un thread separado no usar elmentos de la iu
        Dim worker As System.ComponentModel.BackgroundWorker
        worker = CType(sender, System.ComponentModel.BackgroundWorker)
        e.Result = EnviarMensaje(CType(e.Argument, utiles.parametros), worker, e)
    End Sub

    Private Sub bgWorker_ProgressChanged(ByVal sender As Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgWorker.ProgressChanged
        Me.Registrar(e.UserState)
    End Sub

    Private Sub bgWorker_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgWorker.RunWorkerCompleted
        If Not (e.Error Is Nothing) Then
            Me.Registrar(e.Error.Message)
        ElseIf e.Cancelled Then
            Me.Registrar("[Cliente] La Operacion fue cancelada")
        Else
            Me.Registrar(CStr(e.Result))
        End If
        'Habilitar
        enprogreso = False
    End Sub

    'este procedimiento tiene que correr en un thread separado
    Private Function EnviarMensaje(ByVal parametros As utiles.parametros, ByVal worker As System.ComponentModel.BackgroundWorker, ByVal e As DoWorkEventArgs) As String
        Dim resultado As String
        Dim Cliente As New sockets.TCP_Cliente
        Dim rnd As New Random
        '##Chequeo de cancelacion
        If worker.CancellationPending = True Then
            e.Cancel = True
            worker.ReportProgress(0, "Operacion Cancelada")
            resultado = "Operacion Cancelada"
        Else
            'enviar a cada almacen especificado
            worker.ReportProgress(0, "Enviando mensaje a IP: " & parametros.ip & " : " & parametros.puerto)
            If Cliente.Conectarse(parametros.ip, CInt(parametros.puerto)) Then
                Try
                    Cliente.EnviarMensaje(parametros.mensaje)
                    resultado = "Se termino el envio del mensaje."
                Catch ex As Exception
                    resultado = "No se pudo enviar el mensaje."
                Finally
                    Cliente.Desconectarse()
                End Try
            Else
                resultado = "El destino no estaba disponible."
            End If
        End If
        '##fin chequeo de cancelacion
        Return resultado
    End Function

#End Region

    Private Sub Cliente_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbMinutos.SelectedIndex = 0
        bgWorker.WorkerReportsProgress = True
        bgWorker.WorkerSupportsCancellation = True
        Me.LeerDatos()
        If chkAutostart.Checked = True Then
            btnComenzar.PerformClick()
            btnMinimizar.PerformClick()
        End If
    End Sub

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

    Private Function Validar() As Boolean
        Dim resultado As Boolean = True
        If txtIp.Text = "" Then
            MessageBox.Show("Debe indicar la direccion IP a la que enviara los mensajes.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            resultado = False
        ElseIf txtPuerto.Text = "" Then
            MessageBox.Show("Debe indicar el puerto al que enviara los mensajes.", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
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

    Private Sub GuardarDatos(ByVal autoinicio As Boolean, ByVal mensaje As String, ByVal ipservidor As String, ByVal puertoservidor As String, ByVal minutos As Integer)
        Dim dt As New DataTable
        dt.Columns.Add("autostart", System.Type.GetType("System.Boolean"))
        dt.Columns.Add("mensaje", System.Type.GetType("System.String"))
        dt.Columns.Add("ip", System.Type.GetType("System.String"))
        dt.Columns.Add("puerto", System.Type.GetType("System.String"))
        dt.Columns.Add("minutos", System.Type.GetType("System.Int32"))
        Dim dr As DataRow
        dr = dt.NewRow
        dr("autostart") = autoinicio
        dr("mensaje") = mensaje
        dr("ip") = ipservidor.Trim
        dr("puerto") = puertoservidor.Trim
        dr("minutos") = minutos
        dt.Rows.Add(dr)
        dt.TableName = "configuracion"
        If File.Exists(Application.StartupPath & "\conf_cliente.aqt") Then
            File.Delete(Application.StartupPath & "\conf_cliente.aqt")
        End If
        dt.WriteXml(Application.StartupPath & "\conf_cliente.aqt", XmlWriteMode.WriteSchema)
        dt.Dispose()
    End Sub

    Private Sub LeerDatos()
        If File.Exists(Application.StartupPath & "\conf_cliente.aqt") Then
            Dim dt As New DataTable
            dt.ReadXml(Application.StartupPath & "\conf_cliente.aqt")
            If dt.Rows.Count > 0 Then
                txtIdentificacion.Text = CStr(dt.Rows(0)("mensaje"))
                txtIp.Text = CStr(dt.Rows(0)("ip"))
                txtPuerto.Text = CStr(dt.Rows(0)("puerto"))
                chkAutostart.Checked = CBool(dt.Rows(0)("autostart"))
                cmbMinutos.Text = CStr(dt.Rows(0)("minutos"))
            Else
                txtIdentificacion.Text = ""
                txtIp.Text = ""
                txtPuerto.Text = ""
                cmbMinutos.SelectedIndex = 0
                chkAutostart.Checked = False
            End If
            dt.Dispose()
        Else
            txtIdentificacion.Text = ""
            txtIp.Text = ""
            txtPuerto.Text = ""
            cmbMinutos.SelectedIndex = 0
            chkAutostart.Checked = False
        End If

    End Sub

    Private Sub btnMinimizar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMinimizar.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class
