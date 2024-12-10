using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using System.Data;
using System.Net;

public partial class BRANCHES_edit : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    BranchDashboard _brn = new BranchDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
           string BranchCode =  Request.QueryString["BRANCHID"].ToString();
            txtBranchCode.Text = BranchCode;
            _GetBrancFundamentals();
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
    private bool _BRANCH_UPDATE()
    {
        //string getdate = DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss").Replace('/', '-');
        _brn._branchID = txtBranchCode.Text;
        _brn._UserID = Session["USER_NAME"].ToString();
        _brn._branchName = txtBranchName.Text;
        _brn._branchNameK = TxtBranchNameK.Text;
        _brn._RemoteAddr = _getlocalIP();
        bool _getService = _brn._BRANCH_UPDATE();
        if (_getService == false)
        {
            ShowMessage(_brn._message, MessageType.Error);
        }
        else
        {
            ShowMessage("BRANCH UPDATE Successfully : " + _brn._branchID + "", MessageType.Success);
        }
        return _getService;
    }

    private void _GetBrancFundamentals()
    {
        _brn._branchID = txtBranchCode.Text;
        try
        {
            DataTable dt = _brn._GETBRANCHFundamentals();
            txtCompany.Text = dt.Rows[0]["CompanyID"].ToString();
            txtBranchShort.Text = dt.Rows[0]["BranchShort"].ToString();
            txtBranchName.Text = dt.Rows[0]["BranchName"].ToString();
            TxtBranchNameK.Text = dt.Rows[0]["BranchNameK"].ToString();
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
    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        _BRANCH_UPDATE();
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