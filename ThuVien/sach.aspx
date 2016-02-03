<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sach.aspx.cs" Inherits="sach" %>


<%@ Register src="usercontrols/DangNhapUC.ascx" tagname="DangNhapUC" tagprefix="uc1" %>

<%@ Register src="usercontrols/SachTheoTheLoaiUC.ascx" tagname="SachTheoTheLoaiUC" tagprefix="uc2" %>

<%@ Register src="usercontrols/SachDocNhieuUC.ascx" tagname="SachDocNhieuUC" tagprefix="uc3" %>

<%@ Register src="usercontrols/TimSachUC.ascx" tagname="TimSachUC" tagprefix="uc4" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Thư viện Huflit</title>
	<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
	<link rel="stylesheet" type="text/css" href="css/style.css" />

	<style>
	#Container p{font-size:14px}
	    .style1
        {
            width: 100%;
        }
	</style>
</head>
<body>
    <form id="form2" runat="server">
<div id="Wrapper">
	<div id="Header">
		<div id="Banner">
		<div id="name">Thư Viện Huflit</div>
		<div id="name2">Đại Học Ngọai Ngữ - Tin Học Thành Phố Hồ Chí Minh</div>
		</div>
		<div id="Navigator">
		<ul>
		<li><a href="trangchu.aspx">Trang chủ</a></li>
		<li><a href="gioithieu.aspx">Giới thiệu</a></li>
		<li><a href="tracuu.aspx">Tra cứu sách</a></li>
		</ul>
		<div class="login">
		    <uc1:DangNhapUC ID="DangNhapUC1" runat="server" />
		</div>
		</div>
	</div>
	<div id="Content">
	  <div id="Sidebar">		
		<uc4:TimSachUC ID="TimSachUC1" runat="server" />
			<div class="box">
				<div class="box_head">Sách theo thể lọai</div>
				<div class="box_content">
				
				    <uc2:SachTheoTheLoaiUC ID="SachTheoTheLoaiUC1" runat="server" />
				
				</div>
				<div class="box_bottom"></div>
			</div>
			<div class="box">
				<div class="box_head">Sách đọc nhiều nhất</div>			
				<div id="Sach">	
					<ul class="sachbox">					   
					<marquee direction="down" scrollamount="5" onmouseover="this.stop();" onmouseout="this.start();" height="460px">						
		             <uc3:SachDocNhieuUC ID="SachDocNhieuUC1" runat="server" /></marquee>	
					</ul>
				</div>				
				<div class="box_bottom"></div>
			</div>	
			<div class="box">
				<div class="box_head">Thống kê</div>
				<div class="box_content"style="height:40px;padding:5px 10px">
				Số ngừơi truy cập: 219 <br/>
				Số lượng sách: 10548<br/>
				</div>
				<div class="box_bottom"></div>
			</div>
	  </div>
		<div id="container_head">Chi tiết sách	</div>
	  <div id="Container">
	    
	      <table class="style1">
              <tr>
                  <td rowspan="9">
                      <asp:Image ID="HinhAnhImage" runat="server" Height="240px" Width="180px" />
                  </td>
                  <td>
                      <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Tên sách: "></asp:Label>
                      <asp:Label ID="TenSachLabel" runat="server" Font-Size="14pt" ForeColor="Blue" 
                          Width="350px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Nhà xuất bản: "></asp:Label>
                      <asp:Label ID="NhaXuatBanLabel" runat="server" Width="350px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Năm xuất bản: "></asp:Label>
                      <asp:Label ID="NamXuatBanLabel" runat="server" Width="350px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Lần xuất bản: "></asp:Label>
                      <asp:Label ID="LanXuatBanLabel" runat="server" Width="350px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Tác giả: "></asp:Label>
                      <br />
                      <asp:ListBox ID="TacGiaListBox" runat="server" Width="400px"></asp:ListBox>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Lọai sách: "></asp:Label>
                      <asp:Label ID="LoaiSachLabel" runat="server" Width="350px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Thể lọai: "></asp:Label>
                      <asp:Label ID="ChuDeLabel" runat="server" Width="350px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="Chủ đề: "></asp:Label>
                      <asp:Label ID="TheLoaiLabel" runat="server" Width="350px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Khu vực: "></asp:Label>
                      <asp:Label ID="KhuVucLabel" runat="server" Width="350px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td>
                      <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Kệ: "></asp:Label>
                      <asp:Label ID="KeLabel" runat="server" Width="350px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td>
                      <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Ngăn: "></asp:Label>
                      <asp:Label ID="NganLabel" runat="server" Width="350px"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      &nbsp;</td>
                  <td>
                      <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Trị giá: "></asp:Label>
                      <asp:Label ID="TriGiaLabel" runat="server" Width="80px"></asp:Label>
                      <asp:Label ID="Label26" runat="server" Text="vnđ"></asp:Label>
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

