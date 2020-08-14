Public Class OtrosPagos
    Public TipoOtroPago As String
    Public Clave As String
    Public Concepto As String
    Public Importe As Double
    Public SubsidioCausado As Double


    Sub New()
        TipoOtroPago = ""
        Clave = ""
        Concepto = ""
        Importe = 0
        SubsidioCausado = 0
    End Sub
    Sub New(
            ByVal TipoOtroPago As String,
            ByVal Clave As String,
            ByVal Concepto As String,
            ByVal Importe As Double,
            ByVal SubsidioCausado As Double)

        TipoOtroPago = TipoOtroPago
        Clave = Clave
        Concepto = Concepto
        Importe = Importe
        SubsidioCausado = SubsidioCausado


    End Sub


End Class
