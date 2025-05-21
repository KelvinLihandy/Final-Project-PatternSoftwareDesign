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
    public partial class JewelDetail : System.Web.UI.Page
    {
        private static int jewelId;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!int.TryParse(Request.QueryString["JewelID"], out jewelId))
                {
                    lblMessage.Text = "Invalid Jewel ID.";
                    return;
                }

                MsJewel jewel = JewelDetailController.GetJewelById(jewelId);
                if (jewel == null)
                {
                    lblMessage.Text = "Jewel not found.";
                    return;
                }

                lblJewelName.Text = "Name: " + jewel.JewelName;
                lblCategory.Text = "Category: " + jewel.MsCategory.CategoryName;
                lblBrand.Text = "Brand: " + jewel.MsBrand.BrandName;
                lblCountry.Text = "Country: " + jewel.MsBrand.BrandCountry;
                lblClass.Text = "Class: " + jewel.MsBrand.BrandClass;
                lblPrice.Text = "Price: $" + jewel.JewelPrice;
                lblYear.Text = "Release Year: " + jewel.JewelReleaseYear;
            }
            // Set button visibility based on role
            string role = Session["UserRole"]?.ToString();
            if (role == "customer")
            {
                btnAddToCart.Visible = true;
            }
            else if (role == "admin")
            {
                btnEdit.Visible = true;
                btnDelete.Visible = true;
            }
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            int userId = (int)Session["UserID"];
            string result = JewelDetailController.AddToCart(userId, jewelId);
            lblMessage.Text = result;
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditJewel.aspx?JewelID=" + jewelId);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string result = JewelDetailController.DeleteJewel(jewelId);
            lblMessage.Text = result;
            Response.Redirect("Home.aspx");
        }
    }
}
