using FinalProjectPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectPSD.View
{
    public partial class TransactionDetail : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null || Session["UserRole"]?.ToString() != "customer")
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                int transactionId;
                if (int.TryParse(Request.QueryString["TransactionID"], out transactionId))
                {
                    lblTransactionID.Text = "Transaction ID: " + transactionId;
                    gvTransactionDetail.DataSource = TransactionDetailController.GetTransactionDetail(transactionId);
                    gvTransactionDetail.DataBind();
                }
                else
                {
                    lblTransactionID.Text = "Invalid transaction.";
                }
            }
        }
    }
}