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

public partial class Payment_TBSWUPLD : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    WingDashBoard _wing = new WingDashBoard();
    SqlCommand cmd = new SqlCommand();
    logger _logger = new logger();
    Oracle_BulkInsert _BUL = new Oracle_BulkInsert();
    master_debug _log = new master_debug();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
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
                        DataTable tblcsv = new DataTable();
                        //creating columns  

                        //tblcsv.Columns.Add("NAME");
                        //tblcsv.Columns.Add("CITY");
                        //tblcsv.Columns.Add("ADDRESS");
                        //tblcsv.Columns.Add("DESIGNATION");

                        tblcsv.Columns.Add("tran_date");
                        tblcsv.Columns.Add("txn_time"); // new added
                        tblcsv.Columns.Add("tran_id");
                        tblcsv.Columns.Add("reference_id");
                        tblcsv.Columns.Add("txn_reference_no"); // new added
                        tblcsv.Columns.Add("service_name");
                        tblcsv.Columns.Add("wing_account_name"); // new added
                        tblcsv.Columns.Add("wing_num"); // Move 
                        tblcsv.Columns.Add("category"); // new added
                        tblcsv.Columns.Add("prefix"); // new added
                        tblcsv.Columns.Add("loan_num"); // Move
                        tblcsv.Columns.Add("customer_name"); // new added
                        tblcsv.Columns.Add("cust_phone"); // Move
                        tblcsv.Columns.Add("dr"); // new added
                        tblcsv.Columns.Add("cr"); // new added
                        tblcsv.Columns.Add("balance"); // move
                        tblcsv.Columns.Add("txn_status"); // new added
                        tblcsv.Columns.Add("channel"); // new added
                        tblcsv.Columns.Add("transfer_type"); // new added
                        tblcsv.Columns.Add("sender"); // move
                        tblcsv.Columns.Add("sender_acct"); // new added
                        tblcsv.Columns.Add("sender_name"); // new added
                        tblcsv.Columns.Add("remark"); // move
                        tblcsv.Columns.Add("Tran_ccy");
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
                        _BUL._USERID = Session["USERID"].ToString();
                        string _getcount = tblcsv.Rows.Count.ToString();
                        _BUL.OracleBulk_WING_upload_recon(tblcsv);
                        loading_Close();
                        ShowMessage("Uploaded Successful Total records : "+ _getcount + " !!!", MessageType.Success);
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
            string _getmsg = _log._messageError; 
            ShowMessage(_getmsg, MessageType.Error);
        }
    }
    private void loading_Close()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#loading').hide();", true);
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}