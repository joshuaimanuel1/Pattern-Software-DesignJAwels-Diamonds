// Views/Jewels/JewelDetail.aspx.cs
using System;
using System.Web;
using System.Web.UI;
using projectpsd.Handlers;
using projectpsd.Model;
using projectpsd.Utils;

namespace projectpsd.Views.Jewels
{
    public partial class JewelDetail : System.Web.UI.Page
    {
        private readonly JewelHandler jewelHandler;
        private readonly CartHandler cartHandler;
        private int currentJewelId;

        public JewelDetail()
        {
            jewelHandler = new JewelHandler();
            cartHandler = new CartHandler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out currentJewelId))
                {
                    LoadJewelDetails(currentJewelId);
                    SetupActionButtons();
                }
                else
                {
                    lblErrorMessage.Text = "Jewel ID not provided or invalid.";
                    pnlJewelDetails.Visible = false;
                }
            }
        }

        private void LoadJewelDetails(int jewelId)
        {
            MsJewel jewel = jewelHandler.GetJewelDetail(jewelId);

            if (jewel != null)
            {
                lblJewelName.Text = jewel.JewelName;
                lblCategoryName.Text = jewel.MsCategory?.CategoryName;
                lblBrandName.Text = jewel.MsBrand?.BrandName;
                lblCountryOfOrigin.Text = jewel.MsBrand?.BrandCountry;
                lblBrandClass.Text = jewel.MsBrand?.BrandClass;
                lblPrice.Text = jewel.JewelPrice.ToString("C");
                lblReleaseYear.Text = jewel.JewelReleaseYear.ToString();
                pnlJewelDetails.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = "Jewel not found.";
                pnlJewelDetails.Visible = false;
            }
        }

        private void SetupActionButtons()
        {
            pnlCustomerActions.Visible = false;
            pnlAdminActions.Visible = false;

            if (SessionManager.IsLoggedIn())
            {
                if (SessionManager.IsCustomer())
                {
                    pnlCustomerActions.Visible = true;
                }
                else if (SessionManager.IsAdmin())
                {
                    pnlAdminActions.Visible = true;
                }
            }
        }

        protected void BtnAddtoCart_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            lblSuccessMessage.Text = "";

            if (!Page.IsValid)
            {
                return;
            }

            if (!int.TryParse(txtQuantity.Text, out int quantity) || quantity <= 0)
            {
                lblErrorMessage.Text = "Quantity must be a positive number.";
                return;
            }

            int userId = SessionManager.GetCurrentUserId();
            if (userId == 0)
            {
                Response.Redirect("~/Views/LoginPage.aspx");
                return;
            }

            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out currentJewelId))
            {
                string result = cartHandler.AddJewelToCart(userId, currentJewelId, quantity);

                if (result.Contains("success") || result.Contains("updated"))
                {
                    lblSuccessMessage.Text = result;
                }
                else
                {
                    lblErrorMessage.Text = result;
                }
            }
            else
            {
                lblErrorMessage.Text = "Jewel ID is missing or invalid.";
            }
        }

        protected void BtnEditJewel_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsAdmin())
            {
                Response.Redirect("~/Views/LoginPage.aspx");
                return;
            }

            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out currentJewelId))
            {
                Response.Redirect($"~/Views/Jewels/UpdateJewel.aspx?id={currentJewelId}");
            }
        }

        protected void BtnDeleteJewel_Click(object sender, EventArgs e)
        {
            if (!SessionManager.IsAdmin())
            {
                Response.Redirect("~/Views/LoginPage.aspx");
                return;
            }

            if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out currentJewelId))
            {
                string result = jewelHandler.DeleteJewel(currentJewelId);

                if (result.Contains("success"))
                {
                    lblSuccessMessage.Text = result;
                    Response.Redirect("~/Views/Jewels/Home.aspx"); // KOREKSI PATH
                }
                else
                {
                    lblErrorMessage.Text = result;
                }
            }
            else
            {
                lblErrorMessage.Text = "Jewel ID is missing or invalid for deletion.";
            }
        }
    }
}