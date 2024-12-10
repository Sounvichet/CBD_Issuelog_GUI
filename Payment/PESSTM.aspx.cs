using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using MasterReportClass;
using System.Drawing;
using ClosedXML.Excel;
using System.IO;


public partial class Payment_PESSTM : System.Web.UI.Page
{
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    logger _logger = new logger();
    SqlConnection sqlc = new SqlConnection();
    OracleConnection obj2 = new OracleConnection();
    PESSTMDashboard _PES = new PESSTMDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
           // ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        
        if (!IsPostBack)
        {
            txtto.Text = currentdate;
            txtfrom.Text = currentdate;
            txtgenerate.Text = currentdate;
        }
    }


    public void _getExcelfile()
    {
        _PES.P_FROM_DATE = txtfrom.Text;
        _PES.P_TO_DATE = txtto.Text;
        string datetime = DateTime.Now.ToString("yyyyMMdd");  //DateTime.Now.AddDays(-1).ToString("yyyyMMdd");
        XLWorkbook wb = new XLWorkbook();
        DataTable dt1 = _PES._D_PR_EPOWER_SETTLEMENT();
        wb.Worksheets.Add(dt1, "EPOWER");

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename= " + datetime + "EPOWER_LISTING.xlsx");

        using (MemoryStream MyMemoryStream = new MemoryStream())
        {
            wb.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx");
    }

    protected void Linkbtnapply_Click(object sender, EventArgs e)
    {
        _getExcelfile();
    }
}