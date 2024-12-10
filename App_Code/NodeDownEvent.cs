using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using TicketClassLibrary;
using System.Data.SqlClient;
/// <summary>
/// Summary description for NodeDownEvent
/// </summary>
public class NodeDownEvent
{
    ticketconnection obj2 = new ticketconnection();
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string Message { get; set; }
    public string _rundate { get; set; }
    public string _NodeID { get; set; }
    public string _userID { get; set; }

    public DataTable getFundamentals(string eventid)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("NodeDownEvents_Fundamental", ref cmd);
            cmd.Parameters.AddWithValue("@EventID", eventid);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {

            //sqlc.Close();
        }
        return dt;

    }
    public DataTable getFundamentalsHis(string eventid)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("NodeDownEvents_Fundamental_HIS", ref cmd);
            cmd.Parameters.AddWithValue("@EventID", eventid);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }

        finally
        {

            //sqlc.Close();
        }
        return dt;

    }
    public bool _NodeDownEvent_AddByDate()
    {
        try
        {
            _sqlcom._command_Stored("NodeDownEvents_AddByDate", ref cmd);
            cmd.Parameters.AddWithValue("@rundate", _rundate);
            cmd.Parameters.AddWithValue("@nodeid", _NodeID);
            cmd.Parameters.AddWithValue("@userid", _userID);
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
}
    



