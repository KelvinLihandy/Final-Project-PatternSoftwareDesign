<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="TransactionDetail.aspx.cs" Inherits="FinalProjectPSD.View.TransactionDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; flex-direction: column; gap: 0vh; justify-content: center; align-items: center; height: 93vh ; margin: 0; width: 100vw; margin-top: 12vh; ">
    <h1>Transaction Detail</h1>

    <asp:Label ID="lblTransactionID" runat="server" Font-Bold="true" />

    <br /><br />
    <asp:GridView ID="gvTransactionDetail" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="JewelName" HeaderText="Jewel Name" />
            <asp:BoundField DataField="Quantity" HeaderText="Quantity" />
        </Columns>
    </asp:GridView>
    </div>
</asp:Content>
