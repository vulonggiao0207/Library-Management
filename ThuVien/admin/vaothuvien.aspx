<%@ Page Language="C#" AutoEventWireup="true" CodeFile="vaothuvien.aspx.cs" Inherits="admin_vaothuvien" %>

<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

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
		<div id="container_head">ĐỌC GIẢ VÀO RA THƯ VIỆN</div>
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
          Mã Đọc Giả :
          <asp:TextBox ID="MaDocGiaTextBox" runat="server" Height="22px"></asp:TextBox>
&nbsp;&nbsp;&nbsp;
          <asp:Button ID="Button1" runat="server" Height="21px" onclick="Button1_Click" 
              Text="Chấp Nhận" Width="80px" />

 
 
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Label ID="ThongBaoLabel" runat="server"></asp:Label>
      
          <br />
          <asp:GridView ID="DsDocGiaGridView" runat="server" CellPadding="4" 
              ForeColor="#333333" GridLines="None" Width="503px" AllowPaging="True" 
                  AutoGenerateColumns="False">
              <AlternatingRowStyle BackColor="White" />
              <Columns>
                  <asp:BoundField DataField="madocgia" HeaderText="Mã độc giả" />
                  <asp:BoundField DataField="tendocgia" HeaderText="Tên độc giả" />
                  <asp:BoundField DataField="thoigian" HeaderText="Thời gian" />
              </Columns>
              <EditRowStyle BackColor="#2461BF" />
              <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
              <RowStyle BackColor="#EFF3FB" />
              <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
              <SortedAscendingCellStyle BackColor="#F5F7FB" />
              <SortedAscendingHeaderStyle BackColor="#6D95E1" />
              <SortedDescendingCellStyle BackColor="#E9EBEF" />
              <SortedDescendingHeaderStyle BackColor="#4870BE" />
          </asp:GridView>
          <br />
          
          <br />
          
 
         
          <%--popup thong bao--%>
          <asp:HiddenField ID="ThongBaoHid" runat="server" />
              <asp:ModalPopupExtender ID="ThongBaoPopup" runat="server"
              PopupControlID="ThongBaoPanel" TargetControlID="ThongBaoHid"
              BackgroundCssClass="PopupBackground"
              DropShadow="true">
              </asp:ModalPopupExtender>           
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
