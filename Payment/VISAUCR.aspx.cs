using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;
using VisaClearingClass;

public partial class Payment_VISAUCR : System.Web.UI.Page
{
    //SqlConnection sqlc = new SqlConnection();
    //logger _logger = new logger();
    //SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    //MaintenanceFeeDashBoard _fee = new MaintenanceFeeDashBoard();
    //Visa_payment_dashboard _visa = new Visa_payment_dashboard();
    UpdateCustReferece _visa = new UpdateCustReferece();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!IsPostBack)
        {
            string script = "$(document).ready(function () { $('[id*=LinkbtnExport]').click(); });";
            ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
            Label4.Text = grid1.Rows.Count.ToString();
        }
    }
    protected void grid_username()
    {

        // obj.Grid_by_username(D_User_name.Text, grid1);
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Payment/new_ticket_dispute.aspx");
    }
    protected void btnedit_click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/Payment/edit_visa_cbs_reference.aspx?refnum=" + id);
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
                Response.Redirect("~/Payment/edit_visa_cbs_reference.aspx?refnum=" + id);
            }
        }
    }
    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkedit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/Payment/edit_visa_cbs_reference.aspx?refnum=" + row.Cells[4].Text);
        }
    }

    protected void Linkbtnsearch_Click(object sender, EventArgs e)
    {
        _visa.p_RRN = t_search.Text;
        _grid._GridviewBinding(grid1, _visa._get_VISA_List_by_RRN());
        Label4.Text = grid1.Rows.Count.ToString();
    }
}