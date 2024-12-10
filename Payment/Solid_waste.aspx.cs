using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.OracleClient;
using MasterReportClass;
using System.Drawing;
using ClosedXML.Excel;
using System.IO;
using System.Data;


public partial class Payment_Solid_waste : System.Web.UI.Page
{
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    logger _logger = new logger();
    OracleConnection obj2 = new OracleConnection();
    SolidWasteDashboard _solid = new SolidWasteDashboard();
    dbcon _oracon = new dbcon();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');

        if (!IsPostBack)
        {
            txtfrom.Text = currentdate;
            txtto.Text = currentdate;
        }
        }
    private void _exportexcellisting()
    {
        
        _solid.P_BRN_FROM = txtfrom.Text;
        _solid.P_BRN_TO = txtto.Text;
        var workbook = new XLWorkbook();

        DataTable dt3 = _solid._getSolidWastelisting();
        DataSet ds = new DataSet();
        ds.Tables.Add(dt3);

        for (int i = 0; i < ds.Tables.Count; i++)
        {

            workbook.Worksheets.Add(ds.Tables[i] as DataTable);
        }
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=SDW_LISTING.xlsx");

        using (MemoryStream MyMemoryStream = new MemoryStream())
        {
            workbook.SaveAs(MyMemoryStream);
            MyMemoryStream.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
    }

    private void _GetexcelflieSWB()
    {

        XLWorkbook wb = new XLWorkbook();

        obj2.ConnectionString = _oracon.oracleconUAT5();
        obj2.Open();
        OracleCommand cmd = new OracleCommand("PR_SOLID_WASTE_LISTING", obj2);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("P_FROM", txtfrom.Text);
        cmd.Parameters.AddWithValue("P_TO", txtto.Text);
        cmd.Parameters.Add("O_CURSOR1", OracleType.Cursor).Direction = ParameterDirection.Output;
        cmd.Parameters.Add("O_CURSOR2", OracleType.Cursor).Direction = ParameterDirection.Output;
        OracleDataAdapter _adp = new OracleDataAdapter();
        _adp.SelectCommand = cmd;
        DataSet ds = new DataSet();
        _adp.Fill(ds);

        for (int i = 0; i < ds.Tables.Count; i++)
        {

            wb.Worksheets.Add(ds.Tables[i] as DataTable);
        }
        obj2.Close();

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=SWB_Settlement.xlsx");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();
        //Response.Write("<script>alert('Update Successful!!')</script>");
        //Server.Transfer("~/TestPro/Default.aspx");



    }
    protected void Linkbtnapply_Click(object sender, EventArgs e)
    {
        //_exportexcellisting();
       // _GetexcelflieSWB();
    }

    protected void Linkbtncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/index.aspx");
    }
}