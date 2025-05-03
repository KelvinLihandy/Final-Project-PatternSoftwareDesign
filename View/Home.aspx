<%@ Page Title="Home - JAwels & Diamonds" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalProjectPSD.View.Home" %>

<asp:Content ID="Content" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="jewel-container">
        <asp:ListView ID="JewelsRepeater" runat="server">
            <ItemTemplate>
                <div class="jewel-card">
                    <div class="jewel-name"><%# Eval("JewelName") %></div>
                    <div class="jewel-info">ID: <%# Eval("JewelID") %></div>
                    <div class="jewel-price">$<%# Eval("JewelPrice") %></div>
                    <asp:HyperLink ID="DetailLink" runat="server"
                        CssClass="detail-btn"
                        Text="View Details"
                        NavigateUrl='<%# "JewelDetail.aspx?id=" + Eval("JewelID") %>'>
                    </asp:HyperLink>
                </div>
            </ItemTemplate>
            <EmptyDataTemplate>
                <div class="no-jewels">No jewelry items available at the moment.</div>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>

    <asp:Label ID="ErrorLabel" runat="server" ForeColor="Red" Visible="false"></asp:Label>
</asp:Content>
