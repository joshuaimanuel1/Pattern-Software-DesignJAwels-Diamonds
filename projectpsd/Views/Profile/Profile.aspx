<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="projectpsd.Views.Profile.Profile" MasterPageFile="~/Master/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>User Profile</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Your Profile</h2>

    <div style="margin-top: 20px;">
        <h3>Profile Information</h3>
        <p><strong>Username:</strong> <asp:Label ID="lblUsername" runat="server"></asp:Label></p>
        <p><strong>Email:</strong> <asp:Label ID="lblEmail" runat="server"></asp:Label></p>
        <p><strong>Gender:</strong> <asp:Label ID="lblGender" runat="server"></asp:Label></p>
        <p><strong>Date of Birth:</strong> <asp:Label ID="lblDateOfBirth" runat="server"></asp:Label></p>
    </div>

    <div style="margin-top: 40px;">
        <h3>Change Password</h3>
        <div>
            <asp:Label ID="lblOldPassword" runat="server" Text="Old Password:"></asp:Label>
            <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvOldPassword" runat="server" ControlToValidate="txtOldPassword" ErrorMessage="Old Password must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
        </div>
        <div style="margin-top: 10px;">
            <asp:Label ID="lblNewPassword" runat="server" Text="New Password:"></asp:Label>
            <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvNewPassword" runat="server" ControlToValidate="txtNewPassword" ErrorMessage="New Password must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CustomValidator ID="cvNewPassword" runat="server" ControlToValidate="txtNewPassword" OnServerValidate="ValidateNewPassword" ErrorMessage="New Password must be alphanumeric and 8 to 25 characters." ForeColor="Red"></asp:CustomValidator>
        </div>
        <div style="margin-top: 10px;">
            <asp:Label ID="lblConfirmNewPassword" runat="server" Text="Confirm New Password:"></asp:Label>
            <asp:TextBox ID="txtConfirmNewPassword" runat="server" TextMode="Password"></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvConfirmNewPassword" runat="server" ControlToValidate="txtConfirmNewPassword" ErrorMessage="Confirm New Password must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
            <asp:CompareValidator ID="cvComparePassword" runat="server" ControlToValidate="txtConfirmNewPassword" ControlToCompare="txtNewPassword" Operator="Equal" ErrorMessage="Confirm Password must be the same with new password." ForeColor="Red"></asp:CompareValidator>
        </div>
        <div style="margin-top: 20px;">
            <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="BtnChangePassword_Click" />
        </div>
        <div style="margin-top: 10px;">
            <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        </div>
    </div>
</asp:Content>