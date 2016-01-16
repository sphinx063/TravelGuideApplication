<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffLogin.aspx.cs" Inherits="TravelWithMe.StaffLogin" %>

<%@ Register src="HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body bgcolor="#E0E8F0">
    <form id="form1" runat="server">
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
        <p>
            Staff Login Page</p>
        <p>
            User name :
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        </p>
        <p>
            Pasword&nbsp;&nbsp;&nbsp; :
            <asp:TextBox ID="TextBox2" TextMode="password" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Login" OnClick="Button1_Click" />
&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="msg" runat="server" ForeColor="#CC3300"></asp:Label>
        </p>
    </form>
</body>
</html>
