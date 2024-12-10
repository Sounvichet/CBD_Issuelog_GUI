using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
public partial class ROLES_delete : System.Web.UI.Page
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
            string ROLEID = Request.QueryString["ROLEID"].ToString();
            txtgroupid.Text = ROLEID;
            _getdropGlevel();
            _getAccountgroup_Fundamentals();


        }
    }

    private void _getAccountgroup_Fundamentals()
    {
        _role._GroupID = txtgroupid.Text;
        string _active = "";
        string _holiday = "";
        try
        {
            DataTable dt = _role._getAccountGroup_Fundamentals();
            txtname.Text = dt.Rows[0]["GName"].ToString();
            txtDescription.Text = dt.Rows[0]["GDesc"].ToString();
            dgrouplevel.SelectedValue = dt.Rows[0]["GLevel"].ToString();
            _active = dt.Rows[0]["GStatus"].ToString();
            _holiday = dt.Rows[0]["HolidayAllow"].ToString();
            if (_active == "A")
            {
                chkactive.Checked = true;
            }
            if (_holiday == "1")
            {
                Chkholiday.Checked = true;
            }
            

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
    private bool _AccountGroup_Delete()
    {
        _role._GroupID = txtgroupid.Text;
        _role._userid = Session["USER_NAME"].ToString();
        _role._RemoteAddr = _getlocalIP();
        bool _getaccountgroup_add =  _role._AccountGroup_Delete();
        if (_getaccountgroup_add == false)
        {   
            ShowMessage("Please contacted with Administrator", MessageType.Error);
        }
        else
        {
            ShowMessage("Delete Role is successfully..!", MessageType.Success);
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
        _AccountGroup_Delete();
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