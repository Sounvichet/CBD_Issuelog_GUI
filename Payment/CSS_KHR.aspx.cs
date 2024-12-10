using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;
using System.Drawing;

public partial class Payment_CSS_KHR : System.Web.UI.Page
{
    CSSdashboard _CSS = new CSSdashboard();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    SqlConnection sqlc = new SqlConnection();
    GridViewValues _grid = new GridViewValues();
    string getdate = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            Page.ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'> window.top.location.href = '../Default.aspx'; </script>");
        }

        getdate = Request.QueryString["GetDate"].ToString();
        Date_settle.InnerText = getdate;
        if (!this.IsPostBack)
        {
            //Populating a DataTable from database.
            // this._getCSS_KHR();
           // getcsstotal();
        }
    }

    //private void _getCSS_KHR()
    //{
    //    //string query = "exec SelectString 'TMSEL','UW1'";
    //    string query = "Select 'Hello'";
    //    _sqlcmd._command_Query(query, ref cmd);
    //    SqlDataReader dr = cmd.ExecuteReader();
    //    StringBuilder html = new StringBuilder();

    //    html.Append("<table class= 'tablecenter trbgcolor' border = '1'>");

    //    //table start 
    //    html.Append("<table>");
    //    int index = 1;
    //    while (dr.Read())
    //    {
    //        if (index == 1)
    //        {
    //            html.Append("<tr>");

    //            for (int i = 0; i < dr.FieldCount; i++)
    //            {
    //                html.Append("<td>");
    //                html.Append(dr.GetName(i));
    //                html.Append("</td>");
    //            }
    //            html.Append("</tr>");
    //        }
    //        index++;
    //        html.Append("<tr>");
    //        for (int i = 0; i < dr.FieldCount; i++)
    //        {
    //            html.Append("<td>");
    //            html.Append(dr.GetValue(i));
    //            html.Append("</td>");
    //        }
    //        html.Append("</tr>");
    //        html.Append("</table>");

    //        PlaceHolder1.Controls.Add(new Literal { Text = html.ToString() });
    //        sqlc.Close();
    //    }
    //}
    private void _getCSSsettlement()
    {
        //_grid._GridviewBinding(GridView1, _CSS._get_CSS_SETTLEMENT("28-Jul-2020", "KHR"));
    }

    //private void getcsstotal()
    //{
    //    DataTable dt = _CSS._get_CSS_SETTLEMENT(getdate, "KHR");

    //    double totalamt1 = 0;
    //    double totalamt2 = 0;
    //    double totalamt3 = 0;
    //    double totalamt4 = 0;
    //    foreach (DataRow dr in dt.Rows)
    //    {
    //        totalamt1 += Convert.ToDouble(dr["AMT_SETTLE_i"]);
    //        totalamt2 += Convert.ToDouble(dr["FEE_Income"]);
    //        totalamt3 += Convert.ToDouble(dr["AMT_SETTLE_O"]);
    //        totalamt4 += Convert.ToDouble(dr["FEE_Sharing"]);
    //        //totalamt5 += Convert.ToDouble(dr["NET_NBC"]);
    //        //totalamt6 += Convert.ToDouble(dr["AP_BAL"]);

    //    }

    //    dt.Columns[12].MaxLength = 20;
    //    //GridView1.Columns[4].FooterText = totalamt1.ToString("f2");
    //    //GridView1.Columns[7].FooterText = totalamt2.ToString("f2");
    //    //GridView1.Columns[11].FooterText = totalamt3.ToString("f2");
    //    //GridView1.Columns[14].FooterText = totalamt4.ToString("f2");
    //    //GridView1.Columns[7].FooterText = totalamt5.ToString("f2");
    //    DataRow rowTotal = dt.NewRow();
    //    rowTotal["AMT_SETTLE_i"] = totalamt1.ToString("f2");
    //    rowTotal["FEE_Income"] = totalamt2.ToString("f2");
    //    rowTotal["AMT_SETTLE_O"] = totalamt3.ToString("f2");
    //    rowTotal["FEE_Sharing"] = totalamt4.ToString("f2");
    //    rowTotal["BANK_NAME"] = "Grand Total:";
    //    dt.Rows.Add(rowTotal);
    //    DataRow dataRowTotal = dt.NewRow();
    //    double AMT_SETTLE_O = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["AMT_SETTLE_O"]);
    //    double AMT_SETTLE_i = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["AMT_SETTLE_i"]);
    //    double FEE_Income = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["FEE_Income"]);
    //    double FEE_Sharing = Convert.ToDouble(dt.Rows[dt.Rows.Count - 1]["FEE_Sharing"]);
    //    dataRowTotal["TRAN_TYPE_O"] = "Net Amount";
    //    dataRowTotal[12] = "Net FEE";
    //    //dataRowTotal[11] = "Net FEE";
    //    dataRowTotal["AMT_SETTLE_O"] = (AMT_SETTLE_i - AMT_SETTLE_O).ToString();


    //    // dataRowTotal["SUSPEN_ACC1_O"] = "Net Fee";
    //    dataRowTotal["FEE_Sharing"] = (FEE_Income - FEE_Sharing).ToString();

    //    dt.Rows.Add(dataRowTotal);
    //    GridView1.DataSource = dt;
    //    GridView1.DataBind();

    //}

    protected void OnDataBound(object sender, EventArgs e)  //EventArgs e
    {
        GridView1.HeaderRow.Cells[0].Visible = false;
        GridView1.HeaderRow.Cells[1].Visible = false;
        GridView1.HeaderRow.Cells[2].CssClass = "vertical-middle";
        GridView1.HeaderRow.Cells[3].CssClass = "vertical-middle";
        GridView1.HeaderRow.Cells[4].CssClass = "vertical-middle";
        GridView1.HeaderRow.Cells[5].CssClass = "vertical-middle";
        GridView1.HeaderRow.Cells[6].CssClass = "vertical-middle";
        GridView1.HeaderRow.Cells[7].CssClass = "vertical-middle";
        GridView1.HeaderRow.Cells[8].CssClass = "vertical-middle";
        GridView1.HeaderRow.Cells[9].CssClass = "vertical-middle";
        GridView1.HeaderRow.Cells[10].CssClass = "vertical-middle";
        GridView1.HeaderRow.Cells[11].CssClass = "vertical-middle";
        GridView1.HeaderRow.Cells[12].CssClass = "vertical-middle";
        GridView1.HeaderRow.Cells[13].CssClass = "vertical-middle";
        GridView1.HeaderRow.Cells[14].CssClass = "vertical-middle";
        GridView1.HeaderRow.Cells[15].CssClass = "vertical-middle";
        
        GridViewRow row = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
        TableHeaderCell cell = new TableHeaderCell();
        cell.Text = "No";
        cell.CssClass = "vertical-middle";
        row.Controls.Add(cell);
        cell.RowSpan = 2;

        cell = new TableHeaderCell();
        cell.Text = "NAME of BANK/MFI";
        cell.CssClass = "vertical-middle";
        row.Controls.Add(cell);
        cell.RowSpan = 2;

        cell = new TableHeaderCell();
        cell.ColumnSpan = 7;
        cell.Text = "INCOMING CASH";
        cell.CssClass = "vertical-middle";
        row.Controls.Add(cell);

        cell = new TableHeaderCell();
        cell.ColumnSpan = 7;
        cell.Text = "OUTGOING CASH";
        cell.CssClass = "vertical-middle";
        row.Controls.Add(cell);

        row.BackColor = ColorTranslator.FromHtml("#3AC0F2");
        GridView1.HeaderRow.Parent.Controls.AddAt(0, row);
        //check if the row is the header row
    }

}