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
    public partial class Home : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadJewels();
            }
        }

        private void LoadJewels()
        {
            try
            {
                List<MsJewel> jewels = JewelHandler.GetAllJewels();

                if (jewels != null && jewels.Count > 0)
                {
                    JewelsRepeater.DataSource = jewels;
                    JewelsRepeater.DataBind();
                }
                else
                {
                    JewelsRepeater.DataSource = null;
                    JewelsRepeater.DataBind();

                    ErrorLabel.Text = "No jewelry items found.";
                    ErrorLabel.Visible = true;
                }
            }
            catch (Exception ex)
            {
                ErrorLabel.Text = "Error loading jewelry: " + ex.Message;
                ErrorLabel.Visible = true;
            }
        }
    }
}