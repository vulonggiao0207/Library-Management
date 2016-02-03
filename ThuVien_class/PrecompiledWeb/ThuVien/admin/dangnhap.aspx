<%@ page language="C#" autoeventwireup="true" inherits="admin_dangnhap, App_Web_umczga5z" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Thư viện Huflit</title>
	<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
	<link rel="stylesheet" type="text/css" href="../css/style.css" />
	<script src="../scripts/jquery.min.js" type="text/javascript"></script> 
	<script src="../scripts/jquery.js" type="text/javascript"></script> 	
	<script src="../scripts/script.js" type="text/javascript"></script> 	
</head>
<body>
<form id="mainform" runat="server">
<div id="Wrapper">
	<div id="Header">
		<div id="Banner">
		<div id="name">Thư Viện Huflit</div>
		<div id="name2">Đại Học Ngọai Ngữ - Tin Học Thành Phố Hồ Chí Minh</div>
		</div>
		<div id="Navigator">	
	
		</div>
	</div>
	<div id="Content">	
		
		<div id="container_head" style="margin-right:120px">Đăng nhập	</div>
	  <div id="Container" style="margin-right:121px">	
	       
          <table style="width:300px; margin-left:200px">
              <tr>
                  <td>
                      <asp:Label ID="Label1" runat="server" Text="Tài khỏan:"></asp:Label>
                  </td>
                  <td>
                      <asp:TextBox ID="TaiKhoanTextBox" runat="server"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label2" runat="server" Text="Mật khẩu:"></asp:Label>
                  </td>
                  <td>
                      <asp:TextBox ID="MatKhauTextBox" runat="server" TextMode="Password"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td>
                      <asp:Button ID="DangNhapButton" runat="server" Text="Đăng nhập" 
                          onclick="DangNhapButton_Click" />
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="ThongBaoLabel" runat="server" ForeColor="Red" 
                          Text="Mời nhập tài khỏan và mật khẩu" Style="margin-left:50px"></asp:Label>
                  </td>
              </tr>
          </table>
	       
       </div>
		<div id="container_bottom" style="margin-right:120px"></div>
	</div>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>
