// Views/Cart/Cart.aspx.cs
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic;
using projectpsd.Handlers;
using projectpsd.Utils;
using projectpsd.Model; // Untuk objek Cart dan MsJewel

namespace projectpsd.Views.Cart
{
    public partial class Cart : System.Web.UI.Page
    {
        private readonly CartHandler cartHandler;
        private int currentUserId;

        public Cart()
        {
            cartHandler = new CartHandler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Halaman ini hanya dapat diakses oleh Customer
            if (!SessionManager.IsCustomer())
            {
                Response.Redirect("~/Views/LoginPage.aspx"); // Redirect jika bukan Customer
                return;
            }

            currentUserId = SessionManager.GetCurrentUserId();

            if (!IsPostBack)
            {
                LoadCartItems();
            }
        }

        private void LoadCartItems()
        {
            List<projectpsd.Model.Cart> cartItems = cartHandler.GetUserCartItems(currentUserId);

            if (cartItems != null && cartItems.Any())
            {
                gvCart.DataSource = cartItems;
                gvCart.DataBind();
                CalculateTotalPrice(cartItems);
                pnlCartContent.Visible = true;
                lblMessage.Text = "";
            }
            else
            {
                gvCart.DataSource = null; // Pastikan GridView kosong
                gvCart.DataBind();
                lblTotalPrice.Text = "0.00"; // Reset total
                pnlCartContent.Visible = false; // Sembunyikan konten keranjang jika kosong
                lblMessage.Text = "Your shopping cart is empty.";
            }
        }

        private void CalculateTotalPrice(List<projectpsd.Model.Cart> cartItems)
        {
            // Ingat, JewelPrice di DB Anda adalah INT, jadi kita pakai int untuk perhitungan
            decimal total = cartItems.Sum(item => (decimal)item.Quantity * item.MsJewel.JewelPrice);
            lblTotalPrice.Text = total.ToString("C"); // Format sebagai mata uang
        }

        protected void GvCart_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblMessage.Text = ""; // Bersihkan pesan sebelumnya

            // Ambil JewelID dari CommandArgument
            int jewelId = Convert.ToInt32(e.CommandArgument);

            if (e.CommandName == "UpdateItem")
            {
                // Temukan baris GridView yang diklik
                GridViewRow row = (GridViewRow)((LinkButton)e.CommandSource).NamingContainer;
                TextBox txtQuantity = (TextBox)row.FindControl("txtQuantity");

                if (txtQuantity != null && int.TryParse(txtQuantity.Text, out int newQuantity))
                {
                    string result = cartHandler.UpdateCartItemQuantity(currentUserId, jewelId, newQuantity);
                    if (result.Contains("updated"))
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Green;
                        lblMessage.Text = result;
                        LoadCartItems(); // Muat ulang keranjang setelah update
                    }
                    else
                    {
                        lblMessage.ForeColor = System.Drawing.Color.Red;
                        lblMessage.Text = result;
                    }
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = "Invalid quantity.";
                }
            }
            else if (e.CommandName == "RemoveItem")
            {
                string result = cartHandler.RemoveCartItem(currentUserId, jewelId);
                if (result.Contains("removed"))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = result;
                    LoadCartItems(); // Muat ulang keranjang setelah hapus
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = result;
                }
            }
        }

        protected void BtnClearCart_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";
            string result = cartHandler.ClearUserCart(currentUserId);
            if (result.Contains("cleared"))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = result;
                LoadCartItems(); // Muat ulang keranjang (seharusnya kosong)
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = result;
            }
        }

        protected void BtnCheckout_Click(object sender, EventArgs e)
        {
            lblMessage.Text = "";

            if (!Page.IsValid) // Memastikan payment method sudah dipilih
            {
                return;
            }

            string paymentMethod = ddlPaymentMethod.SelectedValue;

            // Panggil Checkout dari CartHandler
            string result = cartHandler.CheckoutCart(currentUserId, paymentMethod);

            if (result.Contains("successful"))
            {
                lblMessage.ForeColor = System.Drawing.Color.Green;
                lblMessage.Text = result;
                // Redirect ke halaman My Orders atau Home setelah checkout
                Response.Redirect("~/Views/Orders/MyOrders.aspx"); // Kita akan buat halaman ini nanti
            }
            else
            {
                lblMessage.ForeColor = System.Drawing.Color.Red;
                lblMessage.Text = result;
            }
        }
    }
}