using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProjectPSD.Controller;
using FinalProjectPSD.Model;

namespace FinalProjectPSD.View
{
    public partial class Profile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Response.Redirect("Login.aspx");
                    return;
                }

                int userId = (int)Session["UserID"];
                MsUser user = ProfileController.GetUser(userId);

                if (user != null)
                {
                    lblUsername.Text = "Username: " + user.UserName;
                    lblEmail.Text = "Email: " + user.UserEmail;
                    lblGender.Text = "Gender: " + user.UserGender;
                    lblDOB.Text = "Date of Birth: " + user.UserDOB.ToShortDateString();
                }
            }
        }

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Response.Redirect("Login.aspx");
                return;
            }

            int userId = (int)Session["UserID"];
            string oldPassword = txtOldPassword.Text;
            string newPassword = txtNewPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            string result = ProfileController.ChangePassword(userId, oldPassword, newPassword, confirmPassword);
            lblMessage.Text = result;
        }
    }
}
