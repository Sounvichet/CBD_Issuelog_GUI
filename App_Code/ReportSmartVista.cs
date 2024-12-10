using System.Data.SqlClient;
using System.Data;
using System;



/// <summary>
/// Summary description for ReportSmartVista
/// </summary>
public class ReportSmartVista
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
    public DataTable D_bind_reportname(string _UserID)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select a.ReportCat ,a.ReportCatName  from v_reportcategoryuser a left join V_SysUserAD ad on ad.UserID = a.userid where a.activeflag = 1  And a.ReportGroup='BCM' and a.reportcat <> 'TBSWRMGT' and ad.UserID = '" + _UserID + "' order by a.ReportCatName ";
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
    public DataTable D_bind_reportname_Wing(string _UserID)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select a.ReportCat ,a.ReportCatName  from v_reportcategoryuser a  left join V_SysUserAD ad on ad.UserID = a.userid where a.activeflag = 1  And a.ReportGroup='BCM' and a.ReportCat in ('TBSWRMGT','TBSDPMG') and ad.UserAD = '" + _UserID + "' order by a.ReportCatName ;";
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
    public DataTable D_bind_reportname_CSS_dispute(string _UserID)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select a.ReportCat ,a.ReportCatName  from v_reportcategoryuser a  left join V_SysUserAD ad on ad.UserID = a.userid where a.activeflag = 1  And a.ReportGroup='BCM' and a.ReportCat in ('TBSCSPMG') and ad.UserAD = '" + _UserID + "' order by a.ReportCatName ;";
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
    public DataTable D_bind_Upload_file_DDL(string _UserID)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select a.ReportCat ,a.ReportCatName  from v_reportcategoryuser a  left join V_SysUserAD ad on ad.UserID = a.userid where a.activeflag = 1  And a.ReportGroup='SVF' and ad.UserID = '" + _UserID + "'  order by a.ReportCatName ;";
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
    public DataTable D_bind_reportcode(string _groupreport)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select ReportCode , ReportName from sysReport where reportcat = '" + _groupreport + "' and status = '1' order by ReportCode";
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
    public DataTable D_current_Term_Down()
    {
        DataTable dt = new DataTable();
        try
        {

            string query = "Select A.SEQNO , A.ORIG_PID , A.START_TIME ,round((sysdate - A.START_TIME)*(24*60),0) as TOTAL_MIN, A.CUR_DESC  from SV_TERMCURRENTDOWN A";
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
    public DataTable D_Term_listing (string _getPID, string _getStart , string _getEnd)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select A.EventID , A.PID,a.TERMINAL_ID ,a.Status ,a.LastDownTime ,a.LastDownMinute,a.BranchContact,a.Action,a.ReasonGroupDesc,a.ReasonTypeDesc ,a.PlanStatusDesc from  [V_GetTermlisting] A Where A.LastDownMinute is not null And A.PID =  isnull ("+_getPID+",a.PID) And A.DayID between dbo.GetDateCode('" + _getStart + "') and dbo.GetDateCode ('"+ _getEnd + "')";
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
    public DataTable D_BranchName()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("SWO_BranchName", ref cmd);
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
    public DataTable D_TERMNAME(string _getbrn_code)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("SV_TermName", ref cmd);
            cmd.Parameters.AddWithValue("@BranchCode", _getbrn_code);
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
    public DataTable D_Persentage_byWeek()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "select Weekdesc , cast ((UpPercent * 100) as numeric (18,2)) as UpPercent from V_TERM_UP_WEEKLY_TOTAL Where 1=1 and T_Type = 1 ORDER BY WeekID";
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