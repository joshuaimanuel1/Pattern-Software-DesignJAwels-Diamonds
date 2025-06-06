// Views/Jewels/UpdateJewel.aspx.cs
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using projectpsd.Handlers;
using projectpsd.Utils;
using projectpsd.Model;

namespace projectpsd.Views.Jewels
{
    public partial class UpdateJewel : System.Web.UI.Page
    {
        private readonly JewelHandler jewelHandler;

        public UpdateJewel()
        {
            jewelHandler = new JewelHandler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Halaman ini hanya dapat diakses oleh Admin
            if (!SessionManager.IsAdmin())
            {
                Response.Redirect("~/Views/LoginPage.aspx"); // Redirect jika bukan Admin
                return;
            }

            if (!IsPostBack)
            {
                LoadDropdowns();
                // Muat data jewel yang akan diupdate
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int jewelId))
                {
                    LoadJewelData(jewelId);
                }
                else
                {
                    lblErrorMessage.Text = "Jewel ID not provided or invalid for update.";
                    pnlJewelForm.Visible = false;
                }
            }
        }

        private void LoadDropdowns()
        {
            var categories = jewelHandler.GetAllCategories();
            ddlCategory.DataSource = categories;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CategoryID";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", ""));

            var brands = jewelHandler.GetAllBrands();
            ddlBrand.DataSource = brands;
            ddlBrand.DataTextField = "BrandName";
            ddlBrand.DataValueField = "BrandID";
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("-- Select Brand --", ""));
        }

        private void LoadJewelData(int jewelId)
        {
            MsJewel jewel = jewelHandler.GetJewelDetail(jewelId);

            if (jewel != null)
            {
                hfJewelId.Value = jewel.JewelID.ToString();
                txtJewelName.Text = jewel.JewelName;
                ddlCategory.SelectedValue = jewel.CategoryID.ToString();
                ddlBrand.SelectedValue = jewel.BrandID.ToString();
                txtPrice.Text = jewel.JewelPrice.ToString();
                txtReleaseYear.Text = jewel.JewelReleaseYear.ToString();
                pnlJewelForm.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = "Jewel not found for update.";
                pnlJewelForm.Visible = false;
            }
        }

        protected void ValidateJewelNameLength(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ValidationHelper.IsLengthBetween(args.Value, 3, 25);
        }

        protected void ValidateReleaseYear(object source, ServerValidateEventArgs args)
        {
            if (int.TryParse(args.Value, out int year))
            {
                args.IsValid = ValidationHelper.IsJewelReleaseYearValid(year);
            }
            else
            {
                args.IsValid = false;
            }
        }

        protected void BtnUpdateJewel_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            lblSuccessMessage.Text = "";

            if (!Page.IsValid)
            {
                return;
            }

            int jewelId = int.Parse(hfJewelId.Value); // Ambil JewelID dari HiddenField
            string jewelName = txtJewelName.Text;
            int categoryId = int.Parse(ddlCategory.SelectedValue);
            int brandId = int.Parse(ddlBrand.SelectedValue);
            int price = int.Parse(txtPrice.Text);
            int releaseYear = int.Parse(txtReleaseYear.Text);

            string result = jewelHandler.UpdateExistingJewel(jewelId, jewelName, categoryId, brandId, price, releaseYear);

            if (result == "Jewel updated successfully.")
            {
                lblSuccessMessage.Text = result;
                // Opsional: Redirect ke detail jewel atau home
                // Response.Redirect($"~/Views/Jewels/JewelDetail.aspx?id={jewelId}");
            }
            else
            {
                lblErrorMessage.Text = result;
            }
        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Jewels/Home.aspx"); // Redirect ke Home Page
        }
    }
}