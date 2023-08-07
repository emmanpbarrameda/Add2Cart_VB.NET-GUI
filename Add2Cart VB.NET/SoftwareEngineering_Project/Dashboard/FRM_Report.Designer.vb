<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FRM_Report
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
        Me.PdfViewer1 = New Spire.PdfViewer.Forms.PdfViewer()
        Me.BTN_Print = New System.Windows.Forms.Button()
        Me.BTN_ClearFilters = New System.Windows.Forms.Button()
        Me.CBO_Filters = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'PdfViewer1
        '
        Me.PdfViewer1.FindTextHighLightColor = System.Drawing.Color.FromArgb(CType(CType(200, Byte), Integer), CType(CType(153, Byte), Integer), CType(CType(193, Byte), Integer), CType(CType(218, Byte), Integer))
        Me.PdfViewer1.FormFillEnabled = False
        Me.PdfViewer1.IgnoreCase = False
        Me.PdfViewer1.IsToolBarVisible = True
        Me.PdfViewer1.Location = New System.Drawing.Point(12, 143)
        Me.PdfViewer1.MultiPagesThreshold = 60
        Me.PdfViewer1.Name = "PdfViewer1"
        Me.PdfViewer1.OnRenderPageExceptionEvent = Nothing
        Me.PdfViewer1.Size = New System.Drawing.Size(1087, 474)
        Me.PdfViewer1.TabIndex = 133
        Me.PdfViewer1.Text = "PdfViewer1"
        Me.PdfViewer1.Threshold = 60
        Me.PdfViewer1.ViewerBackgroundColor = System.Drawing.Color.FromArgb(CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer), CType(CType(229, Byte), Integer))
        '
        'BTN_Print
        '
        Me.BTN_Print.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.BTN_Print.FlatAppearance.BorderSize = 0
        Me.BTN_Print.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Print.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Print.ForeColor = System.Drawing.Color.White
        Me.BTN_Print.Location = New System.Drawing.Point(966, 93)
        Me.BTN_Print.Name = "BTN_Print"
        Me.BTN_Print.Size = New System.Drawing.Size(133, 26)
        Me.BTN_Print.TabIndex = 134
        Me.BTN_Print.Text = "PRINT"
        Me.BTN_Print.UseVisualStyleBackColor = False
        '
        'BTN_ClearFilters
        '
        Me.BTN_ClearFilters.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.BTN_ClearFilters.FlatAppearance.BorderSize = 0
        Me.BTN_ClearFilters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_ClearFilters.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_ClearFilters.ForeColor = System.Drawing.Color.White
        Me.BTN_ClearFilters.Location = New System.Drawing.Point(966, 65)
        Me.BTN_ClearFilters.Name = "BTN_ClearFilters"
        Me.BTN_ClearFilters.Size = New System.Drawing.Size(133, 26)
        Me.BTN_ClearFilters.TabIndex = 135
        Me.BTN_ClearFilters.Text = "CLEAR FILTERS"
        Me.BTN_ClearFilters.UseVisualStyleBackColor = False
        '
        'CBO_Filters
        '
        Me.CBO_Filters.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.CBO_Filters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CBO_Filters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.CBO_Filters.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CBO_Filters.ForeColor = System.Drawing.Color.White
        Me.CBO_Filters.FormattingEnabled = True
        Me.CBO_Filters.Location = New System.Drawing.Point(966, 41)
        Me.CBO_Filters.Margin = New System.Windows.Forms.Padding(0)
        Me.CBO_Filters.Name = "CBO_Filters"
        Me.CBO_Filters.Size = New System.Drawing.Size(133, 21)
        Me.CBO_Filters.TabIndex = 136
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(1027, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 20)
        Me.Label1.TabIndex = 137
        Me.Label1.Text = "S O R T"
        '
        'FRM_Report
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1111, 628)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.CBO_Filters)
        Me.Controls.Add(Me.BTN_ClearFilters)
        Me.Controls.Add(Me.BTN_Print)
        Me.Controls.Add(Me.PdfViewer1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FRM_Report"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Report"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents PdfViewer1 As Spire.PdfViewer.Forms.PdfViewer
    Friend WithEvents BTN_Print As Button
    Friend WithEvents BTN_ClearFilters As Button
    Friend WithEvents CBO_Filters As ComboBox
    Friend WithEvents Label1 As Label
End Class
