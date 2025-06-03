using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProjectPSD.Dataset;
using FinalProjectPSD.Handler;
using FinalProjectPSD.Model;
using FinalProjectPSD.Report;

namespace FinalProjectPSD.View
{
    public partial class Report : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                List<TransactionHeader> completedTransactions = TransactionHandler.GetData()
                    .Where(th => th.TransactionStatus == "Completed")
                    .ToList();

                CrystalReport1 report = new CrystalReport1();
                DataSet1 dataSet = GetData(completedTransactions);
                report.SetDataSource(dataSet);
                CrystalReportViewer1.ReportSource = report;
            }
        }

        private static DataSet1 GetData(List<TransactionHeader> transactionHeaders)
        {
            DataSet1 data = new DataSet1();
            var headerTable = data.TransactionHeader;
            var detailTable = data.TransactionDetail;
            var jewelTable = data.MsJewel;

            var jewelSet = new HashSet<int>();
            foreach (TransactionHeader t in transactionHeaders)
            {
                var hrow = headerTable.NewRow();
                hrow["TransactionID"] = t.TransactionID.ToString();
                hrow["UserID"] = t.UserID.ToString();
                hrow["TransactionDate"] = t.TransactionDate.ToString("yyyy-MM-dd HH:mm:ss");
                hrow["PaymentMethod"] = t.PaymentMethod;
                hrow["TransactionStatus"] = t.TransactionStatus;
                headerTable.Rows.Add(hrow);

                foreach (TransactionDetail d in t.TransactionDetails)
                {
                    var drow = detailTable.NewRow();
                    drow["TransactionID"] = d.TransactionID.ToString();
                    drow["JewelID"] = d.JewelID.ToString();
                    drow["Quantity"] = d.Quantity.ToString();
                    detailTable.Rows.Add(drow);

                    if (d.MsJewel != null && jewelSet.Add(d.JewelID))
                    {
                        var jrow = jewelTable.NewRow();
                        jrow["JewelID"] = d.MsJewel.JewelID.ToString();
                        jrow["BrandID"] = d.MsJewel.BrandID.ToString();
                        jrow["CategoryID"] = d.MsJewel.CategoryID.ToString();
                        jrow["JewelName"] = d.MsJewel.JewelName;
                        jrow["JewelPrice"] = d.MsJewel.JewelPrice.ToString();
                        jrow["JewelReleaseYear"] = d.MsJewel.JewelReleaseYear.ToString();
                        jewelTable.Rows.Add(jrow);
                    }
                }
            }
            return data;
        }
    }
}