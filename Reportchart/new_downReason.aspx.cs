using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using System.Data;

public partial class Reportchart_new_downReason : System.Web.UI.Page
{

    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    IncidentDashBoards _inc = new IncidentDashBoards();
    public enum MessageType { Success, Error, Info, Warning };
    string getgroupreasonid; 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        getgroupreasonid = Request.QueryString["ReasonGroupid"].ToString();
        l_groupid.Text = getgroupreasonid;
        l_userID.Text = Session["USERID"].ToString() ;

    }

    private bool _RegisterTicket()
    {
        _inc._ReasonGroupID = l_groupid.Text;
        _inc._ReasonShortDesc = t_reasonshortdesc.Text;
        _inc._reasonfulldesc = t_ReasonFullDesc.Text;
        _inc._userad = l_userID.Text;
        bool retval = _inc._REG_NodeDownReason();
        if (retval == false)
        {
            ShowMessage("Register ticket is fail " + _inc._message + "", MessageType.Error);
        }
        else
        {
            ShowMessage("Register new record with ticket = " + _inc._getticket + "", MessageType.Success);
            linkbtnsave.Enabled = false;
        }
        return retval;
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void link_save_Click(object sender, EventArgs e)
    {
        _RegisterTicket();
    }

    protected void link_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Reportchart/NodeDownReason.aspx");
    }
}