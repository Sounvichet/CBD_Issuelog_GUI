using System;
using System.Web.UI;
using System.Data;
using ClosedXML.Excel;
using CSSClearingClass; 
public partial class Payment_CSSRPT : System.Web.UI.Page
{
    CSSSettlement _css = new CSSSettlement();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
    }



    private void loading()
    {
        //string script = isHide ? "$('#loading').hide(); " : "$('#loading').show(); ";
        //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#loading').show();", true);
    }
    private void loading_Close()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#loading').hide();", true);
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void btnExport_ServerClick(object sender, EventArgs e)
    {
        _export_excel();
    }

    private void _export_excel()
    {
        _css.P_STTL_CCY = d_settlement.SelectedItem.ToString();
        _css.P_SDATE = t_start_date.Text;
        _css.P_EDATE = t_end_date.Text;
        XLWorkbook wb = new XLWorkbook();
        DataTable dt = new DataTable();
        dt = _css._CSS_NBC_list_rpt();
        wb.Worksheets.Add(dt, d_settlement.SelectedItem.ToString() +"_NBC" );

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + d_settlement.SelectedItem.ToString()+"_NBC_.xls");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
    }
}