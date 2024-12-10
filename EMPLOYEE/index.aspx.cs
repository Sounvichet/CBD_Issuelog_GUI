using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;

public partial class EMPLOYEE_index : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    EmployeeDashboard _emp = new EmployeeDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            grid_load();
            Label4.Text = grid1.Rows.Count.ToString();
        }
    }

    protected void linkbtnnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/EMPLOYEE/new.aspx");
    }
    protected void Linkbtnedit_Click1(object sender, EventArgs e)
    {

    }

    protected void LinkBtndel_Click(object sender, EventArgs e)
    {
       
    }

    protected void LinkBtnview_Click(object sender, EventArgs e)
    {

    }

    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "LinkEdit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/PACKAGES/edit.aspx?PACKAGEID=" + row.Cells[4].Text);
        }
        else if (e.CommandName == "LinkDelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/PACKAGES/delete.aspx?PACKAGEID=" + row.Cells[4].Text);
        }
        else if (e.CommandName == "lnkView")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/PACKAGES/view.aspx?PACKAGEID=" + row.Cells[4].Text);
        }
    }
    protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid1.PageIndex = e.NewPageIndex;
        this.grid_load();
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void grid_load()
    {
        _grid._GridviewBinding(grid1, _emp._getEmployeelisting());
        Label4.Text = grid1.Rows.Count.ToString();
    }

    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //string _days = (string)DataBinder.Eval(e.Row.DataItem, "PKGStatus");
        //if (_days == "ACT")
        //{
        //    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        //} 
    }
    private void _getexcel_EmployeeList()
    {
        try
        {
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = new DataTable();

            dt = _emp._getEmployeelisting();
            wb.Worksheets.Add(dt, "EmployeesList");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=EmployeesList.xlsx");
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
    protected void Linkexport_Click(object sender, EventArgs e)
    {
        _getexcel_EmployeeList();
    }

    protected void LinkSchedule_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(row.Cells[4].Text);
                Response.Redirect("~/PACKAGES/schedule.aspx?PACKAGEID=" + id);
            }
        }
    }
}