using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;

public partial class Reportchart_NodeDownReason : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    IncidentDashBoards _inc = new IncidentDashBoards();
    string eventid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        eventid = Request.QueryString["EventID"].ToString();
        _inc._ReasonGroupID = eventid;

        if (!IsPostBack)
        {
            _inc._ReasonGroupID = eventid;
            _Get_NodeDownReason();
        }
    }

    protected void _Get_NodeDownReason()
    {
        _grid._GridviewBinding(grid1, _inc._Get_NodeDownReason());
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        eventid = Request.QueryString["GroupID"].ToString();
        Response.Redirect("~/Reportchart/new_downReason.aspx?ReasonGroupid=" + eventid);
    }
    protected void btnedit_click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/FC/edit.aspx?ReasonGroupid=" + id);
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
                Response.Redirect("~/FC/delete.aspx?ID_CARD=" + id);
            }
        }
    }

    protected void btnupload_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FC/upload.aspx");
    }

    //protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    //{

    //    if (e.CommandName == "lnkedit")
    //    {
    //        int index = Convert.ToInt32(e.CommandArgument);
    //        GridViewRow row = grid1.Rows[index];
    //        Response.Redirect("~/FC/edit.aspx?ID_CARD=" + row.Cells[1].Text);
    //    }
    //    else if (e.CommandName == "InkDelete")
    //    {
    //        int index = Convert.ToInt32(e.CommandArgument);
    //        GridViewRow row = grid1.Rows[index];
    //        Response.Redirect("~/FC/delete.aspx?ID_CARD=" + row.Cells[1].Text);
    //    }
    //    else if (e.CommandName == "lnkView")
    //    {
    //        int index = Convert.ToInt32(e.CommandArgument);
    //        GridViewRow row = grid1.Rows[index];
    //        Response.Redirect("~/FC/view.aspx?ID_CARD=" + row.Cells[1].Text);
    //    }
    //}
    protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid1.PageIndex = e.NewPageIndex;
        this._Get_NodeDownReason();
        Label4.Text = grid1.Rows.Count.ToString();
    }

    protected void btn_apply_Click(object sender, EventArgs e)
    {
    }


    protected void LinkBtbcancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Reportchart/nodedowntype.aspx");
    }
}