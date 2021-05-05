Imports System.Data
Public Class clParametrizacion

#Region "Pac"

    Public Function insertPac(ByVal name As String, ByVal slogan As String, ByVal initial_year As String,
                              ByVal final_year As String, ByVal number_years As String, ByVal state As String) As Integer

        QRY = "insert into pac(name, slogan, initial_year, final_year, number_years, state) values (" &
              "'" & name & "', '" & slogan & "', " & initial_year & ", " & final_year & ", " &
              "" & number_years & ", '" & state & "') "

        Return Data.Execute(QRY)
    End Function

    Public Function updatePac(ByVal name As String, ByVal slogan As String, ByVal initial_year As String,
                              ByVal final_year As String, ByVal number_years As String, ByVal state As String,
                              ByVal id As String) As Integer

        QRY = "update pac set name = '" & name & "', slogan = '" & slogan & "', initial_year = " & initial_year & ", 
               final_year = " & final_year & ", number_years = " & number_years & ", state = '" & state & "'
               where id = " & id & ""

        Return Data.Execute(QRY)
    End Function

    Public Function updatePac(ByVal id As String) As Integer

        QRY = "update pac set state = 'I' where id = " & id & ""

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

    Public Function selectPac() As DataTable

        QRY = "select id, name, slogan, initial_year, final_year, number_years, state from pac where state = 'A' 
               order by id"

        Return Data.OpenData(QRY)
    End Function

    Public Function selectPac(ByVal id As String) As DataRow

        QRY = "select id, name, slogan, initial_year, final_year, number_years, state from pac where id = " & id

        Return Data.OpenRow(QRY)
    End Function

#End Region

#Region "Levels"
    Public Function selectLevels(ByVal pac_id As String, Optional order As String = "") As DataTable

        QRY = "select id, name, pac_id, hierarchy, state from levels where state = 'A' and pac_id = " & pac_id

        If order <> String.Empty Then
            QRY &= " order by " & order
        End If

        Return Data.OpenData(QRY)
    End Function

    Public Function selectLevelsFila(ByVal pac_id As String, ByVal hierarchy As String) As DataRow

        QRY = "select id, name, pac_id, hierarchy, state from levels where pac_id = " & pac_id & " and hierarchy = '" & hierarchy & "'"

        Return Data.OpenRow(QRY)
    End Function

    Public Function insertLevels(ByVal name As String, ByVal pac_id As String, ByVal hierarchy As String, ByVal state As String) As Integer

        QRY = "insert into levels(name, pac_id, hierarchy,  state) values (" &
              "'" & name & "', " & pac_id & ", " & hierarchy & ", '" & state & "') "

        Return Data.Execute(QRY)
    End Function

    Public Function updateLevels(ByVal id As String, name As String, ByVal hierarchy As String, ByVal state As String) As Integer

        QRY = "update levels set name = '" & name & "', hierarchy = '" & hierarchy & "', state = '" & state & "' where id = " & id & ""

        Return Data.Execute(QRY)
    End Function

    Public Function deleteLevels(ByVal id As String, ByVal state As String) As Integer

        QRY = "update levels set  state = '" & state & "' where id = " & id & ""

        Return Data.Execute(QRY)
    End Function

#End Region

#Region "Contents"
    Public Function selectContents(ByVal pac_id As String, ByVal level_id As String, Optional ByVal sublevel As String = "",
                                   Optional ByVal code As String = "") As DataTable

        QRY = "select * from contents where pac_id = " & pac_id & " and level_id = '" & level_id & "' and state = 'A' "

        If sublevel <> String.Empty Then
            QRY &= "and sublevel = '" & sublevel & "' "
        End If

        If code <> String.Empty Then
            QRY &= "and code = '" & code & "' "
        End If

        QRY &= "order by code"

        Return Data.OpenData(QRY)
    End Function

    Public Function selectContents(ByVal pac_id As String, ByVal code As String) As DataTable

        QRY = "select * from contents where pac_id = " & pac_id & " and code = '" & code & "' and state = 'A'"

        Return Data.OpenData(QRY)
    End Function
    Public Function selectContents(ByVal pac_id As String) As DataTable

        QRY = "select * from contents where pac_id = " & pac_id & " and state = 'A' order by code"

        Return Data.OpenData(QRY)
    End Function
    Public Function insertContents(ByVal pac_id As String, ByVal level_id As String, ByVal code As String,
                               ByVal name_level As String, ByVal sublevel As String, ByVal name As String,
                               ByVal weigth As String, ByVal state As String) As Integer

        QRY = "insert into contents (pac_id, level_id, code, name_level, sublevel, name, weigth, state) values ( " &
              "" & pac_id & ", " & level_id & ", '" & code & "', '" & name_level & "', '" & sublevel & "', " &
              "'" & name & "', " & weigth & ",  '" & state & "') "

        Return Data.Execute(QRY)
    End Function

    Public Function updateContents(ByVal id As String, code As String, ByVal name As String, ByVal weigth As String) As Integer

        QRY = "update contents set code = '" & code & "', name = '" & name & "', weigth = '" & weigth & "' where id = '" & id & "' "

        Return Data.Execute(QRY)
    End Function
    Public Function deleteContents(ByVal id As String, ByVal state As String) As Integer

        QRY = "update contents set state = '" & state & "' where id = '" & id & "' "

        Return Data.Execute(QRY)
    End Function

#End Region
End Class
