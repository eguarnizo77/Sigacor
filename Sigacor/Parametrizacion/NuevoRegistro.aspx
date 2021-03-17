<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="NuevoRegistro.aspx.vb" Inherits="Sigacor.NuevoRegistro" MasterPageFile="~/Principal.Master" Culture="en-US" %>


<asp:Content ID="Content1" ContentPlaceHolderID="contenedor1" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contenedor2" runat="server">

    <div class="container">
        <nav class="nav nav-pills nav-justified" style="height: 60px; border-radius: 10px; box-shadow: 4px 4px 8px #bdbdbd;">
            <asp:LinkButton ID="btnPac" runat="server" class="nav-link active">
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
                                <asp:TextBox ID="txtNomPac" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-6">
                            <div class="form-group">
                                <label>Slogan</label>
                                <asp:TextBox ID="txtSlogan" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group">
                                <label>Año Inicial</label>
                                <asp:TextBox TextMode="Number" ID="TextBox1" class="form-control" runat="server" min="2013" max="2014"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group">
                                <label>Cantidad de Años</label>
                                <asp:TextBox TextMode="Number" ID="TextBox2" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-4">
                            <div class="form-group">
                                <label>Fecha de Control</label>
                                <asp:TextBox TextMode="Date" ID="TextBox3" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-12 text-center">
                            <asp:LinkButton ID="LinkButton3" runat="server" class="btn btn-primary">Siguiente</asp:LinkButton>
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
                                <asp:TextBox ID="TextBox4" class="form-control" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        
                        <div class="col-12 text-center">
                            <asp:LinkButton ID="LinkButton1" runat="server" class="btn btn-primary">Siguiente</asp:LinkButton>
                        </div>
                    </div>
                </div>
            </div>
        </asp:Panel>
        <asp:Label ID="lblError" runat="server" Text="lblError" Style="Color: red;"></asp:Label>
    </div>

</asp:Content>

