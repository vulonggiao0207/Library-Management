<%@ Page Language="C#" AutoEventWireup="true" CodeFile="doimatkhau.aspx.cs" Inherits="admin_doipass" %>


<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/SachTheoTheLoaiUC.ascx" tagname="SachTheoTheLoaiUC" tagprefix="uc2" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Thư viện Huflit</title>
	<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
	<link rel="stylesheet" type="text/css" href="../css/style.css" />
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
            <uc3:admin_navigatorUC ID="admin_navigatorUC1" runat="server" />
&nbsp;</div>
	</div>
   
	<div id="Content">
     <div id="Sidebar">	
        <div class="box">
            <uc1:PhanQuyenUC ID="PhanQuyenUC1" runat="server" />       
		</div>               
    </div>
		<div id="container_head">Đổi mật khẩu</div>
	  <div id="Container">
        <div id="Div1">	
		
		
	  <div id="Div3" style="margin-right:121px">	
	       
          <table style="width:300px; margin-left:200px">
              <tr>
                  <td>
                      <asp:Label ID="Label2" runat="server" Text="Mật khẩu cũ:"></asp:Label>
                  </td>
                  <td>
                      <asp:TextBox ID="MatKhauCuTextBox" runat="server" TextMode="Password"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label3" runat="server" Text="Mật khẩu Mới:"></asp:Label>
                  </td>
                  <td>
                      <asp:TextBox ID="MatKhauMoiTextBox" runat="server" TextMode="Password"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label1" runat="server" Text="Xác thực mật khẩu mới:"></asp:Label>
                  </td>
                  <td>
                      <asp:TextBox ID="MatKhauXacThucTextBox" runat="server" TextMode="Password"></asp:TextBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      
                  </td>
                  <td>
                  <asp:Button ID="DoiButton" runat="server" Text="Đổi Mật Khẩu" Width="85px" 
                          onclick="DoiButton_Click" />
                  </td>
                  </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="ThongBaoLabel" runat="server" ForeColor="Red" 
                          Style="margin-left:50px"></asp:Label>
                  </td>
              </tr>
          </table>
	       
       </div>
		<div id="Div4" style="margin-right:120px"></div>
	</div>
      </div>
		<div id="container_bottom"></div>
	</div>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>