using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using System.Data;
using System.Net;

public partial class SERVICES_delete : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    ServiceDashboard _service = new ServiceDashboard();
    DropDownListValues _drop = new DropDownListValues();
    string ServiceID = "";
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            ServiceID = Request.QueryString["SERVICEID"].ToString();
            txtServiceID.Text = ServiceID;
            _GetServiceStatus();
            _GetCustFundamentals();
            
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
    private bool _SERVICE_DELETE()
    {
        _service._ServiceID = txtServiceID.Text;
        _service._USERiD = Session["USER_NAME"].ToString();
        _service._RemoteAddr = _getlocalIP();
        bool _getService = _service._SERVICE_DELETE();
        if (_getService == false)
        {
            ShowMessage(_service._message, MessageType.Error);
        }
        else
        {
            ShowMessage("SERVICE Delete Successfully : "+ _service._ServiceID + "", MessageType.Success);
        }
        return _getService;
    }

    private void _GetServiceStatus()
    {
        _drop.bindDropDownList_String(D_ServiceStatus, _service._getServicesStatus());
    }
    private void _GetCustFundamentals()
    {
        _service._ServiceID = txtServiceID.Text;
        try
        {
            DataTable dt = _service._getServiceFundamentals();
            txtservicename.Text = dt.Rows[0]["serviceNameK"].ToString();
            txtprice.Text = dt.Rows[0]["Price"].ToString();
            D_ServiceStatus.SelectedValue = dt.Rows[0]["SERVICESTATUS"].ToString();
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

    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void linkbtnupdate_Click(object sender, EventArgs e)
    {
        _SERVICE_DELETE();
    }
}