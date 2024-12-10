using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;

public partial class transaction_index : System.Web.UI.Page
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
            //grid_load();
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
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
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

    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        //if (e.CommandName == "lnkedit")
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow row = grid1.Rows[index];
        //    Response.Redirect("~/CUSTOMERS/edit.aspx?CUSTOMERID=" + row.Cells[1].Text);
        //}
        //else if (e.CommandName == "InkDelete")
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow row = grid1.Rows[index];
        //    Response.Redirect("~/CUSTOMERS/delete.aspx?CUSTOMERID=" + row.Cells[1].Text);
        //}
        //else if (e.CommandName == "lnkView")
        //{
        //    int index = Convert.ToInt32(e.CommandArgument);
        //    GridViewRow row = grid1.Rows[index];
        //    Response.Redirect("~/CUSTOMERS/view.aspx?CUSTOMERID=" + row.Cells[1].Text);
        //}
    }
    protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid1.PageIndex = e.NewPageIndex;
        this._getcustlist();
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void _getcustlist()
    {
        _cus._Search = TxtUser.Text;
        _grid._GridviewBinding(grid1, _cus._getCustomerlist_View());
        Label4.Text = grid1.Rows.Count.ToString();
    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        _getcustlist();
    }

    protected void LinkAction_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                gettitlescreen.InnerText = "Customer Action";
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
                frm2.Attributes["src"] = "~/CUSTOMERS/customerAction.aspx?CUSTOMERID=" + id.ToString();
                // Response.Redirect("~/Mission/edit.aspx?ticket_no=" + id);
            }
        }
    }

    protected void LinkPayment_Click(object sender, EventArgs e)
    {
        //foreach (GridViewRow row in grid1.Rows)
        //{
        //    CheckBox checkbox = (CheckBox)row.FindControl("check");
        //    if (checkbox.Checked)
        //    {
        //        gettitlescreen.InnerText = "Customer Payment";
        //        string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
        //        System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
        //        frm2.Attributes["src"] = "~/CUSTOMERS/customerpayment.aspx?CUSTOMERID=" + id.ToString();
        //        // Response.Redirect("~/Mission/edit.aspx?ticket_no=" + id);
        //    }
        //}

        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/CUSTOMERS/customerpayment.aspx?CUSTOMERID=" + id);
            }
        }
    }

    protected void linkupload_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                gettitlescreen.InnerText = "Customer Upload image";
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
                frm2.Attributes["src"] = "~/CUSTOMERS/customerupload.aspx?CUSTOMERID=" + id.ToString();
                // Response.Redirect("~/Mission/edit.aspx?ticket_no=" + id);
            }
        }
    }

    protected void linkbtnnew_Click1(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/CUSTOMERS/custServiceAdd.aspx?CUSTOMERID=" + id);
            }
        }
    }
}