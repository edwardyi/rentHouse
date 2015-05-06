<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dynamicTable.aspx.vb" Inherits="WebApplication3.dynamicTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="true">
        </asp:ScriptManager>
        Your Name :
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <input id="btnGetTime" type="button" value="Show Current Time"
            onclick = "ShowCurrentTime()" />
        <br />
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <asp:Label ID="lblTime" runat="server" ></asp:Label>
                <asp:Button ID="btnTime" runat="server" Text="JS取時間" />
            </ContentTemplate>
        </asp:UpdatePanel>
           
    </div>
    </form>
    
</body>
<script type="text/javascript">
    window.onload = function() {
        DisplayCurrentTime();
    }
    //當更新面板重整時
    //On UpdatePanel Refresh
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    if (prm != null) {
        prm.add_endRequest(function(sender, e) {
            if (sender._postBackSettings.panelsToUpdate != null) {
                DisplayCurrentTime();
            }
        });
    };
    /*
    var prm = Sys.WebForms.PageRequestManager.getInstance();
    if (prm != null) {
        prm.add_endRequest(function(sender, e) {
            if (sender._postBackSettings.panelsToUpdate != null) {
                DisplayCurrentTime();
            }
        });
    }*/
    function DisplayCurrentTime() {
        var date = new Date();
        var hours = date.getHours() < 10 ? "0" + date.getHours() : date.getHours();
        var minutes = date.getMinutes() < 10 ? "0" + date.getMinutes() : date.getMinutes();
        var seconds = date.getSeconds() < 10 ? "0" + date.getSeconds() : date.getSeconds();
        time = hours + ":" + minutes + ":" + seconds;
        var lblTime = document.getElementById("<%=lblTime.ClientID %>");
        lblTime.innerHTML = time;
    }

function ShowCurrentTime() {
    //debugger;
    PageMethods.GetCurrentTime(document.getElementById("<%=txtUserName.ClientID%>").value, OnSuccess);
}
function OnSuccess(response,userControl,methodName) {
    alert(response);
}
</script>
</html>
