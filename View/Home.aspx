<%@ Page Title="Home - JAwels & Diamonds" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalProjectPSD.View.Home" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h1>Welcome to JAwels & Diamonds</h1>
        <p>Discover our collection of luxury jewelry pieces.</p>
        
        <div class="jewel-container">
            <asp:Repeater ID="JewelsRepeater" runat="server">
                <ItemTemplate>
                    <div class="jewel-card">
                        <div class="jewel-name"><%# Eval("JewelName") %></div>
                        <div class="jewel-info">ID: <%# Eval("JewelID") %></div>
                        <div class="jewel-price">$<%# Eval("JewelPrice") %></div>
                        <asp:HyperLink ID="DetailLink" runat="server" 
                            CssClass="detail-btn" 
                            Text="View Details" 
                            NavigateUrl='<%# "AddJewel.aspx?id=" + Eval("JewelID") %>'>
                        </asp:HyperLink>
                    </div>
                </ItemTemplate>
                <EmptyDataTemplate>
                    <div class="no-jewels">No jewelry items available at the moment.</div>
                </EmptyDataTemplate>
            </asp:Repeater>
        </div>
        
        <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>
    </div>
</asp:Content>