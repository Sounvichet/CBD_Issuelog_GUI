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
using System.Drawing;
using ClosedXML.Excel;
public partial class Reportchart_report : System.Web.UI.Page
{
    DropDownListValues _dropdown = new DropDownListValues();
    ReportSolarWinds _Report = new ReportSolarWinds();
    logger _logger = new logger();
    SqlConnection sqlc = new SqlConnection();
    GridViewValues _gridView = new GridViewValues();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    DataSet ds = new DataSet();
    string FormCode;
    string ListViewCode;
    string execproc = "";
    
    public enum MessageType { Success, Error, Info, Warning };
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
            _ActionType();
            _SelectToday();
            _NodeType();
            _groupreason();
            Label8.Text = GriViewReport.Rows.Count.ToString();
        }
    }
    public void _View_Type()
    {
        _dropdown.bindDropDownList(D_View_Type, _Report.D_View_Type());
    }
    public void _SelectDate()
    {
        _dropdown.bindDropDownList(D_Date, _Report.D_Select_date());
    }
    public void _SelectToday()
    {
        try
        {
            DataTable dt = _Report.D_Select_date_today();
            D_Date.SelectedValue = dt.Rows[0]["LookupCode"].ToString();
            _Frequency_Fundamental(D_Date.SelectedValue);

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
        _dropdown.bindDropDownList(D_NodeType, _Report.D_NodeType());
    }
    public void _groupreason()
    {
        _dropdown.bindDropDownList(D_ReasonGroup, _Report.D_getReasonGroup());
    }
    public void _ActionType()
    {
        _dropdown.bindDropDownList(D_ActionType, _Report.D_ActionType());
    }
    public void _Frequency_Fundamental(string lookup)
    {
        DataTable dt = _Report.D_Frequency_Fundamental(lookup);

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
            T_Form.Text = _Report._getStartPeriod(D_Date.SelectedValue);
            T_to.Text = _Report._getEndPeriod(D_Date.SelectedValue);
        }
        else
        {
            _Frequency_Fundamental(D_Date.SelectedValue);

        }


    }
    public void _ListViewCode()
    { 
            string viewtype = D_View_Type.SelectedItem.Text;
            DataTable dt = _Report.D_ListViewCode(D_View_Type.SelectedValue, viewtype);
            if (dt.Rows.Count == 0)
            {
                Response.Write("<script>alert('Not Yet implement!')</script>");
            }
            if (dt.Rows.Count > 0)
            {
                FormCode = dt.Rows[0]["FormCode"].ToString();
                ListViewCode = dt.Rows[0]["ListViewCode"].ToString();
                if (FormCode == "SWD21" && ListViewCode == "000" && D_ReasonGroup.SelectedValue == "" && D_ActionType.SelectedItem.Text == "")
                {
                    _gridView._GridviewBinding(GriViewReport, _Report.D_SelectString_NullActionType(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
                }
                else if (FormCode == "SWD21" && ListViewCode == "000" && D_ReasonGroup.SelectedValue != "" && D_ActionType.SelectedItem.Text == "")
                {
                    _gridView._GridviewBinding(GriViewReport, _Report.D_SelectString_NotAction(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue, D_ReasonGroup.SelectedValue));
                }
            else if(FormCode == "SWD21" && ListViewCode == "000" && D_NodeType.SelectedValue != "" && D_ReasonGroup.SelectedValue != "" && D_ActionType.SelectedItem.Text != "")
                {
                    _gridView._GridviewBinding(GriViewReport, _Report._Full_input_values(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue, D_ReasonGroup.SelectedValue, D_ActionType.SelectedValue));
                }
            else if(FormCode == "SWD21" && ListViewCode == "001" && D_ReasonGroup.SelectedValue == "" && D_ActionType.SelectedItem.Text == "")
                {
                    _gridView._GridviewBinding(GriViewReport, _Report.D_SelectString_NullActionType001(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
                }
            else if(FormCode == "SWD21" && ListViewCode == "001" && D_ActionType.SelectedItem.Text != "")
                {
                    _gridView._GridviewBinding(GriViewReport, _Report.D_SelectString(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue, D_ActionType.SelectedItem.Text, D_ReasonGroup.SelectedValue));
                }
            else if(FormCode == "SWD21" && ListViewCode == "002")
                {
                    _gridView._GridviewBinding(GriViewReport, _Report.D_SelectString_002(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
                }
            else if(FormCode == "SWD21" && ListViewCode == "T00")
                {
                    _gridView._GridviewBinding(GriViewReport, _Report.D_SelectString_T00(FormCode, ListViewCode, T_Form.Text, T_to.Text, D_NodeType.SelectedValue));
                }
                Label8.Text = GriViewReport.Rows.Count.ToString();
                // Response.Write(_Report._Sqlquery);
            }
        }
    
    private void ExportGridView()
    {
        string str = D_View_Type.SelectedItem.Text;
        str = str.Replace(" ", "");
        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.AddHeader("content-disposition", "attachment;filename=" + str + ".xls");
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";

        using (StringWriter sw = new StringWriter())
        {
            HtmlTextWriter hw = new HtmlTextWriter(sw);

            //To Export all pages
            GriViewReport.AllowPaging = false;
            //GriViewReport.RowStyle.Wrap = true;
            this._ListViewCode();
            GriViewReport.HeaderRow.BackColor = Color.White;
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
    public void _getExcelFile()
    {
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Buffer = true;
        string WorkBook = "";
        string Worksheet = "";
        WorkBook = D_View_Type.SelectedItem.ToString().Replace(' ', '_'); ;
        Worksheet = D_View_Type.SelectedValue;
        try
        {
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = new DataTable();

            if (GriViewReport.HeaderRow != null)
            {

                for (int i = 0; i < GriViewReport.HeaderRow.Cells.Count; i++)
                {
                    dt.Columns.Add(GriViewReport.HeaderRow.Cells[i].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GriViewReport.Rows)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < row.Cells.Count; i++)
                {
                    dr[i] = row.Cells[i].Text.Replace("&nbsp;", "");
                }
                dt.Rows.Add(dr);
            }

            //  add the footer row to the table
            if (GriViewReport.FooterRow != null)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < GriViewReport.FooterRow.Cells.Count; i++)
                {
                    dr[i] = GriViewReport.FooterRow.Cells[i].Text.Replace("&nbsp;", "");
                }
                dt.Rows.Add(dr);
            }


            wb.Worksheets.Add(dt, Worksheet);
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename= " + WorkBook + ".xlsx");

            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }

           

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _logger._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }

    }
    public void _GetMultiExcel()
    {
        Response.ClearContent();
        Response.ClearHeaders();
        Response.Buffer = true;
        string WorkBook = "";
        string Worksheet = "";
        WorkBook = D_View_Type.SelectedItem.ToString().Replace(' ', '_'); ;
        Worksheet = D_View_Type.SelectedValue;
        try
        {
            DataSet ds = _getdatasetexportToexcel();
            XLWorkbook wb = new XLWorkbook();

            foreach (DataTable dt in ds.Tables)
            {
                wb.Worksheets.Add(dt);
            }

            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename= " + WorkBook + ".xlsx");

            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _logger._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }

    }
    public DataSet _getdatasetexportToexcel()
    {
        DataSet ds = new DataSet();
        if (ds.Tables.Count > 0)
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                D_View_Type.Items.Add(new ListItem() { Text = row["Text"].ToString(), Value = row["Value"].ToString() });

            }

        return ds;
    }
    public void _getmultiexportsheet()
    {

        string _formcode = "SWD21";
        DataTable dt = _Report.D_View_Type();
        foreach (DataRow dt1 in dt.Rows)
        {
            string _getValues = dt1.Field<string>("ListViewCode");
            string _getFormdate = T_Form.Text;
            string _getTodate = T_to.Text;
            string _getNodeID = D_NodeType.SelectedValue;

            if (_getValues != "002")
            {
                 execproc += "exec SelectString '" + _formcode + "' , '" + _getValues + "','001','','And DayID between dbo.GetDateCode (''" + _getFormdate + "'') and dbo.GetDateCode(''" + _getTodate + "'') And nodetypeid =" + _getNodeID + " And DownMinute >= 30',default,default;";
            }
            if (_getValues == "002")

            {
                execproc += "exec SelectString '" + _formcode + "' , '" + _getValues + "','001','','And Cast(DownTime  as Date) between  dbo.GetDateCode (''" + _getFormdate + "'') and dbo.GetDateCode(''" + _getTodate + "'') And nodetypeid =" + _getNodeID + "',default,default;";
            }
            
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
            //    export.TableName = "";
            //    wb.Worksheets.Add(export);
            //}
            for(int i=0; i< ds.Tables.Count; i++)
            {
                ds.Tables[i].TableName = D_View_Type.Items[i + 1].Text.ToString(); 
                wb.Worksheets.Add(ds.Tables[i] as DataTable);
            }
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename= NodeDownReason.xlsx");

            using (MemoryStream MyMemoryStream = new MemoryStream())
            {
                wb.SaveAs(MyMemoryStream);
                MyMemoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }


    }
    protected void btnapply_Click(object sender, EventArgs e)
    {
        _ListViewCode();
    }
    protected void generate_click(object sender, EventArgs e)
    {
        _getmultiexportsheet();
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        // ScriptManager.RegisterStartupScript(this, this.GetType(), "redirect", "window.location='" + Request.ApplicationPath + "Ticket/index.aspx';", true);
        Response.Redirect("~/index.aspx");
    }
    protected void btngenerate_Click(object sender, EventArgs e)
    {

         _getExcelFile();
        string script = "alert('Excel report generated successfully.');";
        ScriptManager.RegisterClientScriptBlock(this, GetType(), "Popup", script, true);
    }

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void GriViewReport_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GriViewReport.PageIndex = e.NewPageIndex;
        _ListViewCode();
        GriViewReport.DataBind();
        Label8.Text = GriViewReport.Rows.Count.ToString();
    }
}