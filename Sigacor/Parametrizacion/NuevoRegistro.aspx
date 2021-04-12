<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NuevoRegistro.aspx.vb" Inherits="Sigacor.NuevoRegistro" MasterPageFile="~/Principal.Master" Culture="en-US" %>


<asp:Content ID="Content1" ContentPlaceHolderID="contenedor1" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contenedor2" runat="server">
    <script src="../Componentes/vendor/jquery/jquery.min.js"></script>
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
            <!--            <a class="nav-link active" aria-current="page" href="#">PAC</a>-->

        </nav>
        <br />
        <br />
        <asp:Panel ID="pnlPac" runat="server">
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
                                <asp:TextBox TextMode="Number" ID="txtYearInicial" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group">
                                <label>Cantidad de Años</label>
                                <asp:TextBox TextMode="Number" ID="txtCantYears" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group">
                                <label>Fecha de Control</label>
                                <asp:TextBox TextMode="Date" ID="txtFecControl" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-12 text-center">
                            <asp:LinkButton ID="btnSigPac" runat="server" class="btn btn-primary">Siguiente</asp:LinkButton>
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
                            <div class="form-group">
                                <label>Peso</label>
                                <asp:TextBox TextMode="Number" ID="txtPesoNiv" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <%--<div class="col-6">
                            <div class="form-group">
                                <label>Estado</label>
                                <asp:DropDownList ID="cmbEstadoNiv" class="form-control" runat="server" AutoComplete="Off"></asp:DropDownList>
                            </div>
                        </div>--%>
                        <div class="col-6">
                            <div class="form-group" style="margin-top: 3%">
                                <asp:LinkButton ID="btnAgregar" runat="server" class="btn btn-primary">Agregar</asp:LinkButton>
                            </div>
                        </div>
                        <br />
                        <div class="col-12" style="overflow-x: auto; overflow-y: auto;">
                            <asp:GridView ID="tblNiveles" runat="server" CssClass="table" Width="100%" AutoGenerateColumns="False" Style="cursor: pointer;">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="Código" />
                                    <asp:BoundField DataField="name" HeaderText="Nombre" />
                                    <asp:BoundField DataField="weigth" HeaderText="Peso" />
                                    <asp:TemplateField HeaderText="Aciones">
                                        <ItemTemplate>
                                            <a href="#" class="btn btn-success btn-circle" style="height:30px; width:30px">
                                                <i class="fas fa-ellipsis-h"></i>
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </div>

                        <div class="col-12 text-center">
                            <asp:LinkButton ID="btnAtrasNiveles" runat="server" class="btn btn-primary">Antras</asp:LinkButton>
                            <asp:LinkButton ID="btnSigNiveles" runat="server" class="btn btn-primary">Siguiente</asp:LinkButton>
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
                                <label>Niveles</label>
                                <asp:DropDownList ID="cmbNiveles" class="form-control" runat="server" AutoComplete="Off" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                       <div class="col-3" id="pnlSubNivel" runat="server">
                            <div class="form-group">
                                <asp:Label ID="lblSubNivel" runat="server">Trascendencia</asp:Label>           
                                <asp:DropDownList ID="cmbSubNivel" class="form-control mt-2" runat="server" AutoComplete="Off"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-5">
                            <div class="form-group">
                                <label>Nombre</label>
                                <asp:TextBox ID="txtNombrePlanAcc" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-3">
                            <div class="form-group">
                                <label>Peso</label>
                                <asp:TextBox TextMode="Number" ID="txtPesoPlanAcc" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="form-group my-4">
                                <asp:LinkButton ID="btnAgregarPlanAcc" runat="server" class="btn btn-primary">Agregar</asp:LinkButton>
                            </div>
                        </div>
                        <br />
                        <div class="col-12" style="overflow-x: auto; overflow-y: auto;">
                            <asp:GridView ID="tblPlanAccion" runat="server" CssClass="table" Width="100%" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:BoundField DataField="nivel" HeaderText="Nivel" />
                                    <asp:BoundField DataField="hierarchy" HeaderText="Jerarquia" />
                                    <asp:BoundField DataField="name" HeaderText="Nombre" />
                                    <asp:BoundField DataField="weigth" HeaderText="Peso" />
                                </Columns>
                            </asp:GridView>
                        </div>

                        <div class="col-12 text-center">
                            <asp:LinkButton ID="btnAtrasPlanAcc" runat="server" class="btn btn-primary">Antras</asp:LinkButton>
                            <asp:LinkButton ID="btnSigPlanAcc" runat="server" class="btn btn-primary">Siguiente</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:LinkButton ID="btnGrabar" runat="server"></asp:LinkButton>
        <asp:Label ID="lblError" runat="server" Text="lblError" Style="color: red;"></asp:Label>
    </div>

    <script type="text/javascript">


        $(document).ready(function () {
            $("[id*=contenedor2_tblNiveles]").DataTable({
                "paging": false,
                "ordering": false,
                "searching": false,
                "info": false,
                rowReorder: {
                    selector: 'tr'
                },
               
            });
        });


        $(document).ready(function () {
            $("[id*=contenedor2_tblPlanAccion]").DataTable({
                "paging": false,
                "ordering": true,
                "searching": false,
                "info": false
            });
        });

        function AlertaSN() {
            const swalWithBootstrapButtons = swal.mixin({
                confirmButtonClass: 'btn btn-success',
                cancelButtonClass: 'btn btn-danger espacioBtnAlerta',
                buttonsStyling: false,
            })
            swalWithBootstrapButtons({
                title: 'Verificación',
                text: "¿Desea continuar con la creacion de la parametrización?",
                type: 'info',
                showCancelButton: true,
                confirmButtonText: 'Si',
                cancelButtonText: 'No',
                reverseButtons: true
            }).then((result) => {
                if (result.value) {
                    document.getElementById('contenedor2_btnGrabar').click();
                } else if (
                    // Read more about handling dismissals
                    result.dismiss === swal.DismissReason.cancel
                ) {
                    swalWithBootstrapButtons(
                        'Has cancelado la paramretrización',
                        '',
                        'error'
                    )
                }
            })
        };

    </script>

    <style>
        .espacioBtnAlerta{
            margin-right: 40px;
        }
    </style>
</asp:Content>

