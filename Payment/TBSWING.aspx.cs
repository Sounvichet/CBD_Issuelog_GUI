using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data.OracleClient;

public partial class Payment_wing : System.Web.UI.Page
{
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    GridViewValues _grid = new GridViewValues();
    ReportWingDashboard _wing = new ReportWingDashboard();
    logger _logger = new logger();
    DropDownListValues _dropdown = new DropDownListValues();
    SqlConnection sqlc = new SqlConnection();
    OracleConnection orac = new OracleConnection();
    dbcon _oracon = new dbcon();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            _SelectDate();
            _SelectToday();
        }
    }
    public void _SelectDate()
    {
        _dropdown.bindDropDownList(d_selectdate, _wing.D_Select_date());
    }
    public void _SelectToday()
    {
        try
        {
            DataTable dt = _wing.D_Select_date_today();
            d_selectdate.SelectedValue = dt.Rows[0]["LookupCode"].ToString();
            _Frequency_Fundamental(d_selectdate.SelectedValue);

        }

        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
        }

    }

    public void _Frequency_Fundamental(string lookup)
    {
        DataTable dt = _wing.D_Frequency_Fundamental(lookup);

        if (dt.Rows.Count == 0)
        {
            Response.Write("<script>alert('Not Yet implement!')</script>");
        }

        if (dt.Rows.Count > 0)
        {
            txtForm.Text = dt.Rows[0][3].ToString();
            txtTo.Text = dt.Rows[0][4].ToString();
        }
    }
    protected void D_selectdate_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectdate = d_selectdate.SelectedValue;
        if (selectdate == "LD")
        {
            txtForm.Text = _wing._getStartPeriod(d_selectdate.SelectedValue);
            txtTo.Text = _wing._getEndPeriod(d_selectdate.SelectedValue);
        }
        else
        {
            _Frequency_Fundamental(d_selectdate.SelectedValue);

        }
    }
    public void _getWingListing()
    {
        _grid._GridviewBinding(GriViewReport, _wing.PR_WING_LOAN_REPAYMENT(txtForm.Text, txtTo.Text, d_wing.Text));
    }

    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        _getWingListing();
    }
    public void _getExcelFile()
    {
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Buffer = true;
        string WorkBook = "";
        string Worksheet = "";
        WorkBook = d_wing.Text;
        Worksheet = d_wing.Text;
        try
        {
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = new DataTable();

            if (GriViewReport.HeaderRow != null)
            {

                for (int i = 0; i < GriViewReport.HeaderRow.Cells.Count; i++)
                {
                    dt.Columns.Add(GriViewReport.HeaderRow.Cells[i].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GriViewReport.Rows)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dr[i] = row.Cells[i].Text.Replace("&nbsp;", "");
                }
                dt.Rows.Add(dr);
            }

            //  add the footer row to the table
            if (GriViewReport.FooterRow != null)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < GriViewReport.FooterRow.Cells.Count; i++)
                {
                    dr[i] = GriViewReport.FooterRow.Cells[i].Text.Replace("&nbsp;", "");
                }
                dt.Rows.Add(dr);
            }


            wb.Worksheets.Add(dt, Worksheet);
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename= " + WorkBook + ".xlsx");

            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _logger._message + " !!')</script>");
        }
        finally
        {
            //sqlc.Close();
            //sqlc.Dispose();
            //SqlConnection.ClearPool(sqlc);
        }

    }
    private void _GetexcelflieWing(string S_date,string E_date,string _partner)
    {

        XLWorkbook wb = new XLWorkbook();

        orac.ConnectionString = _oracon.oracleconcbs();
        orac.Open();
        OracleCommand cmd = new OracleCommand("PR_WING_LOAN_REPAYMENT", orac);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("P_SDATE", S_date);
        cmd.Parameters.AddWithValue("P_EDATE", E_date);
        cmd.Parameters.AddWithValue("PARTNER", _partner);
        cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("O_CURSOR1", OracleType.Cursor).Direction = ParameterDirection.Output;
        OracleDataAdapter _adp = new OracleDataAdapter();
        _adp.SelectCommand = cmd;
        DataSet ds = new DataSet();
        _adp.Fill(ds);

        for (int i = 0; i < ds.Tables.Count; i++)
        {

            wb.Worksheets.Add(ds.Tables[i] as DataTable);
        }
        orac.Close();

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=Wing_settlement.xlsx");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    protected void Linkexport_Click(object sender, EventArgs e)
    {
        //_getExcelFile();
        _GetexcelflieWing(txtForm.Text,txtTo.Text,d_wing.Text);
    }
    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx");
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}