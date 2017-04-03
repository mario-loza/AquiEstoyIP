<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Cliente
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Cliente))
        Me.txtIdentificacion = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.chkAutostart = New System.Windows.Forms.CheckBox
        Me.cmbMinutos = New System.Windows.Forms.ComboBox
        Me.txtIp = New System.Windows.Forms.TextBox
        Me.txtPuerto = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.Label8 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.lstRegistro = New System.Windows.Forms.ListBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnBorrar = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnMinimizar = New System.Windows.Forms.Button
        Me.btnComenzar = New System.Windows.Forms.Button
        Me.btnSalir = New System.Windows.Forms.Button
        Me.tmrReloj = New System.Windows.Forms.Timer(Me.components)
        Me.nfi = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtIdentificacion
        '
        Me.txtIdentificacion.Location = New System.Drawing.Point(104, 27)
        Me.txtIdentificacion.MaxLength = 50
        Me.txtIdentificacion.Name = "txtIdentificacion"
        Me.txtIdentificacion.Size = New System.Drawing.Size(336, 20)
        Me.txtIdentificacion.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(107, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Mensaje__________"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.chkAutostart)
        Me.GroupBox1.Controls.Add(Me.cmbMinutos)
        Me.GroupBox1.Controls.Add(Me.txtIp)
        Me.GroupBox1.Controls.Add(Me.txtPuerto)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 73)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(452, 136)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Servidor"
        '
        'chkAutostart
        '
        Me.chkAutostart.AutoSize = True
        Me.chkAutostart.Checked = True
        Me.chkAutostart.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutostart.Location = New System.Drawing.Point(100, 107)
        Me.chkAutostart.Name = "chkAutostart"
        Me.chkAutostart.Size = New System.Drawing.Size(234, 17)
        Me.chkAutostart.TabIndex = 3
        Me.chkAutostart.Text = "Iniciar automaticamente al reiniciar el equipo"
        Me.chkAutostart.UseVisualStyleBackColor = True
        '
        'cmbMinutos
        '
        Me.cmbMinutos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbMinutos.FormattingEnabled = True
        Me.cmbMinutos.Items.AddRange(New Object() {"1", "2", "3", "5", "10", "15", "20", "25", "30", "45", "60"})
        Me.cmbMinutos.Location = New System.Drawing.Point(104, 73)
        Me.cmbMinutos.Name = "cmbMinutos"
        Me.cmbMinutos.Size = New System.Drawing.Size(72, 21)
        Me.cmbMinutos.TabIndex = 2
        '
        'txtIp
        '
        Me.txtIp.Location = New System.Drawing.Point(104, 17)
        Me.txtIp.MaxLength = 15
        Me.txtIp.Name = "txtIp"
        Me.txtIp.Size = New System.Drawing.Size(168, 20)
        Me.txtIp.TabIndex = 0
        '
        'txtPuerto
        '
        Me.txtPuerto.Location = New System.Drawing.Point(104, 45)
        Me.txtPuerto.MaxLength = 10
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(100, 20)
        Me.txtPuerto.TabIndex = 1
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(168, 81)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(62, 13)
        Me.Label7.TabIndex = 7
        Me.Label7.Text = "___Minutos"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(8, 81)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(113, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Enviar Cada________"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Puerto_____________"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 24)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(113, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Direccion IP________"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(476, 277)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Label8)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.txtIdentificacion)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(468, 251)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Configuracion"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Label8
        '
        Me.Label8.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(330, 228)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(128, 13)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "desmadre.inc@gmail.com"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstRegistro)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(468, 251)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Registro"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'lstRegistro
        '
        Me.lstRegistro.BackColor = System.Drawing.SystemColors.Info
        Me.lstRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstRegistro.FormattingEnabled = True
        Me.lstRegistro.Location = New System.Drawing.Point(3, 3)
        Me.lstRegistro.Name = "lstRegistro"
        Me.lstRegistro.ScrollAlwaysVisible = True
        Me.lstRegistro.Size = New System.Drawing.Size(462, 212)
        Me.lstRegistro.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnBorrar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 221)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(462, 27)
        Me.Panel2.TabIndex = 0
        '
        'btnBorrar
        '
        Me.btnBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBorrar.Location = New System.Drawing.Point(385, 3)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(75, 23)
        Me.btnBorrar.TabIndex = 0
        Me.btnBorrar.Text = "Limpiar"
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnMinimizar)
        Me.Panel1.Controls.Add(Me.btnComenzar)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 277)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(476, 33)
        Me.Panel1.TabIndex = 1
        '
        'btnMinimizar
        '
        Me.btnMinimizar.Location = New System.Drawing.Point(80, 4)
        Me.btnMinimizar.Name = "btnMinimizar"
        Me.btnMinimizar.Size = New System.Drawing.Size(75, 23)
        Me.btnMinimizar.TabIndex = 1
        Me.btnMinimizar.Text = "Minimizar"
        Me.btnMinimizar.UseVisualStyleBackColor = True
        '
        'btnComenzar
        '
        Me.btnComenzar.Location = New System.Drawing.Point(4, 4)
        Me.btnComenzar.Name = "btnComenzar"
        Me.btnComenzar.Size = New System.Drawing.Size(75, 23)
        Me.btnComenzar.TabIndex = 0
        Me.btnComenzar.Text = "Comenzar"
        Me.btnComenzar.UseVisualStyleBackColor = True
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Location = New System.Drawing.Point(397, 4)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'tmrReloj
        '
        '
        'nfi
        '
        Me.nfi.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.nfi.BalloonTipText = "Doble clic para Abrir"
        Me.nfi.Icon = CType(resources.GetObject("nfi.Icon"), System.Drawing.Icon)
        Me.nfi.Text = "AquiEstoy Cliente 1.0"
        '
        'Cliente
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(476, 310)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Cliente"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AquiEstoy Cliente 1.0"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents txtIdentificacion As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbMinutos As System.Windows.Forms.ComboBox
    Friend WithEvents txtIp As System.Windows.Forms.TextBox
    Friend WithEvents txtPuerto As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents lstRegistro As System.Windows.Forms.ListBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents btnComenzar As System.Windows.Forms.Button
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents tmrReloj As System.Windows.Forms.Timer
    Friend WithEvents nfi As System.Windows.Forms.NotifyIcon
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents chkAutostart As System.Windows.Forms.CheckBox
    Friend WithEvents btnMinimizar As System.Windows.Forms.Button

End Class
