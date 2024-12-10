using System;
using System.Web.UI;
using System.Data;
using System.Data.SqlClient;
using TicketClassLibrary;
using System.Net;
using System.Web.UI.WebControls;
using UserADClass; 

public partial class login : System.Web.UI.Page
{
    SqlCommand cmd;
    string role_name;
    string outputvalues;
    string name;
    string acc_type;
    //logger _log = new logger();
    //SqlConnection sqlc = new SqlConnection();
    //SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    //UserFundamentals _userfund = new UserFundamentals();
    //USERAD _userAD = new USERAD();
    //UserDashboard _user = new UserDashboard();
    UserADDashboard _uad = new UserADDashboard();
    string _IP = "";
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {   
        if (!Page.IsPostBack)
        {
            Session.Abandon();
        }
    }
    //private bool _account_logout()
    //{
    //    _user._UserID = Session["user_name"].ToString();
    //    _user._Remoteaddr = _getlocalIP();
    //    bool getlog_out = _user._Account_Logout();
    //    if (getlog_out == false)
    //    {
    //        Response.Write(@"<script language='javascript'>alert('Please contact admin for logout !!')</script>");
    //    }

    //    else
    //    {
    //        Response.Redirect("default.aspx");
    //    }
    //    return getlog_out;
    //}
    //private void login_exec(string user_name, string pass )

    //{
    //    string userPass = string.Empty;
    //    string errMsg = string.Empty;
    //    string errstack = string.Empty;
       
    //    //int retval = 0;
    //    try
    //    {

    //        //System.Web.HttpContext context = System.Web.HttpContext.Current;
    //        //string ipAddress = context.Request.ServerVariables["REMOTE_ADDR"];
    //        _IP = _getlocalIP();
    //        _sqlcmd._command_Stored("Account_login", ref cmd);
    //        cmd.Parameters.AddWithValue("@USERID", user_name);
    //        cmd.Parameters.AddWithValue("@Password", pass);
    //        cmd.Parameters.AddWithValue("@Remoteaddr", _IP);
    //        cmd.Parameters.Add("@retval", SqlDbType.Int,8).Direction = ParameterDirection.Output;
    //        cmd.ExecuteNonQuery();
    //        int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0

    //        if (retval == 1)
    //        {
    //            _UserAD_fundamentals(user_name);
    //            Response.Redirect("~/apptop.aspx");
    //        }  
    //    }
    //    catch (Exception ex)
    //    {
    //        _log.LogError(ex);
    //        errMsg = ex.Message;
    //        ShowMessage(errMsg, MessageType.Error);
    //        //Response.Write(@"<script language='javascript'>alert('" + errMsg + " !!')</script>");
    //    }
    //    finally
    //    {
    //        sqlc.Close();
    //        cmd.Connection.Close();
    //        sqlc.Dispose();
    //        SqlConnection.ClearPool(sqlc);   
    //    }
    //}
    //private void binddata(string user_name)
    //{
    //    DataTable dt = _userfund._Account_Fundamentals(user_name);
    //    Session["USER_NAME"] = dt.Rows[0]["USERID"].ToString();
    //    Session["role_name"] = dt.Rows[0]["UGroupID"].ToString();
    //    Session["ID_staff"] = dt.Rows[0]["Employeeid"].ToString();
    //    //Session["Position"] = dt.Rows[0]["Position"].ToString();
    //    Session["Email"] = dt.Rows[0]["Email"].ToString();
    //    Session["FullName"] = dt.Rows[0]["FullName"].ToString();
    //    Session["office"] = dt.Rows[0]["Branchname"].ToString();
    //    Session["BRANCHCODE"] = dt.Rows[0]["BRANCHID"].ToString();
    //    Session["COMPANY"] = dt.Rows[0]["COMPANYID"].ToString();
    //    Session["JOBID"] = dt.Rows[0]["JobtitleID"].ToString();
    //    Session["JOBDEC"] = dt.Rows[0]["JobTitle"].ToString();
    //}
    private void _UserAD_fundamentals(string _userAD)
    {
        DataTable dt = _uad._UserAD_Fundamentals(_userAD);

        if (dt.Rows.Count == 0)
        {
           ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + _uad._msgerror + "\");", true);
        }
        else
        {
            Session["USER_NAME"] = dt.Rows[0]["UserID"].ToString();//dt.Rows[0]["Employeeid"].ToString();
            Session["FamilyName"] = dt.Rows[0]["FullName"].ToString();
            Session["role_name"] = "";
            Session["JobTitle"] = dt.Rows[0]["JobTitle"].ToString();
            //Session["ID_staff"] = dt.Rows[0]["Employeeid"].ToString();
            //Session["Email"] = dt.Rows[0]["Email"].ToString();
            Session["FullName"] = dt.Rows[0]["FullName"].ToString();
            Session["office"] = dt.Rows[0]["Branchname"].ToString();
            Session["BRANCHCODE"] = dt.Rows[0]["BRANCHID"].ToString();
          //  Session["OfficeRange"] = dt.Rows[0]["OfficeRange"].ToString();
            Session["deptID"] = dt.Rows[0]["deptID"].ToString();
            Session["BranchID"] = dt.Rows[0]["BranchID"].ToString();
            Session["USERID"] = dt.Rows[0]["USERAD"].ToString();
            Session["COMPANY"] = dt.Rows[0]["COMPANYID"].ToString();
        }
    }
    public string GetUserIP()
    {
        string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

        if (!string.IsNullOrEmpty(ipList))
        {
            return ipList.Split(',')[0];
        }

        return Request.ServerVariables["REMOTE_ADDR"];
    }
    private bool _UserloginAD(string _userID , string _password)
    {
        
            bool retval = _uad._userloginAD(_userID, _password);

            if (retval == false)
            {
            bool getsecond = _uad._userloginAD_second(_userID, _password);
            if (getsecond == false)
            {
             ShowMessage("User and password loged in fail..!", MessageType.Error); 
            }
            else
            {
             _UserAD_fundamentals(_userID);
             Response.Redirect("~/apptop.aspx");
            }
            return getsecond;
            }
            else
            {
                _UserAD_fundamentals(_userID);
                Response.Redirect("~/apptop.aspx");
        }
        return retval;
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        var AlertBox = "ShowMessage('" + Message + "','" + type + "')";
        Page.ClientScript.RegisterStartupScript(this.GetType(), "CallMyFunction", AlertBox, true);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        _UserloginAD(TextBox1.Text, TextBox2.Text);
    }
}


