using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class Payment_Fastlisting : System.Web.UI.Page
{
    string idedit = "";
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    IncidentDashBoards _incident = new IncidentDashBoards();
    DropDownListValues _drop = new DropDownListValues();
    ReportPayment _payment = new ReportPayment();
    string storid = "";
    int rowIndex = 1;
    int _Fastamt;
    decimal total = 0;
    string _getTotalamt = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        idedit = Request.QueryString["GetDate"].ToString();
        lbldate.InnerText = idedit;
        if (!this.IsPostBack)
        {
           // _getFastSettlement();

        }
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        bool newRow = false;
        if ((_Fastamt > 0))
        {
            //string _getitem = (DataBinder.Eval(e.Row.DataItem, "TRN_DATE").ToString());   // e.Row.Cells[11].Text.ToString();
               // newRow = true;
            //rowIndex = 1;
        }

        if ((_Fastamt > 0) && (DataBinder.Eval(e.Row.DataItem, "TRN_DATE") == null))
        {
            newRow = true;
            rowIndex = 0;


        }

        if (newRow)
        {
            AddNewRow(sender, e);
            
        }
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            storid = DataBinder.Eval(e.Row.DataItem, "TRN_DATE").ToString();
            _Fastamt = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TRN_AMOUNT"));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            total = total + Convert.ToDecimal(e.Row.Cells[9].Text);
        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[5].Text = Convert.ToDateTime(e.Row.Cells[5].Text).ToString("dd/MMM/yyyy").Replace('/', '-');
        //}
    }
    public void AddNewRow(object sender, GridViewRowEventArgs e)
    {
        GridView GridView1 = (GridView)sender;
        GridViewRow NewTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
        NewTotalRow.Font.Bold = true;
        NewTotalRow.BackColor = Color.FromName("#01559E");
        NewTotalRow.ForeColor = Color.FromName("#f5f5f5");
        TableCell HeaderCell = new TableCell();
        TableCell HeaderTotal = new TableCell();
        HeaderCell.Height = 10;
        //HeaderCell.ColumnSpan = 13;
        HeaderCell.Font.Size = 10;
        HeaderCell.Text = "Transaction Type: INCOMING - SUCCESS, Count :" + GridView1.Rows.Count.ToString();
        HeaderCell.HorizontalAlign = HorizontalAlign.Left;
        NewTotalRow.Cells.Add(HeaderCell);

        HeaderTotal.Height = 10;
        HeaderTotal.ColumnSpan = 11;
        HeaderTotal.Font.Size = 10;
        HeaderTotal.Text = "Total (INCOMING - SUCCESS) :" + total.ToString("F2");
        HeaderTotal.HorizontalAlign = HorizontalAlign.Right;
        NewTotalRow.Cells.Add(HeaderTotal);


        GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + rowIndex, NewTotalRow);
       // AddNewRow_total(sender, e);
        rowIndex++;
    }
    public void AddNewRow_total(object sender, GridViewRowEventArgs e)
    {
        GridView GridView1 = (GridView)sender;
        GridViewRow NewTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
        NewTotalRow.Font.Bold = true;
        NewTotalRow.BackColor = Color.FromName("#01559E");
        NewTotalRow.ForeColor = Color.FromName("#f5f5f5");
        TableCell HeaderCell = new TableCell();
        HeaderCell.Height = 10;
        HeaderCell.ColumnSpan = 13;
        HeaderCell.Font.Size = 10;
        HeaderCell.Text = "Total (INCOMING - SUCCESS) :" + total;
        HeaderCell.HorizontalAlign = HorizontalAlign.Left;
        NewTotalRow.Cells.Add(HeaderCell);
        GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + rowIndex, NewTotalRow);
        rowIndex++;
    }
   
    private void _getFastSettlement()
    {
        DataTable getrecord = _payment._PR_FASTPAYMENT_STM_LIST(idedit);
        _grid._GridviewBinding(GridView1, getrecord);
        _getTotalamt = getrecord.AsEnumerable().Sum(row => row.Field<decimal>("TRN_AMOUNT")).ToString();
      
      
    }
}