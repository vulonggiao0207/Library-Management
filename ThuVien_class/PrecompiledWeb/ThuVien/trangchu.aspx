<%@ page language="C#" autoeventwireup="true" inherits="trangchu, App_Web_edbgxuy3" %>
<%@ Register src="usercontrols/DangNhapUC.ascx" tagname="DangNhapUC" tagprefix="uc1" %>
<%@ Register src="usercontrols/SachTheoTheLoaiUC.ascx" tagname="SachTheoTheLoaiUC" tagprefix="uc3" %>
<%@ Register src="usercontrols/DSSachUC.ascx" tagname="DSSachUC" tagprefix="uc2" %>
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
	    /*$(document).ready(function() {
	    $('#Slide > div:gt(0)').hide();
	    setInterval(function(){
	    $('#Slide div:first-child').fadeOut().next('div').fadeIn().end().appendTo('#Slide');},2000);
	    });*/
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
		<li><a href="trangchu.aspx"  style="background:#fff;color:#0066CC">Trang chủ</a></li>
		<li><a href="gioithieu.aspx">Giới thiệu</a></li>
		<li><a href="tracuu.aspx">Tra cứu sách</a></li>
		<li><a href="tintuc.aspx">Tin tức </a></li>
		<li><a href="sachmuon.aspx">Sách mượn </a></li>
		</ul>
		<div class="login">
     
		    <uc1:DangNhapUC ID="DangNhapUC1" runat="server" />
     
		</div>
		</div>
	</div>
	<div id="Content">
		<div id="Slide">
		  <div> <img src="images/slides/slide1.jpg"/>
		  <div class="thongbao">
		  <h2>thông báo 1</h2> asfas asdfasdfa sdfasefasdfasrsadfa sdfasdfawf sadfawe fasdfasfa asdfasdfa sd
		  </div></div>
			<div> <img src="images/slides/slide2.jpg"/>
			<div class="thongbao">
			<h2>thông báo 2</h2>  asfas asdfasdfa sdfasefasdfasrsadfa sdfasdfawf sadfawe fasdfasfa asdfasdfa sd
			</div></div>
			<div> <img src="images/slides/slide3.jpg"/>
			<div class="thongbao">
			<h2>thông báo 3</h2>asfas asdfasdfa sdfasefasdfasrsadfa sdfasdfawf sadfawe fasdfasfa asdfasdfa sd
			</div></div>
			<div>  <img src="images/slides/slide4.jpg"/>
			<div class="thongbao">
			<h2>thông báo 4</h2>asfas asdfasdfa sdfasefasdfasrsadfa sdfasdfawf sadfawe fasdfasfa asdfasdfa sd
			</div></div>
		</div>
		<div id="Sidebar">		
		<div class="box">
				<div class="box_head">Tìm sách</div>
				<div class="box_content" style="height:25px">
                    <asp:TextBox ID="TimSachTextBox" runat="server" Width="150" Style="margin-left:10px"></asp:TextBox>
                    <asp:Button ID="TimButton" runat="server" Text="Tìm" Width="40px" Style="marin-left:10px" />
				</div>
				<div class="box_bottom"></div>
			</div>
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
					<li class="sach"><a href="#"><img src="images/books/365.jpg"/><br/> 365 xách lược sử thế </a></li>
					<li class="sach"><a href="#"><img src="images/books/abobedesing.jpg"/><br/> Adobe Designer </a></li>
					<li class="sach"><a href="#"><img src="images/books/banCVhoanhao.jpg"/><br/> Bản CV hòan hảo </a></li>	
					<li class="sach"><a href="#"><img src="images/books/hoihoa.jpg"/><br/> Hội họa</a></li>
					<li class="sach"><a href="#"><img src="images/books/headway.jpg"/><br/> Headway Student's book </a></li>
					<li class="sach"><a href="#"><img src="images/books/lehoitaynguyen.jpg"/><br/>Lễ hội Tây Nguyên </a>	</li>
					<li class="sach"><a href="#"><img src="images/books/letlearnEng.jpg"/><br/>Let's learm English </a></li>
					<li class="sach"><a href="#"><img src="images/books/triethoc.jpg"/><br/>Triết học </a></li></marquee>	
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
		<div id="container_head">Sách mới nhất	</div>
	  <div id="Container">	
	        <ul>
				<li><a href="#"><img src="images/books/365.jpg"/><br/> 365 xách lược sử thế </a><p>Nội dung: aaskqwm asliduqwer mdiaopuqwemrtlmscaowiq umsad</p></li>
				<li><a href="#"><img src="images/books/abobedesing.jpg"/><br/> Adobe Designer </a><p>Nội dung: aaskqwm asliduqwer mdiaopuqwemrtlmscaowiq umsad</p></li>
				<li><a href="#"><img src="images/books/banCVhoanhao.jpg"/><br/> Bản CV hòan hảo </a>
					  <p>Nội dung: aaskqwm asliduqwer mdiaopuqwemrtlmscaowiq umsad</p></li>			
				<li><a href="#"><img src="images/books/chienluoc.jpg"/><br/>Chiến quốc sách </a><p>Nội dung: aaskqwm asliduqwer mdiaopuqwemrtlmscaowiq umsad</p></li>
				<li><a href="#"><img src="images/books/hoihoa.jpg"/><br/> Hội họa</a><p>Nội dung: aaskqwm asliduqwer mdiaopuqwemrtlmscaowiq umsad</p></li>
				<li><a href="#"><img src="images/books/headway.jpg"/><br/> 
				Headway Student's book</a>
				  <p>Nội dung: aaskqwm asliduqwer mdiaopuqwemrtlmscaowiq umsad</p></li>
				<li><a href="#"><img src="images/books/lehoitaynguyen.jpg"/><br/>Lễ hội Tây Nguyên </a><p>Nội dung: aaskqwm asliduqwer mdiaopuqwemrtlmscao </p>	</li>
				<li><a href="#"><img src="images/books/letlearnEng.jpg"/><br/>Let's learm English </a><p>Nội dung: aaskqwm asliduqwer mdiaopuqwemrtlmscaowiq umsad</p></li>				
            </ul>	
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
