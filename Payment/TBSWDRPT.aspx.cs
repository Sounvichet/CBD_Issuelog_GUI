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


public partial class payment_TBSWDRPT : System.Web.UI.Page
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
    Dispute_DashBoard _dis = new Dispute_DashBoard();
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

    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    private void _SelectDate()
    {
        _drop.bindDropDownList(D_Date, _vista.D_Select_date());
    }
    private void _get_status()
    {
        _drop.binddropdownlist_status(d_category, _dis._get_status());
        
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
        _drop.bindDropDownList(D_Report_type, _vista.D_bind_reportname_Wing(Session["USERID"].ToString()));
    }
    
    private void _export_excel_listing(string _Channel)
    {
        _dis.P_CHANNEL = _Channel;
        _dis.P_SDATE = T_From.Text;
        _dis.P_EDATE = T_To.Text;
        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = _dis._get_rpt_ticket_loan_bydate();
        wb.Worksheets.Add(dt, D_Report_type.SelectedValue.ToString());

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename="+d_Channel.SelectedItem.ToString()+"_"+ D_Report_type.SelectedValue.ToString() +"_"+d_category.SelectedItem.ToString()+".xls");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
    }
    private void _export_excel_listing_bystatus(string _channel, string _status)
    {
        _dis.P_CHANNEL = _channel;
        _dis.P_STATUS = _status;
        _dis.P_SDATE = T_From.Text;
        _dis.P_EDATE = T_To.Text;
        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = _dis._get_rpt_ticket_loan_bystatus();
        wb.Worksheets.Add(dt, D_Report_type.SelectedValue.ToString()+'_'+_status);

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + D_Report_type.SelectedValue.ToString() + "_" + d_category.SelectedItem.ToString() + ".xls");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string d_report = D_Report_type.SelectedValue.ToString();
        string d_status = d_category.SelectedItem.ToString();

        if (d_report == "TBSDPMG" && d_status == "All")
        {
            _export_excel_listing(d_Channel.SelectedItem.Text);
        }
        if (d_report == "TBSDPMG" && d_status == "PENDING")
        {
            _export_excel_listing_bystatus(d_Channel.SelectedItem.Text, "In_progress");
        }
        if (d_report == "TBSDPMG" && d_status == "Closed")
        {
            _export_excel_listing_bystatus(d_Channel.SelectedItem.Text, "Closed");
        }
        else if (d_report == "TBSDPMG" && d_status == "SOLVED")
        {
            _export_excel_listing_bystatus(d_Channel.SelectedItem.Text, "Solved");
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Disable", "javascript:Disable();", true);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("TBSWDSL.aspx");
    }
    protected void D_Report_type_SelectedIndexChanged(object sender, EventArgs e)
    {
        _get_status();
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
}