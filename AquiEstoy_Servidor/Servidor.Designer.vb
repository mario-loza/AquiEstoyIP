<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Servidor
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Servidor))
        Me.lstRegistro = New System.Windows.Forms.ListBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.btnBorrar = New System.Windows.Forms.Button
        Me.txtPuerto = New System.Windows.Forms.TextBox
        Me.btnComenzar = New System.Windows.Forms.Button
        Me.nfi = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.txtMiIp = New System.Windows.Forms.TextBox
        Me.btnSalir = New System.Windows.Forms.Button
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.chkAutostart = New System.Windows.Forms.CheckBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnMinimizar = New System.Windows.Forms.Button
        Me.Panel2.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'lstRegistro
        '
        Me.lstRegistro.BackColor = System.Drawing.SystemColors.Info
        Me.lstRegistro.Dock = System.Windows.Forms.DockStyle.Fill
        Me.lstRegistro.FormattingEnabled = True
        Me.lstRegistro.Location = New System.Drawing.Point(3, 3)
        Me.lstRegistro.Name = "lstRegistro"
        Me.lstRegistro.Size = New System.Drawing.Size(494, 212)
        Me.lstRegistro.TabIndex = 1
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.btnBorrar)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(3, 220)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(494, 31)
        Me.Panel2.TabIndex = 0
        '
        'btnBorrar
        '
        Me.btnBorrar.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBorrar.Location = New System.Drawing.Point(417, 4)
        Me.btnBorrar.Name = "btnBorrar"
        Me.btnBorrar.Size = New System.Drawing.Size(75, 23)
        Me.btnBorrar.TabIndex = 0
        Me.btnBorrar.Text = "Borrar Registro"
        Me.btnBorrar.UseVisualStyleBackColor = True
        '
        'txtPuerto
        '
        Me.txtPuerto.Location = New System.Drawing.Point(110, 56)
        Me.txtPuerto.MaxLength = 10
        Me.txtPuerto.Name = "txtPuerto"
        Me.txtPuerto.Size = New System.Drawing.Size(100, 20)
        Me.txtPuerto.TabIndex = 1
        '
        'btnComenzar
        '
        Me.btnComenzar.Location = New System.Drawing.Point(6, 3)
        Me.btnComenzar.Name = "btnComenzar"
        Me.btnComenzar.Size = New System.Drawing.Size(75, 23)
        Me.btnComenzar.TabIndex = 0
        Me.btnComenzar.Text = "Comenzar"
        Me.btnComenzar.UseVisualStyleBackColor = True
        '
        'nfi
        '
        Me.nfi.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info
        Me.nfi.BalloonTipText = "Doble clic para Abrir"
        Me.nfi.Icon = CType(resources.GetObject("nfi.Icon"), System.Drawing.Icon)
        Me.nfi.Text = "AquiEstoy Servidor 1.0"
        '
        'txtMiIp
        '
        Me.txtMiIp.Location = New System.Drawing.Point(110, 28)
        Me.txtMiIp.MaxLength = 15
        Me.txtMiIp.Name = "txtMiIp"
        Me.txtMiIp.Size = New System.Drawing.Size(176, 20)
        Me.txtMiIp.TabIndex = 0
        '
        'btnSalir
        '
        Me.btnSalir.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSalir.Location = New System.Drawing.Point(425, 3)
        Me.btnSalir.Name = "btnSalir"
        Me.btnSalir.Size = New System.Drawing.Size(75, 23)
        Me.btnSalir.TabIndex = 2
        Me.btnSalir.Text = "Salir"
        Me.btnSalir.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(8, 63)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(145, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Puerto de escucha________"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(8, 35)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Mi IP______________"
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(508, 280)
        Me.TabControl1.TabIndex = 0
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.chkAutostart)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.txtMiIp)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.txtPuerto)
        Me.TabPage1.Controls.Add(Me.Label4)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(500, 254)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Configuracion"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'chkAutostart
        '
        Me.chkAutostart.AutoSize = True
        Me.chkAutostart.Checked = True
        Me.chkAutostart.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkAutostart.Location = New System.Drawing.Point(12, 96)
        Me.chkAutostart.Name = "chkAutostart"
        Me.chkAutostart.Size = New System.Drawing.Size(234, 17)
        Me.chkAutostart.TabIndex = 15
        Me.chkAutostart.Text = "Iniciar automaticamente al reiniciar el equipo"
        Me.chkAutostart.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(364, 232)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "desmadre.inc@gmail.com"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.lstRegistro)
        Me.TabPage2.Controls.Add(Me.Panel2)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(500, 254)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Registro"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnMinimizar)
        Me.Panel1.Controls.Add(Me.btnComenzar)
        Me.Panel1.Controls.Add(Me.btnSalir)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel1.Location = New System.Drawing.Point(0, 280)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(508, 29)
        Me.Panel1.TabIndex = 1
        '
        'btnMinimizar
        '
        Me.btnMinimizar.Location = New System.Drawing.Point(84, 3)
        Me.btnMinimizar.Name = "btnMinimizar"
        Me.btnMinimizar.Size = New System.Drawing.Size(75, 23)
        Me.btnMinimizar.TabIndex = 1
        Me.btnMinimizar.Text = "Minimizar"
        Me.btnMinimizar.UseVisualStyleBackColor = True
        '
        'Servidor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(508, 309)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Servidor"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "AquiEstoy Servidor 1.0"
        Me.Panel2.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lstRegistro As System.Windows.Forms.ListBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents btnBorrar As System.Windows.Forms.Button
    Friend WithEvents txtPuerto As System.Windows.Forms.TextBox
    Friend WithEvents btnComenzar As System.Windows.Forms.Button
    Friend WithEvents nfi As System.Windows.Forms.NotifyIcon
    Friend WithEvents txtMiIp As System.Windows.Forms.TextBox
    Friend WithEvents btnSalir As System.Windows.Forms.Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents chkAutostart As System.Windows.Forms.CheckBox
    Friend WithEvents btnMinimizar As System.Windows.Forms.Button

End Class
