using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;

public partial class CURRENCY_index : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    CurrencyDashboard _CCY = new CurrencyDashboard();
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
     
    }
    protected void Linkbtnedit_Click1(object sender, EventArgs e)
    {

    }

    protected void LinkBtndel_Click(object sender, EventArgs e)
    {

    }

    protected void LinkBtnview_Click(object sender, EventArgs e)
    {

    }

    protected void Linkprint_Click(object sender, EventArgs e)
    {
       
    }
    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "lnkedit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/ticket/edit.aspx?CUSTOMERID=" + row.Cells[1].Text);
        }
        else if (e.CommandName == "InkDelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/ticket/delete.aspx?CUSTOMERID=" + row.Cells[1].Text);
        }
        else if (e.CommandName == "lnkView")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/ticket/view.aspx?CUSTOMERID=" + row.Cells[1].Text);
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
        _grid._GridviewBinding(grid1, _CCY._getCurrencyListing());
        Label4.Text = grid1.Rows.Count.ToString();
    }
}