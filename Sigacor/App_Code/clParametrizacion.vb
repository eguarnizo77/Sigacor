Imports System.Data
Public Class clParametrizacion

    Public Function insertPac(ByVal name As String, ByVal slogan As String, ByVal initial_year As String,
                               ByVal final_year As String, ByVal number_years As String, ByVal state As String) As Integer

        QRY = "insert into pac(name, slogan, initial_year, final_year, number_years, state) values (" &
              "'" & name & "', '" & slogan & "', " & initial_year & ", " & final_year & ", " &
              "" & number_years & ", '" & state & "') "

        Return Data.Execute(QRY)
    End Function

    Public Function consecutivoPac() As Integer

        Dim row As DataRow

        QRY = "select id from pac order by id desc"

        row = Data.OpenRow(QRY)
        If row IsNot Nothing Then
            consecutivoPac = row("id")
        End If

    End Function

    Public Function insertLevels(ByVal name As String, ByVal pac_id As String, ByVal hierarchy As String,
                                 ByVal weigth As String, ByVal state As String) As Integer

        QRY = "insert into levels(name, pac_id, hierarchy, weigth, state) values (" &
              "'" & name & "', " & pac_id & ", " & hierarchy & ", " & weigth & ", " &
              "'" & state & "') "

        Return Data.Execute(QRY)
    End Function

    Public Function insertTracing(ByVal code As String, ByVal array As String) As Integer
        Dim row As DataRow
        QRY = "insert into tracing(code, array) values (" &
              "'" & code & "', " & array & ") "

        Data.Execute(QRY)

        QRY = "select id from tracing order by id desc"

        row = Data.OpenRow(QRY)
        If QRY IsNot Nothing Then
            insertTracing = row("id")
        Else
            insertTracing = 0
        End If

    End Function

    Public Function deleteJerarquia() As Integer

        QRY = "delete from jerarquia"

        Return Data.Execute(QRY)
    End Function
    Public Function selectJerarquia(ByVal level As String, Optional ByVal sublevel As String = "", Optional ByVal code As String = "") As DataTable

        QRY = "select * from jerarquia where level = '" & level & "' "

        If sublevel <> String.Empty Then
            QRY &= "and sublevel = '" & sublevel & "' "
        End If

        If code <> String.Empty Then
            QRY &= "and code = '" & code & "' "
        End If

        If sublevel = String.Empty And sublevel = String.Empty And code = String.Empty Then
        Else
            QRY &= "order by code desc"
        End If


        Return Data.OpenData(QRY)
    End Function
    Public Function selectJerarquia() As DataTable

        QRY = "select * from jerarquia"

        Return Data.OpenData(QRY)
    End Function
    Public Function insertJerarquia(ByVal level As String, ByVal sublevel As String, ByVal name As String,
                                    ByVal value As String, ByVal namelevel As String, ByVal code As String) As Integer

        QRY = "insert into jerarquia (level, sublevel, name, value, namelevel, code) values ( " &
              "'" & level & "', '" & sublevel & "', '" & name & "', " & value & ", " &
              "'" & namelevel & "', '" & code & "' )"

        Return Data.Execute(QRY)
    End Function

End Class
