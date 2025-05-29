using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProjectPSD.Model;
using FinalProjectPSD.Handler;

namespace FinalProjectPSD.View
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // This page is only available to customers
            if (Session["user"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
                return;
            }

            MsUser currentUser = (MsUser)Session["user"];
            if (currentUser.UserRole != "Customer")
            {
                Response.Redirect("~/View/Home.aspx");
                return;
            }

            if (!IsPostBack)
            {
                LoadUserTransactions();
            }
        }

        private void LoadUserTransactions()
        {
            try
            {
                MsUser currentUser = (MsUser)Session["user"];

                // Display the history of all user transactions
                // Data to be shown are Transaction ID, Transaction Date, Payment Method, and Status
                List<TransactionHeader> userTransactions = TransactionHandler.GetUserTransactions(currentUser.UserID);

                gvMyOrders.DataSource = userTransactions;
                gvMyOrders.DataBind();
            }
            catch (Exception ex)
            {
                // Handle error gracefully
                Response.Write("<script>alert('Error loading transactions: " + ex.Message + "');</script>");
            }
        }

        protected void gvMyOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int transactionID = Convert.ToInt32(e.CommandArgument);

            try
            {
                switch (e.CommandName)
                {
                    case "ViewDetails":
                        // Provide a view details button that will direct the user to the transaction detail page of the selected row
                        // The transaction ID must be passed using URL's query string parameter
                        Response.Redirect("~/View/TransactionDetail.aspx?TransactionID=" + transactionID);
                        break;

                    case "ConfirmPackage":
                        // If "Confirm Package" button is clicked, change the transaction status to "Done"
                        bool confirmResult = TransactionHandler.UpdateTransactionStatus(transactionID, "Done");

                        if (confirmResult)
                        {
                            LoadUserTransactions(); // Refresh the grid to show updated status
                            Response.Write("<script>alert('Package confirmed successfully!');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Failed to confirm package. Please try again.');</script>");
                        }
                        break;

                    case "RejectPackage":
                        // If "Reject Package" button is clicked, change the transaction status to "Rejected"
                        bool rejectResult = TransactionHandler.UpdateTransactionStatus(transactionID, "Rejected");

                        if (rejectResult)
                        {
                            LoadUserTransactions(); // Refresh the grid to show updated status
                            Response.Write("<script>alert('Package rejected successfully!');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Failed to reject package. Please try again.');</script>");
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('Error: " + ex.Message + "');</script>");
            }
        }
    }
}