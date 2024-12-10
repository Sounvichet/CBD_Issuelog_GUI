using System.Data.SqlClient;
using System.Data;
using System;
using System.Data.OracleClient;

/// <summary>
/// Summary description for ReportWingDashboard
/// </summary>
public class ReportWingDashboard
{
    SqlConnection sqlc = new SqlConnection();
    OracleConnection Orac = new OracleConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    dbcon _oracon = new dbcon();
    public DataTable PR_WING_LOAN_REPAYMENT(string S_date, string E_date,string _partner)
    {
        DataTable dt = new DataTable();
        try
        {
            Orac.ConnectionString = _oracon.oracleconcbs();
            Orac.Open();
            OracleCommand cmd = new OracleCommand("PR_WING_LOAN_REPAYMENT", Orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_SDATE", S_date);
            cmd.Parameters.AddWithValue("P_EDATE", E_date);
            cmd.Parameters.AddWithValue("PARTNER", _partner);
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("O_CURSOR1", OracleType.Cursor).Direction = ParameterDirection.Output;
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
        }
        finally
        {
            Orac.Close();
            Orac.Dispose();
            OracleConnection.ClearPool(Orac);
        }
        return dt;
    }
    public DataTable PR_WING_Settlement(string S_date, string E_date, string _partner)
    {
        DataTable dt = new DataTable();
        try
        {
            Orac.ConnectionString = _oracon.oracleconcbs();
            Orac.Open();
            OracleCommand cmd = new OracleCommand("PR_WING_LOAN_REPAYMENT", Orac);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("P_SDATE", S_date);
            cmd.Parameters.AddWithValue("P_EDATE", E_date);
            cmd.Parameters.AddWithValue("PARTNER", _partner);
            cmd.Parameters.Add("o_cursor", OracleType.Cursor).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("O_CURSOR1", OracleType.Cursor).Direction = ParameterDirection.Output;
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
        }
        finally
        {
            Orac.Close();
            Orac.Dispose();
            OracleConnection.ClearPool(Orac);
        }
        return dt;
    }
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
    public DataTable D_CSS_DDL(string USERID)
    {
        //------DDL = dropdownlist
        DataTable dt = new DataTable();
        try
        {

            string query = "Select a.ReportCat ,a.ReportCatName  from v_reportcategoryuser a left outer join V_sysUserAD b on b.UserID = a.userid where a.activeflag = 1  And a.ReportGroup ='PMS' and substring (a.formCode,1,4) = 'WING' And a.ReportCat not in ('EDCCSMLD','PVCSMLD') And b.UserID = '" + USERID + "'  order by ReportCatName ;";
            _sqlcom._command_Query(query,ref cmd);
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
}