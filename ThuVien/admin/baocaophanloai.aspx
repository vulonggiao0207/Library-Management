<%@ Page Language="C#" AutoEventWireup="true" CodeFile="baocaophanloai.aspx.cs" Inherits="admin_thongke" %>


<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server"/>
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
		<div id="container_head">Thống kê theo phân loại sách</div>
	  <div id="Container">
     

          Loại sách:<asp:DropDownList ID="PhanLoaiDropDownList" runat="server" 
              DataSourceID="SqlDataSource1" DataTextField="TenPhanLoai" 
              DataValueField="TenPhanLoai" Height="19px" Width="212px">
              <asp:ListItem Selected="True"></asp:ListItem>
              <asp:ListItem></asp:ListItem>
          </asp:DropDownList>
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
          <asp:Button ID="BaoCaoButton" runat="server" Height="28px" Text="Thống kê" 
              Width="111px" onclick="BaoCaoButton_Click" />
          <br />
          <asp:ScriptManager ID="ScriptManager1" runat="server">
          </asp:ScriptManager>
          &nbsp;
          <asp:GridView ID="DSPhanLoaiGridView" runat="server" 
              AutoGenerateColumns="False" BackColor="White" BorderColor="#3366CC" 
              BorderStyle="None" BorderWidth="1px" CellPadding="4" Width="690px">
              <Columns>
                  <asp:BoundField DataField="tensach" HeaderText="Tên Sách"></asp:BoundField>
                  <asp:BoundField DataField="tennxb" HeaderText="Tên NXB">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:BoundField>
                  <asp:BoundField DataField="namxuatban" HeaderText="Năm xuất bản">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" Wrap="False" />
                  </asp:BoundField>
                  <asp:BoundField DataField="lanxuatban" HeaderText="Lần xuất bản">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:BoundField>
                  <asp:BoundField DataField="soluong" HeaderText="Số lượng">
                  <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                  </asp:BoundField>
              </Columns>
              <FooterStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Center" 
                  VerticalAlign="Middle" />
              <HeaderStyle BackColor="#003399" Font-Bold="True" ForeColor="#CCCCFF" />
              <PagerStyle BackColor="#99CCCC" ForeColor="#003399" HorizontalAlign="Left" />
              <RowStyle BackColor="White" ForeColor="#003399" />
              <SelectedRowStyle BackColor="#009999" Font-Bold="True" ForeColor="#CCFF99" />
              <SortedAscendingCellStyle BackColor="#EDF6F6" />
              <SortedAscendingHeaderStyle BackColor="#0D4AC4" />
              <SortedDescendingCellStyle BackColor="#D6DFDF" />
              <SortedDescendingHeaderStyle BackColor="#002876" />
          </asp:GridView>
          <asp:SqlDataSource ID="SqlDataSource1" runat="server" 
              ConnectionString="<%$ ConnectionStrings:ThuVienConnectionString2 %>" 
              SelectCommand="SELECT [TenPhanLoai] FROM [PhanLoai]"></asp:SqlDataSource>
&nbsp;</div>
		<div id="container_bottom"></div>
	</div>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>

