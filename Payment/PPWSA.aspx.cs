using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using ClosedXML.Excel;
using System.IO;
using MasterReportClass;

public partial class Payment_PPWSA : System.Web.UI.Page
{
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    GridViewValues _grid = new GridViewValues();
    ReportWingDashboard _wing = new ReportWingDashboard();
    DropDownListValues _dropdown = new DropDownListValues();
    PPWSADashboard _PPWSA = new PPWSADashboard();
    logger _logger = new logger();
    SqlConnection sqlc = new SqlConnection();
    OracleConnection obj2 = new OracleConnection();
    ReportPayment _payment = new ReportPayment();
    

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            _SelectDate();
            _SelectToday();
        }

        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        txtgenerate.Text = currentdate;
    }

    public void _SelectDate()
    {
        _dropdown.bindDropDownList(D_selectdate, _PPWSA.D_Select_date());
    }
    public void _SelectToday()
    {
        try
        {
            DataTable dt = _PPWSA.D_Select_date_today();
            D_selectdate.SelectedValue = dt.Rows[0]["LookupCode"].ToString();
            _Frequency_Fundamental(D_selectdate.SelectedValue);

        }

        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
        }



    }

    public void _Frequency_Fundamental(string lookup)
    {
        DataTable dt = _PPWSA.D_Frequency_Fundamental(lookup);

        if (dt.Rows.Count == 0)
        {
            Response.Write("<script>alert('Not Yet implement!')</script>");
        }

        if (dt.Rows.Count > 0)
        {
            txtForm.Text = dt.Rows[0][3].ToString();
            txtto.Text = dt.Rows[0][4].ToString();
        }

    }

    protected void D_selectdate_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectdate = D_selectdate.SelectedValue;
        if (selectdate == "LD")
        {
            txtForm.Text = _PPWSA._getStartPeriod(D_selectdate.SelectedValue);
            txtto.Text = _PPWSA._getEndPeriod(D_selectdate.SelectedValue);
        }
        else
        {
            _Frequency_Fundamental(D_selectdate.SelectedValue);

        }
    }
    //private void _getexportexcel()
    //{
    //    try
    //    {

    //    }
    //    catch (Exception ex)
    //    {
    //        _logger.LogError(ex);
    //        _logger._message = ex.Message;
    //    }
    //    finally
    //    {
    //        obj2.Close();
    //        obj2.Dispose();
    //        OracleConnection.ClearPool(obj2);
    //    }
    //}

    private void getexcel()
    {

        var workbook = new XLWorkbook();
        DataTable dt = new DataTable();
        
        dt = _payment.D_PR_PPWSA_SETTLEMENT(txtForm.Text, txtto.Text);
        DataSet ds = new DataSet();
        ds.Tables.Add(dt);
        

        //var ws = workbook.Worksheets.Add(ds.Tables[i] as DataTable);

        
          ds.Tables[0].TableName = "PPWSA_Settlement";
          var  ws  = workbook.Worksheets.Add(ds.Tables[0] as DataTable);
        

        long sum_txn_amt = 0;
        long Generated_Item = 0;

        ws.Row(1).InsertRowsAbove(1);
        ws.Cell(1, 1).Value = "HKL-PPWSA Report Print from " + txtForm.Text + " to " + txtto.Text + "";
        ws.Range("A1:G1").Style.Fill.BackgroundColor = XLColor.LightGray;
        ws.Range("A1:G1").Merge();
        ws.Range("A1:G1").Style.Font.Underline = XLFontUnderlineValues.Single;
        ws.Range("A1:G1").Style.Font.Bold = true;
        ws.Range("A1:G1").Style.Font.FontName = "Calibri";
        ws.Range("A1:G1").Style.Font.FontSize = 13;
        ws.Range("A1:G1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        ws.Range("A1:G1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;




        int i = 3;
        int k = i;
        if (ds.Tables[0].Rows.Count>0)
        {
            Generated_Item = ds.Tables[0].Rows.Count;
            //ws.Range("A" + i + ":G" + (ds.Tables[0].Rows.Count - 1 + i)).Style.NumberFormat.Format = ;
            // ws.Range("A" + i + ":G" + (ds.Tables[0].Rows.Count - 1 + i)).Style.Font.FontName = "Calibri";
            // ws.Range("A" + i + ":G" + (ds.Tables[0].Rows.Count - 1 + i)).Style.Font.FontSize = 11;

        for ( k = i; k <= ds.Tables[0].Rows.Count-1 + i ; k++ )
        {
            for (int m = 1; m <= ds.Tables[0].Columns.Count; m++)
            {
                   // int test = Convert.ToInt32(ds.Tables[0].Rows[k - i].ItemArray[m - 1]);
                    ws.Cell(k,m).Value = ds.Tables[0].Rows[k-i][m - 1].ToString();
                if (m == 4)
                {
                    sum_txn_amt = sum_txn_amt + (Convert.ToInt32(ds.Tables[0].Rows[k - i][m - 1]));
                } 
            }
        }
        }
        //ws.Range("A" + k + ":C" + k).Merge();
        ws.Cell(k, 3).Value = "Total Payment:";
        ws.Cell(k, 4).Value = sum_txn_amt;
        
        ws.Range("A" + k + ":D" + k).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        ws.Range("A" + k + ":D" + k).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
        ws.Range("C" + k + ":D" + k).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
        ws.Range("D1:D" + k).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
        ws.Range("A" + k + ":D" + k).Style.Font.Bold = true;
        ws.Range("D3" + ":D" + k).Style.NumberFormat.Format = "#,##0.00";


        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        //Response.AddHeader("content-disposition", "attachment;filename=" + txtgenerate.Text + "-HKL_PPWSA.xlsx");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        if (!System.IO.File.Exists(@"\\192.168.111.12\edc-pnp-kdl\!!Debug\Debug\" + txtgenerate.Text + "-HKL_PPWSA.xlsx"))
        {
            workbook.SaveAs(@"\\192.168.111.12\edc-pnp-kdl\!!Debug\Debug\" + txtgenerate.Text + "-HKL_PPWSA.xlsx");
        }

        else
        {
            workbook.SaveAs(@"\\192.168.111.12\edc-pnp-kdl\!!Debug\Debug\" + txtgenerate.Text + "-HKL_PPWSA(Copy).xlsx");
        }


        
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    private void _Get_PPWSA_LISTING()
    {

        var workbook = new XLWorkbook();
        DataTable dt = new DataTable();

        dt = _payment.D_PR_PPWSA_SETTLEMENT(txtForm.Text, txtto.Text);
        DataSet ds = new DataSet();
        ds.Tables.Add(dt);


        //var ws = workbook.Worksheets.Add(ds.Tables[i] as DataTable);


        ds.Tables[0].TableName = "PPWSA_Settlement";
        var ws = workbook.Worksheets.Add(ds.Tables[0] as DataTable);


        Decimal sum_txn_amt = 0;
        long Generated_Item = 0;

        ws.Row(1).InsertRowsAbove(1);
        ws.Cell(1, 1).Value = "HKL-PPWSA Report Print from " + txtForm.Text + " to " + txtto.Text + "";
        ws.Range("A1:G1").Style.Fill.BackgroundColor = XLColor.LightGray;
        ws.Range("A1:G1").Merge();
        ws.Range("A1:G1").Style.Font.Underline = XLFontUnderlineValues.Single;
        ws.Range("A1:G1").Style.Font.Bold = true;
        ws.Range("A1:G1").Style.Font.FontName = "Calibri";
        ws.Range("A1:G1").Style.Font.FontSize = 13;
        ws.Range("A1:G1").Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        ws.Range("A1:G1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;




        int i = 3;
        int k = i;
        if (ds.Tables[0].Rows.Count > 0)
        {
            Generated_Item = ds.Tables[0].Rows.Count;
            //ws.Range("A" + i + ":G" + (ds.Tables[0].Rows.Count - 1 + i)).Style.NumberFormat.Format = ;
            // ws.Range("A" + i + ":G" + (ds.Tables[0].Rows.Count - 1 + i)).Style.Font.FontName = "Calibri";
            // ws.Range("A" + i + ":G" + (ds.Tables[0].Rows.Count - 1 + i)).Style.Font.FontSize = 11;

            for (k = i; k <= ds.Tables[0].Rows.Count - 1 + i; k++)
            {
                for (int m = 1; m <= ds.Tables[0].Columns.Count; m++)
                {
                    // int test = Convert.ToInt32(ds.Tables[0].Rows[k - i].ItemArray[m - 1]);
                    ws.Cell(k, m).Value = ds.Tables[0].Rows[k - i][m - 1].ToString();
                    if (m == 4)
                    {
                       // sum_txn_amt = sum_txn_amt + (Convert.ToInt32(ds.Tables[0].Rows[k - i][m - 1]));
                        sum_txn_amt = sum_txn_amt + Convert.ToDecimal(ds.Tables[0].Rows[k - i][m - 1]);
                    }
                }
            }
        }
        //ws.Range("A" + k + ":C" + k).Merge();
        ws.Cell(k, 3).Value = "Total Payment:";
        ws.Cell(k, 4).Value = sum_txn_amt;

        ws.Range("A" + k + ":D" + k).Style.Alignment.Vertical = XLAlignmentVerticalValues.Center;
        ws.Range("A" + k + ":D" + k).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
        ws.Range("C" + k + ":D" + k).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
        ws.Range("D1:D" + k).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
        ws.Range("A" + k + ":D" + k).Style.Font.Bold = true;
        ws.Range("D3" + ":D" + k).Style.NumberFormat.Format = "#,##0.00";

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename="+txtgenerate.Text.ToString()+"_PPWSA_List.xlsx");

        using (MemoryStream MyMemoryStream = new MemoryStream())
        {
            workbook.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }


    }
    protected void Linkbtnapply_Click(object sender, EventArgs e)
    {
        //_Get_PPWSA_LISTING();
        //getexcel();
    }
    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx");
    }
}