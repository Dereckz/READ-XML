Public Class Percepciones
    Public TotalSueldos As Double
    Public TotalGravado As Double
    Public TotalExento As Double
    Public TipoPercepcion As String
    Public Clave As String
    Public Concepto As String
    Public ImporteGravado As Double
    Public ImporteExento As Double

    Sub New()
        TotalSueldos = 0
        TotalGravado = 0
        TotalExento = 0
        TipoPercepcion = ""
        Clave = ""
        Concepto = ""
        ImporteGravado = 0
        ImporteExento = 0
    End Sub

    Sub New(
            ByVal TotalSueldos As Double,
            ByVal TotalGravado As Double,
            ByVal TotalExento As Double,
            ByVal TipoPercepcion As String,
            ByVal Clave As String,
            ByVal Concepto As String,
            ByVal ImporteGravado As Double,
            ByVal ImporteExento As Double)

        TotalSueldos = TotalSueldos
        TotalGravado = TotalGravado
        TotalExento = TotalExento
        TipoPercepcion = TipoPercepcion
        Clave = Clave
        Concepto = Concepto
        ImporteGravado = ImporteGravado
        ImporteExento = ImporteExento



    End Sub




End Class
