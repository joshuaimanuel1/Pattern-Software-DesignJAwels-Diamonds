<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="JewelDetail.aspx.cs" Inherits="projectpsd.Views.Jewels.JewelDetail" MasterPageFile="~/Master/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Jewel Details</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Jewel Details</h2>

    <div style="margin-top: 20px;">
        <asp:Panel ID="pnlJewelDetails" runat="server" Visible="false">
            <p><strong>Jewel Name:</strong> <asp:Label ID="lblJewelName" runat="server"></asp:Label></p>
            <p><strong>Category:</strong> <asp:Label ID="lblCategoryName" runat="server"></asp:Label></p>
            <p><strong>Brand:</strong> <asp:Label ID="lblBrandName" runat="server"></asp:Label></p>
            <p><strong>Country of Origin:</strong> <asp:Label ID="lblCountryOfOrigin" runat="server"></asp:Label></p>
            <p><strong>Class:</strong> <asp:Label ID="lblBrandClass" runat="server"></asp:Label></p>
            <p><strong>Price:</strong> <asp:Label ID="lblPrice" runat="server"></asp:Label></p>
            <p><strong>Release Year:</strong> <asp:Label ID="lblReleaseYear" runat="server"></asp:Label></p>

            <div style="margin-top: 20px;">
                <asp:Panel ID="pnlCustomerActions" runat="server" Visible="false">
                    <asp:Label ID="lblQuantity" runat="server" Text="Quantity:"></asp:Label>
                    <asp:TextBox ID="txtQuantity" runat="server" Text="1" TextMode="Number"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity" ErrorMessage="Quantity must be filled." ForeColor="Red"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvQuantity" runat="server" ControlToValidate="txtQuantity" Type="Integer" MinimumValue="1" MaximumValue="999" ErrorMessage="Quantity must be a positive number." ForeColor="Red"></asp:RangeValidator>
                    <br /><br />
                    <asp:Button ID="btnAddtoCart" runat="server" Text="Add to Cart" OnClick="BtnAddtoCart_Click" />
                </asp:Panel>

                <asp:Panel ID="pnlAdminActions" runat="server" Visible="false">
                    <asp:Button ID="btnEditJewel" runat="server" Text="Edit Jewel" OnClick="BtnEditJewel_Click" />
                    <asp:Button ID="btnDeleteJewel" runat="server" Text="Delete Jewel" OnClick="BtnDeleteJewel_Click" OnClientClick="return confirm('Are you sure you want to delete this jewel?');" /> <%-- DIUBAH --%>
                </asp:Panel>
            </div
        </asp:Panel>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
        <asp:Label ID="lblSuccessMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
    </div>
</asp:Content>