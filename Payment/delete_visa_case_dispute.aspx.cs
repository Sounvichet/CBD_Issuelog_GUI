using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using VisaClearingClass;

public partial class Payment_delete_visa_case_dispute : System.Web.UI.Page
{
    string refnum_delete;
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    dbcon obj1 = new dbcon();
    //Dispute_DashBoard _dis = new Dispute_DashBoard();
    //Case_Disputes_Dashboard _case_dis = new Case_Disputes_Dashboard();
    CaseDisputeDashboard _case_dis = new CaseDisputeDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        refnum_delete = Request.QueryString["refnum"].ToString();
        if (!IsPostBack)
        {
            BindTextBoxvalues();
        }
    }
    private void BindTextBoxvalues()
    {
        try
        {
            _case_dis.P_REFNUM = refnum_delete;
            DataTable dt = _case_dis._get_refnum_fundamental();
            l_refnum.Text = dt.Rows[0][0].ToString();
            l_trn_amount.Text = dt.Rows[0][1].ToString();
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

    private bool _delete_visa_case_dispute()
    {
        _case_dis.P_REFNUM = l_refnum.Text;
        bool retval = _case_dis._delete_visa_case_dispute();

        if (retval == true)
        {
            ShowMessage("Delete Successfully ..!", MessageType.Success);
            Linkbtndelete.Enabled = false;
        }
        else
        {
            ShowMessage("Delete Fail : "+ _case_dis._get_message+ "", MessageType.Error);
            
        }
        return retval;
    }

    protected void Btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Payment/VISACDI.aspx");
    }

    protected void Btndelete_Click(object sender, EventArgs e)
    {
        _delete_visa_case_dispute();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}