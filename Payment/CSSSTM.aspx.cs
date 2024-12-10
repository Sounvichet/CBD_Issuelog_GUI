using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ClosedXML.Excel;
using System.Data;
using MasterReportClass;
using System.Data.SqlClient;
using System.Drawing;

public partial class Payment_CSS : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlCommand cmd = new SqlCommand();
    GridViewValues _grid = new GridViewValues();
    CSSdashboard _CSS = new CSSdashboard();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    { 
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }

        if (!IsPostBack)
        {
            string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            T_start_date.Text = currentdate;
        }
    }


    private void get_excel_CSS_Trasaction()
    {
        _CSS.P_SDATE = T_start_date.Text;
        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = _CSS._CSS_RECON_SETTLEMENT();
        wb.Worksheets.Add(dt, "CSS_SETTLEMENT");

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=CSS_SETTLE_" + _CSS.P_SDATE + ".xlsx");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void Linkexport_Click(object sender, EventArgs e)
    {
        get_excel_CSS_Trasaction();
    }
}