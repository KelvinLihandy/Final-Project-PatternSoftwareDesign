<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FinalProjectPSD.View.Home" MasterPageFile="~/View/Navbar.Master" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2 style="text-align: center; margin: 60px 0; color: #333; ">Our Exclusive Collection</h2>
        
        <div style="width: 100%; margin-top: 60px; display: flex; justify-content: center;">
            <asp:GridView ID="JewelGridView" runat="server" AutoGenerateColumns="False" 
                GridLines="None" ShowHeader="False" AllowPaging="True" 
                PageSize="9" OnPageIndexChanging="JewelGridView_PageIndexChanging"
                style="width: 100%;">
                <Columns>
                    <asp:TemplateField>
                        <ItemTemplate>
                            <div style="border: 1px solid #ddd; border-radius: 8px; padding: 15px; width: 100%; box-shadow: 0 2px 5px rgba(0,0,0,0.1); transition: transform 0.3s; height: 100%; margin-bottom:30px;">
                                <div style="margin-bottom: 15px; display: flex; flex-direction: row; justify-content: space-between">
                                    <div style="color: #666; margin-bottom: 5px;">ID: <%# Eval("JewelID") %></div>
                                    <div style="font-size: 18px; font-weight: bold; margin-bottom: 5px;"><%# Eval("JewelName") %></div>
                                    <div style="font-size: 16px; font-weight: bold; color: #3a7b4c;">$<%# Eval("JewelPrice", "{0:N0}") %></div>
                                </div>
                                <a href='JewelDetail.aspx?JewelID=<%# Eval("JewelID") %>' style="display: block; width: 80%; padding: 8px; background-color: #3a7b4c; color: white; text-align: center; border: none; border-radius: 4px; cursor: pointer; text-decoration: none; justify-self:center">
                                    View Details

                                </a>
                            </div>
                        </ItemTemplate>
                        <ItemStyle Width="33%" />
                    </asp:TemplateField>
                </Columns>
                <EmptyDataTemplate>
                    <div style="text-align: center; padding: 40px; color: #666; font-style: italic;">No jewelry items available at the moment.</div>
                </EmptyDataTemplate>
                <PagerStyle CssClass="pager" />
            </asp:GridView>
        </div>
    </div>
    <style>
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
