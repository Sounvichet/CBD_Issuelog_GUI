using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Net;

public partial class CUSTOMERS_edit : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    CustomerDashboard _CUS = new CustomerDashboard();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!this.IsPostBack)
        {
            string _customerid = Request.QueryString["CUSTOMERID"].ToString();
            l_customerid.Text = _customerid;
            _customerFundamentals();
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

    private void _customerFundamentals()
    {
        _CUS._customerID = l_customerid.Text;
        DataTable dt = _CUS._getCustomerFundamentals();
        l_branchID.Text = dt.Rows[0]["BranchID"].ToString();
        t_fullname.Text = dt.Rows[0]["NameKhmer"].ToString();
        t_email.Text = dt.Rows[0]["Email"].ToString();
        T_FName.Text = dt.Rows[0]["Fname"].ToString();
        T_Lname.Text = dt.Rows[0]["Lname"].ToString();
        l_cycle.Text = dt.Rows[0]["CycleID"].ToString();
        l_standing.Text = dt.Rows[0]["outstanding"].ToString();
        T_phone.Text = dt.Rows[0]["Phone"].ToString();
        T_house.Text = dt.Rows[0]["House"].ToString();
        T_street.Text = dt.Rows[0]["Street"].ToString();
        T_village.Text = dt.Rows[0]["Village"].ToString();
        T_Commune.Text = dt.Rows[0]["Commune"].ToString();
        T_District.Text = dt.Rows[0]["District"].ToString();
        T_Province.Text = dt.Rows[0]["Province"].ToString();
        T_DOB.Text   = dt.Rows[0]["DOB"].ToString();
    }

    private bool _getCustomer_Edit()

    {
        _CUS._customerID = l_customerid.Text;
        _CUS._NameKhmer = t_fullname.Text;
        _CUS._Fname = T_FName.Text;
        _CUS._Lname = T_Lname.Text;
        _CUS._DOB = T_DOB.Text;
        _CUS._Phone = T_phone.Text;
        _CUS._Email = t_email.Text;
        _CUS._House = T_house.Text;
        _CUS._Street = T_street.Text;
        _CUS._Village = T_village.Text;
        _CUS._Commune = T_Commune.Text;
        _CUS._District = T_District.Text;
        _CUS._Province = T_Province.Text;
        _CUS._UpdatedBy = Session["USER_NAME"].ToString();
        _CUS._UpdatedFrom = _getlocalIP();
        bool customerEdit = _CUS._CUSTOMER_EDIT();
        if (customerEdit == false)
        {
            ShowMessage("Customer update is fail please contact admin", MessageType.Error);
        }
        else
        {
            ShowMessage("Customer Update is successful with customer ID "+ _CUS._customerID + "", MessageType.Success);
        }
        return customerEdit;
    }
    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        _getCustomer_Edit();
    }
    protected void Linkbtnrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx");
    }
    protected void linkedit_Click(object sender, EventArgs e)
    {
        linkbtnsave.Enabled = true;
        t_fullname.Enabled = true;
        t_email.Enabled = true;
        T_FName.Enabled = true;
        T_Lname.Enabled = true;
        T_phone.Enabled = true;
        T_house.Enabled = true;
        T_street.Enabled = true;
        T_village.Enabled = true;
        T_Commune.Enabled = true;
        T_District.Enabled = true;
        T_Province.Enabled = true;
        T_DOB.Enabled = true;
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}