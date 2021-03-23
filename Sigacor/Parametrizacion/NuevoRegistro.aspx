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
                                <asp:TextBox ID="txtPesoNiv" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="form-group">
                                <label>Estado</label>
                                <asp:DropDownList ID="cmbEstadoNiv" class="form-control" runat="server" AutoComplete="Off"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="form-group" style="margin-top: 6%">
                                <asp:LinkButton ID="btnAgregar" runat="server" class="btn btn-primary">Agregar</asp:LinkButton>
                            </div>
                        </div>
                        <br />
                        <div class="col-12" style="overflow-x: auto; overflow-y: auto;">
                            <asp:GridView ID="tblNiveles" runat="server" CssClass="table" Width="100%" AutoGenerateColumns="False" style="cursor:pointer;">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="Código" />
                                    <asp:BoundField DataField="name" HeaderText="Nombre" />
                                    <asp:BoundField DataField="weigth" HeaderText="Peso" />
                                    <asp:BoundField DataField="state" HeaderText="Estado" /> 
                                    <asp:TemplateField>
                                        <ItemTemplate>                    
                                            <a href="#" class="btn btn-success btn-circle">
                                                <i class="fas fa-ellipsis-h"></i>
                                            </a>
                                        </ItemTemplate>
                                        <ItemStyle Width="100px"/>
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
                        <div class="col-6">
                            <div class="form-group">
                                <label>Nombre</label>
                                <asp:DropDownList ID="cmbNiveles" class="form-control" runat="server" AutoComplete="Off"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="form-group">
                                <label>Nombre</label>
                                <asp:TextBox ID="txtNombrePlanAcc" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="form-group">
                                <label>Peso</label>
                                <asp:TextBox ID="txtPesoPlanAcc" class="form-control" runat="server" AutoComplete="Off"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="form-group">
                                <label>Estado</label>
                                <asp:DropDownList ID="cmbEstadoPlanAcc" class="form-control" runat="server"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-12 text-center">
                            <asp:LinkButton ID="btnAtrasPlanAcc" runat="server" class="btn btn-primary">Antras</asp:LinkButton>
                            <asp:LinkButton ID="btnSigPlanAcc" runat="server" class="btn btn-primary">Siguiente</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Label ID="lblError" runat="server" Text="lblError" Style="color: red;"></asp:Label>
    </div>
    	
	<script type="text/javascript">


        $(document).ready(function () {
            $("[id*=contenedor2_tblNiveles]").DataTable({
                "paging": false,
                "ordering": false,
                rowReorder: {
                    selector: 'tr'
                },
                columnDefs: [
                    { targets: 0, visible: false }
                ]
            });
        });

    </script>
</asp:Content>

