<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="projectpsd.Views.LoginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>
                <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
                <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
            </div>
            <div>
                <asp:CheckBox ID="RememberCheckBox" runat="server" Text="Remember Me" />
            </div>
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
            <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
            <asp:Label ID="ErrorLabel" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
