using System;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Web.UI;
using System.IO;
using System.Drawing;
using System.Data;
using System.Net;

public partial class SERVICES_new : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    ServiceDashboard _service = new ServiceDashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
    }
    private bool _SERVICE_CREATE()
    {
        string getdate = DateTime.Now.ToString("dd/MMM/yyyy HH:mm:ss").Replace('/', '-');
        _service._serviceNameK = txtservicename.Text;
        _service._Createby = Session["USER_NAME"].ToString();
        _service._Createdate = getdate;
        _service._price = Convert.ToInt32(txtprice.Text);
        bool _getService = _service._SERVICE_ADD();
        if (_getService == false)
        {
            ShowMessage(_service._message, MessageType.Error);
        }
        else
        {
            ShowMessage("SERVICE Registration Successfully : "+ _service.getserviceID + "", MessageType.Success);
        }
        return _getService;
    }
    protected void linkbtnsave_Click(object sender, EventArgs e)
    {
        if (txtprice.Text == "")
        {
            ShowMessage("Maindatory field is Price not allow null", MessageType.Error);
        }
        else
        {
            _SERVICE_CREATE();
        }
    }
    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("index.aspx");
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}