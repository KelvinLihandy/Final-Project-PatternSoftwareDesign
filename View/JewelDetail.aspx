<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="JewelDetail.aspx.cs" Inherits="FinalProjectPSD.View.JewelDetail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div style="display: flex; flex-direction: column; gap: 0vh; justify-content: center; align-items: center; height: 93vh ; margin: 0; width: 100vw; margin-top: 12vh; ">
    <h1>Jewel Detail</h1>

    <asp:Label ID="lblJewelName" runat="server" Font-Bold="true" /><br />
    <asp:Label ID="lblCategory" runat="server" /><br />
    <asp:Label ID="lblBrand" runat="server" /><br />
    <asp:Label ID="lblCountry" runat="server" /><br />
    <asp:Label ID="lblClass" runat="server" /><br />
    <asp:Label ID="lblPrice" runat="server" /><br />
    <asp:Label ID="lblYear" runat="server" /><br /><br />

    <asp:Button ID="btnAddToCart" runat="server" Text="Add to Cart" Visible="false" OnClick="btnAddToCart_Click" />
    <asp:Button ID="btnEdit" runat="server" Text="Edit" Visible="false" OnClick="btnEdit_Click" />
    <asp:Button ID="btnDelete" runat="server" Text="Delete" Visible="false" OnClick="btnDelete_Click" />

    <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
    </div>
</asp:Content>
