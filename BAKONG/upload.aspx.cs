using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using ClosedXML.Excel;
using System.Configuration;
using MasterReportClass;
using Oracle.ManagedDataAccess.Client;
using BakongClearingDispute; 
public partial class BAKONG_upload : System.Web.UI.Page
{
    BAKONGDashboard _BAK = new BAKONGDashboard();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    logger _logger = new logger();
    SqlConnection sqlc = new SqlConnection();
    masterreport_connect obj1 = new masterreport_connect();
    Oracle_BulkInsert _BUL = new Oracle_BulkInsert();
    BakongUploadReconFile _upRecon = new BakongUploadReconFile();

    string s_ReportSQL = "";
    string s_reportCode = "";
    string s_reportFun = "";
    string s_ColHeader1 = "";
    string s_ColHeader2 = "";
    string s_FileName = "";
    string s_ReportTitle = "";
    string s_conncode = "";
    string s_provider = "";
    string s_connectstring = "";
    string S_reportname = "";
    public enum MessageType { Success, Error, Info, Warning };
    Oracle.ManagedDataAccess.Client.OracleConnection obj2 = new Oracle.ManagedDataAccess.Client.OracleConnection();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
           // L_count.Text = GridView1.Rows.Count.ToString();
        }
        }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    private void FillGridFromExcelSheet(string FilePath, string ext, string isHader)  //, string isHader
    {
        string connectionString = "";
        if (ext == ".xls")
        {   //For Excel 97-03
            connectionString = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source={0};Extended Properties='Excel 8.0;HDR={1}'";
        }
        else if (ext == ".xlsx")
        {    //For Excel 07 and greater
            connectionString = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source={0};Extended Properties='Excel 12.0;HDR={1}'";
        }
        connectionString = String.Format(connectionString, FilePath, isHader); //, isHader
        OleDbConnection conn = new OleDbConnection(connectionString);
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter dataAdapter = new OleDbDataAdapter();
        DataTable dt = new DataTable();
        cmd.Connection = conn;
        //Fetch 1st Sheet Name
        conn.Open();
        DataTable dtSchema;
        dtSchema = conn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
        string ExcelSheetName = dtSchema.Rows[0]["TABLE_NAME"].ToString();
        conn.Close();
        //Read all data of fetched Sheet to a Data Table
        conn.Open();
        cmd.CommandText = "SELECT * From [" + ExcelSheetName + "]";
        dataAdapter.SelectCommand = cmd;
        dataAdapter.Fill(dt);
        conn.Close();
        //Bind Sheet Data to GridView
        GridView1.Caption = Path.GetFileName(FilePath);
        GridView1.DataSource = dt;
        GridView1.DataBind();
    }


    //protected void btnUpload_Click(object sender, EventArgs e)
    //{
    //    if (FileUpload1.HasFile)
    //    {
    //        //if (!Convert.IsDBNull(FileUpload1.PostedFile) &
    //        //       FileUpload1.PostedFile.ContentLength > 0)
    //        //{

    //        //}
    //        string Ext = Path.GetExtension(FileUpload1.PostedFile.FileName);
    //        if (Ext == ".xls" || Ext == ".xlsx")
    //        {
    //            lblErrorMessage.Visible = false;
    //            string Name = Path.GetFileName(FileUpload1.PostedFile.FileName);
    //            string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
    //            string FilePath = HttpContext.Current.Server.MapPath(FolderPath + Name);
    //            FileUpload1.SaveAs(FilePath);
    //            FillGridFromExcelSheet(FilePath, Ext, ddlIsHeaderExists.SelectedValue);
    //            L_count.Text = GridView1.Rows.Count.ToString();
    //        }
    //        else
    //        {
    //            lblErrorMessage.Visible = true;
    //            lblErrorMessage.InnerText = "Please upload valid Excel File";
    //            GridView1.DataSource = null;
    //            GridView1.DataBind();
    //        }
    //    }
    //}
    public void v_bind_sql_text(string P_report_sql)
    {
        try
        {
            DataTable dt = new DataTable();
            _sqlcom._command_Stored("PR_excel_report_connstring", ref cmd);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@reportcode", P_report_sql);
            //cmd.CommandText = "Select ReportSQL,reportFun,ColHeader1,ColHeader2,FileName,ReportTitle from sysreport where reportcode = '" + P_report_sql + "'";
            dt.Load(cmd.ExecuteReader());
            if (dt.Rows.Count > 0)
            {
                s_ReportSQL = dt.Rows[0]["ReportSQL"].ToString();
                s_reportCode = dt.Rows[0]["ReportCode"].ToString();
                S_reportname = dt.Rows[0]["ReportName"].ToString();
                s_reportFun = dt.Rows[0]["reportFun"].ToString();
                s_ColHeader1 = dt.Rows[0]["ColHeader1"].ToString();
                s_ColHeader2 = dt.Rows[0]["ColHeader2"].ToString();
                s_FileName = dt.Rows[0]["FileName"].ToString();
                s_ReportTitle = dt.Rows[0]["ReportTitle"].ToString();
                s_conncode = dt.Rows[0]["conncode"].ToString();
                s_provider = dt.Rows[0]["provider"].ToString();
                s_connectstring = dt.Rows[0]["connectstring"].ToString();
            }
            else
            {
                Response.Write("No record bind !");
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            throw ex;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    private void loading_Close()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#loading').hide();", true);
    }
    //protected void Linkbtnupload_Click(object sender, EventArgs e)
    //{
    //    try
    //    {
    //        string getreportsql = "ATMPS09";
    //        v_bind_sql_text(getreportsql);
    //        _BAK.P_USERID = Session["USER_NAME"].ToString();
    //        _BAK._BAKONG_INSERT_TRNS(GridView1, s_connectstring);
    //        loading_Close();
    //        ShowMessage("Insert records into Table sccuessful.", MessageType.Success);
    //    }
    //    catch (Exception ex)
    //    {
    //        ShowMessage("fail to insert records", MessageType.Error);
    //    }
        
    //}
    protected void Button2_ServerClick(object sender, EventArgs e)
    {
        try
        {
            if (FileUpload2.HasFile)
            {
                int flag = 0;
                string FileName = Path.GetFileName(FileUpload2.PostedFile.FileName);
                string RandomName = DateTime.Now.ToFileTime().ToString();
                string Extension = Path.GetExtension(FileUpload2.PostedFile.FileName);
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
                        FileUpload2.SaveAs(FilePath);
                        DataTable tblcsv = new DataTable();
                        //creating columns  

                        tblcsv.Columns.Add("ORIG_BANK");
                        tblcsv.Columns.Add("RECEIVED_BANK");
                        tblcsv.Columns.Add("ORIG_ACCT");
                        tblcsv.Columns.Add("RECEIVED_ACCT");
                        tblcsv.Columns.Add("TRN_DATE");
                        tblcsv.Columns.Add("TRN_TIME");
                        tblcsv.Columns.Add("BSA_DATE");
                        tblcsv.Columns.Add("CURRRENCY");
                        tblcsv.Columns.Add("TRN_AMOUNT");
                        tblcsv.Columns.Add("NOTE");
                        tblcsv.Columns.Add("DESCRIPTION");
                        tblcsv.Columns.Add("HASH");


                        //ReadCSVFile(FilePath);
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
                        _upRecon._USERID = Session["USER_NAME"].ToString();
                        //Calling insert Functions  
                        //InsertCSVRecords(tblcsv);
                        //_BUL.SaveUsingOracleBulkCopy(tblcsv);
                        //_BUL.OracleBulk_BAKONG(tblcsv);
                        _upRecon.BakongUploadRecon(tblcsv);

                        if (_upRecon._getmessage == "1")
                        {
                            ShowMessage("Uploaded Successful !!!", MessageType.Success);
                        }
                        else
                        {
                            ShowMessage("Uploaded Failed !!!", MessageType.Error);
                        }

                        
                    }

                }
                else
                {
                    //FileUpload1.SaveAs(FilePath);
                    //ReadCSVFile(FilePath);
                }
            }
            else
            {
                String msg = "Select a file then try to import";
            }
        }

        catch (Exception ex)
        {
            _BAK._getmsg = ex.Message;
            ShowMessage(_BAK._getmsg, MessageType.Error);
           // ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "alert", "alert('msg');", true);
        }
    }

    private void InsertCSVRecords(DataTable csvdt)
    {

        sqlc.ConnectionString = _sqlcom.getConnectionString();
        
        //creating object of SqlBulkCopy
        SqlBulkCopy objbulk = new SqlBulkCopy(sqlc);
        //assigning Destination table name    
        objbulk.DestinationTableName = "TEST_UPLOAD";
        //Mapping Table column    
        objbulk.ColumnMappings.Add("Name", "Name");
        objbulk.ColumnMappings.Add("City", "City");
        objbulk.ColumnMappings.Add("Address", "Address");
        objbulk.ColumnMappings.Add("Designation", "Designation");
        //inserting Datatable Records to DataBase    
        sqlc.Open();
        objbulk.WriteToServer(csvdt);
        sqlc.Close();
    }
}