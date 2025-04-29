<%@ Page Title="Login" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FinalProjectPSD.View.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; flex-direction: column; gap: 1vh; justify-content: center; align-items: center; height: 93vh ; margin: 0; width: 100vw; margin-top: 7vh; ">
        <asp:Label ID="LoginTitle" runat="server" Text="Login" style="font-size: 48px; padding-bottom: 2vh; align-self: center;"></asp:Label>

        <div style="display:flex; flex-direction:column; font-size: 24px; min-width: 33vw; max-width: 33vw;">
            <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server" Height="20px" Font-Size="Medium" ></asp:TextBox>
            <asp:Label ID="EmailError" runat="server" Text="" ForeColor="Red" Visible="true" Font-Size="18px"></asp:Label>
        </div>

        <div style="display:flex; flex-direction:column; font-size: 24px; min-width: 33vw; max-width: 33vw;">
            <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" Height="20px" Font-Size="Medium" ></asp:TextBox>
            <asp:Label ID="PasswordError" runat="server" Text="" ForeColor="Red" Visible="true" Font-Size="18px"></asp:Label>
        </div>
        <div style="font-size: 24px; min-width: 33vw; max-width: 33vw;">
            <asp:CheckBox ID="rememberMe" runat="server" Text="Remember Me" Font-Size="Large" Height="20px" />
        </div>
        <div style="display: flex; justify-content: center; width: 100%; font-size: 24px; padding-top: 2vh;">
            <asp:Button ID="ButtonLogin" runat="server" Text="Login" OnClick="ButtonLogin_Click" Width="200px" Height="50px" Font-Size="Large" />
        </div>
    </div>
</asp:Content>