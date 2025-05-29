<%@ Page Title="" Language="C#" MasterPageFile="~/View/Navbar.Master" AutoEventWireup="true" CodeBehind="MyOrders.aspx.cs" Inherits="FinalProjectPSD.View.MyOrders" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>My Orders</title>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container">
        <h2>My Orders</h2>
        <div class="row mt-4">
            <div class="col-12">
                <asp:GridView ID="gvMyOrders" runat="server" 
                    AutoGenerateColumns="false" 
                    CssClass="table table-striped" 
                    OnRowCommand="gvMyOrders_RowCommand"
                    DataKeyNames="TransactionID">
                    <Columns>
                        <asp:BoundField DataField="TransactionID" HeaderText="Transaction ID" />
                        <asp:BoundField DataField="TransactionDate" HeaderText="Transaction Date" DataFormatString="{0:MM/dd/yyyy}" />
                        <asp:BoundField DataField="PaymentMethod" HeaderText="Payment Method" />
                        <asp:BoundField DataField="TransactionStatus" HeaderText="Status" />
                        <asp:TemplateField HeaderText="Actions">
                            <ItemTemplate>
                                <asp:Button ID="btnViewDetails" runat="server" 
                                    Text="View Details" 
                                    CommandName="ViewDetails" 
                                    CommandArgument='<%# Eval("TransactionID") %>'
                                    CssClass="btn btn-primary btn-sm" />
                                
                                <!-- Confirm & Reject Package Buttons - Only for "Arrived" status -->
                                <asp:Panel ID="pnlArrivedActions" runat="server" 
                                    Visible='<%# Eval("TransactionStatus").ToString() == "Arrived" %>'>
                                    <asp:Button ID="btnConfirmPackage" runat="server" 
                                        Text="Confirm Package" 
                                        CommandName="ConfirmPackage" 
                                        CommandArgument='<%# Eval("TransactionID") %>'
                                        CssClass="btn btn-success btn-sm ml-1" />
                                    <asp:Button ID="btnRejectPackage" runat="server" 
                                        Text="Reject Package" 
                                        CommandName="RejectPackage" 
                                        CommandArgument='<%# Eval("TransactionID") %>'
                                        CssClass="btn btn-danger btn-sm ml-1" />
                                </asp:Panel>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                    <EmptyDataTemplate>
                        <div class="alert alert-info text-center">
                            <h5>No Orders Found</h5>
                            <p>You have no orders yet. Start shopping to see your orders here.</p>
                        </div>
                    </EmptyDataTemplate>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>