Imports System.IO
Imports System.Xml

Public Class frmReadXML
    Dim emisor As New Emisor
    Dim receptor As New Receptor
    Dim comprobante As New Comprobante
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

                    If m_xmlr.Name = "cfdi:Comprobante" Then

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
                    If m_xmlr.Name = "cfdi:Emisor" Then

                        emisor.NombreE = m_xmlr.GetAttribute("Nombre")
                        emisor.RFCE = m_xmlr.GetAttribute("Rfc")
                        emisor.RegimenFiscalE = m_xmlr.GetAttribute("RegimenFiscal")



                        '  m_xmlr.Read()
                    End If

                    'RECEPTOR
                    If m_xmlr.Name = "cfdi:Receptor" Then

                        receptor.NombreR = m_xmlr.GetAttribute("Nombre")
                        receptor.RFCR = m_xmlr.GetAttribute("Rfc")
                        receptor.UsoCFDI = m_xmlr.GetAttribute("UsoCFDI")


                        ' item.SubItems.Add(receptor.UsoCFDI)
                        ' m_xmlr.Read()

                    End If




                    'COMPLEMENTO                  
                    If m_xmlr.Name = "tfd:TimbreFiscalDigital" Then
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

            End If
        Catch ex As Exception

        End Try
    End Sub
End Class
