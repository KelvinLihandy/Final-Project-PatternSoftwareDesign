<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetailPage.aspx.cs" Inherits="FinalProjectPSD.View.TransactionDetailPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h1 style="text-align: center; margin-top: 80px; justify-content: center;">Transaction Detail</h1>

    <div style="margin-top: 0px; display: flex; flex-direction:column; justify-content: center; align-items: center; font-size: 18px;">
        <asp:Label ID="IDLabel" runat="server" Text="Transaction ID : "></asp:Label>
        <asp:Label ID="DateLabel" runat="server" Text="Date : "></asp:Label>
        <asp:Label ID="StatusLabel" runat="server" Text="Status : "></asp:Label>
    </div>

    <br /><br />

    <div style="width: 100%; margin-top: 0px; display: flex; justify-content: center;  font-size: 18px;">
        <asp:GridView ID="DetailsGridView" runat="server" AutoGenerateColumns="false">
            <Columns>
                <asp:BoundField DataField="JewelName" HeaderText="Jewel" />
                <asp:BoundField DataField="BrandName" HeaderText="Brand" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}"/>
                <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
                <asp:BoundField DataField="Subtotal" HeaderText="Subtotal" DataFormatString="{0:C}"/>
            </Columns>
        </asp:GridView>
    </div>

    <div style="display: flex; flex-direction:column; justify-content: center; align-items: center; font-size: 20px;">
        <p><strong>Total:</strong> <asp:Label ID="TotalLabel" runat="server" /></p>
    </div>
</asp:Content>
