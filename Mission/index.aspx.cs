using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using IncidentDashBoard; 

public partial class Mission_index : System.Web.UI.Page
{
    //SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    //SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    //MissionDashBoard _mission = new MissionDashBoard();
    Mission_Dashboard _mission = new Mission_Dashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!this.IsPostBack)
        {
            grid_load();
        }
    }
    protected void grid_load()
    {
        _grid._GridviewBinding(grid1, _mission.D_getGridmissionindex());
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        //  Response.Redirect("~/TestPro/ticket/new.aspx");
        Response.Redirect("~/Mission/new.aspx");
    }
    protected void btnedit_click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/Mission/edit.aspx?ticket_no=" + id);
            }
        }
    }
    protected void btnprint_click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
                frm2.Attributes["src"] = "~/Mission/Mission_letter.aspx?ticket_no=" + id.ToString();
                // Response.Redirect("~/Mission/edit.aspx?ticket_no=" + id);
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
                Response.Redirect("~/Mission/delete.aspx?ticket_no=" + id);
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
                String id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/Mission/view.aspx?ticket_no=" + id);
            }
        }

    }
    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "lnkedit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/Mission/edit.aspx?ticket_no=" + row.Cells[3].Text);
        }
        else if (e.CommandName == "InkDelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/Mission/delete.aspx?ticket_no=" + row.Cells[3].Text);
        }
    }
    protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid1.PageIndex = e.NewPageIndex;
        this.grid_load();
    }
}