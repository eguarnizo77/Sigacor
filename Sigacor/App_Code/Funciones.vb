Imports System.Data
Public Class Funciones
    Public Function states() As DataTable

        QRY = "select * from states"

        Return Data.OpenData(QRY)
    End Function

End Class
