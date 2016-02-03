<%@ page language="C#" autoeventwireup="true" inherits="admin_capnhatnhanvien, App_Web_hvldu23q" %>

<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Thư viện Huflit</title>
	<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
	<link rel="stylesheet" type="text/css" href="../css/style.css" />
     <style type="text/css">
       .PopupBackground
        {
            background-color:#333333;
            filter:alpha(opacity=70);
            opacity:0.5;    
            overflow:scroll;    
        }   
    </style> 
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
		<div id="container_head"></div>
	  <div id="Container">
          
          <table style="width:690px" bgcolor="#E8F3FF">
              <tr>
                  <td><asp:TextBox ID="TimTextbox" runat="server" 
                          Width="650px" Height="20px"></asp:TextBox>  </td>
                  <td><asp:ImageButton ID="TimButton" runat="server" 
                          Text="Thêm mới" Width="25px" 
                          Height="25px" ImageUrl="~/images/search_tool.jpg" />
                  </td>
              </tr>
              <tr>
                  <td colspan="2">  
                      <asp:GridView ID="NhanVienGridView" runat="server" Width="690px" 
                          AutoGenerateColumns="False">
                          <Columns>
                              <asp:TemplateField HeaderText="Hình ảnh"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Họ Tên - Chức Vụ"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Thông tin liên lạc"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Thông tin cá nhân"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Tài khỏan"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Xóa"></asp:TemplateField>
                              <asp:TemplateField HeaderText="Sửa"></asp:TemplateField>
                          </Columns>
                      </asp:GridView> 
                    
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="Label1" runat="server" Text="Thêm mới nhân viên: " 
                          Style="margin-left:0px;"></asp:Label>
                     <asp:ImageButton runat="server" Text="Thêm mới" Width="25px" Height="25px" 
                          ImageUrl="~/images/insert.jpg" ID="ThemButton"  />
                  </td>
              </tr>
          </table>    
          
      </div>
		<div id="container_bottom"></div>
	</div>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>