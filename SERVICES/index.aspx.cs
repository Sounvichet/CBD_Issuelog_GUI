using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;

public partial class SERVICES_index : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    ServiceDashboard _service = new ServiceDashboard();
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
        Response.Redirect("~/SERVICES/new.aspx");
    }
    protected void Linkbtnedit_Click1(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(row.Cells[4].Text);
                Response.Redirect("~/SERVICES/edit.aspx?SERVICEID=" + id);
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
                string id = Convert.ToString(row.Cells[4].Text);
                Response.Redirect("~/SERVICES/delete.aspx?SERVICEID=" + id);
            }


        }
    }

    protected void LinkBtnview_Click(object sender, EventArgs e)
    {

    }

    protected void Linkprint_Click(object sender, EventArgs e)
    {

    }
    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "LinkEdit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/SERVICES/edit.aspx?SERVICEID=" + row.Cells[4].Text);
        }
        else if (e.CommandName == "LinkDelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/SERVICES/delete.aspx?SERVICEID=" + row.Cells[4].Text);
        }
        else if (e.CommandName == "lnkView")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/SERVICES/view.aspx?SERVICEID=" + row.Cells[4].Text);
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
        _grid._GridviewBinding(grid1, _service._getServicesListing());
        Label4.Text = grid1.Rows.Count.ToString();
    }
    //private void export_serviceType()
    //{
    //    try
    //    {
    //        XLWorkbook wb = new XLWorkbook();
    //        DataTable dt = new DataTable();

    //        if (grid1.HeaderRow != null)
    //        {

    //            for (int i = 0; i < grid1.HeaderRow.Cells.Count; i++)
    //            {
    //                dt.Columns.Add(grid1.HeaderRow.Cells[i].Text);
    //            }
    //        }

    //        //  add each of the data rows to the table
    //        foreach (GridViewRow row in grid1.Rows)
    //        {
    //            DataRow dr;
    //            dr = dt.NewRow();

    //            for (int i = 0; i < row.Cells.Count; i++)
    //            {
    //                dr[i] = row.Cells[i].Text.Replace("&nbsp;", "");
    //            }
    //            dt.Rows.Add(dr);
    //        }

    //        //  add the footer row to the table
    //        if (grid1.FooterRow != null)
    //        {
    //            DataRow dr;
    //            dr = dt.NewRow();

    //            for (int i = 0; i < grid1.FooterRow.Cells.Count; i++)
    //            {
    //                dr[i] = grid1.FooterRow.Cells[i].Text.Replace("&nbsp;", "");
    //            }
    //            dt.Rows.Add(dr);
    //        }



    //        wb.Worksheets.Add(dt, "Service_type");
    //        Response.Clear();
    //        Response.Buffer = true;
    //        Response.Charset = "";
    //        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //        Response.AddHeader("content-disposition", "attachment;filename=Service_type.xlsx");
    //        System.IO.MemoryStream memory = new System.IO.MemoryStream();
    //        wb.SaveAs(memory);
    //        memory.WriteTo(Response.OutputStream);
    //        Response.Flush();
    //        Response.End();
    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex);
    //    }
    //    finally
    //    {
    //        sqlc.Close();
    //        sqlc.Dispose();
    //        SqlConnection.ClearPool(sqlc);
    //    }

    //}

    private void _getexcel_servicetype()
    {
        try
        {
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = new DataTable();

            dt = _service._getServicesListing();
            wb.Worksheets.Add(dt, "Service_type");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=Service_type.xlsx");
            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            wb.SaveAs(memory);
            memory.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    protected void Linkexport_Click(object sender, EventArgs e)
    {
        _getexcel_servicetype();
    }

    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        string _days = (string)DataBinder.Eval(e.Row.DataItem, "SERVICESTATUS");
        if (_days == "Active")
        {
            e.Row.Cells[7].HorizontalAlign = HorizontalAlign.Center;
        }
    }
}