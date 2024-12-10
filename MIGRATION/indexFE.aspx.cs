using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass;

public partial class MIGRATION_indexFE : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    ReportSVMigration _mig = new ReportSVMigration();
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
        _mig._getUSERID =  Session["User_Name"].ToString();
        _drop.bindDropDownList(D_serviceType, _mig.D_get_DDL_FE());
    }
}