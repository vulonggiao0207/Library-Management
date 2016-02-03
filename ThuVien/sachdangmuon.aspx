<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sachdangmuon.aspx.cs" Inherits="sachdangmuon" %>


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
		<div id="container_head">Sách đang mượn</div>
	  <div id="Container">
	   
	      <table class="style1">
              <tr>
                  <td>
                      <asp:Label ID="DocGiaLabel" runat="server" Width="690px" 
                           Style="text-align:center" ForeColor="Red"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:GridView ID="SachGridview" runat="server" Width="690px" BackColor="White" 
                          BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                          ForeColor="Black" GridLines="Horizontal" AutoGenerateColumns="False" 
                          onrowcreated="SachGridview_RowCreated" ShowHeader="False">
                          <Columns>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <table class="style1">
                                          <tr>
                                              <td colspan="2">
                                                  <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Mã sách:"></asp:Label>
                                                  <asp:Label ID="MaSachLabel" runat="server" Width="500px" 
                                                      Text='<%# Eval("masach") %>' ></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td rowspan="5">
                                                  <asp:Image ID="HinhAnhimage" runat="server" Height="200px" Style="margin:5px" 
                                                      Width="150px" />
                                              </td>
                                              <td>
                                                  <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Tên sách:"></asp:Label>
                                                  <asp:Label ID="TenSachLabel" runat="server" Font-Size="14pt" ForeColor="Blue" 
                                                      Width="340px"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Nhà xuất bản:"></asp:Label>
                                                  <asp:Label ID="NhaxuatbanLabel" runat="server" Width="300px"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Năm xuất bản:"></asp:Label>
                                                  <asp:Label ID="NamxuatbanLabel" runat="server" Width="300px"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Lần xuất bản:"></asp:Label>
                                                  <asp:Label ID="LanxuatbanLabel" runat="server" Width="300px"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Tác giả:"></asp:Label>
                                                  <br />
                                                  <asp:ListBox ID="TacGiaListBox" runat="server" Width="300px"></asp:ListBox>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  &nbsp;</td>
                                              <td>
                                                  <asp:Label ID="Label23" runat="server" Font-Bold="True" Text="Trị giá:  "></asp:Label>
                                                  <asp:Label ID="TriGiaLabel" runat="server" Text='<%# Eval("Tienthechan") %>'></asp:Label>
                                                  <asp:Label ID="Label24" runat="server" Text=" vnđ"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  &nbsp;</td>
                                              <td>
                                                  <asp:Label ID="Label21" runat="server" Font-Bold="True" Text="Tiền thế chân:  "></asp:Label>
                                                  <asp:Label ID="TienTheChanLabel" runat="server" 
                                                      Text='<%# Eval("Tienthechan") %>'></asp:Label>
                                                  <asp:Label ID="Label22" runat="server" Text=" vnđ"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:HiddenField ID="maphieuhid" runat="server" 
                                                      Value='<%# Eval("maphieumuon") %>' />
                                              </td>
                                              <td>
                                                  <asp:Label ID="Label18" runat="server" Font-Bold="True" Text="Ngày mượn:  "></asp:Label>
                                                  <asp:Label ID="NgaymuonLabel" runat="server"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  &nbsp;</td>
                                              <td>
                                                  <asp:Label ID="Label19" runat="server" Font-Bold="True" Text="Hết hạn ngày: "></asp:Label>
                                                  <asp:Label ID="HethanLabel" runat="server"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  &nbsp;</td>
                                              <td>
                                                  <asp:Label ID="Label20" runat="server" Font-Bold="True" Text="Gia hạn đến: "></asp:Label>
                                                  <asp:Label ID="GiahanLabel" runat="server" Text='<%# Eval("Giahan") %>'></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  &nbsp;</td>
                                              <td>
                                                  <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Trễ hạn: "></asp:Label>
                                                  <asp:Label ID="NgaytrehanLabel" runat="server">0</asp:Label>
                                                  <asp:Label ID="Label17" runat="server" Text=" ngày"></asp:Label>
                                              </td>
                                          </tr>
                                      </table>
                                  </ItemTemplate>
                              </asp:TemplateField>
                          </Columns>
                          <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
                          <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
                          <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
                          <SortedAscendingCellStyle BackColor="#F7F7F7" />
                          <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
                          <SortedDescendingCellStyle BackColor="#E5E5E5" />
                          <SortedDescendingHeaderStyle BackColor="#242121" />

<SortedAscendingCellStyle BackColor="#F1F1F1"></SortedAscendingCellStyle>

<SortedAscendingHeaderStyle BackColor="Gray"></SortedAscendingHeaderStyle>

<SortedDescendingCellStyle BackColor="#CAC9C9"></SortedDescendingCellStyle>

<SortedDescendingHeaderStyle BackColor="#383838"></SortedDescendingHeaderStyle>
                      </asp:GridView>
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

