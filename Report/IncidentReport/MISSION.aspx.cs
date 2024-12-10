using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using ClosedXML.Excel;

public partial class Report_IncidentReport_MISSION : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    logger _logger = new logger();
    ReportIncident _incident = new ReportIncident();
    DropDownListValues _dropdown = new DropDownListValues();
    GridViewValues _Gridview = new GridViewValues();
    MissionDashBoard _mission = new MissionDashBoard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
           // ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        string nextdate = DateTime.Now.AddDays(1).ToString("dd/MMM/yyyy").Replace('/', '-');
        string previousdate = DateTime.Now.AddDays(-1).ToString("dd/MMM/yyyy").Replace('/', '-');
        if (!this.IsPostBack)
        {
            Dropdown_branch();
            DropDown_Selectdate();
            T_Form.Text = previousdate;
            T_To.Text = currentdate;
            Label5.Text = Getgridview.Rows.Count.ToString();
        }
        }
    public void Dropdown_branch()
    {
        _dropdown.bindDropDownList(D_branch_name, _incident.D_BranchName());

    }
    public void DropDown_terminal()
    {
        _dropdown.bindDropDownList(D_Terminal, _incident.D_Terminal(D_branch_name.SelectedValue));
    }
    public void DropDown_Selectdate()
    {
        _dropdown.bindDropDownList(D_SelectDate, _incident.D_Select_date());
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
    public void _getReportmission()
    {
        Getgridview.HeaderStyle.BackColor = Color.FromName("#01559E");
        Getgridview.HeaderStyle.Font.Bold = true;
        Getgridview.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");

        _mission._branch_name = D_branch_name.SelectedValue;
        _mission._terminal = D_Terminal.SelectedValue; 
        _mission._start_date = T_Form.Text;
        _mission._end_date = T_To.Text;

        _Gridview._GridviewBinding(Getgridview, _mission.RP_MISSION_LISTING());
        Label5.Text = Getgridview.Rows.Count.ToString();

    }

    private void export_report_Mission()
    {
        try
        {
            _mission._branch_name = D_branch_name.SelectedValue;
            _mission._terminal = D_Terminal.SelectedValue;
            _mission._start_date = T_Form.Text;
            _mission._end_date = T_To.Text;

            XLWorkbook wb = new XLWorkbook();
            DataTable dt = new DataTable();
            dt = _mission.RP_MISSION_LISTING();
            wb.Worksheets.Add(dt, "MissionByDate");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=MissionListing.xlsx");
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
    protected void D_branch_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        DropDown_terminal();
    }

    protected void D_SelectDate_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectdate = D_SelectDate.SelectedValue;
        if (selectdate == "LD")
        {
            T_Form.Text = _incident._getStartPeriod(D_SelectDate.SelectedValue);
            T_To.Text = _incident._getStartPeriod(D_SelectDate.SelectedValue);
        }
        else
        {
            _Frequency_Fundamental(D_SelectDate.SelectedValue);
        }
    }

    protected void LinkbtnApply_Click(object sender, EventArgs e)
    {
        _getReportmission();
    }
    protected void Linkbtnexport_Click(object sender, EventArgs e)
    {
        export_report_Mission();
    }
}