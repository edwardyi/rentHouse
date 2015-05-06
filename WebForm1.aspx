<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="WebForm1.aspx.vb" Inherits="WebApplication3.WebForm1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>ASP.NET Ajax</title>
    <script type="text/javascript">
    
      function pageLoad() {
      }
      function callService(f) {
          WebService.sayHello(
            f.elements['name'].value,
            callComplete,
            callError
          );
      }
      function callComplete(result) {
          window.alert(result);
      }
      function callError(result) {
          window.alert(result);
      }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager2" runat="server">
        <Services>
            <asp:ServiceReference Path="WebService1.asmx" />
        </Services>
        </asp:ScriptManager>
        
        <input id="Text1" type="text" name="name" />
        <input id="Button1" type="button" value="按我" onclick="callService(this.form)" />
    </div>
    </form>
</body>
</html>
