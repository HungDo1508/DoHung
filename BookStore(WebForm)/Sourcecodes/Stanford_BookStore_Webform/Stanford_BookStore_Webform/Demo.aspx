<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Demo.aspx.cs" Inherits="Stanford_BookStore_Webform.Demo" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h1>Hello</h1>
        </div>
        <div style="width: 100%;">
            <div style="width: 350px; margin-left: auto; margin-right: auto;">
                <fieldset class="login_group_field">
                    <legend>Đăng nhập hệ thống</legend>
                    <table>
                        <tr>
                            <td>Tên đăng nhập
                            </td>
                            <td>
                                <asp:TextBox ID="txtTenDangNhap" runat="server"></asp:TextBox>
                                &nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="Bạn cần nhập tên đăng nhập" ForeColor="Red" Text="*" ControlToValidate="txtTenDangNhap"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>Mật khẩu
                            </td>
                            <td>
                                <asp:TextBox ID="txtMatKhau" runat="server" TextMode="Password"></asp:TextBox>
                                &nbsp;
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="Bạn cần nhập mật khẩu" ForeColor="Red" Text="*" ControlToValidate="txtMatKhau"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:LinkButton ID="lbtnDangNhap" runat="server" CssClass="stanfButton"> <img src="Content/images/right_16.png" />Đăng nhập</asp:LinkButton>
                                &nbsp;
                                <a class="stanfButton" href="TrangChu.aspx">
                                    <img src="images/delete.gif" />Hủy bỏ</a>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td>
                                <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" runat="server" ForeColor="Red" />
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>
