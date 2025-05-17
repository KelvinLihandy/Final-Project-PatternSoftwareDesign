<%@ Page Title="Cart" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="FinalProjectPSD.View.Cart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 40px">
        <h2 style= "margin-top: 60px">Shopping Cart</h2>
        <asp:GridView ID="CartGridView" runat="server" AutoGenerateColumns="false" 
            CssClass="table" OnRowCommand="CartGridView_RowCommand">
            <Columns>
                <asp:BoundField DataField="Id" HeaderText="Id" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:BoundField DataField="Brand" HeaderText="Brand" />
                <asp:TemplateField HeaderText="Quantity">
                    <ItemTemplate>
                        <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Eval("Quantity") %>' 
                            Width="50px"></asp:TextBox>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="UpdateButton" runat="server" Text="Update" 
                            CommandName="UpdateItem" CommandArgument='<%# Eval("Id") %>' 
                            CssClass="btn-update" />
                        <asp:Button ID="RemoveButton" runat="server" Text="Remove" 
                            CommandName="RemoveItem" CommandArgument='<%# Eval("Id") %>' 
                            CssClass="btn-remove" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <EmptyDataTemplate>
                <div>Your cart is empty.</div>
            </EmptyDataTemplate>
        </asp:GridView>
        
        <div style="margin-top: 20px; display: flex; justify-content: space-between; align-items: center;">
            <div style="text-align: left;">
                <div style="font-weight: bold; font-size: 16px; margin-bottom: 10px;">
                    Total: <asp:Label ID="TotalLabel" runat="server" Font-Bold="true"></asp:Label>
                </div>
                <div style="margin-top: 10px;">
                    <asp:DropDownList ID="PaymentMethodDropDown" runat="server" Width="200px">
                        <asp:ListItem Text="Credit Card" Value="CreditCard" />
                        <asp:ListItem Text="Visa" Value="PayPal" />
                        <asp:ListItem Text="Bank Transfer" Value="BankTransfer" />
                        <asp:ListItem Text="E-Wallet" Value="COD" />
                    </asp:DropDownList>
                </div>
            </div>
            <div style="text-align: right; display: flex; gap: 15px; justify-content: flex-end;">
                <asp:Button ID="ContinueShoppingButton" runat="server" Text="Clear Cart" 
                    OnClick="ContinueShoppingButton_Click" 
                    Style="background-color: #444444; color: white; padding: 8px 15px; border: none; border-radius: 4px; cursor: pointer;" />
                <asp:Button ID="CheckoutButton" runat="server" Text="Proceed to Checkout" 
                    OnClick="CheckoutButton_Click" 
                    Style="background-color: #007bff; color: white; padding: 8px 15px; border: none; border-radius: 4px; cursor: pointer;" />
            </div>
        </div>
    </div>

    <style>
        table {
            width: 100%;
            border-collapse: collapse;
            margin-top: 20px;
        }
        th, td {
            padding: 8px;
            text-align: left;
            border-bottom: 1px solid #ddd;
        }
        th {
            background-color: #f2f2f2;
            font-weight: bold;
        }
        .btn-update {
            background-color: #4CAF50; /* Green */
            color: white;
            padding: 5px 10px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
            margin-right: 5px;
        }
        .btn-remove {
            background-color: #f44336; /* Red */
            color: white;
            padding: 5px 10px;
            border: none;
            border-radius: 3px;
            cursor: pointer;
        }
    </style>
</asp:Content>