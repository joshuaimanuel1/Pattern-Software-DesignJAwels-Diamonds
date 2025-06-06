<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="projectpsd.Views.Cart.Cart" MasterPageFile="~/Master/MasterPage.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Your Shopping Cart</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h2>Your Shopping Cart</h2>

    <div style="margin-top: 20px;">
        <asp:Panel ID="pnlCartContent" runat="server" Visible="false">
            <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="false" CssClass="gvStyle"
                OnRowCommand="GvCart_RowCommand" DataKeyNames="UserID,JewelID"
                CellPadding="4" CellSpacing="1">
                <Columns>
                    <asp:BoundField DataField="MsJewel.JewelID" HeaderText="Jewel ID" />
                    <asp:BoundField DataField="MsJewel.JewelName" HeaderText="Jewel Name" />
                    <asp:BoundField DataField="MsJewel.MsBrand.BrandName" HeaderText="Brand" />
                    <asp:BoundField DataField="MsJewel.JewelPrice" HeaderText="Price" DataFormatString="{0:C}" />
                    <asp:TemplateField HeaderText="Quantity">
                        <ItemTemplate>
                            <asp:TextBox ID="txtQuantity" runat="server" Text='<%# Eval("Quantity") %>' Width="50px" TextMode="Number"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvQuantity" runat="server" ControlToValidate="txtQuantity" ErrorMessage="*" ForeColor="Red" Display="Dynamic"></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="rvQuantity" runat="server" ControlToValidate="txtQuantity" Type="Integer" MinimumValue="1" MaximumValue="999" ErrorMessage="Qty > 0" ForeColor="Red" Display="Dynamic"></asp:RangeValidator>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Subtotal">
                        <ItemTemplate>
                            <asp:Label ID="lblSubtotal" runat="server" Text='<%# ((int)Eval("Quantity") * (int)Eval("MsJewel.JewelPrice")).ToString("C") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Actions">
                        <ItemTemplate>
                            <asp:LinkButton ID="btnUpdate" runat="server" CommandName="UpdateItem" CommandArgument='<%# Eval("JewelID") %>' Text="Update"></asp:LinkButton>
                            <asp:LinkButton ID="btnRemove" runat="server" CommandName="RemoveItem" CommandArgument='<%# Eval("JewelID") %>' Text="Remove" OnClientClick="return confirm('Are you sure you want to remove this item?');"></asp:LinkButton>
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    Your cart is empty.
                </EmptyDataTemplate>
                <HeaderStyle BackColor="#333" ForeColor="White" Font-Bold="True" HorizontalAlign="Left" />
                <RowStyle BackColor="#f2f2f2" />
                <AlternatingRowStyle BackColor="White" />
            </asp:GridView>

            <div style="margin-top: 20px; text-align: right;">
                <strong>Total Price:</strong> <asp:Label ID="lblTotalPrice" runat="server" Text="0.00"></asp:Label><br /><br />

                <asp:Label ID="lblPaymentMethod" runat="server" Text="Payment Method:"></asp:Label>
                <asp:DropDownList ID="ddlPaymentMethod" runat="server">
                    <asp:ListItem Text="-- Select Payment Method --" Value=""></asp:ListItem>
                    <asp:ListItem Text="Credit Card" Value="Credit Card"></asp:ListItem>
                    <asp:ListItem Text="Bank Transfer" Value="Bank Transfer"></asp:ListItem>
                    <asp:ListItem Text="E-Wallet" Value="E-Wallet"></asp:ListItem>
                </asp:DropDownList>
                <asp:RequiredFieldValidator ID="rfvPaymentMethod" runat="server" ControlToValidate="ddlPaymentMethod" InitialValue="" ErrorMessage="Payment method must be selected." ForeColor="Red"></asp:RequiredFieldValidator>
                <br /><br />

                <asp:Button ID="btnClearCart" runat="server" Text="Clear Cart" OnClick="BtnClearCart_Click" OnClientClick="return confirm('Are you sure you want to clear your entire cart?');" CausesValidation="false" />
                <asp:Button ID="btnCheckout" runat="server" Text="Checkout" OnClick="BtnCheckout_Click" />
            </div>
        </asp:Panel>
        <asp:Label ID="lblMessage" runat="server" Text="" ForeColor="Red"></asp:Label>
    </div>
</asp:Content>