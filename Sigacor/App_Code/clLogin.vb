Imports System.Data
Public Class clLogin
    Public Function selectUsuario(ByVal USUARIO_BD As String, Optional ByVal consulta As String = "") As DataRow

        If consulta = String.Empty Then
            QRY = "select usuario_bd, clave, rol_id, address, movil, encriptado, description, " &
                  "concat(nombr_empld, ' ', aplld_empld) as nombreEmp from RHMHOJVI " &
                  "join profiles on usuario_bd = user_id join roles on name = rol_id " &
                  "where usuario_bd = '" & USUARIO_BD & "' "
        ElseIf consulta = "1" Then
            QRY = "select  usuario_bd from    RHMHOJVI where   usuario_bd = '" & USUARIO_BD & "'" &
                  "and codg_carg  not like  '99%'"
        ElseIf consulta = "2" Then
            QRY = "select  usuario_bd from    RHMHOJVI where   usuario_bd = '" & USUARIO_BD & "'" &
                  "and codg_carg  not like  '99%' and fech_retr >= '" & Now.ToString("yyyy-MM-dd") & "'"
        End If

        Return Data.OpenRow(QRY)
    End Function

    Public Function selectMenu() As DataTable

        QRY = "select * from menu where state = 'A'"

        Return Data.OpenData(QRY)
    End Function

End Class
