Public Class NominaR
    Public Curp As String
    Public NumSeguridadSocial As String
    Public FechaInicioRelLaboral As String
    Public Antigüedad As String
    Public TipoContrato As String
    Public Sindicalizado As String
    Public TipoJornada As String
    Public TipoRegimen As String
    Public NumEmpleado As String
    Public Puesto As Int32
    Public RiesgoPuesto As Int16
    Public PeriodicidadPago As String
    Public SalarioDiarioIntegrado As Double
    Public SalarioBaseCotApor As Double
    Public ClaveEntFed As Char

    Sub New()
        Curp = ""
        NumSeguridadSocial = ""
        FechaInicioRelLaboral = ""
        Antigüedad = ""
        TipoContrato = ""
        Sindicalizado = ""
        TipoJornada = ""
        TipoRegimen = ""
        NumEmpleado = ""
        Puesto = 0
        RiesgoPuesto = 0
        PeriodicidadPago = ""
        SalarioDiarioIntegrado = 0
        SalarioBaseCotApor = 0
        ClaveEntFed = ""
    End Sub


    Sub New(
            ByVal Curp As String,
            ByVal NumSeguridadSocial As String,
            ByVal FechaInicioRelLaboral As String,
            ByVal Antigüedad As String,
            ByVal TipoContrato As String,
            ByVal Sindicalizado As String,
            ByVal TipoJornada As String,
            ByVal TipoRegimen As String,
            ByVal NumEmpleado As String,
            ByVal Puesto As Int32,
            ByVal RiesgoPuesto As Int16,
            ByVal PeriodicidadPago As String,
            ByVal SalarioDiarioIntegrado As Double,
            ByVal SalarioBaseCotApor As Double,
            ByVal ClaveEntFed As Char)

        Curp = Curp
        NumSeguridadSocial = NumSeguridadSocial
        FechaInicioRelLaboral = FechaInicioRelLaboral
        Antigüedad = Antigüedad
        TipoContrato = TipoContrato
        Sindicalizado = Sindicalizado
        TipoJornada = TipoJornada
        TipoRegimen = TipoRegimen
        NumEmpleado = NumEmpleado
        Puesto = Puesto
        RiesgoPuesto = RiesgoPuesto
        PeriodicidadPago = PeriodicidadPago
        SalarioDiarioIntegrado = SalarioDiarioIntegrado
        SalarioBaseCotApor = SalarioBaseCotApor
        ClaveEntFed = ClaveEntFed

    End Sub

   

End Class
