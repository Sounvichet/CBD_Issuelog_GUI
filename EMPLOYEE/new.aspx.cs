using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using System.Data;
using System.Net;

public partial class EMPLOYEE_new : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    EmployeeDashboard _emp = new EmployeeDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            _getbranchIDDLL();
            _getGender();
            _getEmpStatus();
            _getEmpjobtitle();
        }
    }

    private void _getbranchIDDLL()
    {
        _drop.bindDropDownList_String(D_branchID, _emp._getBranchID());
    }
    private void _getGender()
    {
        _drop.bindDropDownList_String(D_gender, _emp._getEMPGENDER());
    }
    private void _getEmpStatus()
    {
        _drop.bindDropDownList_String(d_empStatus, _emp._getEMPSTATUS());
    }
    private void _getEmpjobtitle()
    {
        _drop.bindDropDownList_String(d_jobttile, _emp._getEMPJobtitle());
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
    private bool _EMP_CREATE()
    {
        string getdate = DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss").Replace('/', '-');
        _emp._BranchID = D_branchID.SelectedValue;
        _emp._EMPDATE = txtempdate.Text;
        _emp._FName = txtFirstName.Text;
        _emp._LName = txtLastName.Text;
        _emp._NameKhmer = txtnameKhmer.Text;
        _emp._Gender = D_gender.SelectedValue;
        _emp._EMPStatus = d_empStatus.SelectedValue;
        _emp._JobTitle = d_jobttile.SelectedValue;
        _emp._Phone = txtphone.Text;
        _emp._Email = txtemail.Text;
        _emp._UserID = Session["USER_NAME"].ToString();
        _emp._RemoteAddr = _getlocalIP();
        bool _EMPADD = _emp._EMPLOYEE_ADD();
        if (_EMPADD == false)
        {
            ShowMessage(_emp._message, MessageType.Error);
        }
        else
        {
            ShowMessage("EMPLOYEE Registration Successfully : " + _emp._getempID + "", MessageType.Success);
        }
        return _EMPADD;
    }
    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        _EMP_CREATE();
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