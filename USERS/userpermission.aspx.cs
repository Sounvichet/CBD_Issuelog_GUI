using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;


public partial class USERS_userpermission : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    UserFundamentals _userfund = new UserFundamentals();
    BranchDashboard _branch = new BranchDashboard();
    string userid = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
          //  ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!this.IsPostBack)
        {
            _getLanguage();
            _getBranchDDL();
            _getgroupDDL();
            _userFundamentals();
            _getusergroupname();


        }
    }
    private void _getBranchDDL()
    {
        _drop.bindDropDownList(d_Branch, _branch._GETBRANCHDDL());
    }
    private void _getgroupDDL()
    {
        _drop.bindDropDownList(d_membergroup, _userfund._get_groupNameDDL());
    }
    private void _getLanguage()
    {
        _drop.bindDropDownList(d_language, _userfund._get_Languagetype());
    }
    private void _userFundamentals()
    {
        userid = Request.QueryString["userid"].ToString();
        DataTable dt = _userfund._Account_Fundamentals(userid);
        t_loginacc.Text = dt.Rows[0]["USERID"].ToString();
        t_password_algr.Text = dt.Rows[0]["PwAlgorithm"].ToString();
        t_firstName.Text = dt.Rows[0]["UFName"].ToString();
        t_lastName.Text = dt.Rows[0]["ULName"].ToString();
        t_NickName.Text = dt.Rows[0]["USLName"].ToString();
        t_email.Text = dt.Rows[0]["Email"].ToString();
        t_desc.Text = dt.Rows[0]["UDesc"].ToString();
        d_membergroup.SelectedValue = dt.Rows[0]["Groupid"].ToString();
        d_Branch.SelectedValue = dt.Rows[0]["Branchid"].ToString();
        string _getlanguage = dt.Rows[0]["LanName"].ToString();
        if (_getlanguage == "English")
        {
            d_language.SelectedValue = "001";
        }
        else
        {
            d_language.SelectedValue = "000";
        }
        
        t_assigned.Text = dt.Rows[0]["UpdatedBy"].ToString();
        t_jobtitle.Text = dt.Rows[0]["JobTitle"].ToString();
    }
    private void _getusergroupname()
    {
        _userfund._userid = Request.QueryString["userid"].ToString();
        DataTable dt = _userfund._get_UserGroupName();
        foreach (DataRow dt1 in dt.Rows)
        {
            t_assignedGroup.Text += dt1.Field<string>("GName");
            t_assignedGroup.Text += Environment.NewLine;

        }
        
    }
    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
    protected void btngroup_Click(object sender, EventArgs e)
    {

                 GetTitlescreen.InnerText = "Add UserGroup";
                string _getuser = Request.QueryString["userid"].ToString();
                     System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
                frm2.Attributes["src"] = "~/USERS/getusergroupid.aspx?getuserid=" + _getuser;
                frm2.Attributes.Add("style", "width:100%;height:400px;");

    }
}