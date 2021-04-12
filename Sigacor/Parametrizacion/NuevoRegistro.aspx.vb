Public Class NuevoRegistro
    Inherits System.Web.UI.Page

    Dim parametrizacion As New clParametrizacion
    Dim fun As New Funciones

#Region "Load"
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then
            pnlPac.Visible = True
            pestaña(1)
            pnlSubNivel.Visible = False
            pnlNiveles.Visible = False
            pnlPlanAccion.Visible = False
            lblError.Visible = False
        End If

        If tblNiveles.Rows.Count > 0 Then
            tblNiveles.UseAccessibleHeader = True
            tblNiveles.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
        If tblPlanAccion.Rows.Count > 0 Then
            tblPlanAccion.UseAccessibleHeader = True
            tblPlanAccion.HeaderRow.TableSection = TableRowSection.TableHeader
        End If
    End Sub

#End Region

#Region "SelectedIndexChanged"
    Private Sub cmbNiveles_SelectedIndexChsanged(sender As Object, e As EventArgs) Handles cmbNiveles.SelectedIndexChanged
        Try
            If cmbNiveles.SelectedValue = "1" Then
                pnlSubNivel.Visible = False
                cmbSubNivel.Items.Clear()
            Else
                DataT = Nothing
                DataT = parametrizacion.selectJerarquia(CInt(cmbNiveles.SelectedValue.Trim) - 1)
                If DataT.Rows.Count > 0 Then
                    lblSubNivel.Text = DataT(0)(1)
                    pnlSubNivel.Visible = True
                    cmbSubNivel.Items.Clear()
                    cmbSubNivel.DataTextField = "name"
                    cmbSubNivel.DataValueField = "code"
                    cmbSubNivel.DataSource = DataT
                    cmbSubNivel.DataBind()
                    cmbSubNivel.Items.Insert(0, New ListItem("---Seleccione---", ""))
                    cmbSubNivel.Focus()
                Else
                    txtNombrePlanAcc.Focus()
                End If
            End If

        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

#End Region

#Region "Click"

    Private Sub btnGrabar_Click(sender As Object, e As EventArgs) Handles btnGrabar.Click
        Try
            Dim pac As Integer

            If tblPlanAccion.Rows.Count = 0 Then
                alerta("Advertencia", "Ingrese la parametrización de plan de acción cuatrienal", "info", "")
                Exit Sub
            End If

            parametrizacion.insertPac(txtNomPac.Text.Trim, txtSlogan.Text.Trim, txtYearInicial.Text.Trim,
                                      CDate(txtFecControl.Text.Trim).ToString("yyyy"), txtCantYears.Text.Trim,
                                      "A")
            pac = parametrizacion.consecutivoPac
            For Each row As GridViewRow In tblNiveles.Rows
                parametrizacion.insertLevels(row.Cells(1).Text.Trim, pac, row.Cells(0).Text.Trim,
                                             row.Cells(2).Text.Trim, "A")
            Next
            DataT = Nothing
            DataT = parametrizacion.selectJerarquia()
            If DataT.Rows.Count > 0 Then
                For Each row As DataRow In DataT.Rows
                    parametrizacion.insertContents(pac, row("level"), row("code"), row("namelevel"), row("sublevel"),
                                                   row("name"), row("weigth"), "A")
                Next
            End If

            parametrizacion.deleteJerarquia()

            alerta("Se ha creado la parametrización correctamente", "Pac: " & pac, "success", "")
            limpiarForm()

        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
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
            If tblNiveles.Rows.Count = 0 Then
                alerta("Advertencia", "Ingrese un nivel", "info", "")
                Exit Sub
            End If

            pestaña(3)
            pnlPac.Visible = False
            pnlNiveles.Visible = False
            pnlPlanAccion.Visible = True

            parametrizacion.deleteJerarquia()

            cmbNiveles.Items.Clear()
            cmbNiveles.DataTextField = "name"
            cmbNiveles.DataValueField = "id"
            cmbNiveles.DataSource = Session("dtNiveles")
            cmbNiveles.DataBind()
            cmbNiveles.Items.Insert(0, New ListItem("---Seleccione---", ""))

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
    Private Sub btnSigPlanAcc_Click(sender As Object, e As EventArgs) Handles btnSigPlanAcc.Click
        ScriptManager.RegisterStartupScript(Me, GetType(Page), "alertaSN", "AlertaSN();", True)
    End Sub
    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim dt As New DataTable
            dt.Columns.Add("id")
            dt.Columns.Add("name")
            dt.Columns.Add("weigth")
            Dim row As DataRow

            If txtNombreNiv.Text = String.Empty Then
                alerta("Advertencia", "Ingrese el nombre del nivel", "info", "contenedor2_txtNombreNiv")
                Exit Sub
            End If
            If txtPesoNiv.Text = String.Empty Then
                alerta("Advertencia", "Ingrese el peso del nivel", "info", "contenedor2_txtPesoNiv")
                Exit Sub
            End If

            Dim i As Integer = 1
            For Each fila As GridViewRow In tblNiveles.Rows
                row = dt.NewRow()
                row("id") = i
                row("name") = fila.Cells(1).Text.Trim
                row("weigth") = fila.Cells(2).Text.Trim
                i = i + 1
                dt.Rows.Add(row)
            Next
            row = dt.NewRow()
            row("id") = i
            row("name") = txtNombreNiv.Text.Trim
            row("weigth") = txtPesoNiv.Text.Trim
            dt.Rows.Add(row)

            tblPlanAccion.DataSource = Nothing
            tblPlanAccion.DataBind()

            txtNombreNiv.Text = String.Empty
            txtPesoNiv.Text = String.Empty
            Session("dtNiveles") = dt

            tblNiveles.DataSource = dt
            tblNiveles.DataBind()
            tblNiveles.UseAccessibleHeader = True
            tblNiveles.HeaderRow.TableSection = TableRowSection.TableHeader

        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

    Private Sub btnAgregarPlanAcc_Click(sender As Object, e As EventArgs) Handles btnAgregarPlanAcc.Click
        Try
            Dim dt As New DataTable
            Dim dt2 As New DataTable
            dt.Columns.Add("nivel")
            dt.Columns.Add("hierarchy")
            dt.Columns.Add("name")
            dt.Columns.Add("weigth")
            Dim row As DataRow

            If cmbNiveles.SelectedIndex = 0 Then
                alerta("Advertencia", "Seleccione un nivel", "info", "contenedor2_cmbNiveles")
                Exit Sub
            End If
            If txtNombrePlanAcc.Text = String.Empty Then
                alerta("Advertencia", "Ingrese el nombre", "info", "contenedor2_txtNombrePlanAcc")
                Exit Sub
            End If
            If txtPesoPlanAcc.Text = String.Empty Then
                alerta("Advertencia", "Ingrese el peso", "info", "contenedor2_txtPesoPlanAcc")
                Exit Sub
            End If

            Dim i As Integer = 0
            dt2 = Session("dtNiveles")

            i = 0
            For Each fila As GridViewRow In tblPlanAccion.Rows
                row = dt.NewRow()
                row("hierarchy") = fila.Cells(1).Text.Trim
                row("nivel") = fila.Cells(0).Text.Trim
                row("name") = fila.Cells(2).Text.Trim
                row("weigth") = fila.Cells(3).Text.Trim
                dt.Rows.Add(row)
            Next

            Dim subNivel, name As String
            If cmbSubNivel.Items.Count > 0 Then
                subNivel = cmbSubNivel.SelectedValue.Trim
                name = cmbSubNivel.SelectedItem.ToString.Trim
            Else
                subNivel = String.Empty
            End If

            Dim value, code, jerarquia As String
            DataT = Nothing
            DataT = parametrizacion.selectJerarquia(cmbNiveles.SelectedValue.Trim, subNivel)
            If DataT.Rows.Count > 0 Then
                For Each dr As DataRow In DataT.Rows
                    'value = CInt(dr("value")) + 1
                    code = dr("code")
                    code = code.Substring(code.Length - 1)
                    value = CInt(code) + 1
                    If dr("code").Length = 1 Then
                        code = value
                    Else
                        code = Mid(dr("code"), 1, Len(dr("code")) - 1) & value
                    End If
                    value = 0
                    'code = value
                    jerarquia = code
                    Exit For
                Next
            Else
                DataT = parametrizacion.selectJerarquia(cmbNiveles.SelectedValue.Trim - 1, "", subNivel)
                If DataT.Rows.Count > 0 Then
                    value = "1"
                    If cmbSubNivel.SelectedValue = String.Empty Then
                        code = DataT(0)(4)
                    Else
                        code = DataT(0)(4) & "." & value
                    End If
                    jerarquia = code
                Else
                    code = "1"
                    value = "0"
                    jerarquia = "1"
                End If

            End If

            parametrizacion.insertJerarquia(cmbNiveles.SelectedValue, subNivel, txtNombrePlanAcc.Text.Trim,
                                            cmbNiveles.SelectedItem.ToString.Trim, code, txtPesoPlanAcc.Text.Trim)

            row = dt.NewRow()
            row("nivel") = cmbNiveles.SelectedValue
            row("name") = txtNombrePlanAcc.Text.Trim
            row("weigth") = txtPesoPlanAcc.Text.Trim
            row("hierarchy") = jerarquia
            dt.Rows.Add(row)

            txtNombrePlanAcc.Text = String.Empty
            txtPesoPlanAcc.Text = String.Empty

            Session("dtPlanAccional") = dt
            tblPlanAccion.DataSource = dt
            tblPlanAccion.DataBind()
            tblPlanAccion.HeaderRow.TableSection = TableRowSection.TableHeader

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

    Public Sub limpiarForm()
        Try
            txtNomPac.Text = String.Empty
            txtSlogan.Text = String.Empty
            txtYearInicial.Text = String.Empty
            txtCantYears.Text = String.Empty
            txtFecControl.Text = String.Empty
            txtNombreNiv.Text = String.Empty
            txtPesoNiv.Text = String.Empty
            tblNiveles.DataSource = Nothing
            tblNiveles.DataBind()
            cmbNiveles.Items.Clear()
            cmbSubNivel.Items.Clear()
            txtNombrePlanAcc.Text = String.Empty
            txtPesoPlanAcc.Text = String.Empty
            tblPlanAccion.DataSource = Nothing
            tblPlanAccion.DataBind()

            pnlPac.Visible = True
            pestaña(1)
            pnlNiveles.Visible = False
            pnlPlanAccion.Visible = False
            lblError.Text = String.Empty
            lblError.Visible = False


            pnlSubNivel.Visible = False

            Session("niveles") = Nothing
        Catch ex As Exception
            lblError.Text = ex.Message
        End Try
    End Sub

#End Region

End Class