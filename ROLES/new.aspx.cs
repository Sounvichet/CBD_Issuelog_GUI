using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
public partial class ROLES_new : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    ROLESDashboard _role = new ROLESDashboard();
    DropDownListValues _drop = new DropDownListValues();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            _getdropGlevel();
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
    private void _getdropGlevel()
    {
        _drop.bindDropDownList(dgrouplevel, _role._getAccountGroup_GetLevelList());
    }
    private bool _AccountGroup_add()
    {
        _role._GroupID = txtgroupid.Text;
        _role._GName = txtname.Text;
        _role._GDesc = txtDescription.Text;
        _role._GStatus = chkactive.Checked ? "A" : "N";
        _role._GLevel = dgrouplevel.SelectedValue;
        _role._GOrder = txtorder.Text;
        _role._Holiday = Convert.ToInt16(Chkholiday.Checked);
        _role._userid = Session["USER_NAME"].ToString();
        _role._RemoteAddr = _getlocalIP();
        bool _getaccountgroup_add =  _role._AccountGroup_Add();
        if (_getaccountgroup_add == false)
        {   
            ShowMessage("Please contacted with Administrator", MessageType.Error);
        }
        else
        {
            bool _InitPermission = _role._AccountGroup_InitPermission();
            if (_InitPermission == false)
            {
                ShowMessage("Please contacted with Administrator", MessageType.Error);
            }
            else
            {
                ShowMessage("ROLE Registerd is successfully..!", MessageType.Success);
            }
            return _InitPermission;
        }
        return _getaccountgroup_add;
    }

    protected void Linkbtnnew_Click(object sender, EventArgs e)
    {
        linkbtnsave.Enabled = true;
        Linkbtncancel.Enabled = true;
        txtgroupid.Enabled = true;
        txtname.Enabled = true;
        txtorder.Enabled = true;
        txtDescription.Enabled = true;
        chkactive.Enabled = true;
        dgrouplevel.Enabled = true;
        Chkholiday.Enabled = true;
    }

    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
         _AccountGroup_add();

        //int get_holiday = Convert.ToInt16(Chkholiday.Checked);
        //Response.Write(get_holiday);
    }
    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("GNRROLE.aspx");
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}