<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Parametrizacion.aspx.vb" Inherits="Sigacor.Parametrizacion" MasterPageFile="~/Principal.Master" Culture="en-US" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenedor1" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contenedor2" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-4"></div>
            <div class="col-8">
                <asp:LinkButton ID="btnNuevo" class="btn btn-success btn-icon-split" runat="server">
                    <span class="icon text-white-50">
                        <i class="fas fa-plus"></i>
                    </span>
                    <span class="text">Nueva Parametrización</span>
                </asp:LinkButton>
                <div class="input-group mb-3">
                  
                </div>
                <div class="btn-group" role="group" aria-label="Basic example">
                    <span class="icon text-white-50" style="background-color:#D4B62A;">
                        <i class="fas fa-plus"></i>
                    </span>
                <asp:DropDownList ID="cmbFiltrar" class="btn btn-danger dropdown-toggle" runat="server" style="background-color:#D4B62A;"> 
                    <asp:ListItem>Filtrar por </asp:ListItem>
                </asp:DropDownList>
                    </div>
                
                
            </div>
        </div>
    </div>

</asp:Content>
