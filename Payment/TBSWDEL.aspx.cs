using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MasterReportClass;

public partial class Payment_TBSWDEL : System.Web.UI.Page
{
    string idedit;
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    dbcon obj1 = new dbcon();
    Dispute_DashBoard _dis = new Dispute_DashBoard();
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
            _dis.P_TICKET = idedit;
            DataTable dt = _dis._get_ticket_in_progress_fundamental() ;
            Problem_ID.Text = dt.Rows[0][0].ToString();
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

    private bool _deletemission()
    {
        _dis.P_TICKET = Problem_ID.Text;
        bool retval = _dis._delete_bill_ticket_dispute();

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
        Response.Redirect("~/Payment/TBSWDSL.aspx");
    }

    protected void Btndelete_Click(object sender, EventArgs e)
    {
        _deletemission();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}