// Views/Jewels/Home.aspx.cs
using System;
using System.Web.UI;
using System.Web.UI.WebControls; // <-- PASTIKAN INI ADA
using projectpsd.Handlers;
using projectpsd.Utils;

namespace projectpsd.Views.Jewels // PASTIKAN NAMESPACE INI BENAR
{
    public partial class Home : System.Web.UI.Page
    {
        private readonly JewelHandler jewelhandler; // Line 12 (seperti di error Anda)

        // !!! INI ADALAH KONSTRUKTOR. PASTIKAN PERSIS SEPERTI INI. !!!
        // Constructor dieksekusi sebelum Page_Load, dan ini satu-satunya tempat untuk menginisialisasi readonly field.
        public Home()
        {
            jewelhandler = new JewelHandler(); // Baris inisialisasi yang benar
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // HAPUS BARIS INI JIKA ADA:
            // jewelHandler = new JewelHandler(); // Ini kemungkinan menyebabkan error CS0118 di Line 16
            // karena Anda mencoba menginisialisasi readonly field dua kali
            // atau di tempat yang salah.

            if (!IsPostBack)
            {
                LoadJewels();
            }
        }

        private void LoadJewels()
        {
            // Pastikan ini memanggil instance variable 'jewelHandler' (huruf kecil 'j')
            var jewels = jewelhandler.GetAllJewels(); // Line 27 (seperti di error Anda)
            gvJewels.DataSource = jewels;              // Line 28 (seperti di error Anda)
            gvJewels.DataBind();
        }

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

//5645da57f92fbd85e8a3462ad97f2e2e1dd0339e09dd96f95499a8de3d7b4b05