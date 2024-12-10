using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Data;
using System.Data.SqlClient;

public partial class ROLES_GetJobtitlegroupid : System.Web.UI.Page
{
    UserFundamentals _user = new UserFundamentals();
    ListBoxvalues _listbox = new ListBoxvalues();
    ROLESDashboard _role = new ROLESDashboard();
    UserDashboard _userd = new UserDashboard();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            //ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
            _account_logout();
        }

        if (!IsPostBack)
        {
            string _getjobtitile = Request.QueryString["TITLEID"].ToString();
            _getsysgrouplist();
            _getsysgroup_fundamentalsbyjob();
        }
    }

    private bool _account_logout()
    {
        if (_userd._UserID == null)
        {
            Response.Redirect("default.aspx");
            return true;
        }
        _userd._UserID = Session["user_name"].ToString();
        _userd._Remoteaddr = _getlocalIP();
        bool getlog_out = _userd._Account_Logout();
        if (getlog_out == false)
        {
            Response.Write(@"<script language='javascript'>alert('Please contact admin for logout !!')</script>");
        }

        else
        {

        }
        return getlog_out;
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
    protected void btnLeft_Click(object sender, EventArgs e)
    {
        //List will hold items to be removed.
        List<ListItem> removedItems = new List<ListItem>();

        //Loop and transfer the Items to Destination ListBox.
        foreach (ListItem item in lstRight.Items)
        {
            if (item.Selected)
            {
                item.Selected = false;
                lstLeft.Items.Add(item);
                removedItems.Add(item);
            }
        }

        //Loop and remove the Items from the Source ListBox.
        foreach (ListItem item in removedItems)
        {
            lstRight.Items.Remove(item);
        }
    }

    protected void btnRight_Click(object sender, EventArgs e)
    {
        //List will hold items to be removed.
        List<ListItem> removedItems = new List<ListItem>();

        //Loop and transfer the Items to Destination ListBox.
        foreach (ListItem item in lstLeft.Items)
        {
            if (item.Selected)
            {
                item.Selected = false;
                lstRight.Items.Add(item);
                removedItems.Add(item);
            }
        }

        //Loop and remove the Items from the Source ListBox.
        foreach (ListItem item in removedItems)
        {
            lstLeft.Items.Remove(item);
        }
    }
    private void _getsysgrouplist()
    {
        _listbox.bindListBox_String(lstLeft, _user._get_sysgrouplist());
    }
    private void _getsysgroup_fundamentalsbyjob()
    {
        _role._jobtitle = Request.QueryString["TITLEID"].ToString();
        _listbox.bindListBox_String(lstRight, _role._GetGroupidbytitile_fundamentals());
    }

    public bool _USERGROUP()
    {
        _role._jobtitle = Request.QueryString["TITLEID"].ToString();
        bool _Jobgroup_delete = _role._SYSJOBTITLEGROUP_DELETE();

        if (_Jobgroup_delete == false)
        {
            ShowMessage("Can not add user group please contact admin", MessageType.Error);
        }

        else
        {
            _role._jobtitle = Request.QueryString["TITLEID"].ToString();
            _role._SYSJOBTITLEGROUP_ADD(lstRight);
            ShowMessage("add Job group successfully", MessageType.Success);
        }
        return _Jobgroup_delete;

    }
    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        _USERGROUP();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    public enum MessageType { Success, Error, Info, Warning };
}