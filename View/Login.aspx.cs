﻿using FinalProjectPSD.Controller;
using FinalProjectPSD.Model;
using FinalProjectPSD.Repository;
using System;
using System.Web;

namespace FinalProjectPSD.View
{
	public partial class Login : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            string email = TextBoxEmail.Text;
            string password = TextBoxPassword.Text;
            bool remember = rememberMe.Checked;

            EmailError.Visible = LoginController.ValidateEmail(email);
            PasswordError.Visible = LoginController.ValidatePassword(password);

            if (EmailError.Visible == true || PasswordError.Visible == true)
            {
                return;
            }

            MsUser user = MsUserRepository.GetUser(email, password);
            if (remember)
            {
                HttpCookie cookie = new HttpCookie("user_cookie")//user mana yang login
                {
                    HttpOnly = true,
                    Secure = true,
                    Value = user.UserID.ToString(),
                    Expires = DateTime.Now.AddDays(3)
                };
                Response.Cookies.Add(cookie);
            }

            if (user != null)
            {
                Session[user.UserRole] = user; //simpen data login manual user sekarang. kalau ada cookie bisa dipake kalau gada session (user ga login manual)
                Response.Redirect("~/View/Home.aspx");
            }
        }
    }
}