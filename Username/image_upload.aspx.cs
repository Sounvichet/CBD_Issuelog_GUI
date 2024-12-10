using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;
public partial class Username_image_upload : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    dbcon obj1 = new dbcon();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    EmployeeDashboard _emp = new EmployeeDashboard();
    Employee_Info _employee = new Employee_Info();
    public enum MessageType { Success, Error, Info, Warning };
    string filename = "";
    string ext = "";
    string contenttype = "";
    int filesize = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
    }
    public string _getlocalIP()
    {
        IPHostEntry host;
        string localID = "?";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily.ToString() == "InterNetwork")
            {
                localID = ip.ToString();
            }
        }

        return localID;
    }
    private bool _GetEmpPhoto()
    {
        filename = Path.GetFileName(filcusUpload.PostedFile.FileName);
        ext = Path.GetExtension(filename);
        contenttype = String.Empty;
        switch (ext)
        {
            case ".jpg":
                contenttype = "image/jpg";
                break;
            case ".png":
                contenttype = "image/png";
                break;
        }
        filesize = filcusUpload.PostedFile.ContentLength;

        string SIDCARD = Request.QueryString["SIDCARD"].ToString();
        _emp._EmployeeID = SIDCARD;
        bool _EmpPhoto_Delete = _emp._EMPPHO_DELETE();
        if (_EmpPhoto_Delete == false)
        {
            ShowMessage("employee photo uploaded is fail please contact admin!", MessageType.Error);
        }

        else
        {
            bool getempphto = _EMPPHOTO_ADD();
            if (getempphto == false)
            {
                ShowMessage("employee photo uploaded is fail please contact admin!", MessageType.Error);
            }
            else
            {
                ShowMessage("Employee image uploaded is successfully with USER " + Session["user_name"].ToString()+ "", MessageType.Success);
            }
            return getempphto;
        }
        return _EmpPhoto_Delete;
    }
    public bool _EMPPHOTO_ADD()
    {

        try
        {
            int retval = 0;
            if (contenttype != String.Empty)
            {

                Stream fs = filcusUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);                                 //reads the   binary files
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);                           //counting the file length into bytes

                _sqlcmd._command_Stored("PR_EMPPHOTO_ADD", ref cmd);
                cmd.Parameters.AddWithValue("@CompanyID", Session["COMPANY"].ToString());
                cmd.Parameters.AddWithValue("@BranchID", Session["BRANCHCODE"].ToString());
                cmd.Parameters.AddWithValue("@EmployeeID", _emp._EmployeeID);
                cmd.Parameters.AddWithValue("@Photo", SqlDbType.Binary).Value = bytes;
                cmd.Parameters.AddWithValue("@CreatedBy", Session["user_name"].ToString());
                cmd.Parameters.AddWithValue("@CreatedFrom", _getlocalIP());
                cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                //retval = cmd.Parameters["@retval"].Value.ToString();
                retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            }

            else if (contenttype == String.Empty)
            {
                ShowMessage("Please try again there is no upload file", MessageType.Warning);
            }
            if (retval == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            return false;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    protected void LinkAction_Click(object sender, EventArgs e)
    {
        _GetEmpPhoto();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}