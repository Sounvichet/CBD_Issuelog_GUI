using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;

public partial class Terminal_index : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    ATMTerminalDashboard _atm = new ATMTerminalDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!IsPostBack)
        {
            _Get_ATMTID_listing();
        }
    }

    protected void _Get_ATMTID_listing()
    {
        _grid._GridviewBinding(grid1, _atm.d_get_ATMTerminallisting());
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        //  Response.Redirect("~/TestPro/ticket/new.aspx");
        Response.Redirect("~/FC/new.aspx");
    }
    protected void btnedit_click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/Terminal/edit.aspx?TID=" + id);
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
        this._Get_ATMTID_listing();
        Label4.Text = grid1.Rows.Count.ToString();
    }

    protected void btn_apply_Click(object sender, EventArgs e)
    {
    }

    private void _getexcelticketlisting()
    {

        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = _atm.d_get_ATMTerminallisting();
        wb.Worksheets.Add(dt, "FC_ENGINEER_LIST");

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=FC_ENGINEER_LIST.xlsx");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");

    }


}