<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trasachtaicho.aspx.cs" Inherits="admin_trasach" %>

<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

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
   </div>
	</div>
   
	<div id="Content">
     <div id="Sidebar">	
        <div class="box">
            <uc1:PhanQuyenUC ID="PhanQuyenUC1" runat="server" />       
		</div>               
    </div>
		<div id="container_head">MƯỢN SÁCH ĐỌC TẠI THƯ VIỆN</div>
	  <div id="Container">
          
             <asp:ScriptManager ID="ScriptManager1" runat="server">
          </asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
          
          Nhân viên:
          <asp:Label ID="TenNVlabel" runat="server"></asp:Label>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <br />
          <br />
              Mã sách :
          <asp:TextBox ID="MaSachTextBox" runat="server" Height="22px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
          <asp:Button ID="TraSachButton" runat="server" Height="21px" onclick="Button1_Click" 
              Text="Trả Sách" Width="80px" />

 
 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="ThongBaoLabel" runat="server"></asp:Label>
      
              <br />
              <br />
              <br />
              <br />
      
          <br />
          <br />
          <br />
          
 
         
          <%--popup thong bao--%>
          <%------%>
        <asp:Panel ID="ThongBaoPanel" runat="server" Width="400px" Style="display: none;">            
                <div class="popup_head">THÔNG BÁO</div>
                <div class="popup_content">
                    <center>ĐỌC GIẢ CHƯA ĐĂNG KÝ VÀO HỆ THỐNG</center> 
                 
                    <br> 
                 
                    </br>
                    <center><asp:Button ID="ThoatButton" runat="server" Text="Thoát" Width="50px" Style="margin-right:10px"  /></center>
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
         <%------ --%>
       
         </ContentTemplate>
          </asp:UpdatePanel>

      </div>
		<div id="container_bottom"></div>
	</div>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>

