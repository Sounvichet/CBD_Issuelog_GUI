using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;

public partial class Report_IncidentReport_ISSBYDATE : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    logger _logger = new logger();
    ReportIncident _incident = new ReportIncident();
    DropDownListValues _dropdown = new DropDownListValues();
    GridViewValues _Gridview = new GridViewValues();
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
            Label5.Text = grid1.Rows.Count.ToString();
        }
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
    protected void D_date_SelectedIndexChanged(object sender, EventArgs e)
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
    private void grid_report_Issuebydate()
    {
        try
        {
            _Gridview._GridviewBinding(grid1, _incident.D_reportIssuebyDate(T_Form.Text, T_To.Text));   
            Label5.Text = grid1.Rows.Count.ToString();
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
    private void export_report_terminal()
    {
        try
        {
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = new DataTable();
            dt = _incident.D_reportIssuebyDate(T_Form.Text, T_To.Text);
            wb.Worksheets.Add(dt, "IssueByDate");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=IssueByDate.xlsx");
            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            wb.SaveAs(memory);
            memory.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        grid_report_Issuebydate();
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        export_report_terminal();
    }

}