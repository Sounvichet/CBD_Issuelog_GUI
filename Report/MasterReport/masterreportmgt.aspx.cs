using System;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;
using MasterReportClass;
using System.Data.OracleClient;
using System.Web.UI;
using System.Threading;
using System.Web;
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;
//you just need to import this can connect with Oracle client 19c 


public partial class Report_MasterReport_masterreportmgt : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    dbcon obj1 = new dbcon();
    //OracleConnection orac = new OracleConnection(); //old
    Oracle.ManagedDataAccess.Client.OracleConnection orac1 = new Oracle.ManagedDataAccess.Client.OracleConnection();
    string getreportcode;
    DataTable dt = new DataTable();
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
    Dialy_currentEOD obj2 = new Dialy_currentEOD();
    Dialy_backdateEOD obj3 = new Dialy_backdateEOD();
    NBC_Report obj13 = new NBC_Report();
    DropDownListValues _drop = new DropDownListValues();
    ReportSmartVista _vista = new ReportSmartVista();
    ATM_Management _ATMCard = new ATM_Management();
    CashDenoRemaining _cash = new CashDenoRemaining();
    logger _logger = new logger();
    RadioListValues _radio = new RadioListValues();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    masterreport_connect obj14 = new masterreport_connect();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
             ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!this.IsPostBack)
        {
            _bind_groupreport();
            _SelectDate();
            _selectToday();
        }
        //Image2.Attributes.Add("style", "display: none;");
        //lblwait.Attributes.Add("style", "display: none;");
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    private void _SelectDate()
    {
        _drop.bindDropDownList(D_Date, _vista.D_Select_date());
    }
    private void _selectToday()
    {
        DataTable dt = _vista.D_Select_date_today();
        D_Date.SelectedValue = dt.Rows[0][0].ToString();
        _Frequency_Fundamental(D_Date.SelectedValue);

    }
    public void _Frequency_Fundamental(string lookup)
    {
        DataTable dt = _vista.D_Frequency_Fundamental(lookup);

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
    public void _bind_groupreport()
    {
        _drop.bindDropDownList(D_Report_type, _vista.D_bind_reportname(Session["USER_NAME"].ToString()));
    }
    private void getexcel_PAR2_FEDB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_FEDB(s_ReportSQL, T_From.Text, T_To.Text);
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
        dt = Dt_PR_P2_BODB(s_ReportSQL, T_From.Text, T_To.Text);
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
    private void getexcel_PAR2_MBDB()
    {

        XLWorkbook wb = new XLWorkbook();

        DataTable dt = new DataTable();
        dt = Dt_PR_P2_MBDB(s_ReportSQL, T_From.Text, T_To.Text);
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
    private void getexcel_PAR2_CBSFCRPTRW()
    {

        XLWorkbook wb = new XLWorkbook();

        DataTable dt = new DataTable();
        dt = Dt_PR_P2_CBSFCRPTRW(s_ReportSQL, T_From.Text, T_To.Text);
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

    }
    private void getexcel_NO_PAR_HKLDB1DBRW()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_HKLDB1DBRW(s_ReportSQL);
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");

        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);

        // Append cookie
        HttpCookie cookie = new HttpCookie("ExcelDownloadFlag");
        cookie.Value = "Flag";
        cookie.Expires = DateTime.Now.AddDays(1);
        Response.AppendCookie(cookie);
        // end
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#alert_container').hide();", true);
        Response.Flush();
        Response.End();

        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");
    }
    private void getexcel_PAR2_HKLDB1DBRW()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_HKLDB1DBRW(s_ReportSQL, T_From.Text, T_To.Text);
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

    }
    private void getexcel_PAR1_HKLDB1DBRW()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P1_Start_HKLDB1DBRW(s_ReportSQL, T_From.Text);
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

    }
    //SUB Void for Svreport
    private void getexcel_NO_PAR_svrptrw()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_svrptrw(s_ReportSQL);
        wb.Worksheets.Add(dt, s_ReportTitle);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + s_FileName + "");

        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);

        // Append cookie
        HttpCookie cookie = new HttpCookie("ExcelDownloadFlag");
        cookie.Value = "Flag";
        cookie.Expires = DateTime.Now.AddDays(1);
        Response.AppendCookie(cookie);
        // end
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#alert_container').hide();", true);
        Response.Flush();
        Response.End();

        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");
    }
    private void getexcel_PAR2_svrptrw()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_svrptrw(s_ReportSQL, T_From.Text, T_To.Text);
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

    }
    private void getexcel_PAR1_svrptrw()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P1_Start_svrptrw(s_ReportSQL, T_From.Text);
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

    }

    //// Sub Void for PAR2_end 
    private void getexcel_PAR2_end_FEDB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_end_FEDB(s_ReportSQL, T_To.Text);
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
        ShowMessage("report exported is successfully!", MessageType.Success);
        Response.End();
    }
    private void getexcel_PAR2_end_BODB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_end_BODB(s_ReportSQL, T_To.Text);
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
        ShowMessage("report exported is successfully!", MessageType.Success);
        Response.End();
    }
    private void getexcel_PAR2_end_CBSFCRPTRW()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_end_CBSFCRPTRW(s_ReportSQL, T_To.Text);
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
        ShowMessage("report exported is successfully!", MessageType.Success);
        Response.End();
    }
    private void getexcel_PAR2_end_ISSUELOG()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_end_ISSUELOG(s_ReportSQL, T_To.Text);
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
        dt = Dt_PR_P1_Start_FEDB(s_ReportSQL,T_From.Text);
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
        dt = Dt_PR_P1_Start_BODB(s_ReportSQL, T_From.Text);
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
    private void getexcel_PAR1_Start_MBDB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P1_Start_MBDB(s_ReportSQL, T_From.Text);
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
    private void _bind_reportcat()
    {
        _radio.bindRadioButtonList(rbl_report_listing, _vista.D_bind_reportcode(D_Report_type.SelectedValue));
    }

    // Sub for SQRS Par1 
    private void getexcel_SQRS_PAR1_svrptrw()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = DR_SQRS_P1_svrptrw(s_ReportSQL, T_From.Text);
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

    }
    public void _ExportexcelFile()
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
                    if (s_reportFun != "SPRS" && s_ColHeader1 == "Start_date" && s_conncode == "svrptrw")
                    {

                        getexcel_SQRS_PAR1_svrptrw();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "ISSUELOG")
                    {
                       // getexcel_PAR2_ISSUELOG();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "FEDB")
                    {
                        getexcel_PAR2_FEDB();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "FESB")
                    {
                     //   getexcel_PAR2_FESB();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "BODB")
                    {
                        getexcel_PAR2_BODB();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "CBSFCRPTRW")
                    {
                        getexcel_PAR2_CBSFCRPTRW();
                    }
                if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "MBDB")
                    {
                        getexcel_PAR2_MBDB();
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
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "" && s_ColHeader2 == "End_date" && s_conncode == "BODB")
                    {
                       getexcel_PAR2_end_BODB();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "" && s_ColHeader2 == "End_date" && s_conncode == "CBSFCRPTRW")
                    {
                        getexcel_PAR2_end_CBSFCRPTRW();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "ISSUELOG")
                    {
                        getexcel_PAR1_Start_ISSUELOG();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "FEDB")
                    {
                       getexcel_PAR1_Start_FEDB();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "BODB")
                    {
                       getexcel_PAR1_Start_BODB();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "MBDB")
                    {
                       getexcel_PAR1_Start_MBDB();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "" && s_ColHeader2 == "" && s_conncode == "HKLDB1DBRW")
                    {
                        getexcel_NO_PAR_HKLDB1DBRW();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "HKLDB1DBRW")
                    {
                        getexcel_PAR1_HKLDB1DBRW();
                        
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "HKLDB1DBRW")
                    {
                         getexcel_PAR2_HKLDB1DBRW(); 
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "" && s_ColHeader2 == "" && s_conncode == "svrptrw")
                    {
                    getexcel_NO_PAR_svrptrw();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "svrptrw")
                    {
                        getexcel_PAR1_svrptrw();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "svrptrw")
                    {
                    getexcel_PAR2_svrptrw();
                        
                    }


            }
            }
    }
    // Sub with No Par
    
    protected void Button1_Click(object sender, EventArgs e)
    {
        _ExportexcelFile();
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       
        Response.Redirect("~/index.aspx");
    }
    protected void D_Report_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        _bind_reportcat();
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
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
    }
    private DataTable Dt_PR_P2_MBDB(string Report_Sql, string par1, string par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac1.ConnectionString = s_connectstring;
            orac1.Open();
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, orac1);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = par1;
            cmd1.Parameters.Add("P_EDATE", OracleDbType.NVarchar2).Value = par2;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            da1.Fill(dt);


        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_CBSFCRPTRW(string Report_Sql, string par1, string par2)

    {
        DataTable dt = new DataTable();
        try
        {


            var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(s_connectstring);
            connection.Open();
            //orac.ConnectionString = s_connectstring;
            //orac.Open();
            //OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = par1;
            cmd1.Parameters.Add("P_EDATE", OracleDbType.NVarchar2).Value = par2;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            da1.Fill(dt);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_FEDB(string Report_Sql, string par1, string par2)

    {
        DataTable dt = new DataTable();
        try
        {
           
            var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(s_connectstring);
            connection.Open();
            //orac.ConnectionString = s_connectstring;
            //orac.Open();
            //OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = par1;
            cmd1.Parameters.Add("P_EDATE", OracleDbType.NVarchar2).Value = par2;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            da1.Fill(dt);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_BODB(string Report_Sql, string par1, string par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac1.ConnectionString = s_connectstring;
            orac1.Open();
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, orac1);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = par1;
            cmd1.Parameters.Add("P_EDATE", OracleDbType.NVarchar2).Value = par2;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            da1.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    ////sub Datable for par 1
    private DataTable Dt_PR_P2_end_ISSUELOG(string Report_Sql, string par2)

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
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_end_FEDB(string Report_Sql, string par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac1.ConnectionString = s_connectstring;
            orac1.Open();
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, orac1);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_EDATE", OracleDbType.NVarchar2).Value = par2;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            da1.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_end_BODB(string Report_Sql, string par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac1.ConnectionString = s_connectstring;
            orac1.Open();
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, orac1);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_EDATE", OracleDbType.NVarchar2).Value = par2;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            da1.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_end_CBSFCRPTRW(string Report_Sql, string par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac1.ConnectionString = s_connectstring;
            orac1.Open();
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, orac1);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_EDATE", OracleDbType.NVarchar2).Value = par2;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            da1.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
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
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P1_Start_MBDB(string Report_Sql, string par1)

    {
        DataTable dt = new DataTable();
        try
        {
            orac1.ConnectionString = s_connectstring;
            orac1.Open();
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, orac1);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = par1;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            da1.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P1_Start_FEDB(string Report_Sql, string par1)

    {
        DataTable dt = new DataTable();
        try
        {
            orac1.ConnectionString = s_connectstring;
            orac1.Open();
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, orac1);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = par1;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            da1.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P1_Start_BODB(string Report_Sql, string par1)

    {
        DataTable dt = new DataTable();
        try
        {
            orac1.ConnectionString = s_connectstring;
            orac1.Open();
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, orac1);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = par1;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            da1.Fill(dt);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    //Sub Datatable with no Par
    private DataTable Dt_PR_HKLDB1DBRW(string Report_Sql)

    {
        DataTable dt = new DataTable();
        try
        {


            var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(s_connectstring);
            connection.Open();
            //orac.ConnectionString = s_connectstring;
            //orac.Open();
            //OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            da1.Fill(dt);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P1_Start_HKLDB1DBRW(string Report_Sql, string par1)

    {
        DataTable dt = new DataTable();
        try
        {


            var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(s_connectstring);
            connection.Open();
            //orac.ConnectionString = s_connectstring;
            //orac.Open();
            //OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = par1;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            da1.Fill(dt);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_HKLDB1DBRW(string Report_Sql, string par1 , string par2)

    {
        DataTable dt = new DataTable();
        try
        {


            var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(s_connectstring);
            connection.Open();
            //orac.ConnectionString = s_connectstring;
            //orac.Open();
            //OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = par1;
            cmd1.Parameters.Add("P_EDATE", OracleDbType.NVarchar2).Value = par2;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            da1.Fill(dt);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    // Sub Datatalbe for SVREPORT
    private DataTable Dt_PR_svrptrw(string Report_Sql)

    {
        DataTable dt = new DataTable();
        try
        {


            var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(s_connectstring);
            connection.Open();
            //orac.ConnectionString = s_connectstring;
            //orac.Open();
            //OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            da1.Fill(dt);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P1_Start_svrptrw(string Report_Sql, string par1)

    {
        DataTable dt = new DataTable();
        try
        {


            var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(s_connectstring);
            connection.Open();
            //orac.ConnectionString = s_connectstring;
            //orac.Open();
            //OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = par1;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            da1.Fill(dt);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    private DataTable Dt_PR_P2_svrptrw(string Report_Sql, string par1, string par2)

    {
        DataTable dt = new DataTable();
        try
        {


            var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(s_connectstring);
            connection.Open();
            //orac.ConnectionString = s_connectstring;
            //orac.Open();
            //OracleCommand cmd = new OracleCommand(Report_Sql, orac);
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, connection);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = par1;
            cmd1.Parameters.Add("P_EDATE", OracleDbType.NVarchar2).Value = par2;
            cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            da1.Fill(dt);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }



    // Sub datatable with SQRS 
    // SVRPTRW 
    public DataTable DR_SQRS_P1_svrptrw(string Report_Sql , string par1)
    {
        DataTable dt = new DataTable();
        try
        {
            obj14.P_Connstring = "svrptrw";
            string _svconn = obj14._getconnstring();
            string _get_sql_st = obj14.SQL_SCRIPT(Report_Sql);
            var connection = new Oracle.ManagedDataAccess.Client.OracleConnection(_svconn);
            connection.Open();

            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(_get_sql_st, connection);
            cmd1.CommandType = CommandType.Text;
            cmd1.Parameters.Add("P_SDATE", OracleDbType.NVarchar2).Value = par1;
            

            //cmd1.Parameters.Add("o_cursor", OracleDbType.RefCursor).Direction = ParameterDirection.Output;
            Oracle.ManagedDataAccess.Client.OracleDataAdapter da1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter(cmd1);
            //OracleDataAdapter da = new OracleDataAdapter(cmd);
            da1.Fill(dt);

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
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
            DataTable dt = new DataTable();
            _sqlcom._command_Stored("PR_excel_report_connstring", ref cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reportcode", P_report_sql);
            //cmd.CommandText = "Select ReportSQL,reportFun,ColHeader1,ColHeader2,FileName,ReportTitle from sysreport where reportcode = '" + P_report_sql + "'";
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                s_ReportSQL = dt.Rows[0]["ReportSQL"].ToString();
                s_reportCode = dt.Rows[0]["ReportCode"].ToString();
                S_reportname = dt.Rows[0]["ReportName"].ToString();
                s_reportFun = dt.Rows[0]["reportFun"].ToString();
                s_ColHeader1 = dt.Rows[0]["ColHeader1"].ToString();
                s_ColHeader2 = dt.Rows[0]["ColHeader2"].ToString();
                s_FileName = dt.Rows[0]["FileName"].ToString();
                s_ReportTitle = dt.Rows[0]["ReportTitle"].ToString();
                s_conncode = dt.Rows[0]["conncode"].ToString();
                s_provider = dt.Rows[0]["provider"].ToString();
                s_connectstring = dt.Rows[0]["connectstring"].ToString();
            }
            else
            {
                Response.Write("No record bind !");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            throw ex;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    protected void D_Date_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectdate = D_Date.SelectedValue;
        if (selectdate == "LD")
        {
            T_From.Text = _vista._getStartPeriod(D_Date.SelectedValue);
            T_To.Text = _vista._getStartPeriod(D_Date.SelectedValue);
        }
        else
        {
            _Frequency_Fundamental(D_Date.SelectedValue);
        }
    }
    protected void LinkBtntest_Click(object sender, EventArgs e)
    {
        ShowMessage("We are processing", MessageType.Info);
    }
    private void loading_Close()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#loading').hide();", true);
    }
}