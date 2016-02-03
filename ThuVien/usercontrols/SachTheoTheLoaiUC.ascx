<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SachTheoTheLoaiUC.ascx.cs" Inherits="usercontrols_SachTheoTheLoai" %>
<asp:ListView ID="TheLoaiSachListView" runat="server" EnableModelValidation="True">
        <LayoutTemplate>
        <ul>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
        </ul>
        </LayoutTemplate>
        <ItemTemplate>
        <li>
        <p>
            <asp:HyperLink ID="CategoryList" runat="server" NavigateUrl='<%#"../tracuu.aspx?ten=&&maphanloai="+ Eval("MaPhanLoai").ToString() %>'>
            <asp:Label ID="LinkButton2" runat="server" Text='<%# Eval("TenPhanLoai") %>' />
            </asp:HyperLink>
        </p>
        </li>
        </ItemTemplate>
</asp:ListView>