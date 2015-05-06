<%@ WebHandler Language="VB" Class="Handler" %>

Imports System
Imports System.Web
Imports System.Web.SessionState
Public Class Handler : Implements IHttpHandler,IReadOnlySessionState
    
    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        context.Response.ContentType = "text/plain"
        'Dim ID As String = context.Request.Form["ID"]
        'Dim middleName As String = context.Request.Form["MiddleName"]
        'Dim lastName As String = context.Session["LastName"].ToString()
        'Dim Name As String = ID + "" + middleName + "" + lastName
        'context.Response.Write(Name)
        context.Response.Write("Hello World")
    End Sub
 
    Public ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class