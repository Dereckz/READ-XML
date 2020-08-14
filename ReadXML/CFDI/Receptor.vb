Public Class Receptor
    Public RFCR As String
    Public NombreR As String
    Public UsoCFDI As String
    Sub New()
        RFCR = ""
        NombreR = ""
        UsoCFDI = ""
    End Sub

    Sub New(ByVal RFCR As String, ByVal NombreR As String, ByVal RegimenFiscalE As String)
        RFCR = RFCR
        NombreR = NombreR
        UsoCFDI = UsoCFDI
    End Sub

   


    'Propiedades
    'Public Property RFCR As String
    '    Get
    '        Return RFCR
    '    End Get
    '    Set(ByVal value As String)
    '        RFCR = value
    '    End Set
    'End Property

    'Public Property NombreR As String
    '    Get
    '        Return NombreR
    '    End Get
    '    Set(ByVal value As String)
    '        NombreR = value
    '    End Set
    'End Property

    'Public Property UsoCFDI As String
    '    Get
    '        Return UsoCFDI
    '    End Get
    '    Set(ByVal value As String)
    '        NombreR = value
    '    End Set
    'End Property
End Class
