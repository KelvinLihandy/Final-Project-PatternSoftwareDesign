using FinalProjectPSD.Controller;
using FinalProjectPSD.Handler;
using FinalProjectPSD.Model;
using FinalProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectPSD.View
{
    public partial class UpdateJewel : System.Web.UI.Page
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
                ddlCategory.Items.Clear();
                ddlBrand.Items.Clear();

                List<MsCategory> categoryList = MsCategoryRepository.GetCategories();
                ddlCategory.DataSource = categoryList;
                ddlCategory.DataTextField = "CategoryName";
                ddlCategory.DataValueField = "CategoryID";
                ddlCategory.DataBind();

                List<MsBrand> brandList = MsBrandRepository.GetBrands();
                ddlBrand.DataSource = brandList;
                ddlBrand.DataTextField = "BrandName";
                ddlBrand.DataValueField = "BrandID";
                ddlBrand.DataBind();
                }
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            string jewelName = txtJewelName.Text.Trim();
            string category = ddlCategory.SelectedValue;
            string brand = ddlBrand.SelectedValue;
            string priceText = txtPrice.Text.Trim();
            string yearText = txtReleaseYear.Text.Trim();

            // Debugging
            //LabelResult.Text = $"Selected Category ID: {category}, Brand ID: {brand}";
            //System.Diagnostics.Debug.WriteLine($"Selected Category: {category}, Brand: {brand}");
            //System.Diagnostics.Debug.WriteLine($"Category dropdown items: {ddlCategory.Items.Count}");
            //System.Diagnostics.Debug.WriteLine($"Brand dropdown items: {ddlBrand.Items.Count}");

            string nameError = JewelController.ValidateName(jewelName);
            string categoryError = JewelController.ValidateCategoryById(category);  
            string brandError = JewelController.ValidateBrandById(brand);  
            object[] priceValidation = JewelController.ValidatePrice(priceText);
            object[] yearValidation = JewelController.ValidateYear(yearText);

            string priceError = (string)priceValidation[0];
            string yearError = (string)yearValidation[0];

            lblJewelNameError.Text = string.Empty;
            lblCategoryError.Text = string.Empty;
            lblBrandError.Text = string.Empty;
            lblPriceError.Text = string.Empty;
            lblYearError.Text = string.Empty;

            bool hasError = false;

            if (!string.IsNullOrEmpty(nameError))
            {
                lblJewelNameError.Text = nameError;
                hasError = true;
            }
            if (!string.IsNullOrEmpty(categoryError))
            {
                lblCategoryError.Text = categoryError;
                hasError = true;
            }
            if (!string.IsNullOrEmpty(brandError))
            {
                lblBrandError.Text = brandError;
                hasError = true;
            }
            if (!string.IsNullOrEmpty(priceError))
            {
                lblPriceError.Text = priceError;
                hasError = true;
            }
            if (!string.IsNullOrEmpty(yearError))
            {
                lblYearError.Text = yearError;
                hasError = true;
            }

            if (hasError)
            {
                return;
            }

            int categoryId = int.Parse(category);
            int brandId = int.Parse(brand);
            int price = (int)priceValidation[1];
            int year = (int)yearValidation[1];
            int jewelId = int.Parse(Request.QueryString["JewelID"]);

            bool isUpdated = JewelHandler.UpdateJewel(jewelId, jewelName, categoryId, brandId, price, year);

            if (isUpdated)
            {
                // Redirect to the jewel details page not yet created
                Response.Redirect("~/JewelDetails.aspx?JewelID=" + jewelId);
            }
            else
            {
                lblJewelNameError.Text = "Failed to update the jewel.";
            }
        }
    }
}
