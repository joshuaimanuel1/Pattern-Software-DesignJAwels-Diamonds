<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="projectpsd.Views.RegisterPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Label ID="EmailLabel" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="EmailTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="UsernameLabel" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="UsernameTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="PasswordLabel" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="PasswordTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="ConfirmPasswordLabel" runat="server" Text="Confirm Label"></asp:Label>
            <asp:TextBox ID="ConfirmPasswordTextBox" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="GenderLabel" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButtonList ID="GenderRadioButtonList" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList>
        </div>
        <div>
            <asp:Label ID="DOBLabel" runat="server" Text="Date of Birth"></asp:Label>
            <asp:TextBox ID="DOBTextBox" runat="server" TextMode="Date"></asp:TextBox>
        </div>
        <div>
            <asp:Button ID="RegisterButton" runat="server" Text="Register" OnClick="RegisterButton_Click" />
            <asp:Button ID="LoginButton" runat="server" Text="Login" OnClick="LoginButton_Click" />
        </div>
        <div>
            <asp:Label ID="ValidationLabel" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
