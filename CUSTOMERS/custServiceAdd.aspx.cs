using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using ClosedXML;
using ClosedXML.Excel;
using System.Data;
using System.Net;

public partial class CUSTOMERS_custServiceAdd : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    CustomerDashboard _cus = new CustomerDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            string _getcustomerID = Request.QueryString["CUSTOMERID"].ToString();
            string getdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            _GetCustFundamentals();
            _getproductcode();
            Label4.Text = gridschedule.Rows.Count.ToString();
            txttrndate.Text = getdate;
        }
    }

    private void _GetCustFundamentals()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        try
        {
            DataTable dt = _cus._getCustomerFundamentals();
            lblcustomerID.Text = dt.Rows[0]["CustomerID"].ToString();
            lblOutstanding.Text = dt.Rows[0]["Outstanding"].ToString();
            //lblcycle.Text = dt.Rows[0]["CycleID"].ToString();
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

    private bool _GETCUSTOMERSERVICE_ADD()
    {
        
        _cus._BranchID = Session["BRANCHCODE"].ToString();
        _cus._customerID = lblcustomerID.Text;
        _cus._ServicePKG = D_SERCPKG.SelectedValue;
        _cus._CreatedBy = Session["USER_NAME"].ToString();
        _cus._CreatedDate = txttrndate.Text;
        _cus._getPrice = Convert.ToDecimal(lblPrice.Text);
        _cus._CreatedFrom = _getlocalIP();

        bool _CUSTSERVICEADD = _cus._CUSTOMERSERVICE_ADD();
        if (_CUSTSERVICEADD == false)
        {
            ShowMessage(_cus._message, MessageType.Error);
        }
        else
        {
            _cus._AddPrice = Convert.ToDecimal(lblOutstanding.Text);
            _cus._UserID = Session["USER_NAME"].ToString();
            _cus._trn_date = txttrndate.Text;
            _cus._RemoteAddr = _getlocalIP();
            bool getcusserviceprice = _cus._CusServicePrice_UPDATE();
            if (getcusserviceprice == false)
            {
                ShowMessage(_cus._message, MessageType.Error);
            }
            else
            {
                _cus._Service_no = _cus._GetService;
                bool _getschedule = _cus._Cust_AddMoreSchedule();
                if (_getschedule == false)
                {
                    ShowMessage(_cus._message, MessageType.Error);
                }
                else
                {
                    ShowMessage("Add More service Successfully", MessageType.Success);
                }
                return _getschedule;
            }
            return getcusserviceprice;
        }
        return _CUSTSERVICEADD;
    }
    private void _getproductcode()
    {
        _drop.bindDropDownList(D_PRODUCT, _cus._getProductCode());
    }
    private void _getServicePackage()
    {
        _drop.bindDropDownList(D_SERCPKG, _cus._getGetServicePackage(D_PRODUCT.SelectedValue));
    }
    protected void D_PRODUCT_SelectedIndexChanged(object sender, EventArgs e)
    {
        _getServicePackage();
    }
    
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Linkbtnrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("transaction.aspx");
    }

    protected void LinkAdd_Click(object sender, EventArgs e)
    {
        _GETCUSTOMERSERVICE_ADD();
    }

    protected void D_SERCPKG_SelectedIndexChanged(object sender, EventArgs e)
    {
        _cus._ServicePKG = D_SERCPKG.SelectedValue;
        DataTable dt = _cus._getGetServicePackagePrice();
        lblPrice.Text = dt.Rows[0]["Price"].ToString();
    }
}