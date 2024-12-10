using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using System.Data;
using System.Net;

public partial class PACKAGES_Add_schedule : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    PackageDashboard _PKG = new PackageDashboard();
    ServiceDashboard _SER = new ServiceDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            string getPackageID = Request.QueryString["PackageID"].ToString();
            txtPackageID.Text = getPackageID;
            _GetPKGFundamentals();
            _getServiceID();

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

    private void _GetPKGFundamentals()
    {
        _PKG._PACKAGEID = txtPackageID.Text;
        try
        {
            DataTable dt = _PKG._getPKGFundamentals();
            txtPkgname.Text = dt.Rows[0]["packageNameK"].ToString();
            //TxtPrice.Text = dt.Rows[0]["Price"].ToString();
            //D_PKGSTATUS.SelectedValue = dt.Rows[0]["PKGSTATUS"].ToString();
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

    private bool _SERVICEPACKAGE_ADD()
    {
        string getdate = DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss").Replace('/', '-');
        _PKG._SERPKGSCHEDULE = Convert.ToInt32(txtscheduleno.Text);
        _PKG._PACKAGEID = txtPackageID.Text;
        _PKG._SERVICEID = D_SERVICEID.SelectedValue;
        _PKG._UserID = Session["USER_NAME"].ToString();
        _PKG._RemoteAddr = _getlocalIP();
        bool _getService = _PKG._SERVICEPACKAGE_ADD();
        if (_getService == false)
        {
            ShowMessage(_PKG._message, MessageType.Error);
        }
        else
        {
            ShowMessage("SERVICEPACKAGE Registration Successfully : " + txtPackageID.Text + "", MessageType.Success);
            //txtPackageID.Text = "";
            //txtscheduleno.Text = "";
            //D_SERVICEID.ClearSelection();
        }
        return _getService;
    }

    private void _getServiceID()
    {
        _drop.bindDropDownList_String(D_SERVICEID, _SER._GetDDLSERVICEID());
    }
    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        _SERVICEPACKAGE_ADD();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void Linkbtnrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
}