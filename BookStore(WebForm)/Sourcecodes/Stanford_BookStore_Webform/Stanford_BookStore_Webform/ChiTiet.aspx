<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore.Master" AutoEventWireup="true" CodeBehind="ChiTiet.aspx.cs" Inherits="Stanford_BookStore_Webform.ChiTiet" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1>
        <asp:Literal ID="lblTenSach" runat="server"></asp:Literal><span>(by
            <asp:Literal ID="lblTacGia" runat="server"></asp:Literal>)</span></h1>
    <p style="text-align: right; color: red;">
        <asp:Literal ID="lblGiaSach" runat="server"></asp:Literal>
    </p>
    <p>
        <asp:Literal ID="lblMoTa" runat="server"></asp:Literal>
    </p>

    <div class="image_panel">
        <asp:Image ID="imgAnhSach" runat="server" Width="400" />
    </div>

    <div class="cleaner_with_height">&nbsp;</div>
</asp:Content>
