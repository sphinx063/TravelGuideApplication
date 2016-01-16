<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="StaffSignUp.aspx.cs" Inherits="TravelWithMe.StaffSignUp" %>

<%@ Register src="HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:Label ID="staffun" runat="server" ForeColor="#CC3300"></asp:Label>
        <br />
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
        <p>
            Staff Registration<br />
        </p>
        User name&nbsp;&nbsp;
        <asp:TextBox ID="un" runat="server"></asp:TextBox>
        <p>
            Password&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="pwd" Textmode="password" runat="server" OnTextChanged="pwd_TextChanged"></asp:TextBox>
        </p>
        <p>
            Confirm&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="cnf" Textmode="password" runat="server"></asp:TextBox>
        </p>
        <p>
            Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" Text="Register" OnClick="Button1_Click" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="msg" runat="server" ForeColor="Red"></asp:Label>
        </p>
    </form>
</body>
</html>
