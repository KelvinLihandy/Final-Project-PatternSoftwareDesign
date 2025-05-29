<%@ Page Title="UpdateJewel" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="UpdateJewel.aspx.cs" Inherits="FinalProjectPSD.View.UpdateJewel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<div style="display: flex; flex-direction: column; gap: 1vh; justify-content: center; align-items: center; height: 93vh; margin-top: 7vh; width: 100vw; ">

    <asp:Label ID="updateLabel" runat="server" Text="Update Jewel" Style="font-size: 48px; padding-bottom: 2vh; align-self: center;"></asp:Label>

    <div style="display: flex; flex-direction: column; font-size: 24px; min-width: 33vw; max-width: 33vw;">
        <asp:Label ID="LabelName" runat="server" Text="Jewel Name"></asp:Label>
        <asp:TextBox ID="txtJewelName" runat="server" Height="20px" Font-Size="Medium"></asp:TextBox>
        <asp:Label ID="lblJewelNameError" runat="server" Text="" ForeColor="Red" Visible="true" Font-Size="18px"></asp:Label>
    </div>

    <div style="display: flex; flex-direction: column; font-size: 24px; min-width: 33vw; max-width: 33vw;">
        <asp:Label ID="LabelCategory" runat="server" Text="Category"></asp:Label>
        <asp:DropDownList ID="ddlCategory" runat="server" DataTextField="CategoryName" DataValueField="CategoryID" AppendDataBoundItems="true" Height="30px" Font-Size="Medium" >
            <asp:ListItem Text="Select Category" Value="" />
        </asp:DropDownList>
        <asp:Label ID="lblCategoryError" runat="server" Text="" ForeColor="Red" Visible="true" Font-Size="18px"></asp:Label>
    </div>

    <div style="display: flex; flex-direction: column; font-size: 24px; min-width: 33vw; max-width: 33vw;">
        <asp:Label ID="LabelBrand" runat="server" Text="Brand"></asp:Label>
        <asp:DropDownList ID="ddlBrand"  runat="server" DataTextField="BrandName" DataValueField="BrandID" AppendDataBoundItems="true" Height="30px" Font-Size="Medium" >
            <asp:ListItem Text="Select Brand" Value="" />
        </asp:DropDownList>
        <asp:Label ID="lblBrandError" runat="server" Text="" ForeColor="Red" Visible="true" Font-Size="18px"></asp:Label>
    </div>

    <div style="display: flex; flex-direction: column; font-size: 24px; min-width: 33vw; max-width: 33vw;">
        <asp:Label ID="LabelPrice" runat="server" Text="Price"></asp:Label>
        <asp:TextBox ID="txtPrice" runat="server" Height="20px" Font-Size="Medium"></asp:TextBox>
        <asp:Label ID="lblPriceError" runat="server" Text="" ForeColor="Red" Visible="true" Font-Size="18px"></asp:Label>
    </div>

    <div style="display: flex; flex-direction: column; font-size: 24px; min-width: 33vw; max-width: 33vw;">
        <asp:Label ID="LabelYear" runat="server" Text="Release Year"></asp:Label>
        <asp:TextBox ID="txtReleaseYear" runat="server" Height="20px" Font-Size="Medium"></asp:TextBox>
        <asp:Label ID="lblYearError" runat="server" Text="" ForeColor="Red" Visible="true" Font-Size="18px"></asp:Label>
    </div>

    <div style="display: flex; justify-content: center; width: 100%; font-size: 24px; padding-top: 2vh; gap: 20px; ">
        <asp:Button ID="ButtonCancel" runat="server" Text="Cancel" OnClick="ButtonCancel_Click" Width="200px" Height="50px" Font-Size="Large" />
        <asp:Button ID="ButtonUpdate" runat="server" Text="Update Jewel" OnClick="BtnUpdate_Click" Width="200px" Height="50px" Font-Size="Large" />
    </div>
    <asp:Label ID="LabelResult" runat="server" Text="" Visible="true" Font-Size="30px"></asp:Label>
</div>
</asp:Content>
