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

            EmailError.Text = RegisterController.ValidateEmail(email);
            UsernameError.Text = RegisterController.ValidateUserName(name);
            PasswordError.Text = RegisterController.ValidatePassword(password);
            ConfirmError.Text = RegisterController.ValidateConfirm(password, confirm);
            GenderError.Text = RegisterController.ValidateGender(gender);
            DateError.Text = RegisterController.ValidateDob(dob);

            if (!string.IsNullOrEmpty(EmailError.Text) ||
                !string.IsNullOrEmpty(UsernameError.Text) ||
                !string.IsNullOrEmpty(PasswordError.Text) ||
                !string.IsNullOrEmpty(ConfirmError.Text) ||
                !string.IsNullOrEmpty(GenderError.Text) ||
                !string.IsNullOrEmpty(DateError.Text)) return;

            AuthHandler.InsertUser(email, name, password, gender, dob);
            Response.Redirect("~/View/Login.aspx");
            return;
        }
    }
}