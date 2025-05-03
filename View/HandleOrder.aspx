<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="HandleOrder.aspx.cs" Inherits="FinalProjectPSD.View.HandleOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; flex-direction: column; gap: 1vh; justify-content: center; align-items: center; height: 93vh; margin-top: 7vh; width: 100vw;">
        <asp:Label ID="handleOrderLabel" runat="server" Text="Handle Unfinished Orders" Style="font-size: 36px; padding-bottom: 2vh; align-self: center;"></asp:Label>
        <asp:GridView ID="UnfinishedTransactionGridView" runat="server" AutoGenerateColumns="False" OnRowDataBound="UnfinishedTransactionGridView_RowDataBound" CellPadding="8">
            <Columns>
                <asp:BoundField DataField="TransactionID" HeaderText="Transaction Id" ItemStyle-Height="40px" HeaderStyle-Height="30px" ItemStyle-Width="150px" />
                <asp:BoundField DataField="UserID" HeaderText="User Id" ItemStyle-Width="100px "/>
                <asp:BoundField DataField="TransactionStatus" HeaderText="Status" ItemStyle-Width="150px" />
                <asp:TemplateField HeaderText="Action" ItemStyle-Width="300px">
                    <ItemTemplate>
                        <asp:Button ID="ConfirmPaymentBtn" runat="server" Text="Confirm Payment" CommandArgument='<%# Eval("TransactionID") %>' OnClick="ConfirmPaymentBtn_Click" Visible="false" />
                        <asp:Button ID="ShipPackageBtn" runat="server" Text="Ship Package" CommandArgument='<%# Eval("TransactionID") %>' OnClick="ShipPackageBtn_Click" Visible="false" />
                        <asp:Label ID="WaitingLabel" runat="server" Text="Waiting for user confirmation…" Visible="false" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
