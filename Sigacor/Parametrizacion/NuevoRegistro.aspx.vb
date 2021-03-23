Public Class NuevoRegistro
    Inherits System.Web.UI.Page

    Dim parametrizacion As New clParametrizacion
    Dim fun As New Funciones

#Region "Click"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlPac.Visible = True
            pestaña(1)
            pnlNiveles.Visible = False
            pnlPlanAccion.Visible = False
            lblError.Visible = False
            Dim dt As New DataTable

            dt.Columns.Add("id")
            dt.Columns.Add("name")
            dt.Columns.Add("weigth")
            dt.Columns.Add("state")
            Session("dataNiveles") = dt


            cmbEstadoNiv.Items.Clear()
            cmbEstadoNiv.DataTextField = "description"
            cmbEstadoNiv.DataValueField = "name"
            cmbEstadoNiv.DataSource = fun.states()
            cmbEstadoNiv.DataBind()
            cmbEstadoNiv.Items.Insert(0, New ListItem("---Seleccione---", ""))



        End If
        If tblNiveles.Rows.Count > 0 Then
            tblNiveles.UseAccessibleHeader = True
            tblNiveles.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub

    Private Sub btnPac_Click(sender As Object, e As EventArgs) Handles btnPac.Click
        Try
            btnSigPac_Click(Nothing, Nothing)
            pnlPac.Visible = True
            pestaña(1)
            pnlNiveles.Visible = False
            pnlPlanAccion.Visible = False
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub
    Private Sub btnNiveles_Click(sender As Object, e As EventArgs) Handles btnNiveles.Click
        Try
            btnSigPac_Click(Nothing, Nothing)
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Private Sub btnPlanAccion_Click(sender As Object, e As EventArgs) Handles btnPlanAccion.Click
        Try
            btnSigPac_Click(Nothing, Nothing)
            btnSigNiveles_Click(Nothing, Nothing)
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Private Sub btnSigPac_Click(sender As Object, e As EventArgs) Handles btnSigPac.Click
        Try
            If txtNomPac.Text = String.Empty Then
                alerta("Advertencia", "Ingrese el nombre el pac", "info", "contenedor2_txtNomPac")
                Exit Sub
            End If
            If txtSlogan.Text = String.Empty Then
                alerta("Advertencia", "Ingrese el slogan", "info", "contenedor2_txtSlogan")
                Exit Sub
            End If
            If txtYearInicial.Text = String.Empty Then
                alerta("Advertencia", "Ingrese el año inicial", "info", "contenedor2_txtYearInicial")
                Exit Sub
            End If
            If txtCantYears.Text = String.Empty Then
                alerta("Advertencia", "Ingrese la cantidad de años", "info", "contenedor2_txtCantYears")
                Exit Sub
            End If
            If txtFecControl.Text = String.Empty Then
                alerta("Advertencia", "Ingrese la fecha de control", "info", "contenedor2_txtFecControl")
                Exit Sub
            End If
            pestaña(2)
            pnlPac.Visible = False
            pnlNiveles.Visible = True
            pnlPlanAccion.Visible = False
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub
    Private Sub btnSigNiveles_Click(sender As Object, e As EventArgs) Handles btnSigNiveles.Click
        Try
            'If txtNombreNiv.Text = String.Empty Then
            '    alerta("Advertencia", "Ingrese el nombre del nivel", "info", "contenedor2_txtNombreNiv")
            '    Exit Sub
            'End If
            'If txtPesoNiv.Text = String.Empty Then
            '    alerta("Advertencia", "Ingrese el peso del nivel", "info", "contenedor2_txtPesoNiv")
            '    Exit Sub
            'End If
            If tblNiveles.Rows.Count = 0 Then
                alerta("Advertencia", "Ingrese un nivel", "info", "")
                Exit Sub
            End If

            pestaña(3)
            pnlPac.Visible = False
            pnlNiveles.Visible = False
            pnlPlanAccion.Visible = True
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Private Sub btnAtrasNiveles_Click(sender As Object, e As EventArgs) Handles btnAtrasNiveles.Click
        Try
            btnPac_Click(Nothing, Nothing)
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Private Sub btnAtrasPlanAcc_Click(sender As Object, e As EventArgs) Handles btnAtrasPlanAcc.Click
        Try
            btnSigNiveles_Click(Nothing, Nothing)
            pestaña(2)
            pnlPac.Visible = False
            pnlNiveles.Visible = True
            pnlPlanAccion.Visible = False
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim dt As New DataTable
            dt = Session("dataNiveles")
            Dim row As DataRow = dt.NewRow()

            If txtNombreNiv.Text = String.Empty Then
                alerta("Advertencia", "Ingrese el nombre del nivel", "info", "contenedor2_txtNombreNiv")
                Exit Sub
            End If
            If txtPesoNiv.Text = String.Empty Then
                alerta("Advertencia", "Ingrese el peso del nivel", "info", "contenedor2_txtPesoNiv")
                Exit Sub
            End If
            If cmbEstadoNiv.SelectedIndex = 0 Then
                alerta("Advertencia", "Seleccione el estado del nivel", "info", "contenedor2_cmbEstadoNiv")
                Exit Sub
            End If

            If dt.Rows.Count > 0 Then
                Dim i As Integer = 1
                For Each fila As DataRow In dt.Rows
                    row("id") = i
                    row("name") = row("name")
                    row("weigth") = row("weigth")
                    row("state") = row("state")
                    i = i + 1
                Next
                row("id") = i
                row("name") = txtNombreNiv.Text.Trim
                row("weigth") = txtPesoNiv.Text.Trim
                row("state") = cmbEstadoNiv.SelectedValue
                dt.Rows.Add(row)
            Else
                row("id") = "1"
                row("name") = txtNombreNiv.Text.Trim
                row("weigth") = txtPesoNiv.Text.Trim
                row("state") = cmbEstadoNiv.SelectedValue
                dt.Rows.Add(row)
            End If

            txtNombreNiv.Text = String.Empty
            txtPesoNiv.Text = String.Empty

            tblNiveles.DataSource = dt
            tblNiveles.DataBind()
            tblNiveles.UseAccessibleHeader = True
            tblNiveles.HeaderRow.TableSection = TableRowSection.TableHeader

        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub
#End Region

#Region "Metodos - Funciones"
    Public Sub alerta(ByVal mensaje As String, ByVal subMensaje As String, ByVal tipo As String, Optional foco As String = "")
        Dim Script As String = "<script type='text/javascript'> swal({title:'" + mensaje.Replace("'", " | ") + "', text:'" + subMensaje.Replace("'", " | ") + "' , type:'" + tipo + "', confirmButtonText:'OK'})"
        If foco.Trim <> "" Then
            Script &= ".then((result) => {if (result.value) {document.getElementById('" + foco + "').focus();}});"
        End If
        Script &= " </script>"
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "swal", Script, False)
    End Sub
    Sub pestaña(index As Integer)
        btnPac.Attributes.Add("class", "")
        btnNiveles.Attributes.Add("class", "")
        btnPlanAccion.Attributes.Add("class", "")

        Select Case index
            Case 1
                btnPac.Attributes.Add("class", "nav-link active")
                btnNiveles.Attributes.Add("class", "nav-link")
                btnPlanAccion.Attributes.Add("class", "nav-link")
            Case 2
                btnNiveles.Attributes.Add("class", "nav-link active")
                btnPac.Attributes.Add("class", "nav-link")
                btnPlanAccion.Attributes.Add("class", "nav-link")
            Case 3
                btnPlanAccion.Attributes.Add("class", "nav-link active")
                btnPac.Attributes.Add("class", "nav-link")
                btnNiveles.Attributes.Add("class", "nav-link")
        End Select
    End Sub

    Private Sub tblNiveles_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles tblNiveles.RowDataBound
        If e.Row.RowType = DataControlRowType.Header Then
            e.Row.Cells(3).Visible = False
        End If
    End Sub

#End Region

End Class