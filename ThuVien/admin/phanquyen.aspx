<%@ Page Language="C#" AutoEventWireup="true" CodeFile="phanquyen.aspx.cs" Inherits="admin_phanquyen" %>

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
		<div id="container_head">Phân quyền cho nhân viên</div>
	  <div id="Container">
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
           <ContentTemplate>
           
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
                      <asp:ScriptManager ID="ScriptManager1" runat="server">
                      </asp:ScriptManager>
                    <%--  <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                      <ContentTemplate>--%>
                      
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
                                <asp:TemplateField HeaderText="Quyền">
                                  <ItemTemplate>
                                      <asp:ImageButton ID="XoaButton" runat="server" Text="Xóa" Width="25px" 
                                          Height="25px" ImageUrl="~/images/rights.jpg" CommandName="phanquyen"  
                                          CommandArgument='<%# Eval("MaNV") %>' ToolTip="Phân quyền"  />
                                                                              
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
                   <%-- </ContentTemplate>
                    </asp:UpdatePanel>--%>
                  </td>
              </tr>
              <tr>
                  <td colspan="2">                 
                  </td>
              </tr>
          </table>  
          <%--popup phân quyền nhân viên--%>
            <asp:HiddenField ID="Hidf" runat="server" />
          <asp:ModalPopupExtender ID="PhanQuyenPopup" runat="server"  
             PopupControlID="PhanQuyenNVPanel" TargetControlID="Hidf"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyLuuButton"
              DropShadow="true">
           </asp:ModalPopupExtender>
          <%------%>
        <asp:Panel ID="PhanQuyenNVPanel" runat="server" Width="400px" Height="130px">            
                <div class="popup_head">Phân quyền nhân viên</div>
                <div class="popup_content">
                    <table>
                        <tr>
                            <td colspan="2">
                                <asp:TabContainer ID="QuyenTab" runat="server" ActiveTabIndex="1" Width="370px" 
                                    Height="130px">
                                    <asp:TabPanel ID="TabPanel1" runat="server" HeaderText="Báo cáo - thống kê">
                                        <ContentTemplate>
                                            <asp:CheckBoxList ID="CheckBoxList1" runat="server">                                              
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                      <asp:TabPanel ID="TabPanel2" runat="server" HeaderText="Quản lý độc giả">
                                        <ContentTemplate>
                                            <asp:CheckBoxList ID="CheckBoxList2" runat="server">                                              
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                      <asp:TabPanel ID="TabPanel3" runat="server" HeaderText="Quản lý đọc tại thư viện">
                                        <ContentTemplate>
                                            <asp:CheckBoxList ID="CheckBoxList3" runat="server">                                              
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                      <asp:TabPanel ID="TabPanel4" runat="server" HeaderText="Quản lý mượn - trả sách">
                                        <ContentTemplate>
                                            <asp:CheckBoxList ID="CheckBoxList4" runat="server">                                              
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                      <asp:TabPanel ID="TabPanel5" runat="server" HeaderText="Quản lý nhân viên">
                                        <ContentTemplate>
                                            <asp:CheckBoxList ID="CheckBoxList5" runat="server">                                              
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                     <asp:TabPanel ID="TabPanel6" runat="server" HeaderText="Quản lý sách">
                                        <ContentTemplate>
                                            <asp:CheckBoxList ID="CheckBoxList6" runat="server">                                              
                                            </asp:CheckBoxList>
                                        </ContentTemplate>
                                    </asp:TabPanel>
                                </asp:TabContainer>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                </td>
                            <td>
                                 <asp:Button ID="LuuButton" runat="server" Text="Lưu" Width="50px" onclick="LuuButton_Click"  />
                                <asp:Button ID="HuyLuuButton" runat="server" Style="margin-left:10px" Text="Hủy" 
                                    Width="50px" /></td>
                        </tr>
                    </table>
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
        </ContentTemplate>
           </asp:UpdatePanel>
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