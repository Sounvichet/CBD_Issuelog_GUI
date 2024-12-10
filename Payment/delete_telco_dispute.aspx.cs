using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using MasterReportClass;

public partial class Payment_delete_telco_dispute : System.Web.UI.Page
{
    string idedit;
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    dbcon obj1 = new dbcon();
    Telco_Dashboard _telco = new Telco_Dashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["HTB_EX_REF"].ToString();
        if (!IsPostBack)
        {
            ticket_id.Text = idedit; 
            BindTextBoxvalues();
        }
    }
    private void BindTextBoxvalues()
    {
        try
        {
            _telco.P_TICKET = idedit;
            DataTable dt = _telco._get_telco_ticket_fundamental();
            Branch_name.Text = dt.Rows[0][0].ToString();
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

    private bool _deletetelco_ticket()
    {
        _telco.P_TICKET = ticket_id.Text;
        bool retval = _telco._Delete_telco_dispute(); 

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
        Response.Redirect("~/Payment/TELCO_disp_index.aspx");
    }

    protected void Btndelete_Click(object sender, EventArgs e)
    {
        _deletetelco_ticket();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}