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

public partial class Payment_FEE : System.Web.UI.Page
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
        //Pdate.InnerText = idedit;
        Label1.InnerText = idedit;
        if (!this.IsPostBack)
        {
            _getFEEFastSettlement();
        }
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        //bool newRow = false;
        //if ((_Fastamt > 0) && (DataBinder.Eval(e.Row.DataItem, "TRN_DATE") != null))
        //{
        //    string _getitem = (DataBinder.Eval(e.Row.DataItem, "TRN_DATE").ToString());   // e.Row.Cells[11].Text.ToString();
        //    if (storid != _getitem)
        //        newRow = true;
        //    //rowIndex = 1;
        //}

        //if ((_Fastamt > 0) && (DataBinder.Eval(e.Row.DataItem, "TRN_DATE") == null))
        //{
        //    newRow = true;
        //    rowIndex = 0;
           
           
        //}

        //if (newRow)
        //{
        //    AddNewRow(sender, e);
            
        //}


    }
    //protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    //{
    //    //int count = GridView1.Columns.Count-1;

    //    //for (int i = count; i >= 1; i--)
    //    //{
    //    //    GridView1.Columns[i].Visible = false;
    //    //}

    //    //if (e.Row.RowType == DataControlRowType.DataRow)
    //    //{
    //    //    storid = DataBinder.Eval(e.Row.DataItem, "FEE_DATE").ToString();
    //    //    _Fastamt = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "TRN_AMOUNT"));
    //    //}
    //    //if (e.Row.RowType == DataControlRowType.DataRow)
    //    //{
    //    //    total = total + Convert.ToDecimal(e.Row.Cells[9].Text);
    //    //}


    //    //if (e.Row.RowType == DataControlRowType.DataRow)
    //    //{
    //    //    e.Row.Cells[5].Text = Convert.ToDateTime(e.Row.Cells[5].Text).ToString("dd/MMM/yyyy").Replace('/', '-');
    //    //}
    //}
    public void AddNewRow(object sender, GridViewRowEventArgs e)
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
        HeaderCell.Text = "Transaction Type: INCOMING - SUCCESS, Count :" + GridView1.Rows.Count.ToString();
        HeaderCell.HorizontalAlign = HorizontalAlign.Left;
        NewTotalRow.Cells.Add(HeaderCell);
        GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + rowIndex, NewTotalRow);
        AddNewRow_total(sender, e);
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
    //protected void OnDataBound(object sender, EventArgs e)
    //{
    //    GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);

    //    TableHeaderCell cell = new TableHeaderCell();
    //    cell.Text = "No";
    //    cell.RowSpan = 2;
    //    row.Controls.Add(cell);

    //    cell = new TableHeaderCell();
    //    cell.RowSpan = 2;
    //    cell.Text = "Branch Name";
    //    row.Controls.Add(cell);


    //    cell = new TableHeaderCell();
    //    cell.ColumnSpan = 3;
    //    cell.Text = "Outgoing Fee";
    //    row.Controls.Add(cell);

    //    cell = new TableHeaderCell();
    //    cell.Text = "Incoming Fee";
    //    row.Controls.Add(cell);

    //    cell = new TableHeaderCell();
    //    cell.RowSpan = 2;
    //    cell.Text = "Branch Net Fee";
    //    row.Controls.Add(cell);

    //    cell = new TableHeaderCell();
    //    cell.RowSpan = 2;
    //    cell.Text = "NBC Net Fee";
    //    row.Controls.Add(cell);

    //    row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
    //    GridView1.HeaderRow.Parent.Controls.AddAt(0, row);
    //}
    private void _getFEEFastSettlement()
    {
        DataTable dt = _payment._PR_FASTPAYMENT_STM_FEE(idedit);
        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
        GridView1.DataSource = ds;

        double totalamt1 = 0;
        double totalamt2 = 0;
        double totalamt3 = 0;
        double totalamt4 = 0;
        double totalamt5 = 0;
        double totalamt6 = 0;
        foreach (DataRow dr in ds.Tables[0].Rows)
        {
            totalamt1 += Convert.ToDouble(dr["OUT_TOTAL_FEE"]);
            totalamt2 += Convert.ToDouble(dr["OUT_TOTAL_FEE"]);
            totalamt3 += Convert.ToDouble(dr["IN_TOTAL_FEE"]);
            totalamt4 += Convert.ToDouble(dr["TOTAL_NET_FEE"]);
            totalamt5 += Convert.ToDouble(dr["NET_NBC"]);
            totalamt6 += Convert.ToDouble(dr["AP_BAL"]);
            
        }

        GridView1.Columns[2].FooterText = totalamt1.ToString("f2");
        GridView1.Columns[3].FooterText = totalamt2.ToString("f2");
        GridView1.Columns[4].FooterText = totalamt6.ToString("f2");
        GridView1.Columns[5].FooterText = totalamt3.ToString("f2");
        GridView1.Columns[6].FooterText = totalamt4.ToString("f2");
        GridView1.Columns[7].FooterText = totalamt5.ToString("f2");
        
        GridView1.DataBind();
        ds.Dispose();







    }
    protected void OnDataBound(object sender, EventArgs e)  //EventArgs e
    {
        GridView1.HeaderRow.Cells[0].Visible = false;
        GridView1.HeaderRow.Cells[1].Visible = false;
        GridView1.HeaderRow.Cells[6].Visible = false;
        GridView1.HeaderRow.Cells[7].Visible = false;
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = "No";
        cell.CssClass = "vertical-middle";
        row.Controls.Add(cell);
        cell.RowSpan = 2;
        

        cell = new TableHeaderCell();
        cell.Text = "Branch_Name";
        cell.CssClass = "vertical-middle";
        row.Controls.Add(cell); 
        cell.RowSpan = 2;

        cell = new TableHeaderCell();
        cell.ColumnSpan = 3;
        cell.Text = "Outgoing Fee";
        cell.CssClass = "vertical-middle";
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.Text = "Incoming Fee";
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.Text = "Branch NetFee";
        cell.CssClass = "vertical-middle";
        row.Controls.Add(cell);
        cell.RowSpan = 2;

        cell = new TableHeaderCell();
        cell.Text = "NBC NetFee";
        cell.CssClass = "vertical-middle";
        row.Controls.Add(cell);
        cell.RowSpan = 2;

        row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
        GridView1.HeaderRow.Parent.Controls.AddAt(0, row);
        //check if the row is the header row

       
    }



    

}