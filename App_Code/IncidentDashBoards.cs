using System;
using TicketClassLibrary;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for IncidentDashBoard
/// </summary>
public class IncidentDashBoards
{
    ticketconnection obj2 = new ticketconnection();
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _message { get; set; }
    public string _getmsg { get; set; }
    public string _getticket { get; set; }
    public string _ReasonGroupID { get; set; }
    public string _ReasonShortDesc { get; set; }
    public string _reasonfulldesc { get; set; }
    public string _userad { get; set; }

    public DataTable D_getReasons()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.ReasonTypeID as ReasonTypeID,a.ReasonFullDesc as Reason  from NodeDownReason a", ref cmd);
            dt1.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt1;
    }
    public DataTable D_getReasons_MB()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.ReasonTypeID as ReasonTypeID,a.ReasonFullDesc as Reason  from NodeDownReason a", ref cmd);
            dt1.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt1;
    }
    public DataTable D_getReasonGroup()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.GroupTypeID,a.GFullDesc as ReasonGroupDesc from NodeGroupReason a", ref cmd);
            dt1.Load(cmd.ExecuteReader());
        }

        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt1;
    }
    public DataTable D_getReasonTypes(string strReasonGroupID)
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.ReasonTypeID as ReasonTypeID,a.ReasonFullDesc as Reason from NodeDownReason a where a.ReasonGroupID =isnull (@ReasonGroupID,'ReasonGroupID')", ref cmd);
            cmd.Parameters.AddWithValue("@ReasonGroupID", strReasonGroupID);
            dt1.Load(cmd.ExecuteReader());

        }

        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt1;
    }
    public DataTable D_getReasonGroup_MB()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.GroupTypeID,a.GFullDesc as ReasonGroupDesc from NodeGroupReason a Where a.GroupTypeID in (10,11)", ref cmd);
            dt1.Load(cmd.ExecuteReader());
        }

        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt1;
    }
    public DataTable D_getReasonTypes_MB(string strReasonGroupID)
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.ReasonTypeID as ReasonTypeID,a.ReasonFullDesc as Reason from NodeDownReason a where a.ReasonGroupID =isnull (@ReasonGroupID,'ReasonGroupID')", ref cmd);
            cmd.Parameters.AddWithValue("@ReasonGroupID", strReasonGroupID);
            dt1.Load(cmd.ExecuteReader());

        }

        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt1;
    }
    public string AutoIncrementID()
    {

        _sqlcom._command_Stored("P_max_ID", ref cmd);
        SqlDataReader dr = cmd.ExecuteReader();
        string id = null;
        if (dr.Read())
        {
            id = dr[0].ToString();
        }
        sqlc.Close();
        return id;
    }
    public DataTable D_getActions()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.ActionTypeID,a.ActionTypeDesc from NodeDownActionType a", ref cmd);
            dt1.Load(cmd.ExecuteReader());

        }

        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt1;
    }
    public DataTable D_Select_getActions()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.ActionTypeID,a.ActionTypeDesc from NodeDownActionType a Where a.ActionTypeID = '1'", ref cmd);
            dt1.Load(cmd.ExecuteReader());

        }

        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt1;
    }
    public static string ZeroAppend(string data, int idLimit)
    {
        return data.Substring(data.Length - idLimit);
    }
    public bool _update_Ticket(string solution , string status , string start_date, string end_date , string branch_name, string problem_type , string Source_Issue ,string ticket_no,string _userlog,string _description)
    {
        try
        {
            _sqlcom._command_Stored("update_issue_pending", ref cmd);
            cmd.Parameters.AddWithValue("@Solution", solution);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@Start_date", start_date);
            cmd.Parameters.AddWithValue("@End_Date", end_date);
            cmd.Parameters.AddWithValue("@Branch_Name", branch_name);
            cmd.Parameters.AddWithValue("@Problem_Type", problem_type);
            cmd.Parameters.AddWithValue("@Decription", _description);
            cmd.Parameters.AddWithValue("@Source_Issue", Source_Issue);
            cmd.Parameters.AddWithValue("@ticket_no", ticket_no);
            cmd.Parameters.AddWithValue("@User_log", _userlog);
            cmd.Parameters.Add("@retval", SqlDbType.Int, 8).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0

            if (retval >= 1)
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
            _message = ex.Message;
            return false;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _Delete_ticket(string ticket_no)
    {
        try
        {
            _sqlcom._command_Stored("delete_issue_pending", ref cmd);
            cmd.Parameters.AddWithValue("@ticket_no", ticket_no);
            cmd.Parameters.Add("@retval", SqlDbType.Int, 8).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0

            if (retval >= 1)
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
            _message = ex.Message;
            return false;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _Ticket_register(string T_channel, string D_branch_name, string T_Product_type, string T_Terminal,
                                       string T_start_date  //, string D_Root_of_issue
                                       ,string t_inform,string D_status, string t_user_input, string t_Decription, string t_Solution,
                                       string t_end_date, string D_Source_Issue, string d_assign_to,
                                       string t_Part_Decription, string t_ATM_serial,
                                       string t_Part_Serial, string t_Issue_date,string d_Cause_of_issue,
                                       string _userLog , string _supportby )
    {
        try
        {
            DataTable dr = _getAutoIncrementID();
            string _ID = dr.Rows[0][0].ToString();
            //string _ID = AutoIncrementID();
            int _IdLimit = 7;
            string _ticketNo = "CBD-" + ZeroAppend("0000000" + _ID, _IdLimit);
            _sqlcom._command_Stored("RegisterIssue1", ref cmd);
            cmd.Parameters.AddWithValue("@Product_Name", T_channel);
            cmd.Parameters.AddWithValue("@Branch_Name", D_branch_name);
            cmd.Parameters.AddWithValue("@Product_Type", T_Product_type);
            cmd.Parameters.AddWithValue("@Terminal", T_Terminal);
            cmd.Parameters.AddWithValue("@Start_Date", T_start_date);
            cmd.Parameters.AddWithValue("@Problem_Type", d_Cause_of_issue);
            cmd.Parameters.AddWithValue("@Contact", t_inform);
            cmd.Parameters.AddWithValue("@Status", D_status);
            cmd.Parameters.AddWithValue("@User_Name", t_user_input);
            cmd.Parameters.AddWithValue("@Decription", t_Decription);
            cmd.Parameters.AddWithValue("@Solution", t_Solution);
            cmd.Parameters.AddWithValue("@End_Date", t_end_date);
            cmd.Parameters.AddWithValue("@Source_Issue", D_Source_Issue);
            cmd.Parameters.AddWithValue("@Assign_To", d_assign_to);
            cmd.Parameters.AddWithValue("@Part_Decription", t_Part_Decription);
            cmd.Parameters.AddWithValue("@ATM_Serial", t_ATM_serial);
            cmd.Parameters.AddWithValue("@Part_Serail", t_Part_Serial);
            cmd.Parameters.AddWithValue("@Issue_Date", t_Issue_date);
            cmd.Parameters.AddWithValue("@Ticket_no", _ticketNo);
            cmd.Parameters.AddWithValue("@user_log", _userLog);
            cmd.Parameters.AddWithValue("@Supportby", _supportby);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string retval = cmd.Parameters["@retval"].Value.ToString();
            _getticket = retval;
            if (retval != "")
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
            _message = ex.Message;
            return false;
            
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }

    public DataTable _getViewFundamentals(string eventid)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("bindgrid_view", ref cmd);
            cmd.Parameters.AddWithValue("@ticket_no", eventid);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }   
    public DataTable _Get_Terminal(string _branchID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_Bind_Terminal", ref cmd);
            cmd.Parameters.AddWithValue("@Branches_Code", _branchID);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _Get_Terminal_01(string _channel,string _branchID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_Bind_Terminal_01", ref cmd);
            cmd.Parameters.AddWithValue("@product_code", _channel);
            cmd.Parameters.AddWithValue("@Branches_Code", _branchID);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }

    public DataTable _Get_Terminal_02(string _branchID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_Bind_Terminal_02", ref cmd);
            cmd.Parameters.AddWithValue("@Branches_Code", _branchID);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }

    public DataTable _Get_BranchName()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_Bind_BranchName", ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _Get_BranchName_01()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_Bind_BranchName_01", ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _Get_BranchName_02()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_Bind_BranchName_02", ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _Get_Terminal_Fundamental(string _Terminal)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_Terminal_Ticket_Fundamental", ref cmd);
            cmd.Parameters.AddWithValue("@TID", _Terminal);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _get_EditFundamentals(string _Ticket_NO)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("updateissuepending", ref cmd);
            cmd.Parameters.AddWithValue("@ticket_no", _Ticket_NO);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _get_DeleteFundamentals(string _Ticket_NO)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("deleteissuepending", ref cmd);
            cmd.Parameters.AddWithValue("@ticket_no", _Ticket_NO);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _GridTicketindex()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("Form_register_GridView", ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _GridTicketView( string _TicketNo)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("P_bind_grid_ticket_his", ref cmd);
            cmd.Parameters.AddWithValue("@ID_AUTO", _TicketNo);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _getServiceChannel()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("P_bind_service_new_ticket", ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _getUserticket()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("P_bind_user_name_new_ticket", ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _getUserticketLoad(string _getempid)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select a.EmployeeID ,a.FullName as username from v_employeeui a where DeptID = 'AMD1' and a.EmployeeID = "+ _getempid + "  order by GradeID";

            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _getAutoIncrementID()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SELECT ISNULL(MAX(ID_AUTO),0) + 1 from tblproblems";
            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _getticketuser()
    {
        DataTable dt = new DataTable();
        try
        {
            
            _sqlcom._command_Stored("PR_Bind_ticketuser", ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _Getgrididexbyuser(string UserID)
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Stored("P_Issue_pending_by_User", ref cmd);
            cmd.Parameters.AddWithValue("@User_name", UserID);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _GetvendorIDDDL()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select A.VendorID , A.VendorDESC from tbl_Vendor a Where A.VendorStatusID = 'ACT'";
            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _GetFC_STAFF_DDL()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_FC_staffName";
            _sqlcom._command_Stored(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }

    public DataTable _GetBP_STAFF_DDL()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_BP_staffName";
            _sqlcom._command_Stored(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }

    public DataTable _Get_NodeGroupReason()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_NodeGroupReason";
            _sqlcom._command_Stored(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public DataTable _Get_NodeDownReason()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_NodeDownReason";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@ReasonGroupID", _ReasonGroupID);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }
    public bool _REG_NodeDownReason ()
    {
        try 
        {
            DataTable dr = _get_Max_id_Nodedown_reason();
            string _ID = dr.Rows[0][0].ToString();
            _sqlcom._command_Stored("PR_REG_NodeDownReason", ref cmd);
            cmd.Parameters.AddWithValue("@ReasonTypeID", _ID);
            cmd.Parameters.AddWithValue("@ReasonShortDesc", _ReasonShortDesc);
            cmd.Parameters.AddWithValue("@reasonfulldesc", _reasonfulldesc);
            cmd.Parameters.AddWithValue("@ReasonGroupID", _ReasonGroupID);
            cmd.Parameters.AddWithValue("@createdby", _userad);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            string retval = cmd.Parameters["@retval"].Value.ToString();
            _getticket = retval;
            if (retval != "")
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
            _message = ex.Message;
            return false;

        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }

    public DataTable _get_Max_id_Nodedown_reason()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select max(a.ReasonTypeID) + 1 as Get_max_ID from NodeDownReason a";
            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;

    }


}