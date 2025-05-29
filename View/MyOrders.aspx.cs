using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProjectPSD.Model;
using FinalProjectPSD.Handler;
using FinalProjectPSD.Controller;

namespace FinalProjectPSD.View
{
    public partial class MyOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null && Session["admin"] == null && Request.Cookies["customer_cookie"] == null && Request.Cookies["admin_cookie"] == null)
            {
                Response.Redirect("~/View/Home.aspx");
            }
            else if ((Session["admin"] != null || Request.Cookies["admin_cookie"] != null) && (Session["customer"] == null && Request.Cookies["customer_cookie"] == null))
            {
                Response.Redirect("~/View/Home.aspx");
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
                MsUser currentUser = (MsUser)Session["customer"];
                List<TransactionHeader> userTransactions = TransactionHandler.GetUserTransactions(currentUser.UserID);

                gvMyOrders.DataSource = userTransactions;
                gvMyOrders.DataBind();
            }
            catch (Exception ex)
            {
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
                        Response.Redirect("~/View/TransactionDetail.aspx?TransactionID=" + transactionID);
                        break;

                    case "ConfirmPackage":
                        bool confirmResult = TransactionHandler.UpdateTransactionStatus(transactionID, "Done");

                        if (confirmResult)
                        {
                            LoadUserTransactions();
                            Response.Write("<script>alert('Package confirmed successfully!');</script>");
                        }
                        else
                        {
                            Response.Write("<script>alert('Failed to confirm package. Please try again.');</script>");
                        }
                        break;

                    case "RejectPackage":
                        bool rejectResult = TransactionHandler.UpdateTransactionStatus(transactionID, "Rejected");

                        if (rejectResult)
                        {
                            LoadUserTransactions();
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