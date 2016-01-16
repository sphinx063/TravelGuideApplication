<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberRegistration.aspx.cs" Inherits="TravelWithMe.MemberRegistration" %>

<%@ Register src="HeaderUserControl.ascx" tagname="HeaderUserControl" tagprefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:HeaderUserControl ID="HeaderUserControl1" runat="server" />
    
    </div>
        <p>
            Enter Details [Members Registration]</p>
        <p>
            User Name :&nbsp;&nbsp;
            <asp:TextBox ID="un" runat="server"></asp:TextBox>
        </p>
        <p>
            Password&nbsp;&nbsp; :&nbsp;&nbsp;
            <asp:TextBox ID="pwd" TextMode="password" runat="server"></asp:TextBox>
        </p>
        <p>
            Confirm&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;
            <asp:TextBox ID="cnf" TextMode="password" runat="server"></asp:TextBox>
        </p>
        <p>
            Email&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; :&nbsp;&nbsp;
            <asp:TextBox ID="email" runat="server"></asp:TextBox>
        </p>
        <p>
            <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Submit" />
&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Label ID="msg" runat="server" ForeColor="#CC3300"></asp:Label>
        &nbsp;&nbsp;&nbsp; [You can login after redirected to login page on click of submit]</p>
    </form>
</body>
</html>
