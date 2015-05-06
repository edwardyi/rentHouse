<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="dynamicTable.aspx.vb" Inherits="WebApplication3.dynamicTable" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Your Name :
        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        <input id="btnGetTime" type="button" value="Show Current Time"
            onclick = "ShowCurrentTime()" />
        <br />
            
            <asp:Button ID="Button1" runat="server" Text="Button" />
        </div>
    </form>
    
</body>
<script src="http://localhost/app3/Scripts/jquery-1.11.2.min.js" type="text/javascript"></script>
<script type="text/javascript" src="http://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
<script type = "text/javascript">
 function ShowCurrentTime() {
    $.ajax({
        type: "POST",
        url: "dynamicTable.vb/GetCurrentTime",
        data: '{name: "' + $("#<%=txtUserName.ClientID%>")[0].value + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: OnSuccess,
        failure: function(response) {
            alert(response.d);
        }
    });

}
function OnSuccess(response) {
    alert(response.d);
}
</script>
</html>
