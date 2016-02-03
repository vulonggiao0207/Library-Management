<%@ Page Language="C#" AutoEventWireup="true" CodeFile="capnhatnhanvien.aspx.cs" Inherits="admin_capnhatnhanvien" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

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
		<div id="container_head">Cập nhật nhân viên</div>
	  <div id="Container">
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
        <%--    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>--%>
          <table style="width:690px" bgcolor="#E8F3FF">
              <tr>
                  <td>
                   <asp:Label ID="Label3" runat="server" Text="Tên nhân viên: "></asp:Label>
                  <asp:TextBox ID="TimTextbox" runat="server" 
                          Width="550px" Height="20px"></asp:TextBox>  </td>
                  <td><asp:ImageButton ID="TimButton" runat="server" 
                          Text="Thêm mới" Width="25px" 
                          Height="25px" ImageUrl="~/images/search_tool.jpg" 
                          onclick="TimButton_Click" />
                  </td>
              </tr>
              <tr>
                  <td colspan="2">  
                      
                      <asp:GridView ID="NhanVienGridView" runat="server" Width="690px" 
                          AutoGenerateColumns="False" onrowcreated="NhanVienGridView_RowCreated" 
                          CellPadding="4" ForeColor="#333333" GridLines="None" 
                          onrowcommand="NhanVienGridView_RowCommand">
                          <AlternatingRowStyle BackColor="White" />
                          <Columns>
                              <asp:TemplateField HeaderText="Hình ảnh">
                                  <ItemTemplate>
                                      <asp:Image ID="HinhAnhImage" runat="server" Height="120px" 
                                          ImageUrl='<%# Eval("HinhAnh") %>' Width="90px" />
                                      <br />
                                      <asp:Label ID="TaiKhoanLabel" runat="server" Text='<%# Eval("TaiKhoan") %>' 
                                          Width="90px"></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="90px"/>
                                  <ItemStyle Width="90px" Height="130px" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Thông tin cá nhân">
                                  <ItemTemplate>
                                      <asp:Label ID="Label2" runat="server" Text="Họ tên: " Font-Bold="True"></asp:Label>
                                      <asp:Label ID="HoTenLabel" runat="server" Height="23px" Text='<%# Eval("TenNV") %>' Width="170px"></asp:Label>
                                      <br />
                                      <asp:Label ID="Label4" runat="server" Text="Chức vụ: " Font-Bold="True"></asp:Label>
                                      <asp:Label ID="ChucVuLabel" runat="server"></asp:Label>
                                      <br />
                                        <asp:Label ID="Label8" runat="server" Text="Ngày sinh: " Font-Bold="True"></asp:Label>
                                      <asp:Label ID="NgaySinhLabel" runat="server" Text='<%# Eval("NgaySinh") %>' 
                                          Width="100px"></asp:Label>
                                      <br />
                                      <asp:Label ID="Label10" runat="server" Text="Giới tính: " Font-Bold="True"></asp:Label>
                                      <asp:Label ID="GioiTinhLabel" runat="server"></asp:Label>
                                      <br />
                                  </ItemTemplate>
                                  <HeaderStyle Width="180px"/>
                                  <ItemStyle Width="180px" Height="130px" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Thông tin liên lạc">
                                  <ItemTemplate>
                                      <asp:Label ID="Label5" runat="server" Text="Địa chỉ: " Font-Bold="True"></asp:Label>
                                      <br />
                                      <asp:Label ID="DiaChiLabel" runat="server" Text='<%# Eval("DiaChi") %>' 
                                          Width="180px"></asp:Label>
                                      <br />
                                      <asp:Label ID="Label7" runat="server" Text="Số điện thoại: " Font-Bold="True"></asp:Label>
                                      <asp:Label ID="SoDTLabel" runat="server" Text='<%# Eval("DienThoai") %>' 
                                          Width="140px"></asp:Label>
                                  </ItemTemplate>
                                  <HeaderStyle Width="180px"/>
                                  <ItemStyle Width="180px" Height="130px" />
                              </asp:TemplateField>                           
                                <asp:TemplateField HeaderText="Xóa">
                                  <ItemTemplate>
                                      <asp:ImageButton ID="XoaButton" runat="server" Text="Xóa" Width="25px" 
                                          Height="25px" ImageUrl="~/images/delete.jpg" CommandName="xoa"  
                                          CommandArgument='<%# Eval("MaNV") %>' ToolTip="Xóa"  />
                                                                              
                                  </ItemTemplate>
                                  <HeaderStyle Width="25px" />
                                  <ItemStyle Width="25px" Height="130px" />
                              </asp:TemplateField>
                               <asp:TemplateField HeaderText="Sửa">
                                  <ItemTemplate>
                                          <asp:ImageButton ID="SuaButton" runat="server" Text="Sửa" Width="25px" 
                                          Height="25px" ImageUrl="~/images/update.jpg" CommandName="sua"  
                                          CommandArgument='<%# Eval("MaNV") %>' ToolTip="Sửa" />
                                  </ItemTemplate>
                                  <HeaderStyle Width="25px" />
                                  <ItemStyle Width="25px" Height="130px" />
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
                      <asp:Label ID="Label1" runat="server" Text="Thêm mới nhân viên: " 
                          Style="margin-left:0px;"></asp:Label>
                     <asp:ImageButton runat="server" Text="Thêm mới" Width="25px" Height="25px" 
                          ImageUrl="~/images/insert.jpg" ID="ThemButton"  />
                      <asp:Label ID="Label11" runat="server" Text="Phục hồi nhân viên cũ:" 
                          Style="margin-left:20px;"></asp:Label>
                     <asp:ImageButton runat="server" Text="Thêm mới" Width="25px" Height="25px" 
                          ImageUrl="~/images/restore.jpg" ID="PhucHoiButton"  />
                  </td>
              </tr>
          </table>  

         
           <%--popup thêm nhà xuất bản--%>
          <asp:ModalPopupExtender ID="ThemPopup" runat="server"  
             PopupControlID="ThemNVPanel" TargetControlID="ThemButton"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyButton"
              DropShadow="true">
          </asp:ModalPopupExtender>      
          <%------%>
        <asp:Panel ID="ThemNVPanel" runat="server" Width="400px" Style="display:none">            
                <div class="popup_head">Thêm nhân viên</div>
                <div class="popup_content">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Label12" runat="server" Text="Tên nhân viên:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TenNVMoiTextBox" runat="server" Width="270px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label13" runat="server" Text="Chức vụ:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ChucVuMoiDropdown" runat="server" Width="150px" ValidationGroup="2">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label14" runat="server" Text="Giới tính:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="GioiTinhMoiDropdown" runat="server" Width="100px" ValidationGroup="2">
                                    <asp:ListItem Value="True">Nam</asp:ListItem>
                                    <asp:ListItem Value="False">Nữ</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label15" runat="server" Text="Ngày sinh: " Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="NgaySinhMoiTextBox" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="NgaySinhMoiTextBox_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="NgaySinhMoiTextBox" SelectedDate="<%# DateTime.Now.Date %>">
                                </asp:CalendarExtender>
                             </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label16" runat="server" Text="Địa chỉ:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="DiaChiMoiTextBox" runat="server" Width="270px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label17" runat="server" Text="Số điện thọai:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="DienThoaiMoiTextBox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label18" runat="server" Text="Hình ảnh:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:FileUpload ID="HinhAnhMoiFileUpLoad" runat="server" Width="270px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label19" runat="server" Text="Tài khoản:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TaiKhoanMoiTextBox" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Label20" runat="server" Text="Mật khẩu:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="MatKhauMoiTextBox" runat="server" Width="200px" 
                                    TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="ThemNVButton" runat="server" Text="Thêm" Width="50px" 
                                    onclick="ThemNVButton_Click" />
                                <asp:Button ID="HuyButton" runat="server" Style="margin-left:10px" Text="Hủy" 
                                    Width="50px" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
          <%------ --%>      
                <%--popup sửa nhân viên--%>
            <asp:HiddenField ID="Hidf" runat="server" />
          <asp:ModalPopupExtender ID="SuaPopup" runat="server"  
             PopupControlID="SuaNVPanel" TargetControlID="Hidf"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyLuuButton"
              DropShadow="true">
          </asp:ModalPopupExtender>      
          <%------%>
        <asp:Panel ID="SuaNVPanel" runat="server" Width="400px" Style="display:none">            
                <div class="popup_head">Sửa nhân viên</div>
                <div class="popup_content">
                    <table>
                        <tr>
                            <td>
                                <asp:Label ID="Labe21" runat="server" Text="Tên nhân viên:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TenNVSuaTextBox" runat="server" Width="270px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Labe22" runat="server" Text="Chức vụ:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="ChucVuSuaDropdown" runat="server" Width="150px" 
                                    ValidationGroup="1">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Labe23" runat="server" Text="Giới tính:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:DropDownList ID="GioiTinhSuaDropdown" runat="server" Width="100px" 
                                    ValidationGroup="1">
                                    <asp:ListItem Value="True">Nam</asp:ListItem>
                                    <asp:ListItem Value="False">Nữ</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Labe24" runat="server" Text="Ngày sinh: " Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="NgaySinhSuaTextBox" runat="server"></asp:TextBox>
                                <asp:CalendarExtender ID="NgaySinhSuaCalender" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="NgaySinhSuaTextBox" SelectedDate="<%# DateTime.Now.Date %>">
                                </asp:CalendarExtender>
                             </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Labe25" runat="server" Text="Địa chỉ:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="DiaChiSuaTextBox" runat="server" Width="270px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Labe26" runat="server" Text="Số điện thọai:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="DienThoaiSuaTextBox" runat="server"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Labe27" runat="server" Text="Hình ảnh:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:AsyncFileUpload ID="HinhAnhSuaFileUpload" runat="server" Width="270px" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Labe28" runat="server" Text="Tài khoản:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="TaiKhoanSuaTextBox" runat="server" Width="200px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Label ID="Labe29" runat="server" Text="Mật khẩu:" Height="25px"></asp:Label>
                            </td>
                            <td>
                                <asp:TextBox ID="MatKhauSuaTextBox" runat="server" Width="200px" 
                                    TextMode="Password"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;</td>
                            <td>
                                <asp:Button ID="LuuButton" runat="server" Text="Lưu" Width="50px" 
                                    onclick="LuuButton_Click"  />
                                <asp:Button ID="HuyLuuButton" runat="server" Style="margin-left:10px" Text="Hủy" 
                                    Width="50px" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
          <%------ --%>   
       <%--  <%--popup phục hồi nhân viên--%>
         <asp:ModalPopupExtender ID="PhucHoiPopup" runat="server"  
             PopupControlID="PhucHoiPanel" TargetControlID="PhucHoiButton"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyPhucHoiButton"
              DropShadow="true">
          </asp:ModalPopupExtender>
          <%------%>
        <asp:Panel ID="PhucHoiPanel" runat="server" Width="690px">            
                <div class="container_head">Phục hồi nhân viên đã xóa</div>
                <div class="Container"> 
                 <table>
                 <tr>
                 <td colspan="2">
                   
                   </td>
                 </tr>
                 <tr>
                 <td></td>
                 <td> 
                    <asp:Button ID="HuyPhucHoiButton" runat="server" Style="margin-left:10px" Text="Hủy" Width="50px" /> 
                 </td>
                 </tr>
                 </table>  
                 
                </div>
                <div class="container_bottom"></div>
        </asp:Panel> 
          <%------ --%>

    <%--     </ContentTemplate>
       </asp:UpdatePanel>--%>
         
          
      </div>
		<div id="container_bottom"></div>
	</div>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>