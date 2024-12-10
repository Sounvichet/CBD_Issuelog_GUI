using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.IO;

public partial class MIGRATION_smcaactcon : System.Web.UI.Page
{

    SqlConnection sqlc = new SqlConnection();
    SqlConnectAndSqlCommand _getsqlcon = new SqlConnectAndSqlCommand();
    SV_Migration _mig = new SV_Migration();
    ReportSVMigration _svmig = new ReportSVMigration();
    DataTable CSVTable = new DataTable();
    DropDownListValues _drop = new DropDownListValues();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!IsPostBack)
        {
            _getDDL_FROM_BRN();
            _getDDL_TO_BRN();
        }
    }
    public void _getDDL_FROM_BRN()
    {

        _drop.bindDropDownList(d_f_branch, _mig.D_get_branch());
    }
    public void _getDDL_TO_BRN()
    {

        _drop.bindDropDownList(d_t_branch, _mig.D_get_branch());
    }
    public void _ExportGenerate()
    {
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        _mig._P_F_BRN = d_f_branch.SelectedValue.ToString();
        _mig._P_T_BRN = d_t_branch.SelectedValue.ToString();
        var workbook = new XLWorkbook();
        DataTable dt1 = _mig.D_get_card_account_summary_recon();
        workbook.Worksheets.Add(dt1, "Summary_CardAccount_Recon");
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=Smy_CardAccount"+ _mig._P_T_BRN + ".xlsx");

        using (MemoryStream MyMemoryStream = new MemoryStream())
        {
            workbook.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
    protected void Linkbtnapply_Click(object sender, EventArgs e)
    {
        _ExportGenerate();
    }

    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("migration_dashboard.aspx");
    }
}