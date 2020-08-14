Public Class Emisor
    'ATRIBUTOS
    Public RFCE As String
    Public NombreE As String
    Public RegimenFiscalE As String

    'CONSTRUCTOR
    Sub New()
        RFCE = ""
        NombreE = ""
        RegimenFiscalE = ""
    End Sub

    Sub New(ByVal RFCE As String, ByVal NombreE As String, ByVal RegimenFiscalE As String)
        RFCE = RFCE
        NombreE = NombreE
        RegimenFiscalE = RegimenFiscalE
    End Sub
    'Propiedades
    'Public Property RFCE As String
    '    Get
    '        Return RFCE

    '    End Get
    '    Set(ByVal value As String)
    '        RFCE = value
    '    End Set
    'End Property

    'Public Property NombreE As String
    '    Get
    '        Return NombreE
    '    End Get
    '    Set(ByVal value As String)
    '        NombreE = value
    '    End Set
    'End Property

    'Public Property RegimenFiscalE As String
    '    Get
    '        Return RegimenFiscalE
    '    End Get
    '    Set(ByVal value As String)
    '        RegimenFiscalE = value
    '    End Set
    'End Property



End Class
