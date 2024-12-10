using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using System.Drawing;
public partial class CUSTOMERS_customerAction : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    CustomerDashboard _cus = new CustomerDashboard();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string currentdate1 = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        if (!IsPostBack)
        {
            string _getcustomerID = Request.QueryString["CUSTOMERID"].ToString();
            _GetCustFundamentals();
            _getServiceIDbyCust();
            _getCusServiceCycle();
            _getCyclscheduleID();

            _getBranchID();
            _getEmpUI();
            _getservicePkgshcedule();
            _getCustSchedulelist();
            txtrndate.Text = currentdate1;
            D_branch.SelectedValue = Session["BRANCHCODE"].ToString();
            _getBranchDDL();
        }
    }

    private void _getBranchDDL()
    {
        string getposition = Session["JOBID"].ToString();

        if (getposition == "")
        {
            D_branch.Enabled = true;
        }

        else
        {
            D_branch.Enabled = false;
        }
    }
    private void _GetCustFundamentals()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        try
        {
            DataTable dt = _cus._getCustomerFundamentals();
            lblcustomerID.Text = dt.Rows[0]["CustomerID"].ToString();
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
    private void _getServiceIDbyCust()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        _drop.bindDropDownList_String(d_service_no, _cus._PR_GetServiceIDbyCustDDL());
    }
    private void _getCusServiceCycle()
    {
        try
        {
            _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
            _cus._Service_no = d_service_no.SelectedValue;
            DataTable dt = _cus._getCusServiceCycle();

            lblcycle.Text = dt.Rows[0]["cycleID"].ToString();
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
    private void _getCyclscheduleID()

    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        _cus._Service_no = d_service_no.SelectedValue;
        _cus._cyleid = lblcycle.Text;
        _drop.bindDropDownList_String(d_cyschedule, _cus._getCustomerScheduleCycle());
    }
    private void _getCustSchedulelist()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        _grid._GridviewBinding(gridschedule, _cus._getCustomerSchedulelist());
    }
    private void _getservicePkgshcedule()
    {
        try
        {
            _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
            _cus._Service_no = d_service_no.SelectedValue;
            _cus._cyleid = lblcycle.Text;
            _cus._schedule_no = Convert.ToInt32(d_cyschedule.SelectedValue);

            _getServicePKGDDL();
            _getServiceDDL();
            DataTable dt = _cus.__GetServicePkgbyschedule();
            D_ServicePKG.SelectedValue  = dt.Rows[0]["PackageID"].ToString();
            d_product.SelectedValue = dt.Rows[0]["ServiceID"].ToString();

        } 
        catch (Exception ex)
        { _logger.LogError(ex); }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    private void _getServicePKGDDL ()

    {
        _drop.bindDropDownList_String(D_ServicePKG, _cus._getGetServicePackageDDL());
    }
    private void _getServiceDDL()
    {
        _drop.bindDropDownList_String(d_product, _cus._getGetServiceDDL());
    }
    private bool _customersheduleupdate()
    {
        _cus._customerID = lblcustomerID.Text;
        _cus._Service_no = d_service_no.SelectedValue;
        _cus._cyleid = lblcycle.Text;
        _cus._schedule_no = Convert.ToInt32(d_cyschedule.SelectedValue);
        _cus._UserID = Session["USER_NAME"].ToString();
        _cus._checkerid = D_employee.SelectedValue;
        _cus._BranchID = D_branch.SelectedValue;
        _cus._trn_date = txtrndate.Text;
        _cus._RemoteAddr = _getlocalIP();

        bool _getshedule = _cus._customer_scheduleUpdate();
        {
            if (_getshedule == false)
            {
                ShowMessage("Please try again..", MessageType.Error);
            }
            else
            {

                DataTable dtrow = _cus._Getrowschedulepending();
                int getrow = dtrow.Rows.Count;
                if (getrow == 0)
                {
                    bool statusupdate = _cus._CusServiceUpdate();
                    if (statusupdate == false)
                    {
                        ShowMessage("Please try service update again..", MessageType.Error);
                    }
                    else
                    {
                        ShowMessage("Update Service Status Successfully with cycle schedule " + d_cyschedule.SelectedValue.ToString() + "", MessageType.Success);
                        
                    }
                }
                else

                {
                    ShowMessage("Update Successfully with cycle schedule " + d_cyschedule.SelectedValue.ToString() + "", MessageType.Success);
                }

            }
            return _getshedule;
        }
    }

    private void _getBranchID()
    {
        _drop.bindDropDownList_String(D_branch, _cus._getBranchID());
    }
    private void _getEmpUI()
    {
        _cus._BranchID = D_branch.SelectedValue;
        _drop.bindDropDownList_String(D_employee, _cus._getEmpUI());
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
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void d_cyschedule_SelectedIndexChanged(object sender, EventArgs e)
    {
        _getservicePkgshcedule();
    }

    protected void LinkAction_Click(object sender, EventArgs e)
    {
        _customersheduleupdate();
    }


    protected void D_branch_SelectedIndexChanged(object sender, EventArgs e)
    {
        _getEmpUI();
    }

    protected void gridschedule_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        for (int i = 0; i < e.Row.Cells.Count; i++)
        {
            e.Row.Cells[i].Attributes.Add("style", "white-space: nowrap;");
        }

        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string status =  (string)DataBinder.Eval(e.Row.DataItem, "Status");
            if (status == "Completed")
            {
                e.Row.BackColor = Color.FromName("#669DF2");
            }
            if (status == "Pending")
            {
                e.Row.BackColor = Color.FromName("#E3EF8A");
            }
        }
    }

    protected void Linkbtnrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void d_service_no_SelectedIndexChanged(object sender, EventArgs e)
    {
        _getCusServiceCycle();
        _getCyclscheduleID();
        _getservicePkgshcedule();
    }
}