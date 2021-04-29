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

            btnActPac.Visible = False
            'btnActNiv.Visible = False
            btnSigPlanAcc.Visible = False

            visualizarPac(Session("id_pac"))
            Session("id_pac") = Nothing
            Session("pac") = Nothing

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

#Region "TextChanged"
    Private Sub txtYearInicial_TextChanged(sender As Object, e As EventArgs) Handles txtYearInicial.TextChanged
        calcularYearFinal()
        txtCantYears.Focus()
    End Sub

    Private Sub txtCantYears_TextChanged(sender As Object, e As EventArgs) Handles txtCantYears.TextChanged
        calcularYearFinal()
        txtYearFinal.Focus()
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
                DataT = parametrizacion.selectContents(lblPac.Text.Trim, CInt(cmbNiveles.SelectedValue.Trim) - 1, "", "")
                If DataT.Rows.Count > 0 Then
                    lblSubNivel.Text = "¿A que " & DataT(0)(4) & " pertenece?"
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
            lblCodigo.Text = "Código de " & cmbNiveles.SelectedItem.ToString
            lblNombre.Text = "Nombre de " & cmbNiveles.SelectedItem.ToString
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

#End Region

#Region "RowDataBound"
    Private Sub tblPlanAccion_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles tblPlanAccion.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(0).Visible = False
                e.Row.Cells(3).Visible = False
                e.Row.Cells(5).Visible = False
                e.Row.Cells(7).Visible = False

                Dim linkBtnEditar, linkBtnEliminar, linkBtnConfirmar As New LinkButton
                linkBtnEditar = e.Row.FindControl("lnkEditPlanAcc")
                linkBtnEliminar = e.Row.FindControl("lnkEliPlanAcc")
                linkBtnConfirmar = e.Row.FindControl("lnkConEditPlanAcc")

                linkBtnEditar.CommandArgument = e.Row.Cells(0).Text.Trim
                linkBtnEliminar.CommandArgument = e.Row.Cells(0).Text.Trim

                linkBtnConfirmar.Visible = False

            End If
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(0).Visible = False
                e.Row.Cells(3).Visible = False
                e.Row.Cells(5).Visible = False
                e.Row.Cells(7).Visible = False
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Private Sub tblNiveles_RowDataBound(sender As Object, e As GridViewRowEventArgs) Handles tblNiveles.RowDataBound
        Try
            If e.Row.RowType = DataControlRowType.DataRow Then
                e.Row.Cells(0).Visible = False
                e.Row.Cells(2).Visible = False
                e.Row.Cells(4).Visible = False

                Dim linkBtnEditar, linkBtnEliminar, linkBtnConfirmar As New LinkButton
                linkBtnEditar = e.Row.FindControl("lnkEditNiv")
                linkBtnEliminar = e.Row.FindControl("lnkEliNiv")
                linkBtnConfirmar = e.Row.FindControl("lnkConEdit")

                linkBtnEditar.CommandArgument = e.Row.Cells(0).Text.Trim
                linkBtnEliminar.CommandArgument = e.Row.Cells(0).Text.Trim

                linkBtnConfirmar.Visible = False

            End If
            If e.Row.RowType = DataControlRowType.Header Then
                e.Row.Cells(0).Visible = False
                e.Row.Cells(2).Visible = False
                e.Row.Cells(4).Visible = False
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

#End Region

#Region "RowCommand"
    Private Sub tblNiveles_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles tblNiveles.RowCommand
        Try

            Dim linkBtnConfirmar, linkBtnEditar, linkBtnEliminar As New LinkButton
            Dim codigo, nombre As TextBox

            If e.CommandName = "Editar" Then
                For Each row As GridViewRow In tblNiveles.Rows

                    linkBtnConfirmar = tblNiveles.Rows(row.RowIndex).FindControl("lnkConEdit")
                    linkBtnEditar = tblNiveles.Rows(row.RowIndex).FindControl("lnkEditNiv")
                    linkBtnEliminar = tblNiveles.Rows(row.RowIndex).FindControl("lnkEliNiv")

                    codigo = tblNiveles.Rows(row.RowIndex).FindControl("txtCodigo")
                    nombre = tblNiveles.Rows(row.RowIndex).FindControl("txtNombre")

                    If e.CommandArgument = row.Cells(0).Text Then

                        linkBtnEditar.Visible = False
                        linkBtnConfirmar.Visible = True
                        linkBtnEliminar.Visible = False

                        codigo.Text = row.Cells(1).Text.Trim
                        nombre.Text = row.Cells(3).Text.Trim

                        row.Cells(1).Visible = False
                        row.Cells(2).Visible = True

                        row.Cells(3).Visible = False
                        row.Cells(4).Visible = True


                    Else
                        linkBtnEditar.Visible = False
                        linkBtnEliminar.Visible = False
                    End If
                Next

            ElseIf e.CommandName = "Confirmar" Then

                For Each row As GridViewRow In tblNiveles.Rows
                    codigo = tblNiveles.Rows(row.RowIndex).FindControl("txtCodigo")
                    nombre = tblNiveles.Rows(row.RowIndex).FindControl("txtNombre")

                    If row.Cells(2).Visible = True Then
                        If codigo.Text = String.Empty Then
                            alerta("Advertencia", "Ingrese el código del nivel", "info")
                            Exit Sub
                        End If
                        If nombre.Text = String.Empty Then
                            alerta("Advertencia", "Ingrese el nombre del nivel", "info")
                            Exit Sub
                        End If
                        parametrizacion.updateLevels(row.Cells(0).Text.Trim, nombre.Text.Trim, codigo.Text.Trim, "A")
                    End If
                Next

                cargarNiveles(lblPac.Text.Trim)
                alerta("Se ha actualizado el nivel correctamente", "", "success")

            ElseIf e.CommandName = "Eliminar" Then
                ScriptManager.RegisterStartupScript(Me, GetType(Page), "alertaNivel", "AlertaEliminacionNivel();", True)
                Session("idNivel") = e.CommandArgument
            End If

        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Private Sub tblPlanAccion_RowCommand(sender As Object, e As GridViewCommandEventArgs) Handles tblPlanAccion.RowCommand
        Try

            Dim linkBtnConfirmar, linkBtnEditar, linkBtnEliminar As New LinkButton
            Dim jerarquia, nombre, peso As TextBox

            If e.CommandName = "Editar" Then
                For Each row As GridViewRow In tblPlanAccion.Rows

                    linkBtnConfirmar = tblPlanAccion.Rows(row.RowIndex).FindControl("lnkConEditPlanAcc")
                    linkBtnEditar = tblPlanAccion.Rows(row.RowIndex).FindControl("lnkEditPlanAcc")
                    linkBtnEliminar = tblPlanAccion.Rows(row.RowIndex).FindControl("lnkEliPlanAcc")

                    jerarquia = tblPlanAccion.Rows(row.RowIndex).FindControl("txtJerarquia")
                    nombre = tblPlanAccion.Rows(row.RowIndex).FindControl("txtNombrePlanAcc")
                    peso = tblPlanAccion.Rows(row.RowIndex).FindControl("txtPeso")

                    If e.CommandArgument = row.Cells(0).Text Then

                        linkBtnEditar.Visible = False
                        linkBtnConfirmar.Visible = True
                        linkBtnEliminar.Visible = False

                        jerarquia.Text = row.Cells(2).Text.Trim
                        nombre.Text = row.Cells(4).Text.Trim
                        peso.Text = row.Cells(6).Text.Trim

                        row.Cells(2).Visible = False
                        row.Cells(3).Visible = True

                        row.Cells(4).Visible = False
                        row.Cells(5).Visible = True

                        row.Cells(6).Visible = False
                        row.Cells(7).Visible = True
                    Else
                        linkBtnEditar.Visible = False
                        linkBtnEliminar.Visible = False
                    End If
                Next

            ElseIf e.CommandName = "Confirmar" Then

                For Each row As GridViewRow In tblPlanAccion.Rows
                    jerarquia = tblPlanAccion.Rows(row.RowIndex).FindControl("txtJerarquia")
                    nombre = tblPlanAccion.Rows(row.RowIndex).FindControl("txtNombrePlanAcc")
                    peso = tblPlanAccion.Rows(row.RowIndex).FindControl("txtPeso")

                    If row.Cells(3).Visible = True Then
                        If jerarquia.Text = String.Empty Then
                            alerta("Advertencia", "Ingrese el código de la jerarquia", "info")
                            Exit Sub
                        End If
                        If nombre.Text = String.Empty Then
                            alerta("Advertencia", "Ingrese el nombre del plan de acción cuatrienal", "info")
                            Exit Sub
                        End If
                        If peso.Text = String.Empty Then
                            alerta("Advertencia", "Ingrese el peso del plan de acción cuatrienal", "info")
                            Exit Sub
                        End If
                        parametrizacion.updateContents(row.Cells(0).Text.Trim, jerarquia.Text.Trim, nombre.Text.Trim, peso.Text.Trim)
                        Exit For
                    End If
                Next

                cargarPlanAccion(lblPac.Text.Trim)
                alerta("Se ha actualizado el plan de acción cuatrienal correctamente", "", "success")

            ElseIf e.CommandName = "Eliminar" Then
                ScriptManager.RegisterStartupScript(Me, GetType(Page), "alertaPlanAcc", "AlertaEliminacionPlanAcc();", True)
                Session("idPlanAcc") = e.CommandArgument
            End If

        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

#End Region

#Region "Click"

    Private Sub btnPac_Click(sender As Object, e As EventArgs) Handles btnPac.Click
        Try
            'btnSigPac_Click(Nothing, Nothing)

            'If lblPac.Text = String.Empty Then
            '    alerta("Advertencia", "El pac no esta registrado", "info", "")
            '    btnPac_Click(Nothing, Nothing)
            '    Exit Sub
            'End If

            pnlPac.Visible = True
            pestaña(1)
            pnlNiveles.Visible = False
            pnlPlanAccion.Visible = False
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub
    Private Sub btnNiveles_Click(sender As Object, e As EventArgs) Handles btnNiveles.Click
        Try
            If lblPac.Text = String.Empty Then
                alerta("Advertencia", "El pac no esta registrado", "info", "")
                btnPac_Click(Nothing, Nothing)
                Exit Sub
            End If

            pestaña(2)
            pnlPac.Visible = False
            pnlNiveles.Visible = True
            pnlPlanAccion.Visible = False
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Private Sub btnPlanAccion_Click(sender As Object, e As EventArgs) Handles btnPlanAccion.Click
        Try
            If lblPac.Text = String.Empty Then
                alerta("Advertencia", "El pac no esta registrado", "info", "")
                btnPac_Click(Nothing, Nothing)
                Exit Sub
            End If

            pestaña(3)
            pnlPac.Visible = False
            pnlNiveles.Visible = False
            pnlPlanAccion.Visible = True
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
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

            If parametrizacion.updatePac(txtNomPac.Text.Trim, txtSlogan.Text.Trim, txtYearInicial.Text.Trim,
                                         txtYearFinal.Text.Trim, txtCantYears.Text.Trim,
                                         "A", lblPac.Text.Trim) > 0 Then

                alerta("Se ha actualizado el pac correctamente", "Pac:  " & lblPac.Text.Trim, "success", "")
            Else
                parametrizacion.insertPac(txtNomPac.Text.Trim, txtSlogan.Text.Trim, txtYearInicial.Text.Trim,
                                          txtYearFinal.Text.Trim, txtCantYears.Text.Trim,
                                          "A")
                lblPac.Text = parametrizacion.consecutivoPac
                alerta("Se ha creado el pac correctamente", "Pac:  " & lblPac.Text.Trim, "success", "")
            End If

            pestaña(2)
            pnlPac.Visible = False
            pnlNiveles.Visible = True
            pnlPlanAccion.Visible = False
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Private Sub btnActPac_Click(sender As Object, e As EventArgs) Handles btnActPac.Click
        btnSigPac_Click(Nothing, Nothing)
    End Sub


    Private Sub btnSigNiveles_Click(sender As Object, e As EventArgs) Handles btnSigNiveles.Click
        Try
            'If lblPac.Text = String.Empty Then
            '    alerta("Advertencia", "El pac no esta registrado", "info", "")
            '    btnPac_Click(Nothing, Nothing)
            '    Exit Sub
            'End If

            'If tblNiveles.Rows.Count = 0 Then
            '    alerta("Advertencia", "Ingrese un nivel", "info", "")
            '    Exit Sub
            'End If


            'For Each row As GridViewRow In tblNiveles.Rows
            '    If parametrizacion.updateLevels(row.Cells(0).Text.Trim, row.Cells(2).Text.Trim, row.Cells(1).Text.Trim, "A") > 0 Then

            '        alerta("Se ha actualizado los niveles correctamente", "Pac:  " & lblPac.Text.Trim, "success", "")
            '    Else
            '        parametrizacion.insertLevels(row.Cells(2).Text.Trim, lblPac.Text.Trim, row.Cells(1).Text.Trim, "A")
            '        lblPac.Text = parametrizacion.consecutivoPac
            '        alerta("Se ha creado los niveles correctamente", "Pac:  " & lblPac.Text.Trim, "success", "")
            '    End If

            'Next

            cargarNiveles(lblPac.Text.Trim)

            pestaña(3)
            pnlPac.Visible = False
            pnlNiveles.Visible = False
            pnlPlanAccion.Visible = True



        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub


    'Private Sub btnActNiv_Click(sender As Object, e As EventArgs) Handles btnActNiv.Click
    '    Try
    '        btnSigNiveles_Click(Nothing, Nothing)
    '    Catch ex As Exception
    '        lblError.Text = ex.Message
    '        lblError.Visible = True
    '    End Try
    'End Sub

    Private Sub btnAtrasNiveles_Click(sender As Object, e As EventArgs) Handles btnAtrasNiveles.Click
        Try
            btnPac_Click(Nothing, Nothing)
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Private Sub btnAtrasPlanAcc_Click(sender As Object, e As EventArgs) Handles btnAtrasPlanAcc.Click
        Try
            'btnSigNiveles_Click(Nothing, Nothing)
            pestaña(2)
            pnlPac.Visible = False
            pnlNiveles.Visible = True
            pnlPlanAccion.Visible = False
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub
    Private Sub btnSigPlanAcc_Click(sender As Object, e As EventArgs) Handles btnSigPlanAcc.Click
        Try
            If tblPlanAccion.Rows.Count = 0 Then
                alerta("Advertencia", "Ingrese la parametrización de plan de acción cuatrienal", "info", "")
                Exit Sub
            End If

            limpiarForm()
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try

    End Sub

    Private Sub btnAgregar_Click(sender As Object, e As EventArgs) Handles btnAgregar.Click
        Try
            Dim hierarchy As Integer = 1
            If txtNombreNiv.Text = String.Empty Then
                alerta("Advertencia", "Ingrese el nombre del nivel", "info", "contenedor2_txtNombreNiv")
                Exit Sub
            End If

            DataT = Nothing
            DataT = parametrizacion.selectLevels(lblPac.Text.Trim, "hierarchy desc")
            If DataT.Rows.Count > 0 Then
                hierarchy = CInt(DataT(0)(3)) + 1
            End If

            parametrizacion.insertLevels(txtNombreNiv.Text.Trim, lblPac.Text.Trim, hierarchy, "A")

            cargarNiveles(lblPac.Text.Trim)

            txtNombreNiv.Text = String.Empty

        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Private Sub btnAgregarPlanAcc_Click(sender As Object, e As EventArgs) Handles btnAgregarPlanAcc.Click
        Try

            If cmbNiveles.SelectedIndex = 0 Then
                alerta("Advertencia", "Seleccione un nivel", "info", "contenedor2_cmbNiveles")
                Exit Sub
            End If
            If txtCodigo.Text = String.Empty Then
                alerta("Advertencia", "Ingrese un codigo código", "info", "contenedor2_cmbNiveles")
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

            Dim subNivel, name As String
            If cmbSubNivel.Items.Count > 0 Then
                subNivel = cmbSubNivel.SelectedValue.Trim
                name = cmbSubNivel.SelectedItem.ToString.Trim
            Else
                subNivel = String.Empty
            End If

            Dim code As String

            DataT = parametrizacion.selectContents(lblPac.Text.Trim, cmbNiveles.SelectedValue.Trim - 1, "", subNivel)
            If DataT.Rows.Count > 0 Then
                code = DataT(0)(3) & "." & txtCodigo.Text.Trim
            Else
                code = txtCodigo.Text.Trim
            End If
            DataT = Nothing
            DataT = parametrizacion.selectContents(lblPac.Text.Trim, code)
            If DataT.Rows.Count > 0 Then
                alerta("Advertencia", "Jerarquia " & code & " ya existe", "info")
                Exit Sub
            End If


            parametrizacion.insertContents(lblPac.Text.Trim, cmbNiveles.SelectedValue, code, cmbNiveles.SelectedItem.ToString.Trim, subNivel,
                                           txtNombrePlanAcc.Text.Trim, txtPesoPlanAcc.Text.Trim, "A")

            txtCodigo.Text = String.Empty
            txtNombrePlanAcc.Text = String.Empty
            txtPesoPlanAcc.Text = String.Empty

            cargarPlanAccion(lblPac.Text.Trim)

            alerta("Se ha creado el item correctamente", "", "success")


        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub
#End Region

#Region "Metodos - Funciones"
    Public Sub visualizarPac(ByVal pac As String)
        Try
            If pac <> String.Empty Then
                Fila = Nothing
                Fila = parametrizacion.selectPac(pac)
                If Fila IsNot Nothing Then
                    lblPac.Text = Fila("id")
                    txtNomPac.Text = Fila("name")
                    txtSlogan.Text = Fila("slogan")
                    txtYearInicial.Text = Fila("initial_year")
                    txtCantYears.Text = Fila("number_years")
                    txtYearFinal.Text = Fila("final_year")

                    btnActPac.Visible = True
                    btnSigPac.Visible = False

                    cargarNiveles(lblPac.Text.Trim)
                    cargarPlanAccion(lblPac.Text.Trim)

                End If
            End If

        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub
    Public Sub cargarNiveles(ByVal pac As String)
        Try
            DataT = parametrizacion.selectLevels(pac)
            If DataT.Rows.Count > 0 Then
                tblNiveles.DataSource = DataT
                tblNiveles.DataBind()
                tblNiveles.UseAccessibleHeader = True
                tblNiveles.HeaderRow.TableSection = TableRowSection.TableHeader

                Session("dtNiveles") = DataT
                cmbNiveles.Items.Clear()
                cmbNiveles.DataTextField = "name"
                cmbNiveles.DataValueField = "hierarchy"
                cmbNiveles.DataSource = DataT
                cmbNiveles.DataBind()
                cmbNiveles.Items.Insert(0, New ListItem("---Seleccione---", ""))

                'btnSigNiveles.Visible = False
                'btnActNiv.Visible = True
            Else
                tblNiveles.DataSource = Nothing
                tblNiveles.DataBind()
            End If
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Public Sub cargarPlanAccion(ByVal pac As String)
        Try

            DataT = Nothing
            DataT = parametrizacion.selectContents(pac)
            If DataT.Rows.Count > 0 Then
                tblPlanAccion.DataSource = DataT
                tblPlanAccion.DataBind()
                tblPlanAccion.UseAccessibleHeader = True
                tblPlanAccion.HeaderRow.TableSection = TableRowSection.TableHeader
            End If

        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Private Sub eliminarNivel_Click(sender As Object, e As EventArgs) Handles eliminarNivel.Click
        Try
            parametrizacion.deleteLevels(Session("idNivel"), "I")
            Session("idNivel") = Nothing
            cargarNiveles(lblPac.Text.Trim)

        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Private Sub eliminarPlanAcc_Click(sender As Object, e As EventArgs) Handles eliminarPlanAcc.Click
        Try
            parametrizacion.deleteContents(Session("idPlanAcc"), "I")
            Session("idPlanAcc") = Nothing
            cargarPlanAccion(lblPac.Text.Trim)
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

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
            lblPac.Text = String.Empty
            txtNomPac.Text = String.Empty
            txtSlogan.Text = String.Empty
            txtYearInicial.Text = String.Empty
            txtCantYears.Text = String.Empty
            txtYearFinal.Text = String.Empty
            txtNombreNiv.Text = String.Empty
            'txtPesoNiv.Text = String.Empty
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
            Session("pac") = Nothing
        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

    Public Sub calcularYearFinal()
        Try
            Dim yearInicial As Integer = 0
            Dim cantidadYears As Integer = 0

            If txtYearInicial.Text <> String.Empty Then yearInicial = CInt(txtYearInicial.Text.Trim)
            If txtCantYears.Text <> String.Empty Then cantidadYears = CInt(txtCantYears.Text.Trim)

            txtYearFinal.Text = yearInicial + cantidadYears

        Catch ex As Exception
            lblError.Text = ex.Message
            lblError.Visible = True
        End Try
    End Sub

#End Region

End Class