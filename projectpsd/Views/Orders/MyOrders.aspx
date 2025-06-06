<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="projectpsd.Views.Orders.MyOrders" MasterPageFile="~/Master/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>My Orders History</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>My Orders History</h2>

    <div style="margin-top: 20px;">
        <asp:GridView ID="gvOrders" runat="server" AutoGenerateColumns="false" CssClass="gvStyle"
            OnRowCommand="GvOrders_RowCommand" DataKeyNames="TransactionID"
            CellPadding="4" CellSpacing="1">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                <asp:BoundField DataField="TransactionDate" HeaderText="Date" DataFormatString="{0:MM/dd/yyyy hh:mm:ss tt}" /> 
                <asp:BoundField DataField="PaymentMethod" HeaderText="Payment" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnViewDetails" runat="server" CommandName="ViewDetails" CommandArgument='<%# Eval("TransactionID") %>' Text="View Details"></asp:LinkButton>
                        
                        <asp:Panel ID="pnlPackageActions" runat="server">
                            <asp:LinkButton ID="btnConfirmPackage" runat="server" CommandName="ConfirmPackage" CommandArgument='<%# Eval("TransactionID") %>' Text="Confirm Package" OnClientClick="return confirm('Are you sure you want to confirm package receipt?');"></asp:LinkButton>
                            <asp:LinkButton ID="btnRejectPackage" runat="server" CommandName="RejectPackage" CommandArgument='<%# Eval("TransactionID") %>' Text="Reject Package" OnClientClick="return confirm('Are you sure you want to reject this package?');"></asp:LinkButton>
                        </asp:Panel>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No order history available.
            </EmptyDataTemplate>
            <HeaderStyle BackColor="#333" ForeColor="White" Font-Bold="True" HorizontalAlign="Left" />
            <RowStyle BackColor="#f2f2f2" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
    </div>
</asp:Content>