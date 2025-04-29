using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectPSD.View
{
	public partial class Navbar : System.Web.UI.MasterPage
	{
		protected void Page_Load(object sender, EventArgs e)
		{

		}

        protected void Loginpage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Login.aspx");
        }

        protected void RegisterPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Register.aspx");
        }

        protected void HomePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }

        protected void CartPage_Click(object sender, EventArgs e)
        {

        }

        protected void MyOrderPage_Click(object sender, EventArgs e)
        {

        }

        protected void ProfilePage_Click(object sender, EventArgs e)
        {

        }

        protected void Logout_Click(object sender, EventArgs e)
        {

        }

        protected void AddJewelPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/AddJewel.aspx");
        }

        protected void ReportPage_Click(object sender, EventArgs e)
        {

        }

        protected void HandleOrderPage_Click(object sender, EventArgs e)
        {

        }
    }
}