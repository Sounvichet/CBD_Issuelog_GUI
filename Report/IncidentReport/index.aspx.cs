using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Report_IncidentReport_index : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    MissionDashBoard _miss = new MissionDashBoard();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    ReportIncident _icident = new ReportIncident();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            Bind_report_name();
        }
    }

    public void Bind_report_name()
    {
         _drop.bindDropDownList(T_report_name, _icident.D_Incident_DDL(Session["USER_NAME"].ToString()));
        //_drop.bindDropDownList(T_report_name, _icident.D_Incident_DDL(Session["User_Name"].ToString())
    }
}