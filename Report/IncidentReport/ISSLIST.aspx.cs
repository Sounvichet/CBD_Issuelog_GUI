using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;

public partial class Report_IncidentReport_ISSLIST : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    logger _logger = new logger();
    ReportIncident _incident = new ReportIncident();
    DropDownListValues _dropdown = new DropDownListValues();
    GridViewValues _Gridview = new GridViewValues();
    RadioListValues _radio = new RadioListValues();
    string report_no;
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!this.IsPostBack)
        {
            DropDown_Selectdate();
            _SelectToday();
            bind_report_name();
            report_no = "ISSLIST";

        }
    }
    public void bind_report_name()
    {
        _radio.bindRadioButtonList(rbl_issuelisting, _incident.D_Radiolist_Issue());
    }
    public void DropDown_Selectdate()
    {
        _dropdown.bindDropDownList(D_date, _incident.D_Select_date());
    }
    public void _SelectToday()
    {
        try
        {
            DataTable dt = _incident.D_Select_date_today();
            D_date.SelectedValue = dt.Rows[0]["LookupCode"].ToString();
            _Frequency_Fundamental(D_date.SelectedValue);
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
    }
    public void _Frequency_Fundamental(string lookup)
    {
        DataTable dt = _incident.D_Frequency_Fundamental(lookup);

        if (dt.Rows.Count == 0)
        {
            Response.Write("<script>alert('Not Yet implement!')</script>");
        }

        if (dt.Rows.Count > 0)
        {
            T_Form.Text = dt.Rows[0][3].ToString();
            T_To.Text = dt.Rows[0][4].ToString();
        }

    }
    protected void DropDown_Selectdate(object sender, EventArgs e)
    {
        string selectdate = D_date.SelectedValue;
        if (selectdate == "LD")
        {
            T_Form.Text = _incident._getStartPeriod(D_date.SelectedValue);  
            T_To.Text = _incident._getStartPeriod(D_date.SelectedValue);
        }
        else
        {
            _Frequency_Fundamental(D_date.SelectedValue);
        }
    }
    public void _Get_sqlfundamental()
    {
            DataTable dt = _incident.D_getReportConnstring(rbl_issuelisting.SelectedValue);
                s_ReportSQL = dt.Rows[0]["ReportSQL"].ToString();
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
    private void getexcel_PAR2_ISSUELOG()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = _incident.Dt_PR_P2_ISSUELOG(s_ReportSQL, T_Form.Text,T_To.Text);
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
        dt = _incident.Dt_PR_P1_Start_ISSUELOG(s_ReportSQL, T_Form.Text);
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
    private void getexcel_PAR1_End_ISSUELOG()
    {
        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = _incident.Dt_PR_P1_end_ISSUELOG(s_ReportSQL, T_To.Text);
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
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/report/incidentreport/IncidentDashboard.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            foreach (ListItem li in rbl_issuelisting.Items)
            {
                if (li.Selected == true)
                {
                    string getreportsql = "";
                    getreportsql += rbl_issuelisting.SelectedValue;
                    _Get_sqlfundamental();
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "End_date" && s_conncode == "ISSUELOG")
                    {
                        getexcel_PAR2_ISSUELOG();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "" && s_ColHeader2 == "End_date" && s_conncode == "ISSUELOG")
                    {
                        getexcel_PAR1_End_ISSUELOG();
                    }
                    if (s_reportFun == "SPRS" && s_ColHeader1 == "Start_date" && s_ColHeader2 == "" && s_conncode == "ISSUELOG")
                    {
                        getexcel_PAR1_Start_ISSUELOG();
                    }
                }
            }
        }

        catch (Exception ex)
        {
            _logger.LogError(ex);
            _incident._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _incident._message + " !!')</script>");

        }
    }

}