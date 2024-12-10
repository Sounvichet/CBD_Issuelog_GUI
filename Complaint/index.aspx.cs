using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
using System.Text;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using ClosedXML.Excel;

public partial class Complaint_index : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    ComplaintDashBoard _complaint = new ComplaintDashBoard();
    GridViewValues _grid = new GridViewValues();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!this.IsPostBack)
        {
            grid_load();
            bind_user_name();
            Label4.Text = grid1.Rows.Count.ToString();
        }
    }
    protected void grid_load()
    {
        _grid._GridviewBinding(grid1, _complaint.D_getGridcomplaint());
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void grid_load_user()
    {
        _grid._GridviewBinding(grid1, _complaint.D_getGridcomplaint_byUser(D_User_name.SelectedValue));
        Label4.Text = grid1.Rows.Count.ToString();
    }
    public void bind_user_name()
    {
        try
        {
            _drop.bindDropDownList(D_User_name, _complaint._getticketuser());
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
    protected void btnedit_click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/Complaint/edit.aspx?ticket_no=" + id ); //+ "&problem_Type=" + row.Cells[5].Text + "&root_Issue=" + row.Cells[6].Text

            }
        }
    }
    protected void btndel_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/Complaint/delete.aspx?ticket_no=" + id);
            }
        }
    }
    protected void D_User_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        grid_load_user();
    }

    void Complain_Pending_By_username()
    {
        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = _complaint.D_getGridcomplaint_byUser(D_User_name.SelectedValue);
        wb.Worksheets.Add(dt, "Issue_pending");

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=Issue_pending.xlsx");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        Response.Write("<script>alert('Update Successful!!')</script>");
        Server.Transfer("~/TestPro/Default.aspx");
    }
    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "lnkEdit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/Complaint/edit.aspx?ticket_no=" + row.Cells[3].Text);
        }
        else if (e.CommandName == "InkDelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/Complaint/delete.aspx?ticket_no=" + row.Cells[3].Text);
        }
    }
    protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid1.PageIndex = e.NewPageIndex;
        this.grid_load();
    }
    protected void btn_apply_Click(object sender, EventArgs e)
    {
        Complain_Pending_By_username();
    }
}