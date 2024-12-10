using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;

public partial class Report_IncidentReport_INCIIS : System.Web.UI.Page
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
            Dropdown_branch();
            DropDown_Selectdate();
            _SelectToday();
            DropDown_ReasonGroup();
            Label5.Text = grid1.Rows.Count.ToString();
        }
    }

    public void Dropdown_branch()
    {
        _dropdown.bindDropDownList(D_Branch_name, _incident.D_BranchName());

    }
    public void DropDown_terminal()
    {
        _dropdown.bindDropDownList(D_Terminal_Name, _incident.D_Terminal(D_Branch_name.SelectedValue));
    }
    public void DropDown_Selectdate()
    {
        _dropdown.bindDropDownList(D_date, _incident.D_Select_date());
    }
    public void DropDown_ReasonGroup()
    {
        _dropdown.bindDropDownList(D_Reason_group, _incident.D_getReasonGroup());
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
    public void _ATMIssuereport()
    {
        _Gridview._GridviewBinding(grid1, _incident.D_RP_ATMIncident(D_Branch_name.SelectedValue, D_Terminal_Name.SelectedValue, D_Reason_group.SelectedValue, T_Form.Text, T_To.Text));
        Label5.Text = grid1.Rows.Count.ToString();
    }
    public void _getExcelFile()
    {
        try
        {
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = new DataTable();

            if (grid1.HeaderRow != null)
            {

                for (int i = 0; i < grid1.HeaderRow.Cells.Count; i++)
                {
                    dt.Columns.Add(grid1.HeaderRow.Cells[i].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in grid1.Rows)
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
            if (grid1.FooterRow != null)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < grid1.FooterRow.Cells.Count; i++)
                {
                    dr[i] = grid1.FooterRow.Cells[i].Text.Replace("&nbsp;", "");
                }
                dt.Rows.Add(dr);
            }


            wb.Worksheets.Add(dt, "Issue_listing");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=Issue_listing.xlsx");
            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            wb.SaveAs(memory);
            memory.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _logger._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }

    }
    protected void D_Branch_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDown_terminal();
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
    protected void Button3_Click(object sender, EventArgs e)
    {
        _ATMIssuereport();
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        _getExcelFile();
    }
}