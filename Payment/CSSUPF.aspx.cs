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
using CSSClearingClass; 
public partial class Payment_CSSUPF : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    SqlConnectAndSqlCommand _getsqlcon = new SqlConnectAndSqlCommand();
    CSSdashboard _CSS = new CSSdashboard();
    DataTable CSVTable = new DataTable();
    //Oracle_BulkInsert _BUL = new Oracle_BulkInsert();
    MasterReportClass.Bulk_CSS_Recon _BUL = new MasterReportClass.Bulk_CSS_Recon();
    CSSClearingClass.InsertFileInfo _file = new CSSClearingClass.InsertFileInfo();
    CSSClearingClass.GetSessionID _getses = new CSSClearingClass.GetSessionID () ;
    CSSClearingClass.UploadReconFile _up = new CSSClearingClass.UploadReconFile();
    master_debug _log = new master_debug();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
    }

    public void ReadCSVFile(string fileName)
    {
        try
        {
            string connection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\\;Extended Properties='Text;HDR=Yes;FMT=CSVDelimited'";

            connection = String.Format(connection, Path.GetDirectoryName(fileName));

            string datatype = string.Empty; 
            OleDbDataAdapter csvAdapter;
            csvAdapter = new OleDbDataAdapter("SELECT * FROM [" + Path.GetFileName(fileName) + "]", connection);
            

            if (File.Exists(fileName) && new FileInfo(fileName).Length > 0)
            {
                try
                {
                    csvAdapter.Fill(CSVTable);
                    if ((CSVTable != null) && (CSVTable.Rows.Count > 0))
                    {
                        ViewState["CSVTable"] = CSVTable;
                        //getgrid1.DataSource = CSVTable;
                        //getgrid1.DataBind();
                        //L_count.InnerText = getgrid1.Rows.Count.ToString();

                        GridView _getGrid = new GridView();
                        _getGrid.DataSource = CSVTable;
                        _getGrid.DataBind();
                        _CSS._CSS_LoopGrid(_getGrid);  //getgrid1
                        loading_Close();
                        ShowMessage("Insert records into Table successful.", MessageType.Success);
                    }
                    else
                    {
                        String msg = "No records found";
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(String.Format("Error reading Table {0}.\n{1}", Path.GetFileName(fileName), ex.Message));
                }
            }
        }
        catch (Exception ex) {
            throw ex;
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
                FolderPath += "/Upload"; 
                string FilePath = Server.MapPath(FolderPath + RandomName + FileName);

                string[] filenames = Directory.GetFiles(Server.MapPath("~/Payment/Files/Upload"));

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

                        tblcsv.Columns.Add("RAW_DATA");
                        tblcsv.Columns.Add("SESSION_ID");

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

                        string _getcount = tblcsv.Rows.Count.ToString();


                        _file.P_FILE_ATTR = "CSS_CLEARING";
                        _file.P_FILE_NAME = FileName;
                        _file.insertfilename();

                        DataTable dt = _getses._GETSessionID();

                        _up._SESSION_ID = dt.Rows[0][0].ToString();

                        _up.CSS_upload_raw_data(tblcsv);

                        _file.opr_processing();



                        // _BUL.OracleBulk_CSS_upload_recon(tblcsv);
                        loading_Close();
                        ShowMessage("Uploaded Successful with records " + _getcount + " !!!", MessageType.Success);

                    }
                    else
                    {
                        ShowMessage("File already exists. Please rename the file and try again.", MessageType.Warning);
                    }

                }
            }
            else
            {
                ShowMessage("Select a file then try to import.", MessageType.Warning);

            }

        }

        catch (Exception ex)
        {
            string _getmsg = _log._messageError;
            ShowMessage(_getmsg, MessageType.Error);
            ShowMessage("An error occurred while uploading the file. Please try again later.", MessageType.Error);
        }
    }

    private void loading()
    {
        //string script = isHide ? "$('#loading').hide(); " : "$('#loading').show(); ";
        //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#loading').show();", true);
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