using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class CUSTOMERS_view : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    CustomerDashboard _cus = new CustomerDashboard();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string _getcustID = Request.QueryString["CUSTOMERID"].ToString();

        if (!IsPostBack)
        {
            _getcustomerphoto(_getcustID);
            _GetCustFundamentals();
            grid_load();
            grid_CusServiceHis();
            grid_CuspaymentHis();
            _getmaxcustdesc();
        }    

    }

    public void _GetCustFundamentals()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString(); 
        try
        {
            DataTable dt = _cus._getCustomerFundamentals();
            txtcustomerID.InnerText = dt.Rows[0]["CustomerID"].ToString();
            Txtcustomername.InnerText = dt.Rows[0]["NameKhmer"].ToString();
            txtphone.InnerText = dt.Rows[0]["Phone"].ToString();
            txtservicePKG.InnerText = dt.Rows[0]["ServicePKG"].ToString();
            txtserviceStatus.InnerText = dt.Rows[0]["Status"].ToString();
            txtSERVICEID.InnerText = dt.Rows[0]["Service_num"].ToString();
            txtcycle.InnerText = dt.Rows[0]["CycleID"].ToString();
            txtoutstanding.InnerText = dt.Rows[0]["Outstanding"].ToString();
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
    public void _getcustomerphoto(string cusphoto)
    {
        try
        {

            _sqlcom._command_Stored("PR_CustomerPhoto", ref cmd);
            cmd.Parameters.AddWithValue("@CustomerID", cusphoto);
            byte[] bytes = (byte[])cmd.ExecuteScalar();
            if (bytes != null)
            {
                string strbase64 = Convert.ToBase64String(bytes);
                cusimage.ImageUrl = "data:image/png;base64," + strbase64;
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

    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
    protected void grid1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        Gridpayment.PageIndex = e.NewPageIndex;
        this.grid_CuspaymentHis();
        Label4.Text = Gridpayment.Rows.Count.ToString();
    }
    protected void grid_load()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        _grid._GridviewBinding(grid1, _cus._getCustomerSchedulelist());
        Label4.Text = grid1.Rows.Count.ToString();
    }

    private void grid_CusServiceHis()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        _grid._GridviewBinding(GridService, _cus._getCustServiceHIS());
        Label2.Text = GridService.Rows.Count.ToString();
    }
    private void grid_CuspaymentHis()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        _grid._GridviewBinding(Gridpayment, _cus._getCustPaymentHIS());
        Label6.Text = Gridpayment.Rows.Count.ToString();
    }

    private void _getmaxcustdesc()
    {
        _cus._customerID = txtcustomerID.InnerText;
        DataTable dt1 = _cus._getmaxcustdesc();
        if (dt1.Rows.Count == 0)
        {
            t_cust_desc.Text = "";
        }
        else
        {
            t_cust_desc.Text = dt1.Rows[0]["Description"].ToString();
        }

    }
    protected void linkView_Click(object sender, EventArgs e)
    {
        foreach (GridViewRow row in grid1.Rows)
        {
            CheckBox checkbox = (CheckBox)row.FindControl("check");
            if (checkbox.Checked)
            {
                GetTitlescreen.InnerText = "View Customer Service Image";
                string id = Convert.ToString(row.Cells[14].Text);
                System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
                frm2.Attributes["src"] = "~/CUSTOMERS/getcustserviceimage.aspx?ID=" + id.ToString();
                // Response.Redirect("~/Mission/edit.aspx?ticket_no=" + id);
            }
        }
    }

    protected void grid1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string status = (string)DataBinder.Eval(e.Row.DataItem, "Status");
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

    protected void grid1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "LinkView")
        {
            int index = Convert.ToInt32(e.CommandArgument);
            GridViewRow row = grid1.Rows[index];
            GetTitlescreen.InnerText = "View Customer Service Image";
            System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
            frm2.Attributes["src"] = "~/CUSTOMERS/getcustserviceimage.aspx?ID=" + row.Cells[14].Text;
            // Response.Redirect("~/Mission/edit.aspx?ticket_no=" + id);


        }
    }

    protected void GridService_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            string status = (string)DataBinder.Eval(e.Row.DataItem, "S_status");
            if (status == "Inactive")
            {
                e.Row.BackColor = Color.FromName("#669DF2");
            }
            if (status == "Active")
            {
                e.Row.BackColor = Color.FromName("#E3EF8A");
            }
        }
    }

    protected void Gridpayment_RowDataBound(object sender, GridViewRowEventArgs e)
    {

    }

    protected void LinkAction_Click(object sender, EventArgs e)
    {
        GetTitlescreen.InnerText = "upload Image Customer";
        string id = txtcustomerID.InnerText;
        System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
        frm2.Attributes["src"] = "~/CUSTOMERS/getcustimage.aspx?customerID=" + id.ToString();
    }

    protected void linkADD_Click(object sender, EventArgs e)
    {
        GetTitlescreen.InnerText = "User Add Customer Description";

        string id = txtcustomerID.InnerText;
        System.Web.UI.ScriptManager.RegisterStartupScript(this, typeof(object), "OpenIframe", "$(document).ready(function(){ $('#iframe-open').modal(); }); ", true);
        frm2.Attributes["src"] = "~/CUSTOMERS/usercustomerdesc.aspx?customerID=" + id.ToString();
        frm2.Attributes.Add("style", "width:100%;height:400px;");

    }
}