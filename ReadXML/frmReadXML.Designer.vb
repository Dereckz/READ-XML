<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmReadXML
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmReadXML))
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.tsbNuevo = New System.Windows.Forms.ToolStripButton()
        Me.tsAcumulados = New System.Windows.Forms.ToolStripButton()
        Me.tsbCancelar = New System.Windows.Forms.ToolStripButton()
        Me.tsbProcesar = New System.Windows.Forms.ToolStripButton()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.lsvLista = New System.Windows.Forms.ListView()
        Me.chkAll = New System.Windows.Forms.CheckBox()
        Me.lblRuta = New System.Windows.Forms.Label()
        Me.ToolStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStrip1
        '
        Me.ToolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.ToolStrip1.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsbNuevo, Me.tsAcumulados, Me.tsbCancelar, Me.tsbProcesar})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(981, 54)
        Me.ToolStrip1.TabIndex = 32
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'tsbNuevo
        '
        Me.tsbNuevo.Image = CType(resources.GetObject("tsbNuevo.Image"), System.Drawing.Image)
        Me.tsbNuevo.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbNuevo.Name = "tsbNuevo"
        Me.tsbNuevo.Size = New System.Drawing.Size(80, 51)
        Me.tsbNuevo.Text = "Agregar XML"
        Me.tsbNuevo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsAcumulados
        '
        Me.tsAcumulados.AutoSize = False
        Me.tsAcumulados.Image = CType(resources.GetObject("tsAcumulados.Image"), System.Drawing.Image)
        Me.tsAcumulados.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsAcumulados.Name = "tsAcumulados"
        Me.tsAcumulados.Size = New System.Drawing.Size(90, 51)
        Me.tsAcumulados.Text = "Enviar Excel"
        Me.tsAcumulados.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbCancelar
        '
        Me.tsbCancelar.AutoSize = False
        Me.tsbCancelar.Image = CType(resources.GetObject("tsbCancelar.Image"), System.Drawing.Image)
        Me.tsbCancelar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbCancelar.Name = "tsbCancelar"
        Me.tsbCancelar.Size = New System.Drawing.Size(90, 51)
        Me.tsbCancelar.Text = "Cancelar"
        Me.tsbCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'tsbProcesar
        '
        Me.tsbProcesar.Enabled = False
        Me.tsbProcesar.Image = CType(resources.GetObject("tsbProcesar.Image"), System.Drawing.Image)
        Me.tsbProcesar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.tsbProcesar.Name = "tsbProcesar"
        Me.tsbProcesar.Size = New System.Drawing.Size(98, 51)
        Me.tsbProcesar.Text = "Procesar archivo"
        Me.tsbProcesar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.tsbProcesar.Visible = False
        '
        'Panel1
        '
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.lsvLista)
        Me.Panel1.Controls.Add(Me.chkAll)
        Me.Panel1.Location = New System.Drawing.Point(12, 66)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(953, 435)
        Me.Panel1.TabIndex = 33
        '
        'lsvLista
        '
        Me.lsvLista.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lsvLista.CheckBoxes = True
        Me.lsvLista.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lsvLista.FullRowSelect = True
        Me.lsvLista.GridLines = True
        Me.lsvLista.HideSelection = False
        Me.lsvLista.Location = New System.Drawing.Point(12, 31)
        Me.lsvLista.MultiSelect = False
        Me.lsvLista.Name = "lsvLista"
        Me.lsvLista.Size = New System.Drawing.Size(934, 397)
        Me.lsvLista.TabIndex = 6
        Me.lsvLista.UseCompatibleStateImageBehavior = False
        Me.lsvLista.View = System.Windows.Forms.View.Details
        '
        'chkAll
        '
        Me.chkAll.AutoSize = True
        Me.chkAll.BackColor = System.Drawing.Color.Transparent
        Me.chkAll.Font = New System.Drawing.Font("Calibri", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkAll.Location = New System.Drawing.Point(12, 3)
        Me.chkAll.Name = "chkAll"
        Me.chkAll.Size = New System.Drawing.Size(107, 22)
        Me.chkAll.TabIndex = 5
        Me.chkAll.Text = "Marcar todos"
        Me.chkAll.UseVisualStyleBackColor = False
        '
        'lblRuta
        '
        Me.lblRuta.AutoSize = True
        Me.lblRuta.Location = New System.Drawing.Point(14, 518)
        Me.lblRuta.Name = "lblRuta"
        Me.lblRuta.Size = New System.Drawing.Size(38, 15)
        Me.lblRuta.TabIndex = 34
        Me.lblRuta.Text = "RUTA"
        '
        'frmReadXML
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(981, 561)
        Me.Controls.Add(Me.lblRuta)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.ToolStrip1)
        Me.Font = New System.Drawing.Font("MS Reference Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "frmReadXML"
        Me.Text = "READ XML"
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolStrip1 As System.Windows.Forms.ToolStrip
    Friend WithEvents tsbNuevo As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsAcumulados As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbCancelar As System.Windows.Forms.ToolStripButton
    Friend WithEvents tsbProcesar As System.Windows.Forms.ToolStripButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents chkAll As System.Windows.Forms.CheckBox
    Friend WithEvents lblRuta As System.Windows.Forms.Label
    Friend WithEvents lsvLista As System.Windows.Forms.ListView

End Class
