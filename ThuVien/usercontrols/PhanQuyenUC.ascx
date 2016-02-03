<%@ Control Language="C#" AutoEventWireup="true" CodeFile="PhanQuyenUC.ascx.cs" Inherits="usercontrols_PhanQuyenUC" %>
<asp:ListView ID="PhanQuyenListView" runat="server" EnableModelValidation="True">
        <LayoutTemplate>        	
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
        </LayoutTemplate>
        <ItemTemplate>
                 
				<div class="box_head"> <asp:Label ID="Label1" runat="server" Text='<%# Eval("TenQuyen") %>' /></div>
				<div class="box_content">   
                 <%--chi tiết phân quyền--%>              
                        <asp:ListView ID="TheLoaiSachListView" runat="server" EnableModelValidation="True" DataSource='<%# Eval("ChiTietQuyen") %>'>
                        <LayoutTemplate>
                        <ul>
                            <asp:PlaceHolder ID="itemPlaceholder" runat="server"/>
                        </ul>
                        </LayoutTemplate>
                        <ItemTemplate>
                        <li>
                        <p>
                            <asp:HyperLink ID="CategoryList" runat="server" NavigateUrl='<%#Eval("LienKet").ToString() %>'>
                            <asp:Label ID="LinkButton2" runat="server" Text='<%# Eval("TenCTQuyen ") %>' />
                            </asp:HyperLink>
                        </p>
                        </li>
                        </ItemTemplate>
                         </asp:ListView>  
                  <%--   --  --%>
				</div>
				<div class="box_bottom"></div>  
             
        </ItemTemplate>
</asp:ListView>