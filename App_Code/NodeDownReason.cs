using System;
using TicketClassLibrary;
using System.Data.SqlClient;
using System.Data;
using System.Net;

/// <summary>
/// Summary description for NodeDownReason
/// </summary>
public class NodeDownReason
{

    ticketconnection obj2 = new ticketconnection();
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string Message { get; set; }
    public string eventno { get; set; }
    public string reason { get; set; }
    public string s_desc { get; set; }
    public string s_resolution { get; set; }
    public string s_action { get; set; }
    public string s_reasondesc { get; set; }
    public string s_userid { get; set; }
    string _ip = "";
    
    //public bool update_NodeDownReason(string s_eventno , string s_reason, string s_desc , string s_resolution , string s_action , string s_reasondesc, string s_userid, int retval)
    public bool update_NodeDownReason()
    {
        try
        {
            //sqlc.ConnectionString = obj1.Sqlcon();
            //sqlc.Open();
            _ip = _getlocalIP();
            sqlc.ConnectionString = _context.getConnectionString();
            sqlc.Open();
            SqlCommand cmd = new SqlCommand("NodeDownEvents_Update", sqlc);
            cmd.CommandType = CommandType.StoredProcedure;
            //dat.UpdateCommand = new SqlCommand("NodeDownEvents_Update", sqlc);
            cmd.Parameters.AddWithValue("@EventID", eventno);
            cmd.Parameters.AddWithValue("@ReasonTypeID", reason);
            cmd.Parameters.AddWithValue("@ProblemDesc", s_desc);
            cmd.Parameters.AddWithValue("@ResolveDesc", s_resolution);
            cmd.Parameters.AddWithValue("@ActionTypeID", s_action);
            cmd.Parameters.AddWithValue("@RootCauseDesc", s_reasondesc);
            cmd.Parameters.AddWithValue("@userid", s_userid);
            cmd.Parameters.AddWithValue("@Remoteaddr", _ip);
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
            Message = ex.Message;
            return false;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool insert_NodeDownReasonHis()
    {
        try
        {
            _ip = _getlocalIP();
            _sqlcom._command_Stored("NodeDownEventsHis_insert", ref cmd);
            cmd.Parameters.AddWithValue("@EventID", eventno);
            cmd.Parameters.AddWithValue("@ReasonTypeID", reason);
            cmd.Parameters.AddWithValue("@ProblemDesc", s_desc);
            cmd.Parameters.AddWithValue("@ResolveDesc", s_resolution);
            cmd.Parameters.AddWithValue("@ActionTypeID", s_action);
            cmd.Parameters.AddWithValue("@RootCauseDesc", s_reasondesc);
            cmd.Parameters.AddWithValue("@userid", s_userid);
            cmd.Parameters.AddWithValue("@Remoteaddr", _ip);
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
            Message = ex.Message;
            return false;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public string _getlocalIP()
    {
        IPHostEntry host;
        string localID = "?";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily.ToString() == "InterNetwork")
            {
                localID = ip.ToString();
            }
        }

        return localID;
    }
    public DataTable D_getReasonTypes(string strReasonGroupID)
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.ReasonTypeID as ReasonTypeID,a.ReasonFullDesc as Reason from NodeDownReason a where a.ReasonGroupID =isnull (@ReasonGroupID,'ReasonGroupID')", ref cmd);
            //s_command("Select a.ReasonTypeID as ReasonTypeID,a.ReasonFullDesc as Reason from NodeDownReason a where a.ReasonGroupID =isnull (@ReasonGroupID,'ReasonGroupID') ", ref cmd);
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
    public DataTable D_getActions()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.ActionTypeID,a.ActionTypeDesc from NodeDownActionType a", ref cmd);
            //s_command("Select a.ActionTypeID,a.ActionTypeDesc from NodeDownActionType a", ref cmd);
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
    public DataTable D_getReasons()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.ReasonTypeID as ReasonTypeID,a.ReasonFullDesc as Reason  from NodeDownReason a", ref cmd);
            //s_command("Select a.ReasonTypeID as ReasonTypeID,a.ReasonFullDesc as Reason  from NodeDownReason a ", ref cmd);
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
    public DataTable D_getPlan()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select LookupCode as PlanStatusID , FullDesc as PlanStatusDesc from syslookup where lookupID = 'YON'", ref cmd);
            //s_command("Select LookupCode as PlanStatusID , FullDesc as PlanStatusDesc from syslookup where lookupID = 'YON' ", ref cmd);
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

}