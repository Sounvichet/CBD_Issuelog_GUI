using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for CompanyDashboard
/// </summary>
public class CompanyDashboard
{
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _Company { get; set; }
    public DataTable _getCompanyFundamentals()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Company_Fundamentals";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@CompanyID", _Company);
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