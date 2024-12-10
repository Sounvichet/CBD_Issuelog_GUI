using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;
using MasterReportClass;
public partial class Payment_TBSWDSL : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    WingDashBoard _wing = new WingDashBoard();
    Dispute_DashBoard _dis = new Dispute_DashBoard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!IsPostBack)
        {
           // bind_user_name();
            grid_load();
            string script = "$(document).ready(function () { $('[id*=LinkbtnExport]').click(); });";
            ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);

        }
    }
    
    protected void grid_load()
    {
        _grid._GridviewBinding(grid1, _dis._get_ticket_in_progress());
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void grid_load_by_trn()
    {
        _dis.P_TICKET = txttrn_ref.Text;
        _grid._GridviewBinding(grid1, _dis._get_ticket_in_progress_fundamental());
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid1.PageIndex = e.NewPageIndex;
        //this.grid_load();
        Label4.Text = grid1.Rows.Count.ToString();
    }
    //protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //    if (e.CommandName == "lnkedit")
    //    {
    //        int index = Convert.ToInt32(e.CommandArgument);
    //        GridViewRow row = grid1.Rows[index];
    //        Response.Redirect("~/ticket/edit.aspx?ticket_no=" + row.Cells[1].Text);
    //    }
    //    else if (e.CommandName == "InkDelete")
    //    {
    //        int index = Convert.ToInt32(e.CommandArgument);
    //        GridViewRow row = grid1.Rows[index];
    //        Response.Redirect("~/ticket/delete.aspx?ticket_no=" + row.Cells[1].Text);
    //    }
    //    else if (e.CommandName == "lnkView")
    //    {
    //        int index = Convert.ToInt32(e.CommandArgument);
    //        GridViewRow row = grid1.Rows[index];
    //        Response.Redirect("~/ticket/view.aspx?ticket_no=" + row.Cells[1].Text);
    //    }
    //}
    protected void LinkbtnExport_Click(object sender, EventArgs e)
    {
        grid_load_by_trn();
    }

    protected void linkbtnnew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/payment/new_wing_dispute.aspx");
    }

    protected void Linkbtnedit_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/payment/TBSWEDIT.aspx?original_ref=" + id);
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
                Response.Redirect("~/payment/TBSWDEL.aspx?original_ref=" + id);
            }
        }
    }

    protected void LinkBtnview_Click(object sender, EventArgs e)
    {

    }

    protected void Linkconsent_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
                frm2.Attributes["src"] = "~/Payment/wing_consert_form.aspx?TRN_ID=" + id.ToString();
                // Response.Redirect("~/Mission/edit.aspx?ticket_no=" + id);
            }
        }
    }
}