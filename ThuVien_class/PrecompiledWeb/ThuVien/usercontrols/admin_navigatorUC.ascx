<%@ control language="C#" autoeventwireup="true" inherits="usercontrols_admin_navigatorUC, App_Web_y4pweddo" %>
 <ul>
		<li><a href="trangchu.aspx"  style="background:#fff;color:#0066CC">Trang chủ</a></li>
		<li><a href="doipass.aspx">Đổi mật khẩu</a></li>	
        <li><asp:LinkButton ID="DangXuatButton" runat="server" 
                onclick="DangXuatButton_Click">Đăng xuất</asp:LinkButton></li>	
</ul>