<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FRM_Products
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.BTN_Search = New System.Windows.Forms.Button()
        Me.BTN_Refresh = New System.Windows.Forms.Button()
        Me.BTN_Clear = New System.Windows.Forms.Button()
        Me.BTN_Delete = New System.Windows.Forms.Button()
        Me.BTN_Update = New System.Windows.Forms.Button()
        Me.BTN_Add = New System.Windows.Forms.Button()
        Me.TXT_Search = New System.Windows.Forms.TextBox()
        Me.TXT_ProductNameDUMMY = New System.Windows.Forms.TextBox()
        Me.NMRC_Quantity = New System.Windows.Forms.NumericUpDown()
        Me.TXT_PriceRange = New System.Windows.Forms.TextBox()
        Me.TXT_ProductName = New System.Windows.Forms.TextBox()
        Me.TXT_ProductID = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.NMRC_Quantity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.MaximumSize = New System.Drawing.Size(813, 564)
        Me.Panel1.MinimumSize = New System.Drawing.Size(813, 564)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(813, 564)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Panel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(177, Byte), Integer), CType(CType(182, Byte), Integer), CType(CType(126, Byte), Integer))
        Me.Panel2.Controls.Add(Me.BTN_Search)
        Me.Panel2.Controls.Add(Me.BTN_Refresh)
        Me.Panel2.Controls.Add(Me.BTN_Clear)
        Me.Panel2.Controls.Add(Me.BTN_Delete)
        Me.Panel2.Controls.Add(Me.BTN_Update)
        Me.Panel2.Controls.Add(Me.BTN_Add)
        Me.Panel2.Controls.Add(Me.TXT_Search)
        Me.Panel2.Controls.Add(Me.TXT_ProductNameDUMMY)
        Me.Panel2.Controls.Add(Me.NMRC_Quantity)
        Me.Panel2.Controls.Add(Me.TXT_PriceRange)
        Me.Panel2.Controls.Add(Me.TXT_ProductName)
        Me.Panel2.Controls.Add(Me.TXT_ProductID)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.DataGridView1)
        Me.Panel2.Location = New System.Drawing.Point(10, 7)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(776, 510)
        Me.Panel2.TabIndex = 0
        '
        'BTN_Search
        '
        Me.BTN_Search.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.BTN_Search.Enabled = False
        Me.BTN_Search.FlatAppearance.BorderSize = 0
        Me.BTN_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Search.ForeColor = System.Drawing.Color.White
        Me.BTN_Search.Location = New System.Drawing.Point(286, 29)
        Me.BTN_Search.Name = "BTN_Search"
        Me.BTN_Search.Size = New System.Drawing.Size(53, 19)
        Me.BTN_Search.TabIndex = 87
        Me.BTN_Search.Text = "SEARCH"
        Me.BTN_Search.UseVisualStyleBackColor = False
        '
        'BTN_Refresh
        '
        Me.BTN_Refresh.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.BTN_Refresh.FlatAppearance.BorderSize = 0
        Me.BTN_Refresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Refresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Refresh.ForeColor = System.Drawing.Color.White
        Me.BTN_Refresh.Location = New System.Drawing.Point(584, 463)
        Me.BTN_Refresh.Name = "BTN_Refresh"
        Me.BTN_Refresh.Size = New System.Drawing.Size(178, 26)
        Me.BTN_Refresh.TabIndex = 86
        Me.BTN_Refresh.Text = "REFRESH ALL"
        Me.BTN_Refresh.UseVisualStyleBackColor = False
        '
        'BTN_Clear
        '
        Me.BTN_Clear.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.BTN_Clear.FlatAppearance.BorderSize = 0
        Me.BTN_Clear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Clear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Clear.ForeColor = System.Drawing.Color.White
        Me.BTN_Clear.Location = New System.Drawing.Point(194, 462)
        Me.BTN_Clear.Name = "BTN_Clear"
        Me.BTN_Clear.Size = New System.Drawing.Size(133, 26)
        Me.BTN_Clear.TabIndex = 85
        Me.BTN_Clear.Text = "CLEAR"
        Me.BTN_Clear.UseVisualStyleBackColor = False
        '
        'BTN_Delete
        '
        Me.BTN_Delete.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.BTN_Delete.Enabled = False
        Me.BTN_Delete.FlatAppearance.BorderSize = 0
        Me.BTN_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Delete.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Delete.ForeColor = System.Drawing.Color.White
        Me.BTN_Delete.Location = New System.Drawing.Point(20, 462)
        Me.BTN_Delete.Name = "BTN_Delete"
        Me.BTN_Delete.Size = New System.Drawing.Size(133, 26)
        Me.BTN_Delete.TabIndex = 84
        Me.BTN_Delete.Text = "DELETE"
        Me.BTN_Delete.UseVisualStyleBackColor = False
        '
        'BTN_Update
        '
        Me.BTN_Update.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.BTN_Update.Enabled = False
        Me.BTN_Update.FlatAppearance.BorderSize = 0
        Me.BTN_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Update.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Update.ForeColor = System.Drawing.Color.White
        Me.BTN_Update.Location = New System.Drawing.Point(194, 424)
        Me.BTN_Update.Name = "BTN_Update"
        Me.BTN_Update.Size = New System.Drawing.Size(133, 26)
        Me.BTN_Update.TabIndex = 83
        Me.BTN_Update.Text = "UPDATE"
        Me.BTN_Update.UseVisualStyleBackColor = False
        '
        'BTN_Add
        '
        Me.BTN_Add.BackColor = System.Drawing.Color.DarkOliveGreen
        Me.BTN_Add.FlatAppearance.BorderSize = 0
        Me.BTN_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.BTN_Add.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTN_Add.ForeColor = System.Drawing.Color.White
        Me.BTN_Add.Location = New System.Drawing.Point(20, 427)
        Me.BTN_Add.Name = "BTN_Add"
        Me.BTN_Add.Size = New System.Drawing.Size(133, 26)
        Me.BTN_Add.TabIndex = 82
        Me.BTN_Add.Text = "ADD"
        Me.BTN_Add.UseVisualStyleBackColor = False
        '
        'TXT_Search
        '
        Me.TXT_Search.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_Search.Location = New System.Drawing.Point(167, 28)
        Me.TXT_Search.Margin = New System.Windows.Forms.Padding(0)
        Me.TXT_Search.Name = "TXT_Search"
        Me.TXT_Search.Size = New System.Drawing.Size(113, 20)
        Me.TXT_Search.TabIndex = 81
        '
        'TXT_ProductNameDUMMY
        '
        Me.TXT_ProductNameDUMMY.Location = New System.Drawing.Point(372, 468)
        Me.TXT_ProductNameDUMMY.Name = "TXT_ProductNameDUMMY"
        Me.TXT_ProductNameDUMMY.ReadOnly = True
        Me.TXT_ProductNameDUMMY.Size = New System.Drawing.Size(173, 20)
        Me.TXT_ProductNameDUMMY.TabIndex = 80
        Me.TXT_ProductNameDUMMY.Visible = False
        '
        'NMRC_Quantity
        '
        Me.NMRC_Quantity.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.NMRC_Quantity.Location = New System.Drawing.Point(166, 202)
        Me.NMRC_Quantity.Margin = New System.Windows.Forms.Padding(0)
        Me.NMRC_Quantity.Name = "NMRC_Quantity"
        Me.NMRC_Quantity.ReadOnly = True
        Me.NMRC_Quantity.Size = New System.Drawing.Size(173, 20)
        Me.NMRC_Quantity.TabIndex = 79
        '
        'TXT_PriceRange
        '
        Me.TXT_PriceRange.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_PriceRange.Location = New System.Drawing.Point(165, 166)
        Me.TXT_PriceRange.Margin = New System.Windows.Forms.Padding(0)
        Me.TXT_PriceRange.Name = "TXT_PriceRange"
        Me.TXT_PriceRange.Size = New System.Drawing.Size(173, 20)
        Me.TXT_PriceRange.TabIndex = 78
        '
        'TXT_ProductName
        '
        Me.TXT_ProductName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_ProductName.Location = New System.Drawing.Point(166, 130)
        Me.TXT_ProductName.Margin = New System.Windows.Forms.Padding(0)
        Me.TXT_ProductName.Name = "TXT_ProductName"
        Me.TXT_ProductName.Size = New System.Drawing.Size(173, 20)
        Me.TXT_ProductName.TabIndex = 77
        '
        'TXT_ProductID
        '
        Me.TXT_ProductID.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TXT_ProductID.Location = New System.Drawing.Point(166, 92)
        Me.TXT_ProductID.Margin = New System.Windows.Forms.Padding(0)
        Me.TXT_ProductID.Name = "TXT_ProductID"
        Me.TXT_ProductID.ReadOnly = True
        Me.TXT_ProductID.Size = New System.Drawing.Size(173, 20)
        Me.TXT_ProductID.TabIndex = 76
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(17, 202)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(76, 20)
        Me.Label5.TabIndex = 75
        Me.Label5.Text = "Quantity"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(17, 166)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 20)
        Me.Label4.TabIndex = 74
        Me.Label4.Text = "Price"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(17, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(122, 20)
        Me.Label3.TabIndex = 73
        Me.Label3.Text = "Product Name"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(17, 92)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(95, 20)
        Me.Label2.TabIndex = 72
        Me.Label2.Text = "Product ID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(18, 27)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(66, 20)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Search"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToResizeColumns = False
        Me.DataGridView1.AllowUserToResizeRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.Color.White
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle2.BackColor = System.Drawing.Color.Pink
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Cursor = System.Windows.Forms.Cursors.Arrow
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.GridColor = System.Drawing.SystemColors.ButtonFace
        Me.DataGridView1.Location = New System.Drawing.Point(372, 27)
        Me.DataGridView1.Margin = New System.Windows.Forms.Padding(0)
        Me.DataGridView1.MultiSelect = False
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle4
        Me.DataGridView1.RowHeadersVisible = False
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.LavenderBlush
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black
        DataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle5
        Me.DataGridView1.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.DataGridView1.RowTemplate.ReadOnly = True
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.ShowEditingIcon = False
        Me.DataGridView1.Size = New System.Drawing.Size(390, 423)
        Me.DataGridView1.TabIndex = 29
        '
        'FRM_Products
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(793, 521)
        Me.Controls.Add(Me.Panel1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.MaximizeBox = False
        Me.MaximumSize = New System.Drawing.Size(813, 564)
        Me.MinimizeBox = False
        Me.MinimumSize = New System.Drawing.Size(813, 564)
        Me.Name = "FRM_Products"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Products"
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.NMRC_Quantity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents Label1 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents TXT_ProductID As TextBox
    Friend WithEvents TXT_PriceRange As TextBox
    Friend WithEvents TXT_ProductName As TextBox
    Friend WithEvents NMRC_Quantity As NumericUpDown
    Friend WithEvents TXT_ProductNameDUMMY As TextBox
    Friend WithEvents TXT_Search As TextBox
    Friend WithEvents BTN_Update As Button
    Friend WithEvents BTN_Add As Button
    Friend WithEvents BTN_Refresh As Button
    Friend WithEvents BTN_Clear As Button
    Friend WithEvents BTN_Delete As Button
    Friend WithEvents BTN_Search As Button
End Class
