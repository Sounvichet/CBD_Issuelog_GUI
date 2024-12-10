using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass;
using System.Data.SqlClient;
using System.Data;
using BakongClearingDispute; 

public partial class BAKONG_summary : System.Web.UI.Page
{
    GridViewValues _grid = new GridViewValues();
    BakongReportDashboard _BakRept = new BakongReportDashboard();
    string s_ReportSQL = "";
    string s_reportCode = "";
    string s_reportFun = "";
    string s_ColHeader1 = "";
    string s_ColHeader2 = "";
    string s_FileName = "";
    string s_ReportTitle = "";
    string s_conncode = "";
    string s_provider = "";
    string s_connectstring = "";
    string S_reportname = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        if (!IsPostBack)
        {
            txtForm.Text = currentdate;
            txtTo.Text = currentdate;
            Label4.Text = GridView1.Rows.Count.ToString();
            grid_load();
        }
    }
    protected void Linkbtnapply_Click(object sender, EventArgs e)
    {
        _BakRept.P_SDATE = txtForm.Text.ToString();
        _BakRept.P_EDATE = txtTo.Text.ToString();
        _grid._GridviewBinding(GridView1, _BakRept._BAKONG_TOTAL_TRANS());
        Label4.Text = GridView1.Rows.Count.ToString();
    }
    protected void grid_load()
    {
        _BakRept.P_SDATE = txtForm.Text.ToString();
        _BakRept.P_EDATE = txtTo.Text.ToString();
        _grid._GridviewBinding(GridView1, _BakRept._BAKONG_TOTAL_TRANS());
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        this.grid_load();
        Label4.Text = GridView1.Rows.Count.ToString();
    }
}