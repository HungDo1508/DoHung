<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="BookAdd.aspx.cs" Inherits="Stanford_BookStore_Webform.Admin.BookAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
     <div style="text-align:center;">
        <h2>Thêm mới thông tin sách</h2>
        <table style="width:100%;">
            <tr>
                <td style="width:15%;">
                    <asp:Label ID="Label1" runat="server" Text="Tên sách:"></asp:Label>
                </td>
                <td style="width:85%;">
                    <asp:TextBox ID="txtTenSach" runat="server" Width="90%"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn cần phải nhập tên sách" Text="*" ForeColor="Red" ControlToValidate="txtTenSach"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Mô tả:
                </td>
                <td>
                    <asp:TextBox ID="txtMoTa" runat="server" TextMode="MultiLine" Rows="5" Width="90%"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>Ảnh sách:</td>
                <td>
                    <asp:Image ID="imgAnhDaiDien" runat="server" Width="150" Height="150" />
                    <br />
                    <asp:FileUpload ID="fUpload" runat="server" />
                    <asp:HiddenField ID="hImage" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    Giá sách:
                </td>
                <td>
                    <asp:TextBox ID="txtGiaSach" runat="server"></asp:TextBox>
                     &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn cần phải nhập giá sách" Text="*" ForeColor="Red" ControlToValidate="txtGiaSach"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Tác giả:
                </td>
                <td>
                    <asp:TextBox ID="txtTacGia" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Bạn cần phải nhập tác giả" Text="*" ForeColor="Red" ControlToValidate="txtTacGia"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Chủ đề:
                </td>
                <td>
                    <asp:DropDownList ID="ddlChuDe" runat="server"></asp:DropDownList>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Bạn cần phải chọn chủ đề sách" Text="*" ForeColor="Red" ControlToValidate="ddlChuDe"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:LinkButton ID="lbtnCapNhat" runat="server" OnClick="lbtnCapNhat_Click">Cập nhật</asp:LinkButton>
                    &nbsp;
                    <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/BookList.aspx">Trở về</asp:HyperLink>

                </td>
            </tr>
            <tr>
                <td></td>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ForeColor="Red" />
                </td>
            </tr>
        </table>
    </div>
</asp:Content>
