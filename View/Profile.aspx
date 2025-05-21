<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="FinalProjectPSD.View.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; flex-direction: column; gap: 0vh; justify-content: center; align-items: center; height: 93vh ; margin: 0; width: 100vw; margin-top: 12vh; ">
        <h1>My Profile</h1>
        <asp:Label ID="lblUsername" runat="server" Text="Username: "></asp:Label><br />
        <asp:Label ID="lblEmail" runat="server" Text="Email: "></asp:Label><br />
        <asp:Label ID="lblGender" runat="server" Text="Gender: "></asp:Label><br />
        <asp:Label ID="lblDOB" runat="server" Text="Date of Birth: "></asp:Label><br />

        <hr />

        <h3>Change Password</h3>
        <asp:Label ID="lblOldPassword" runat="server" Text="Enter Old Password: " />
        <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" /><br />

        <asp:Label ID="lblNewPassword" runat="server" Text="Enter New Password: " />
        <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" /><br />

        <asp:Label ID="lblConfirmPassword" runat="server" Text="Confirm New Password: " />
        <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" /><br /><br />

        <asp:Button ID="btnChangePassword" runat="server" Text="Change Password" OnClick="btnChangePassword_Click" />
        <br /><br />
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
    </div>
</asp:Content>