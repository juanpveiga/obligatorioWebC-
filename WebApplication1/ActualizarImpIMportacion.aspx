<%@ Page Title="" Language="C#" MasterPageFile="~/paginaMaestra.Master" AutoEventWireup="true" CodeBehind="ActualizarImpIMportacion.aspx.cs" Inherits="WebApplication1.ActualizarImpIMportacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:Label ID="lblTitulo" runat="server" Text="ACTUALIZAR IMPUESTO IMPORTACION (RECRAGO)"></asp:Label><br />
    <asp:Label ID="Label1" runat="server" Text="Ingrese Nuevo Valor de Ipuesto :"></asp:Label>
    <asp:TextBox ID="txtNuevoValor" runat="server"></asp:TextBox>
    <asp:Button ID="btnActualizarIMp" runat="server" Text="Actualizar" OnClick="btnActualizarIMp_Click"/>
    <asp:Label ID="lblMensaje" runat="server" Text=""></asp:Label>
    
</asp:Content>
