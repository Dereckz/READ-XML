Imports System.IO
Imports System.Xml
Imports ClosedXML.Excel

Public Class frmReadXML
    Dim emisor As New Emisor
    Dim receptor As New Receptor
    Dim comprobante As New Comprobante
    Dim nomina As New Nomina
    Dim nominaE As New NominaE
    Dim nominaR As New NominaR
    Dim otrospagos As New OtrosPagos
    Dim percepciones As New Percepciones
    Dim TimbreFiscalDigital As New TimbreFiscalDigital
    Dim item As ListViewItem

 

    Private Sub tsbNuevo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbNuevo.Click
        Dim dialogo As New OpenFileDialog
        lblRuta.Text = ""
        Dim idCFDI As Integer = 0
        lsvLista.Items.Clear()
        lsvLista.Columns.Clear()
        lsvLista.Clear()

        With dialogo
            .Multiselect = True
            .Title = "Búsqueda de XML"
            .Filter = "XML (xml)|*.xml;"
            .CheckFileExists = True
            If .ShowDialog = Windows.Forms.DialogResult.OK Then
                lblRuta.Text = .FileName
            End If
        End With

        cargarColumnas()


        For Each f In dialogo.FileNames

            idCFDI = idCFDI + 1

            abirXML(f)

            item = lsvLista.Items.Add(idCFDI)

            item.SubItems.Add(comprobante.Version)
            item.SubItems.Add(comprobante.Serie)
            item.SubItems.Add(comprobante.Fecha)
            item.SubItems.Add(comprobante.Moneda)
            item.SubItems.Add(comprobante.Subtotal)
            item.SubItems.Add(comprobante.Descuento)
            item.SubItems.Add(comprobante.Total)

            item.SubItems.Add(emisor.NombreE)
            item.SubItems.Add(emisor.RFCE)
            ' item.SubItems.Add(emisor.RegimenFiscalE)
            item.SubItems.Add(receptor.NombreR)
            item.SubItems.Add(receptor.RFCR)

            'item.SubItems.Add(TimbreFiscalDigital.Version)
            item.SubItems.Add(TimbreFiscalDigital.UUID)
            item.SubItems.Add(TimbreFiscalDigital.FechaTimbrado)

            'Nomina
            item.SubItems.Add(nomina.TipoNomina)
            item.SubItems.Add(nomina.FechaPago)
            item.SubItems.Add(nomina.FechaFechaInicialPago)
            item.SubItems.Add(nomina.FechaFinalPago)
            item.SubItems.Add(nomina.NumDiasPagados)
            item.SubItems.Add(nomina.TotalPercepciones)
            item.SubItems.Add(percepciones.Clave)
            item.SubItems.Add(percepciones.Concepto)
            item.SubItems.Add(percepciones.ImporteGravado)
            item.SubItems.Add(percepciones.ImporteExento)
            item.SubItems.Add(comprobante.Total)

        Next




    End Sub


    Private Sub abirXML(ByVal ruta As String)


        Try

            If lblRuta.Text <> " " Then
                Dim m_xmlr As XmlTextReader

                m_xmlr = New XmlTextReader(ruta)

                m_xmlr.WhitespaceHandling = WhitespaceHandling.None

               


                m_xmlr.Read()
                '      m_xmlr.Read()


                '  While Not m_xmlr.EOF
                While m_xmlr.Read





                    'If Not m_xmlr.IsStartElement Then
                    '    Exit While
                    'End If

                    If m_xmlr.Name = "cfdi:Comprobante" And m_xmlr.IsStartElement Then

                        comprobante.Version = m_xmlr.GetAttribute("Version")
                        comprobante.Serie = m_xmlr.GetAttribute("Serie")
                        comprobante.Fecha = m_xmlr.GetAttribute("Fecha")
                        comprobante.Moneda = m_xmlr.GetAttribute("Moneda")
                        comprobante.Subtotal = m_xmlr.GetAttribute("SubTotal")
                        comprobante.Descuento = m_xmlr.GetAttribute("Descuento")
                        comprobante.Total = m_xmlr.GetAttribute("Total")



                        '  m_xmlr.Read()
                    End If

                    'EMISOR
                    If m_xmlr.Name = "cfdi:Emisor" And m_xmlr.IsStartElement Then

                        emisor.NombreE = m_xmlr.GetAttribute("Nombre")
                        emisor.RFCE = m_xmlr.GetAttribute("Rfc")
                        emisor.RegimenFiscalE = m_xmlr.GetAttribute("RegimenFiscal")



                        '  m_xmlr.Read()
                    End If

                    'RECEPTOR
                    If m_xmlr.Name = "cfdi:Receptor" And m_xmlr.IsStartElement Then

                        receptor.NombreR = m_xmlr.GetAttribute("Nombre")
                        receptor.RFCR = m_xmlr.GetAttribute("Rfc")
                        receptor.UsoCFDI = m_xmlr.GetAttribute("UsoCFDI")


                        ' item.SubItems.Add(receptor.UsoCFDI)
                        ' m_xmlr.Read()

                    End If

                    If m_xmlr.Name = "nomina12:Nomina" And m_xmlr.IsStartElement Then

                        nomina.VersionN = m_xmlr.GetAttribute("Version")
                        nomina.TipoNomina = m_xmlr.GetAttribute("TipoNomina")
                        nomina.FechaPago = m_xmlr.GetAttribute("FechaPago")
                        nomina.FechaFechaInicialPago = m_xmlr.GetAttribute("FechaInicialPago")
                        nomina.FechaFinalPago = m_xmlr.GetAttribute("FechaFinalPago")
                        nomina.NumDiasPagados = m_xmlr.GetAttribute("NumDiasPagados")
                        nomina.TotalPercepciones = m_xmlr.GetAttribute("TotalPercepciones")
                        nomina.TotalDeducciones = m_xmlr.GetAttribute("TotalDeducciones")
                        nomina.TotalOtrosPagos = m_xmlr.GetAttribute("TotalOtrosPagos")

                    End If
                    If m_xmlr.Name = "nomina12:Emisor" And m_xmlr.IsStartElement Then
                        nominaE.RegistroPatronal = m_xmlr.GetAttribute("RegistroPatronal")
                        nominaE.Curp = m_xmlr.GetAttribute("Curp")
                        nominaE.NumSeguridadSocial = m_xmlr.GetAttribute("NumSeguridadSocial")
                        nominaE.FechaInicioRelLaboral = m_xmlr.GetAttribute("FechaInicioRelLaboral")
                        nominaE.Antigüedad = m_xmlr.GetAttribute("Antigüedad")
                        nominaE.TipoContrato = m_xmlr.GetAttribute("TipoContrato")
                        nominaE.Sindicalizado = m_xmlr.GetAttribute("Sindicalizado")
                        nominaE.TipoJornada = m_xmlr.GetAttribute("TipoJornada")

                    End If
                    If m_xmlr.Name = "nomina12:Receptor" And m_xmlr.IsStartElement Then
                        nominaR.Curp = m_xmlr.GetAttribute("Curp")
                        nominaR.NumSeguridadSocial = m_xmlr.GetAttribute("NumSeguridadSocial")
                        nominaR.FechaInicioRelLaboral = m_xmlr.GetAttribute("FechaInicioRelLaboral")
                        nominaR.Antigüedad = m_xmlr.GetAttribute("Antigüedad")
                        nominaR.TipoContrato = m_xmlr.GetAttribute("TipoContrato")
                        nominaR.Sindicalizado = m_xmlr.GetAttribute("Sindicalizado")
                        nominaR.TipoJornada = m_xmlr.GetAttribute("TipoJornada")
                        nominaR.TipoRegimen = m_xmlr.GetAttribute("TipoRegimen")
                        nominaR.NumEmpleado = m_xmlr.GetAttribute("NumEmpleado")
                        nominaR.Puesto = m_xmlr.GetAttribute("Puesto")
                        nominaR.RiesgoPuesto = m_xmlr.GetAttribute("RiesgoPuesto")
                        nominaR.PeriodicidadPago = m_xmlr.GetAttribute("PeriodicidadPago")
                        nominaR.SalarioDiarioIntegrado = m_xmlr.GetAttribute("SalarioDiarioIntegrado")
                        nominaR.SalarioBaseCotApor = m_xmlr.GetAttribute("SalarioBaseCotApor")
                        nominaR.ClaveEntFed = m_xmlr.GetAttribute("ClaveEntFed")

                    End If
                    If m_xmlr.Name = "nomina12:Percepciones" And m_xmlr.IsStartElement Then
                        percepciones.TotalSueldos = m_xmlr.GetAttribute("TotalSueldos")
                        percepciones.TotalGravado = m_xmlr.GetAttribute("TotalGravado")
                        percepciones.TotalExento = m_xmlr.GetAttribute("TotalExento")


                    End If
                    If m_xmlr.Name = "nomina12:Percepcion" And m_xmlr.IsStartElement Then
                        percepciones.TipoPercepcion = m_xmlr.GetAttribute("TipoPercepcion")
                        percepciones.Clave = m_xmlr.GetAttribute("Clave")
                        percepciones.Concepto = m_xmlr.GetAttribute("Concepto")
                        percepciones.ImporteGravado = m_xmlr.GetAttribute("ImporteGravado")
                        percepciones.ImporteExento = m_xmlr.GetAttribute("ImporteExento")

                    End If
                    If m_xmlr.Name = "nomina12:OtroPago" And m_xmlr.IsStartElement Then
                        otrospagos.TipoOtroPago = m_xmlr.GetAttribute("TipoOtroPago")
                        otrospagos.Clave = m_xmlr.GetAttribute("Clave")
                        otrospagos.Concepto = m_xmlr.GetAttribute("Concepto")
                        otrospagos.Importe = m_xmlr.GetAttribute("Importe")

                    End If
                    If m_xmlr.Name = "nomina12:SubsidioAlEmpleo" And m_xmlr.IsStartElement Then
                        otrospagos.SubsidioCausado = m_xmlr.GetAttribute("SubsidioCausado")
                    End If

                    'COMPLEMENTO                  
                    If m_xmlr.Name = "tfd:TimbreFiscalDigital" And m_xmlr.IsStartElement Then
                        TimbreFiscalDigital.Version = m_xmlr.GetAttribute("Version")
                        TimbreFiscalDigital.UUID = m_xmlr.GetAttribute("UUID")
                        TimbreFiscalDigital.FechaTimbrado = m_xmlr.GetAttribute("FechaTimbrado")
                        'm_xmlr.Read()
                        Exit While

                    End If

                End While

                ' Cerramos la lactura del archivo
                m_xmlr.Close()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

   
    Public Sub WriteRich(ByVal str As String, Optional ByVal niv As Int16 = 0)

        Dim esp As String = vbCrLf & ""
        'Dim item As ListViewItem = lsvLista.Items.Add(niv)
        For i As Integer = 1 To niv
            esp = esp + "    "
            ' item.SubItems.Add(esp & str)
        Next

        'fucnion que escribe eb el cuadro de texto
        '  Me.RtxtXmlReader.AppendText(esp & str)
        'txtEmisor.Text = esp & str
        '  item.SubItems.Add(esp & str)
    End Sub

    Public Sub LeerXml(ByVal S As Stream)
        Dim reader As New XmlTextReader(S)

        'no he probrado codigo aun toy apuradito mi veija ta que 
        reader.WhitespaceHandling = WhitespaceHandling.None

        Dim num As Integer = 0

        'mientras haya que leer
        While reader.Read()
            Select Case reader.NodeType
                'leer elementos
                Case XmlNodeType.Element
                    num += 1
                    Me.WriteRich("<" & reader.Name & ">", num)
                Case XmlNodeType.Text      'leer texto
                    Me.WriteRich(reader.Value, (num + 1))

                Case XmlNodeType.CDATA     'seccion CDATA
                    Me.WriteRich("<![CDATA[" & reader.Value & "]]>")

                Case XmlNodeType.ProcessingInstruction    'instruccion de procesamiento
                    Me.WriteRich("<?" & reader.Name & reader.Value & "?>")

                Case XmlNodeType.Comment
                    Me.WriteRich("<!--reader.Value-->")

                Case XmlNodeType.XmlDeclaration
                    Me.WriteRich("<?xml version='1.0'?>")
                Case XmlNodeType.Document
                Case XmlNodeType.DocumentType
                    Me.WriteRich("<!DOCTYPE " & reader.Name & " [" & reader.Value & "]")
                Case XmlNodeType.EntityReference
                    Me.WriteRich(reader.Name)
                Case XmlNodeType.EndElement
                    Me.WriteRich("</" & reader.Name & ">", num)
                    num -= 1

            End Select
        End While
    End Sub

    Private Sub abirXMLStream()
        Dim myStream As Stream
        Dim myOpenFile As New OpenFileDialog

        'dando las caracteris al archivo que abriremos
        With myOpenFile
            'directorio inicial
            .InitialDirectory = "C:\"
            'archivos que se pueden abrir
            .Filter = "Archivos Xml (*.xml)|*.xml|All Files (*.*)|*.*"
            'indixe del archivo de lectura por defecto
            .FilterIndex = 1
            'restaurar el directorio de la apliación al cerrar el cuadro de dialogo
            .RestoreDirectory = True
        End With

        'si se encontro el archivo
        If myOpenFile.ShowDialog() = DialogResult.OK Then
            'abrir el archivo
            myStream = myOpenFile.OpenFile()
            'si no es nulo
            If Not (myStream Is Nothing) Then
                'que desamos hacer con el archivo
                Me.LeerXml(myStream)
                myStream.Close()
            End If
        End If

    End Sub

    'Private Sub metodoXmlDocument()
    '    Try
    '        Dim m_xmld As XmlDocument
    '        Dim m_nodelist As XmlNodeList
    '        Dim m_node As XmlNode

    '        'Creamos el "Document"
    '        m_xmld = New XmlDocument()

    '        'Cargamos el archivo
    '        m_xmld.Load(lblRuta.Text)

    '        'Obtenemos la lista de los nodos "name"
    '        m_nodelist = m_xmld.SelectNodes("/cfdi/Emisor")

    '        'Iniciamos el ciclo de lectura
    '        For Each m_node In m_nodelist
    '            'Obtenemos el atributo del codigo
    '            Dim mCodigo = m_node.Attributes.GetNamedItem("Nombre").Value

    '            'Obtenemos el Elemento nombre
    '            Dim mNombre = m_node.ChildNodes.Item(0).InnerText

    '            'Obtenemos el Elemento apellido
    '            Dim mApellido = m_node.ChildNodes.Item(1).InnerText

    '            'Escribimos el resultado en la consola, 
    '            'pero tambien podriamos utilizarlos en
    '            'donde deseemos
    '            Console.Write("Codigo usuario: " & mCodigo _
    '              & " Nombre: " & mNombre _
    '              & " Apellido: " & mApellido)
    '            Console.Write(vbCrLf)

    '        Next
    '    Catch ex As Exception
    '        'Error trapping
    '        Console.Write(ex.ToString())
    '    End Try
    'End Sub

   
    Private Sub frmReadXML_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        lsvLista.Visible = True
        cargarColumnas()

    End Sub

    Private Sub cargarColumnas()

        lsvLista.Columns.Add("#")

        lsvLista.Columns.Add("VERSION")
        lsvLista.Columns.Add("SERIE")
        lsvLista.Columns.Add("FECHA")
        lsvLista.Columns.Add("MONEDA")
        lsvLista.Columns.Add("SUBTOTAL")
        lsvLista.Columns.Add("DESCUENTO")
        lsvLista.Columns.Add("TOTAL")
        lsvLista.Columns.Add("NOMBRE EMISOR")
        lsvLista.Columns.Add("RFC EMISOR")
        lsvLista.Columns.Add("NOMBRE RECEPTOR")
        lsvLista.Columns.Add("RFC RECPETOR")
        lsvLista.Columns.Add("UUID")
        lsvLista.Columns.Add("FECHA TIMBRADO")
        lsvLista.Columns.Add("TIPO NOMINA")
        lsvLista.Columns.Add("FECHA PAGO")
        lsvLista.Columns.Add("FECHA INICIAL PAGO")
        lsvLista.Columns.Add("FECHA FINAL PAGO")
        lsvLista.Columns.Add("NUMDIAS PAGADOS")
        lsvLista.Columns.Add("TIPO PERCEPCION")
        lsvLista.Columns.Add("CLAVE")
        lsvLista.Columns.Add("CONCEPTO")
        lsvLista.Columns.Add("IMPORTE GRAVADO")
        lsvLista.Columns.Add("IMPORTE EXCENTO")
        lsvLista.Columns.Add("TOTAL SUELDOS")

        lsvLista.AutoResizeColumn(0,ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(1, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(2, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(3, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(4, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(5, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(6, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(7, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(8, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(9, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(10, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(11, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(12, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(13, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(14, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(15, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(16, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(17, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(18, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(19, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(20, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(21, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(22, ColumnHeaderAutoResizeStyle.HeaderSize)
        lsvLista.AutoResizeColumn(23, ColumnHeaderAutoResizeStyle.HeaderSize)



    End Sub


    Private Sub tsbCancelar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsbCancelar.Click
        lsvLista.Items.Clear()
        lsvLista.Columns.Clear()
        lsvLista.Clear()
        lblRuta.Text = ""
        cargarColumnas()

    End Sub

    Private Sub tsAcumulados_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tsAcumulados.Click
        Try
            Dim filaExcel As Integer = 0
            Dim dialogo As New SaveFileDialog()
            'pnlProgreso.Visible = True
            'pnlCatalogo.Enabled = False
            'Application.DoEvents()

            If lsvLista.Items.Count > 0 Then
                Dim ruta As String
                ruta = My.Application.Info.DirectoryPath() & "\Archivos\Reporte de XML.xlsx"
                Dim book As New ClosedXML.Excel.XLWorkbook(ruta)
                Dim libro As New ClosedXML.Excel.XLWorkbook

                book.Worksheet(1).CopyTo(libro, "Reporte")
                Dim hoja As IXLWorksheet = libro.Worksheets(0)
                filaExcel = 2


                For Each dato As ListViewItem In lsvLista.CheckedItems

                    hoja.Cell(filaExcel, 21).Style.NumberFormat.Format = "@"
                    hoja.Range(filaExcel, 14, filaExcel, 25).Style.NumberFormat.Format = "@"

                    hoja.Cell(filaExcel, 1).Value = dato.SubItems(0).Text()
                    hoja.Cell(filaExcel, 2).Value = dato.SubItems(1).Text()
                    hoja.Cell(filaExcel, 3).Value = dato.SubItems(2).Text()
                    hoja.Cell(filaExcel, 4).Value = dato.SubItems(3).Text()
                    hoja.Cell(filaExcel, 5).Value = dato.SubItems(4).Text()
                    hoja.Cell(filaExcel, 6).Value = dato.SubItems(5).Text()
                    hoja.Cell(filaExcel, 7).Value = dato.SubItems(6).Text()
                    hoja.Cell(filaExcel, 8).Value = dato.SubItems(7).Text()
                    hoja.Cell(filaExcel, 9).Value = dato.SubItems(8).Text()
                    hoja.Cell(filaExcel, 10).Value = dato.SubItems(9).Text()
                    hoja.Cell(filaExcel, 11).Value = dato.SubItems(10).Text()
                    hoja.Cell(filaExcel, 12).Value = dato.SubItems(11).Text()
                    hoja.Cell(filaExcel, 13).Value = dato.SubItems(12).Text()
                    hoja.Cell(filaExcel, 14).Value = dato.SubItems(13).Text()
                    hoja.Cell(filaExcel, 15).Value = dato.SubItems(14).Text()
                    hoja.Cell(filaExcel, 16).Value = dato.SubItems(15).Text()
                    hoja.Cell(filaExcel, 17).Value = dato.SubItems(16).Text()
                    hoja.Cell(filaExcel, 18).Value = dato.SubItems(17).Text()
                    hoja.Cell(filaExcel, 19).Value = dato.SubItems(18).Text()
                    hoja.Cell(filaExcel, 20).Value = dato.SubItems(19).Text()
                    hoja.Cell(filaExcel, 21).Value = dato.SubItems(20).Text()
                    hoja.Cell(filaExcel, 22).Value = dato.SubItems(21).Text()
                    hoja.Cell(filaExcel, 23).Value = dato.SubItems(22).Text()
                    hoja.Cell(filaExcel, 24).Value = dato.SubItems(23).Text()
                    hoja.Cell(filaExcel, 25).Value = dato.SubItems(24).Text()


                    filaExcel = filaExcel + 1

                Next



                dialogo.FileName = "REPORTE XML " & Date.Now.Day & "-" & Date.Now.Month & "-" & Date.Now.Year
                dialogo.Filter = "Archivos de Excel (*.xlsx)|*.xlsx"

                If dialogo.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
                    libro.SaveAs(dialogo.FileName)
                    libro = Nothing
                    MessageBox.Show("Archivo generado correctamente", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)

                End If

            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message.ToString, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub chkAll_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAll.CheckedChanged
        For Each item As ListViewItem In lsvLista.Items
            item.Checked = chkAll.Checked
        Next
        chkAll.Text = IIf(chkAll.Checked, "Desmarcar todos", "Marcar todos")
    End Sub
End Class
