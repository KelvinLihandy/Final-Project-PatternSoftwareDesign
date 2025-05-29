<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="FinalProjectPSD.View.MyOrders" MasterPageFile="~/View/Navbar.Master" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>My Orders - Jewels & Diamonds</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>My Orders</h2>
        <div class="row mt-4">
            <div class="col-12">
                <asp:GridView ID="gvTransactions" runat="server" AutoGenerateColumns="false" CssClass="table table-striped"
                    OnRowCommand="gvTransactions_RowCommand" DataKeyNames="TransactionId">
                    <Columns>
                        <asp:BoundField DataField="TransactionId" HeaderText="Transaction ID" />
                        <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method" />
                        <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnViewDetails" runat="server" Text="View Details" 
                                    CommandName="ViewDetails" CommandArgument='<%# Eval("TransactionId") %>' 
                                    CssClass="btn btn-primary btn-sm" />
                                
                                <asp:Panel ID="pnlArrivedActions" runat="server" Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>'>
                                    <asp:Button ID="btnConfirmPackage" runat="server" Text="Confirm Package" 
                                        CommandName="ConfirmPackage" CommandArgument='<%# Eval("TransactionId") %>' 
                                        CssClass="btn btn-success btn-sm mt-1" />
                                    <asp:Button ID="btnRejectPackage" runat="server" Text="Reject Package" 
                                        CommandName="RejectPackage" CommandArgument='<%# Eval("TransactionId") %>' 
                                        CssClass="btn btn-danger btn-sm mt-1" />
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div class="alert alert-info">
                            You have no orders yet. Start shopping to see your orders here.
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>