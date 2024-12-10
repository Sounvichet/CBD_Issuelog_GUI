using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class CUSTOMERS_getcustserviceimage : System.Web.UI.Page
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
        string getserviceimg = Request.QueryString["ID"].ToString();
        if (!IsPostBack)
        {
            _getcustomerphoto(getserviceimg);
        }
    }
    public void _getcustomerphoto(string cusphoto)
    {
        try
        {

            _sqlcom._command_Stored("PR_GetCustServiceimage", ref cmd);
            cmd.Parameters.AddWithValue("@id", cusphoto);
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
}