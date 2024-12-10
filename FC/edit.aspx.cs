using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class FC_edit : System.Web.UI.Page
{
    string idedit;
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    FCDashboard _FC = new FCDashboard();
    DropDownListValues _drop = new DropDownListValues();
    public enum MessageType { Success, Error, Info, Warning };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["ID_CARD"].ToString();
        if (!IsPostBack)
        {
            L_ID_CARD.Text = idedit;
            BindTextBoxvalues();
        }
    }
    public void BindTextBoxvalues()
    {
        try
        {
            _FC._FC_ID_AUTO = Request.QueryString["ID_CARD"].ToString();
            DataTable dt = _FC.D_get_FC_Fundamental();

            L_ID_CARD.Text = dt.Rows[0]["ID_CARD"].ToString();
            T_NAME_ENG.Text = dt.Rows[0]["NAME_ENG"].ToString();
            T_SEX_ENG.Text = dt.Rows[0]["SEX_ENG"].ToString();
            T_POSITION_ENG.Text = dt.Rows[0]["POSITION_ENG"].ToString();
            T_INST.Text = dt.Rows[0]["INSTITUTION_ENG"].ToString();
            T_PHONE_CONTACT.Text = dt.Rows[0]["PHONE_NUMBER"].ToString();

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

    private bool _Update_FC_Info()
    {
        string _getmsg = "";
        _getmsg = _FC._message;
        _FC._FC_ID_AUTO = Request.QueryString["ID_CARD"].ToString();
        _FC._FC_POSITION = T_POSITION_ENG.Text;
        _FC._FC_NAME = T_NAME_ENG.Text;
        _FC._FC_PHONE = T_PHONE_CONTACT.Text;
        _FC._FC_U_ID_AUTO = L_ID_CARD.Text;
        bool _Update_FC = _FC._getupdateFC_Info();
        if (_Update_FC = false)
        {
            ShowMessage(_getmsg, MessageType.Error);
        }
        else
        {
            ShowMessage("Update FC info successful..!", MessageType.Success);
        }
        return _Update_FC;
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FC/index.aspx");
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        Linkbtnsave.Enabled = true;
        T_NAME_ENG.Enabled = true;
        T_POSITION_ENG.Enabled = true;
        T_PHONE_CONTACT.Enabled = true;
        L_ID_CARD.Enabled = true;
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        _Update_FC_Info();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}