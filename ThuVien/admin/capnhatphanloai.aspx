<%@ Page Language="C#" AutoEventWireup="true" CodeFile="capnhatphanloai.aspx.cs" Inherits="admin_capnhatphanloai" %>


<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/SachTheoTheLoaiUC.ascx" tagname="SachTheoTheLoaiUC" tagprefix="uc2" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="header" runat="server">
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
       .style1
       {
           width: 100%;
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
		<div id="container_head">Cập nhật phân loại sách</div>
	  <div id="Container">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
          </asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>
          <table style="width:400px;margin-left:150px" bgcolor="#E8F3FF">
              <tr>
                  <td><asp:TextBox ID="TimTextbox" runat="server" Width="360px" Height="20px"></asp:TextBox>  </td>
                  <td><asp:ImageButton ID="TimButton" runat="server" Text="Thêm mới" Width="25px" 
                          Height="25px" ImageUrl="~/images/search_tool.jpg" onclick="TimButton_Click" />
                  </td>
              </tr>
              <tr>
                  <td colspan="2">  
                      <asp:GridView ID="PhanLoaiGridView" runat="server" 
                          AutoGenerateColumns="False" Width="400px" 
                          CellPadding="4" ForeColor="#333333" GridLines="None" 
                          onrowcommand="PhanLoaiGridView_RowCommand" >
                         
                          <AlternatingRowStyle BackColor="White" />
                          <Columns>
                              <asp:BoundField DataField="MaPhanLoai" Visible="False">
                              <ControlStyle Width="1px" />
                              <FooterStyle Width="1px" />
                              <HeaderStyle Width="1px" />
                              <ItemStyle Width="1px" />
                              </asp:BoundField>
                              <asp:BoundField DataField="TenPhanLoai" HeaderText="Tên phân loại sách" />
                              <asp:TemplateField HeaderText="Xóa">
                                  <ItemTemplate>
                                      <asp:ImageButton ID="XoaButton" runat="server" Text="Xóa" Width="25px" 
                                          Height="25px" ImageUrl="~/images/delete.jpg" CommandName="xoa"  
                                          CommandArgument='<%# Eval("MaPhanLoai") %>' Style="margin-right:5px" />
                                  </ItemTemplate>
                                  <ControlStyle Width="30px" />
                                  <FooterStyle Width="30px" />
                                  <HeaderStyle Width="30px" />
                                  <ItemStyle Width="30px" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Sửa">
                                  <ItemTemplate>                                     
                                       <asp:ImageButton ID="SuaButton" runat="server" Text="Sửa" Width="25px" 
                                          Height="25px" ImageUrl="~/images/update.jpg" CommandName="sua" Style="margin-right:5px"  
                                          CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                  </ItemTemplate>
                                  <ControlStyle Width="25px" />
                                  <FooterStyle Width="25px" />
                                  <HeaderStyle Width="25px" />
                                  <ItemStyle Width="25px" />
                              </asp:TemplateField>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:ImageButton ID="ImageButton1" runat="server" CommandName="chitiet"  
                                          CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' Height="25px" 
                                          ImageUrl="~/images/rights.jpg" Width="25px" />
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
                      </asp:GridView>
                    
                  </td>
              </tr>
              <tr>
                  <td colspan="2">
                      <asp:Label ID="Label1" runat="server" Text="Thêm mới phân loại sách: " Style="margin-left:0px;"></asp:Label>
                     <asp:ImageButton runat="server" Text="Thêm mới" Width="25px" Height="25px" 
                          ImageUrl="~/images/insert.jpg" ID="ThemButton"  />

                  </td>
              </tr>
          </table>    
         <%--popup thêm loai sach--%>
              <asp:ModalPopupExtender ID="ThemPopup" runat="server"
              PopupControlID="ThemPhanLoaiPanel" TargetControlID="ThemButton"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyButton"
              DropShadow="true">
              </asp:ModalPopupExtender>           
          <%------%>
        <asp:Panel ID="ThemPhanLoaiPanel" runat="server" Width="400px" Style="display: none;">            
                <div class="popup_head">Thêm phân loại sách</div>
                <div class="popup_content">
                    <asp:TextBox ID="ThemPhanLoaiTextBox" runat="server" Width="260px"></asp:TextBox>
                    <asp:Button ID="ThemPhanLoaiButton" runat="server" Text="Thêm" Width="50px" 
                        onclick="ThemPhanLoaiButton_Click" />
                    <asp:Button ID="HuyButton" runat="server" Text="Hủy" Width="50px" Style="margin-left:10px" />
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
         <%------ --%>
          <%--popup sửa loai sach--%>
          <asp:HiddenField ID="SuaHid" runat="server" />
              <asp:ModalPopupExtender ID="SuaPopup" runat="server"
              PopupControlID="SuaPhanLoaiPanel" TargetControlID="SuaHid"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyPhanLoaiButton"
              DropShadow="true">
              </asp:ModalPopupExtender>           
          <%------%>
        <asp:Panel ID="SuaPhanLoaiPanel" runat="server" Width="400px" Style="display: none;">            
                <div class="popup_head">Sửa phân loại sách</div>
                <div class="popup_content">
                    <asp:TextBox ID="SuaTextBox" runat="server" Width="260px"></asp:TextBox>
                    <asp:Button ID="SuaPhanLoaiButton" runat="server" Text="Lưu" Width="50px" 
                        onclick="SuaPhanLoaiButton_Click"/>
                    <asp:Button ID="HuyPhanLoaiButton" runat="server" Text="Hủy" Width="50px" Style="margin-left:10px" />
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
         <%------ --%>

          <%--popup Chitiết lọai sách--%>
          <asp:HiddenField ID="ChiTietHid" runat="server" />
              <asp:ModalPopupExtender ID="ChiTietPopup" runat="server"
              PopupControlID="ChiTietPhanLoaiPanel" TargetControlID="ChiTietHid"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyChiTietButton"
              DropShadow="true">
              </asp:ModalPopupExtender>           
          <%------%>
        <asp:Panel ID="ChiTietPhanLoaiPanel" runat="server" Width="400px" Style="display:none">            
                <div class="popup_head">Chi tiết phân loại sách</div>
                <div class="popup_content">                    
                    <table class="style1">
                        <tr>
                            <td colspan="2">
                                <asp:Label ID="Label2" runat="server" Text="Phân lọai: "></asp:Label>
                                <asp:Label ID="TenPhanLoaiLabel" runat="server" Font-Bold="True" 
                                    ForeColor="Blue" Text="Label" Font-Size="14pt"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="ChiTietGridView" runat="server" CellPadding="4" ForeColor="#333333" 
                                    GridLines="None" Width="380px" AutoGenerateColumns="False" 
                                    onrowcommand="ChiTietGridView_RowCommand">
                                    <AlternatingRowStyle BackColor="White" />
                                    <Columns>
                                        <asp:TemplateField HeaderText="Tên chi tiết phân loại">
                                            <EditItemTemplate>
                                                <asp:TextBox ID="TenChiTietTextBox" runat="server" Width="290px" 
                                                    Text='<%# Eval("TenCTPhanLoai") %>'></asp:TextBox>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:Label ID="TenChiTietLabel" runat="server" 
                                                    Text='<%# Eval("TenCTPhanLoai") %>' Width="290px"></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField>
                                            <EditItemTemplate>
                                                <asp:Button ID="Button1" runat="server" Text="Lưu" 
                                                    CommandArgument='<%# Eval("MaCTPhanLoai") %>' CommandName="luu" />
                                                <asp:Button ID="Button2" runat="server" Text="Hủy" Style="margin-left:5px" 
                                                    CommandName="huy"/>
                                            </EditItemTemplate>
                                            <ItemTemplate>
                                                <asp:ImageButton ID="ImageButton2" runat="server" CommandName="xoa" 
                                                    Height="25px" Width="25px" ImageUrl="~/images/delete.jpg" 
                                                    CommandArgument='<%# Eval("MaCTPhanLoai") %>' />
                                                <asp:ImageButton ID="ImageButton3" runat="server" CommandName="sua" 
                                                    Height="25px" Width="25px" Style="margin-left:5px" 
                                                    ImageUrl="~/images/update.jpg" 
                                                    CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
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
                        <tr>
                            <td>
                                <asp:TextBox ID="TenPhanLoaiThemTextBox" runat="server" Width="250px"></asp:TextBox>
                            </td>
                            <td>
                                <asp:Button ID="ThemChitiet" runat="server" Text="Thêm" Width="50px" 
                                    onclick="ThemChitiet_Click" />
                                <asp:Button ID="HuyChiTietButton" runat="server" Style="margin-left:10px" 
                                    Text="Hủy" Width="50px" />
                            </td>
                        </tr>
                    </table>
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
         <%------ --%>
       
         </ContentTemplate>
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