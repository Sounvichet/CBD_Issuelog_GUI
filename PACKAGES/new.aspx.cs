using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using System.Data;
using System.Net;

public partial class PACKAGES_new : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    PackageDashboard _PKG = new PackageDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
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

    private bool _PACKAGE_CREATE()
    {
        string getdate = DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss").Replace('/', '-');
        _PKG._PackageNameK = txtservicename.Text;
        _PKG._PRICE = Convert.ToDecimal(TxtPrice.Text);
        _PKG._Createdate = getdate;
        _PKG._Createby = Session["USER_NAME"].ToString();
        _PKG._UserID = Session["USER_NAME"].ToString();
        _PKG._GETIP = _getlocalIP();
        bool _getService = _PKG._PACKAGES_ADD();
        if (_getService == false)
        {
            ShowMessage(_PKG._message, MessageType.Error);
        }
        else
        {
            ShowMessage("PACKAGE Registration Successfully : " + _PKG.getPackageID + "", MessageType.Success);
        }
        return _getService;
    }
    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        if (TxtPrice.Text == "")
        {
            ShowMessage("Maindatory field is Price not allow Blank.", MessageType.Error);
        }
        else
        {
            _PACKAGE_CREATE();
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
}