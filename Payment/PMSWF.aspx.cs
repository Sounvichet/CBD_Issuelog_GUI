using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using ClosedXML.Excel;
using System.IO;
using MasterReportClass;


public partial class Payment_MaintenanceFee : System.Web.UI.Page
{
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    GridViewValues _grid = new GridViewValues();
    ReportWingDashboard _wing = new ReportWingDashboard();
    DropDownListValues _dropdown = new DropDownListValues();
    logger _logger = new logger();
    SqlConnection sqlc = new SqlConnection();
    OracleConnection obj2 = new OracleConnection();
    MaintenanceFee _FEE = new MaintenanceFee();
    MaintenanceFeeDashBoard _FEEDashboard = new MaintenanceFeeDashBoard();
    masterreport_connect obj1 = new masterreport_connect();
    
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        string nextdate = DateTime.Now.AddDays(1).ToString("dd/MMM/yyyy").Replace('/', '-');
        string previousdate = DateTime.Now.AddDays(-1).ToString("dd/MMM/yyyy").Replace('/', '-');
        if (!IsPostBack)
        {
            _SelectDate();
            _SelectToday();
            txtnextupload.Text = nextdate;
            txtupload.Text = currentdate;
            Txtgeneratedate.Text = currentdate;
            _get_currency();
            _get_currencyUSD();
        }
       
    }
    public void _SelectDate()
    {
        _dropdown.bindDropDownList(d_selectdate, _FEE.D_Select_date());
    }
    public void _SelectToday()
    {
        try
        {
            DataTable dt = _FEE.D_Select_date_today();
            d_selectdate.SelectedValue = dt.Rows[0]["LookupCode"].ToString();
            _Frequency_Fundamental(d_selectdate.SelectedValue);

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
    public void _Frequency_Fundamental(string lookup)
    {
        DataTable dt = _FEE.D_Frequency_Fundamental(lookup);

        if (dt.Rows.Count == 0)
        {
            Response.Write("<script>alert('Not Yet implement!')</script>");
        }

        if (dt.Rows.Count > 0)
        {
            txtForm.Text = dt.Rows[0][3].ToString();
            txtto.Text = dt.Rows[0][4].ToString();
        }
    }
    protected void D_selectdate_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selectdate = d_selectdate.SelectedValue;
        if (selectdate == "LD")
        {
            txtForm.Text = _FEE._getStartPeriod(d_selectdate.SelectedValue);
            txtto.Text = _FEE._getEndPeriod(d_selectdate.SelectedValue);
        }
        else
        {
            _Frequency_Fundamental(d_selectdate.SelectedValue);

        }
    }
    private void _get_currency()
    {
        DataTable dt = _FEEDashboard._getCurrencyKHR();
        txtUSDKHR.Text = dt.Rows[1][4].ToString();
        txtTHBKHR.Text = dt.Rows[0][4].ToString();
    }
    private void _get_currencyUSD()
    {
        DataTable dt = _FEEDashboard._getCurrencyUSD();
        txtUSDTHB.Text = dt.Rows[0][4].ToString();

    }
    public bool _Getexportexcel_M()
    {
        bool retval = _Pre_checking_script(txtupload.Text, D_servtype.Text);   // _FEEDashboard._Pre_checking_script(txtupload.Text, D_servtype.Text);

        if (retval == true)
        {
            bool update_retval = _Pre_update_checking_script(txtupload.Text, D_servtype.Text);
            if (update_retval == true)
            {
                //====== MOVE DATA TO NEW BACKUP TABLE ======
                //====== DELETE DATA FROM FEE TABLE ======
                bool insert_retval = _InsertBKMB_FEE(txtupload.Text, D_servtype.Text, d_f_brncode.SelectedValue, d_t_brncode.SelectedValue);

                if (insert_retval == true)
                {
                  ///====== MOVE NEW REFRESH DATA BACK TO FEE TABLE ======
                  bool insert_BK_to_ANNFEE = _InsertMB_FEE_from_BK(txtupload.Text, D_servtype.Text, d_f_brncode.SelectedValue, d_t_brncode.SelectedValue);

                        if (insert_BK_to_ANNFEE == true)
                        {
                        //============= MOVE SUBSCRIBER NOT ENOUGH BALANCE TO NEXT DAY ===============
                        bool Move_to_nextday = _InsertMB_FEE_toNextday(txtupload.Text, txtnextupload.Text, D_servtype.Text, txtUSDKHR.Text, txtUSDTHB.Text, d_f_brncode.SelectedValue, d_t_brncode.Text);
                                if (Move_to_nextday == true)
                                {
                                //====== REMOVE LAST_RETRY='Y' FROM FEE TABLE ======
                            bool Update_retry = _updateLastRetryMB(txtupload.Text, D_servtype.Text, txtUSDKHR.Text, txtUSDTHB.Text, d_f_brncode.SelectedValue, d_t_brncode.Text);

                                        if (Update_retry == true)
                                        {
                                              ShowMessage("Process is Successful!", MessageType.Success);  
                                        }

                                        if (Update_retry == false)
                                        {
                                            ShowMessage("Error Update last retry charge", MessageType.Error);
                                        }
                                        return Update_retry;
                                }
                                if (Move_to_nextday == false)
                                {
                                    ShowMessage("Error Move Data to the next day", MessageType.Error);
                                }
                                return Move_to_nextday;
                        }
                        if (insert_BK_to_ANNFEE == false)
                        {
                            ShowMessage("Error Delete record in MOBILEBANKING_ANNUAL_FEE", MessageType.Error);
                        }
                         return insert_BK_to_ANNFEE;
                }
                if (insert_retval == false)

                {
                    ShowMessage("INsert record into FEE_BACKUP_MOBILEBANKING fail !", MessageType.Error);
                }

                return insert_retval;

            }
            if (update_retval == false)
            {
                ShowMessage("Please try again!", MessageType.Error);
            }
            return update_retval;
        }

        if (retval == false)
        {
            ShowMessage("please check it again", MessageType.Error);
        }
        return retval;
    }
    public bool _Getexportexcel_A()
    {
        bool retval = _Pre_checking_script(txtupload.Text, D_servtype.Text);   // _FEEDashboard._Pre_checking_script(txtupload.Text, D_servtype.Text);

        if (retval == true)
        {
                //====== MOVE DATA TO NEW BACKUP TABLE ======
                //====== DELETE DATA FROM FEE TABLE ======
                bool insert_retval = _InsertBKMB_FEE(txtupload.Text, D_servtype.Text, d_f_brncode.SelectedValue, d_t_brncode.SelectedValue);

                if (insert_retval == true)
                {
                    ///====== MOVE NEW REFRESH DATA BACK TO FEE TABLE ======
                    bool insert_BK_to_ANNFEE = _InsertMB_FEE_from_BK(txtupload.Text, D_servtype.Text, d_f_brncode.SelectedValue, d_t_brncode.SelectedValue);

                    if (insert_BK_to_ANNFEE == true)
                    {
                        //============= MOVE SUBSCRIBER NOT ENOUGH BALANCE TO NEXT DAY ===============
                        //bool Move_to_nextday = _InsertMB_FEE_toNextday(txtupload.Text, txtnextupload.Text, D_servtype.Text, txtUSDKHR.Text, txtUSDTHB.Text, d_f_brncode.SelectedValue, d_t_brncode.Text);
                        //if (Move_to_nextday == true)
                        //{
                            //====== REMOVE LAST_RETRY='Y' FROM FEE TABLE ======
                            bool Update_retry = _updateLastRetryMB(txtupload.Text, D_servtype.Text, txtUSDKHR.Text, txtUSDTHB.Text, d_f_brncode.SelectedValue, d_t_brncode.Text);

                            if (Update_retry == true)
                            {
                                ShowMessage("Processed Success please go to the next step!", MessageType.Success);
                            }

                            if (Update_retry == false)
                            {
                                ShowMessage("THere is no record to update", MessageType.Success);
                            }
                            return Update_retry;
                        }
                        //if (Move_to_nextday == false)
                        //{
                        //    ShowMessage("Error Move Data to the next day", MessageType.Error);
                        //}
                        //return Move_to_nextday;
                    //}
                    if (insert_BK_to_ANNFEE == false)
                    {
                        ShowMessage("Error Delete record in MOBILEBANKING_ANNUAL_FEE", MessageType.Error);
                    }
                    return insert_BK_to_ANNFEE;
                }
                if (insert_retval == false)

                {
                    ShowMessage("INsert record into FEE_BACKUP_MOBILEBANKING fail !", MessageType.Error);
                }

                return insert_retval;

            }

        if (retval == false)
        {
            ShowMessage("please check it again", MessageType.Error);
        }
        return retval;
    }
    protected void Linkbtnapply_Click(object sender, EventArgs e)
    {
        _FEEDashboard.dateupload = txtupload.Text;
        _FEEDashboard.Service = D_servtype.Text;
        _FEEDashboard.P_BRN_FROM = d_f_brncode.SelectedValue;
        _FEEDashboard.P_BRN_TO = d_t_brncode.SelectedValue;
        _FEEDashboard.Exc_RateUSD = txtUSDKHR.Text;
        _FEEDashboard.Exc_RateTHB = txtUSDTHB.Text;
        _FEEDashboard.Exc_RateTHBKHR = txtTHBKHR.Text;
        _FEEDashboard.P_FILE_NAME = D_servtype.Text;
        Linkbtnapply.Enabled = false;
        d_f_brncode.Enabled = false;
        d_t_brncode.Enabled = false;
        if (D_servtype.Text == "A")
        {
            _Getexportexcel_A();
        }
        else if (D_servtype.Text =="M")
        {
            _Getexportexcel_M();
        }
        
    }
    protected void D_servtype_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (D_servtype.Text == "M")
        {
            _dropdown.bindDropDownList(d_f_brncode, _FEEDashboard.D_PR_BRN_MAINTENANCEFEE(txtupload.Text, D_servtype.Text));
        }
        else if (D_servtype.Text == "A")
        {
            _dropdown.bindDropDownList(d_f_brncode, _FEEDashboard.D_PR_BRNA_MAINTENANCEFEE());
        }

        
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
    protected void d_f_brncode_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (D_servtype.Text == "A")
        {
            _dropdown.bindDropDownList(d_t_brncode, _FEEDashboard.D_PR_BRNTOA_MAINTENANCEFEE());
        }
        if (D_servtype.Text == "M")
        {
            _dropdown.bindDropDownList(d_t_brncode, _FEEDashboard.D_PR_BRNTO_MAINTENANCEFEE());
        }

        
    }
    public bool _Pre_checking_script(string _uploadDate, string _service)
    {

        DataTable dt = new DataTable();
        try
        {
            obj2.ConnectionString = obj1.oracleconbo();
            obj2.Open();
            OracleCommand cmd = new OracleCommand("PR_Pre_checking_script", obj2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DATEUPLOAD", _uploadDate);
            cmd.Parameters.AddWithValue("SERVICE", _service);
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            dt.Load(cmd.ExecuteReader());

            //int retval = Convert.ToInt32(cmd.Parameters["o_cursor"].Value); //This will 1 or 0
            int retval = dt.Rows.Count;
            if (retval > 0)
            {
                 return true;
               //return false;
            }

            else
            {
                //return true;
                return true;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            return false;
        }
        finally
        {
            obj2.Close();
            obj2.Dispose();
            OracleConnection.ClearPool(obj2);
        }
    }
    public bool _Pre_delete_checking_script(string _uploadDate, string _service)
    {

        DataTable dt = new DataTable();
        try
        {
            obj2.ConnectionString = obj1.oracleconbo();
            obj2.Open();
            OracleCommand cmd = new OracleCommand("PR_delete_Prechecking", obj2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("DATEUPLOAD", _uploadDate);
            cmd.Parameters.AddWithValue("SERVICE", _service);
            cmd.Parameters.Add("P_retval", OracleType.Int32, 8).Direction = ParameterDirection.Output;
            dt.Load(cmd.ExecuteReader());

            int retval = Convert.ToInt32(cmd.Parameters["P_retval"].Value); //This will 1 or 0
            //int retval = dt.Rows.Count;
            if (retval > 0)
            {
                return true;   
            }

            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            return false;
        }
        finally
        {
            obj2.Close();
            obj2.Dispose();
            OracleConnection.ClearPool(obj2);
        }
    }
    public bool _Pre_update_checking_script(string _uploadDate, string _service)
    {

        DataTable dt = new DataTable();
        try
        {
            obj2.ConnectionString = obj1.oracleconbo();
            obj2.Open();
            OracleCommand cmd = new OracleCommand("PR_Update_Prechecking", obj2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_UPLOAD_DATE", _uploadDate);
            cmd.Parameters.AddWithValue("SERVICE", _service);
            cmd.Parameters.Add("P_retval", OracleType.Int32, 8).Direction = ParameterDirection.Output;
            dt.Load(cmd.ExecuteReader());

            int retval = Convert.ToInt32(cmd.Parameters["P_retval"].Value); //This will 1 or 0
            if (retval > 0)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            return false;
        }
        finally
        {
            obj2.Close();
            obj2.Dispose();
            OracleConnection.ClearPool(obj2);
        }
    }
    public bool _InsertBKMB_FEE(string _uploadDate, string _service, string _Fromdate , string _Todate)
    {

        DataTable dt = new DataTable();
        try
        {
            obj2.ConnectionString = obj1.oracleconbo();
            obj2.Open();
            OracleCommand cmd = new OracleCommand("PR_INSERTBKMB_FEE", obj2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_UPLOAD_DATE", _uploadDate);
            cmd.Parameters.AddWithValue("P_SERV_TYPE", _service);
            cmd.Parameters.AddWithValue("P_BRN_FROM", _Fromdate);
            cmd.Parameters.AddWithValue("P_BRN_TO", _Todate);
            cmd.Parameters.Add("P_retval", OracleType.Int32, 8).Direction = ParameterDirection.Output;
            dt.Load(cmd.ExecuteReader());

            int retval = Convert.ToInt32(cmd.Parameters["P_retval"].Value); //This will 1 or 0
            if (retval > 0)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            return false;
        }
        finally
        {
            obj2.Close();
            obj2.Dispose();
            OracleConnection.ClearPool(obj2);
        }
    }
    public bool _delete_MB_annualbyUpload(string _uploadDate, string _service, string _Fromdate, string _Todate)
    {
        /// WHen insert record into table backup annual fee and then delelte table Mobile annual by upload date
        DataTable dt = new DataTable();
        try
        {
            obj2.ConnectionString = obj1.oracleconbo();
            obj2.Open();
            OracleCommand cmd = new OracleCommand("PR_DELETEUPLOADMB_FEE", obj2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_UPLOAD_DATE", _uploadDate);
            cmd.Parameters.AddWithValue("P_SERV_TYPE", _service);
            cmd.Parameters.AddWithValue("P_BRN_FROM", _Fromdate);
            cmd.Parameters.AddWithValue("P_BRN_TO", _Todate);
            cmd.Parameters.Add("P_retval", OracleType.Int32, 8).Direction = ParameterDirection.Output;
            dt.Load(cmd.ExecuteReader());

            int retval = Convert.ToInt32(cmd.Parameters["P_retval"].Value); //This will 1 or 0
            if (retval > 0)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            return false;
        }
        finally
        {
            obj2.Close();
            obj2.Dispose();
            OracleConnection.ClearPool(obj2);
        }
    }
    public bool _InsertMB_FEE_from_BK(string _uploadDate, string _service, string _Fromdate, string _Todate)
    {
        ////'====== MOVE NEW REFRESH DATA BACK TO FEE TABLE ======
        DataTable dt = new DataTable();
        try
        {
            obj2.ConnectionString = obj1.oracleconbo();
            obj2.Open();
            OracleCommand cmd = new OracleCommand("PR_INSERTANNMB_FEE", obj2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_UPLOAD_DATE", _uploadDate);
            cmd.Parameters.AddWithValue("P_SERV_TYPE", _service);
            cmd.Parameters.AddWithValue("P_BRN_FROM", _Fromdate);
            cmd.Parameters.AddWithValue("P_BRN_TO", _Todate);
            cmd.Parameters.Add("P_retval", OracleType.Int32, 8).Direction = ParameterDirection.Output;
            dt.Load(cmd.ExecuteReader());

            int retval = Convert.ToInt32(cmd.Parameters["P_retval"].Value); //This will 1 or 0
            if (retval > 0)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            return false;
        }
        finally
        {
            obj2.Close();
            obj2.Dispose();
            OracleConnection.ClearPool(obj2);
        }
    }
    public bool _InsertMB_FEE_toNextday(string _uploadDate,string _nextuploaddate, string _service,string _ex_rateUSD,string _ex_rateTHB, string _Fromdate, string _Todate)
    {
        //'============= MOVE SUBSCRIBER NOT ENOUGH BALANCE TO NEXT DAY ===============
        DataTable dt = new DataTable();
        try
        {
            obj2.ConnectionString = obj1.oracleconbo();
            obj2.Open();
            OracleCommand cmd = new OracleCommand("PR_INSERTMB_NEXTDAY", obj2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_UPLOAD_DATE", _uploadDate);
            cmd.Parameters.AddWithValue("NEXT_DATE_TO_UPLOAD", _nextuploaddate);
            cmd.Parameters.AddWithValue("P_SERV_TYPE", _service);
            cmd.Parameters.AddWithValue("Exc_RateUSD", _ex_rateUSD);
            cmd.Parameters.AddWithValue("Exc_RateTHB", _ex_rateTHB);
            cmd.Parameters.AddWithValue("P_BRN_FROM", _Fromdate);
            cmd.Parameters.AddWithValue("P_BRN_TO", _Todate);
            cmd.Parameters.Add("P_retval", OracleType.Int32, 8).Direction = ParameterDirection.Output;
            dt.Load(cmd.ExecuteReader());

            int retval = Convert.ToInt32(cmd.Parameters["P_retval"].Value); //This will 1 or 0
            if (retval > 0)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            return false;
        }
        finally
        {
            obj2.Close();
            obj2.Dispose();
            OracleConnection.ClearPool(obj2);
        }
    }
    public bool _updateLastRetryMB(string _uploadDate,  string _service, string _ex_rateUSD, string _ex_rateTHB, string _Fromdate, string _Todate)
    {
        //'====== REMOVE LAST_RETRY='Y' FROM FEE TABLE ======
        DataTable dt = new DataTable();
        try
        {
            obj2.ConnectionString = obj1.oracleconbo();
            obj2.Open();
            OracleCommand cmd = new OracleCommand("PR_UPDATELASTRETRYMB_FEE", obj2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_UPLOAD_DATE", _uploadDate);
            cmd.Parameters.AddWithValue("P_SERV_TYPE", _service);
            cmd.Parameters.AddWithValue("P_BRN_FROM", _Fromdate);
            cmd.Parameters.AddWithValue("P_BRN_TO", _Todate);
            cmd.Parameters.AddWithValue("Exc_RateUSD", _ex_rateUSD);
            cmd.Parameters.AddWithValue("Exc_RateTHB", _ex_rateTHB);
            
            cmd.Parameters.Add("P_retval", OracleType.Int32, 8).Direction = ParameterDirection.Output;
            dt.Load(cmd.ExecuteReader());

            int retval = Convert.ToInt32(cmd.Parameters["P_retval"].Value); //This will 1 or 0
            if (retval > 0)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            return false;
        }
        finally
        {
            obj2.Close();
            obj2.Dispose();
            OracleConnection.ClearPool(obj2);
        }
    }
    public bool _UPDATESTATUS_FEE(string _uploadDate, string _service, string _ex_rateUSD, string _ex_rateTHB, string _Fromdate, string _Todate)
    {
        //'====== REMOVE LAST_RETRY='Y' FROM FEE TABLE ======
        DataTable dt = new DataTable();
        try
        {
            obj2.ConnectionString = obj1.oracleconbo();
            obj2.Open();
            OracleCommand cmd = new OracleCommand("PR_UPDATESTATUS_FEE", obj2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_UPLOAD_DATE", _uploadDate);
            cmd.Parameters.AddWithValue("P_SERV_TYPE", _service);
            cmd.Parameters.AddWithValue("P_BRN_FROM", _Fromdate);
            cmd.Parameters.AddWithValue("P_BRN_TO", _Todate);
            cmd.Parameters.AddWithValue("Exc_RateUSD", _ex_rateUSD);
            cmd.Parameters.AddWithValue("Exc_RateTHB", _ex_rateTHB);

            cmd.Parameters.Add("P_retval", OracleType.Int32, 8).Direction = ParameterDirection.Output;
            dt.Load(cmd.ExecuteReader());

            int retval = Convert.ToInt32(cmd.Parameters["P_retval"].Value); //This will 1 or 0
            if (retval > 0)
            {
                return true;
            }

            else
            {
                return false;
            }

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            return false;
        }
        finally
        {
            obj2.Close();
            obj2.Dispose();
            OracleConnection.ClearPool(obj2);
        }
    }
    public void _exporttoexcelMBFEE()
    {
        _FEEDashboard.Exc_RateUSD = txtUSDKHR.Text;
        _FEEDashboard.Exc_RateTHBKHR = txtTHBKHR.Text;
        _FEEDashboard.Exc_RateTHB = txtUSDTHB.Text;
        _FEEDashboard.P_BRN_FROM =  d_f_brncode.SelectedValue;
        _FEEDashboard.P_BRN_TO =   d_t_brncode.SelectedValue;
        _FEEDashboard.dateupload = txtupload.Text;
        _FEEDashboard.previousdate = DateTime.Now.AddDays(-1).ToString("dd/MMM/yyyy").Replace('/', '-');
        _FEEDashboard.P_FILE_NAME = D_servtype.Text;

        XLWorkbook wb = new XLWorkbook();

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        DataTable dt2 = new DataTable();
        //DataTable dt3 = new DataTable();
        //DataTable dt4 = new DataTable();
        //DataTable dt5 = new DataTable();
        //DataTable dt6 = new DataTable();
        //DataTable dt7 = new DataTable();
        //DataTable dt8 = new DataTable();
        //DataTable dt9 = new DataTable();
        dt = _FEEDashboard.D_ATMMB_ANNUAL_FEE();
        dt1 = _FEEDashboard.D_DETAILS_SHEET_CREDIT();
        dt2 = _FEEDashboard.D_DETAILS_SHEET_DEBIT();
        //dt3 = _FEEDashboard.D_StringACCCLOSED();
        //dt4 = _FEEDashboard.D_StringChargedListing();
        //dt5 = _FEEDashboard.D_StringDORMANT();
        //dt6 = _FEEDashboard.D_StringNotEnoughBalance();
        //dt7 = _FEEDashboard.D_StringSTAT_NO_DR();
        //dt8 = _FEEDashboard.D_StringTPBLOCK_PER_MONTH();
        //dt9 = _FEEDashboard.D_StringUnregistered();

        wb.Worksheets.Add(dt, "ATMMB_ANNUAL_FEE");
        wb.Worksheets.Add(dt1, "DETAILS_SHT_CREDIT");
        wb.Worksheets.Add(dt2, "DETAILS_SHT_DEBIT");
        //wb.Worksheets.Add(dt3, "StACCCLOSED");
        //wb.Worksheets.Add(dt4, "StChargedListing");
        //wb.Worksheets.Add(dt5, "StDORMANT");
        //wb.Worksheets.Add(dt6, "StNotEnoughBalance");
        //wb.Worksheets.Add(dt7, "StSTAT_NO_DR");
        //wb.Worksheets.Add(dt8, "StTPBLOCK_PER_MONTH");
        //wb.Worksheets.Add(dt9, "StUnregistered");



        bool Update_is_upload = _UPDATESTATUS_FEE(txtupload.Text, D_servtype.Text, txtUSDKHR.Text, txtUSDTHB.Text, d_f_brncode.SelectedValue, d_t_brncode.Text);
        if (Update_is_upload == true)
        {
            bool Move_to_nextday = _InsertMB_FEE_toNextday(txtupload.Text, txtnextupload.Text, D_servtype.Text, txtUSDKHR.Text, txtUSDTHB.Text, d_f_brncode.SelectedValue, d_t_brncode.Text);

            if (Move_to_nextday == true)
            {
                ShowMessage("Process Uploaded Successful", MessageType.Success);
            }

            else if (Move_to_nextday == false)
            {
                ShowMessage("Processed error _InsertMB_FEE_toNextday !", MessageType.Error);
            }

        }
        else if (Update_is_upload == false)
        {
            ShowMessage("Error Update Status Upload = 1", MessageType.Error);
        }

        Response.Clear();
        Response.Buffer = true;
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename="+ Txtgeneratedate.Text + "MaintenanceFEE.xlsx");
        System.IO.MemoryStream memory = new System.IO.MemoryStream();
        wb.SaveAs(memory);
        memory.WriteTo(Response.OutputStream);
        Response.Flush();
        Response.End();

    }

    protected void generate_click(object sender, EventArgs e)
    {
        _exporttoexcelMBFEE();
    }

    protected void LinkEdit_Click(object sender, EventArgs e)
    {
        Linkbtnapply.Enabled = true;
    }
}