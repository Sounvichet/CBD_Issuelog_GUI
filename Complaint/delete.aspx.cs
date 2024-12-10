using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Complaint_delete : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    ComplaintDashBoard _complaint = new ComplaintDashBoard();
    string idedit;
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["ticket_no"].ToString();
        if (!this.IsPostBack)
        {
            BindTextBoxvalues();
        }
    }
    private void BindTextBoxvalues()
    {
        try
        {
            DataTable dt = _complaint._get_DeleteFundamentals(idedit);
            Problem_ID.Text = dt.Rows[0][0].ToString();
            t_Branch_name.Text = dt.Rows[0][1].ToString();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
        }
    }
    public bool _Update_ticket()
    {
        bool retval = _complaint._Delete_ticket(idedit);
        if (retval == false)
        {
            ShowMessage("Update record!", MessageType.Error);
            //Response.Write("<script>alert('" + _incident._message + "')</script>");
        }
        else
        {
            ShowMessage("Update record!", MessageType.Success);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "alert", "alert('');", true);
            //ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "window.location='" + Request.ApplicationPath + "Ticket/index.aspx';", true);
            // Response.Redirect("~/ticket/index.aspx");
        }
        return retval;
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Complaint/index.aspx");
    }
    protected void Btndelete_Click(object sender, EventArgs e)
    {
        _Update_ticket();
        Linkbtnsave.Enabled = false;
    }
}