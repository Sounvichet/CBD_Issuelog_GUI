using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
public partial class FC_new : System.Web.UI.Page
{
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
    }

    private void _getADD_FC_INFO()

    {
        try
        {
            _FC._FC_ID_AUTO = T_ID_CARD.Text;
            _FC._FC_NAME = T_FC_NAME_USD.Text;
            _FC._FC_SEX = T_FC_SEX_USD.Text;
            _FC._FC_POSITION = T_FC_POSITION_USD.Text;
            _FC._FC_INST = T_FC_INST_USD.Text;
            _FC._FC_PHONE = T_FC_phone.Text;

            _FC._FC_NAME_KH = T_FC_NAME_KHR.Text;
            _FC._FC_SEX_KH = T_FC_SEX_KHR.Text;
            _FC._FC_POSITION_KH = T_FC_POSITION_KHR.Text;
            _FC._FC_INST_KH = T_FC_INST_KHR.Text;

            _FC._getADDFC_Info();

            if (_FC._get_retval == 1)
            {
                ShowMessage("registerd is successful!", MessageType.Success);
                linkbtnsave.Enabled = false; 
            }
            else
            {
                ShowMessage("registerd is fail", MessageType.Error);
            }
            
        }

        catch
        {
            ShowMessage("registerd is fail please try again!", MessageType.Error);
        }
       
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void Linkbtnrefresh_Click(object sender, EventArgs e)
    {
        Response.Redirect(Request.RawUrl);
    }

    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }

    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        _getADD_FC_INFO();
    }
}