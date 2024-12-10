using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Drawing;

public partial class User_guide_Form_userguide : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    DropDownListValues _drop = new DropDownListValues();
    GridViewValues _grid = new GridViewValues();
    FormUserGuide _guide = new FormUserGuide();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        Label4.Text = grid1.Rows.Count.ToString();

        if (!this.IsPostBack)
        {
            _gridviewformload();
            //grid1.HeaderStyle.BackColor = Color.FromName("#01559E");
            grid1.HeaderStyle.Font.Bold = true;
            //grid1.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        }
        this.RegisterPostBackControl();
    }
    public void _gridviewformload ()
    {
        _grid._GridviewBinding(grid1, _guide.D_grid_formuserguide());
        Label4.Text = grid1.Rows.Count.ToString();
    }
    public void _gridviewbyservice()
    {
        _grid._GridviewBinding(grid1, _guide.D_grid_formuserguidebyservice(D_indicator.Text, D_service.SelectedValue));
        Label4.Text = grid1.Rows.Count.ToString();
    }

    protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        grid1.PageIndex = e.NewPageIndex;
        _gridviewbyservice();
       // this._gridviewformload();
        //this._drop_Indicator();
        Label4.Text = grid1.Rows.Count.ToString();
    }
    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {

        if (e.CommandName == "lnkedit")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/User_guide/edit.aspx?Form_code=" + row.Cells[1].Text);
        }
        else if (e.CommandName == "InkDelete")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            Response.Redirect("~/User_guide/delete.aspx?Form_code=" + row.Cells[1].Text);
        }
    }
    protected void OnDownload(object sender, EventArgs e)
    {
        try
        {
            
            LinkButton lbtn = (LinkButton)sender;
            GridViewRow row = (GridViewRow)lbtn.NamingContainer;
            string _query = "select f.Form_name,f.Post_date,F.Post_by,f.name,f.file_size,f.data from tbl_cbd_form f where f.form_code = "+ row.Cells[1].Text + "";
            _sqlcmd._command_Query(_query, ref cmd);
            //com.Parameters.AddWithValue("form_code", row.Cells[1].Text);
            
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {
                Response.Clear();
                Response.Buffer = true;
                Response.ContentType = dr["file_size"].ToString();
                Response.AddHeader("content-disposition", "attachment;filename=" + dr["Name"].ToString());     // to open file prompt Box open or Save file         
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.BinaryWrite((byte[])dr["data"]);
                Response.End();
            }
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
    protected void D_service_SelectedIndexChanged(object sender, EventArgs e)
    {
        _gridviewbyservice();
        this.RegisterPostBackControl();
    }
    protected void D_indicator_SelectedIndexChanged(object sender, EventArgs e)
    {
        _drop_Indicator();
    }
    public void _drop_Indicator()
    {
        _drop.bindDropDownList(D_service, _guide.D_bind_indicatorbyService(D_indicator.Text));
    }
    private void RegisterPostBackControl()
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            LinkButton lnkFull = row.FindControl("LNKdownload") as LinkButton;
            ScriptManager.GetCurrent(this).RegisterPostBackControl(lnkFull);
        }
    }
    protected void btnNew_Click(object sender, EventArgs e)
    {
        //  Response.Redirect("~/TestPro/ticket/new.aspx");
        Response.Redirect("~/User_guide/new.aspx");
    }
    protected void btnedit_click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/User_guide/edit.aspx?Form_Code=" + id);
            }


        }
    }
    protected void btndelete_click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/User_guide/delete.aspx?Form_Code=" + id);
            }


        }
    }
    protected void btnview_click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                string id = Convert.ToString(grid1.DataKeys[row.RowIndex].Value);
                Response.Redirect("~/User_guide/view.aspx?Form_Code=" + id);
            }


        }
    }
    //protected void OnDataBound(object sender, EventArgs e)  //EventArgs e
    //{

    //    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
    //    TableHeaderCell cell = new TableHeaderCell();
    //    TableCell tcell = new TableCell();



    //    row.BackColor = ColorTranslator.FromHtml("#3AC0F2");

    //    grid1.HeaderRow.Parent.Controls.AddAt(0, row);
    //    //check if the row is the header row


    //}
    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    grid1.HeaderStyle.BackColor = Color.FromName("#01559E");
    //    grid1.HeaderStyle.Font.Bold = true;
    //    grid1.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");

    //    if (e.Row.RowType == DataControlRowType.DataRow)
    //    {
    //        int values = (int)DataBinder.Eval(e.Row.DataItem, "Size");
            
    //            if (values <= 60)
    //            {
    //                e.Row.Cells[6].Font.Bold = true;
    //                e.Row.Cells[6].ForeColor = Color.FromName("Blue");
    //            }
    //            if (values > 60)
    //            {
    //                e.Row.Cells[6].Font.Bold = true;
    //                e.Row.Cells[6].ForeColor = Color.FromName("Orange");
    //            }
    //            if (values >= 300)
    //            {

    //            Decimal result;
    //                e.Row.Cells[6].Font.Bold = true;
    //                e.Row.Cells[6].ForeColor = Color.FromName("Red");
    //            if ((decimal.TryParse(e.Row.Cells[6].Text, out result)))
    //            {
    //                e.Row.Cells[6].Text = String.Format("{0:#,##0.00}", result);
    //            }
                   
    //        }
            
            
    //        //string _days = (string)DataBinder.Eval(e.Row.DataItem, "GetDays");
    //        //if (_days == "WeekendDay")
    //        //{
    //        //    e.Row.BackColor = Color.FromName("#F1F9FE");
    //        //}

    //        //if (_days == "WorkingDay")
    //        //{
    //        //    e.Row.BackColor = Color.FromName("#E0F1FF");
    //        //}


    //    }


    //}
}