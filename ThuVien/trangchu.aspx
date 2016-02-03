<%@ Page Language="C#" AutoEventWireup="true" CodeFile="trangchu.aspx.cs" Inherits="trangchu" %>
<%@ Register src="usercontrols/DangNhapUC.ascx" tagname="DangNhapUC" tagprefix="uc1" %>
<%@ Register src="usercontrols/SachTheoTheLoaiUC.ascx" tagname="SachTheoTheLoaiUC" tagprefix="uc3" %>
<%@ Register src="usercontrols/DSSachUC.ascx" tagname="DSSachUC" tagprefix="uc2" %>
<%@ Register src="usercontrols/SachDocNhieuUC.ascx" tagname="SachDocNhieuUC" tagprefix="uc4" %>
<%@ Register src="usercontrols/TimSachUC.ascx" tagname="TimSachUC" tagprefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
	<title>Thư viện Huflit</title>
	<meta content="text/html; charset=utf-8" http-equiv="Content-Type">
	<link rel="stylesheet" type="text/css" href="css/style.css" />
	<script src="scripts/jquery.min.js" type="text/javascript"></script> 
	<script src="scripts/jquery.js" type="text/javascript"></script> 	
	<script src="scripts/script.js" type="text/javascript"></script> 	
	<script>
	    $(document).ready(function() {
	    $('#Slide > div:gt(0)').hide();
	    setInterval(function(){
	    $('#Slide div:first-child').fadeOut().next('div').fadeIn().end().appendTo('#Slide');},2000);
	    });
	</script>
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
		<ul>
		<li><a href="trangchu.aspx" style="background:#fff;color:#0066CC">Trang chủ</a></li>
		<li><a href="gioithieu.aspx">Giới thiệu</a></li>
		<li><a href="tracuu.aspx">Tra cứu sách</a></li>
		</ul>
		<div class="login">
		    <uc1:DangNhapUC ID="DangNhapUC1" runat="server" />
		</div>
		</div>
	</div>
	<div id="Content">
		<div id="Slide">
		  <div> <img src="images/slides/slide1.jpg"/>
		<%--  <div class="thongbao">
		  <h2>thông báo 1</h2> asfas asdfasdfa sdfasefasdfasrsadfa sdfasdfawf sadfawe fasdfasfa asdfasdfa sd
		  </div>--%></div>
			<div> <img src="images/slides/slide2.jpg"/>
			<%--<div class="thongbao">
			<h2>thông báo 2</h2>  asfas asdfasdfa sdfasefasdfasrsadfa sdfasdfawf sadfawe fasdfasfa asdfasdfa sd
			</div>--%></div>
			<div> <img src="images/slides/slide3.jpg"/>
			<%--<div class="thongbao">
			<h2>thông báo 3</h2>asfas asdfasdfa sdfasefasdfasrsadfa sdfasdfawf sadfawe fasdfasfa asdfasdfa sd
			</div>--%></div>
			<div>  <img src="images/slides/slide4.jpg"/>
		<%--	<div class="thongbao">
			<h2>thông báo 4</h2>asfas asdfasdfa sdfasefasdfasrsadfa sdfasdfawf sadfawe fasdfasfa asdfasdfa sd
			</div>--%></div>
		</div>
		<div id="Sidebar">		
        <uc5:TimSachUC ID="TimSachUC1" runat="server" />
			<div class="box">
				<div class="box_head">Sách theo thể lọai</div>
				<div class="box_content">				
				    <uc3:SachTheoTheLoaiUC ID="SachTheoTheLoaiUC1" runat="server" />				
				</div>
				<div class="box_bottom"></div>
			</div>
			<div class="box">
				<div class="box_head">Sách đọc nhiều nhất</div>			
				<div id="Sach">	
					<ul class="sachbox">	
					<marquee direction="down" scrollamount="5" onmouseover="this.stop();" onmouseout="this.start();" height="460px">
                      <uc4:SachDocNhieuUC ID="SachDocNhieuUC1" runat="server" /></marquee>
                     </ul>
                 </div>				
				<div class="box_bottom"></div>
			</div>	
			<div class="box">
				<div class="box_head">Thống kêống kê</div>
				<div class="box_content"style="height:40px;padding:5px 10px">
				Số ngừơi truy cập: 219 <br/>
				Số lượng sách: 10548<br/>
				</div>
				<div class="box_bottom"></div>
			</div>
		</div>
		<div id="container_head">Sách mới nhất	</div>
	  <div id="Container">	
              <uc2:DSSachUC ID="DSSachUC1" runat="server" />
&nbsp;</div>
		<div id="container_bottom"></div>
	</div>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>
