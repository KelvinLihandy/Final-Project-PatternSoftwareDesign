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
            // Cek dari query string terlebih dahulu
            string userIdStr = Request.QueryString["userId"];
            if (!string.IsNullOrEmpty(userIdStr))
            {
                return Convert.ToInt32(userIdStr);
            }
            // Fallback ke session jika tidak ada di query string
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

            // Calculate and display total
            decimal total = 0;
            foreach (DataRow row in cartItems.Rows)
            {
                total += Convert.ToDecimal(row["Subtotal"]);
            }

            TotalLabel.Text = "$" + string.Format("{0:N2}", total);

            // Make the checkout button enabled only if there are items in cart
            CheckoutButton.Enabled = cartItems.Rows.Count > 0;
        }

        protected void CartGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int userId = GetUserId();
            int jewelId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "UpdateItem")
            {
                // Find the row that was clicked
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
                    // Get the quantity TextBox from the row
                    GridViewRow row = CartGridView.Rows[rowIndex];
                    TextBox quantityTextBox = (TextBox)row.FindControl("QuantityTextBox");
                    string quantityStr = quantityTextBox.Text;

                    string errorMessage = cartController.UpdateCartItemQuantity(userId, jewelId, quantityStr);
                    if (!string.IsNullOrEmpty(errorMessage))
                    {
                        // Show error message
                        ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                            $"alert('{errorMessage}');", true);
                    }
                    else
                    {
                        // Refresh the cart
                        LoadCartItems();
                    }
                }
            }
            else if (e.CommandName == "RemoveItem")
            {
                string errorMessage = cartController.RemoveCartItem(userId, jewelId);
                if (!string.IsNullOrEmpty(errorMessage))
                {
                    // Show error message
                    ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                        $"alert('{errorMessage}');", true);
                }
                else
                {
                    // Refresh the cart
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
                // Show error message
                ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                    $"alert('{errorMessage}');", true);
            }
            else
            {
                // Refresh the cart
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
                // Show error message
                ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                    $"alert('{errorMessage}');", true);
            }
            else
            {
                // Show success message and redirect
                ScriptManager.RegisterStartupScript(this, GetType(), "alert",
                    "alert('Checkout completed successfully!'); window.location='Home.aspx';", true);
            }
        }
    }
}
