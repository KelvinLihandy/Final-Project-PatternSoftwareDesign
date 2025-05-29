using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProjectPSD.Controller;

namespace FinalProjectPSD.View
{
    public partial class Cart : System.Web.UI.Page
    {
        private CartController cartController;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["customer"] == null && Session["admin"] == null &&
                Request.Cookies["customer_cookie"] == null && Request.Cookies["admin_cookie"] == null)
            {
                Response.Redirect("~/View/Login.aspx");
                return;
            }

            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("en-US");

            cartController = new CartController();

            if (!IsPostBack)
            {
                LoadCartItems();
            }
        }

        private int GetUserId()
        {
            string userIdStr = Request.QueryString["userId"];
            if (!string.IsNullOrEmpty(userIdStr))
            {
                return Convert.ToInt32(userIdStr);
            }
            return Convert.ToInt32(Session["UserId"]);
        }

        private void LoadCartItems()
        {
            int userId = GetUserId();
            DataTable cartItems = cartController.GetCartItems(userId);

            CartGridView.DataSource = cartItems;
            CartGridView.DataKeyNames = new string[] { "Id" };
            CartGridView.DataBind();

            System.Diagnostics.Debug.WriteLine($"Binding {cartItems.Rows.Count} items to GridView");

            decimal total = 0;
            foreach (DataRow row in cartItems.Rows)
            {
                total += Convert.ToDecimal(row["Subtotal"]);
            }

            TotalLabel.Text = "$" + string.Format("{0:N2}", total);

            CheckoutButton.Enabled = cartItems.Rows.Count > 0;
        }

        protected void CartGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int userId = GetUserId();
            int jewelId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "UpdateItem")
            {
                int rowIndex = -1;
                for (int i = 0; i < CartGridView.Rows.Count; i++)
                {
                    if (CartGridView.DataKeys[i].Value.ToString() == jewelId.ToString())
                    {
                        rowIndex = i;
                        break;
                    }
                }

                if (rowIndex >= 0)
                {
                    GridViewRow row = CartGridView.Rows[rowIndex];
                    TextBox quantityTextBox = (TextBox)row.FindControl("QuantityTextBox");
                    string quantityStr = quantityTextBox.Text;

                    string errorMessage = cartController.UpdateCartItemQuantity(userId, jewelId, quantityStr);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                            $"alert('{errorMessage}');", true);
                    }
                    else
                    {
                        LoadCartItems();
                    }
                }
            }
            else if (e.CommandName == "RemoveItem")
            {
                string errorMessage = cartController.RemoveCartItem(userId, jewelId);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                        $"alert('{errorMessage}');", true);
                }
                else
                {
                    LoadCartItems();
                }
            }
        }

        protected void ContinueShoppingButton_Click(object sender, EventArgs e)
        {
            int userId = GetUserId();
            string errorMessage = cartController.ClearCart(userId);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                    $"alert('{errorMessage}');", true);
            }
            else
            {
                LoadCartItems();
            }
        }

        protected void CheckoutButton_Click(object sender, EventArgs e)
        {
            int userId = GetUserId();
            string paymentMethod = PaymentMethodDropDown.SelectedValue;

            string errorMessage = cartController.Checkout(userId, paymentMethod);

            if (!string.IsNullOrEmpty(errorMessage))
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                    $"alert('{errorMessage}');", true);
            }
            else
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                    "alert('Checkout completed successfully!'); window.location='Home.aspx';", true);
            }
        }
    }
}
