<%@ page language="C#" autoeventwireup="true" inherits="admin_capnhatnxb, App_Web_hvldu23q" %>

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
		<div id="container_head">Cập nhật nhà xuất bản</div>
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
                      <asp:GridView ID="NhaxuatbanGridView" runat="server" 
                          AutoGenerateColumns="False" EnableModelValidation="True" Width="400px" 
                          CellPadding="4" ForeColor="#333333" GridLines="None" 
                          onrowcommand="NhaxuatbanGridView_RowCommand">
                          <AlternatingRowStyle BackColor="White" />
                          <Columns>
                              <asp:BoundField DataField="manxb" Visible="False">
                              <ControlStyle Width="1px" />
                              <FooterStyle Width="1px" />
                              <HeaderStyle Width="1px" />
                              <ItemStyle Width="1px" />
                              </asp:BoundField>
                              <asp:BoundField DataField="Tennxb" HeaderText="Tên nhà xuất bản" />
                              <asp:TemplateField HeaderText="Xóa">
                                  <ItemTemplate>
                                      <asp:ImageButton ID="XoaButton" runat="server" Text="Xóa" Width="25px" 
                                          Height="25px" ImageUrl="~/images/delete.jpg" CommandName="xoa"  
                                          CommandArgument='<%# Eval("MaNXB") %>' Style="margin-right:5px" />
                                  </ItemTemplate>
                                  <ControlStyle Width="30px" />
                                  <FooterStyle Width="30px" />
                                  <HeaderStyle Width="30px" />
                                  <ItemStyle Width="30px" />
                              </asp:TemplateField>
                              <asp:TemplateField HeaderText="Sửa">
                                  <ItemTemplate>                                     
                                       <asp:ImageButton ID="SuaButton" runat="server" Text="Sửa" Width="25px" 
                                          Height="25px" ImageUrl="~/images/update.jpg" CommandName="sua"  
                                          CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>'
/>

                                  </ItemTemplate>
                                  <ControlStyle Width="25px" />
                                  <FooterStyle Width="25px" />
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
                      <asp:Label ID="Label1" runat="server" Text="Thêm mới nhà xuất bản: " Style="margin-left:0px;"></asp:Label>
                     <asp:ImageButton runat="server" Text="Thêm mới" Width="25px" Height="25px" 
                          ImageUrl="~/images/insert.jpg" ID="ThemButton"  />

                  </td>
              </tr>
          </table>    
         <%--popup thêm nhà xuất bản--%>
              <asp:ModalPopupExtender ID="ThemPopup" runat="server"
              PopupControlID="ThemNXBPanel" TargetControlID="ThemButton"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyButton"
              DropShadow="true">
              </asp:ModalPopupExtender>           
          <%------%>
        <asp:Panel ID="ThemNXBPanel" runat="server" Width="400px" Style="display: none;">            
                <div class="popup_head">Thêm nhà xuất bản</div>
                <div class="popup_content">
                    <asp:TextBox ID="ThemNXBTextBox" runat="server" Width="260px"></asp:TextBox>
                    <asp:Button ID="ThemNXBButton" runat="server" Text="Thêm" Width="50px" 
                        onclick="ThemNXBButton_Click" />
                    <asp:Button ID="HuyButton" runat="server" Text="Hủy" Width="50px" Style="margin-left:10px" />
                </div>
                <div class="popup_bottom"></div>
        </asp:Panel> 
         <%------ --%>
          <%--popup sửa nhà xuất bản--%>
          <asp:HiddenField ID="SuaHid" runat="server" />
              <asp:ModalPopupExtender ID="SuaPopup" runat="server"
              PopupControlID="SuaNXBPanel" TargetControlID="SuaHid"
              BackgroundCssClass="PopupBackground" CancelControlID="HuyNXBButton"
              DropShadow="true">
              </asp:ModalPopupExtender>           
          <%------%>
        <asp:Panel ID="SuaNXBPanel" runat="server" Width="400px" Style="display: none;">            
                <div class="popup_head">Sửa nhà xuất bản</div>
                <div class="popup_content">
                    <asp:TextBox ID="SuaTextBox" runat="server" Width="260px"></asp:TextBox>
                    <asp:Button ID="SuaNXBButton" runat="server" Text="Lưu" Width="50px" 
                        onclick="SuaNXBButton_Click"/>
                    <asp:Button ID="HuyNXBButton" runat="server" Text="Hủy" Width="50px" Style="margin-left:10px" />
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