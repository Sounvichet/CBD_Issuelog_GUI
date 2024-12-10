using System.Data.SqlClient;
using System.Data;
using System;

/// <summary>
/// Summary description for ThresholdDashboard
/// </summary>
public class ThresholdDashboard
{

    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();

    public DataTable D_getCassetteThreshold()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetAlertCCThreshold";
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
}