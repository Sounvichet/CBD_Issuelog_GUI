using System.Data.SqlClient;
using System.Data;
using System;

/// <summary>
/// Summary description for PPWSADashboard
/// </summary>
public class PPWSADashboard
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public DataTable D_Select_date()
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Query("Select LookupCode,FullDesc from sysLookup where LookupID = 'PER' order by FullDesc", ref cmd);
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
    public DataTable D_Select_date_today()
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Query("Select LookupCode,FullDesc from sysLookup where LookupID = 'PER' And LookupCode= 'TD'  order by FullDesc", ref cmd);
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
    public DataTable D_Frequency_Fundamental(string _LookupCode)
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Stored("LookupFrequency_Fundamental", ref cmd);
            cmd.Parameters.AddWithValue("@LookupCode", _LookupCode);
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
    public string _getStartPeriod(string Termcode)
    {

        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        string sqlquery = "Select dbo.getstartperiod('" + Termcode + "','" + currentdate + "')";
        _sqlcom._command_Query(sqlquery, ref cmd);
        SqlDataReader dr = cmd.ExecuteReader();
        string id = null;
        if (dr.Read())
        {
            id = dr[0].ToString();
        }

        return id;
        string Test;
        Test = id;
        sqlc.Close();
        sqlc.Dispose();
        SqlConnection.ClearPool(sqlc);
    }
    public string _getEndPeriod(string Termcode)
    {

        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        string sqlquery = "Select dbo.GetEndPeriod('" + Termcode + "','" + currentdate + "')";
        _sqlcom._command_Query(sqlquery, ref cmd);
        SqlDataReader dr = cmd.ExecuteReader();
        string id = null;
        if (dr.Read())
        {
            id = dr[0].ToString();
        }

        return id;
        string Test;
        Test = id;
        sqlc.Close();
        sqlc.Dispose();
        SqlConnection.ClearPool(sqlc);
    }
    public DataTable D_PR_PPWSA_SETTLEMENT()
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Query("Select LookupCode,FullDesc from sysLookup where LookupID = 'PER' And LookupCode= 'TD'  order by FullDesc", ref cmd);
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