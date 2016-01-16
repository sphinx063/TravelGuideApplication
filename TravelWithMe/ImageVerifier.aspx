<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ImageVerifier.aspx.cs" Inherits="TravelWithMe.ImageVerifier" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Image ID="Image1" runat="server" />
        <br/>
        <asp:Button ID="Button1" runat="server" Text="Verify" OnClick="Button1_Click" />
        
        <asp:Label ID="Label1" runat="server"></asp:Label>
        
    </form>
</body>
</html>
