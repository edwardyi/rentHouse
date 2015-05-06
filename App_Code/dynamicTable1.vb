Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class dynamicTable1
     Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld(ByVal name As String) As String
        Return "Hello World" & name & " TT"
    End Function

End Class
