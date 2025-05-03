<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalProjectPSD.View.Home" MasterPageFile="~/View/Navbar.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Jawels & Diamonds - Home</title>
    <style>
        .jewel-container {
            width: 100%;
            margin-top: 20px;
        }
        .grid-view {
            width: 100%;
            border-collapse: collapse;
        }
        .grid-view td {
            padding: 15px;
            vertical-align: top;
        }
        .jewel-card {
            border: 1px solid #ddd;
            border-radius: 8px;
            padding: 15px;
            width: 100%;
            box-shadow: 0 2px 5px rgba(0,0,0,0.1);
            transition: transform 0.3s;
            height: 100%;
        }
        .jewel-card:hover {
            transform: translateY(-5px);
            box-shadow: 0 5px 15px rgba(0,0,0,0.2);
        }
        .jewel-img {
            width: 100%;
            height: 200px;
            background-color: #f5f5f5;
            display: flex;
            align-items: center;
            justify-content: center;
            margin-bottom: 10px;
        }
        .jewel-img img {
            max-width: 90%;
            max-height: 90%;
        }
        .jewel-info {
            margin-bottom: 15px;
        }
        .jewel-name {
            font-size: 18px;
            font-weight: bold;
            margin-bottom: 5px;
        }
        .jewel-id {
            color: #666;
            margin-bottom: 5px;
        }
        .jewel-price {
            font-size: 16px;
            font-weight: bold;
            color: #3a7b4c;
        }
        .details-btn {
            display: block;
            width: 100%;
            padding: 8px;
            background-color: #3a7b4c;
            color: white;
            text-align: center;
            border: none;
            border-radius: 4px;
            cursor: pointer;
            text-decoration: none;
        }
        .details-btn:hover {
            background-color: #2a5a3c;
        }
        h2 {
            text-align: center;
            margin: 20px 0;
            color: #333;
        }
        .empty-message {
            text-align: center;
            padding: 40px;
            color: #666;
            font-style: italic;
        }
        .pager {
            text-align: center;
            margin-top: 20px;
        }
        .pager a {
            padding: 5px 10px;
            margin: 0 2px;
            border: 1px solid #ddd;
            border-radius: 3px;
            text-decoration: none;
            color: #3a7b4c;
        }
        .pager a:hover {
            background-color: #f5f5f5;
        }
        .pager span {
            padding: 5px 10px;
            margin: 0 2px;
            border: 1px solid #3a7b4c;
            border-radius: 3px;
            background-color: #3a7b4c;
            color: white;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>Our Exclusive Collection</h2>
        
        <div class="jewel-container">
            <asp:GridView ID="JewelGridView" runat="server" AutoGenerateColumns="False" 
                CssClass="grid-view" GridLines="None" ShowHeader="False" AllowPaging="True" 
                PageSize="9" OnPageIndexChanging="JewelGridView_PageIndexChanging">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div class="jewel-card">
                                <div class="jewel-img">
                                    <img src="path-to-image-folder/<%# Eval("JewelID") %>.jpg" alt="<%# Eval("JewelName") %>" 
                                        onerror="this.src='path-to-image-folder/default.jpg';" />
                                </div>
                                <div class="jewel-info">
                                    <div class="jewel-name"><%# Eval("JewelName") %></div>
                                    <div class="jewel-id">ID: <%# Eval("JewelID") %></div>
                                    <div class="jewel-price">$<%# Eval("JewelPrice", "{0:N0}") %></div>
                                </div>
                                <a href="ShowDetails.aspx?id=<%# Eval("JewelID") %>" class="details-btn">View Details</a>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="33%" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div class="empty-message">No jewelry items available at the moment.</div>
                </EmptyDataTemplate>
                <PagerStyle CssClass="pager" />
            </asp:GridView>
        </div>
    </div>
</asp:Content>