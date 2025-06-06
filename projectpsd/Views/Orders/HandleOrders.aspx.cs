using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using projectpsd.Handlers;
using projectpsd.Utils;
using projectpsd.Model;

namespace projectpsd.Views.Orders
{
    public partial class HandleOrders : System.Web.UI.Page
    {
        private readonly OrderHandler orderHandler;

        public HandleOrders()
        {
            orderHandler = new OrderHandler();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!SessionManager.IsAdmin())
            {
                Response.Redirect("~/Views/LoginPage.aspx"); 
                return;
            }

            if (!IsPostBack)
            {
                LoadUnfinishedOrders();
            }
        }

        private void LoadUnfinishedOrders()
        {
            var orders = orderHandler.GetUnfinishedOrdersForAdmin();
            gvUnfinishedOrders.DataSource = orders;
            gvUnfinishedOrders.DataBind();

            if (!orders.Any())
            {
                lblMessage.Text = "No unfinished orders to display.";
                lblMessage.ForeColor = System.Drawing.Color.Blue;
            }
            else
            {
                lblMessage.Text = "";
            }
        }

        protected void GvUnfinishedOrders_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                TransactionHeader order = (TransactionHeader)e.Row.DataItem;

                LinkButton btnConfirmPayment = (LinkButton)e.Row.FindControl("btnConfirmPayment");
                LinkButton btnShipPackage = (LinkButton)e.Row.FindControl("btnShipPackage");
                Label lblWaitingConfirm = (Label)e.Row.FindControl("lblWaitingConfirm");

                if (btnConfirmPayment != null) btnConfirmPayment.Visible = false;
                if (btnShipPackage != null) btnShipPackage.Visible = false;
                if (lblWaitingConfirm != null) lblWaitingConfirm.Visible = false;

                if (order.TransactionStatus == "Payment Pending")
                {
                    if (btnConfirmPayment != null) btnConfirmPayment.Visible = true;
                }
                else if (order.TransactionStatus == "Shipment Pending")
                {
                    if (btnShipPackage != null) btnShipPackage.Visible = true;
                }
                else if (order.TransactionStatus == "Arrived")
                {
                    if (lblWaitingConfirm != null) lblWaitingConfirm.Visible = true;
                }
            }
        }

        protected void GvUnfinishedOrders_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            lblMessage.Text = "";
            int transactionId = Convert.ToInt32(e.CommandArgument);

            string result = "";
            if (e.CommandName == "ConfirmPayment")
            {
                result = orderHandler.ConfirmPayment(transactionId);
            }
            else if (e.CommandName == "ShipPackage")
            {
                result = orderHandler.ShipPackage(transactionId);
            }

            if (!string.IsNullOrEmpty(result))
            {
                if (result.Contains("confirmed") || result.Contains("shipped"))
                {
                    lblMessage.ForeColor = System.Drawing.Color.Green;
                    lblMessage.Text = result;
                    LoadUnfinishedOrders();
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