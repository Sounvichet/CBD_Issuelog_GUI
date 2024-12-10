using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MasterReportClass;
using System.Data;
using System.Data.OracleClient;
public partial class Payment_PMSISMT : System.Web.UI.Page
{
    MaintenanceFeeDashBoard _FEEDashboard = new MaintenanceFeeDashBoard();
    DropDownListValues _dropdown = new DropDownListValues();
    logger _logger = new logger();
    masterreport_connect obj1 = new masterreport_connect();
    OracleConnection obj2 = new OracleConnection();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            _Bind_FROM_BRN();
            _Bind_TO_BRN();
        }
    }
    public void _Bind_FROM_BRN()
    {
        _dropdown.bindDropDownList(d_FRM_BRN, _FEEDashboard.D_BRN_BINDING());
    }
    public void _Bind_TO_BRN()
    {
        _dropdown.bindDropDownList(d_TO_BRN, _FEEDashboard.D_BRN_BINDING());
    }


    public bool _Pre_insertdataintoATMCARD(string _registerDate, string P_from_brn, string P_to_brn)
    {

        DataTable dt = new DataTable();
        try
        {
            obj2.ConnectionString = obj1.oraclecon();
            obj2.Open();
            string query = "PR_Pre_check_insertATMCARD";
            OracleCommand cmd = new OracleCommand(query, obj2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_REG_DATE", _registerDate);
            cmd.Parameters.AddWithValue("P_FRM_BRN", P_from_brn);
            cmd.Parameters.AddWithValue("P_TO_BRN", P_to_brn);
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            dt.Load(cmd.ExecuteReader());

            //int retval = Convert.ToInt32(cmd.Parameters["o_cursor"].Value); //This will 1 or 0
            int retval = dt.Rows.Count;
            if (retval <= 4000)
            {
                return true;
                //return false;
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
    public bool _PRE_Check_BeforeInsert_BO(string _P_UPLOAD_DATE, string _P_SERV_TYPE, string _P_FRM_BRN, string _P_TO_BRN)
    {

        DataTable dt = new DataTable();
        try
        {
            obj2.ConnectionString = obj1.oracleconbo();
            obj2.Open();
            string query = "PR_Pre_check_beforeinsert";
            OracleCommand cmd = new OracleCommand(query, obj2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_UPLOAD_DATE", _P_UPLOAD_DATE);
            cmd.Parameters.AddWithValue("P_SERV_TYPE", _P_SERV_TYPE);
            cmd.Parameters.AddWithValue("P_BRN_FROM", _P_FRM_BRN);
            cmd.Parameters.AddWithValue("P_BRN_TO", _P_TO_BRN);
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            dt.Load(cmd.ExecuteReader());

            //int retval = Convert.ToInt32(cmd.Parameters["o_cursor"].Value); //This will 1 or 0
            int retval = dt.Rows.Count;
            if (retval > 1)
            {
                return false;
            }

            else
            {
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
    public void _insertDataForATMCARD()
    {
        DataTable dt = new DataTable();
        dt = _FEEDashboard.D_PRE_Check_InsertDATAForATMCARD(txtREGISTER.Text, d_FRM_BRN.SelectedValue, d_TO_BRN.SelectedValue);
        if (dt.Rows.Count <=4000)
        {
            string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            DataTable dtcheck = _FEEDashboard.D_PRE_Check_BeforeInsert_BO(currentdate, D_servtype.Text, d_FRM_BRN.SelectedValue, d_TO_BRN.SelectedValue);
            if (dtcheck.Rows.Count > 1)
            {
                ShowMessage("Data have existing record please try again", MessageType.Error);
            }
            else
            {
                bool _insert_ATMCARD = _PR_insert_MaintenanceFEE(txtREGISTER.Text, d_FRM_BRN.SelectedValue, d_TO_BRN.SelectedValue);
                if (_insert_ATMCARD == true)
                {
                    ShowMessage("Successful insert records into annual Fee", MessageType.Success);
                }
                else
                {
                    ShowMessage("Please check _PR_insert_MaintenanceFEE", MessageType.Error);
                }

            }
        }
        else
        {
            ShowMessage("Fail", MessageType.Error);
        }
    }
    public bool _WorkFlow_insertrecordATMCARD()
    {
        bool _precheckrecord = _Pre_insertdataintoATMCARD(txtREGISTER.Text, d_FRM_BRN.SelectedValue, d_TO_BRN.SelectedValue);

        if (_precheckrecord == true)
        {
            string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            bool _prebeforeinsert = _PRE_Check_BeforeInsert_BO(currentdate, D_servtype.Text, d_FRM_BRN.SelectedValue, d_TO_BRN.SelectedValue);

                if (_prebeforeinsert == true)  // record ture < 1
                {
                        bool _insert_ATMCARD = _PR_insert_MaintenanceFEE(txtREGISTER.Text, d_FRM_BRN.SelectedValue, d_TO_BRN.SelectedValue);
                        if (_insert_ATMCARD == true)
                        {
                            ShowMessage("Successful insert records into annual Fee", MessageType.Success);
                        }
                        else
                        {
                            ShowMessage("Please check _PR_insert_MaintenanceFEE", MessageType.Error);
                        }
                }
                else
                {
                    ShowMessage("Error _PRE_Check_BeforeInsert_BO", MessageType.Error);
                }
                return _prebeforeinsert;
        }
        else
        {
            ShowMessage("Error _WorkFlow_insertrecordATMCARD", MessageType.Error);
        }
        return _precheckrecord;

    }
    public void _insertDataForMobile()
    {
        DataTable dt = new DataTable();
        dt = _FEEDashboard.D_PRE_Check_InsertDATAForATMCARD(txtREGISTER.Text, d_FRM_BRN.SelectedValue, d_TO_BRN.SelectedValue);
        if (dt.Rows.Count <= 4000)
        {
            string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
            DataTable dtcheck = _FEEDashboard.D_PRE_Check_BeforeInsert_BO(currentdate, D_servtype.Text, d_FRM_BRN.SelectedValue, d_TO_BRN.SelectedValue);
            if (dtcheck.Rows.Count > 1)
            {
                ShowMessage("Data have existing record please try again", MessageType.Error);
            }
            else
            {
                bool _insert_ATMCARD = _PR_insert_MaintenanceFEE(txtREGISTER.Text, d_FRM_BRN.SelectedValue, d_TO_BRN.SelectedValue);
                if (_insert_ATMCARD == true)
                {
                    ShowMessage("Successful insert records into annual Fee", MessageType.Success);
                }
                else
                {
                    ShowMessage("Please check _PR_insert_MaintenanceFEE", MessageType.Error);
                }

            }
        }
        else
        {
            ShowMessage("Fail", MessageType.Error);
        }
    }
    protected void Linkbtnapply_Click(object sender, EventArgs e)
    {
        if (D_servtype.Text == "A")
        {
            // _insertDataForATMCARD();
            _WorkFlow_insertrecordATMCARD();

        }
        else if (D_servtype.Text == "M")
        {
            ShowMessage("Please Run script Manualy in PLSQL For Mobile", MessageType.Error);
        }
       
      
    }
    public bool _PR_insert_MaintenanceFEE(string P_REG_DATE, string P_FRM_BRN, string P_TO_BRN)
    {

        DataTable dt = new DataTable();
        try
        {
            obj2.ConnectionString = obj1.oraclecon();
            obj2.Open();
            OracleCommand cmd = new OracleCommand("PR_insert_MaintenanceFEE", obj2);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_REG_DATE", P_REG_DATE);
            cmd.Parameters.AddWithValue("P_FRM_BRN", P_FRM_BRN);
            cmd.Parameters.AddWithValue("P_TO_BRN", P_TO_BRN);
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

    protected void LinkEdit_Click(object sender, EventArgs e)
    {
        Linkbtnapply.Enabled = true;
    }

    

    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}