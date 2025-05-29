using FinalProjectPSD.Handler;
using FinalProjectPSD.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectPSD.View
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if the user is logged in
            if (Session["User"] == null || !(Session["User"] is MsUser) || ((MsUser)Session["User"]).UserRole != "Customer")
            {
                Response.Redirect("Login.aspx");
                return;
            }

            if (!IsPostBack)
            {
                BindTransactions();
            }
        }

        private void BindTransactions()
        {
            // Get the current user
            MsUser currentUser = (MsUser)Session["User"];

            // Get the user's transactions
            TransactionHandler handler = new TransactionHandler();
            List<TransactionHeader> transactions = handler.GetUserTransactions(currentUser.UserID);

            // Bind the transactions to the GridView
            gvTransactions.DataSource = transactions;
            gvTransactions.DataBind();
        }

        protected void gvTransactions_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            // Get the transaction ID from the command argument
            int transactionId = Convert.ToInt32(e.CommandArgument);

            // Process the command based on its name
            switch (e.CommandName)
            {
                case "ViewDetails":
                    // Redirect to the transaction details page
                    Response.Redirect($"TransactionDetail.aspx?TransactionID={transactionId}");
                    break;

                case "ConfirmPackage":
                    // Update the transaction status to "Done"
                    UpdateTransactionStatus(transactionId, "Done");
                    break;

                case "RejectPackage":
                    // Update the transaction status to "Rejected"
                    UpdateTransactionStatus(transactionId, "Rejected");
                    break;
            }
        }

        private void UpdateTransactionStatus(int transactionId, string status)
        {
            // Update the transaction status
            TransactionHandler handler = new TransactionHandler();
            bool success = handler.UpdateTransactionStatus(transactionId, status);

            if (success)
            {
                // Refresh the grid to show the updated status
                BindTransactions();

                // Show success message
                ScriptManager.RegisterStartupScript(this, GetType(), "Success",
                    $"alert('Transaction status updated to {status}.');", true);
            }
            else
            {
                // Show error message
                ScriptManager.RegisterStartupScript(this, GetType(), "Error",
                    "alert('Failed to update transaction status. Please try again.');", true);
            }
        }
    }
}