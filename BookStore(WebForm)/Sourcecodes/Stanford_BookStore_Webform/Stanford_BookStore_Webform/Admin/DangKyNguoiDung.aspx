<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DangKyNguoiDung.aspx.cs" Inherits="Stanford_BookStore_Webform.Admin.DangKyNguoiDung" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div style="width:100%; text-align:center">
        <h1>Đăng ký người dùng</h1>
    </div>
    <fieldset>
        <legend>Nhập thông tin đăng ký</legend>
        <table>
            <tr>
                <td>
                    Tài khoản:
                </td>
                <td>
                    <asp:TextBox ID="txtTaiKhoan" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn cần nhập tài khoản" ForeColor="Red" Text="*" ControlToValidate="txtTaiKhoan"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Mật khẩu:
                </td>
                <td>
                    <asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn cần nhập mật khẩu" ForeColor="Red" Text="*" ControlToValidate="txtMatKhau"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Mật khẩu nhập lại:
                </td>
                <td>
                    <asp:TextBox ID="txtMatKhauNhapLai" runat="server" TextMode="Password"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="Bạn cần nhập mật khẩu nhập lại" ForeColor="Red" Text="*" ControlToValidate="txtMatKhauNhapLai"></asp:RequiredFieldValidator>
                    &nbsp;<asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Mật khẩu nhập lại không chính xác" ControlToValidate="txtMatKhauNhapLai" ControlToCompare="txtMatKhau" ForeColor="Red">*</asp:CompareValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Họ tên:
                </td>
                <td>
                    <asp:TextBox ID="txtHoTen" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="Bạn cần nhập họ tên" ForeColor="Red" Text="*" ControlToValidate="txtHoTen"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Điện thoại:
                </td>
                <td>
                    <asp:TextBox ID="txtDienThoai" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:CustomValidator ID="CustomValidator1" runat="server" ErrorMessage="Bạn cần phải nhập số điện thoại từ 10 số" Text="*" ForeColor="Red" ControlToValidate="txtDienThoai" OnServerValidate="txtDienThoai_ServerValidation"></asp:CustomValidator>
                </td>
            </tr>
            <tr>
                <td>
                    Email:
                </td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                    &nbsp;
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Bạn cần nhập đúng định dạng email" ControlToValidate="txtEmail" Text="*" ForeColor="Red"></asp:RegularExpressionValidator>
                    
                </td>
            </tr>
            <tr>
                <td>
                    
                </td>
                <td>
                    <asp:LinkButton ID="lbtnDangKy" runat="server">Đăng ký</asp:LinkButton>
                    
                </td>
            </tr>
            <tr>
                <td>
                   
                </td>
                <td>
                    <asp:ValidationSummary ID="ValidationSummary1" runat="server" ShowMessageBox="true" ForeColor="Red" />
                    
                </td>
            </tr>
        </table>
    </fieldset>
</asp:Content>
