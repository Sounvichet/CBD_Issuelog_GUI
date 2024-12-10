using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ClosedXML.Excel;
using System.Drawing;
using BakongClearingDispute;


public partial class BAKONG_BAKGRPT : System.Web.UI.Page
{
    //SqlConnection sqlc = new SqlConnection();
    //SqlConnectAndSqlCommand _getsqlcon = new SqlConnectAndSqlCommand();
    DataTable CSVTable = new DataTable();
    //WingDashBoard _wing = new WingDashBoard();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    //OracleCommand oracmd = new OracleCommand();
    //OracleConnection obj2 = new OracleConnection();
    //SqlCommand cmd = new SqlCommand();
    //logger _logger = new logger();
    //bool isLoading = false;
    //masterreport_connect obj1 = new masterreport_connect();
    //Visa_payment_dashboard _visa = new Visa_payment_dashboard();
    //Visa_payment_dashboard_UAT _UAT = new Visa_payment_dashboard_UAT();
    //ReportDashboard _visa = new ReportDashboard();
    BakongReportDashboard _report = new BakongReportDashboard();
    
    public enum MessageType { Success, Error, Info, Warning };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            
            string _get_current_date = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            t_start_date.Text = _get_current_date;
            t_end_date.Text = _get_current_date;
            l_count_VISA.Text = grid_report.Rows.Count.ToString();
            _drop.bindDropDownList(d_report_type, _report._Bakong_report_list_DDL());
            
        }
     }



    //public void ReadCSVFile(string fileName)
    //{
    //    try
    //    {
    //        string connection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\\;Extended Properties='Text;HDR=Yes;FMT=CSVDelimited'";

    //        connection = String.Format(connection, Path.GetDirectoryName(fileName));


    //        OleDbDataAdapter csvAdapter;
    //        csvAdapter = new OleDbDataAdapter("SELECT * FROM [" + Path.GetFileName(fileName) + "]", connection);

    //        if (File.Exists(fileName) && new FileInfo(fileName).Length > 0)
    //        {
    //            try
    //            {
    //                csvAdapter.Fill(CSVTable);
    //                if ((CSVTable != null) && (CSVTable.Rows.Count > 0))
    //                {
    //                    ViewState["CSVTable"] = CSVTable;
    //                    GridView _getGrid = new GridView();
    //                    _getGrid.DataSource = CSVTable;
    //                    _getGrid.DataBind();

    //                    _true._WING_Disputed_Insert(_getGrid);
    //                    // _CSS._CSS_LoopGrid(_getGrid);  //getgrid1
    //                    loading_Close();
    //                    ShowMessage("Insert records into Table Successful.", MessageType.Success);
                        
    //                }
    //                else
    //                {
    //                    String msg = "No records found";
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new Exception(String.Format("Error reading Table {0}.\n{1}", Path.GetFileName(fileName), ex.Message));
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

    private void loading()
    {
        //string script = isHide ? "$('#loading').hide(); " : "$('#loading').show(); ";
        //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
        ScriptManager.RegisterStartupScript(this,this.GetType(), "load", "$('#loading').show();", true);
    }
    private void loading_Close()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#loading').hide();", true);
    }
    
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void Update_ServerClick(object sender, EventArgs e)
    {
        
        loading_Close();
        ShowMessage("Uploaded Successful !!!", MessageType.Success);

    }

    private void _GRID_BAKONG_PG_VERIFY_NBC()
    {
        _report.P_SDATE = t_start_date.Text;
        _report.P_EDATE = t_end_date.Text;
        grid_report.HeaderStyle.BackColor = Color.FromName("#00A7A5");
        grid_report.HeaderStyle.Font.Bold = true;
        grid_report.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(grid_report, _report._BAKONG_PG_VERIFY_NBC());
    }

    private void _GRID_BAKONG_RECON_NOST_LIAB()
    {
        _report.P_SDATE = t_start_date.Text;
        _report.P_EDATE = t_end_date.Text;
        grid_report.HeaderStyle.BackColor = Color.FromName("#00A7A5");
        grid_report.HeaderStyle.Font.Bold = true;
        grid_report.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(grid_report, _report._BAKONG_RECON_NOST_LIAB());
    }

    public void _getExcelFile()
    {
        try
        {
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = new DataTable();

            if (grid_report.HeaderRow != null)
            {

                for (int i = 0; i < grid_report.HeaderRow.Cells.Count; i++)
                {
                    dt.Columns.Add(grid_report.HeaderRow.Cells[i].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in grid_report.Rows)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dr[i] = row.Cells[i].Text.Replace("&nbsp;", "");
                }
                dt.Rows.Add(dr);
            }

            //  add the footer row to the table
            if (grid_report.FooterRow != null)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < grid_report.FooterRow.Cells.Count; i++)
                {
                    dr[i] = grid_report.FooterRow.Cells[i].Text.Replace("&nbsp;", "");
                }
                dt.Rows.Add(dr);
            }


            wb.Worksheets.Add(dt, "Issue_listing");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=VISA_RPT_LIST_"+t_end_date.Text+".xlsx");
            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            wb.SaveAs(memory);
            memory.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
          //  Response.Write(@"<script language='javascript'>alert('Error " + _visa.get_message + " !!')</script>");
        }
        finally
        {
          
        }

    }

    protected void d_Review_ServerClick(object sender, EventArgs e)
    {
        string get_rpt_type;
        get_rpt_type = d_report_type.SelectedValue.ToString();

        if (get_rpt_type == "BAK001")
        {
            _GRID_BAKONG_PG_VERIFY_NBC();
            l_count_VISA.Text = grid_report.Rows.Count.ToString();
        }
        if (get_rpt_type == "BAK002")
        {
            _GRID_BAKONG_RECON_NOST_LIAB();
            l_count_VISA.Text = grid_report.Rows.Count.ToString();
        }
        else
        {
            return; 
        }
        

    }

    protected void d_export_ServerClick(object sender, EventArgs e)
    {
        _getExcelFile();
    }



    

   
}