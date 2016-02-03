<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DSSachUC.ascx.cs" Inherits="usercontrols_DSSachUC" %>
<asp:ListView ID="SachListView" runat="server" EnableModelValidation="True">
        <LayoutTemplate>
        <ul>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
        </ul>
        </LayoutTemplate>
        <ItemTemplate>
        <li>
            <asp:HyperLink ID="CategoryList" runat="server" NavigateUrl='<%#"../sach.aspx?sachid="+ Eval("MaDauSach").ToString() %>'>
            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("HinhAnh") %>' /></br>
            <asp:Label ID="LinkButton2" runat="server" Text='<%# Eval("TenSach") %>' /> 
            </asp:HyperLink>
            <p style="font-size:14px">Năm xuất bản: <asp:Label ID="Label2" runat="server" Text='<%# Eval("NamXuatBan") %>' /> </p>
            <p style="font-size:14px">Lần xuất bản: <asp:Label ID="Label3" runat="server" Text='<%# Eval("Lanxuatban") %>' /> </p>
       
        </li>
        </ItemTemplate>
</asp:ListView>