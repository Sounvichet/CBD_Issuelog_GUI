using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.Data;
using MasterReportClass;
using System.Data.SqlClient;
using System.Drawing;
public partial class Payment_index : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    IncidentDashBoards _incident = new IncidentDashBoards();
    DropDownListValues _drop = new DropDownListValues();
    ReportPayment _payment = new ReportPayment();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string date = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        if (!IsPostBack)
        {
            txtgenerate.Text = date;
           // _getfastdate();
            Label4.Text = grid1.Rows.Count.ToString();
        }

    }
    private void _getfastdate()
    {
        _grid._GridviewBinding(grid1, _payment.D_getFastDate());
    }
    private void _getfasthis()
    {
        _grid._GridviewBinding(grid1, _payment.D_getFastDateHIS(txtgenerate.Text));
    }
    private void _getgridload()
    {
         //--HH:mm:ss 
        //_grid._GridviewBinding(grid1, _payment._PR_FASTPAYMENT_STM_LIST(DateTime.Parse(date)));
    }

    protected void btnprint_Click(object sender, EventArgs e)
    {
        //foreach (GridViewRow row in grid1.Rows)
        //{
        //    CheckBox checkbox = (CheckBox)row.FindControl("check");
        //    if (checkbox.Checked)
        //    {
        //        int index = Convert.ToInt32(grid1.DataKeys[row.RowIndex].Value);
        //        //string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
        //        //GridViewRow row1 = grid1.Rows[index];
        //        string _getscreen = row.Cells[7].Text.ToString();
        //        System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);

        //        if (_getscreen == "Listing")
        //        {
        //            frm2.Attributes["src"] = "~/Payment/Fastlisting.aspx?GetDate=" + row.Cells[3].Text.ToString();
        //        }
        //        if (_getscreen == "Summary")
        //        {
        //            frm2.Attributes["src"] = "~/Payment/fastsummary.aspx?GetDate=" + row.Cells[3].Text.ToString();
        //        }
        //        else
        //        {
        //            frm2.Attributes["src"] = "~/Payment/FEE.aspx?GetDate=" + row.Cells[3].Text.ToString();
        //        }

        //        // Response.Redirect("~/Mission/edit.aspx?ticket_no=" + id);
        //    }
        //}
    }
    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "lnkprint")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            string _getscreen =  row.Cells[7].Text.ToString();
            System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
            if (_getscreen == "Listing")
            {
                frm2.Attributes["src"] = "~/Payment/Fastlisting.aspx?GetDate=" + row.Cells[3].Text.ToString();
            }
            if (_getscreen == "Summary")
            {
                frm2.Attributes["src"] = "~/Payment/fastsummary.aspx?GetDate=" + row.Cells[3].Text.ToString();
            }
            if (_getscreen == "Fee")
            {
                frm2.Attributes["src"] = "~/Payment/FEE.aspx?GetDate=" + row.Cells[3].Text.ToString();
            }


        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        grid1.HeaderStyle.BackColor = Color.FromName("#01559E");
        grid1.HeaderStyle.Font.Bold = true;
        grid1.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string _Category = (string)DataBinder.Eval(e.Row.DataItem, "CATEGORY");
            {
                if (_Category == "Listing")
                {
                    e.Row.Cells[7].VerticalAlign = VerticalAlign.Middle;
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[7].Font.Bold = true;
                    e.Row.Cells[7].ForeColor = Color.Green;
                }
                if (_Category == "Summary")
                {
                    e.Row.Cells[7].VerticalAlign = VerticalAlign.Middle;
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[7].Font.Bold = true;
                    e.Row.Cells[7].ForeColor = Color.Green;
                }
                if (_Category == "Fee")
                {

                    e.Row.Cells[7].VerticalAlign = VerticalAlign.Middle;
                    e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
                    e.Row.Cells[7].Font.Bold = true;
                    e.Row.Cells[7].ForeColor = Color.Green;

                }
            }




        }
    }

    protected void Linkbtnapply_Click(object sender, EventArgs e)
    {
      //  _getfasthis();
    }
}
