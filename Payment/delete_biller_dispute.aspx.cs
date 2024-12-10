using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MasterReportClass;

public partial class Payment_delete_biller_dispute : System.Web.UI.Page
{
    string idedit;
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    dbcon obj1 = new dbcon();
    biller_Dashboard _biller = new biller_Dashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["original_ref"].ToString();
        if (!IsPostBack)
        {
            BindTextBoxvalues();
        }
    }
    private void BindTextBoxvalues()
    {
        try
        {
            _biller.P_TICKET = idedit;
            DataTable dt = _biller._get_biller_pending_fundamental() ;
            Problem_ID.Text = dt.Rows[0][3].ToString();
            Branch_name.Text = dt.Rows[0][1].ToString();
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

    private bool _delete_biller_disputed()
    {
        _biller.P_TICKET = Problem_ID.Text;
        bool retval = _biller._Delete_biller_dispute();

        if (retval == true)
        {
            ShowMessage("Delete Successfully ..!", MessageType.Success);
            Linkbtndelete.Enabled = false;
        }
        else
        {
            ShowMessage("Delete Fail please try again..!", MessageType.Error);
            
        }
        return retval;
    }

    protected void Btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Payment/biller_disp_index.aspx");
    }

    protected void Btndelete_Click(object sender, EventArgs e)
    {
        _delete_biller_disputed();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}