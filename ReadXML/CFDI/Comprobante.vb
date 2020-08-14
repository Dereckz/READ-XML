Public Class Comprobante
    Public Version As String
    Public Serie As String
    Public Folio As String
    Public Fecha As String
    Public FormaPago As String
    Public Moneda As String
    Public Subtotal As Double
    Public Descuento As Double
    Public Total As Double
    Public TipoDeComprobante As String
    Public MetodoPago As String

    Sub New()
        Version = ""
        Serie = ""
        Folio = ""
        Fecha = ""
        FormaPago = ""
        Moneda = ""
        Subtotal = 0
        Descuento = 0
        Total = 0
        TipoDeComprobante = ""
        MetodoPago = ""
    End Sub



    Sub New(
            ByVal Version As String,
            ByVal Serie As String,
            ByVal Folio As String,
            ByVal Fecha As String,
            ByVal FormaPago As String,
            ByVal Moneda As String,
            ByVal Subtotal As Double,
            ByVal Descuento As Double,
            ByVal Total As Double,
            ByVal TipoDeComprobante As String,
            ByVal MetodoPago As String)

        Version = Version
        Serie = Serie
        Folio = Folio
        Fecha = Fecha
        FormaPago = FormaPago
        Moneda = Moneda
        Subtotal = Subtotal
        Descuento = Descuento
        Total = Total
        TipoDeComprobante = TipoDeComprobante
        MetodoPago = MetodoPago
    End Sub


End Class
