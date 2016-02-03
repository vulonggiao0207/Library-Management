<%@ Page Language="C#" AutoEventWireup="true" CodeFile="thongketienthechan.aspx.cs" Inherits="admin_baocao_thongketienthechan" %>

<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
		<div id="container_head">Thống kê tiền ký quỹ</div>
	  <div id="Container">
          
          <asp:GridView ID="BaoCaoGridView" runat="server" AutoGenerateColumns="False" 
              BackColor="White" BorderColor="#3366CC" BorderStyle="None" BorderWidth="1px" 
              CellPadding="4" Width="699px">
              <Columns>
                  <asp:BoundField DataField="madocgia" HeaderText="Mã độc giả">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:BoundField>
                  <asp:BoundField DataField="tendocgia" HeaderText="Tên độc giả" />
                  <asp:BoundField DataField="tensach" HeaderText="Tên sách" />
                  <asp:BoundField DataField="tienthechan" HeaderText="Tiền ký quỹ">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:BoundField>
              </Columns>
              <FooterStyle BackColor="#99CCCC" ForeColor="#003399" />
              <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
              <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
              <RowStyle BackColor="White" ForeColor="#003399" />
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <SortedAscendingCellStyle BackColor="#EDF6F6" />
              <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
              <SortedDescendingCellStyle BackColor="#D6DFDF" />
              <SortedDescendingHeaderStyle BackColor="#002876" />
          </asp:GridView>
          <br />
        </div>
		<div id="container_bottom"></div>
	</div>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>

