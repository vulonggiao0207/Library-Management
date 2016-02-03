<%@ Page Language="C#" AutoEventWireup="true" CodeFile="baocaonhapsach.aspx.cs" Inherits="admin_baocaosachnhap" %>
<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
		<div id="container_head">Báo cáo nhập sách vào thư viện</div>
	  <div id="Container">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
          </asp:ScriptManager>
          Nhập sách từ ngày &nbsp;<asp:TextBox ID="TuNgayTextBox" runat="server"></asp:TextBox>
          <asp:CalendarExtender ID="TuNgayTextBox_CalendarExtender" runat="server" format="yyyy/MM/dd"
              Enabled="True" TargetControlID="TuNgayTextBox">
          </asp:CalendarExtender>
          &nbsp;đến &nbsp;<asp:TextBox ID="DenNgayTextBox" runat="server"></asp:TextBox>
          <asp:CalendarExtender ID="DenNgayTextBox_CalendarExtender" runat="server" format="yyyy/MM/dd"
              Enabled="True" TargetControlID="DenNgayTextBox">
          </asp:CalendarExtender>
          &nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="BaoCaoButton" runat="server" Height="28px" Text="Báo cáo" 
              Width="111px" onclick="BaoCaoButton_Click" />
          <br />
          <asp:Label ID="ThongBaoLabel" runat="server"></asp:Label>
          <br />&nbsp;&nbsp;<br />
          <asp:GridView ID="ThongKeNhapSachGridView" runat="server" 
              AutoGenerateColumns="False" BackColor="White" BorderColor="#CCCCCC" 
              BorderStyle="None" BorderWidth="1px" CellPadding="3" Width="697px">
              <Columns>
                  <asp:BoundField DataField="tensach" HeaderText="Tên sách" />
                  <asp:BoundField DataField="tennxb" HeaderText="Tên NXB">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:BoundField>
                  <asp:BoundField DataField="namxuatban" HeaderText="Năm xuất bản">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:BoundField>
                  <asp:BoundField DataField="soluong" HeaderText="Số lượng">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:BoundField>
                  <asp:BoundField DataField="trigia" HeaderText="Trị giá">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:BoundField>
                  <asp:BoundField DataField="thanhtien" HeaderText="Thành tiền">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:BoundField>
              </Columns>
              <FooterStyle BackColor="White" ForeColor="#000066" />
              <HeaderStyle BackColor="#006699" Font-Bold="True" ForeColor="White" />
              <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
              <RowStyle ForeColor="#000066" />
              <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
              <SortedAscendingCellStyle BackColor="#F1F1F1" />
              <SortedAscendingHeaderStyle BackColor="#007DBB" />
              <SortedDescendingCellStyle BackColor="#CAC9C9" />
              <SortedDescendingHeaderStyle BackColor="#00547E" />
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

