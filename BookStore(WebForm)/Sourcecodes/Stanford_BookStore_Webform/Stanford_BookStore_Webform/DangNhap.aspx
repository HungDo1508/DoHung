<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DangNhap.aspx.cs" Inherits="Stanford_BookStore_Webform.DangNhap" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link type="text/css" rel="stylesheet" href="Content/StyleStanford.css" />
</head>
<body>
    <div style="width: 100%; text-align: center">
        <h1 style="text-transform: uppercase">Đăng nhập hệ thống</h1>
    </div>

    <form id="form1" runat="server">
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
                                <asp:LinkButton ID="lbtnDangNhap" runat="server" CssClass="stanfButton" OnClick="lbtnDangNhap_Click"> <img src="Content/images/right_16.png" />Đăng nhập</asp:LinkButton>
                                &nbsp;
                                <a class="stanfButton" href="TrangChu.aspx">
                                    <img src="Content/images/delete.gif" />Hủy bỏ</a>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td style="color:red;">
                                <asp:ValidationSummary ID="ValidationSummary1" ShowMessageBox="true" runat="server" ForeColor="Red" />
                                <br />
                                
                                <asp:Literal ID="lblThongBao" runat="server"></asp:Literal>
                            </td>
                        </tr>
                    </table>
                </fieldset>
            </div>
        </div>
    </form>
</body>
</html>
