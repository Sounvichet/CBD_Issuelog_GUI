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


public partial class payment_rpt_ticket_dispute : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    dbcon obj1 = new dbcon();
    //OracleConnection orac = new OracleConnection(); //old
    Oracle.ManagedDataAccess.Client.OracleConnection orac1 = new Oracle.ManagedDataAccess.Client.OracleConnection();
    DropDownListValues _drop = new DropDownListValues();
    logger _logger = new logger();
    RadioListValues _radio = new RadioListValues();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    Dispute_DashBoard _dis = new Dispute_DashBoard();
    ReportSmartVista _vista = new ReportSmartVista();
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
        _drop.binddropdownlist_css_dispute(d_category, _dis._get_status());
        
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
        _drop.bindDropDownList(D_Report_type, _vista.D_bind_reportname_CSS_dispute(Session["USERID"].ToString()));
    }
    private void _export_excel_listing()
    {
        _dis.P_SDATE = T_From.Text;
        _dis.P_EDATE = T_To.Text;
        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = _dis._get_rpt_CSS_dispute_bydate();
        wb.Worksheets.Add(dt, D_Report_type.SelectedValue.ToString());

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename="+ D_Report_type.SelectedValue.ToString() +"_"+d_category.SelectedItem.ToString()+".xls");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
    }
    private void _export_excel_listing_bystatus( string _status)
    {
        _dis.P_STATUS = _status;
        _dis.P_SDATE = T_From.Text;
        _dis.P_EDATE = T_To.Text;
        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = _dis._get_rpt_CSS_dispute_bystatus();
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

        if (d_report == "TBSCSPMG" && d_status == "All")
        {
            _export_excel_listing();
        }
        if (d_report == "TBSCSPMG" && d_status == "PENDING")
        {
            _export_excel_listing_bystatus("PENDING");
        }
        else if (d_report == "TBSCSPMG" && d_status == "SOLVED")
        {
            _export_excel_listing_bystatus("SOLVED");
        }
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Disable", "javascript:Disable();", true);
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
       
        Response.Redirect("dispute_resolution.aspx");
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