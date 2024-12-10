using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;
using MasterReportClass;
using System.Data.OracleClient;
using System.Web.UI;


public partial class Card_report : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    dbcon obj1 = new dbcon();
    OracleConnection orac = new OracleConnection();
    string getreportcode;
    DataTable dt = new DataTable();
    string s_ReportSQL = "";
    string s_reportFun = "";
    string s_ColHeader1 = "";
    string s_ColHeader2 = "";
    string s_FileName = "";
    string s_ReportTitle = "";
    string s_conncode = "";
    string s_provider = "";
    string s_connectstring = "";
    string S_reportname = "";
    Dialy_currentEOD obj2 = new Dialy_currentEOD();
    Dialy_backdateEOD obj3 = new Dialy_backdateEOD();
    NBC_Report obj13 = new NBC_Report();
    DropDownListValues _drop = new DropDownListValues();
    ReportCards _Cards = new ReportCards();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    RadioListValues _radio = new RadioListValues();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {

            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!this.IsPostBack)
        {
            _bind_reportcat();
            _select_date();
            _SelectToday();
        }
    }
    public void _bind_reportcat()
    {
        _drop.bindDropDownList(D_Report_type, _Cards.D_Bind_reportname(Session["USER_NAME"].ToString()));
    }
    private void _select_date()
    {
        _drop.bindDropDownList(D_selectDate, _Cards.D_Select_date());
    }
    public void _SelectToday()
    {
        try
        {
            DataTable dt = _Cards.D_Select_date_today();
            D_selectDate.SelectedValue = dt.Rows[0]["LookupCode"].ToString();
            _Frequency_Fundamental(D_selectDate.SelectedValue);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }



    }
    public void _Frequency_Fundamental(string lookup)
    {
        DataTable dt = _Cards.D_Frequency_Fundamental(lookup);
        if (dt.Rows.Count == 0)
        {
            Response.Write("<script>alert('Not Yet implement!')</script>");
        }
        if (dt.Rows.Count > 0)
        {
            T_From.Text = dt.Rows[0][3].ToString();
            T_To.Text = dt.Rows[0][4].ToString();
        }
    }
    private void getexcel()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = D_issue(s_ReportSQL);
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PR()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = D_issue_PR(s_ReportSQL);
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR2_FEDB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_FEDB(s_ReportSQL, DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR2_FESB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_FESB(s_ReportSQL, DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR2_BODB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_BODB(s_ReportSQL, DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR2_BOSB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_BOSB(s_ReportSQL, DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR2_HKLDR()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_HKLDR(s_ReportSQL, DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR2_HKLPRD()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_HKLPRD(s_ReportSQL, DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR2_ISSUELOG()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_ISSUELOG(s_ReportSQL, DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    // Sub Void for PAR2_end 
    private void getexcel_PAR2_end_FEDB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_end_FEDB(s_ReportSQL, DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR2_end_FESB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_end_FESB(s_ReportSQL, DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR2_end_BODB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_end_BODB(s_ReportSQL, DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR2_end_BOSB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_end_BOSB(s_ReportSQL, DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR2_end_HKLDR()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_end_HKLDR(s_ReportSQL, DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR2_end_HKLPRD()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_end_HKLPRD(s_ReportSQL, DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR2_end_ISSUELOG()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_end_ISSUELOG(s_ReportSQL, DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    //sub for Par1_start
    private void getexcel_PAR1_Start_FEDB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P1_Start_FEDB(s_ReportSQL, DateTime.Parse(T_From.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");

        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR1_Start_FESB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P1_Start_FESB(s_ReportSQL, DateTime.Parse(T_From.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR1_Start_BODB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P1_Start_BODB(s_ReportSQL, DateTime.Parse(T_From.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR1_Start_BOSB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P1_Start_BOSB(s_ReportSQL, DateTime.Parse(T_From.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR1_Start_HKLDR()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P1_Start_HKLDR(s_ReportSQL, DateTime.Parse(T_From.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR1_Start_HKLPRD()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P1_Start_HKLPRD(s_ReportSQL, DateTime.Parse(T_From.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_PAR1_Start_ISSUELOG()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P1_Start_ISSUELOG(s_ReportSQL, DateTime.Parse(T_From.Text));
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_Dialy_currentEOD()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();
        DataTable dt6 = new DataTable();
        dt1 = obj2.D_CardPending(DateTime.Parse(T_From.Text));
        dt2 = obj2.D_Cardrequestreport(DateTime.Parse(T_From.Text));
        dt3 = obj2.D_FingerPrintByterminal(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt4 = obj2.D_FingerPrintByDevice(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt5 = obj2.D_FingerPrintByUser(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt6 = obj2.D_Postcashtofromatm(DateTime.Parse(T_From.Text), DateTime.Parse(T_From.Text));
        wb.Worksheets.Add(dt1, "CardPending");
        wb.Worksheets.Add(dt2, "Cardrequestreport");
        wb.Worksheets.Add(dt3, "FingerPrintByterminal");
        wb.Worksheets.Add(dt4, "FingerPrintByDevice");
        wb.Worksheets.Add(dt5, "FingerPrintByUser");
        wb.Worksheets.Add(dt6, "Postcashtofromatm");

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_Dialy_backdateEOD()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();
        dt1 = obj3.D_ATM_MB_respcode(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt2 = obj3.D_Daily_ATM_MB_listing(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt3 = obj3.D_MB_Daily_TRN_Report(DateTime.Parse(T_From.Text));
        dt4 = obj3.D_MB_TRNCount_BY_RespCode(DateTime.Parse(T_From.Text));
        dt5 = obj3.D_Terminal_today(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        wb.Worksheets.Add(dt1, "ATM_MB_respcode");
        wb.Worksheets.Add(dt2, "Daily_ATM_MB_listing");
        wb.Worksheets.Add(dt3, "MB_Daily_TRN_Report");
        wb.Worksheets.Add(dt4, "MB_TRNCount_BY_RespCode");
        wb.Worksheets.Add(dt5, "Terminal_today");

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void getexcel_NBCREPORT()
    {
        XLWorkbook wb = new XLWorkbook();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        DataTable dt3 = new DataTable();
        DataTable dt4 = new DataTable();
        DataTable dt5 = new DataTable();
        DataTable dt6 = new DataTable();
        DataTable dt7 = new DataTable();
        DataTable dt8 = new DataTable();
        DataTable dt9 = new DataTable();
        DataTable dt10 = new DataTable();
        DataTable dt11 = new DataTable();
        DataTable dt12 = new DataTable();
        DataTable dt13 = new DataTable();
        DataTable dt14 = new DataTable();
        DataTable dt15 = new DataTable();
        DataTable dt16 = new DataTable();
        DataTable dt17 = new DataTable();
        DataTable dt18 = new DataTable();
        DataTable dt19 = new DataTable();
        DataTable dt20 = new DataTable();
        dt1 = obj13.P_TOTAL_CARD_ISSUE_FE(DateTime.Parse(T_To.Text));
        dt2 = obj13.P_NUMBER_ATM_WITHDRAWAL_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt3 = obj13.P_AMOUNT_ATM_WITHDRAWAL_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt4 = obj13.P_NUMBERE_ATM_DEPOSIT_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt5 = obj13.P_AMOUNT_ATM_DEPOSIT_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt6 = obj13.P_NUMBER_ATM_PAYMENT_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt7 = obj13.P_AMOUNT_ATM_PAYMENT_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt8 = obj13.P_MB_UTILITY_PAYMENT_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt9 = obj13.P_MB_FT_KHR_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt10 = obj13.P_MB_FT_USD_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt11 = obj13.P_Card_Issue_FE(DateTime.Parse(T_To.Text));
        dt12 = obj13.P_NUM_ATM_WITHDRAWAL_LIST_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt13 = obj13.P_AMT_ATM_WITHDRAWAL_LIST_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt14 = obj13.P_NUM_ATM_DEPOSIT_LIST_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt15 = obj13.P_AMT_ATM_DEPOSIT_LIST_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt16 = obj13.P_NUM_ATM_PAYMENT_LIST_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt17 = obj13.P_AMT_ATM_PAYMENT_LIST_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt18 = obj13.P_MB_UTILITY_LIST_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt19 = obj13.P_MB_FT_KHR_LIST_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));
        dt20 = obj13.P_MB_FT_USD_LIST_FE(DateTime.Parse(T_From.Text), DateTime.Parse(T_To.Text));

        wb.Worksheets.Add(dt1, "TOTAL_CARD_ISSUE_FE");
        wb.Worksheets.Add(dt2, "NUMBER_ATM_WITHDRAWAL_FE");
        wb.Worksheets.Add(dt3, "AMOUNT_ATM_WITHDRAWAL_FE");
        wb.Worksheets.Add(dt4, "NUMBERE_ATM_DEPOSIT_FE");
        wb.Worksheets.Add(dt5, "AMOUNT_ATM_DEPOSIT_FE");
        wb.Worksheets.Add(dt6, "NUMBER_ATM_PAYMENT_FE");
        wb.Worksheets.Add(dt7, "AMOUNT_ATM_PAYMENT_FE");
        wb.Worksheets.Add(dt8, "MB_UTILITY_PAYMENT_FE");
        wb.Worksheets.Add(dt9, "MB_FT_KHR_FE");
        wb.Worksheets.Add(dt10, "MB_FT_USD_FE");
        wb.Worksheets.Add(dt11, "Card_Issue_FE");
        wb.Worksheets.Add(dt12, "NUM_ATM_WITHDRAWAL_LIST_FE");
        wb.Worksheets.Add(dt13, "AMT_ATM_WITHDRAWAL_LIST_FE");
        wb.Worksheets.Add(dt14, "NUM_ATM_DEPOSIT_LIST_FE");
        wb.Worksheets.Add(dt15, "AMT_ATM_DEPOSIT_LIST_FE");
        wb.Worksheets.Add(dt16, "NUM_ATM_PAYMENT_LIST_FE");
        wb.Worksheets.Add(dt17, "AMT_ATM_PAYMENT_LIST_FE");
        wb.Worksheets.Add(dt18, "MB_UTILITY_LIST_FE");
        wb.Worksheets.Add(dt19, "MB_FT_KHR_LIST_FE");
        wb.Worksheets.Add(dt20, "MB_FT_USD_LIST_FE");

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
    }
    private void rbl_report_listingname()
    {
        _radio.bindRadioButtonList(rbl_report_listing, _Cards.D_Bind_reportcode(D_Report_type.SelectedValue));
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        string getValue = "";
        foreach (ListItem li in rbl_report_listing.Items)
        {
            if (li.Selected == true)
            {
                string getreportsql = "";
                // getreportsql += cb_report.Items[0].Value;
                getreportsql += rbl_report_listing.Text;
                v_bind_sql_text(getreportsql);
                if (s_reportFun != "SPRS")
                {
                    getexcel();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "ISSUELOG")
                {
                    getexcel_PAR2_ISSUELOG();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "FEDB")
                {
                    getexcel_PAR2_FEDB();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "FESB")
                {
                    getexcel_PAR2_FESB();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "BODB")
                {
                    getexcel_PAR2_BODB();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "BOSB")
                {
                    getexcel_PAR2_BOSB();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "HKLDR")
                {
                    getexcel_PAR2_HKLDR();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "HKLPRD")
                {
                    getexcel_PAR2_HKLPRD();
                }
                /// Sub Function for Procedure with Par As of date
                if (s_reportFun == "SPRS" && s_ColHeader1 == "" && s_ColHeader2 == "End_date" && s_conncode == "ISSUELOG")
                {
                    getexcel_PAR2_end_ISSUELOG();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "" && s_ColHeader2 == "End_date" && s_conncode == "FEDB")
                {
                    getexcel_PAR2_end_FEDB();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "" && s_ColHeader2 == "End_date" && s_conncode == "FESB")
                {
                    getexcel_PAR2_end_FESB();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "" && s_ColHeader2 == "End_date" && s_conncode == "BODB")
                {
                    getexcel_PAR2_end_BODB();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "" && s_ColHeader2 == "End_date" && s_conncode == "BOSB")
                {
                    getexcel_PAR2_end_BOSB();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "" && s_ColHeader2 == "End_date" && s_conncode == "HKLDR")
                {
                    getexcel_PAR2_end_HKLPRD();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "" && s_ColHeader2 == "End_date" && s_conncode == "HKLPRD")
                {
                    getexcel_PAR2_end_HKLPRD();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "ISSUELOG")
                {
                    getexcel_PAR1_Start_ISSUELOG();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "FEDB")
                {
                    getexcel_PAR1_Start_FEDB();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "FESB")
                {
                    getexcel_PAR1_Start_FESB();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "BODB")
                {
                    getexcel_PAR1_Start_BODB();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "BOSB")
                {
                    getexcel_PAR1_Start_BOSB();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "HKLDR")
                {
                    getexcel_PAR1_Start_HKLDR();
                }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "HKLPRD")
                {
                    getexcel_PAR1_Start_HKLPRD();
                }
                if (s_reportFun == "SPRS" && S_reportname == "DialycurrentEOD" && s_ColHeader1 == "" && s_ColHeader2 == "")
                {
                    getexcel_Dialy_currentEOD();
                }
                if (s_reportFun == "SPRS" && S_reportname == "DialybackdateEOD" && s_ColHeader1 == "" && s_ColHeader2 == "")
                {
                    getexcel_Dialy_backdateEOD();
                }
                if (s_reportFun == "SPRS" && S_reportname == "NBCREPORT_all" && s_ColHeader1 == "" && s_ColHeader2 == "")
                {
                    getexcel_NBCREPORT();
                }
                if (s_ColHeader1 == "Start_date" && s_ColHeader2 == "")
                {

                }
                if (s_ColHeader1 == "" && s_ColHeader2 == "End_date")
                {

                }

            }
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "window.location='" + Request.ApplicationPath + "index.aspx';", true);
    }
    protected void D_Report_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        rbl_report_listingname();
    }
    private DataTable getdatatable_CMD(string Report_Sql)
    {
        DataTable dt = new DataTable();
        try
        {
            sqlc.ConnectionString = obj1.Sqlcon();
            sqlc.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = Report_Sql;
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable D_issue(string Report_Sql)

    {
        DataTable dt = new DataTable();
        try
        {
            sqlc.ConnectionString = obj1.Sqlcon();
            sqlc.Open();
            SqlDataAdapter adt = new SqlDataAdapter("", sqlc);
            adt.SelectCommand.CommandText = Report_Sql;
            adt.SelectCommand.CommandType = CommandType.Text;
            adt.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable D_issue_PR(string Report_Sql)

    {
        DataTable dt = new DataTable();
        try
        {
            sqlc.ConnectionString = obj1.Sqlcon();
            sqlc.Open();
            SqlDataAdapter adt = new SqlDataAdapter("", sqlc);
            adt.SelectCommand.CommandText = Report_Sql;
            adt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adt.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable D_issue_PR_P1(string Report_Sql, string par1)

    {
        DataTable dt = new DataTable();
        try
        {
            sqlc.ConnectionString = obj1.Sqlcon();
            sqlc.Open();
            SqlDataAdapter adt = new SqlDataAdapter("", sqlc);
            adt.SelectCommand.CommandText = Report_Sql;
            adt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adt.SelectCommand.Parameters.AddWithValue("S_DATE", par1);
            adt.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_ISSUELOG(string Report_Sql, DateTime par1, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {

            sqlc.ConnectionString = s_connectstring;
            sqlc.Open();
            SqlDataAdapter adt = new SqlDataAdapter(Report_Sql, sqlc);
            adt.SelectCommand.CommandText = Report_Sql;
            adt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adt.SelectCommand.Parameters.AddWithValue("@Start_date", par1);
            adt.SelectCommand.Parameters.AddWithValue("@End_date", par2);
            adt.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
    }
    private DataTable Dt_PR_P2_HKLPRD(string Report_Sql, DateTime par1, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_SDATE", OracleType.DateTime).Value = par1;
            cmd.Parameters.AddWithValue("P_EDATE", OracleType.DateTime).Value = par2;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_HKLDR(string Report_Sql, DateTime par1, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_SDATE", OracleType.DateTime).Value = par1;
            cmd.Parameters.AddWithValue("P_EDATE", OracleType.DateTime).Value = par2;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_FESB(string Report_Sql, DateTime par1, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_SDATE", OracleType.DateTime).Value = par1;
            cmd.Parameters.AddWithValue("P_EDATE", OracleType.DateTime).Value = par2;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_FEDB(string Report_Sql, DateTime par1, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_SDATE", OracleType.DateTime).Value = par1;
            cmd.Parameters.AddWithValue("P_EDATE", OracleType.DateTime).Value = par2;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_BOSB(string Report_Sql, DateTime par1, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_SDATE", OracleType.DateTime).Value = par1;
            cmd.Parameters.AddWithValue("P_EDATE", OracleType.DateTime).Value = par2;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_BODB(string Report_Sql, DateTime par1, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_SDATE", OracleType.DateTime).Value = par1;
            cmd.Parameters.AddWithValue("P_EDATE", OracleType.DateTime).Value = par2;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    //sub Datable for par 1
    private DataTable Dt_PR_P2_end_ISSUELOG(string Report_Sql, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {
            sqlc.ConnectionString = s_connectstring;
            sqlc.Open();
            SqlDataAdapter adt = new SqlDataAdapter(Report_Sql, sqlc);
            adt.SelectCommand.CommandText = Report_Sql;
            adt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adt.SelectCommand.Parameters.AddWithValue("@End_date", par2);
            adt.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_end_HKLPRD(string Report_Sql, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_EDATE", OracleType.DateTime).Value = par2;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_end_HKLDR(string Report_Sql, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_EDATE", OracleType.DateTime).Value = par2;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_end_FESB(string Report_Sql, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_EDATE", OracleType.DateTime).Value = par2;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_end_FEDB(string Report_Sql, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_EDATE", OracleType.DateTime).Value = par2;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_end_BOSB(string Report_Sql, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_EDATE", OracleType.DateTime).Value = par2;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_end_BODB(string Report_Sql, DateTime par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_EDATE", OracleType.DateTime).Value = par2;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P1_Start_ISSUELOG(string Report_Sql, DateTime par1)

    {
        DataTable dt = new DataTable();
        try
        {
            sqlc.ConnectionString = s_connectstring;
            sqlc.Open();
            SqlDataAdapter adt = new SqlDataAdapter(Report_Sql, sqlc);
            adt.SelectCommand.CommandText = Report_Sql;
            adt.SelectCommand.CommandType = CommandType.StoredProcedure;
            adt.SelectCommand.Parameters.AddWithValue("@start_date", par1);
            adt.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P1_Start_HKLPRD(string Report_Sql, DateTime par1)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_SDATE", OracleType.DateTime).Value = par1;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P1_Start_HKLDR(string Report_Sql, DateTime par1)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_SDATE", OracleType.DateTime).Value = par1;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P1_Start_FESB(string Report_Sql, DateTime par1)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_SDATE", OracleType.DateTime).Value = par1;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P1_Start_FEDB(string Report_Sql, DateTime par1)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            cmd.Parameters.Add("P_SDATE", OracleType.DateTime).Value = par1;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            da.Fill(dt);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P1_Start_BOSB(string Report_Sql, DateTime par1)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_SDATE", OracleType.DateTime).Value = par1;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P1_Start_BODB(string Report_Sql, DateTime par1)

    {
        DataTable dt = new DataTable();
        try
        {
            orac.ConnectionString = s_connectstring;
            orac.Open();
            OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_SDATE", OracleType.DateTime).Value = par1;
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            OracleDataAdapter da = new OracleDataAdapter(cmd);
            da.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private string bind_report_sql(string P_report_sql)
    {
        sqlc.ConnectionString = obj1.Sqlcon();
        sqlc.Open();
        SqlCommand cmd = new SqlCommand("", sqlc);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Select ReportSQL from sysreport where reportcode ='" + P_report_sql + "'";
        SqlDataReader dr = cmd.ExecuteReader();
        string id = null;
        if (dr.Read())
        {
            id = dr[0].ToString();
            id = dr[1].ToString();
        }
        sqlc.Close();
        sqlc.Dispose();
        SqlConnection.ClearPool(sqlc);
        return id;
    }
    public void v_bind_sql_text(string P_report_sql)
    {
        try
        {
            sqlc.ConnectionString = obj1.Sqlcon();
            sqlc.Open();
            SqlCommand cmd = new SqlCommand("PR_excel_report_connstring", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reportcode", P_report_sql);
            //cmd.CommandText = "Select ReportSQL,reportFun,ColHeader1,ColHeader2,FileName,ReportTitle from sysreport where reportcode = '" + P_report_sql + "'";
            SqlDataAdapter adt = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adt.Fill(ds, "sysreport");
            if (ds.Tables[0].Rows.Count > 0)
            {
                s_ReportSQL = ds.Tables[0].Rows[0]["ReportSQL"].ToString();
                S_reportname = ds.Tables[0].Rows[0]["ReportName"].ToString();
                s_reportFun = ds.Tables[0].Rows[0]["reportFun"].ToString();
                s_ColHeader1 = ds.Tables[0].Rows[0]["ColHeader1"].ToString();
                s_ColHeader2 = ds.Tables[0].Rows[0]["ColHeader2"].ToString();
                s_FileName = ds.Tables[0].Rows[0]["FileName"].ToString();
                s_ReportTitle = ds.Tables[0].Rows[0]["ReportTitle"].ToString();
                s_conncode = ds.Tables[0].Rows[0]["conncode"].ToString();
                s_provider = ds.Tables[0].Rows[0]["provider"].ToString();
                s_connectstring = ds.Tables[0].Rows[0]["connectstring"].ToString();

            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _Cards._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _Cards._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    protected void D_selectDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectdate = D_selectDate.SelectedValue;
        if (selectdate == "LD")
        {
            T_From.Text = _Cards._getStartPeriod(D_selectDate.SelectedValue);
            T_To.Text = _Cards._getStartPeriod(D_selectDate.SelectedValue);
        }
        else
        {
            _Frequency_Fundamental(D_selectDate.SelectedValue);
        }
    }
}