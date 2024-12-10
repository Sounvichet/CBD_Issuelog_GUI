using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using ClosedXML.Excel;
using MasterReportClass;
using System.Data.OleDb;
using System.IO;
using System.Configuration;
using System.Drawing;
using System.Data.OracleClient;
using System.Threading;

public partial class Payment_VISAROF : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    SqlConnectAndSqlCommand _getsqlcon = new SqlConnectAndSqlCommand();
    DataTable CSVTable = new DataTable();
    //WingDashBoard _wing = new WingDashBoard();
    GridViewValues _grid = new GridViewValues();
    DropDownListValues _drop = new DropDownListValues();
    OracleCommand oracmd = new OracleCommand();
    OracleConnection obj2 = new OracleConnection();
    SqlCommand cmd = new SqlCommand();
    logger _logger = new logger();
    bool isLoading = false;
    masterreport_connect obj1 = new masterreport_connect();
    Visa_payment_dashboard_UAT _visa = new Visa_payment_dashboard_UAT();

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
            t_values_date.Text = _get_current_date;
            t_proc_date.Text = _get_current_date;
            _drop.bindDropDownList(d_GL_account,_visa._get_GL_ACCT_RIGHT_OFF());
            
        }
     }



    //public void ReadCSVFile(string fileName)
    //{
    //    try
    //    {
    //        string connection = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}\\;Extended Properties='Text;HDR=Yes;FMT=CSVDelimited'";

    //        connection = String.Format(connection, Path.GetDirectoryName(fileName));


    //        OleDbDataAdapter csvAdapter;
    //        csvAdapter = new OleDbDataAdapter("SELECT * FROM [" + Path.GetFileName(fileName) + "]", connection);

    //        if (File.Exists(fileName) && new FileInfo(fileName).Length > 0)
    //        {
    //            try
    //            {
    //                csvAdapter.Fill(CSVTable);
    //                if ((CSVTable != null) && (CSVTable.Rows.Count > 0))
    //                {
    //                    ViewState["CSVTable"] = CSVTable;
    //                    GridView _getGrid = new GridView();
    //                    _getGrid.DataSource = CSVTable;
    //                    _getGrid.DataBind();

    //                    _true._WING_Disputed_Insert(_getGrid);
    //                    // _CSS._CSS_LoopGrid(_getGrid);  //getgrid1
    //                    loading_Close();
    //                    ShowMessage("Insert records into Table Successful.", MessageType.Success);
                        
    //                }
    //                else
    //                {
    //                    String msg = "No records found";
    //                }
    //            }
    //            catch (Exception ex)
    //            {
    //                throw new Exception(String.Format("Error reading Table {0}.\n{1}", Path.GetFileName(fileName), ex.Message));
    //            }
    //        }
    //    }
    //    catch (Exception ex)
    //    {
    //        throw ex;
    //    }
    //}

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
    
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void Update_ServerClick(object sender, EventArgs e)
    {
        
        loading_Close();
        ShowMessage("Uploaded Successful !!!", MessageType.Success);

    }
    protected void linkbtnprocess_Click(object sender, EventArgs e)
    {
        _visa.p_gl = d_GL_account.SelectedItem.ToString();
        _visa.P_rf_date = t_values_date.Text;
        DataTable dt = _visa._get_GL_DR_BAL_LCY();
        if (dt.Rows.Count != 0)
        {
            t_gl_ending_balance.Text = dt.Rows[0][0].ToString();
        }
        if (dt.Rows.Count == 0)
        {
            Response.Write(@"<script language='javascript'>alert('there is no balance in date " + t_values_date.Text + " !!')</script>");

        }
    }

    protected void t_ending_balance_TextChanged(object sender, EventArgs e)
    {
        // Convert.ToDecimal(t_gl_ending_balance.Text);
        decimal gl_balance;
        if (!decimal.TryParse(t_gl_ending_balance.Text, out gl_balance))
        {
            Response.Write(@"<script language='javascript'>alert('GL ending balance must be a valid number !!')</script>");
            return;
        }

        decimal visa_balance;
        if (!decimal.TryParse(t_ending_balance.Text, out visa_balance))
        {
            Response.Write(@"<script language='javascript'>alert('Visa ending balance must be a valid number !!')</script>");
            return;
        }
        t_cal_right_off.Text = Convert.ToString(visa_balance - gl_balance);

        decimal cal_right_off = visa_balance - gl_balance ;

        if (cal_right_off < 0)
        {
            t_dr_cr.Text = "credit";
        }
        else if (cal_right_off > 0)
        {
            t_dr_cr.Text = "debit";
        }
        else
        {
            t_dr_cr.Text = ""; // Handle the case where cal_right_off is exactly zero if needed
        }
    }
    public bool _register_visa_right_off()
    {
        _visa.P_BANK_DATE = t_bank_date.Text;
        _visa.P_SOURCE_GL = d_GL_account.SelectedItem.ToString();
        _visa.P_VALUES_DATE = t_values_date.Text;
        _visa.P_GL_ENDING_BAL = t_gl_ending_balance.Text;
        _visa.P_VISA_ENDING_BAL = t_ending_balance.Text;
        _visa.P_PROC_DATE = t_proc_date.Text;
        _visa.P_CAL_RIGHTOFF = t_cal_right_off.Text;
        _visa.P_DR_CR = t_dr_cr.Text;
        _visa.P_USERID = Session["USERID"].ToString();
        bool _get_visa_right_off = _visa._ADD_VISA_WRITE_OFF();
        if (_get_visa_right_off == true)
        {
            ShowMessage("Added visa right off is successful !", MessageType.Success);
            LinkBtnsave.Enabled = false;
        }
        else
        {
            ShowMessage("added visa right off is fail!" + _logger._message, MessageType.Error);
        }
        return _get_visa_right_off;
    }
    protected void LinkBtnsave_Click(object sender, EventArgs e)
    {
        _register_visa_right_off();
    }

    protected void t_proc_date_TextChanged(object sender, EventArgs e)
    {
        _visa.P_ICM_DATE = t_proc_date.Text;
        DataTable dt = _visa._get_RUN_DATE();
        if (dt.Rows.Count != 0)
        {
            t_bank_date.Text = dt.Rows[0][0].ToString();
        }
        if (dt.Rows.Count == 0)
        {
            Response.Write(@"<script language='javascript'>alert('there is no RUN_DATE in incoming date  " + t_proc_date.Text + " !!')</script>");

        }
    }
}