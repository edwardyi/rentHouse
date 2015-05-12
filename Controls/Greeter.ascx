<%@ Control Language="VB" AutoEventWireup="false" CodeFile="Greeter.ascx.vb" Inherits="Controls_Greeter" %>
<%-- Server-side code. --%>

<script runat="server">
  Private _greeterName As String = Nothing

  Public ReadOnly Property GreeterName As String
    Get
      If _greeterName Is Nothing Then
        _greeterName = "Greeter_" + Guid.NewGuid.ToString("N")
      End If
      Return _greeterName
    End Get
  End Property
</script>

<%-- JavaScript. --%>

<script type="text/javascript">
  window["<%= Me.GreeterName %>"] = function () {
    var messageId = "<%= divMessage.ClientID %>";
    var messageElement = document.getElementById(messageId);
    messageElement.style.display = "block";
  };
</script>

<%-- Markup. --%>
<div runat="server" id="divMessage" style="display: none;">
    Hello
</div>