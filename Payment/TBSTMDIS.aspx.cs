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
using TrueMoneyClearingDispute; 

public partial class Payment_TBSTMDIS : System.Web.UI.Page
{
    //SqlConnection sqlc = new SqlConnection();
    //SqlConnectAndSqlCommand _getsqlcon = new SqlConnectAndSqlCommand();
    //DataTable CSVTable = new DataTable();
    //WingDashBoard _wing = new WingDashBoard();
    GridViewValues _grid = new GridViewValues();
    //OracleCommand oracmd = new OracleCommand();
    //OracleConnection obj2 = new OracleConnection();
    //SqlCommand cmd = new SqlCommand();
    logger _logger = new logger();
    bool isLoading = false;
   // masterreport_connect obj1 = new masterreport_connect();
    //Oracle_BulkInsert _BUL = new Oracle_BulkInsert();
    TrueMoney_Dashboard _true = new TrueMoney_Dashboard();
    TrueMoneyUploadDisputeFile _trueUp = new TrueMoneyUploadDisputeFile();
    TrueMoneyReport _truerpt = new TrueMoneyReport();
    TrueUpdateIsUpload _isupload = new TrueUpdateIsUpload();
    TrueMoneyITOFunction _TrueFn = new TrueMoneyITOFunction();
    TrueMoneyPushIRawToITO _truepush = new TrueMoneyPushIRawToITO();

    public enum MessageType { Success, Error, Info, Warning };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            l_count_wing.Text = GetGrid_Wing_list.Rows.Count.ToString();
            l_count_CBS.Text = GetGrid_CBS_list.Rows.Count.ToString();
            //string script = "$(document).ready(function () { $('[id*=Review]').click();alert('hi'); });";
            //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
        }
     }

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
    protected void btnUpload_Click(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload1.HasFile)
            {
                int flag = 0;
                string FileName = Path.GetFileName(FileUpload1.PostedFile.FileName);
                string RandomName = DateTime.Now.ToFileTime().ToString();
                string Extension = Path.GetExtension(FileUpload1.PostedFile.FileName);
                string FolderPath = ConfigurationManager.AppSettings["FolderPath"];  //"~/upload/";

                string FilePath = Server.MapPath(FolderPath + RandomName + FileName);

                string[] filenames = Directory.GetFiles(Server.MapPath("~/Payment"));

                if (filenames.Length > 0)
                {
                    foreach (string filename in filenames)
                    {
                        if (FilePath == filename)
                        {
                            flag = 1;
                            break;
                        }
                    }

                    if (flag == 0)
                    {
                        FileUpload1.SaveAs(FilePath);
                        //ReadCSVFile(FilePath);

                        DataTable tblcsv = new DataTable();
                        tblcsv.Columns.Add("trn_date");
                        tblcsv.Columns.Add("trn_time");
                        tblcsv.Columns.Add("TRN_ID");
                        tblcsv.Columns.Add("Service_Name");
                        tblcsv.Columns.Add("account_name");
                        tblcsv.Columns.Add("login_id");
                        tblcsv.Columns.Add("category_code");
                        tblcsv.Columns.Add("bill_number");
                        tblcsv.Columns.Add("customer_name");
                        tblcsv.Columns.Add("customer_number");
                        tblcsv.Columns.Add("CCY");
                        tblcsv.Columns.Add("REQ_VALUE");
                        tblcsv.Columns.Add("err_code");
                        tblcsv.Columns.Add("bank_account");
                        tblcsv.Columns.Add("bank_name");
                        tblcsv.Columns.Add("UPLOAD_DATE");

                        string ReadCSV = File.ReadAllText(FilePath);
                        //spliting row after new line  
                        foreach (string csvRow in ReadCSV.Split('\n'))
                        {
                            if (!string.IsNullOrEmpty(csvRow))
                            {
                                //Adding each row into datatable  
                                tblcsv.Rows.Add();
                                int count = 0;
                                foreach (string FileRec in csvRow.Split(';'))
                                {
                                    tblcsv.Rows[tblcsv.Rows.Count - 1][count] = FileRec;
                                    count++;
                                }
                            }
                        }
                        //_BUL.OracleBulk_True_DIS_insert(tblcsv);
                        _trueUp.TrueMoneyUploadDispute(tblcsv); 
                        ShowMessage("Uploaded Successful !!!", MessageType.Success);
                    }

                }
            }
            else
            {
                String msg = "Select a file then try to import";
            }
         
        }

        catch (Exception ex)
        {
            throw ex;
        } 
    }
    private void _getgrid_Wing_Summary()
    {
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');

        _truerpt.P_SDATE = currentdate;
        GetGrid_Wing_smy.HeaderStyle.BackColor = Color.FromName("#00A7A5");
        GetGrid_Wing_smy.HeaderStyle.Font.Bold = true;
        GetGrid_Wing_smy.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(GetGrid_Wing_smy, _truerpt._get_TRUE_Summary_report());
    }
    private void _getgrid_WING_Disputed_list()
    {
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');

        _truerpt.P_SDATE = currentdate;
        GetGrid_Wing_list.HeaderStyle.BackColor = Color.FromName("#00A7A5");
        GetGrid_Wing_list.HeaderStyle.Font.Bold = true;
        GetGrid_Wing_list.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(GetGrid_Wing_list, _truerpt._get_TRUE_Disputed_list());
    }
    private void _getgrid_WING_CBS_Success_list()
    {
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');

        _truerpt.P_SDATE = currentdate;
        GetGrid_CBS_list.HeaderStyle.BackColor = Color.FromName("#00A7A5");
        GetGrid_CBS_list.HeaderStyle.Font.Bold = true;
        GetGrid_CBS_list.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(GetGrid_CBS_list, _truerpt._get_TRUE_CBS_Success_list());
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Review_ServerClick1(object sender, EventArgs e)
    {
       
        try
        {
            //loading();
            _getgrid_Wing_Summary();
            _getgrid_WING_Disputed_list();
            _getgrid_WING_CBS_Success_list();
            l_count_wing.Text = GetGrid_Wing_list.Rows.Count.ToString();
            l_count_CBS.Text = GetGrid_CBS_list.Rows.Count.ToString();
            loading_Close();

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
        }
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
        
        //_true.p_ccy = d_CCY.SelectedItem.ToString();
        //_true._get_TRUE_UPDATE_ISUPLOAD();
        _isupload.p_ccy = d_CCY.SelectedItem.ToString();
        _isupload._get_TRUE_UPDATE_ISUPLOAD();
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
        _TrueFn.p_type = "CBDAPP";
        _TrueFn.p_source = "CBD_SYSTEM";
        _TrueFn.p_reference = "TRUE_DIS_" + d_CCY.SelectedItem.ToString(); ;
        _TrueFn._GET_ITO_FN_PUSH_ENTRIES();
        ShowMessage("Push Function was successful!", MessageType.Success);
        
    }

    protected void A4_ServerClick(object sender, EventArgs e)
    {
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        _truepush.P_SDATE = currentdate;
        _truepush.p_reference = "TRUE_DIS_" + d_CCY.SelectedItem.ToString();
        _truepush.p_ccy = d_CCY.SelectedItem.ToString();
        _truepush.P_UserAD = Session["USERID"].ToString();
        _truepush._get_TRUE_ITO_Upload();
        loading_Close();
        ShowMessage("Moved records to ITO is successful !", MessageType.Success);
    }

    protected void A5_ServerClick(object sender, EventArgs e)
    {
        _TrueFn.p_source = "CBD_SYSTEM";
        _TrueFn.p_reference = "TRUE_DIS_" + d_CCY.SelectedItem.ToString();
        _TrueFn.p_ccy = d_CCY.SelectedItem.ToString();
        _TrueFn._GET_ITO_FN_DEL_ENTRIES();
        _TrueFn._GET_TRUE_DEL_AFTER_UPLOADED();
        ShowMessage("Deleted Function is successful!", MessageType.Success);
    }
}