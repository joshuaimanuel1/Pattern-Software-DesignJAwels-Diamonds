// Views/Jewels/AddJewel.aspx.cs
using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using projectpsd.Handlers;
using projectpsd.Utils;
using projectpsd.Model; // Untuk MsCategory dan MsBrand

namespace projectpsd.Views.Jewels
{
    public partial class AddJewel : System.Web.UI.Page
    {
        private readonly JewelHandler jewelHandler;

        public AddJewel()
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
            }
        }

        private void LoadDropdowns()
        {
            // Muat kategori
            var categories = jewelHandler.GetAllCategories();
            ddlCategory.DataSource = categories;
            ddlCategory.DataTextField = "CategoryName"; // Nama properti untuk ditampilkan
            ddlCategory.DataValueField = "CategoryID";   // Nama properti untuk nilai (ID)
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("-- Select Category --", "")); // Tambah item default

            // Muat brand
            var brands = jewelHandler.GetAllBrands();
            ddlBrand.DataSource = brands;
            ddlBrand.DataTextField = "BrandName"; // Nama properti untuk ditampilkan
            ddlBrand.DataValueField = "BrandID";   // Nama properti untuk nilai (ID)
            ddlBrand.DataBind();
            ddlBrand.Items.Insert(0, new ListItem("-- Select Brand --", "")); // Tambah item default
        }

        // Custom Validator untuk panjang Jewel Name
        protected void ValidateJewelNameLength(object source, ServerValidateEventArgs args)
        {
            args.IsValid = ValidationHelper.IsLengthBetween(args.Value, 3, 25);
        }

        // Custom Validator untuk Release Year
        protected void ValidateReleaseYear(object source, ServerValidateEventArgs args)
        {
            if (int.TryParse(args.Value, out int year))
            {
                args.IsValid = ValidationHelper.IsJewelReleaseYearValid(year);
            }
            else
            {
                args.IsValid = false; // Jika tidak bisa di-parse sebagai integer
            }
        }

        protected void BtnAddJewel_Click(object sender, EventArgs e)
        {
            lblErrorMessage.Text = "";
            lblSuccessMessage.Text = "";

            if (!Page.IsValid) // Validasi dari RequiredFieldValidator, RangeValidator, CustomValidator
            {
                return;
            }

            string jewelName = txtJewelName.Text;
            int categoryId = int.Parse(ddlCategory.SelectedValue);
            int brandId = int.Parse(ddlBrand.SelectedValue);
            int price = int.Parse(txtPrice.Text); // JewelPrice adalah INT
            int releaseYear = int.Parse(txtReleaseYear.Text);

            // Delegasikan ke Handler
            string result = jewelHandler.AddNewJewel(jewelName, categoryId, brandId, price, releaseYear);

            if (result == "Jewel added successfully.")
            {
                lblSuccessMessage.Text = result;
                // Bersihkan form setelah sukses
                txtJewelName.Text = "";
                ddlCategory.SelectedIndex = 0;
                ddlBrand.SelectedIndex = 0;
                txtPrice.Text = "";
                txtReleaseYear.Text = "";
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