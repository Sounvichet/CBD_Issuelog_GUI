using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class CUSTOMERS_print : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    CustomerDashboard _cus = new CustomerDashboard();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            string _getcustomerID = Request.QueryString["CUSTOMERID"].ToString();
            _getcustomerphoto(_getcustomerID);
            _GetCustFundamentals();
            _getCustSchedulelist();
         //   _GetCustFundamentals();
         //   grid_load();
         //   Label4.Text = grid1.Rows.Count.ToString();
        }
    }
    private void _getcustomerphoto(string cusphoto)
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
    private void _GetCustFundamentals()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        try
        {
            DataTable dt = _cus._getCustomerFundamentals();
            lblcustomerID.Text = dt.Rows[0]["CustomerID"].ToString();
            lblcustomername.Text = dt.Rows[0]["NameKhmer"].ToString();
            lblphone.Text = dt.Rows[0]["Phone"].ToString();
            lblServicePKG.Text = dt.Rows[0]["ServicePKG"].ToString();
            lblstatus.Text = dt.Rows[0]["Status"].ToString();
            lblService_num.Text = dt.Rows[0]["Service_num"].ToString();
            lblcycle.Text = dt.Rows[0]["CycleID"].ToString();
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
    private void _getCustSchedulelist()
    {
        _cus._customerID = Request.QueryString["CUSTOMERID"].ToString();
        _grid._GridviewBinding(gridschedule, _cus._getCustomerSchedulelist());
    }
}