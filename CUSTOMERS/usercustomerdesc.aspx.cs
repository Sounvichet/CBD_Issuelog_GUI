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
public partial class CUSTOMERS_usercustomerdesc : System.Web.UI.Page
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
            _getmaxcustdesc();
            _getcustdesclist();
            Label4.Text = grid1.Rows.Count.ToString();
            
        }
    }

    private void _getmaxcustdesc()

    {
        _CUS._customerID = Request.QueryString["CUSTOMERID"].ToString();
        DataTable dt = _CUS._getmaxcustdesc();
        if (dt.Rows.Count == 0)
        {
            t_desc.Text = "";
        }
        else
        {
            t_desc.Text = dt.Rows[0]["Description"].ToString();
        }
        

    }

    private void _getcustdesclist()
    {
        _CUS._customerID = Request.QueryString["CUSTOMERID"].ToString();
        _grid._GridviewBinding(grid1, _CUS._getdescbycust());
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
    private bool _getcustdesc()
    {
        _CUS._customerID = Request.QueryString["CUSTOMERID"].ToString();
        _CUS._CUSTDESC = t_desc.Text;
        _CUS._CreatedBy = Session["USER_NAME"].ToString();
        _CUS._CreatedFrom = _getlocalIP();
        bool _custdesc = _CUS._USERCUSTDESC_ADD();
        if (_custdesc == false)
        {
            ShowMessage("Add customer desc is fail please contact admin", MessageType.Error);
        }
        else
        {
            ShowMessage("Add customer desc is successfull", MessageType.Success);
        }
        return _custdesc;
    }


    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        _getcustdesc();
    }

    protected void Linkbtnrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}