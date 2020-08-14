Public Class TimbreFiscalDigital
    Public UUID As String
    Public Version As String
    Public FechaTimbrado As String

    Sub New()
        UUID = ""
        Version = ""
        FechaTimbrado = ""
    End Sub

    Sub New(
            ByVal UUID As String,
            ByVal Version As String,
            ByVal FechaTimbrado As String)

        UUID = UUID
        Version = Version
        FechaTimbrado = FechaTimbrado
    End Sub

End Class
