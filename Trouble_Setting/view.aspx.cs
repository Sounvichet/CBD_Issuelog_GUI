using System;
using System.Data;
using System.Web.UI.WebControls;
using System.IO;
using System.Data.SqlClient;

public partial class Trouble_Setting_view : System.Web.UI.Page
{
    string idedit;
    TroubleSetting _seting = new TroubleSetting();
    DropDownListValues _drop = new DropDownListValues();
    GridViewValues _grid = new GridViewValues();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["ReportCode"].ToString();
        if (!this.IsPostBack)
        {
            _trouble_Fundamentals();
            ShowEmpImage(idedit);
        }
    }
    private void _trouble_Fundamentals()
    {
        DataTable dt = _seting.D_TroubleSetting_Fundamentals(Session["USERID"].ToString(), idedit);
        ReportCode.Text = dt.Rows[0][0].ToString();
        t_issuename.Text = dt.Rows[0][1].ToString();
        t_issuedesc.Text = dt.Rows[0][2].ToString();
    }
    public void ShowEmpImage(string _reportcat)
    {
        try
        {

            _sqlcom._command_Stored("PR_TroublePhoto", ref cmd);
            cmd.Parameters.AddWithValue("@ReportCat", _reportcat);
            byte[] bytes = (byte[])cmd.ExecuteScalar();
            if (bytes != null)
            {
                string strbase64 = Convert.ToBase64String(bytes);
                Image1.ImageUrl = "data:image/png;base64," + strbase64;
            }

        }
        catch (Exception ex)
        {
            throw;
        }
        finally
        {
            sqlc.Close();
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Trouble_Setting/index.aspx");
    }
}