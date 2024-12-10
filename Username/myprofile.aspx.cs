using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
public partial class myprofile : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    dbcon obj1 = new dbcon();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    Employee_Info _employee = new Employee_Info();
    GridViewValues _grid = new GridViewValues();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["user_name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string date = DateTime.Now.ToString("dd/MMM/yyyy");
        DateTime getdate = Convert.ToDateTime(date);
        string _getyear = getdate.Year.ToString();
        if (!this.IsPostBack)
        {
            ShowEmpImage();
            _getEmployinfo();
            //_getempsalary_list(lblEmployeeCode.Text);
            //_getempLeave_listbyEmp(lblEmployeeCode.Text, _getyear);
            //_getempfamily_listbyEmp(lblEmployeeCode.Text);
            //_getempcontact(lblEmployeeCode.Text);
            //_getempacademic(lblEmployeeCode.Text);
            //_getinernaltraining(lblEmployeeCode.Text);
            //_getempdocument(lblEmployeeCode.Text);
        }
    }
    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx");
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
    }
    public void _getEmployinfo()
    {
        _employee._EmpID = Session["USERID"].ToString();
        try
        {
            DataTable dt = _employee._getEmplyee_Info();
            lblBranch.Text = dt.Rows[0]["BranchName"].ToString();
            lblSidCard.Text = dt.Rows[0]["EmployeeId"].ToString();
            lblEmployeeName.Text = dt.Rows[0]["FullName"].ToString();
            lblPhone.Text = dt.Rows[0]["Phone"].ToString();
            lblEmail.Text = dt.Rows[0]["email"].ToString();
            lblempstatus.Text = dt.Rows[0]["EmpStaus"].ToString();
            lbljobtitle.Text  = dt.Rows[0]["JobTitle"].ToString();
        }
        catch (Exception ex)
        {
            //string _getmsg = _employee._message;

            //Response.Write("<script>alert('Hello"+ _employee._message +"')</script>");
        }
       


    }
    public void ShowEmpImage()
    {
        try
        {
            string StaffID = (Session["USERID"].ToString());
            _sqlcmd._command_Stored("P_setupImage", ref cmd);
            cmd.Parameters.AddWithValue("@EmployeeID", StaffID);
            byte[] bytes = (byte[])cmd.ExecuteScalar();
            if (bytes != null)
            {
                string strbase64 = Convert.ToBase64String(bytes);
                imageprofile.ImageUrl = "data:image/png;base64," + strbase64;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _logger._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }

    }
    protected void btncancel_Click1(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx");
    }


    protected void LinkAction_Click(object sender, EventArgs e)
    {
        gettitlescreen.InnerText = "upload Image Employee";
        string id = lblSidCard.Text;
        System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
        frm2.Attributes["src"] = "~/Username/image_upload.aspx?SIDCARD=" + id.ToString();
    }
}