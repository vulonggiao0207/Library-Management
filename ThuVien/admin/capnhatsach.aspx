<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation ="false"  CodeFile="capnhatsach.aspx.cs" Inherits="admin_capnhatsach" %>

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
		<div id="container_head">Cập nhật sách</div>
	  <div id="Container">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
          </asp:ScriptManager>
          <table style="width:690px" bgcolor="#E8F3FF">
              <tr>
                  <td>
                   <asp:Label ID="Label3" runat="server" Text="Tên sách: "></asp:Label>
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
                      
                      <asp:GridView ID="SachGridView" runat="server" AutoGenerateColumns="False" 
                          Width="690px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                          AllowPaging="True" onpageindexchanging="SachGridView_PageIndexChanging" 
                          onrowcreated="SachGridView_RowCreated" 
                          onrowcommand="SachGridView_RowCommand" PageSize="8">
                          <AlternatingRowStyle BackColor="White" />
                          <Columns>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:Image ID="Image1" runat="server" Height="120px" Width="90px" 
                                          Style="margin:5px" ImageUrl='<%# Eval("HinhAnh") %>' />
                                  </ItemTemplate>
                                  <HeaderStyle Width="100px" />
                                  <ItemStyle Width="100px" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Tên - tác giả">
                                  <ItemTemplate>
                                      <asp:Label ID="TenSachLabel" runat="server" Text='<%# Eval("TenSach") %>' 
                                          Width="200px" Font-Bold="True" Font-Size="13pt" ForeColor="#0000CC"></asp:Label>
                                     <br />
                                      <asp:Label ID="Label6" runat="server" Font-Bold="True" Text="Tác giả:"></asp:Label>
                                      <br />
                                      <asp:ListBox ID="TacGiaListBox" runat="server" Width="200px" 
                                          DataSource='<%# Eval("tacgiaColl") %>' DataTextField="TenTG" DataValueField="MaTG" ></asp:ListBox>
                                  </ItemTemplate>
                                  <HeaderStyle Width="280px" />
                                  <ItemStyle Width="280px" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Thông tin">
                                  <ItemTemplate>
                                      <asp:Label ID="Label7" runat="server" Font-Bold="True" Text="Nhà xuất bản: "></asp:Label>
                                      <asp:Label ID="NhaxuatbanLabel" runat="server" Text=""></asp:Label>
                                      <br />
                                      <asp:Label ID="Label9" runat="server" Font-Bold="True" Text="Năm xuất bản: "></asp:Label>
                                      <asp:Label ID="NamxuatbanLabel" runat="server" Text='<%# Eval("namxuatban") %>'></asp:Label>
                                      <br />
                                      <asp:Label ID="Label10" runat="server" Font-Bold="True" Text="Lần xuất bản: "></asp:Label>
                                      <asp:Label ID="LanxuatbanLabel" runat="server" Text='<%# Eval("lanxuatban") %>'></asp:Label>
                                      <br />
                                      <asp:Label ID="Label13" runat="server" Font-Bold="True" Text="Trị giá: "></asp:Label>
                                      <asp:Label ID="TriGiaLabel" runat="server" Text='<%# Eval("trigia") %>'></asp:Label>
                                      <asp:Label ID="Label25" runat="server" Text=" vnđ"></asp:Label>
                                      <br />
                                      <asp:Label ID="Label15" runat="server" Font-Bold="True" Text="Ngày nhập sách: "></asp:Label>
                                      <asp:Label ID="NgaynhapLabel" runat="server" Text='<%# Eval("ngaynhap") %>'></asp:Label>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImageButton1" runat="server" 
                                          CommandArgument='<%# Eval("madausach") %>' CommandName="chitiet" 
                                          Height="25px" ImageUrl="~/images/rights.jpg" ToolTip="Liệt kê sách" 
                                          Width="25px" Style="margin:0 0 5px 5px"/>
                                          <br />
                                       <asp:ImageButton ID="ImageButton3" runat="server" 
                                          CommandArgument='<%# Eval("madausach") %>' CommandName="xoa" 
                                          Height="25px" ImageUrl="~/images/delete.jpg" ToolTip="Xóa sách" 
                                          Width="25px" Style="margin:0 0 5px 5px"/>
                                          <br />
                                       <asp:ImageButton ID="ImageButton4" runat="server" 
                                          CommandArgument='<%# Eval("madausach") %>' CommandName="sua" 
                                          Height="25px" ImageUrl="~/images/update.jpg" ToolTip="Sửa thông tin" 
                                          Width="25px" Style="margin:0 0 5px 5px"/>
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
                      <asp:Label ID="Label1" runat="server" Text="Thêm mới sách: " 
                          Style="margin-left:0px;"></asp:Label>
                     <asp:ImageButton runat="server" Text="Thêm mới" Width="25px" Height="25px" 
                          ImageUrl="~/images/insert.jpg" ID="ThemButton"  />                     
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="ThongbaoLabel" runat="server" ForeColor="Red" Width="680px" Style="text-align:center"></asp:Label>
                  </td>
              </tr>
          </table>  

            <%--popup thêm sach--%>
          <asp:ModalPopupExtender ID="ThemPopup" runat="server"
              PopupControlID="ThemSachPanel" TargetControlID="ThemButton"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyButton"
              DropShadow="true">
          </asp:ModalPopupExtender>       
          <%------%>
        <asp:Panel ID="ThemSachPanel" runat="server" Width="400px" Style="display:none">       
                <div class="popup_head">Thêm đầu sách</div>
                <div class="popup_content">
                     <table>
                         <tr>
                             <td>
                                 <asp:Label ID="Label16" runat="server" Text="Tên sách:" Height="25px"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TenSachMoiTextBox" runat="server" Width="280px"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label21" runat="server" Text="Tác giả:"></asp:Label>
                             </td>
                             <td>
                             <asp:Panel ID="Panel1" runat="server" Height="120px" ScrollBars="Auto" 
                                     Width="280px">
                                 <asp:CheckBoxList ID="TacgiaMoiList" runat="server" Height="120px" 
                                     Width="260px">
                                 </asp:CheckBoxList>
                            </asp:Panel>
                                 <br />
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label17" runat="server" Text="Nhà xuất bản:" Height="25px"></asp:Label>
                             </td>
                             <td>
                                 <asp:DropDownList ID="NhaxuatbanMoiDropdown" runat="server" Width="280px">
                                 </asp:DropDownList>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label24" runat="server" Text="Hình ảnh:" Height="25px"></asp:Label>
                             </td>
                             <td>
                                 <asp:FileUpload ID="HinhAnhMoiFileUpLoad" runat="server" />
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label18" runat="server" Height="25px" Text="Năm xuất bản:"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="NamxuatbanMoiTextBox" runat="server" Width="100px"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label19" runat="server" Text="Lần xuất bản:" Height="25px"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="LanxuatbanMoiTextbox" runat="server" Width="100px"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label20" runat="server" Text="Trị giá:" Height="25px"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TrigiaMoiTextBox" runat="server" Width="100px"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label22" runat="server" Text="Ngày nhập:" Height="25px"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="NgaynhapsachMoiTextBox" runat="server" Width="100px"></asp:TextBox>
                                 <asp:CalendarExtender ID="NgaynhapsachMoiTextBox_CalendarExtender" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="NgaynhapsachMoiTextBox" SelectedDate="<%# DateTime.Now.Date %>">
                                 </asp:CalendarExtender>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label23" runat="server" Text="Số lượng:"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="SoluongMoiTextBotx" runat="server" Width="100px"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 &nbsp;</td>
                             <td>
                                 <asp:Button ID="ThemSachButton" runat="server" onclick="ThemSachButton_Click" Text="Thêm" Width="50px" />
                                 <asp:Button ID="HuyButton" runat="server" Style="margin-left:10px" Text="Hủy" 
                                     Width="50px" />
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2">
                                 <asp:Label ID="ThemSachThongBaolabel" runat="server" ForeColor="Red" 
                                     Width="380px" Style="text-align:center"></asp:Label>
                             </td>
                         </tr>
                     </table>
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
          <%--------%><%--popup chi tiết sách--%>
              <asp:HiddenField ID="ChiTietSachHid" runat="server" />
              <asp:ModalPopupExtender ID="ChiTietPopup" runat="server"
              PopupControlID="ChiTietSachPanel" TargetControlID="ChiTietSachHid"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyChiTietButton"
              DropShadow="true">
          </asp:ModalPopupExtender>  
          <%--------%>
           <asp:Panel ID="ChiTietSachPanel" runat="server" Width="400px" Style="display:none">     
                <div class="popup_head">Chi tiết đầu sách</div>
                <div class="popup_content">
                     <table width="380">
                       <tr>  <td style="width:125px">                                
                           
                             <asp:Image ID="HinhanhdausachImage" runat="server" Height="160px" 
                                 Width="120px" />                           
                             </td>
                             
                           <td>
                               <asp:Label ID="TenDauSachLabel" runat="server" Font-Bold="False" 
                                   Font-Size="14pt" ForeColor="Blue"></asp:Label>
                               <br />
                               <asp:Label ID="Label28" runat="server" Font-Bold="True" Text="Lần xuất bản: "></asp:Label>
                               <asp:Label ID="ChiTietDauSachLanXuatBanLabel" runat="server"></asp:Label>
                               <br />
                               <asp:Label ID="Label30" runat="server" Font-Bold="True" Text="Trị giá: "></asp:Label>
                               <asp:Label ID="ChiTietDauSachTriGiaLabel" runat="server" Width="80px"></asp:Label>
                               <asp:Label ID="Label33" runat="server" Text=" vnđ"></asp:Label>
                               <br />
                               <asp:Label ID="Label32" runat="server" Font-Bold="True" Text="Ngày nhập: "></asp:Label>
                               <asp:Label ID="ChiTietDauSachNgayNhapLabel" runat="server"></asp:Label>
                           </td>
                             
                         </tr> 
                         <tr>
                             <td colspan="2">                                
                           
                                 <asp:GridView ID="ChiTietDauSachGridView" runat="server" AutoGenerateColumns="False" 
                                     Width="380px" CellPadding="4" ForeColor="#333333" GridLines="None" 
                                     onrowcommand="ChiTietDauSachGridView_RowCommand">
                                     <AlternatingRowStyle BackColor="White" />
                                     <Columns>
                                         <asp:BoundField DataField="MaSach" HeaderText="Mã sách" />
                                         <asp:TemplateField>
                                             <ItemTemplate>
                                                 <asp:ImageButton ID="ImageButton2" runat="server" CommandName="xoa" Height="25px" 
                                                     ImageUrl="~/images/delete.jpg" Width="25px" Style="margin-left:5px" 
                                                     CommandArgument='<%# Eval("Masach") %>'/>
                                             </ItemTemplate>
                                             <HeaderStyle Width="25px" />
                                             <ItemStyle Width="25px" />
                                         </asp:TemplateField>
                                         <asp:TemplateField>
                                             <ItemTemplate>
                                                 <asp:ImageButton ID="ImageButton5" runat="server" 
                                                     CommandArgument='<%# Eval("MaSach") %>' Height="25px" 
                                                     ImageUrl="~/images/print.jpg" ToolTip="In mã" Width="25px" 
                                                     CommandName="in" />
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
                         <td>                                
                             </td>
                             <td>
                                 <asp:Button ID="ThemChiTietSachButton" runat="server" Text="Thêm sách" onclick="ThemChiTietSachButton_Click"/>
                                 <asp:Button ID="InToanBoButton" runat="server" Text="In mã" 
                                     Style="margin-left:20px" Width="55px" onclick="InToanBoButton_Click"/>
                                 <asp:Button ID="HuyChiTietButton" runat="server" Style="margin-left:20px" 
                                     Text="Hủy" Width="55px" />
                             </td>                             
                         </tr>
                         <tr>
                             <td colspan="2">
                                 <asp:Label ID="XoaThongBaoLabel" runat="server" ForeColor="Red" 
                                     Width="380px" Style="text-align:center"></asp:Label>
                             </td>
                         </tr>
                     </table>
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
          <%------%>
          <asp:HiddenField ID="SuaSachHid" runat="server" />
          <%--popup thêm sach--%>
          <asp:ModalPopupExtender ID="SuaPopup" runat="server"
              PopupControlID="SuaSachPanal" TargetControlID="SuaSachHid"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyLuuTextBox"
              DropShadow="true">
          </asp:ModalPopupExtender>       
          <%------%>
        <asp:Panel ID="SuaSachPanal" runat="server" Width="400px" Style="display:none">          
                <div class="popup_head">Sửa đầu sách</div>
                <div class="popup_content">
                     <table>
                         <tr>
                             <td>
                                 <asp:Label ID="Label2" runat="server" Text="Tên sách:" Height="25px"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TenSachSuaTextBox" runat="server" Width="280px"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label4" runat="server" Text="Tác giả:"></asp:Label>
                             </td>
                             <td>
                             <asp:Panel ID="Panel3" runat="server" Height="120px" ScrollBars="Auto" 
                                     Width="280px">
                                 <asp:CheckBoxList ID="TacGiaSuaListBox" runat="server" Height="120px" 
                                     Width="260px">
                                 </asp:CheckBoxList>
                            </asp:Panel>
                                 <br />
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label5" runat="server" Text="Nhà xuất bản:" Height="25px"></asp:Label>
                             </td>
                             <td>
                                 <asp:DropDownList ID="NhaXuatBanSuaDropDown" runat="server" Width="280px">
                                 </asp:DropDownList>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label8" runat="server" Text="Hình ảnh:" Height="25px"></asp:Label>
                             </td>
                             <td>
                                 <asp:FileUpload ID="HinhAnhSuaUpload" runat="server" />
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label11" runat="server" Height="25px" Text="Năm xuất bản:"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="NamXuatBanSuaTextBox" runat="server" Width="100px"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label12" runat="server" Text="Lần xuất bản:" Height="25px"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="LanXuatBanSuaTextBox" runat="server" Width="100px"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label14" runat="server" Text="Trị giá:" Height="25px"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="TriGiaSuaTextBox" runat="server" Width="100px"></asp:TextBox>
                             </td>
                         </tr>
                         <tr>
                             <td>
                                 <asp:Label ID="Label26" runat="server" Text="Ngày nhập:" Height="25px"></asp:Label>
                             </td>
                             <td>
                                 <asp:TextBox ID="NgayNhapSuaTextBox" runat="server" Width="100px"></asp:TextBox>
                                 <asp:CalendarExtender ID="CalendarExtender1" runat="server" 
                                    Enabled="True" Format="dd/MM/yyyy" TargetControlID="NgayNhapSuaTextBox" SelectedDate="<%# DateTime.Now.Date %>">
                                 </asp:CalendarExtender>
                             </td>
                         </tr>                        
                         <tr>
                             <td>
                                 &nbsp;</td>
                             <td>
                                 <asp:Button ID="LuuButton" runat="server" Text="Lưu" Width="50px" 
                                     onclick="LuuButton_Click"  />
                                 <asp:Button ID="HuyLuuTextBox" runat="server" Style="margin-left:10px" Text="Hủy" 
                                     Width="50px" />
                             </td>
                         </tr>
                         <tr>
                             <td colspan="2">
                                 <asp:Label ID="SuaThongBaoLabel" runat="server" ForeColor="Red" Width="380px" Style="text-align:center"></asp:Label>
                             </td>
                         </tr>
                     </table>
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
          <%--------%>
      </div>
		<div id="container_bottom"></div>
	</div>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>