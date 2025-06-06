// Views/Jewels/Home.aspx.cs
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using projectpsd.Handlers;
using projectpsd.Utils;

namespace projectpsd.Views.Jewels
{
    public partial class Home : System.Web.UI.Page
    {
        private readonly JewelHandler jewelHandler; // Tambahkan 'readonly'

        protected void Page_Load(object sender, EventArgs e)
        {
            JewelHandler = new JewelHandler();

            if (!IsPostBack)
            {
                LoadJewels();
            }
        }

        private void LoadJewels()
        {
            var jewels = jewelHandler.GetAllJewels();
            gvJewels.DataSource = jewels;
            gvJewels.DataBind();
        }

        // Ubah nama metode menjadi PascalCase
        protected void GvJewels_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewDetails")
            {
                int jewelId = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"~/Views/Jewels/JewelDetail.aspx?id={jewelId}");
            }
        }
    }
}