using System;
using System.Web.UI;
using projectpsd.Utils;
using projectpsd.Handlers;
using projectpsd.Model;
using System.Web.UI.HtmlControls;
using projectpsd.Views.Jewels;

namespace projectpsd.Master
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        private readonly AuthHandler authHandler;

        public MasterPage()
        {
            authHandler = new AuthHandler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!SessionManager.IsLoggedIn())
                {
                    MsUser autoLoggedInUser = authHandler.TryAutoLoginFromCookie();
                    if (autoLoggedInUser != null)
                    {
                        Response.Redirect("~/Views/Jewels/Home.aspx");
                        return;
                    }
                }
                UpdateNavigationBarVisibility();
            }
        }

        private void UpdateNavigationBarVisibility()
        {
            HomeButton.Visible = false;
            LoginButton.Visible = false;
            RegisterButton.Visible = false;
            CartButton.Visible = false;
            MyOrdersButton.Visible = false;
            ProfileButton.Visible = false;
            LogoutButton.Visible = false;
            AddJewelButton.Visible = false;
            ReportButton.Visible = false;
            HandleOrderButton.Visible = false;
            GreetingLabel.Visible = false;

            if (SessionManager.IsLoggedIn())
            {
                GreetingLabel.Text = "Welcome, " + SessionManager.GetCurrentUserName();
                GreetingLabel.Visible = true;

                HomeButton.Visible = true;
                ProfileButton.Visible = true;
                LogoutButton.Visible = true;

                if (SessionManager.IsAdmin())
                {
                    AddJewelButton.Visible = true;
                    ReportButton.Visible = true;
                    HandleOrderButton.Visible = true;
                }
                else if (SessionManager.IsCustomer())
                {
                    CartButton.Visible = true;
                    MyOrdersButton.Visible = true;
                }
            }
            else
            {
                HomeButton.Visible = true;
                LoginButton.Visible = true;
                RegisterButton.Visible = true;
            }
        }

        protected void HomeButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Jewels/Home.aspx");
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
            Response.Redirect("~/Views/Cart/Cart.aspx");
        }

        protected void MyOrdersButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Orders/MyOrders.aspx");
        }

        protected void ProfileButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Profile/Profile.aspx");
        }

        protected void AddJewelButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Jewels/AddJewel.aspx");
        }

        protected void ReportButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Reports/Reports.aspx");
        }

        protected void HandleOrderButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Views/Orders/HandleOrders.aspx");
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            authHandler.LogoutUser();
            Response.Redirect("~/Views/LoginPage.aspx");
        }
    }
}