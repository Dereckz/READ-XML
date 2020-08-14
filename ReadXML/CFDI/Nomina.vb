Public Class Nomina
    Public Version As String
    Public TipoNomina As String
    Public FechaPago As String
    Public FechaFechaInicialPago As String
    Public FechaFinalPago As String
    Public NumDiasPagados As String
    Public TotalPercepciones As Double
    Public TotalDeducciones As Double
    Public TotalOtrosPagos As Double


    Sub New()
        Version = ""
        TipoNomina = ""
        FechaPago = ""
        FechaFechaInicialPago = ""
        FechaFinalPago = ""
        NumDiasPagados = ""
        TotalPercepciones = 0
        TotalDeducciones = 0
        TotalOtrosPagos = ""

    End Sub

    Sub New(
            ByVal Version As String,
            ByVal TipoNomina As String,
            ByVal FechaPago As String,
            ByVal FechaFechaInicialPago As String,
            ByVal FechaFinalPago As String,
            ByVal NumDiasPagados As String,
            ByVal TotalPercepciones As Double,
            ByVal TotalDeducciones As Double,
            ByVal TotalOtrosPagos As Double)

        Version = Version
        TipoNomina = TipoNomina
        FechaPago = FechaPago
        FechaFechaInicialPago = FechaFechaInicialPago
        FechaFinalPago = FechaFinalPago
        NumDiasPagados = NumDiasPagados
        TotalPercepciones = TotalPercepciones
        TotalDeducciones = TotalDeducciones
        TotalOtrosPagos = TotalOtrosPagos

    End Sub


End Class
