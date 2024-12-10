using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;

public partial class BRANCHES_index : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand _cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    BranchDashboard _branch = new BranchDashboard();
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
        Response.Redirect("~/BRANCHES/new.aspx");
    }
    protected void Linkbtnedit_Click1(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(row.Cells[4].Text);
                Response.Redirect("~/BRANCHES/edit.aspx?BRANCHID=" + id);
            }
        }
    }

    protected void LinkBtndel_Click(object sender, EventArgs e)
    {

    }

    protected void LinkBtnview_Click(object sender, EventArgs e)
    {

    }

    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "lnkedit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/ticket/edit.aspx?ticket_no=" + row.Cells[1].Text);
        }
        else if (e.CommandName == "InkDelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/ticket/delete.aspx?ticket_no=" + row.Cells[1].Text);
        }
        else if (e.CommandName == "lnkView")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/ticket/view.aspx?ticket_no=" + row.Cells[1].Text);
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
        _grid._GridviewBinding(grid1, _branch._getBrancheslisting());
        Label4.Text = grid1.Rows.Count.ToString();
    }
    private void _getexcel_BRANCH()
    {
        try
        {
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = new DataTable();

            dt = _branch._getBrancheslisting();
            wb.Worksheets.Add(dt, "BRANCHES");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=BRANCHES.xlsx");
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
    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[4].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
            e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        }
    }

    protected void Linkexport_Click(object sender, EventArgs e)
    {
        _getexcel_BRANCH();
    }
}