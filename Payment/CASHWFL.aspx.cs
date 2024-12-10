using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;
using MasterReportClass;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Drawing;
using System.Data.OracleClient;

public partial class Payment_CASHWFL : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    SqlConnectAndSqlCommand _getsqlcon = new SqlConnectAndSqlCommand();
    DataTable CSVTable = new DataTable();
    //WingDashBoard _wing = new WingDashBoard();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    OracleCommand oracmd = new OracleCommand();
    OracleConnection obj2 = new OracleConnection();
    SqlCommand cmd = new SqlCommand();
    logger _logger = new logger();
    bool isLoading = false;
    masterreport_connect obj1 = new masterreport_connect();
    Cashback_Dashboard _cash = new Cashback_Dashboard();


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
            l_count_VISA.Text = GetGrid_cashback_Visa_list.Rows.Count.ToString();
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
    //private void _getgrid_visa_pre_list()
    //{
    //    _visa.P_DATE = t_start_date.Text;
    //    _visa.P_EDATE = t_end_date.Text;
    //    _visa.P_CCY = d_CCY.SelectedItem.ToString();
    //    GetGrid_Visa_list.HeaderStyle.BackColor = Color.FromName("#00A7A5");
    //    GetGrid_Visa_list.HeaderStyle.Font.Bold = true;
    //    GetGrid_Visa_list.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
    //    _grid._GridviewBinding(GetGrid_Visa_list, _visa._get_VISA_ITO_Listing());
    //}

    //private void _getgrid_iss_visa_pre_list()
    //{

    //    _visa.P_DATE = t_start_date.Text;
    //    _visa.P_EDATE = t_end_date.Text;
    //    GetGrid_Visa_list.HeaderStyle.BackColor = Color.FromName("#00A7A5");
    //    GetGrid_Visa_list.HeaderStyle.Font.Bold = true;
    //    GetGrid_Visa_list.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
    //    _grid._GridviewBinding(GetGrid_Visa_list, _visa._get_VISA_ISS_ITO_Listing());
    //}

    private void _gridview_cashback_visa_payment_smy()
    {
        GetGrid_CASHBACK_Smy.HeaderStyle.BackColor = Color.FromName("#00A7A5");
        GetGrid_CASHBACK_Smy.HeaderStyle.Font.Bold = true;
        GetGrid_CASHBACK_Smy.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(GetGrid_CASHBACK_Smy, _cash._GET_CASHBACK_ITO_SMY());
    }


    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Review_ServerClick1(object sender, EventArgs e)
    {
        _gridview_cashback_visa_payment_smy();
        GetGrid_CASHBACK_Smy.HeaderStyle.BackColor = Color.FromName("#00A7A5");
        GetGrid_CASHBACK_Smy.HeaderStyle.Font.Bold = true;
        GetGrid_CASHBACK_Smy.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");

        _grid._GridviewBinding(GetGrid_cashback_Visa_list, _cash._GET_CASHBACK_ITO_Listing());
        l_count_VISA.Text = GetGrid_cashback_Visa_list.Rows.Count.ToString();
        
    }
    //private void Get_WING_ITO_UPLOAD()
    //{
    //    string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
    //    _wing.P_SDATE = currentdate;
    //    XLWorkbook wb = new XLWorkbook();
    //    DataTable dt = new DataTable();
    //    dt = _wing._get_WING_ITO_Upload();
    //    wb.Worksheets.Add(dt, "WING_ITO_UPLOAD");

    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.Charset = "";
    //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //    Response.AddHeader("content-disposition", "attachment;filename=WING_UPLOAD.xlsx");
    //    System.IO.MemoryStream memory = new System.IO.MemoryStream();
    //    wb.SaveAs(memory);
    //    memory.WriteTo(Response.OutputStream);
    //    Response.Flush();
    //    Response.End();
    //    //Response.Write("<script>alert('Update Successful!!')</script>");
    //    //Server.Transfer("~/TestPro/Default.aspx");
    //}
    //private void Get_WING_generate_disputed()
    //{
    //    string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
    //    _true.P_SDATE = currentdate;
    //    XLWorkbook wb = new XLWorkbook();
    //    DataTable dt = new DataTable();
    //    dt = _true._get_WING_generate_disputed();
    //    wb.Worksheets.Add(dt, "Wing_disputed");

    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.Charset = "";
    //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //    Response.AddHeader("content-disposition", "attachment;filename=WING_Generate_Disputed.xlsx");
    //    System.IO.MemoryStream memory = new System.IO.MemoryStream();
    //    wb.SaveAs(memory);
    //    memory.WriteTo(Response.OutputStream);
    //    Response.Flush();
    //    Response.End();
    //    //Response.Write("<script>alert('Update Successful!!')</script>");
    //    //Server.Transfer("~/TestPro/Default.aspx");
    //}

    //private void Get_WING_generate_ITO()
    //{
    //    string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
    //    _wing.P_SDATE = currentdate;
    //    XLWorkbook wb = new XLWorkbook();
    //    DataTable dt = new DataTable();
    //    dt = _wing._get_WING_generate_disputed();
    //    wb.Worksheets.Add(dt, "Wing_disputed");
    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.Charset = "";
    //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //    Response.AddHeader("content-disposition", "attachment;filename=WING_Generate_Disputed.xlsx");
    //    System.IO.MemoryStream memory = new System.IO.MemoryStream();
    //    wb.SaveAs(memory);
    //    memory.WriteTo(Response.OutputStream);
    //    Response.Flush();
    //    Response.End();
    //    //Response.Write("<script>alert('Update Successful!!')</script>");
    //    //Server.Transfer("~/TestPro/Default.aspx");
    //}

    protected void Update_ServerClick(object sender, EventArgs e)
    {
        
        loading_Close();
        ShowMessage("Uploaded Successful !!!", MessageType.Success);

    }
    protected void export_ServerClick(object sender, EventArgs e)
    {

    }
    protected void A1_ServerClick(object sender, EventArgs e)
    {
       // Get_WING_generate_disputed();
    }

    protected void A2_ServerClick(object sender, EventArgs e)
    {
       // Get_WING_ITO_UPLOAD();
    }

    protected void A3_ServerClick(object sender, EventArgs e)
    {
        //string get_ITO_reference = _get_reference();
        //_visa.p_type = "CBDAPP";
        //_visa.p_source = "CBD_SYSTEM";
        //_visa.p_reference = get_ITO_reference;
        //_visa._GET_ITO_FN_PUSH_ENTRIES();
        //ShowMessage("Push Function was successful!", MessageType.Success);
    }

    protected void A4_ServerClick(object sender, EventArgs e)
    {
        _cash.P_USERID = Session["USERID"].ToString();
        _cash._CASHBACK_PAYMENT_ITO_UPLOADS(GetGrid_cashback_Visa_list);
        loading_Close();
        ShowMessage("Moved records to ITO is successful !", MessageType.Success);
    }

    //public string _get_reference()

    //{
    //    string _id = null;
    //    string _sttl_type = null;
    //    //_visa.P_CCY = d_CCY.SelectedItem.ToString();
    //    _visa.P_DATE = t_start_date.Text;
    //    _sttl_type = d_settlement.SelectedValue;

    //    if (_sttl_type == "STTT0100")
    //    {
    //        _visa.P_S_REF = d_settlement.SelectedItem.ToString();
    //        DataTable dt = _visa._get_VISA_ITO_reference();
    //        _id = dt.Rows[0][0].ToString();
    //    }
    //    else if (_sttl_type == "STTT0200" /* && d_CCY.SelectedItem.ToString() == "USD"*/)
    //    {
    //        _visa.P_BATCH = _visa.P_S_REF = d_settlement.SelectedItem.ToString();
    //        DataTable dt = _visa._get_VISA_ITO_reference();
    //        _id = dt.Rows[0][0].ToString();
    //    }

    //    return _id;
    //}
    protected void A5_ServerClick(object sender, EventArgs e)
    {
        //string get_ITO_reference = _get_reference();
        ////_visa.p_type = "CBDAPP";
        //_visa.p_source = "CBD_SYSTEM";
        //_visa.p_reference = get_ITO_reference;
        //_visa._GET_ITO_FN_DEL_ENTRIES();
        ////_true._GET_TRUE_DEL_AFTER_UPLOADED();
        //ShowMessage("Deleted Function is successful!", MessageType.Success);
    }

    //protected void btnedit_click(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow row in GetGrid_Visa_list.Rows)
    //    {
    //        CheckBox checkbox = (CheckBox)row.FindControl("check");
    //        if (checkbox.Checked)
    //        {
    //            string id = Convert.ToString(row.Cells[14].Text);
    //            Response.Redirect("~/Payment/visa_payment_edit.aspx?RRN=" + id);
    //        }
    //    }
    //}
    //protected void btndelete_click(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow row in GetGrid_Visa_list.Rows)
    //    {
    //        CheckBox checkbox = (CheckBox)row.FindControl("check");
    //        if (checkbox.Checked)
    //        {
    //            string id = Convert.ToString(row.Cells[14].Text);
    //            Response.Redirect("~/Payment/visa_payment_delete.aspx?RRN=" + id);
    //        }
    //    }
    //}



    protected void Linkbtnexport_Click(object sender, EventArgs e)
    {
        _getExcelFile();
    }
    

    public void _getExcelFile()
    {
        try
        {
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = new DataTable();

            if (GetGrid_cashback_Visa_list.HeaderRow != null)
            {

                for (int i = 0; i < GetGrid_cashback_Visa_list.HeaderRow.Cells.Count; i++)
                {
                    dt.Columns.Add(GetGrid_cashback_Visa_list.HeaderRow.Cells[i].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GetGrid_cashback_Visa_list.Rows)
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
            if (GetGrid_cashback_Visa_list.FooterRow != null)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < GetGrid_cashback_Visa_list.FooterRow.Cells.Count; i++)
                {
                    dr[i] = GetGrid_cashback_Visa_list.FooterRow.Cells[i].Text.Replace("&nbsp;", "");
                }
                dt.Rows.Add(dr);
            }


            wb.Worksheets.Add(dt, "Issue_listing");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=CASHBACK_LIST.xlsx");
            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            wb.SaveAs(memory);
            memory.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _logger._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }

    }
}