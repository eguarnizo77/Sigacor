<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Parametrizacion.aspx.vb" Inherits="Sigacor.Parametrizacion" MasterPageFile="~/Principal.Master" Culture="en-US" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contenedor1" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="contenedor2" runat="server">

    <div class="container">
        <div class="row">
            <div class="col-12 text-right">
                <a class="btn btn-success btn-icon-split" href="NuevoRegistro.aspx">
                    <span class="icon text-white-50">
                        <i class="fas fa-plus"></i>
                    </span>
                    <span class="text">Nueva Parametrización</span>
                </a>
                <div class="btn-group" role="group" aria-label="Basic example">
                    <span class="icon text-white-50" style="display: inline-block; padding: .375rem 0.75rem; background-color: #c9a811;">
                        <i class="fas fa-filter"></i>
                    </span>
                    <asp:DropDownList ID="cmbFiltrar" class="btn btn-amarillo dropdown-toggle" runat="server">
                        <asp:ListItem>Filtrar por </asp:ListItem>
                    </asp:DropDownList>
                </div>  
            </div>
        </div>
    </div>

</asp:Content>
