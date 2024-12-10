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

public partial class Payment_fastsummary : System.Web.UI.Page
{
    string idedit = "";
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    IncidentDashBoards _incident = new IncidentDashBoards();
    DropDownListValues _drop = new DropDownListValues();
    ReportPayment _payment = new ReportPayment();
    string _getsession = "";
    int rowIndex = 0;
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
            _getFastSettlement();
        }
    }
    protected void GridView1_RowCreated(object sender, GridViewRowEventArgs e)
    {
        bool newRowM = false;
        bool newRowA = false;
        //if ((_Fastamt > 0) && (DataBinder.Eval(e.Row.DataItem, "TRN_DATE") != null))
        //{
        //    string _getitem = (DataBinder.Eval(e.Row.DataItem, "TRN_DATE").ToString());   // e.Row.Cells[11].Text.ToString();
        //    if (storid != _getitem)
        //        newRow = true;
        //    //rowIndex = 1;
        //}
      
        if ((_getsession == "M"))  //(DataBinder.Eval(e.Row.DataItem, "TRN_DATE") == null)
        {
            newRowM = true;
            rowIndex = 0;
            // rowIndex = 0;
        }
        
        if ((_getsession == "A"))  //(DataBinder.Eval(e.Row.DataItem, "TRN_DATE") == null)
        {
            newRowA = true;
            rowIndex = 4;

        }


        if (newRowM)
        {
            AddNewRowM(sender, e);

        }
        if (newRowA)
        {
            AddNewRow(sender, e);

        }
    
        //if (newrowT)
        //{
        //    AddNewRowTOTAL(sender, e);

        //}
    }
    protected void OnDataBound(object sender, EventArgs e)
    {
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Normal);
        
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = "Outgoing Transaction";
        cell.ColumnSpan = 2;
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 2;
        cell.Text = "Incoming Transaction";
        row.Controls.Add(cell);
        

        cell = new TableHeaderCell();
        cell.ColumnSpan = 2;
        cell.Text = "Net Position";
        row.Controls.Add(cell);
        

        row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
        GridView1.HeaderRow.Parent.Controls.AddAt(0, row);
    }
    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            _getsession = DataBinder.Eval(e.Row.DataItem, "SETTLE_SESSION").ToString();
            _Fastamt = Convert.ToInt32(DataBinder.Eval(e.Row.DataItem, "NET_AMOUNT"));
        }
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            total = total + Convert.ToDecimal(e.Row.Cells[4].Text);
        }
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    e.Row.Cells[5].Text = Convert.ToDateTime(e.Row.Cells[5].Text).ToString("dd/MMM/yyyy").Replace('/', '-');
        //}
    }
    public void AddNewRowTOTAL(object sender, GridViewRowEventArgs e)
    {
        GridView GridView1 = (GridView)sender;
        GridViewRow NewTotalRow = new GridViewRow(0, 0, DataControlRowType.DataRow, DataControlRowState.Insert);
        NewTotalRow.Font.Bold = true;
        NewTotalRow.BackColor = Color.FromName("#01559E");
        NewTotalRow.ForeColor = Color.FromName("#f5f5f5");
        TableCell HeaderCell = new TableCell();
        TableCell HeaderCell1 = new TableCell();
        HeaderCell.Height = 10;
        HeaderCell.ColumnSpan = 4;
        HeaderCell.Font.Size = 10;
        HeaderCell.Text = "Total Amount :";
        HeaderCell.HorizontalAlign = HorizontalAlign.Right;
        /////
        HeaderCell1.Height = 10;
        HeaderCell1.ColumnSpan = 2;
        HeaderCell1.Font.Size = 10;
        HeaderCell1.Text = total.ToString("F2");
        HeaderCell1.HorizontalAlign = HorizontalAlign.Left;
        NewTotalRow.Cells.Add(HeaderCell);
        NewTotalRow.Cells.Add(HeaderCell1);
        GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + rowIndex, NewTotalRow);
        rowIndex++;
    }
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
        HeaderCell.Text = "Afternoon (2.30PM)";
        HeaderCell.HorizontalAlign = HorizontalAlign.Left;
        NewTotalRow.Cells.Add(HeaderCell);
        GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + rowIndex, NewTotalRow);
        rowIndex =6;
        AddNewRowTOTAL(sender, e);
    }
    public void AddNewRowM(object sender, GridViewRowEventArgs e)
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
        HeaderCell.Text = "Morning (9.45AM)";
        HeaderCell.HorizontalAlign = HorizontalAlign.Left;
        NewTotalRow.Cells.Add(HeaderCell);
        GridView1.Controls[0].Controls.AddAt(e.Row.RowIndex + rowIndex, NewTotalRow);
        rowIndex++;
    }
    private void _getFastSettlement()
    {
        DataTable getrecord = _payment.PR_FASTPAYMENT_STM_SMY(idedit);
        _grid._GridviewBinding(GridView1, getrecord);
        //_getTotalamt = getrecord.AsEnumerable().Sum(row => row.Field<decimal>("TRN_AMOUNT")).ToString();
    }
}