using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FinalProjectPSD.Handler;
using FinalProjectPSD.Repository;
using FinalProjectPSD.Model;

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
            // Create handler instance using the repository
            JewelHandler jewelHandler = new JewelHandler();

            // Get all jewels
            List<MsJewel> jewels = jewelHandler.GetAllJewels();

            // Bind the data to the repeater
            JewelRepeater.DataSource = jewels;
            JewelRepeater.DataBind();
        }
    }
}