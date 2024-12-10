using System.Data.SqlClient;
using System.Data;
using System;
using System.IO;

/// <summary>
/// Summary description for MissionDashBoard
/// </summary>
public class MissionDashBoard
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _message { get; set; }
    public string _branch_name { get; set; }
    public string _terminal { get; set; }
    public string _product_type { get; set; }
    public string _model_type { get; set; }
    public string _problem_type { get; set; }
    public string _equitment { get; set; }
    public string _start_date { get; set; }
    public string _end_date { get; set; }
    public string _day { get; set; }
    public string _night { get; set; }
    public string _name_1 { get; set; }
    public string _position1 { get; set; }
    public string _company1 { get; set; }
    public string _phone1 { get; set; }
    public string _staff_id1 { get; set; }
    public string _gender1 { get; set; }
    public string _name_2 { get; set; }
    public string _position2 { get; set; }
    public string _company2 { get; set; }
    public string _phone2 { get; set; }
    public string _staff_id2 { get; set; }
    public string _gender2 { get; set; }
    public string _Status { get; set; }
    public string _Problem_desc { get; set; }
    public string _username { get; set; }
    public string _ticketno { get; set; }
    public string _getTicketno { get; set; }
    public string _sdate { get; set; }
    public string _edate { get; set; }
    public string _solution { get; set; }

    public DataTable D_branch_name()
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Stored("Branch_name_Webreport", ref cmd);
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _message = ex.Message;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
    }
    public DataTable D_problem_type()
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Stored("P_problem_type_mission", ref cmd);
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _message = ex.Message;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
    }
    public DataTable D_FC_STAFFNAME()
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Stored("PR_FC_staffName", ref cmd);
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _message = ex.Message;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
    }
    public DataTable D_FC_Fundamental(string ID_CARD)
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Stored("P_fc_name_ticket", ref cmd);
            cmd.Parameters.AddWithValue("@ID_CARD", ID_CARD);
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _message = ex.Message;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
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
    public DataTable D_getGridmissionindex()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored("Mission_index", ref cmd);
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
    public DataTable D_Mission_Fundamentals(string _ticket_No)
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored("Mission_edit", ref cmd);
            cmd.Parameters.AddWithValue("@ticket_no", _ticket_No);
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
    public DataTable D_MissionView_Fundamentals(string _ticket_No)
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_ticketmissionFundamentals", ref cmd);
            cmd.Parameters.AddWithValue("@ticket_no", _ticket_No);
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
    public DataTable D_Missiondelete_Fundamentals(string _ticket_No)
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored("Mission_delete", ref cmd);
            cmd.Parameters.AddWithValue("@Ticket_no", _ticket_No);
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
    public DataTable D_mission_printFuncdamentals(string _ticket_No)
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored("Mission_PrintFundamentals", ref cmd);
            cmd.Parameters.AddWithValue("@ticket_no", _ticket_No);
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
    public DataTable D_Mission_Terminal_info(string _terminal)
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored("P_Branch_name_sub_Mission", ref cmd);
            cmd.Parameters.AddWithValue("@Terminal", _terminal);
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
    public DataTable D_Mission_get_Terminal(string _branchCode)
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored("P_bind_Terminal_mission", ref cmd);
            cmd.Parameters.AddWithValue("@Branches_Name", _branchCode);
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
    public DataTable D_get_AutoIncrementID()
    {
        DataTable dt1 = new DataTable();
        try
        {
            string query = "SELECT ISNULL(MAX(ID_AUTO),0) + 1 from tblproblems";
            _sqlcom._command_Query(query, ref cmd);
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
    private string AutoIncrementID()
    {

        string query = "PR_Autoincrementid_mission";
        _sqlcom._command_Stored(query, ref cmd);
        SqlDataReader dr = cmd.ExecuteReader();
        string id = null;
        if (dr.Read())
        {
            id = dr[0].ToString();
        }
        sqlc.Close();
        sqlc.Dispose();
        SqlConnection.ClearPool(sqlc);
        return id;
    }
    public bool Register_mission()
    {
        try
        {
            string id = AutoIncrementID();
            int idLimit = 7;
            string ticket = "CBD-" + ZeroAppend("0000000" + id, idLimit);
            _sqlcom._command_Stored("P_register_mission", ref cmd);
            cmd.Parameters.AddWithValue("@Ticket_no", ticket);
            cmd.Parameters.AddWithValue("@Branch_name", _branch_name);
            cmd.Parameters.AddWithValue("@Terminal", _terminal);
            cmd.Parameters.AddWithValue("@Product_Type", _product_type);
            cmd.Parameters.AddWithValue("@Model_type", _model_type);
            cmd.Parameters.AddWithValue("@Problem_type", _problem_type);
            cmd.Parameters.AddWithValue("@Problem_desc", _Problem_desc);
            cmd.Parameters.AddWithValue("@Equitment", _equitment);
            cmd.Parameters.AddWithValue("@Start_Date", _start_date);
            cmd.Parameters.AddWithValue("@End_Date", _end_date);
            cmd.Parameters.AddWithValue("@Miss_day", _day);
            cmd.Parameters.AddWithValue("@Miss_night", _night);
            cmd.Parameters.AddWithValue("@Name1", _name_1);
            //cmd.Parameters.Add("@Position1", SqlDbType.NVarChar, 255);
            //cmd.Parameters["@Position1"].Value = _position1;
            cmd.Parameters.AddWithValue("@Company1", _company1);
            cmd.Parameters.AddWithValue("@Phone1", _phone1);
            cmd.Parameters.AddWithValue("@Staff_ID1", _staff_id1);
            cmd.Parameters.AddWithValue("@Gender1", _gender1);
            cmd.Parameters.AddWithValue("@Name2", _name_2);
            //cmd.Parameters.Add("@Position2", SqlDbType.NVarChar,255);
            //cmd.Parameters["@Position2"].Value = _position2;
            cmd.Parameters.AddWithValue("@Company2", _company2);
            cmd.Parameters.AddWithValue("@Phone2", _phone2);
            cmd.Parameters.AddWithValue("@Staff_ID2", _staff_id2);
            cmd.Parameters.AddWithValue("@Gender2", _gender2);
            cmd.Parameters.AddWithValue("@status", _Status);
            cmd.Parameters.AddWithValue("@User_Name", _username);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 20).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            string retval = cmd.Parameters["@retval"].Value.ToString();
            _getTicketno = retval;
            if (retval !="")
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
            _message = ex.Message  ;
            return false;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }


    }
    public bool ticketMission_register()
    {
        try
        {
            
            _sqlcom._command_Stored("PR_ticketmissionregister", ref cmd);
            cmd.Parameters.AddWithValue("@Ticket_no", _ticketno);
            cmd.Parameters.AddWithValue("@Branch_name", _branch_name);
            cmd.Parameters.AddWithValue("@Terminal", _terminal);
            cmd.Parameters.AddWithValue("@Product_Type", _product_type);
            cmd.Parameters.AddWithValue("@Model_type", _model_type);
            cmd.Parameters.AddWithValue("@Problem_type", _problem_type);
            cmd.Parameters.AddWithValue("@Problem_desc", _Problem_desc);
            cmd.Parameters.AddWithValue("@Equitment", _equitment);
            cmd.Parameters.AddWithValue("@Start_Date", _start_date);
            cmd.Parameters.AddWithValue("@End_Date", _end_date);
            cmd.Parameters.AddWithValue("@Miss_day", _day);
            cmd.Parameters.AddWithValue("@Miss_night", _night);
            cmd.Parameters.AddWithValue("@Name1", _name_1);
            //cmd.Parameters.Add("@Position1", SqlDbType.NVarChar, 255);
            //cmd.Parameters["@Position1"].Value = _position1;
            cmd.Parameters.AddWithValue("@Company1", _company1);
            cmd.Parameters.AddWithValue("@Phone1", _phone1);
            cmd.Parameters.AddWithValue("@Staff_ID1", _staff_id1);
            cmd.Parameters.AddWithValue("@Gender1", _gender1);
            cmd.Parameters.AddWithValue("@Name2", _name_2);
            //cmd.Parameters.Add("@Position2", SqlDbType.NVarChar,255);
            //cmd.Parameters["@Position2"].Value = _position2;
            cmd.Parameters.AddWithValue("@Company2", _company2);
            cmd.Parameters.AddWithValue("@Phone2", _phone2);
            cmd.Parameters.AddWithValue("@Staff_ID2", _staff_id2);
            cmd.Parameters.AddWithValue("@Gender2", _gender2);
            cmd.Parameters.AddWithValue("@status", _Status);
            cmd.Parameters.AddWithValue("@User_Name", _username);
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
    public DataTable _getMissionFundamentals(string eventid)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("MissionFundamentals", ref cmd);
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
    public bool Delete_mission(string _ticket)
    {
        try
        {
            _sqlcom._command_Stored("delete_issue_pending", ref cmd);
            cmd.Parameters.AddWithValue("@ticket_no", _ticket);
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
    public bool _update_status_mission()
    {
        try
        {
            _sqlcom._command_Stored("Update_Status_mission", ref cmd);
            cmd.Parameters.AddWithValue("@ID_AUTO", _ticketno);
            cmd.Parameters.AddWithValue("@start_date", _sdate);
            cmd.Parameters.AddWithValue("@end_date", _edate);
            cmd.Parameters.AddWithValue("@solution", _solution);
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
    public DataTable RP_MISSION_LISTING()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored("RP_ATMMission", ref cmd);
            cmd.Parameters.AddWithValue("@Branch_name", _branch_name);
            cmd.Parameters.AddWithValue("@Terminal", _terminal);
            cmd.Parameters.AddWithValue("@start_date", _start_date);
            cmd.Parameters.AddWithValue("@End_date", _end_date);
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

    public DataTable _Getmissionday()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select dbo.GetMissionDays("+ _start_date + ","+_end_date +")";
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