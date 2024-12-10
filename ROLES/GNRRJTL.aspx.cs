using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;

public partial class ROLES_GNRRJTL : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    ROLESDashboard _role = new ROLESDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            _getgridjobtitileGroup();
        }
    }
    private void _getgridjobtitileGroup()
    {
        _grid._GridviewBinding(gridgroup, _role._GetSYSJOBTITLEGROUPLIST());
        Label4.Text = gridgroup.Rows.Count.ToString();
    }
    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "LinkEdit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gridgroup.Rows[index];
            Response.Redirect("~/ROLE/edit.aspx?SERVICEID=" + row.Cells[4].Text);
        }
        else if (e.CommandName == "LinkDelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gridgroup.Rows[index];
            Response.Redirect("~/ROLE/delete.aspx?SERVICEID=" + row.Cells[4].Text);
        }
        else if (e.CommandName == "lnkView")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = gridgroup.Rows[index];
            Response.Redirect("~/ROLE/view.aspx?SERVICEID=" + row.Cells[4].Text);
        }
    }
    private void _getJobtitlelistbyID()
    {
        _role._jobtitle = txtrole.Text;
        _grid._GridviewBinding(gridgroup, _role._GetjobtitlelistbyTitle());
        Label4.Text = gridgroup.Rows.Count.ToString();
    }
    protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        gridgroup.PageIndex = e.NewPageIndex;
        _getJobtitlelistbyID();
        Label4.Text = gridgroup.Rows.Count.ToString();
    }
    protected void linkbtnnew_Click(object sender, EventArgs e)
    {

    }

    protected void Linkbtnedit_Click(object sender, EventArgs e)
    {

    }

    protected void LinkBtndel_Click(object sender, EventArgs e)
    {

    }

    protected void LinkBtnview_Click(object sender, EventArgs e)
    {

    }

    protected void LinkPermission_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in gridgroup.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                GetTitlescreen.InnerText = "JobTitleuserGroupid";
                string id = Convert.ToString(row.Cells[1].Text);
                System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
                frm2.Attributes["src"] = "~/ROLES/GetJobtitlegroupid.aspx?TITLEID=" + id;
                frm2.Attributes.Add("style", "width:100%;height:400px;");
            }
        }
    }

    protected void Linkexport_Click(object sender, EventArgs e)
    {

    }

    protected void btnsearch_Click(object sender, EventArgs e)
    {
        _getJobtitlelistbyID();
    }

    
}