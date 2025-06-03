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
    public partial class Navbar : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] != null)
            {
                var customer = Session["customer"];
                string userName = (string)customer.GetType().GetProperty("UserName").GetValue(customer, null);
                UsernameLabel1.Text = "Hello " + userName;
            }
            if (Session["admin"] != null)
            {
                var customer = Session["admin"];
                string userName = (string)customer.GetType().GetProperty("UserName").GetValue(customer, null);
                UsernameLabel2.Text = "Hello " + userName;
            }
            if (Session["UserID"] == null)
            {
                string[] roles = { "admin", "customer" };

                foreach (string role in roles)
                {
                    HttpCookie cookie = Request.Cookies[$"{role}_cookie"];
                    if (cookie != null)
                    {
                        int userId;
                        if (int.TryParse(cookie.Value, out userId))
                        {
                            MsUser user = AuthHandler.GetUserById(userId);
                            if (user != null)
                            {
                                Session["UserID"] = user.UserID;
                                Session["UserRole"] = user.UserRole;
                                Session[user.UserRole] = user;
                                break;
                            }
                        }
                    }
                }
            }
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
            if (Session["customer"] != null)
            {
                var customer = Session["customer"];
                int userId = Convert.ToInt32(customer.GetType().GetProperty("UserID").GetValue(customer, null));
                Response.Redirect($"~/View/Cart.aspx?userId={userId}");
            }
            else if (Request.Cookies["customer_cookie"] != null)
            {
                string userIdStr = Request.Cookies["customer_cookie"].Value;
                Response.Redirect($"~/View/Cart.aspx?userId={userIdStr}");
            }
            else
            {
                Response.Redirect("~/View/Login.aspx");
            }
        }

        protected void MyOrderPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/MyOrders.aspx");
        }

        protected void ProfilePage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Profile.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();
            if (Request.Cookies.Count > 0)
            {
                foreach (string cookieName in Request.Cookies.AllKeys)
                {
                    HttpCookie cookie = new HttpCookie(cookieName);
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);
                }
            }
            Response.Redirect("~/View/Home.aspx");
        }

        protected void AddJewelPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/AddJewel.aspx");
        }

        protected void ReportPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Report.aspx");
        }

        protected void HandleOrderPage_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/HandleOrder.aspx");
        }
    }
}