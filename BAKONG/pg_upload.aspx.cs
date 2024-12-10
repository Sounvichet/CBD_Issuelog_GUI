using System;
using System.Web.UI;
using System.Data.SqlClient;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using MasterReportClass;
using BakongClearingDispute; 
public partial class BAKONG_pg_upload : System.Web.UI.Page
{
    BAKONGDashboard _BAK = new BAKONGDashboard();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    logger _logger = new logger();
    SqlConnection sqlc = new SqlConnection();
    masterreport_connect obj1 = new masterreport_connect();
    Oracle_BulkInsert _BUL = new Oracle_BulkInsert();
    //BakongUploadReconFile _upRecon = new BakongUploadReconFile();
    BakongPGUploadReconfile _pg = new BakongPGUploadReconfile();


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
    
    private void loading_Close()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#loading').hide();", true);
    }
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

                        tblcsv.Columns.Add("ID");
                        tblcsv.Columns.Add("SRC_ACCOUNT");
                        tblcsv.Columns.Add("DEST_ACCOUNT");
                        tblcsv.Columns.Add("CCY");
                        tblcsv.Columns.Add("AMOUNT");
                        tblcsv.Columns.Add("CREATED_TIME");
                        tblcsv.Columns.Add("LOCAL_TIME");
                        tblcsv.Columns.Add("BSA_DATE");
                        tblcsv.Columns.Add("TRN_HASH");
                        tblcsv.Columns.Add("STATUS");
                        tblcsv.Columns.Add("SRC_ACC_TYPE");
                        tblcsv.Columns.Add("DEST_ACC_TYPE");
                        tblcsv.Columns.Add("SRC_BIN");
                        tblcsv.Columns.Add("DEST_BIN");
                        tblcsv.Columns.Add("DOMAIN");
                        tblcsv.Columns.Add("TYPE");

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
                        _pg._USERID = Session["USER_NAME"].ToString();
                        //Calling insert Functions  
                        //InsertCSVRecords(tblcsv);
                        //_BUL.SaveUsingOracleBulkCopy(tblcsv);
                        //_BUL.OracleBulk_BAKONG(tblcsv);
                        _pg.BakongUploadRecon(tblcsv);
                        ShowMessage("Uploaded Successful !!!", MessageType.Success);
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
            ShowMessage(_pg._getmessage, MessageType.Error);
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