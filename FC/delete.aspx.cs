using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;

public partial class FC_delete : System.Web.UI.Page
{
    string iddelete;
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
        iddelete = Request.QueryString["ID_CARD"].ToString();
        t_staff_ID.Text = iddelete;
        if (!IsPostBack)
        { 
           BindTextBoxvalues();
        }
    }

    public void BindTextBoxvalues()
    {
        try
        {
            _FC._FC_ID_AUTO = Request.QueryString["ID_CARD"].ToString();
            DataTable dt = _FC.D_get_FC_Fundamental();
            T_FC_Name.Text = dt.Rows[0]["NAME_ENG"].ToString();
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


    private bool _Delete_FC_Info()
    {
        string _getmsg = "";
        _getmsg = _FC._message;
        _FC._FC_ID_AUTO = Request.QueryString["ID_CARD"].ToString();
        bool _Update_FC = _FC._getDelete_FC_Info();
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

    protected void Linkbtndelete_Click(object sender, EventArgs e)
    {
        _Delete_FC_Info();
    }

    protected void LinkBtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/FC/index.aspx");
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}