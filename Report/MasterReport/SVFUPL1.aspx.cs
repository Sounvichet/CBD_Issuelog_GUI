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

public partial class Report_MasterReport_SVFUPL1 : System.Web.UI.Page
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

                string[] filenames = Directory.GetFiles(Server.MapPath("~/Report/MasterReport"));

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

                        tblcsv.Columns.Add("run_date");
                        tblcsv.Columns.Add("delivery_agent");
                        tblcsv.Columns.Add("emboss_name");
                        tblcsv.Columns.Add("cust_category");
                        tblcsv.Columns.Add("iss_date");
                        tblcsv.Columns.Add("card_status");
                        tblcsv.Columns.Add("iss_days");
                        tblcsv.Columns.Add("persion_id");
                        tblcsv.Columns.Add("account_num");
                        tblcsv.Columns.Add("cref_no");
                        tblcsv.Columns.Add("exp_dt");
                        tblcsv.Columns.Add("card_id");
                        
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
                        _BUL._USERID = Session["USER_NAME"].ToString();
                        //Calling insert Functions  
                        //InsertCSVRecords(tblcsv);
                        //_BUL.SaveUsingOracleBulkCopy(tblcsv);
                        string _getcount = tblcsv.Rows.Count.ToString();
                        _BUL.OracleBulk_CARD_90days_upload(tblcsv);
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
            ShowMessage(_getmsg,MessageType.Error);
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