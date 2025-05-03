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
    public partial class HandleOrder : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null && Session["admin"] == null && Request.Cookies["customer_cookie"] == null && Request.Cookies["admin_cookie"] == null)
            {
                Response.Redirect("~/View/Home.aspx");
            }
            else if ((Session["customer"] != null || Request.Cookies["customer_cookie"] != null) && (Session["admin"] == null && Request.Cookies["admin_cookie"] == null))
            {
                Response.Redirect("~/View/Home.aspx");
            }
            if (!Page.IsPostBack)
            {
                List<TransactionHeader> unfinishedTransactionList = TransactionHandler.GetUnfinishedTransactions();
                UnfinishedTransactionGridView.DataSource = unfinishedTransactionList;
                UnfinishedTransactionGridView.DataBind();
            }
        }

        protected void UnfinishedTransactionGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string status = DataBinder.Eval(e.Row.DataItem, "TransactionStatus").ToString();

                Button confirmBtn = (Button)e.Row.FindControl("ConfirmPaymentBtn");
                Button shipBtn = (Button)e.Row.FindControl("ShipPackageBtn");
                Label waitingLabel = (Label)e.Row.FindControl("WaitingLabel");

                switch (status)
                {
                    case "Payment Pending":
                        confirmBtn.Visible = true;
                        break;
                    case "Shipment Pending":
                        shipBtn.Visible = true;
                        break;
                    case "Arrived":
                        waitingLabel.Visible = true;
                        break;
                }
            }
        }


        protected void ConfirmPaymentBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int transactionId = int.Parse(btn.CommandArgument);
            TransactionHandler.SetConfirmPayment(transactionId);
            List<TransactionHeader> unfinishedTransactionList = TransactionHandler.GetUnfinishedTransactions();
            UnfinishedTransactionGridView.DataSource = unfinishedTransactionList;
            UnfinishedTransactionGridView.DataBind();
        }

        protected void ShipPackageBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int transactionId = int.Parse(btn.CommandArgument);
            TransactionHandler.setShipmentPending(transactionId);
            List<TransactionHeader> unfinishedTransactionList = TransactionHandler.GetUnfinishedTransactions();
            UnfinishedTransactionGridView.DataSource = unfinishedTransactionList;
            UnfinishedTransactionGridView.DataBind();
        }
    }
}