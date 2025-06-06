using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using projectpsd.Handlers;
using projectpsd.Utils;
using projectpsd.Model;

namespace projectpsd.Views.Orders
{
    public partial class MyOrders : System.Web.UI.Page
    {
        private readonly OrderHandler orderHandler;
        private int currentUserId;

        public MyOrders()
        {
            orderHandler = new OrderHandler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionManager.IsCustomer())
            {
                Response.Redirect("~/Views/LoginPage.aspx");
                return;
            }

            currentUserId = SessionManager.GetCurrentUserId();

            if (!IsPostBack)
            {
                LoadOrderHistory();
            }
        }

        private void LoadOrderHistory()
        {
            var orders = orderHandler.GetCustomerOrderHistory(currentUserId);
            gvOrders.DataSource = orders;
            gvOrders.DataBind();

            if (!orders.Any())
            {
                lblMessage.Text = "You have no order history.";
                lblMessage.ForeColor = System.Drawing.Color.Blue;
            }
        }


        protected void GvOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TransactionHeader order = (TransactionHeader)e.Row.DataItem;

                Panel pnlPackageActions = (Panel)e.Row.FindControl("pnlPackageActions");
                LinkButton btnConfirmPackage = (LinkButton)e.Row.FindControl("btnConfirmPackage");
                LinkButton btnRejectPackage = (LinkButton)e.Row.FindControl("btnRejectPackage");

                if (pnlPackageActions != null)
                {
                    if (order.TransactionStatus == "Arrived")
                    {
                        pnlPackageActions.Visible = true; 
                        if (btnConfirmPackage != null) btnConfirmPackage.Visible = true;
                        if (btnRejectPackage != null) btnRejectPackage.Visible = true;
                    }
                    else
                    {
                        pnlPackageActions.Visible = false;
                        if (btnConfirmPackage != null) btnConfirmPackage.Visible = false;
                        if (btnRejectPackage != null) btnRejectPackage.Visible = false;
                    }
                }
            }
        }


        protected void GvOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblMessage.Text = "";
            int transactionId = Convert.ToInt32(e.CommandArgument);

            string result = "";
            if (e.CommandName == "ViewDetails")
            {
                Response.Redirect($"~/Views/Orders/TransactionDetail.aspx?id={transactionId}");
            }
            else if (e.CommandName == "ConfirmPackage")
            {
                result = orderHandler.ConfirmPackageReceived(transactionId, currentUserId);
            }
            else if (e.CommandName == "RejectPackage")
            {
                result = orderHandler.RejectPackage(transactionId, currentUserId);
            }


            if (!string.IsNullOrEmpty(result))
            {
                if (result.Contains("success") || result.Contains("confirmed") || result.Contains("rejected"))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = result;
                    LoadOrderHistory(); 
                }
                else
                {
                    lblMessage.ForeColor = System.Drawing.Color.Red;
                    lblMessage.Text = result;
                }
            }
        }
    }
}