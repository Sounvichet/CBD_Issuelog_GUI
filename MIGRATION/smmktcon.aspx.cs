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

public partial class MIGRATION_smmktcon : System.Web.UI.Page
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
    }

    public void _ExportGenerate()
    {
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        //_mig._P_F_BRN = d_f_branch.SelectedValue.ToString();
        //_mig._P_T_BRN = d_t_branch.SelectedValue.ToString();
        var workbook = new XLWorkbook();
        DataTable dt1 = _mig.D_get_acq_Recon();
        DataTable dt2 = _mig.D_get_acq_BO1_Recon();
        DataTable dt3 = _mig.D_get_acq_BO2_Recon();
        workbook.Worksheets.Add(dt1, "acq_term_Recon");
        workbook.Worksheets.Add(dt2, "acq_term_Recon_BO1");
        workbook.Worksheets.Add(dt3, "acq_term_Recon_BO2");
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=acq_term_Recon.xlsx");

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