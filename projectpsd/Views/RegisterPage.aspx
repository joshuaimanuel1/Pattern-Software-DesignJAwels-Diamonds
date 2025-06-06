<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RegisterPage.aspx.cs" Inherits="projectpsd.Views.RegisterPage" MasterPageFile="~/Master/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Register</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Register as a New Customer</h2>
    <div style="margin-top: 20px;">
        <div>
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                ErrorMessage="Email must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div style="margin-top: 10px;">
            <asp:Label ID="lblUsername" runat="server" Text="Username:"></asp:Label>
            <asp:TextBox ID="txtUsername" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtUsername"
                ErrorMessage="Username must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div style="margin-top: 10px;">
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                ErrorMessage="Password must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div style="margin-top: 10px;">
            <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm Password:"></asp:Label>
            <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvConfirmPassword" runat="server" ControlToValidate="txtConfirmPassword"
                ErrorMessage="Confirm Password must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div style="margin-top: 10px;">
            <asp:Label ID="lblGender" runat="server" Text="Gender:"></asp:Label>
            <asp:RadioButtonList ID="rblGender" runat="server" RepeatDirection="Horizontal">
                <asp:ListItem Text="Male" Value="Male"></asp:ListItem>
                <asp:ListItem Text="Female" Value="Female"></asp:ListItem>
            </asp:RadioButtonList>
            <asp:RequiredFieldValidator ID="rfvGender" runat="server" ControlToValidate="rblGender"
                ErrorMessage="Gender must be chosen." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div style="margin-top: 10px;">
            <asp:Label ID="lblDateOfBirth" runat="server" Text="Date of Birth:"></asp:Label>
            <asp:TextBox ID="txtDateOfBirth" runat="server" TextMode="Date"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvDateOfBirth" runat="server" ControlToValidate="txtDateOfBirth"
                ErrorMessage="Date of Birth must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div style="margin-top: 20px;">
            <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="BtnRegister_Click" />
        </div>
        <div style="margin-top: 10px;">
            <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>