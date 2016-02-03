<%@ Page Language="C#" AutoEventWireup="true" CodeFile="gioithieu.aspx.cs" Inherits="gioithieu" %>

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
		<li><a href="gioithieu.aspx" style="background:#fff;color:#0066CC">Giới thiệu</a></li>
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
		             <uc3:SachDocNhieuUC ID="SachDocNhieuUC1" runat="server" />
                    </marquee>	
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
		<div id="container_head">Giới thiệu	</div>
	  <div id="Container">
	    <p>CHỨC NĂNG - NHIỆM VỤ:</p>
        <p><strong><u><b>Chức năng:</b></u></strong><br />
          Thư viện là đơn  vị   nghiệp vụ phục vụ cho công các đào tạo và nghiên cứu khoa học trong nhà    trường có chức năng tham mưu cho Hiệu trưởng thực hiện công tác quản lý   thư  viện; tổ chức thu thập, lưu trữ, bảo quản và khai thác tốt nguồn   tài liệu phục  vụ cho việc giảng dạy, nghiên cứu học tập của cán bộ,   giảng viên, nhân viên và  sinh viên của trường.</p>
        <p><strong><u><b>Nhiệm vụ:</b></u></strong></p>
        <p>Xây dựng và phát  triển thư viện theo hướng chuẩn hóa và hiện đại.<br />
          Lập kế hoạch và  tổ chức việc bổ sung tài liệu các loại bao gồm mua   mới, tiếp nhận và trao đổi  nhằm phục vụ cho các đối tượng bạn đọc trong   việc đào tạo và nghiên cứu khoa  học. <br />
          Tiếp nhận, quản  lý và khai thác hệ thống luận văn, luận án của CB-GV-NV và sinh viên trong nhà  trường.<br />
          Phối hợp với  Phòng Đào tạo – Nghiên cứu khoa học, Ban tu thư trong   việc tổ chức biên dịch  sách, báo, tài liệu phục vụ cho công tác đào tạo   và Nghiên cứu khoa học.<br />
          Xử lý và sắp xếp  các loại tài liệu, tổ   chức thực hiện công tác lưu trữ và bảo quản các kho tài  liệu theo đúng   tiêu chuẩn qui định.<br />
          Tổ chức phục vụ  tốt, văn minh, lịch sự đáp ứng yêu cầu về tài liệu cho việc học tập, giảng dạy  và nghiên cứu.<br />
          Mở rộng hợp tác  và trao đổi kinh nghiệm với các Thư viện trong và ngoài nước.<br />
          Thống kê và báo  cáo theo yêu cầu của nhà trường.</p>
        <p>&nbsp;</p>
        <p>TỔ CHỨC:</p>
        <p>Phòng đọc<br />
          Kho tài liệu<br />
          Phòng đọc báo,  tạp chí, luận văn tốt nghiệp của sinh viên<br />
          Phòng kỹ thuật.</p>
        <p>&nbsp;</p>
        <p>PHỤC VỤ ĐỘC GIẢ:</p>
        <p><strong><b>Phục vụ bạn  đọc trong việc:</b></strong></p>
          1) Đăng ký bạn đọc
          <br/>
          2) Tra cứu tài liệu
          <br/>
          3) Tìm tài liệu
          <br/>
          4) Cho mượn xem tại chỗ
          <br/>
          5) Cho mượn mang về nhà
          <br/>
          6) Trả lời câu hỏi bạn đọc
          <br/>
          7) Truy tìm thông tin cho bạn đọc
          <br/>
          8) Hướng dẫn bạn đọc truy cập mạng internet
          <br/>
          9) Giới thiệu sách mới hay sách theo chủ đề
          <br/>
          10) Sao chép tài liệu cho bạn đọc.
        
          <p><strong><b>1. Đăng ký  bạn đọc :</b></strong></p>
        <p>Bạn  đọc phải có thẻ sinh viên hoặc thẻ CBVN, giảng viên khi vào thư viện.<br />
          Khi đến sử dụng  thư viện, bạn đọc xuất trình thẻ sinh viên, thẻ CBNV hay giảng viên cho thủ  thư.</p>
        <p><strong><b>2. Tra cứu tài  liệu:</b></strong><br />
            <strong>Tra  cứu sách:</strong><br />
          Bạn  đọc có thể tự tra cứu hoặc yêu cầu thủ thư hướng dẫn cách tra cứu   mục lục trực  tuyến trên máy trạm tra cứu theo 3 loại mục lục: nhan đề,   tác giả và đề mục.<br />
  <strong>Tra  cứu luận văn:</strong><br />
          Bạn    đọc có thể tra tìm luận văn trên máy tính hoặc theo danh mục khóa luận   đã in ra  để tại quầy lưu hành. Các danh mục luận văn này sắp theo khung   phân loại D.D.C  20.<br />
  <strong>Tra  cứu dĩa CD:</strong><br />
          Bạn  đọc có thể tra cứu đĩa CD theo danh mục đĩa CD trên máy tính hay đã in giấy tại  quầy lưu hành.</p>
        <p><strong><b>3. Tìm tài  liệu:</b></strong></p>
        <p><strong>Tìm  sách:</strong><br />
          Sau  khi đã tra cứu trên mục lục   trực tuyến dữ liệu thư tịch của một cuốn sách, bạn  đọc cần ghi nhớ số   hiệu của cuốn sách (số phân loại, ký hiệu tác giả hay nhan  đề). Bạn đọc   có thể trực tiếp đến bên kệ sách để tìm theo thứ tự số hiệu.<br />
          Bạn    đọc cũng có thể đi thẳng vào kho để tìm sách theo bộ môn hay đề tài.   Sách được  sắp theo thứ tự số phân loại trên từng dãy kệ. Ở đầu mỗi dãy   kệ có ghi rõ sách  trên kệ thuộc số phân loại nào. Nếu không tìm được,   bạn đọc có thể tham vấn thủ  thư.<br />
  <strong>Tìm  báo chí:</strong><br />
          Bạn  đọc tự chọn các báo, tạp chí trên kệ báo tạp chí của phòng đọc   báo. Đối với các  tạp chí cũ, bạn đọc liên hệ thủ thư để được hướng dẫn. <br />
  <strong>Tìm  luận văn:</strong><br />
          Bạn  đọc có thể tìm kiếm luận   văn trên mục lục trực tuyến hoặc trên danh mục luận  văn được in ra   giấy tại quầy lưu hành. Bạn đọc ghi lại các số hiệu của luận văn  và nhờ   Thủ thư lấy.<br />
  <strong>Tìm  đĩa CD:</strong><br />
          Bạn  đọc có thể tìm đĩa CD trên danh mục được in sẵn tại quầy lưu hành và nhờ Thủ  thư lấy ra.</p>
        <p><strong><b>4. Mượn tài  liệu xem tại chỗ:</b></strong></p>
        <p><strong>Mượn  sách:</strong><br />
          Bạn  đọc có thể đọc sách trong   phòng báo, tạp chí mà không cần đăng ký mượn sách.  Đọc xong bạn đọc để   sách tại chỗ hoặc tập trung lại một chỗ để thủ thư cất. Nếu  bạn đọc   mang sách trong kho ra phòng đọc chính, phải đăng ký tại quầy thủ thư.<br />
  <strong>Mượn  báo chí:</strong><br />
          Bạn  đọc có thể đọc các nhật báo, tuần báo, tạp chí, tập san tại chỗ   không cần đăng  ký mượn. Bạn đọc không được mượn báo chí mang về nhà.   Báo chí đọc xong để tại  chỗ.<br />
  <strong>Mượn  luận văn:</strong><br />
          Bạn  đọc có thể đọc các luận văn tại chỗ   không cần phải đăng ký. Bạn   đọc không được mượn luận văn về nhà. Bạn đọc  chỉ có thể photo luận văn   cử nhân. </p>
        <p><strong><b>5. Mượn mang  về nhà:</b></strong><br />
          Khi  có nhu cầu mượn sách   về nhà, bạn đọc phải xuất trình thẻ sinh viên để làm thủ  tục mượn về   nhà. Bạn đọc phải thế chân khi mượn tài liệu về nhà theo nội quy  của   thư viện.</p>
        <p><strong><b>6. Trả lời  câu hỏi của bạn đọc:</b></strong><br />
          Thủ  thư tại   quầy lưu hành có nhiệm vụ trả lời những thắc mắc của bạn đọc liên quan    đến tra cứu tài liệu trực tuyến và vị trí của tài liệu.</p>
        <p><strong><b>7. Truy tìm  thông tin cho bạn đọc:</b></strong><br />
          Khi  bạn   đọc có nhu cầu tài liệu về đề tài đang nghiên cứu, thủ thư sẽ cung cấp   cho  bạn đọc danh mục các tài liệu liên quan hiện có trong thư viện.</p>
        <p><strong><b>8. Hướng dẫn  bạn đọc truy cập mạng internet:</b></strong><br />
          Bạn  đọc không biết cách truy cập mạng internet có thể yêu cầu thủ thư   hay kỹ thuật  viên về công nghệ thông tin của thư viện hướng dẫn.</p>
        <p><strong><b>9. Giới thiệu  sách mới hay sách theo chủ đề:</b></strong><br />
          Hàng  tháng thư viện giới thiệu danh mục sách mới bổ sung, sách được tài   trợ trên  trang web trường, gửi thông báo đến các khoa và niêm yết tại   bản tin của thư  viện.</p>
        <p><strong><b>10. Sao chép  tài liệu cho bạn đọc:</b></strong><br />
          Bạn  đọc có thể yêu cầu thủ thư cho sao chép những trang sách hay báo chí mà bạn đọc  cần đọc, nghiên cứu tại nhà, CD-ROM. </p>
        <p>&nbsp;</p>
        <p><strong><u><b>CƠ CẤU NHÂN SỰ:</b></u></strong></p>
        <p><strong>Bà Nguyễn  Thị Thanh Thủy</strong><br />
          Chức vụ: Chủ  nhiệm</p>
        <p><strong>Bà Thái Thị  Thu Nguyệt</strong><br />
          Chức vụ: Chuyên  viên</p>
        <p><strong>Bà Đào Thị Kim Hoa</strong><br />
          Chức vụ: Chuyên viên</p>
        <p><strong>Ông Nguyễn Lâm Phước </strong><br />
          Chức vụ: Nhân Viên</p>
        <p><strong>Bà  Trần Xuân Như</strong><br />
          Chức vụ: Nhân  Viên</p>
        <p><strong>Bà  Vũ Thị Ngọc Mai</strong><br />
          Chức vụ: Nhân  Viên</p>
        <p>&nbsp;</p>
        <p><u><em>LIÊN HỆ:</em></u><br />
          Cơ sở Thư viện đặt tại lầu I khu B,    Đại học Ngoại ngữ - Tin học TPHCM, 155 Sư Vạn Hạnh nối dài, phường 13,   Quận 10,  Thành phố Hồ Chí Minh<br />
          Email: <a href="mailto:Thuvien@huflit.edu.vn">Thuvien@huflit.edu.vn</a><br />
          Điện thoại: (08)  38 621 856</p>
        <p><strong>Giờ mở cửa thư viện</strong><br />
            <strong><b>Từ thứ hai  đến thứ bảy hàng tuần</b></strong><br />
            <strong><b>Sáng: </b></strong> Từ 7h30 đến 11h30<br />
  <strong><b>Chiều:</b></strong> Từ 13h30 đến 17h00</p>
        <p><b>Vào mùa thi thư  viện mở cửa thêm buổi tối:</b> <strong>Từ 17h00 đến 20h30 thứ hai đến thứ sáu hàng tuần.</strong></p>
	  </div>
		<div id="container_bottom"></div>
  </div>
	<div id="Footer">
	</div>
</div>
    </form>
</body>
</html>

