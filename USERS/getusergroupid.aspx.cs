using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;

public partial class USERS_getusergroupid : System.Web.UI.Page
{
    UserFundamentals _user = new UserFundamentals();
    ListBoxvalues _listbox = new ListBoxvalues();
    ROLESDashboard _role = new ROLESDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!IsPostBack)
        {
            _user._userid = Request.QueryString["getuserid"].ToString();
            _getusergrouprule();
            _getsysgrouplist();
        }
    }
    private void _getusergrouprule()
    {
        _listbox.bindListBox_String(lstRight, _user._get_UserGrouprolebyUserid());
    }
    private void _getsysgrouplist()

    {
        _listbox.bindListBox_String(lstLeft, _user._get_sysgrouplist());
    }
    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        ShowMessage("Can not add user group please contact admin", MessageType.Error);
    }
    protected void LeftClick(object sender, EventArgs e)
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

    protected void RightClick(object sender, EventArgs e)
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

    public bool _USERGROUP()
    {
        string usergroup = Request.QueryString["getuserid"].ToString();
        _role._usergroup = usergroup;
        bool _usergroup_delete = _role._sysusergroup_delete();

        if (_usergroup_delete == false)
        {
            ShowMessage("Can not add user group please contact admin", MessageType.Error);
        }

        else
        {
            _role._userid = Session["USER_NAME"].ToString();
            _role._RemoteAddr = _getlocalIP();
            _role._sysusergroup_ADD(lstRight);
            ShowMessage("add user group successfully", MessageType.Success);
        }
        return _usergroup_delete;

    }
    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        _USERGROUP();
    }


    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}