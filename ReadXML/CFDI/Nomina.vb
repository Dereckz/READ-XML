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

End Class
