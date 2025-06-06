using projectpsd.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace projectpsd.Master
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public Button LoginBtn => LoginButton;
        public Button LogoutBtn => LogoutButton;
        public Button RegisterBtn => RegisterButton;
        public Button CartBtn => CartButton;
        public Button ProfileBtn => ProfileButton;
        public Button HandleOrderBtn => HandleOrderButton;
        public Button MyOrdersBtn => MyOrdersButton;
        public Button ReportBtn => ReportButton;
        public Button AddJewelBtn => AddJewelButton;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string role = Session["role"] as string;

                LoginBtn.Visible = false;
                RegisterBtn.Visible = false;
                CartBtn.Visible = false;
                MyOrdersBtn.Visible = false;
                ProfileBtn.Visible = false;
                LogoutBtn.Visible = false;
                AddJewelBtn.Visible = false;
                ReportBtn.Visible = false;
                HandleOrderBtn.Visible = false;

                HomeButton.Visible = true;

                if (role == null)
                {
                    LogoutBtn.Visible = true;
                    RegisterBtn.Visible = true;
                }
                else if (role == "Customer")
                {
                    CartBtn.Visible = true;
                    MyOrdersBtn.Visible = true;
                    ProfileBtn.Visible = true;
                    LogoutBtn.Visible = true;
                }
                else if (role == "Admin")
                {
                    AddJewelBtn.Visible = true;
                    ReportBtn.Visible = true;
                    HandleOrderBtn.Visible = true;
                    ProfileBtn.Visible = true;
                    LogoutBtn.Visible = true;
                }
            }
            if (Session["user"] != null)
            {
                var user = (MsUser)Session["user"];
                GreetingLabel.Text = "Welcome, " + user.UserName;
            }
            else
            {
                GreetingLabel.Text = "";
            }
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HomePage.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void RegisterButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/RegisterPage.aspx");
        }

        protected void CartButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/CartPage.aspx");
        }

        protected void MyOrdersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/OrderPage.aspx");
        }

        protected void ProfileButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ProfilePage.aspx");
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            if (Request.Cookies["ASP.NET_SessionId"] != null)
            {
                Request.Cookies["ASP.NET_SessionId"].Expires = DateTime.Now.AddDays(-1);
            }
            if (Request.Cookies["UserEmail"] != null)
            {
                Request.Cookies["UserEmail"].Expires = DateTime.Now.AddDays(-1);
            }
            if (Request.Cookies["UserPassword"] != null)
            {
                Request.Cookies["UserPassword"].Expires= DateTime.Now.AddDays(-1);
            }
            Response.Redirect("~/Views/LoginPage.aspx");
        }

        protected void AddJewelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/JewelPage.aspx");
        }

        protected void ReportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/ReportPage.aspx");
        }

        protected void HandleOrderButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/HandleOrderPage.aspx");
        }
    }
}