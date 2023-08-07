<%@ Page Title="" Language="C#" MasterPageFile="~/BookStore2.Master" AutoEventWireup="true" CodeBehind="TrangChu2.aspx.cs" Inherits="Stanford_BookStore_Webform.TrangChu2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <asp:DataList ID="dlSach" runat="server" OnItemDataBound="dlSach_ItemDataBound" RepeatLayout="Flow">
        <ItemTemplate>
            <div class="templatemo_product_box">
                <h1>
                    <asp:HyperLink ID="HyperLink1" Text='<%#Bind("TenSach") %>' NavigateUrl='<%#Eval("Id", "~/ChiTiet.aspx?ma={0}") %>' runat="server"></asp:HyperLink>
                    <span>(by
                        <asp:Literal ID="Literal1" Text='<%#Bind("TacGia") %>' runat="server"></asp:Literal>)</span></h1>
                <asp:Image ID="Image2" ImageUrl='<%#Eval("AnhSach", "~/Content/Images/{0}") %>' Width="100" Height="150" runat="server" />
                <div class="product_info">
                    <p>
                        <asp:Literal ID="Literal2" Text='<%# Bind("MoTa") %>' runat="server"></asp:Literal>
                    </p>
                    <h3>
                        <asp:Literal ID="Literal3" Text='<%# Bind("GiaSach") %>' runat="server"></asp:Literal></h3>
                    <div class="buy_now_button"><a href="subpage.html">Buy Now</a></div>
                    <div class="detail_button">
                        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl='<%#Eval("Id", "~/ChiTiet.aspx?ma={0}") %>'>Chi tiết</asp:HyperLink>
                    </div>
                </div>
                <div class="cleaner">&nbsp;</div>
            </div>

            <asp:Literal ID="lblCanChinh" runat="server"></asp:Literal>

        </ItemTemplate>
    </asp:DataList>
</asp:Content>
