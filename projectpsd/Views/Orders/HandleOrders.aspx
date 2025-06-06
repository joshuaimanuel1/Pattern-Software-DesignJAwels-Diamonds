<%-- Views/Orders/HandleOrders.aspx --%>
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HandleOrders.aspx.cs" Inherits="projectpsd.Views.Orders.HandleOrders" MasterPageFile="~/Master/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Handle Orders (Admin)</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Handle Customer Orders</h2>

    <div style="margin-top: 20px;">
        <asp:GridView ID="gvUnfinishedOrders" runat="server" AutoGenerateColumns="false" CssClass="gvStyle"
            OnRowCommand="GvUnfinishedOrders_RowCommand" OnRowDataBound="GvUnfinishedOrders_RowDataBound"
            DataKeyNames="TransactionID" CellPadding="4" CellSpacing="1">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                <asp:BoundField DataField="UserID" HeaderText="User ID" />
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:LinkButton ID="btnConfirmPayment" runat="server" CommandName="ConfirmPayment" CommandArgument='<%# Eval("TransactionID") %>' Text="Confirm Payment" Visible="false"></asp:LinkButton>
                        <asp:LinkButton ID="btnShipPackage" runat="server" CommandName="ShipPackage" CommandArgument='<%# Eval("TransactionID") %>' Text="Ship Package" Visible="false"></asp:LinkButton>
                        <asp:Label ID="lblWaitingConfirm" runat="server" Text="Waiting for user confirmation..." Visible="false"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                No unfinished orders to handle.
            </EmptyDataTemplate>
            <HeaderStyle BackColor="#333" ForeColor="White" Font-Bold="True" HorizontalAlign="Left" />
            <RowStyle BackColor="#f2f2f2" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Green"></asp:Label>
    </div>
</asp:Content>