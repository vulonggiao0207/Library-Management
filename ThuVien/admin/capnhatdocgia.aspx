<%@ Page Language="C#" AutoEventWireup="true" CodeFile="capnhatdocgia.aspx.cs" Inherits="admin_capnhatdocgia" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit.HTMLEditor" tagprefix="cc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
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
<form id="mainform" runat="server" enctype="multipart/form-data">
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
		<div id="container_head">Cập nhật độc giả</div>
	  <div id="Container">
      <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
          <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
          <table style="width:690px" bgcolor="#E8F3FF">
              <tr>
                  <td>
                   <asp:Label ID="Label1" runat="server" Text="Tên độc giả: "></asp:Label>
                  <asp:TextBox ID="TimTextbox" runat="server" 
                          Width="550px" Height="20px"></asp:TextBox>  </td>
                  <td><asp:ImageButton ID="TimButton" runat="server" 
                          Text="Thêm mới" Width="25px" 
                          Height="25px" ImageUrl="~/images/search_tool.jpg" 
                          onclick="TimButton_Click"/>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">  
                      
                      <asp:GridView ID="DocGiaGridView" runat="server" AutoGenerateColumns="False" 
                          Width="690px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                          onrowcommand="DocGiaGridView_RowCommand" 
                          onrowcreated="DocGiaGridView_RowCreated" 
                          onselectedindexchanging="DocGiaGridView_SelectedIndexChanging" 
                          onpageindexchanging="DocGiaGridView_PageIndexChanging">
                          <AlternatingRowStyle BackColor="White" />
                          <Columns>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:Image ID="Image1" runat="server" Height="120px" Width="90px" 
                                          Style="margin:5px" ImageUrl='<%# Eval("HinhAnh") %>'/>
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                  <ItemStyle Width="100px" />
                              </asp:TemplateField>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:Label ID="Label2" runat="server" Font-Bold="True" Text="Mã độc giả: "></asp:Label>
                                      <asp:Label ID="MadocgiaLabel" runat="server" Text='<%# Eval("MaDocGia") %>'></asp:Label>
                                      <br />
                                      <asp:Label ID="Labe3" runat="server" Font-Bold="True" Text="Tên độc giả: "></asp:Label>
                                      <asp:Label ID="Tendocgialabel" runat="server" Text='<%# Eval("TenDocGia") %>'></asp:Label>
                                      <br />
                                      <asp:Label ID="Label4" runat="server" Font-Bold="True" Text="Lọai độc giả: "></asp:Label>
                                      <asp:Label ID="LoaidocgiaLabel" runat="server" Text="Label"></asp:Label>
                                      <br />
                                      <asp:Label ID="Label5" runat="server" Font-Bold="True" Text="Giới tính: "></asp:Label>
                                      <asp:Label ID="GioitinhLabel" runat="server" Text="Label"></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Ngày sinh: "></asp:Label>
                                      <asp:Label ID="Label7" runat="server" Text='<%# Eval("NgaySinh") %>'></asp:Label>
                                      <br />
                                      <asp:Label ID="Label8" runat="server" Font-Bold="True" Text="Địa chỉ: "></asp:Label>
                                      <asp:Label ID="Label9" runat="server" Text='<%# Eval("DiaChi") %>'></asp:Label>
                                      <br />
                                      <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Ngày lập thẻ: "></asp:Label>
                                      <asp:Label ID="Label11" runat="server" Text='<%# Eval("NgayLapThe") %>'></asp:Label>
                                      <br />
                                      <asp:Label ID="Label12" runat="server" Font-Bold="True" Text="Ngày hết hạn: "></asp:Label>
                                      <asp:Label ID="Label13" runat="server" Text='<%# Eval("NgayHetHan") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImageButton2" runat="server" Height="25px" 
                                          ImageUrl="~/images/delete.jpg" Width="25px" CommandName="xoa" 
                                          CommandArgument='<%# Eval("MaDocGia") %>' />
                                  </ItemTemplate>
                                  <HeaderStyle Width="25px" />
                                  <ItemStyle Width="25px" />
                              </asp:TemplateField>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImageButton1" runat="server" Height="25px" 
                                          ImageUrl="~/images/update.jpg" Width="25px" Style="margin-left:5px" 
                                          CommandName="sua" CommandArgument='<%# Eval("MaDocGia") %>' />
                                  </ItemTemplate>
                                  <HeaderStyle Width="25px" />
                                  <ItemStyle Width="25px" />
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
              <tr>
                  <td colspan="2">
                      <asp:Label ID="Label14" runat="server" Text="Thêm mới độc giả: " 
                          Style="margin-left:0px;"></asp:Label>
                     <asp:ImageButton runat="server" Text="Thêm mới" Width="25px" Height="25px" 
                          ImageUrl="~/images/insert.jpg" ID="ThemButton"  />
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="ThongBaoLabel" runat="server" ForeColor="Red" 
                          Style="text-align:center" Width="690px"></asp:Label>
                  </td>
              </tr>
          </table>  
          <%--popup thêm độc giả--%>
          <asp:ModalPopupExtender ID="ThemPopup" runat="server"
              PopupControlID="ThemLoaiPanel" TargetControlID="ThemButton"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyButton"
              DropShadow="true">
          </asp:ModalPopupExtender>    
          <%------%>
        <asp:Panel ID="ThemLoaiPanel" runat="server" Width="400px" Style="display:none">            
                <div class="popup_head">Thêm độc giả</div>
                <div class="popup_content">

                    <table class="style1">
                        <tr>
                            <td>
                                <asp:Label ID="Label15" runat="server" Height="25px" Text="Mã độc giả:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="MaDocGiaThemTextBox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label16" runat="server" Height="25px" Text="Tên độc giả:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TenDocGiaThemTextBox" runat="server" Width="270px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" Height="25px" Text="Lọai độc giả:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="LoaiDocGiaThemDropdown" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label18" runat="server" Height="25px" Text="Giới tính:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="GioiTinhThemDropdown" runat="server" Width="60px">
                                    <asp:ListItem Value="True">Nam</asp:ListItem>
                                    <asp:ListItem Value="False">Nữ</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label19" runat="server" Height="25px" Text="Ngày sinh:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="NgaySinhThemTextBox" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="NgaySinhThemTextBox_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="NgaySinhThemTextBox" Format="dd/MM/yyyy" SelectedDate="<%# DateTime.Now.Date %>">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label20" runat="server" Height="25px" Text="Địa chỉ:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="DiaChiThemTextBox" runat="server" Width="270px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label21" runat="server" Height="25px" Text="Hình ảnh:"></asp:Label>
                            </td>
                            <td>
                                <asp:FileUpload ID="HinhAnhThemUpload" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label22" runat="server" Height="25px" Text="Ngày lập thẻ:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="NgayLapTheThemTxt" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="NgayLapTheThemTxt_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="NgayLapTheThemTxt" Format="dd/MM/yyyy" SelectedDate="<%# DateTime.Now.Date %>">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label23" runat="server" Height="25px" Text="Ngày hết hạn:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="NgayHetHanThemTxt" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="NgayHetHanThemTxt_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="NgayHetHanThemTxt" Format="dd/MM/yyyy" SelectedDate="<%# DateTime.Now.Date %>">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label24" runat="server" Height="25px" Text="Mật khẩu:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="MatKhauthemTxt" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="ThemLoaiButton" runat="server" Text="Thêm" Width="50px" 
                                    onclick="ThemLoaiButton_Click" />
                                <asp:Button ID="HuyButton" runat="server" Style="margin-left:10px" Text="Hủy" 
                                    Width="50px" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="ThongBaoThemLabel" runat="server" ForeColor="Red" Width="370px" Style="text-align:center"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
          <%------ --%><%--popup sửa lọai độc giả--%>
          <asp:HiddenField ID="SuaHid" runat="server" />
          <asp:ModalPopupExtender ID="SuaPopup" runat="server"
              PopupControlID="SuaLoaiPanel" TargetControlID="SuaHid"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyLoaiButton"
              DropShadow="true">
          </asp:ModalPopupExtender>      
          <%------%>
        <asp:Panel ID="SuaLoaiPanel" runat="server" Width="400px" Style="display:none">            
                <div class="popup_head">Sửa độc giả</div>
                <div class="popup_content">
                    <table class="style1">
                        <tr>
                            <td>
                                <asp:Label ID="Label30" runat="server" Height="25px" Text="Mã độc giả:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="MaDocGiaSuaTextBox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label31" runat="server" Height="25px" Text="Tên độc giả:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TenDocGiaSuaTextBox" runat="server" Width="270px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label32" runat="server" Height="25px" Text="Lọai độc giả:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="LoaiDocGiaSuaDropdown" runat="server" Width="200px">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label33" runat="server" Height="25px" Text="Giới tính:"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="GioiTinhSuaDropdown" runat="server" Width="60px">
                                    <asp:ListItem Value="True">Nam</asp:ListItem>
                                    <asp:ListItem Value="False">Nữ</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label34" runat="server" Height="25px" Text="Ngày sinh:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="NgaySinhSuaTxt" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="NgaySinhSuaTxt_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="NgaySinhSuaTxt" Format="dd/MM/yyyy" SelectedDate="<%# DateTime.Now.Date %>">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label35" runat="server" Height="25px" Text="Địa chỉ:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="DiaChiSuaTextBox" runat="server" Width="270px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label36" runat="server" Height="25px" Text="Hình ảnh:"></asp:Label>
                            </td>
                            <td>
                                <asp:FileUpload ID="HinhAnhSuaUpload" runat="server" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label37" runat="server" Height="25px" Text="Ngày lập thẻ:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="NgayLapTheSuaTextBox" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="NgayLapTheSuaTextBox_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="NgayLapTheSuaTextBox" Format="dd/MM/yyyy" SelectedDate="<%# DateTime.Now.Date %>">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label38" runat="server" Height="25px" Text="Ngày hết hạn:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="NgayHetHanSuaTextbox" runat="server" Width="100px"></asp:TextBox>
                                <asp:CalendarExtender ID="NgayHetHanSuaTextbox_CalendarExtender" runat="server" 
                                    Enabled="True" TargetControlID="NgayHetHanSuaTextbox" Format="dd/MM/yyyy" SelectedDate="<%# DateTime.Now.Date %>">
                                </asp:CalendarExtender>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label39" runat="server" Height="25px" Text="Mật khẩu:"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="MatKhauSuaTextBox" runat="server" TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="SuaLoaiButton" runat="server" Text="Lưu" Width="50px" 
                                    onclick="SuaLoaiButton_Click" />
                                <asp:Button ID="HuyLoaiButton" runat="server" Style="margin-left:10px" 
                                    Text="Hủy" Width="50px" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
          <%------ --%>
      </div>
		<div id="container_bottom"></div>
	</div>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>