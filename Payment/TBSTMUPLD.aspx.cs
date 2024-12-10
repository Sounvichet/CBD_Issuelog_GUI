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
using TrueMoneyClearingDispute; 

public partial class Payment_TBSTMUPLD : System.Web.UI.Page
{
    Oracle_BulkInsert _BUL = new Oracle_BulkInsert();
    master_debug _log = new master_debug();
    TrueMoneyUploadReconFile _trueM = new TrueMoneyUploadReconFile();
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
                        tblcsv.Columns.Add("Tran_ID");
                        tblcsv.Columns.Add("Long_order_id"); // new added 
                        tblcsv.Columns.Add("Account_id");
                        tblcsv.Columns.Add("Service_type");
                        tblcsv.Columns.Add("Currency");
                        tblcsv.Columns.Add("Req_amount");
                        tblcsv.Columns.Add("Fee");
                        tblcsv.Columns.Add("Comm_Partner");
                        tblcsv.Columns.Add("Biller_Bal");
                        tblcsv.Columns.Add("Account_number");
                        tblcsv.Columns.Add("Account_name");
                        tblcsv.Columns.Add("Amount");
                        tblcsv.Columns.Add("Note");
                        tblcsv.Columns.Add("Phone_Number");
                        tblcsv.Columns.Add("Penalty_Amount");
                        tblcsv.Columns.Add("Repayment_amount");
                        tblcsv.Columns.Add("Ex_Reference");
                        tblcsv.Columns.Add("ref_number");
                        tblcsv.Columns.Add("Status");
                        tblcsv.Columns.Add("Action_date");

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

                        //_BUL.OracleBulk_TRUE_upload_recon(tblcsv);
                        _trueM.TrueMoneyUploadRecon(tblcsv);
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