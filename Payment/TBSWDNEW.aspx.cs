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

public partial class Payment_TBSWDNEW : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    SqlConnectAndSqlCommand _getsqlcon = new SqlConnectAndSqlCommand();
    DataTable CSVTable = new DataTable();
    WingDashBoard _wing = new WingDashBoard();
    GridViewValues _grid = new GridViewValues();
    OracleCommand oracmd = new OracleCommand();
    OracleConnection obj2 = new OracleConnection();
    SqlCommand cmd = new SqlCommand();
    logger _logger = new logger();
    masterreport_connect obj1 = new masterreport_connect();
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
                        GridView _getGrid = new GridView();
                        _getGrid.DataSource = CSVTable;
                        _getGrid.DataBind();

                        _wing._WING_Disputed_RSL_Insert(_getGrid);
                        // _CSS._CSS_LoopGrid(_getGrid);  //getgrid1
                        ShowMessage("Insert records into Table scuessful.", MessageType.Success);
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
        catch (Exception ex)
        {
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
                        ReadCSVFile(FilePath);
                    }

                }
                else
                {
                    FileUpload1.SaveAs(FilePath);
                    ReadCSVFile(FilePath);
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
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}