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
using Oracle.ManagedDataAccess.Types;
using Oracle.ManagedDataAccess.Client;
public partial class MIGRATION_cacrcon : System.Web.UI.Page
{
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

    SqlConnection sqlc = new SqlConnection();
    SqlConnectAndSqlCommand _getsqlcon = new SqlConnectAndSqlCommand();
    SV_Migration _mig = new SV_Migration();
    ReportSVMigration _svmig = new ReportSVMigration();
    DataTable CSVTable = new DataTable();
    DropDownListValues _drop = new DropDownListValues();
    RadioListValues _radio = new RadioListValues();
    logger _logger = new logger();
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
            _bind_reportcat();
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
        DataTable dt1 = _mig.D_get_card_account_recon();
        DataTable dt2 = _mig.D_get_card_account_BO1_recon();
        DataTable dt3 = _mig.D_get_card_account_BO2_recon();
        workbook.Worksheets.Add(dt1, ""+ _mig._P_F_BRN + "_"+ _mig._P_T_BRN + "_Card_account_recon");
        workbook.Worksheets.Add(dt2, "" + _mig._P_F_BRN + "_" + _mig._P_T_BRN + "_BO1");
        workbook.Worksheets.Add(dt3, "" + _mig._P_F_BRN + "_" + _mig._P_T_BRN + "_BO2");
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=Card_account_recon"+ _mig._P_F_BRN + "_"+ _mig._P_T_BRN + ".xlsx");

        using (MemoryStream MyMemoryStream = new MemoryStream())
        {
            workbook.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }
    private void _bind_reportcat()
    {
        _radio.bindRadioButtonList(rbl_report_listing, _svmig.D_bind_reportcode("cacrcon"));
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
                if (s_reportFun != "SPRS")
                {
                    //getexcel();
                }
               
                if (s_reportFun == "SPRS" && s_ColHeader1 == "P_F_BRN" && s_ColHeader2 == "P_T_BRN" && s_conncode == "SVMIGDB")
                {
                    getexcel_PAR2_SVMIGDB();
                }
            }
        }
    }
    private void getexcel_PAR2_SVMIGDB()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = Dt_PR_P2_SVMIGDB(s_ReportSQL, d_f_branch.SelectedValue, d_t_branch.SelectedValue);
        wb.Worksheets.Add(dt, s_ReportTitle); //s_ReportTitle

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
    private DataTable Dt_PR_P2_SVMIGDB(string Report_Sql, string par1, string par2)

    {
        DataTable dt = new DataTable();
        try
        {
            orac1.ConnectionString = s_connectstring;
            orac1.Open();
            Oracle.ManagedDataAccess.Client.OracleCommand cmd1 = new Oracle.ManagedDataAccess.Client.OracleCommand(Report_Sql, orac1);
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.Parameters.Add("P_F_BRN", OracleDbType.NVarchar2).Value = par1;
            cmd1.Parameters.Add("P_T_BRN", OracleDbType.NVarchar2).Value = par2;
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
    public void v_bind_sql_text(string P_report_sql)
    {
        try
        {
            DataTable dt = new DataTable();
            _getsqlcon._command_Stored("PR_excel_report_connstring", ref cmd);
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
    protected void Linkbtnapply_Click(object sender, EventArgs e)
    {
        //_ExportGenerate();
        _ExportexcelFile();
    }
    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("migration_dashboard.aspx");
    }
}