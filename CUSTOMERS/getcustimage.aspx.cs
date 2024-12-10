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
public partial class CUSTOMERS_getcustimage : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    dbcon obj1 = new dbcon();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    CustomerDashboard _cust = new CustomerDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    string filename = "";
    string ext = "";
    string contenttype = "";
    int filesize = 0;
    string _getcurrentdate = "";
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!this.IsPostBack)
        {
            
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

    public void _GetCustFundamentals()
    {
        _cust._customerID = Request.QueryString["CUSTOMERID"].ToString();
        try
        {
            DataTable dt = _cust._getCustomerFundamentals();
            _cust._customerID = dt.Rows[0]["CustomerID"].ToString();
            _cust._BranchID = dt.Rows[0]["BranchID"].ToString();
            _cust._CompanyID = dt.Rows[0]["CompanyID"].ToString();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    private bool _GetcustPhoto()
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

        string getcustomerid = Request.QueryString["customerID"].ToString();
        _cust._customerID = getcustomerid;
        bool _cust_delete = _cust._CUSTPHO_DELETE();
        if (_cust_delete == false)
        {
            ShowMessage("Customer photo uploaded is fail please contact admin!", MessageType.Error);
        }

        else
        {
            _GetCustFundamentals();
            bool getcustphto = _CUSTPHOTO_ADD();
            if (getcustphto == false)
            {
                ShowMessage("employee photo uploaded is fail please contact admin!", MessageType.Error);
            }
            else
            {
                ShowMessage("Customer image uploaded is successfully with USER " + Session["user_name"].ToString() + "", MessageType.Success);
            }
            return getcustphto;
        }
        return _cust_delete;
    }
    public bool _CUSTPHOTO_ADD()
    {

        try
        {
            int retval = 0;
            if (contenttype != String.Empty)
            {

                Stream fs = filcusUpload.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);                                 //reads the   binary files
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);                           //counting the file length into bytes
                _getcurrentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
                _sqlcmd._command_Stored("PR_CUSTOMERPHOTO_ADD", ref cmd);
                cmd.Parameters.AddWithValue("@CompanyID", _cust._CompanyID);
                cmd.Parameters.AddWithValue("@BranchID", _cust._BranchID);
                cmd.Parameters.AddWithValue("@CustomerID", _cust._customerID);
                cmd.Parameters.AddWithValue("@Photo", SqlDbType.Binary).Value = bytes;
                cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = filename;
                cmd.Parameters.AddWithValue("@file_size", filesize);
                cmd.Parameters.AddWithValue("@File_type", SqlDbType.NVarChar).Value = contenttype;
                cmd.Parameters.AddWithValue("@CreatedBy", Session["user_name"].ToString());
                cmd.Parameters.AddWithValue("@CreatedDate", _getcurrentdate);
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
        _GetcustPhoto();
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}