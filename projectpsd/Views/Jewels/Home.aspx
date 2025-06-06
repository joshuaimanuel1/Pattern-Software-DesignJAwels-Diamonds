<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="projectpsd.Views.Jewels.Home" MasterPageFile="~/Master/MasterPage.master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Home - JAwels & Diamonds</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Welcome to JAwels & Diamonds</h2>

<div style="margin-top: 20px;">
    <h3>Our Collection</h3>
    <asp:GridView ID="gvJewels" runat="server" AutoGenerateColumns="false" CssClass="gvStyle"
        OnRowCommand="GvJewels_RowCommand" DataKeyNames="JewelID"
        CellPadding="4" CellSpacing="1">
        <Columns>
            <asp:BoundField DataField="JewelID" HeaderText="Jewel ID" />
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
            <asp:BoundField DataField="JewelPrice" HeaderText="Price" DataFormatString="{0:C}" />
            <asp:TemplateField HeaderText="Actions">
                <ItemTemplate>
                    <asp:LinkButton ID="btnViewDetails" runat="server" CommandName="ViewDetails" CommandArgument='<%# Eval("JewelID") %>' Text="View Details"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <EmptyDataTemplate>
            No jewels available.
        </EmptyDataTemplate>
        <HeaderStyle BackColor="#333" ForeColor="White" Font-Bold="True" HorizontalAlign="Left" /> 
        <RowStyle BackColor="#f2f2f2" />
        <AlternatingRowStyle BackColor="White" />
    </asp:GridView>
</div>
</asp:Content>