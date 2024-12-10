using System;
using TicketClassLibrary;
using System.Data.SqlClient;
using System.Data;
using System.Data.OracleClient;

/// <summary>
/// Summary description for ATMTerminalDashboard
/// </summary>
public class ATMTerminalDashboard
{
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    OracleConnection _orac = new OracleConnection();

    public DataTable d_get_ATMTerminallisting()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.TID , a.ATM_TYPE , a.ATM_MODE ,a.ATM_SERIES , a.GOLIVE_DATE , a.LOCATION , a.ATM_SERAIL , a.ATM_NAME , a.STATUS , a.ATM_BRANCH from V_TERMINAL_CUR a", ref cmd);
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