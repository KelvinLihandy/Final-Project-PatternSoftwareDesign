using FinalProjectPSD.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectPSD.View
{
    public partial class TransactionDetailPage : System.Web.UI.Page
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
            if (!IsPostBack && Request.QueryString["TransactionID"] != null)
            {
                int TransID = int.Parse(Request.QueryString["TransactionID"]);
                var TransHeader = TransactionController.GetTransactionHeaderById(TransID);

                if (TransHeader == null)
                {
                    Response.Redirect("MyOrders.aspx");
                    return;
                }

                IDLabel.Text = "Transaction ID : " + TransHeader.TransactionID.ToString();
                DateLabel.Text = "Date : " + TransHeader.TransactionDate.ToString("dd MMM yyyy");
                StatusLabel.Text = "Status : " + TransHeader.TransactionStatus;

                var TransDetail = TransactionController.GetTransactionDetailDisplay(TransID);
                DetailsGridView.DataSource = TransDetail;
                DetailsGridView.DataBind();

                TotalLabel.Text = TransDetail.Sum(d => d.Subtotal).ToString("C");
            }
        }
    }
}