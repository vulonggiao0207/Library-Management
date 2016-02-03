<%@ Page Language="C#" AutoEventWireup="true" CodeFile="tracuu.aspx.cs" Inherits="tracuu" %>


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
		<li><a href="tracuu.aspx" style="background:#fff;color:#0066CC">Tra cứu sách</a></li>
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
		<div id="container_head">Tra cứu sách</div>
	  <div id="Container">
       <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
	      <table class="style1">
              <tr>
                  <td>
                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Lọai sách: "></asp:Label>
                  </td>
                  <td>
                      <asp:DropDownList ID="LoaisachDropdown" runat="server" Width="200px">
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Thể lọai: "></asp:Label>
                  </td>
                  <td> 
                      
                      <asp:DropDownList ID="TheLoaiDropdown" runat="server" Width="200px" 
                          AutoPostBack="True" 
                          onselectedindexchanged="TheLoaiDropdown_SelectedIndexChanged">
                      </asp:DropDownList>
                      <asp:Label ID="Label3" runat="server" Font-Bold="True" Text="Chủ đề:"></asp:Label>
                      <asp:DropDownList ID="ChudeDropdown" runat="server" Width="200px">
                      </asp:DropDownList>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Tên sách: "></asp:Label>
                  </td>
                  <td>
                      <asp:TextBox ID="TenSachTextBox" runat="server" Width="200px"></asp:TextBox>
                      <asp:Button ID="TìmButton" runat="server" Text="Tìm" 
                          onclick="TìmButton_Click" />
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="ThongBaoLabel" runat="server" ForeColor="Red" Width="690px" Style="text-align:center"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:GridView ID="SachGridview" runat="server" AllowPaging="True" 
                          AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" 
                          GridLines="None" onpageindexchanging="SachGridview_PageIndexChanging" 
                          onrowcreated="SachGridview_RowCreated" ShowHeader="False" Width="690px" 
                          PageSize="6">
                          <AlternatingRowStyle BackColor="White" />
                          <Columns>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <table class="style1">
                                          <tr>
                                              <td rowspan="6">
                                                  <asp:Image ID="HinhAnhImage" runat="server" Height="200px" Width="150px" 
                                                      ImageUrl='<%# Eval("hinhanh") %>' />
                                              </td>
                                              <td>
                                                  <asp:Label ID="Label1" runat="server" Font-Bold="True" Text="Tên sách: "></asp:Label>
                                                  <asp:Label ID="TenSachLabel" runat="server" Font-Size="14pt" ForeColor="Blue" 
                                                      Width="350px" Text='<%# Eval("TenSach") %>'></asp:Label>
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
                                                  <asp:Label ID="NamXuatBanLabel" runat="server" Width="350px" 
                                                      Text='<%# Eval("NamXuatBan") %>'></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Lần xuất bản: "></asp:Label>
                                                  <asp:Label ID="LanXuatBanLabel" runat="server" Width="350px" 
                                                      Text='<%# Eval("Lanxuatban") %>'></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Tác giả: "></asp:Label>
                                                  <br />
                                                  <asp:ListBox ID="TacGiaListBox" runat="server" Width="400px" 
                                                      DataSource='<%# Eval("tacgiacoll") %>' DataTextField="TenTG" 
                                                      DataValueField="MaTG"></asp:ListBox>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                
                                                  <asp:HyperLink ID="HyperLink1" runat="server" 
                                                     NavigateUrl='<%#"sach.aspx?sachid="+ Eval("MaDauSach").ToString() %>'>chi tiết sách...</asp:HyperLink>
                                                
                                              </td>
                                          </tr>
                                      </table>
                                  </ItemTemplate>
                              </asp:TemplateField>
                          </Columns>
                          <EditRowStyle BackColor="#2461BF" />
                          <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                          <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                          <RowStyle BackColor="#EFF3FB" />
                          <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                          <SortedAscendingCellStyle BackColor="#F5F7FB" />
                          <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                          <SortedDescendingCellStyle BackColor="#E9EBEF" />
                          <SortedDescendingHeaderStyle BackColor="#4870BE" />
                      </asp:GridView>
                  </td>
              </tr>
          </table>
	 </ContentTemplate>
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="TìmButton" EventName="Click" />
            </Triggers>
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

