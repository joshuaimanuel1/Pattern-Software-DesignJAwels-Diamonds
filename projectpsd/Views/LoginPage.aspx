<%-- Views/LoginPage.aspx --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginPage.aspx.cs" Inherits="projectpsd.Views.LoginPage" MasterPageFile="~/Master/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Login</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Login to JAwels & Diamonds</h2>
    <div style="margin-top: 20px;">
        <div>
            <asp:Label ID="lblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                ErrorMessage="Email must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div style="margin-top: 10px;">
            <asp:Label ID="lblPassword" runat="server" Text="Password:"></asp:Label>
            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtPassword"
                ErrorMessage="Password must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div style="margin-top: 10px;">
            <asp:CheckBox ID="chkRememberMe" runat="server" Text="Remember Me" />
        </div>
        <div style="margin-top: 20px;">
            <asp:Button ID="btnLoginCustomer" runat="server" Text="Login as Customer" OnClick="BtnLogin_Click" />
                
            <asp:Button ID="btnLoginAdmin" runat="server" Text="Login as Admin" OnClick="BtnLoginAdmin_Click" />
        </div>
        <div style="margin-top: 10px;">
            <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>