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

public partial class Payment_Lyhour_trn_fee : System.Web.UI.Page
{
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    logger _logger = new logger();
    SqlConnection sqlc = new SqlConnection();
    OracleConnection obj2 = new OracleConnection();
    LyhourtrnDashboard _lyhour = new LyhourtrnDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        string previousdate = DateTime.Now.AddDays(-1).ToString("dd/MMM/yyyy").Replace('/', '-');
        if (!IsPostBack)
        {
            txtgenerate.Text = currentdate;
            txtupload.Text = currentdate;
            txtfrom.Text = previousdate;
            txtto.Text = previousdate;
            _get_currency();
        }
    }

    private void _get_currency()
    {
        DataTable dt = _lyhour._getCurrencyKHR();
        txtUSDKHR.Text = dt.Rows[1][4].ToString();
        txtTHBKHR.Text = dt.Rows[0][4].ToString();
    }
    private void _getexcelfile()
    {
        _lyhour.P_UPLOAD_DATE = txtupload.Text;
        _lyhour.P_BRN_FROM = txtfrom.Text;
        _lyhour.P_BRN_TO = txtto.Text;
        _lyhour.Exc_RateUSD = txtUSDKHR.Text;
        _lyhour.Exc_RateTHB = txtTHBKHR.Text;

        XLWorkbook wb = new XLWorkbook();
        
        DataTable dt1 = _lyhour._D_LYHOUR_DETAILS_CREDIT();
        DataTable dt2 = _lyhour._D_LYHOUR_DETAILS_DEBIT();
        DataTable dt3 = _lyhour._D_LYHOUR_MASTER_SHEET();

        wb.Worksheets.Add(dt1, "LYHOUR_DETAILS_CREDIT");
        wb.Worksheets.Add(dt2, "LYHOUR_DETAILS_DEBIT");
        wb.Worksheets.Add(dt3, "LYHOUR_MASTER_SHEET");

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename= " + txtupload.Text + "LyHour_Trn_FEE.xlsx");

        using (MemoryStream MyMemoryStream = new MemoryStream())
        {
            wb.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
    private void _exportMaster()
    {
        _lyhour.P_UPLOAD_DATE = txtupload.Text;
        _lyhour.P_BRN_FROM = txtfrom.Text;
        _lyhour.P_BRN_TO = txtto.Text;
        _lyhour.Exc_RateUSD = txtUSDKHR.Text;
        _lyhour.Exc_RateTHB = txtTHBKHR.Text;

        XLWorkbook wb = new XLWorkbook();

        DataTable dt3 = _lyhour._D_LYHOUR_MASTER_SHEET();
        wb.Worksheets.Add(dt3, "LYHOUR_MASTER_SHEET");

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename= " + txtupload.Text + ""+d_settle_type.Text+".xlsx");

        using (MemoryStream MyMemoryStream = new MemoryStream())
        {
            wb.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
    private void _exportdebit()
    {
        _lyhour.P_UPLOAD_DATE = txtupload.Text;
        _lyhour.P_BRN_FROM = txtfrom.Text;
        _lyhour.P_BRN_TO = txtto.Text;
        _lyhour.Exc_RateUSD = txtUSDKHR.Text;
        _lyhour.Exc_RateTHB = txtTHBKHR.Text;

        XLWorkbook wb = new XLWorkbook();
        DataTable dt2 = _lyhour._D_LYHOUR_DETAILS_DEBIT();
        wb.Worksheets.Add(dt2, "LYHOUR_DETAILS_DEBIT");


        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename= " + txtupload.Text + ""+d_settle_type.Text+".xlsx");

        using (MemoryStream MyMemoryStream = new MemoryStream())
        {
            wb.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
    private void _exportcredit()
    {
        _lyhour.P_UPLOAD_DATE = txtupload.Text;
        _lyhour.P_BRN_FROM = txtfrom.Text;
        _lyhour.P_BRN_TO = txtto.Text;
        _lyhour.Exc_RateUSD = txtUSDKHR.Text;
        _lyhour.Exc_RateTHB = txtTHBKHR.Text;

        XLWorkbook wb = new XLWorkbook();    
        DataTable dt1 = _lyhour._D_LYHOUR_DETAILS_CREDIT();
        wb.Worksheets.Add(dt1, "LYHOUR_DETAILS_CREDIT");

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename= " + txtupload.Text + ""+d_settle_type.Text+".xlsx");

        using (MemoryStream MyMemoryStream = new MemoryStream())
        {
            wb.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
    protected void Linkbtnapply_Click(object sender, EventArgs e)
    {
        if (d_settle_type.Text == "Master")
        {
            _exportMaster();
        }
        if (d_settle_type.Text == "Credit")
        {
            _exportcredit();
        }
        if (d_settle_type.Text == "Debit")
        {
            _exportdebit();
        }
    }

    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx"); 
    }
}