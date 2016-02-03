<%@ Page Language="C#" AutoEventWireup="true" CodeFile="baocaochuatrasach.aspx.cs" Inherits="admin_baocaochuatrasach" %>

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
		<div id="container_head">Báo cáo độc giả chưa trả sách thư viện</div>
	  <div id="Container">
          
          <asp:GridView ID="BaoCaoGridView" runat="server" AutoGenerateColumns="False" 
              BackColor="White" BorderColor="#DEDFDE" BorderStyle="None" BorderWidth="1px" 
              CellPadding="4" ForeColor="Black" GridLines="Vertical" Width="691px">
              <AlternatingRowStyle BackColor="White" />
              <Columns>
                  <asp:BoundField DataField="madocgia" HeaderText="Mã độc giả">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:BoundField>
                  <asp:BoundField DataField="tendocgia" HeaderText="Tên độc giả" />
                  <asp:BoundField DataField="tensach" HeaderText="Tên sách" />
                  <asp:BoundField DataField="ngaymuon" HeaderText="Ngày mượn">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:BoundField>
                  <asp:BoundField DataField="ngaygiahan" HeaderText="Ngày gia hạn">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:BoundField>
              </Columns>
              <FooterStyle BackColor="#CCCC99" />
              <HeaderStyle BackColor="#6B696B" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" />
              <RowStyle BackColor="#F7F7DE" />
              <SelectedRowStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
              <SortedAscendingCellStyle BackColor="#FBFBF2" />
              <SortedAscendingHeaderStyle BackColor="#848384" />
              <SortedDescendingCellStyle BackColor="#EAEAD3" />
              <SortedDescendingHeaderStyle BackColor="#575357" />
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


