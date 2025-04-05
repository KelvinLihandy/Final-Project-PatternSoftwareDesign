using FinalProjectPSD.Controller;
using FinalProjectPSD.Handler;
using System;

namespace FinalProjectPSD.View
{
	public partial class Register : System.Web.UI.Page
	{
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonRegister_Click(object sender, EventArgs e)
        {
            string email = TextBoxEmail.Text.Trim();
            string name = TextBoxUsername.Text.Trim();
            string password = TextBoxPassword.Text;
            string confirm = TextBoxConfirm.Text;
            string gender = RadioButtonGender.SelectedItem != null ? RadioButtonGender.SelectedValue : "";
            string dob = TextBoxDate.Text;

            EmailError.Visible = RegisterController.ValidateEmail(email);
            UsernameError.Visible = RegisterController.ValidateUserName(name);
            PasswordError.Visible = RegisterController.ValidatePassword(password);
            ConfirmError.Visible = RegisterController.ValidateConfirm(password, confirm);
            GenderError.Visible = RegisterController.ValidateGender(gender);
            DateError.Visible = RegisterController.ValidateDob(dob);

            if (EmailError.Visible == true || UsernameError.Visible == true ||
                PasswordError.Visible == true || ConfirmError.Visible == true ||
                GenderError.Visible == true || DateError.Visible == true)
            {
                return;
            }

            AuthHandler.InsertUser(email, name, password, gender, dob);
            Response.Redirect("~/View/Login.aspx");
            return;
        }
    }
}