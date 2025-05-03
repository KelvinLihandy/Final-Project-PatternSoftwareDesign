using FinalProjectPSD.Controller;
using FinalProjectPSD.Handler;
using FinalProjectPSD.Model;
using FinalProjectPSD.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProjectPSD.View
{
    public partial class AddJewel : System.Web.UI.Page
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
                List<MsCategory> categoryList = MsCategoryRepository.GetCategories();
                List <MsBrand> brandList = MsBrandRepository.GetBrands();
                DropdownCategory.DataSource = categoryList;
                DropdownCategory.DataBind();
                DropdownBrand.DataSource = brandList;
                DropdownBrand.DataBind();
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/View/Home.aspx");
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            string name = TextBoxName.Text;
            string category = DropdownCategory.SelectedItem.Text;
            string brand = DropdownBrand.SelectedItem.Text;
            string priceString = TextBoxPrice.Text.Trim();
            string yearString = TextBoxYear.Text.Trim();
            object[] priceObj = JewelController.ValidatePrice(priceString);
            object[] yearObj = JewelController.ValidateYear(yearString);
            NameError.Text = JewelController.ValidateName(name);
            CategoryError.Text = JewelController.ValidateCategory(category);
            BrandError.Text = JewelController.ValidateBrand(brand);
            PriceError.Text = (string)priceObj[0];
            YearError.Text = (string)yearObj[0];
            if (!string.IsNullOrEmpty(NameError.Text) ||
                !string.IsNullOrEmpty(CategoryError.Text) ||
                !string.IsNullOrEmpty(BrandError.Text) ||
                !string.IsNullOrEmpty(PriceError.Text) ||
                !string.IsNullOrEmpty(YearError.Text)) return;
            if(JewelHandler.InsertJewel(
                name.Trim(),
                int.Parse(DropdownBrand.SelectedValue),
                int.Parse(DropdownCategory.SelectedValue),
                (int)priceObj[1],
                (int)yearObj[1]
             )) LabelResult.Text = "Success Add";
            else
            {
                LabelResult.ForeColor = Color.Red;
                LabelResult.Text = "Failed Add";
            }
            return;
        }
    }
}