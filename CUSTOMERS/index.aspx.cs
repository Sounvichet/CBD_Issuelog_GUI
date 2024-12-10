using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;

public partial class CUSTOMERS_index : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    CustomerDashboard _cus = new CustomerDashboard();
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
        Response.Redirect("~/CUSTOMERS/new.aspx");
    }
    protected void Linkbtnedit_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/CUSTOMERS/edit.aspx?CUSTOMERID=" + id);
            }
        }
    }
    protected void LinkBtndel_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(row.Cells[15].Text);
                Response.Redirect("~/CUSTOMERS/delete.aspx?CUSTOMERID=" + id);
            }
        }
    }
    protected void LinkBtnview_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/CUSTOMERS/view.aspx?CUSTOMERID=" + id);
            }
        }
    }

    protected void Linkprint_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            { 
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
                frm2.Attributes["src"] = "~/CUSTOMERS/Print.aspx?CUSTOMERID=" + id.ToString();
                // Response.Redirect("~/Mission/edit.aspx?ticket_no=" + id);
            }
        }
    }
    //protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //    if (e.CommandName == "lnkedit")
    //    {
    //        int index = Convert.ToInt32(e.CommandArgument);
    //        GridViewRow row = grid1.Rows[index];
    //        Response.Redirect("~/CUSTOMERS/edit.aspx?CUSTOMERID=" + row.Cells[1].Text);
    //    }
    //    else if (e.CommandName == "InkDelete")
    //    {
    //        int index = Convert.ToInt32(e.CommandArgument);
    //        GridViewRow row = grid1.Rows[index];
    //        Response.Redirect("~/CUSTOMERS/delete.aspx?CUSTOMERID=" + row.Cells[1].Text);
    //    }
    //    else if (e.CommandName == "lnkView")
    //    {
    //        int index = Convert.ToInt32(e.CommandArgument);
    //        GridViewRow row = grid1.Rows[index];
    //        Response.Redirect("~/CUSTOMERS/view.aspx?CUSTOMERID=" + row.Cells[1].Text);
    //    }
    //}
    protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid1.PageIndex = e.NewPageIndex;
        this.grid_load();
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void grid_load()
    {
         _cus._BranchID = Session["BRANCHCODE"].ToString();
        //_cus._BranchID = "003";
        _grid._GridviewBinding(grid1, _cus._getCustomerlisting());
        Label4.Text = grid1.Rows.Count.ToString();
    }

    private void Grid_search()

    {
        _cus._Search = TxtUser.Text.ToString();
        _grid._GridviewBinding(grid1, _cus._GetCustlistbySearch());
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void btnsearch_Click(object sender, EventArgs e)
    {
        Grid_search();
    }
}