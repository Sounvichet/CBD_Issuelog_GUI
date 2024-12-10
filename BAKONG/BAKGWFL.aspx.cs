using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Drawing;
using System.Data.OracleClient;
using CSSClearingClass;
using MasterDebugLog;
using BakongClearingDispute; 


public partial class Payment_BAKGWFL : System.Web.UI.Page
{
    //SqlConnection sqlc = new SqlConnection();
    DataTable CSVTable = new DataTable();
    GridViewValues _grid = new GridViewValues();
    bool isLoading = false;
    //logger _logger = new logger();
    CSSSettlement _css = new CSSSettlement();
    CSSITOPreview _pre = new CSSITOPreview();
    CSSITOUpload _ito = new CSSITOUpload();
    DebugLog _log = new DebugLog();
    BakongITOPreview _bkito = new BakongITOPreview();
    BakongITOUpload _bitoup = new BakongITOUpload();
    BakongDashboard _bd = new BakongDashboard();
    public enum MessageType { Success, Error, Info, Warning };

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {

            string _get_current_date = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            t_start_date.Text = _get_current_date;
            t_end_date.Text = _get_current_date;
            
        }
     }

    private void loading()
    {
        //string script = isHide ? "$('#loading').hide(); " : "$('#loading').show(); ";
        //ClientScript.RegisterStartupScript(this.GetType(), "load", script, true);
        ScriptManager.RegisterStartupScript(this,this.GetType(), "load", "$('#loading').show();", true);
    }
    private void loading_Close()
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), "load", "$('#loading').hide();", true);
    }
    

    //private void _grid_css_obs_settlement_USD()
    //{
    //    _css.P_STTL_CCY = "USD";
    //    _css.P_SDATE = t_start_date.Text;
    //    _css.P_EDATE = t_end_date.Text;

    //    grid_css_sttl_USD.HeaderStyle.BackColor = Color.FromName("#00A7A5");
    //    grid_css_sttl_USD.HeaderStyle.Font.Bold = true;
    //    grid_css_sttl_USD.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
    //    _grid._GridviewBinding(grid_css_sttl_USD, _css._CSS_OBS_Settlement());
    //}

    //private void _grid_css_obs_settlement_KHR()
    //{
    //    _css.P_STTL_CCY = "KHR";
    //    _css.P_SDATE = t_start_date.Text;
    //    _css.P_EDATE = t_end_date.Text;

    //    grid_css_sttl_KHR.HeaderStyle.BackColor = Color.FromName("#00A7A5");
    //    grid_css_sttl_KHR.HeaderStyle.Font.Bold = true;
    //    grid_css_sttl_KHR.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
    //    _grid._GridviewBinding(grid_css_sttl_KHR, _css._CSS_OBS_Settlement());

    //}

    private void _grid_css_ito_pre()
    {
        _bkito.P_CCY = d_settlement.SelectedItem.Text;
        _bkito.P_SDATE = t_start_date.Text;
        _bkito.P_EDATE = t_end_date.Text;
        GetGrid_css_list.HeaderStyle.BackColor = Color.FromName("#00A7A5");
        GetGrid_css_list.HeaderStyle.Font.Bold = true;
        GetGrid_css_list.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(GetGrid_css_list, _bkito._BAKONG_OBS_Settlement());
        l_count_css.Text = GetGrid_css_list.Rows.Count.ToString();

    }

    private void _grid_Bakong_ito_smy()
    {
        _bkito.P_CCY = d_settlement.SelectedItem.Text;
        _bkito.P_SDATE = t_start_date.Text;
        _bkito.P_EDATE = t_end_date.Text;
        Grid_Bakong_ITO_SMY.HeaderStyle.BackColor = Color.FromName("#00A7A5");
        Grid_Bakong_ITO_SMY.HeaderStyle.Font.Bold = true;
        Grid_Bakong_ITO_SMY.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(Grid_Bakong_ITO_SMY, _bkito._BAKONG_ITO_SMY());

    }

    private void _grid_Bakong_ito_nbc_smy()
    {
        _bkito.P_CCY = d_settlement.SelectedItem.Text;
        _bkito.P_SDATE = t_start_date.Text;
        _bkito.P_EDATE = t_end_date.Text;
        Grid_Bakong_NBC_SMY.HeaderStyle.BackColor = Color.FromName("#00A7A5");
        Grid_Bakong_NBC_SMY.HeaderStyle.Font.Bold = true;
        Grid_Bakong_NBC_SMY.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(Grid_Bakong_NBC_SMY, _bkito._BAKONG_NBC_SMY());

    }


    private void _grid_Bakong_ito_pg_smy()
    {
        _bkito.P_CCY = d_settlement.SelectedItem.Text;
        //_bkito.P_SDATE = t_start_date.Text;
        _bkito.P_EDATE = t_end_date.Text;
        Grid_Bakong_PG_SMY.HeaderStyle.BackColor = Color.FromName("#00A7A5");
        Grid_Bakong_PG_SMY.HeaderStyle.Font.Bold = true;
        Grid_Bakong_PG_SMY.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(Grid_Bakong_PG_SMY, _bkito._BAKONG_PG_SMY());

    }

    private void _grid_Bakong_ito_obs_sttl()
    {
        _bd.P_STTL_CCY = d_settlement.SelectedItem.Text;
        _bd.P_SDATE = t_start_date.Text;
        _bd.P_EDATE = t_end_date.Text;
        Grid_Bakong_OBS.HeaderStyle.BackColor = Color.FromName("#00A7A5");
        Grid_Bakong_OBS.HeaderStyle.Font.Bold = true;
        Grid_Bakong_OBS.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
        _grid._GridviewBinding(Grid_Bakong_OBS, _bd._BAKONG_OBS_Settlement());

    }

    //private void _grid_css_check_variance()
    //{
    //    _pre.P_CCY = d_settlement.SelectedItem.Text;
    //    _pre.P_SDATE = t_start_date.Text;
    //    _pre.P_EDATE = t_end_date.Text;
    //    Grid_ITO_SMY.HeaderStyle.BackColor = Color.FromName("#00A7A5");
    //    Grid_ITO_SMY.HeaderStyle.Font.Bold = true;
    //    Grid_ITO_SMY.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
    //    _grid._GridviewBinding(Grid_check_variance,_pre._CSS_check_variance());

    //}

    //private void _grid_css_getcount_by_status()
    //{
    //    _pre.P_CCY = d_settlement.SelectedItem.Text;
    //    _pre.P_SDATE = t_start_date.Text;
    //    _pre.P_EDATE = t_end_date.Text;
    //    Grid_ITO_SMY.HeaderStyle.BackColor = Color.FromName("#00A7A5");
    //    Grid_ITO_SMY.HeaderStyle.Font.Bold = true;
    //    Grid_ITO_SMY.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
    //    _grid._GridviewBinding(Grid_total_count_status, _css._CSS_NBC_get_count_by_status_rpt());

    //}


    //private void _grid_css_payment_smy()
    //{
    //    _css.P_STTL_CCY = d_settlement.SelectedItem.Text;
    //    _css.P_SDATE = t_start_date.Text;
    //    _css.P_EDATE = t_end_date.Text;
    //    GetGrid_CSS_Smy.HeaderStyle.BackColor = Color.FromName("#00A7A5");
    //    GetGrid_CSS_Smy.HeaderStyle.Font.Bold = true;
    //    GetGrid_CSS_Smy.HeaderStyle.ForeColor = Color.FromName("#f5f5f5");
    //    _grid._GridviewBinding(GetGrid_CSS_Smy, _css._CSS_payment_smy());

    //}

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void Review_ServerClick1(object sender, EventArgs e)
    {
        _grid_css_ito_pre();
        _grid_Bakong_ito_smy();
        _grid_Bakong_ito_nbc_smy();
        _grid_Bakong_ito_pg_smy();
        _grid_Bakong_ito_obs_sttl();
    }
    //private void Get_WING_ITO_UPLOAD()
    //{
    //    string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
    //    _wing.P_SDATE = currentdate;
    //    XLWorkbook wb = new XLWorkbook();
    //    DataTable dt = new DataTable();
    //    dt = _wing._get_WING_ITO_Upload();
    //    wb.Worksheets.Add(dt, "WING_ITO_UPLOAD");

    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.Charset = "";
    //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //    Response.AddHeader("content-disposition", "attachment;filename=WING_UPLOAD.xlsx");
    //    System.IO.MemoryStream memory = new System.IO.MemoryStream();
    //    wb.SaveAs(memory);
    //    memory.WriteTo(Response.OutputStream);
    //    Response.Flush();
    //    Response.End();
    //    //Response.Write("<script>alert('Update Successful!!')</script>");
    //    //Server.Transfer("~/TestPro/Default.aspx");
    //}
    //private void Get_WING_generate_disputed()
    //{
    //    string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
    //    _true.P_SDATE = currentdate;
    //    XLWorkbook wb = new XLWorkbook();
    //    DataTable dt = new DataTable();
    //    dt = _true._get_WING_generate_disputed();
    //    wb.Worksheets.Add(dt, "Wing_disputed");

    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.Charset = "";
    //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //    Response.AddHeader("content-disposition", "attachment;filename=WING_Generate_Disputed.xlsx");
    //    System.IO.MemoryStream memory = new System.IO.MemoryStream();
    //    wb.SaveAs(memory);
    //    memory.WriteTo(Response.OutputStream);
    //    Response.Flush();
    //    Response.End();
    //    //Response.Write("<script>alert('Update Successful!!')</script>");
    //    //Server.Transfer("~/TestPro/Default.aspx");
    //}

    //private void Get_WING_generate_ITO()
    //{
    //    string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
    //    _wing.P_SDATE = currentdate;
    //    XLWorkbook wb = new XLWorkbook();
    //    DataTable dt = new DataTable();
    //    dt = _wing._get_WING_generate_disputed();
    //    wb.Worksheets.Add(dt, "Wing_disputed");
    //    Response.Clear();
    //    Response.Buffer = true;
    //    Response.Charset = "";
    //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
    //    Response.AddHeader("content-disposition", "attachment;filename=WING_Generate_Disputed.xlsx");
    //    System.IO.MemoryStream memory = new System.IO.MemoryStream();
    //    wb.SaveAs(memory);
    //    memory.WriteTo(Response.OutputStream);
    //    Response.Flush();
    //    Response.End();
    //    //Response.Write("<script>alert('Update Successful!!')</script>");
    //    //Server.Transfer("~/TestPro/Default.aspx");
    //}

    protected void Update_ServerClick(object sender, EventArgs e)
    {
        
        loading_Close();
        ShowMessage("Uploaded Successful !!!", MessageType.Success);

    }
    protected void export_ServerClick(object sender, EventArgs e)
    {

    }
    protected void A1_ServerClick(object sender, EventArgs e)
    {
       // Get_WING_generate_disputed();
    }

    protected void A2_ServerClick(object sender, EventArgs e)
    {
       // Get_WING_ITO_UPLOAD();
    }

    protected void A3_ServerClick(object sender, EventArgs e)
    {
        //string get_ITO_reference = _get_reference();
        string _getsettle;
        _getsettle = d_settlement.SelectedItem.ToString();

        if (_getsettle == "KHR")
        {
            _ito.p_type = "CBDAPP";
            _ito.p_source = "CBD_SYSTEM";
            _ito.p_reference = "CSS_KHR";
            _ito._GET_ITO_FN_PUSH_ENTRIES();
            ShowMessage("Push Function was successful for CSS KHR", MessageType.Success);
        }
        if (_getsettle == "USD")
        {
            _ito.p_type = "CBDAPP";
            _ito.p_source = "CBD_SYSTEM";
            _ito.p_reference = "CSS_USD";
            _ito._GET_ITO_FN_PUSH_ENTRIES();
            ShowMessage("Push Function was successful for CSS USD", MessageType.Success);
        }
        //else if (_getsettle == "NNSS_KHR")
        //{
        //    _visa.p_type = "CBDAPP";
        //    _visa.p_source = "CBD_SYSTEM";
        //    _visa.p_reference = "VISA_NNSS_KHR";
        //    _visa._GET_ITO_FN_PUSH_ENTRIES();
        //    ShowMessage("Push Function was successful for VISA NNSS KHR", MessageType.Success);
        //}

    }
    protected void A4_ServerClick(object sender, EventArgs e)
    {
        //_visa.P_USERID = Session["USERID"].ToString();
        //_visa._VISA_PAYMENT_ITO_UPLOADS(GetGrid_Visa_list);
        _ito.P_USERID = Session["USERID"].ToString();
        //_ito._VISA_PAYMENT_ITO_UPLOADS(GetGrid_css_list);
        _bitoup._BAKONG_PAYMENT_ITO_UPLOADS(GetGrid_css_list);
        loading_Close();
        ShowMessage("Moved records to ITO is successful !", MessageType.Success);
    }

    protected void A5_ServerClick(object sender, EventArgs e)
    {
        string _getsettle;
        _getsettle = d_settlement.SelectedItem.ToString();

        if (_getsettle == "KHR")
        {
            _ito.p_source = "CBD_SYSTEM";
            _ito.p_reference = "CSS_KHR";
            _ito._GET_ITO_FN_DEL_ENTRIES();
            ShowMessage("Deleted Function is successful for CSS KHR", MessageType.Success);
        }
        if (_getsettle == "USD")
        {
            _ito.p_source = "CBD_SYSTEM";
            _ito.p_reference = "CSS_USD";
            _ito._GET_ITO_FN_DEL_ENTRIES();
            ShowMessage("Deleted Function is successful for CSS USD", MessageType.Success);
        }
        //else if (_getsettle == "NNSS_USD")
        //{
        //    _visa.p_source = "CBD_SYSTEM";
        //    _visa.p_reference = "VISA_NNSS_USD";
        //    _visa._GET_ITO_FN_DEL_ENTRIES();
        //    ShowMessage("Deleted Function is successful for VISA NNSS USD", MessageType.Success);
        //}
    }

    //protected void btnedit_click(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow row in GetGrid_Visa_list.Rows)
    //    {
    //        CheckBox checkbox = (CheckBox)row.FindControl("check");
    //        if (checkbox.Checked)
    //        {
    //            string id = Convert.ToString(row.Cells[14].Text);
    //            Response.Redirect("~/Payment/visa_payment_edit.aspx?RRN=" + id);
    //        }
    //    }
    //}
    //protected void btndelete_click(object sender, EventArgs e)
    //{
    //    foreach (GridViewRow row in GetGrid_Visa_list.Rows)
    //    {
    //        CheckBox checkbox = (CheckBox)row.FindControl("check");
    //        if (checkbox.Checked)
    //        {
    //            string id = Convert.ToString(row.Cells[14].Text);
    //            Response.Redirect("~/Payment/visa_payment_delete.aspx?RRN=" + id);
    //        }
    //    }
    //}

    protected void Linkbtnexport_Click(object sender, EventArgs e)
    {
        _getExcelFile();
    }
    

    public void _getExcelFile()
    {
        try
        {
            XLWorkbook wb = new XLWorkbook();
            DataTable dt = new DataTable();

            if (GetGrid_css_list.HeaderRow != null)
            {

                for (int i = 0; i < GetGrid_css_list.HeaderRow.Cells.Count; i++)
                {
                    dt.Columns.Add(GetGrid_css_list.HeaderRow.Cells[i].Text);
                }
            }

            //  add each of the data rows to the table
            foreach (GridViewRow row in GetGrid_css_list.Rows)
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
            if (GetGrid_css_list.FooterRow != null)
            {
                DataRow dr;
                dr = dt.NewRow();

                for (int i = 0; i < GetGrid_css_list.FooterRow.Cells.Count; i++)
                {
                    dr[i] = GetGrid_css_list.FooterRow.Cells[i].Text.Replace("&nbsp;", "");
                }
                dt.Rows.Add(dr);
            }


            wb.Worksheets.Add(dt, "Issue_listing");
            Response.Clear();
            Response.Buffer = true;
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename="+d_settlement.SelectedItem.ToString()+"_"+t_end_date.Text+".xlsx");
            System.IO.MemoryStream memory = new System.IO.MemoryStream();
            wb.SaveAs(memory);
            memory.WriteTo(Response.OutputStream);
            Response.Flush();
            Response.End();
        }
        catch (Exception ex)
        {
            _log.logfile(ex);
            _log._messageError = ex.Message;
            Response.Write(@"<script language='javascript'>alert('" + _log._messageError + " !!')</script>");
        }
        finally
        {
            //sqlc.Close();
            //sqlc.Dispose();
            //SqlConnection.ClearPool(sqlc);
        }

    }
}