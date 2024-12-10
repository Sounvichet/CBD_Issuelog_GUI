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

public partial class CUSTOMERS_customerpayment : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    CustomerDashboard _cus = new CustomerDashboard();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    InvoiceDashboard _invoice = new InvoiceDashboard();
    EntriesDashboard _ent = new EntriesDashboard();
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
            _getserviceno();
            _getpaymentlistbycust();
            _getServiceoutstanding();
            txttrndate.Text = getdate;
            _getCashtype();
            Label4.Text = gridschedule.Rows.Count.ToString();
            
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
            txtBranchid.Text = dt.Rows[0]["BranchID"].ToString();
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
    private void _getServiceoutstanding()
    {
        _cus._Service_no = D_Service_no.SelectedValue;
        try
        {
            DataTable dt = _cus._getCustServicePKGOutstanding();
            lblSerOustanding.Text = dt.Rows[0]["Outstanding"].ToString();
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
    private void _getpaymentlistbycust()
    {
        _invoice._CustomerID = lblcustomerID.Text;
        _grid._GridviewBinding(gridschedule, _invoice._getPaymentListbyCust());
    }
    private void _getserviceno()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        _drop.bindDropDownList_String(D_Service_no, _cus._PR_GetServiceIDbyCustDDL());
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
    private void _getCashtype()

    {
        _drop.bindDropDownList_String(d_Cash_type, _invoice._GetCashTypeDDL());
    }
    private bool _GETReceiveAMT()
    {
        
        _invoice._CustomerID = lblcustomerID.Text;
        _invoice._ServiceID = D_Service_no.SelectedValue;
        _invoice._Outstanding = Convert.ToDecimal(lblOutstanding.Text);
        _invoice._ReceiveAmt = Convert.ToDecimal(txtrecevicedamt.Text);
        _invoice._seroutstanding = Convert.ToDecimal(lblSerOustanding.Text);
        _invoice._trn_date = txttrndate.Text;
        _invoice._BranchID = Session["BRANCHCODE"].ToString();
        _invoice._USERID = Session["USER_NAME"].ToString();
        _invoice._Remoteaddr = _getlocalIP();
        _invoice._Cashtype = d_Cash_type.SelectedValue;
        bool _getreceviveAmt = _invoice._GETReceiveAMTE_ADD();
        if (_getreceviveAmt == false)
        {
            ShowMessage(_invoice._message, MessageType.Error);
        }
        else
        {
            _invoice._getending_bal = _invoice._Outstanding - _invoice._ReceiveAmt;
                bool _ending_bal = _invoice._ENDING_BAL_UPDATE();
                if (_ending_bal == false)

                {
                    ShowMessage(_invoice._message, MessageType.Error);
                }
                else
                {
                _invoice._getSERPKGending_bal = _invoice._seroutstanding - _invoice._ReceiveAmt;
                bool SERPKG_bal = _invoice._SERPKG_BAL_UPDATE();
                    if (SERPKG_bal == false)
                    {
                        ShowMessage(_invoice._message, MessageType.Error);
                    }
                    else
                    {

                    _ent._CUS_branch = txtBranchid.Text;
                    _ent._CustomerID = lblcustomerID.Text;
                    _ent._ServiceID = D_Service_no.SelectedValue;
                    _ent._ReceiveAmt = Convert.ToDecimal(txtrecevicedamt.Text);
                    _ent._BranchiD = Session["BRANCHCODE"].ToString();
                    _ent._userID = Session["USER_NAME"].ToString();
                    bool entries_paid = _ent._CUSSERICE_ENTRIES_PAID();
                    if (entries_paid == false)
                    {
                        ShowMessage(_ent._message, MessageType.Error);
                    }
                    else
                    {
                        ShowMessage("Payment Registration Successfully : " + _invoice._getInvoice + "", MessageType.Success);
                    }

                    return entries_paid;
                    }
                    return SERPKG_bal;
                    }
                 return _ending_bal;
        }
        return _getreceviveAmt;
    }
    protected void LinkAction_Click(object sender, EventArgs e)
    {
        decimal _outstanding = Convert.ToDecimal(lblOutstanding.Text);
        decimal seroustanding = Convert.ToDecimal(lblSerOustanding.Text);
        decimal receive;
        if (decimal.TryParse(txtrecevicedamt.Text, out receive))
        {
            if (receive > 0 && receive <= _outstanding && receive <= seroustanding)
            {
                _GETReceiveAMT();
            }
            if (receive > _outstanding)
            {
                ShowMessage("Please check Received Amount should be less then Oustanding Amount!!", MessageType.Error);
            }
            if (receive > seroustanding)
            {
                ShowMessage("Please check Received Amount should be less then Service Oustanding Amount!!", MessageType.Error);
            }
            else if (receive == 0)
            {
                ShowMessage("Please check Received Amount Again Cannot O values or null", MessageType.Warning);
            }
           
        }
        else
        {
            ShowMessage("Your inputed is not correct please try again!!", MessageType.Error);
        }



        //decimal Received = Convert.ToDecimal(txtrecevicedamt.Text);

       
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
    protected void D_Service_no_SelectedIndexChanged(object sender, EventArgs e)
    {
        _getServiceoutstanding();
    }
}