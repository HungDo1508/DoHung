<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookList.aspx.cs" Inherits="Stanford_BookStore_Webform.Admin.BookList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:100%; text-align:center;">
        <h2>Quản lý thông tin sách</h2>
    </div>
<div style="width:100%; text-align:right;">
    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/BookAdd.aspx">Thêm mới</asp:HyperLink>
</div>
    <asp:GridView ID="gridSach" runat="server" Width="100%" GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="gridSach_RowCommand">
        <Columns>
            <asp:BoundField DataField="AnhSach" HeaderText="Ảnh"></asp:BoundField>
            <asp:BoundField DataField="Id" HeaderText="Id"></asp:BoundField>
            <asp:BoundField DataField="TenSach" HeaderText="T&#234;n s&#225;ch"></asp:BoundField>
            <asp:BoundField DataField="MoTa" HeaderText="M&#244; tả"></asp:BoundField>
            <asp:BoundField DataField="TacGia" HeaderText="T&#225;c giả"></asp:BoundField>
            <asp:BoundField DataField="NgayTao" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Ng&#224;y tạo"></asp:BoundField>
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="lbtnSua" runat="server" CommandName="Sua" CommandArgument='<%#Bind("Id") %>'>Sửa</asp:LinkButton>
                    &nbsp;
                    <asp:LinkButton ID="lbtnXoa" runat="server" CommandName="Xoa" CommandArgument='<%#Bind("Id") %>' OnClientClick="return confirm('Bạn có chắc chắn muốn xóa thông tin này ?');">Xóa</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
</asp:Content>
