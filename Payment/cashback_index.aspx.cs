using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass;

public partial class Payment_cashback_index : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    ReportCASHBACKDashboard _CASH = new ReportCASHBACKDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            _getdropdownlist();
        }
    }
    public void _getdropdownlist()
    {

        _drop.bindDropDownList(D_serviceType, _CASH.D_CASH_DDL(Session["USERID"].ToString()));
    }
}