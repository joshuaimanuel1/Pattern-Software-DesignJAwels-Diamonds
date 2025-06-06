<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="projectpsd.Views.Orders.TransactionDetail" MasterPageFile="~/Master/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Transaction Details</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Transaction Details</h2>

    <div style="margin-top: 20px;">
        <asp:Panel ID="pnlTransactionDetails" runat="server" Visible="false">
            <p><strong>Transaction ID:</strong> <asp:Label ID="lblTransactionId" runat="server"></asp:Label></p>
            <p><strong>Transaction Date:</strong> <asp:Label ID="lblTransactionDate" runat="server"></asp:Label></p>
            <p><strong>Payment Method:</strong> <asp:Label ID="lblPaymentMethod" runat="server"></asp:Label></p>
            <p><strong>Status:</strong> <asp:Label ID="lblStatus" runat="server"></asp:Label></p>
            
            <h3>Items in this Transaction:</h3>
            <asp:GridView ID="gvTransactionItems" runat="server" AutoGenerateColumns="false" CssClass="gvStyle"
                CellPadding="4" CellSpacing="1">
                <Columns>
                    <asp:BoundField DataField="MsJewel.JewelName" HeaderText="Jewel Name" />
                    <asp:BoundField DataField="Quantity" HeaderText="Quantity" /
                </Columns>
                <EmptyDataTemplate>
                    No items found for this transaction.
                </EmptyDataTemplate>
                <HeaderStyle BackColor="#333" ForeColor="White" Font-Bold="True" HorizontalAlign="Left" />
                <RowStyle BackColor="#f2f2f2" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>
        </asp:Panel>
        <asp:Label ID="lblErrorMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>