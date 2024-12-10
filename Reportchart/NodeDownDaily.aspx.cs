using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using ClosedXML.Excel;
using System.Drawing;

public partial class Reportchart_NodeDownDaily : System.Web.UI.Page
{
    DropDownListValues _dropdown = new DropDownListValues();
    ReportNodeDownDaily _NodeDownDaily = new ReportNodeDownDaily();
    logger _logger = new logger();
    SqlConnection sqlc = new SqlConnection();
    GridViewValues _gridView = new GridViewValues();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    DataSet ds = new DataSet();
    SqlCommand cmd = new SqlCommand();
    string execproc = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            _View_Type();
            _SelectDate();
            _SelectToday();
            _NodeType();
            Label8.Text = GriViewReport.Rows.Count.ToString();
        }
    }
    public void _View_Type()
    {
        _dropdown.bindDropDownList(D_View_Type, _NodeDownDaily.D_View_Type());
    }
    public void _SelectDate()
    {
        _dropdown.bindDropDownList(D_Date, _NodeDownDaily.D_Select_date());
    }
    public void _SelectToday()
    {
        try
        {
            DataTable dt = _NodeDownDaily.D_Select_date_today();
            D_Date.SelectedValue = dt.Rows[0]["LookupCode"].ToString();
            _Frequency_Fundamental(D_Date.SelectedValue);
            //T_Form.Text =_Report._getStartPeriod(D_Date.SelectedValue);
            //T_to.Text = _Report._getEndPeriod(D_Date.SelectedValue);
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
    public void _NodeType()
    {
        _dropdown.bindDropDownList(D_NodeType, _NodeDownDaily.D_NodeType());
    }
    public void _Frequency_Fundamental(string lookup)
    {
        DataTable dt = _NodeDownDaily.D_Frequency_Fundamental(lookup);

        if (dt.Rows.Count == 0)
        {
            Response.Write("<script>alert('Not Yet implement!')</script>");
        }

        if (dt.Rows.Count > 0)
        {
            T_Form.Text = dt.Rows[0][3].ToString();
            T_to.Text = dt.Rows[0][4].ToString();
        }

    }
    protected void D_Date_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectdate = D_Date.SelectedValue;

        if (selectdate == "LD")
        {
            T_Form.Text = _NodeDownDaily._getStartPeriod(D_Date.SelectedValue);
            T_to.Text = _NodeDownDaily._getEndPeriod(D_Date.SelectedValue);
        }
        else
        {
            _Frequency_Fundamental(D_Date.SelectedValue);
        }
    }
    public void _ListViewCode()
    {
        string viewtype = D_View_Type.SelectedItem.Text;
        DataTable dt = _NodeDownDaily.D_ListViewCode(D_View_Type.SelectedValue, viewtype);
        if (dt.Rows.Count == 0)
        {
            Response.Write("<script>alert('Not Yet implement!')</script>");
        }
        if (dt.Rows.Count > 0)
        {
            string FormCode;
            string ListViewCode;
            FormCode = dt.Rows[0]["FormCode"].ToString();
            ListViewCode = dt.Rows[0]["ListViewCode"].ToString();
            if (FormCode == "SWD22" && ListViewCode == "000")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22000(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "001")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22001(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "002")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22002(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "003")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22003(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "004")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22004(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "005")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22005(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "006")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22006(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "007")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22007(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "008")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22008(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "009")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22009(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "010")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22010(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "011")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22011(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "012")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22012(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "013")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22013(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "014")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22014(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            if (FormCode == "SWD22" && ListViewCode == "999")
            {
                _gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectStringSWD22999(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
            }
            //_gridView._GridviewBinding(GriViewReport, _NodeDownDaily.D_SelectString(FormCode, ListViewCode, T_Form.Text, T_to.Text,D_NodeType.SelectedValue));
            Label8.Text = GriViewReport.Rows.Count.ToString();
            // Response.Write(_NodeDownDaily._sqlquery);
        }
    }
    private void ExportGridView()
    {
        string str = D_View_Type.SelectedItem.Text;
        str = str.Replace(" ", "");
        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + str + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.ms-excel";
        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            GriViewReport.AllowPaging = false;
            this._ListViewCode();

            GriViewReport.HeaderRow.BackColor = Color.White;
            GriViewReport.Attributes.Add("style", "word-break:break-all; word-wrap:break-word");
            foreach (TableCell cell in GriViewReport.HeaderRow.Cells)
            {
                cell.BackColor = GriViewReport.HeaderStyle.BackColor;
            }
            foreach (GridViewRow row in GriViewReport.Rows)
            {
                row.BackColor = Color.White;
                foreach (TableCell cell in row.Cells)
                {
                    if (row.RowIndex % 2 == 0)
                    {
                        cell.BackColor = GriViewReport.AlternatingRowStyle.BackColor;
                    }
                    else
                    {
                        cell.BackColor = GriViewReport.RowStyle.BackColor;
                    }
                    cell.CssClass = "textmode";
                }
            }
            GriViewReport.RenderControl(hw);

            //style to format numbers to string
            string style = @"<style> .textmode { mso-number-format:\@; } </style>";
            Response.Write(style);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();
        }
    }

    public void _exporttoexcel()
    {

        string _formcode = "SWD22";
        DataTable dt = _NodeDownDaily.D_View_Type();
        foreach (DataRow dt1 in dt.Rows)
        {
            string _getValues = dt1.Field<string>("ListViewCode");
            string _getFormdate = T_Form.Text;
            string _getTodate = T_to.Text;
            string _getNodeID = D_NodeType.SelectedValue;

            execproc += "exec SelectString '" + _formcode + "' , '" + _getValues + "','And DayID between dbo.GetDateCode (''" + _getFormdate + "'') and dbo.GetDateCode(''" + _getTodate + "'') And nodetypeid =" + _getNodeID + " ';";

        }
        using (SqlDataAdapter sda = new SqlDataAdapter())
        {
            _sqlcom._command_Query(execproc, ref cmd);
            sda.SelectCommand = cmd;
            sda.Fill(ds);

            //for (int i = 0; i < ds.Tables.Count; i++)
            //{
            //    if (i == 0)
            //    {
            //        ds.Tables[i].TableName = _getValues;
            //    }
            //    else
            //    {
            //        ds.Merge(ds.Tables[i]);
            //    }

            //}

        }

        using (XLWorkbook wb = new XLWorkbook())
        {
            //foreach (DataTable export in ds.Tables)
            //{
            //    //Add DataTable as Worksheet.
            //    wb.Worksheets.Add(export);
            //}

            for (int i = 0; i < ds.Tables.Count; i++)
            {
                ds.Tables[i].TableName = D_View_Type.Items[i + 1].Text.ToString();
                wb.Worksheets.Add(ds.Tables[i] as DataTable);
            }

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename= NodeDownDaily.xlsx");

            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }


    }
    protected void generate_click(object sender, EventArgs e)
    {
        _exporttoexcel();
    }
    protected void btnapply_Click(object sender, EventArgs e)
    {
        _ListViewCode();
    }
    protected void btngenerate_Click(object sender, EventArgs e)
    {
        ExportGridView();
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        // ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "window.location='" + Request.ApplicationPath + "Ticket/index.aspx';", true);
        Response.Redirect("~/index.aspx");
    }
}