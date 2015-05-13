<%@ Control Language="VB" AutoEventWireup="false" CodeFile="RentForm2.ascx.vb" Inherits="Controls_RentForm2" %>
<asp:Label ID="lbl_WorkId" runat="server" Text="工號"></asp:Label>
<asp:TextBox ID="workId" runat="server"></asp:TextBox>
<!--如果輸入空白字元則會發生錯誤 -->
<asp:RequiredFieldValidator ID="workIdCheckEmpty" runat="server" ControlToValidate="workId"
    ErrorMessage="工號不能為空" Display="Dynamic"></asp:RequiredFieldValidator>
<asp:RangeValidator ID="workIdCheck" runat="server" ControlToValidate="workId" ErrorMessage="工號需要為數字"
    Type="Integer" MinimumValue="0" MaximumValue="80000000" Display="Dynamic"></asp:RangeValidator>
<br />
<asp:Label ID="lbl_start" runat="server" Text="開始租屋"></asp:Label>
<asp:TextBox ID="startDate" runat="server"></asp:TextBox><br />
<asp:Label ID="lbl_end" runat="server" Text="結束租屋"></asp:Label>
<asp:TextBox ID="endDate" runat="server"></asp:TextBox><br />
<asp:Button ID="newRenter" runat="server" Text="新增" />
<asp:Button ID="btn_Submit" runat="server" Text="計算" Visible="false" />