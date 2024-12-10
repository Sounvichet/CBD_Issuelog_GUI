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
public partial class Payment_CSSIST : System.Web.UI.Page
{
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    MaintenanceFee _Main = new MaintenanceFee();
    logger _logger = new logger();
    SqlConnection sqlc = new SqlConnection();
    CSSdashboard _CSS = new CSSdashboard();
    DataTable CSVTable = new DataTable();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        if (!IsPostBack)
        {
            
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
                        _CSS._CSS_insert_Trans(_getGrid);  //getgrid1
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

    //public bool _INSERT_RECORD()
    //{
    //    bool INSERTDATE = _CSS._CSS_INSERT_TRNBYDAY();
    //    string getrecord = _CSS.P_rowcount.ToString();
    //    if (INSERTDATE == true)
    //    {
    //        ShowMessage("INSERT records"+ getrecord + " is Successful..", MessageType.Success);
    //    }
    //    else 
    //     {
    //        ShowMessage("Please try it again!!", MessageType.Error);
    //    }

    //    return INSERTDATE;

    //}

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void btnUpload_Click(object sender, EventArgs e)
    {
        //if (FileUpload1.HasFile)
        //{
        //    //if (!Convert.IsDBNull(FileUpload1.PostedFile) &
        //    //       FileUpload1.PostedFile.ContentLength > 0)
        //    //{

        //    //}
        //        string Ext = Path.GetExtension(FileUpload1.PostedFile.FileName);
        //    if (Ext == ".xls" || Ext == ".xlsx")
        //    {
        //        lblErrorMessage.Visible = false;
        //        string Name = Path.GetFileName(FileUpload1.PostedFile.FileName);
        //        string FolderPath = ConfigurationManager.AppSettings["FolderPath"];
        //        string FilePath = HttpContext.Current.Server.MapPath(FolderPath + Name);
        //        FileUpload1.SaveAs(FilePath);
        //        FillGridFromExcelSheet(FilePath, Ext, ddlIsHeaderExists.SelectedValue);
        //        L_count.InnerText = getgrid1.Rows.Count.ToString();
        //        }
        //    else
        //    {
        //        lblErrorMessage.Visible = true;
        //        lblErrorMessage.InnerText = "Please upload valid Excel File";
        //        getgrid1.DataSource = null;
        //        getgrid1.DataBind();
        //    }
        //}
        btnUpload.Enabled = false;
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
                        btnUpload.Enabled = true;
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
}