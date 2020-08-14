Public Class NominaE
    Public RegistroPatronal As String
    Public Curp As String
    Public NumSeguridadSocial As String
    Public FechaInicioRelLaboral As String
    Public Antigüedad As String
    Public TipoContrato As String
    Public Sindicalizado As Double
    Public TipoJornada As Double

    Sub New()
        RegistroPatronal = ""
        Curp = ""
        NumSeguridadSocial = ""
        FechaInicioRelLaboral = ""
        Antigüedad = ""
        TipoContrato = ""
        Sindicalizado = 0
        TipoJornada = 0
    End Sub

    Sub New(
            ByVal RegistroPatronal As String,
            ByVal Curp As String,
            ByVal NumSeguridadSocial As String,
            ByVal FechaInicioRelLaboral As String,
            ByVal Antigüedad As String,
            ByVal TipoContrato As String,
            ByVal Sindicalizado As Double,
            ByVal TipoJornada As Double)


        RegistroPatronal = RegistroPatronal
        Curp = Curp
        NumSeguridadSocial = NumSeguridadSocial
        FechaInicioRelLaboral = FechaInicioRelLaboral
        Antigüedad = Antigüedad
        TipoContrato = TipoContrato
        Sindicalizado = Sindicalizado
        TipoJornada = TipoJornada

    End Sub

End Class
