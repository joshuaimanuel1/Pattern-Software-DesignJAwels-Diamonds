using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using projectpsd.Handlers;
using projectpsd.Utils;
using projectpsd.Model;
using System.Linq;

namespace projectpsd.Views.Orders
{
    public partial class TransactionDetail : System.Web.UI.Page
    {
        private readonly OrderHandler orderHandler;

        public TransactionDetail()
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

            if (!IsPostBack)
            {
                if (Request.QueryString["id"] != null && int.TryParse(Request.QueryString["id"], out int transactionId))
                {
                    LoadTransactionDetails(transactionId);
                }
                else
                {
                    lblErrorMessage.Text = "Transaction ID not provided or invalid.";
                    pnlTransactionDetails.Visible = false;
                }
            }
        }

        private void LoadTransactionDetails(int transactionId)
        {
            
            int currentUserId = SessionManager.GetCurrentUserId();
            TransactionHeader transaction = orderHandler.GetCustomerTransactionDetail(transactionId);

            if (transaction != null && transaction.UserID == currentUserId)
            {
                lblTransactionId.Text = transaction.TransactionID.ToString();
                lblTransactionDate.Text = transaction.TransactionDate.ToShortDateString();
                lblPaymentMethod.Text = transaction.PaymentMethod;
                lblStatus.Text = transaction.TransactionStatus;

                
                gvTransactionItems.DataSource = transaction.TransactionDetails.ToList();
                gvTransactionItems.DataBind();
http://localhost:64151/Views/Orders/TransactionDetail.aspx.cs
                pnlTransactionDetails.Visible = true;
            }
            else
            {
                lblErrorMessage.Text = "Transaction not found or you don't have permission to view it.";
                pnlTransactionDetails.Visible = false;
            }
        }
    }
}