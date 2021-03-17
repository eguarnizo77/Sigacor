Public Class NuevoRegistro
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlPac.Visible = True
            pnlNiveles.Visible = False
            lblError.Visible = False
        End If
    End Sub

    Private Sub btnPac_Click(sender As Object, e As EventArgs) Handles btnPac.Click
        Try
            pnlPac.Visible = True
            pnlNiveles.Visible = False
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub
    Private Sub btnNiveles_Click(sender As Object, e As EventArgs) Handles btnNiveles.Click
        Try
            pnlPac.Visible = False
            pnlNiveles.Visible = True
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Private Sub btnPlanAccion_Click(sender As Object, e As EventArgs) Handles btnPlanAccion.Click
        Try

        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

#Region "Region"

#End Region
End Class