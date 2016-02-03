<%@ Page Language="C#" AutoEventWireup="true" CodeFile="baocaosachmat.aspx.cs" Inherits="admin_baocaosachmat" %>

<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<%@ Register assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304" namespace="CrystalDecisions.Web" tagprefix="CR" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
	<title>Thư viện Huflit</title>
	<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
	<link rel="stylesheet" type="text/css" href="../css/style.css" />
    <style type="text/css">
      
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
		<div id="container_head">Báo cáo </div>
	  <div id="Container">
          
          <table>
              <tr>
                  <td width="690">
          
          <asp:Button ID="Baocaoreport" runat="server" onclick="Baocaoreport_Click" 
              Text="Sách mất" />
        
                  </td>
              </tr>
          </table>
        
          <asp:HiddenField ID="XemtruocHid" runat="server" />
          
      </div>       
	<div id="container_bottom">   </div>     
	    <br />
	</div> 
          <asp:Panel ID="BaoCaoPanel" runat="server" Visible="true" Style="margin-top:70px"> 
   
              <CR:CrystalReportViewer ID="ReportMatSach" runat="server" AutoDataBind="true" 
            BestFitPage="False" ToolPanelView="None" />
     </asp:Panel>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>

