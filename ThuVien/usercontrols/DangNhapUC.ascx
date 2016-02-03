<%@ Control Language="C#" AutoEventWireup="true" CodeFile="DangNhapUC.ascx.cs" Inherits="user_controls_DangNhapUC" %>
  
     <asp:Label ID="taikhoanLabel" runat="server" Text="Tải khỏan"></asp:Label>
    <asp:TextBox ID="TaiKhoanTextBox" runat="server" Width="90px"></asp:TextBox>
    <asp:Label ID="MatkhauLabel" runat="server" Text="Mật khẩu: "></asp:Label>
   <asp:TextBox ID="MatKhauTextBox" runat="server" TextMode="Password" Width="90px"></asp:TextBox>
    <asp:Button ID="DangNhapButton" runat="server" Text="Đăng nhập" 
    Width="80px" onclick="DangNhapButton_Click"/>
<asp:Label ID="ThongbaoLabel" runat="server" ForeColor="Red"></asp:Label>


<asp:Panel ID="Panel1" runat="server">
<li><asp:LinkButton ID="SachDanMuonButton" runat="server" 
    onclick="SachDanMuonButton_Click">Sách mượn</asp:LinkButton>  </li>
<li><asp:LinkButton ID="DoimatkhauButton" runat="server" 
    onclick="DoimatkhauButton_Click">Đổi mật khẩu</asp:LinkButton></li>
<li><asp:LinkButton ID="ThoatButton" runat="server" onclick="ThoatButton_Click">Thoát</asp:LinkButton></li>
</asp:Panel>







