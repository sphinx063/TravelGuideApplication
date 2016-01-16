<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AdminLogin.aspx.cs" Inherits="TravelWithMe.AdminLogin" %>

<%@ Register src="HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#E0E8F0">
    <form id="form1" runat="server">
    <div>
    
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
    
    </div>
        <p>
            Enter Admin details</p>
        <p>
            User name :
            <asp:TextBox ID="TextBox1" runat="server" Width="235px"></asp:TextBox>
        </p>
        <p>
            Password&nbsp; :
            <asp:TextBox ID="TextBox2" TextMode="password" runat="server" Width="234px"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Login" />
&nbsp;&nbsp;
            <asp:Label ID="Label1" runat="server" ForeColor="#CC3300"></asp:Label>
        </p>
    </form>
</body>
</html>
