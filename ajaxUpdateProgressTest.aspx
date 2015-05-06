<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="ajaxUpdateProgressTest.aspx.vb" Inherits="WebApplication3.ajaxUpdateProgressTest" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title></title>
    <style type="text/css">
        body
        {
            margin:0;
            padding:0;
            font-family:Arial;
            
        }
       .model
       {
          position: fixed;
          z-index: 999;
          height: 100%;
          width: 100%;
          top: 0;
          background-color: Black;
          filter: alpha(opacity=60);
          opacity: 0.6; /*在chrome裡有作用*/
          -moz-opacity: 0.9;
       }
       .center
       {
          z-index: 1000;
          margin: 300px auto;
          padding: 130px;
          background-color: white;
          border-radius: 10px;
          opacity: 1;
          -moz-opacity: 1;
       }
       .center img
       {
          height: 128px;
          width: 128px;
       }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        <asp:UpdateProgress ID="UpdateProgress1" runat="server">
            <ProgressTemplate>
               <div class="model">
                    <div class="center">
                        更新中請稍候
                        <img alt="更新中請稍候" src="Images/loader.gif" />
                    </div>
                </div>
            </ProgressTemplate>
        </asp:UpdateProgress>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div style="text-align:center">
                    <h1>
                        <asp:Button ID="Button1" Text="更新" runat="server" />
                    </h1>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
