using System.Data.SqlClient;
using System.Data;
using System;

/// <summary>
/// Summary description for ComplaintDashBoard
/// </summary>
public class ComplaintDashBoard
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _msgerror { get; set; }

    public DataTable D_getGridcomplaint()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored("P_complain_grid", ref cmd);
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
    public DataTable D_getGridcomplaint_byUser(string _UserID)
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_Complain_pending_by_User", ref cmd);
            cmd.Parameters.AddWithValue("@User_name", _UserID);
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
    public DataTable D_complaintticketfundamental(string _UserID)
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored("updateissuepending", ref cmd);
            cmd.Parameters.AddWithValue("@ticket_no", _UserID);
            dt1.Load(cmd.ExecuteReader());

        }

        catch (Exception ex)
        {
            _logger.LogError(ex);
            _msgerror = ex.Message;
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt1;
    }
    public bool Update_Ticket(string _Branch_Name,string _Source_Issue, string _Problem_Type, string _Solution, DateTime _Start_date, DateTime _End_date, string _Status, string _ticket_no, string _userAD)
    {
        try
        {
            _sqlcom._command_Stored("update_complain_pending", ref cmd);
            cmd.Parameters.AddWithValue("@Branch_Name", _Branch_Name);
            cmd.Parameters.AddWithValue("@Source_Issue", _Source_Issue);
            cmd.Parameters.AddWithValue("@Problem_Type", _Problem_Type);
            cmd.Parameters.AddWithValue("@Solution", _Solution);
            cmd.Parameters.AddWithValue("@Start_date", _Start_date);
            cmd.Parameters.AddWithValue("@End_date", _End_date);
            cmd.Parameters.AddWithValue("@status", _Status);
            cmd.Parameters.AddWithValue("@ticket_no", _ticket_no);
            cmd.Parameters.AddWithValue("@userAD", _userAD);
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
            _msgerror = ex.Message;
            return false;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
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
            _msgerror = ex.Message;
            return false;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
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
}