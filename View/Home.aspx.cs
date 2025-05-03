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
            JewelHandler jewelHandler = new JewelHandler();

            List<MsJewel> jewels = jewelHandler.GetAllJewels();

            JewelGridView.DataSource = jewels;
            JewelGridView.DataBind();
        }

        protected void JewelGridView_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            JewelGridView.PageIndex = e.NewPageIndex;
            LoadJewels();
        }
    }
}