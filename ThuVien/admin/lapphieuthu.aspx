<%@ Page Language="C#" AutoEventWireup="true" CodeFile="lapphieuthu.aspx.cs" Inherits="admin_lapphieuphat" %>

<%@ Register Assembly="CrystalDecisions.Web, Version=13.0.2000.0, Culture=neutral, PublicKeyToken=692fbea5521e1304"
    Namespace="CrystalDecisions.Web" TagPrefix="CR" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>

<%@ Register src="../usercontrols/PhanQuyenUC.ascx" tagname="PhanQuyenUC" tagprefix="uc1" %>

<%@ Register src="../usercontrols/admin_navigatorUC.ascx" tagname="admin_navigatorUC" tagprefix="uc3" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
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
		<div id="container_head">Lập phiếu thu</div>
	  <div id="Container">
          <asp:ScriptManager ID="ScriptManager1" runat="server">
          </asp:ScriptManager>
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
          <ContentTemplate>          
          <table style="width:600px;margin-left:50px " bgcolor="#E8F2FF">
              <tr>
                  <td bgcolor="#999999">
                      <asp:Label ID="Label2" runat="server" Font-Bold="True" ForeColor="White" 
                          Height="23px" Text="  Thông tin sách mượn của độc giả"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="Label1" runat="server" Text="Mã độc giả: " Font-Bold="False"></asp:Label>
                      <asp:TextBox ID="MadocgiaTextbox" runat="server" Width="200px"></asp:TextBox>
                      <asp:Button ID="TimButton" runat="server" Text="Tìm" Width="50px" 
                          onclick="TimButton_Click" />
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:Label ID="DocGiaLabel" runat="server" Width="600px" 
                           Style="text-align:center" ForeColor="Red"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:GridView ID="SachGridview" runat="server" Width="600px" BackColor="White" 
                          BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" 
                          ForeColor="Black" GridLines="Horizontal" 
                          onrowcommand="SachGridview_RowCommand" AutoGenerateColumns="False" 
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
                                                  <asp:Image ID="HinhAnhimage" runat="server" Height="160px" Style="margin:5px" 
                                                      Width="120px" />
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
                                          <tr>
                                              <td>
                                                  &nbsp;</td>
                                              <td>
                                                  <asp:Button ID="ThemButton" runat="server" CommandName="Them" 
                                                      Text="Thêm vào phiếu phạt" 
                                                      CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' />
                                              </td>
                                          </tr>
                                          <tr>
                                              <td colspan="2">
                                                  <asp:Label ID="SachLabel" runat="server" ForeColor="Red" 
                                                      Style="text-align:center" Width="590px"></asp:Label>
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
              <tr>
                  <td bgcolor="#999999">
                      <asp:Label ID="Label3" runat="server" Font-Bold="True" ForeColor="White" 
                          Height="23px" Text="  Phiếu thu"></asp:Label>
                  </td>
              </tr>
              <tr>
                  <td>
                      <asp:GridView ID="PhieuPhatGridview" runat="server" Width="600px" 
                          BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" 
                          CellPadding="4" ForeColor="Black" GridLines="Horizontal" 
                          AutoGenerateColumns="False" onrowcommand="PhieuPhatGridview_RowCommand" 
                          onrowcreated="PhieuPhatGridview_RowCreated" ShowHeader="False">
                          <Columns>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:Image ID="HinhanhImage" runat="server" Height="120px" Width="90px" 
                                          Style="padding:3px" />
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <table class="style1">
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label23" runat="server" Font-Bold="True" Text="Mã sách: " 
                                                      Width="100px"></asp:Label>
                                              </td>
                                              <td>
                                                  <asp:Label ID="MaSachLabel" runat="server" Text='<%# Eval("Masach") %>' 
                                                      Width="350px"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label24" runat="server" Font-Bold="True" Text="Tên sách: " 
                                                      Width="100px"></asp:Label>
                                              </td>
                                              <td>
                                                  <asp:Label ID="TenSachLabel" runat="server" Width="350px"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label26" runat="server" Font-Bold="True" Text="Số tiền phạt: " 
                                                      Width="100px"></asp:Label>
                                              </td>
                                              <td>
                                                  <asp:TextBox ID="SoTienPhatTextBox" runat="server" 
                                                      Text='<%# Eval("Sotienphat") %>'></asp:TextBox>
                                                  <asp:Label ID="Label29" runat="server" Text="vnđ"></asp:Label>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:Label ID="Label25" runat="server" Font-Bold="True" Text="Lý do phạt: " 
                                                      Width="100px"></asp:Label>
                                              </td>
                                              <td rowspan="2">
                                                  <asp:TextBox ID="LyDoPhatTextbox" runat="server" Height="50px" 
                                                      TextMode="MultiLine" Width="370px" Text='<%# Eval("Lydophat") %>'></asp:TextBox>
                                              </td>
                                          </tr>
                                          <tr>
                                              <td>
                                                  <asp:HiddenField ID="MaphieumuonHid" runat="server" 
                                                      Value='<%# Eval("Maphieumuon") %>' />
                                              </td>
                                          </tr>
                                      </table>
                                  </ItemTemplate>
                              </asp:TemplateField>
                              <asp:TemplateField>
                                  <ItemTemplate>
                                      <asp:ImageButton ID="Image1" runat="server" Height="25px" 
                                          ImageUrl="~/images/delete.jpg" Width="25px" 
                                          CommandArgument='<%# DataBinder.Eval(Container, "RowIndex") %>' 
                                          CommandName="xoa" />
                                  </ItemTemplate>
                                  <HeaderStyle Width="25px" />
                                  <ItemStyle Width="25px" />
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
                      </asp:GridView>
                  </td>
              </tr>
              <tr>
                  <td width="300">
                      <asp:Label ID="InphieuLabel" runat="server" ForeColor="Red" 
                          Style="text-align:center" Width="590px"></asp:Label>
                  </td>
              </tr>
          </table>
          </ContentTemplate>
          </asp:UpdatePanel> 

          <table  style="width:600px;margin-left:50px " bgcolor="#E8F2FF">
              <tr>
                  <td>
          <asp:Button ID="LuuPhieuThuButton" runat="server" 
                          onclick="LuuPhieuThuButton_Click" Style="margin-left:350px" 
                          Text="Lưu và In phiếu thu" Width="150px" />
                  </td>
              </tr>
          </table>
      </div>
		<div id="container_bottom"></div>
		</div> 
          <asp:Panel ID="BaoCaoPanel" runat="server" Visible="false">  
                <asp:Button ID="ThoatButton" runat="server" Text="X" Style="margin-left:705px" onclick="ThoatButton_Click" />
              <CR:CrystalReportViewer ID="InPhieuReport" runat="server" BestFitPage="False" ToolPanelView="None" />
           </asp:Panel>
	<div id="Footer">
	</div>
</div>
</form>
</body>
</html>