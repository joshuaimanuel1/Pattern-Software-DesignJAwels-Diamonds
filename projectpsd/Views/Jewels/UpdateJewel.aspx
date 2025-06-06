<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UpdateJewel.aspx.cs" Inherits="projectpsd.Views.Jewels.UpdateJewel" MasterPageFile="~/Master/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Update Jewel</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Update Jewel</h2>

    <div style="margin-top: 20px;">
        <asp:Panel ID="pnlJewelForm" runat="server" Visible="false">
            <asp:HiddenField ID="hfJewelId" runat="server" />
            <div>
                <asp:Label ID="lblJewelName" runat="server" Text="Jewel Name:"></asp:Label>
                <asp:TextBox ID="txtJewelName" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvJewelName" runat="server" ControlToValidate="txtJewelName" ErrorMessage="Jewel Name must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvJewelNameLength" runat="server" ControlToValidate="txtJewelName" OnServerValidate="ValidateJewelNameLength" ErrorMessage="Jewel Name must be between 3 to 25 characters (inclusive)." ForeColor="Red"></asp:CustomValidator>
            </div>
            <div style="margin-top: 10px;">
                <asp:Label ID="lblCategory" runat="server" Text="Category:"></asp:Label>
                <asp:DropDownList ID="ddlCategory" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory" InitialValue="" ErrorMessage="Category must be selected." ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div style="margin-top: 10px;">
                <asp:Label ID="lblBrand" runat="server" Text="Brand:"></asp:Label>
                <asp:DropDownList ID="ddlBrand" runat="server"></asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvBrand" runat="server" ControlToValidate="ddlBrand" InitialValue="" ErrorMessage="Brand must be selected." ForeColor="Red"></asp:RequiredFieldValidator>
            </div>
            <div style="margin-top: 10px;">
                <asp:Label ID="lblPrice" runat="server" Text="Price:"></asp:Label>
                <asp:TextBox ID="txtPrice" runat="server" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvPrice" runat="server" ControlToValidate="txtPrice" ErrorMessage="Price must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:RangeValidator ID="rvPrice" runat="server" ControlToValidate="txtPrice" Type="Integer" MinimumValue="26" MaximumValue="999999999" ErrorMessage="Price must be a number and more than $25." ForeColor="Red"></asp:RangeValidator>
            </div>
            <div style="margin-top: 10px;">
                <asp:Label ID="lblReleaseYear" runat="server" Text="Release Year:"></asp:Label>
                <asp:TextBox ID="txtReleaseYear" runat="server" TextMode="Number"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfvReleaseYear" runat="server" ControlToValidate="txtReleaseYear" ErrorMessage="Release Year must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
                <asp:CustomValidator ID="cvReleaseYearValid" runat="server" ControlToValidate="txtReleaseYear" OnServerValidate="ValidateReleaseYear" ErrorMessage="Release Year must be a number and less than 2025." ForeColor="Red"></asp:CustomValidator>
            </div>
            <div style="margin-top: 20px;">
                <asp:Button ID="btnUpdateJewel" runat="server" Text="Update Jewel" OnClick="BtnUpdateJewel_Click" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" OnClick="BtnCancel_Click" CausesValidation="false" />
            </div>
        </asp:Panel>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
    </div>
</asp:Content>