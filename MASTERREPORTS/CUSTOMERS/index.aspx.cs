using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using System.Data;
using System.Net;
public partial class CUSTOMERS_index : System.Web.UI.Page
{
    
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    ReportCustDashboard _rptCus = new ReportCustDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!IsPostBack)

        {
            _getCustreportcategory();
        }
    }

    private void _getCustreportcategory()
    {
        _rptCus._userid = Session["USER_NAME"].ToString();
        _drop.bindDropDownList(D_cust_report, _rptCus._PR_GetCUSTREPORTDDL());
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}