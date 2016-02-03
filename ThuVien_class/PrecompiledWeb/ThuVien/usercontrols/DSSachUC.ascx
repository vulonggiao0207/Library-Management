<%@ control language="C#" autoeventwireup="true" inherits="usercontrols_DSSachUC, App_Web_y4pweddo" %>
<asp:ListView ID="TheLoaiSachListView" runat="server" EnableModelValidation="True">
        <LayoutTemplate>
        <ul>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
        </ul>
        </LayoutTemplate>
        <ItemTemplate>
        <li>
        
            <asp:HyperLink ID="CategoryList" runat="server" NavigateUrl='<%#"sach.aspx?sachid="+ Eval("MaSach").ToString() %>'>
            <asp:Image ID="Image1" runat="server" ImageUrl='<%# Eval("HinhAnh") %>' /></br>
            <asp:Label ID="LinkButton2" runat="server" Text='<%# Eval("TenSach") %>' /> 
            </asp:HyperLink>
            <p> <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenNhaXuatBan") %>' /> </p>
            <p> <asp:Label ID="Label2" runat="server" Text='<%# Eval("NamXuatBan") %>' /> </p>
            <p> <asp:Label ID="Label3" runat="server" Text='<%# Eval("TacGia") %>' /> </p>
       
        </li>
        </ItemTemplate>
</asp:ListView>