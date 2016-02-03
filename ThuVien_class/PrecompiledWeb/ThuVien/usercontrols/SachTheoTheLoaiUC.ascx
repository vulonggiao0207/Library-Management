<%@ control language="C#" autoeventwireup="true" inherits="usercontrols_SachTheoTheLoai, App_Web_y4pweddo" %>
<asp:ListView ID="TheLoaiSachListView" runat="server" EnableModelValidation="True">
        <LayoutTemplate>
        <ul>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
        </ul>
        </LayoutTemplate>
        <ItemTemplate>
        <li>
        <p>
            <asp:HyperLink ID="CategoryList" runat="server" NavigateUrl='<%#"phanloaisach.aspx?ptid="+ Eval("MaPhanLoai").ToString() %>'>
            <asp:Label ID="LinkButton2" runat="server" Text='<%# Eval("TenPhanLoai") %>' />
            </asp:HyperLink>
        </p>
        </li>
        </ItemTemplate>
</asp:ListView>