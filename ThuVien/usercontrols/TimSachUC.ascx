<%@ Control Language="C#" AutoEventWireup="true" CodeFile="TimSachUC.ascx.cs" Inherits="usercontrols_TimSachUC" %>
	<div class="box">
				<div class="box_head">Tìm sách</div>
				<div class="box_content" style="height:25px">
                    <asp:TextBox ID="TimSachTextBox" runat="server" Width="150" Style="margin-left:10px"></asp:TextBox>
                    <asp:Button ID="TimButton" runat="server" Text="Tìm" Width="40px" 
                        Style="marin-left:10px" onclick="TimButton_Click" />
				</div>
				<div class="box_bottom"></div>
			</div>
