<%@ Page Title="Register" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FinalProjectPSD.View.Register" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="display: flex; flex-direction: column; gap: 1vh; justify-content: center; align-items: center; height: 93vh; margin-top: 7vh; width: 100vw; ">
        <asp:Label ID="RegisterTitle" runat="server" Text="Register" Style="font-size: 48px; padding-bottom: 2vh; align-self: center;"></asp:Label>

        <div style="display: flex; flex-direction: column; font-size: 24px; min-width: 33vw; max-width: 33vw;">
            <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
            <asp:TextBox ID="TextBoxEmail" runat="server" Height="20px" Font-Size="Medium"></asp:TextBox>
            <asp:Label ID="EmailError" runat="server" Text="Must be a valid email format and must be unique in the user database" ForeColor="Red" Visible="false" Font-Size="18px"></asp:Label>
        </div>

        <div style="display: flex; flex-direction: column; font-size: 24px; min-width: 33vw; max-width: 33vw;">
            <asp:Label ID="LabelUsername" runat="server" Text="Username"></asp:Label>
            <asp:TextBox ID="TextBoxUsername" runat="server" Height="20px" Font-Size="Medium"></asp:TextBox>
            <asp:Label ID="UsernameError" runat="server" Text="Must be between 3 to 25 characters (inclusive)" ForeColor="Red" Visible="false" Font-Size="18px"></asp:Label>
        </div>

        <div style="display: flex; flex-direction: column; font-size: 24px; min-width: 33vw; max-width: 33vw;">
            <asp:Label ID="LabelPassword" runat="server" Text="Password"></asp:Label>
            <asp:TextBox ID="TextBoxPassword" runat="server" Height="20px" Font-Size="Medium"></asp:TextBox>
            <asp:Label ID="PasswordError" runat="server" Text="Must be alphanumeric and 8 to 20 characters (inclusive)" ForeColor="Red" Visible="false" Font-Size="18px"></asp:Label>
        </div>

        <div style="display: flex; flex-direction: column; font-size: 24px; min-width: 33vw; max-width: 33vw;">
            <asp:Label ID="LabelConfirm" runat="server" Text="Confirm Password"></asp:Label>
            <asp:TextBox ID="TextBoxConfirm" runat="server" Height="20px" Font-Size="Medium"></asp:TextBox>
            <asp:Label ID="ConfirmError" runat="server" Text="Must be the same as password." ForeColor="Red" Visible="false" Font-Size="18px"></asp:Label>
        </div>

        <div style="display: flex; flex-direction: column; font-size: 24px; min-width: 33vw; max-width: 33vw;">
            <asp:Label ID="LabelGender" runat="server" Text="Gender"></asp:Label>
            <asp:RadioButtonList ID="RadioButtonGender" runat="server">
                <asp:ListItem Value="male">Male</asp:ListItem>
                <asp:ListItem Value="female">Female</asp:ListItem>
            </asp:RadioButtonList>
            <asp:Label ID="GenderError" runat="server" Text="Must be chosen using radio button and must be Male or Female" ForeColor="Red" Visible="false" Font-Size="18px"></asp:Label>
        </div>

        <div style="display: flex; flex-direction: column; font-size: 24px; min-width: 33vw; max-width: 33vw;">
            <asp:Label ID="LabelDate" runat="server" Text="Date of Birth"></asp:Label>
            <asp:TextBox ID="TextBoxDate" runat="server" TextMode="Date" Height="30px" Font-Size="Medium"></asp:TextBox>
            <asp:Label ID="DateError" runat="server" Text="Must be chosen using date picker and must be earlier than 01/01/2010" ForeColor="Red" Visible="false" Font-Size="18px"></asp:Label>
        </div>

        <div style="display: flex; justify-content: center; width: 100%; font-size: 24px; padding-top: 2vh;">
            <asp:Button ID="ButtonRegister" runat="server" Text="Register" OnClick="ButtonRegister_Click" Width="200px" Height="50px" Font-Size="Large" />
        </div>
    </div>
    <script type="text/javascript">
        document.getElementById('<%= TextBoxDate.ClientID %>').addEventListener('keydown', function (event) {
            event.preventDefault();
        });
    </script>
</asp:Content>
