<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainFm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainFm))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.paybackTb = New System.Windows.Forms.TextBox()
        Me.elecCostTb = New System.Windows.Forms.TextBox()
        Me.panelCostTb = New System.Windows.Forms.TextBox()
        Me.systemEffTb = New System.Windows.Forms.TextBox()
        Me.panelEffTb = New System.Windows.Forms.TextBox()
        Me.selectBt = New System.Windows.Forms.Button()
        Me.ExitBt = New System.Windows.Forms.Button()
        Me.cbxBuildingSel = New System.Windows.Forms.ComboBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.zoomBt = New System.Windows.Forms.Button()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 0
        '
        'TextBox1
        '
        Me.TextBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox1.Location = New System.Drawing.Point(51, 29)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(292, 76)
        Me.TextBox1.TabIndex = 1
        Me.TextBox1.Text = resources.GetString("TextBox1.Text")
        Me.TextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(96, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(115, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Payback period (years)"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(88, 173)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Avg cost of electricity ($)"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(48, 200)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Total inst. cost per solar panel ($)"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(86, 257)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(125, 13)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Solar panel efficiency (%)"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(105, 229)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "System efficiency (%)"
        '
        'paybackTb
        '
        Me.paybackTb.Location = New System.Drawing.Point(228, 142)
        Me.paybackTb.Name = "paybackTb"
        Me.paybackTb.Size = New System.Drawing.Size(100, 20)
        Me.paybackTb.TabIndex = 7
        Me.paybackTb.Text = "20"
        '
        'elecCostTb
        '
        Me.elecCostTb.Location = New System.Drawing.Point(228, 170)
        Me.elecCostTb.Name = "elecCostTb"
        Me.elecCostTb.Size = New System.Drawing.Size(100, 20)
        Me.elecCostTb.TabIndex = 8
        Me.elecCostTb.Text = "0.1022"
        '
        'panelCostTb
        '
        Me.panelCostTb.Location = New System.Drawing.Point(228, 197)
        Me.panelCostTb.Name = "panelCostTb"
        Me.panelCostTb.Size = New System.Drawing.Size(100, 20)
        Me.panelCostTb.TabIndex = 9
        Me.panelCostTb.Text = "521.00"
        '
        'systemEffTb
        '
        Me.systemEffTb.Location = New System.Drawing.Point(228, 226)
        Me.systemEffTb.Name = "systemEffTb"
        Me.systemEffTb.Size = New System.Drawing.Size(100, 20)
        Me.systemEffTb.TabIndex = 10
        Me.systemEffTb.Text = "90"
        '
        'panelEffTb
        '
        Me.panelEffTb.Location = New System.Drawing.Point(228, 254)
        Me.panelEffTb.Name = "panelEffTb"
        Me.panelEffTb.Size = New System.Drawing.Size(100, 20)
        Me.panelEffTb.TabIndex = 11
        Me.panelEffTb.Text = "18"
        '
        'selectBt
        '
        Me.selectBt.Location = New System.Drawing.Point(145, 289)
        Me.selectBt.Name = "selectBt"
        Me.selectBt.Size = New System.Drawing.Size(157, 23)
        Me.selectBt.TabIndex = 12
        Me.selectBt.Text = "Select Feasible Points "
        Me.selectBt.UseVisualStyleBackColor = True
        '
        'ExitBt
        '
        Me.ExitBt.Location = New System.Drawing.Point(342, 332)
        Me.ExitBt.Name = "ExitBt"
        Me.ExitBt.Size = New System.Drawing.Size(75, 23)
        Me.ExitBt.TabIndex = 13
        Me.ExitBt.Text = "Exit"
        Me.ExitBt.UseVisualStyleBackColor = True
        '
        'cbxBuildingSel
        '
        Me.cbxBuildingSel.FormattingEnabled = True
        Me.cbxBuildingSel.Location = New System.Drawing.Point(554, 173)
        Me.cbxBuildingSel.Name = "cbxBuildingSel"
        Me.cbxBuildingSel.Size = New System.Drawing.Size(121, 21)
        Me.cbxBuildingSel.TabIndex = 15
        Me.cbxBuildingSel.Text = "<select building>"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(108, 117)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(220, 13)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "Selecting Points For Solar Installation"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(413, 117)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(262, 13)
        Me.Label8.TabIndex = 17
        Me.Label8.Text = "Generating Solar Data for a Specific Building"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(444, 176)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(91, 13)
        Me.Label9.TabIndex = 18
        Me.Label9.Text = "UNC- CH Building"
        '
        'zoomBt
        '
        Me.zoomBt.Location = New System.Drawing.Point(526, 219)
        Me.zoomBt.Name = "zoomBt"
        Me.zoomBt.Size = New System.Drawing.Size(121, 23)
        Me.zoomBt.TabIndex = 19
        Me.zoomBt.Text = "Zoom to Building"
        Me.zoomBt.UseVisualStyleBackColor = True
        '
        'TextBox2
        '
        Me.TextBox2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TextBox2.Location = New System.Drawing.Point(399, 29)
        Me.TextBox2.Multiline = True
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(276, 76)
        Me.TextBox2.TabIndex = 20
        Me.TextBox2.Text = resources.GetString("TextBox2.Text")
        Me.TextBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'MainFm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(712, 367)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.zoomBt)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cbxBuildingSel)
        Me.Controls.Add(Me.ExitBt)
        Me.Controls.Add(Me.selectBt)
        Me.Controls.Add(Me.panelEffTb)
        Me.Controls.Add(Me.systemEffTb)
        Me.Controls.Add(Me.panelCostTb)
        Me.Controls.Add(Me.elecCostTb)
        Me.Controls.Add(Me.paybackTb)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Name = "MainFm"
        Me.Tag = ""
        Me.Text = "Rooftop Solar Feasibility Calculator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents paybackTb As System.Windows.Forms.TextBox
    Friend WithEvents elecCostTb As System.Windows.Forms.TextBox
    Friend WithEvents panelCostTb As System.Windows.Forms.TextBox
    Friend WithEvents systemEffTb As System.Windows.Forms.TextBox
    Friend WithEvents panelEffTb As System.Windows.Forms.TextBox
    Friend WithEvents selectBt As System.Windows.Forms.Button
    Friend WithEvents ExitBt As System.Windows.Forms.Button
    Friend WithEvents cbxBuildingSel As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents zoomBt As System.Windows.Forms.Button
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
End Class
