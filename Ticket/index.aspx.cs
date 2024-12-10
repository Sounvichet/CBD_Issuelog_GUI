using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;
using IncidentDashBoard;

public partial class Ticket_index : System.Web.UI.Page
{
    //SqlConnection sqlc = new SqlConnection();
    //logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    TicketDashboard _ticket = new TicketDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!IsPostBack)
        {
            bind_user_name();
            grid_load();
           // string script = "$(document).ready(function () grid_load(this.GetType(), "load", script, true);
            
        }
    }
    public void Griduser_pending()
    {
        try
        {
            _grid._GridviewBinding(grid1, _ticket._GridTicketindex());
            Label4.Text = grid1.Rows.Count.ToString();
        }
        catch (Exception ex)
        {
            Response.Write(@"<script language='javascript'>alert('" + _ticket.get_message + " !!')</script>");
        }
        finally
        {
            
        }
    }
    protected void grid_username()
    {

        // obj.Grid_by_username(D_User_name.Text, grid1);
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void grid_load()
    {
        _grid._GridviewBinding(grid1, _ticket._GridTicketindex());
        Label4.Text = grid1.Rows.Count.ToString();
    }
    public void bind_user_name()
    {
        try
        {
            _drop.bindDropDownList(D_User_name, _ticket._getticketuser());
        }
        catch (Exception ex)
        {
            Response.Write(@"<script language='javascript'>alert('" + _ticket.get_message + " !!')</script>");
        }
        finally
        {
           
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        //  Response.Redirect("~/TestPro/ticket/new.aspx");
        Response.Redirect("~/ticket/new.aspx");
    }
    protected void btnedit_click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/ticket/edit.aspx?ticket_no=" + id);
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
                Response.Redirect("~/ticket/delete.aspx?ticket_no=" + id);
            }
        }
    }
    protected void btnview_Click(object sender, EventArgs e)
    {

        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/ticket/view.aspx?ticket_no=" + id);
            }
        }

    }
    protected void btnupload_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/ticket/upload.aspx");
    }
    protected void D_User_name_SelectedIndexChanged(object sender, EventArgs e)
    {
        _getGridbyuser();

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

    protected void btn_apply_Click(object sender, EventArgs e)
    {
        string _action = "";
        _action = D_User_name.SelectedValue.ToString();

        if (_action == "")
        {
            System.Threading.Thread.Sleep(5000);
            _getexcelticketlisting();
        }
        else
        {
            System.Threading.Thread.Sleep(5000);
            _getexcelticketlistingbyuser();
        }
    }

    private void _getexcelticketlisting()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = _ticket._GridTicketindex();
        wb.Worksheets.Add(dt, "Ticket_listing");

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=Ticket_listing.xlsx");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");

    }
    private void _getexcelticketlistingbyuser()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = _ticket._Getgrididexbyuser(D_User_name.SelectedValue);
        wb.Worksheets.Add(dt, "listingbyuser");

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=listingbyuser.xlsx");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");

    }
    public void _getGridbyuser()
    {
        _grid._GridviewBinding(grid1, _ticket._Getgrididexbyuser(D_User_name.SelectedValue)); //D_User_name.SelectedItem.ToString()
        Label4.Text = grid1.Rows.Count.ToString();
    }

    protected void LinkBtnmission_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/ticket/getmission.aspx?ticket_no=" + id);
            }
        }
    }
}