<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SachDocNhieuUC.ascx.cs" Inherits="usercontrols_SachDocNhieuUC" %>
<asp:ListView ID="SachListView" runat="server" EnableModelValidation="True">
        <LayoutTemplate>
       <%-- <ul class="sach">--%>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
       <%-- </ul>--%>
        </LayoutTemplate>
        <ItemTemplate>
        <li class="sach">
            <asp:HyperLink ID="CategoryList" runat="server" NavigateUrl='<%#"../sach.aspx?sachid="+ Eval("MaDauSach").ToString() %>'>
            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("HinhAnh") %>' /></br>
            <asp:Label ID="LinkButton2" runat="server" Text='<%# Eval("TenSach") %>' /> 
            </asp:HyperLink>       
        </li>
        </ItemTemplate>
</asp:ListView>