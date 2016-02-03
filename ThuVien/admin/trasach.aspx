<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trasach.aspx.cs" Inherits="admin_trasach" %>


<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
		<div id="container_head">Độc giả trả sách</div>
	  <div id="Container">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
          </asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
          
          <table style="width:500px;margin-left:100px" bgcolor="#E8F2FF">
              <tr>
                  <td colspan="2" bgcolor="#999999">
                      <asp:Label ID="Label34" runat="server" Font-Bold="True" ForeColor="White" 
                          Height="23px" Text="Thông tin sách cần trả"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="Label1" runat="server" Text="Mã sách: "></asp:Label>
                      <asp:TextBox ID="MaSachKiemTraTextbox" runat="server" Width="320px"></asp:TextBox>
                      <asp:Button ID="KiemTraButton" runat="server" onclick="KiemTraButton_Click" 
                          Text="Kiểm tra" />
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="ThongbaoSachLabel" runat="server" Font-Size="12pt" 
                          ForeColor="Red" Style="text-align:center" Width="490px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label2" runat="server" Text="Độc giả: " Font-Bold="True" 
                          Height="25px"></asp:Label>
                      <asp:Label ID="DocGiaLabel" runat="server" Height="25px" 
                          Width="250px" Font-Size="14pt" ForeColor="Blue"></asp:Label>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label3" runat="server" Font-Bold="True" Height="25px" 
                          Text="Mã độc giả:"></asp:Label>
                      <asp:Label ID="MaDocGiaLabel" runat="server" Height="25px" 
                          Width="100px"></asp:Label>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="Label6" runat="server" Font-Bold="True" Height="25px" 
                          Text="Mượn sách: "></asp:Label>
                      <asp:Label ID="TenSachLabel" runat="server" Height="25px" 
                          Width="400px" Font-Size="14pt" ForeColor="Blue"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label7" runat="server" Font-Bold="True" Height="25px" 
                          Text="Mã sách: "></asp:Label>
                      <asp:Label ID="MaSachLabel" runat="server" Height="25px" 
                          Width="350px"></asp:Label>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label8" runat="server" Font-Bold="True" Height="25px" 
                          Text="Ngày mượn: "></asp:Label>
                      <asp:Label ID="NgayMuonLabel" runat="server" Height="25px" 
                          Width="100px"></asp:Label>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label9" runat="server" Font-Bold="True" Height="25px" 
                          Text="Ngày hết hạn:"></asp:Label>
                      <asp:Label ID="NgayHetHanLabel" runat="server" Height="25px" 
                          Width="100px"></asp:Label>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label23" runat="server" Font-Bold="True" Height="25px" 
                          Text="Gia hạn: "></asp:Label>
                      <asp:Label ID="GiaHanLabel" runat="server" Height="25px" 
                          Width="100px"></asp:Label>
                  </td>
                  <td>
                      &nbsp;</td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="Label14" runat="server" Font-Bold="True" Height="25px" 
                          Text="Trong phiếu mượn: "></asp:Label>
                      <asp:Label ID="MaPhieuMuonLabel" runat="server" Height="25px" 
                          Width="350px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="Label24" runat="server" Font-Bold="True" Height="25px" 
                          Text="Lập bởi nhân viên: "></asp:Label>
                      <asp:Label ID="TenNhanVienLabel" runat="server" Height="25px" 
                          Width="350px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="Label25" runat="server" Font-Bold="True" Height="25px" 
                          Text="Mã nhân viên: "></asp:Label>
                      <asp:Label ID="MaNhanVienLabel" runat="server" Height="25px" 
                          Width="350px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="ThongbaoLapPhieuPhatLabel" runat="server" Font-Size="12pt" 
                          ForeColor="Red" Style="text-align:center" Width="490px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Button ID="TraSachButton" runat="server" Text="Trả sách" Width="80px" 
                          Style="margin-left:280px" onclick="TraSachButton_Click" />
                  </td>
              </tr>
          </table>
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
