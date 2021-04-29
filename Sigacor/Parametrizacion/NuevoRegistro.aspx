<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NuevoRegistro.aspx.vb" Inherits="Sigacor.NuevoRegistro" MasterPageFile="~/Principal.Master" Culture="en-US" %>


<asp:Content ID="Content1" ContentPlaceHolderID="contenedor1" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contenedor2" runat="server">
    
    <div class="container">
        <nav class="nav nav-pills nav-justified" style="height: 60px; border-radius: 10px; box-shadow: 4px 4px 8px #bdbdbd;">
            <asp:LinkButton ID="btnPac" runat="server" class="nav-link">
                <span class="btn btn-primary bg-white text-black-50 btn-circle" style="margin-right: 10px;">1</span>
                PAC</asp:LinkButton>
            <asp:LinkButton ID="btnNiveles" runat="server" class="nav-link">
                <span class="btn btn-primary bg-white text-black-50 btn-circle" style="margin-right: 10px;">2</span>
                Niveles</asp:LinkButton>
            <asp:LinkButton ID="btnPlanAccion" runat="server" class="nav-link">
                <span class="btn btn-primary bg-white text-black-50 btn-circle" style="margin-right: 10px;">3</span>
                Plan de Acción cuatrienal</asp:LinkButton>

        </nav>
        <br />
        <br />
        <asp:Panel ID="pnlPac" runat="server">
            <asp:Label ID="lblPac" runat="server" CssClass="d-none"></asp:Label>
            <div class="card mb-4 py-3 border-bottom-info" style="box-shadow: 4px 4px 8px #bdbdbd;">
                <div class="card-body">
                    <div class="row">
                        <div class="col-6">
                            <div class="form-group">
                                <label>Nombre del PAC</label>
                                <asp:TextBox ID="txtNomPac" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="form-group">
                                <label>Slogan</label>
                                <asp:TextBox ID="txtSlogan" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group">
                                <label>Año Inicial</label>
                                <asp:TextBox TextMode="Number" ID="txtYearInicial" class="form-control" runat="server" AutoComplete="Off" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group">
                                <label>Cantidad de Años</label>
                                <asp:TextBox TextMode="Number" ID="txtCantYears" class="form-control" runat="server" AutoComplete="Off" AutoPostBack="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group">
                                <label>Año Final</label>
                                <asp:TextBox ID="txtYearFinal" class="form-control" runat="server" AutoComplete="Off" ReadOnly="true"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-12 text-center">
                            <asp:LinkButton ID="btnSigPac" runat="server" class="btn btn-primary">Grabar Pac</asp:LinkButton>
                            <asp:LinkButton ID="btnActPac" runat="server" class="btn btn-primary">Actualizar Pac</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>

        <asp:Panel ID="pnlNiveles" runat="server">
            <div class="card mb-4 py-3 border-bottom-info" style="box-shadow: 4px 4px 8px #bdbdbd;">
                <div class="card-body">
                    <div class="row">
                        <div class="col-6">
                            <div class="form-group">
                                <label>Nombre</label>
                                <asp:TextBox ID="txtNombreNiv" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="form-group mt-4">
                                <asp:LinkButton ID="btnAgregar" runat="server" class="btn btn-primary">Agregar</asp:LinkButton>
                            </div>
                        </div>
                        <br />
                        <div class="col-12" style="overflow-x: auto; overflow-y: auto;">
                            <asp:GridView ID="tblNiveles" runat="server" CssClass="table" Width="100%" AutoGenerateColumns="False" Style="cursor: pointer;">
                                <Columns>
                                    <asp:BoundField DataField="id" />
                                    <asp:BoundField DataField="hierarchy" HeaderText="Código" />
                                    <asp:TemplateField HeaderText="Código">
                                        <ItemTemplate>
                                            <asp:TextBox TextMode="Number" ID="txtCodigo" class="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="name" HeaderText="Nombre" />
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNombre" class="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" HeaderText="Acciones">
                                        <ItemTemplate>
                                            <%--<a href="#" class="btn btn-success btn-circle" style="height:30px; width:30px">
                                                <i class="fas fa-ellipsis-h"></i>
                                            </a>--%>
                                            <asp:LinkButton ID="lnkEditNiv" runat="server" data-placement="top"
                                                data-toggle="tooltip" Height="30px" Width="30px" CommandName="Editar"
                                                Style="display: inline-grid" title="Editar niveles" class="btn btn-success btn-circle">                                            
                                            <i class="fas fa-edit"></i>                                        
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkConEdit" runat="server" data-placement="top"
                                                data-toggle="tooltip" Height="30px" Width="30px" CommandName="Confirmar"
                                                Style="display: inline-grid" title="Confirmar" class="btn btn-success btn-circle">                                            
                                            <i class="fas fa-check"></i>                                   
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkEliNiv" runat="server" data-placement="top"
                                                data-toggle="tooltip" Height="30px" Width="30px" CommandName="Eliminar"
                                                Style="display: inline-grid" title="Eliminar niveles" class="btn btn-success btn-circle">                                            
                                            <i class="fas fa-backspace"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                        <div class="col-12 text-center mt-3">
                            <asp:LinkButton ID="btnAtrasNiveles" runat="server" class="btn btn-primary">Atrás</asp:LinkButton>
                            <asp:LinkButton ID="btnSigNiveles" runat="server" class="btn btn-primary">Siguiente</asp:LinkButton>
                            <%--<asp:LinkButton ID="btnActNiv" runat="server" class="btn btn-primary">Actualizar Niveles</asp:LinkButton>--%>
                        </div>
                    </div>
                </div>
            </div>

        </asp:Panel>

        <asp:Panel ID="pnlPlanAccion" runat="server">
            <div class="card mb-4 py-3 border-bottom-info" style="box-shadow: 4px 4px 8px #bdbdbd;">
                <div class="card-body">
                    <div class="row">
                        <div class="col-4">
                            <div class="form-group">
                                <label>¿Que nivel desea ingresar?</label>
                                <asp:DropDownList ID="cmbNiveles" class="form-control" runat="server" AutoComplete="Off" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                       <div class="col-4" id="pnlSubNivel" runat="server">
                            <div class="form-group">
                                <asp:Label ID="lblSubNivel" runat="server" CssClass="labelAccionCua"></asp:Label>           
                                <asp:DropDownList ID="cmbSubNivel" class="form-control" runat="server" AutoComplete="Off"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group">
                                <asp:Label ID="lblCodigo" runat="server" CssClass="labelAccionCua">Código</asp:Label>  
                                <asp:TextBox TextMode="Number" ID="txtCodigo" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group">
                                <asp:Label ID="lblNombre" runat="server" CssClass="labelAccionCua">Nombre</asp:Label>  
                                <asp:TextBox ID="txtNombrePlanAcc" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-2">
                            <div class="form-group">
                                <label>Peso</label>
                                <asp:TextBox TextMode="Number" ID="txtPesoPlanAcc" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="form-group my-4">
                                <asp:LinkButton ID="btnAgregarPlanAcc" runat="server" class="btn btn-primary">Grabar</asp:LinkButton>
                            </div>
                        </div>
                        <br />
                        <div class="col-12" style="overflow-x: auto; overflow-y: auto;">
                            <asp:GridView ID="tblPlanAccion" runat="server" CssClass="table" Width="100%" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="id" />
                                    <asp:BoundField DataField="level_id" HeaderText="Nivel" />
                                    <asp:BoundField DataField="code" HeaderText="Jerarquia" />
                                    <asp:TemplateField HeaderText="Jerarquia">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtJerarquia" class="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="name" HeaderText="Nombre" />
                                    <asp:TemplateField HeaderText="Nombre">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtNombrePlanAcc" class="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:BoundField DataField="weigth" HeaderText="Peso" />
                                    <asp:TemplateField HeaderText="Peso">
                                        <ItemTemplate>
                                            <asp:TextBox TextMode="Number" ID="txtPeso" class="form-control" runat="server"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="200px" HeaderText="Acciones">
                                        <ItemTemplate>
                                            <asp:LinkButton ID="lnkEditPlanAcc" runat="server" data-placement="top"
                                                data-toggle="tooltip" Height="30px" Width="30px" CommandName="Editar"
                                                Style="display: inline-grid" title="Editar plan de acción" class="btn btn-success btn-circle">                                            
                                            <i class="fas fa-edit"></i>                                        
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkConEditPlanAcc" runat="server" data-placement="top"
                                                data-toggle="tooltip" Height="30px" Width="30px" CommandName="Confirmar"
                                                Style="display: inline-grid" title="Confirmar" class="btn btn-success btn-circle">                                            
                                            <i class="fas fa-check"></i>                                   
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkEliPlanAcc" runat="server" data-placement="top"
                                                data-toggle="tooltip" Height="30px" Width="30px" CommandName="Eliminar"
                                                Style="display: inline-grid" title="Eliminar plan de acción" class="btn btn-success btn-circle">                                            
                                            <i class="fas fa-backspace"></i>
                                            </asp:LinkButton>
                                        </ItemTemplate>
                                        <ItemStyle Width="20%" VerticalAlign="Middle" HorizontalAlign="Center" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                        <div class="col-12 text-center">
                            <asp:LinkButton ID="btnAtrasPlanAcc" runat="server" class="btn btn-primary">Atrás</asp:LinkButton>
                            <asp:LinkButton ID="btnSigPlanAcc" runat="server" class="btn btn-primary">Siguiente</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>        
        <asp:Label ID="lblError" runat="server" Text="lblError" Style="color: red;"></asp:Label>

        <asp:LinkButton ID="eliminarNivel" runat="server"></asp:LinkButton>
        <asp:LinkButton ID="eliminarPlanAcc" runat="server"></asp:LinkButton>
    </div>

    <style>
        .labelAccionCua{
            display: inline-block;
            margin-bottom: .5rem;
        }
         .espacioBtnAlerta{
            margin-right: 40px;
        }
    </style>

    <script type="text/javascript">
        function abrirModal() {
            $(window).on('load', function () {
                $('#mdlVisualizador').modal('show');
            });
        };

        function AlertaEliminacionNivel() {
            const swalWithBootstrapButtons = swal.mixin({
                confirmButtonClass: 'btn btn-success',
                cancelButtonClass: 'btn btn-danger espacioBtnAlerta',
                buttonsStyling: false,
            })
            swalWithBootstrapButtons({
                title: 'Verificación',
                text: "¿Desea eliminar el nivel?",
                type: 'info',
                showCancelButton: true,
                confirmButtonText: 'Si',
                cancelButtonText: 'No',
                reverseButtons: true
            }).then((result) => {
                if (result.value) {
                    document.getElementById('contenedor2_eliminarNivel').click();
                } else if (
                    // Read more about handling dismissals
                    result.dismiss === swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons(
                        'Has cancelado la eliminación del nivel',
                        '',
                        'error'
                    )
                }
            })
        };

        function AlertaEliminacionPlanAcc() {
            const swalWithBootstrapButtons = swal.mixin({
                confirmButtonClass: 'btn btn-success',
                cancelButtonClass: 'btn btn-danger espacioBtnAlerta',
                buttonsStyling: false,
            })
            swalWithBootstrapButtons({
                title: 'Verificación',
                text: "¿Desea eliminar el plan acción cuatrienal?",
                type: 'info',
                showCancelButton: true,
                confirmButtonText: 'Si',
                cancelButtonText: 'No',
                reverseButtons: true
            }).then((result) => {
                if (result.value) {
                    document.getElementById('contenedor2_eliminarPlanAcc').click();
                } else if (
                    // Read more about handling dismissals
                    result.dismiss === swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons(
                        'Has cancelado la eliminación del plan de acción cuatrienal',
                        '',
                        'error'
                    )
                }
            })
        };


        window.onload = function () {
            var pos = window.name || 0;
            window.scrollTo(0, pos);
        }
        window.onunload = function () {
            window.name = self.pageYOffset || (document.documentElement.scrollTop + document.body.scrollTop);
        }
    </script>

</asp:Content>

