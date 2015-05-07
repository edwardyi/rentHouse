Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols

' 若要允許使用 ASP.NET AJAX 從指令碼呼叫此 Web 服務，請取消註解下一行。
' <System.Web.Script.Services.ScriptService()> _
<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class dynamicTable
     Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function HelloWorld() As String
        Return "Hello World"
    End Function

    <WebMethod()> _
    Public Function GetCurrentTime(ByVal name As String) As String
        Return "Hello " & name & Environment.NewLine & "The Current Time is: " & DateTime.Now.ToString()
    End Function
    <WebMethod()> _
    Public Function Test() As String
        Return "123"
    End Function
    <WebMethod()> Public Function Add(ByVal a As Integer, ByVal b As Integer) As Integer
        Return (a + b)
    End Function

    <WebMethod()> Public Function Subtract(ByVal A As System.Single, ByVal B As System.Single) As System.Single
        Return A - B
    End Function

    <WebMethod()> Public Function Multiply(ByVal A As System.Single, ByVal B As System.Single) As System.Single
        Return A * B
    End Function

    <WebMethod()> Public Function Divide(ByVal A As System.Single, ByVal B As System.Single) As System.Single
        If B = 0 Then
            Return -1
        End If
        Return Convert.ToSingle(A / B)
    End Function

End Class
