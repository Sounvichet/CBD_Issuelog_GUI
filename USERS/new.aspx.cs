using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using System.Data;
using System.Net;
public partial class USERS_new : System.Web.UI.Page
{
    
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    UserDashboard _user = new UserDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!IsPostBack)

        {
            _getgender();
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
    private bool _ACCOUNT_CREATE()
    {
        _user._UserID = txtuserid.Text;
        _user._Fname = txtfname.Text;
        _user._Lname = txtlname.Text;
        _user._Email = txtemail.Text;
        _user._Password = txtpassword.Text;
        _user._Remoteaddr = _getlocalIP();

        bool _getaccount = _user._ACCOUNT_CREATE();
        if (_getaccount == false)
        {
            ShowMessage(_user._message, MessageType.Error);
        }
        else
        {
            _user._name = txtuserid.Text;
            _user._IDCard = txtIDCard.Text;
            _user._Password = txtpassword.Text;
            _user._CreatedBy = Session["USER_NAME"].ToString();
            _user._Remoteaddr = _getlocalIP();
            bool GetSysuser = _user._SysuserEmployee_ADD();
            if (GetSysuser == false)
            {
                ShowMessage("Fail "+ _user._message + "", MessageType.Success);
            }
            else
            {
                _user._name = txtuserid.Text;
                bool UserBranchUpdate = _user._USER_BRANCH_UPDATE();
                if (UserBranchUpdate == false)
                {
                    ShowMessage("Fail " + _user._message + "", MessageType.Success);
                }
                else
                {
                    ShowMessage("USER Registration Successful.. :" + _user._getuser + "", MessageType.Success);
                }
            }
        }
        return _getaccount;
    }
    private bool _GetAccountRegister_Create()
    {
        _user._Fname = txtfname.Text;
        _user._Lname = txtlname.Text;
        _user._gender = D_gender.SelectedValue;
     //   _user._DBO = txtDBO.Text;
     //   _user._EMPDATE = txtstartdate.Text;
        _user._IDCard = txtIDCard.Text;
        _user._UserID = txtuserid.Text;
        _user._Password = txtpassword.Text;
        _user._Email = txtemail.Text;
       // _user._Remoteaddr = _getlocalIP();

        bool _getaccount = _user._AccountRegister_Create();
        if (_getaccount == false)
        {
            ShowMessage(_user._message, MessageType.Error);
        }
        else
        {
            ShowMessage("USER Registration Successful", MessageType.Success);
        }
        return _getaccount;
    }

    private bool _getSysuserEmployee_ADD()
    {
        _user._name = txtuserid.Text;
        _user._IDCard = txtIDCard.Text;
        _user._Password = txtpassword.Text;
        _user._CreatedBy = Session["USER_NAME"].ToString();
        _user._Remoteaddr = _getlocalIP();

        bool _getaccount = _user._SysuserEmployee_ADD();
        if (_getaccount == false)
        {
            ShowMessage(_user._message, MessageType.Error);
        }
        else
        {
            ShowMessage("USER Registration Successful", MessageType.Success);
        }
        return _getaccount;
    }
    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        //_GetAccountRegister_Create();
        _ACCOUNT_CREATE();
        //_getSysuserEmployee_ADD();
    }

    private void _getgender()
    {
        _drop.bindDropDownList_String(D_gender, _user._getEMPGENDER());
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