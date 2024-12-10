using System.Data.SqlClient;
using System.Data;
using System;
public class ReportIncident
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _message { get; set; }
    public DataTable D_Incident_DDL(string USERID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.ReportCat ,a.ReportCatName  from v_reportcategoryuser a left outer join V_sysUserAD b on b.UserID = a.userid where a.activeflag = 1  And a.ReportGroup='CBA'  And b.UserID = '" + USERID + "' order by ReportCatName", ref cmd);
            //cmd.Parameters.AddWithValue("@userid", USERID);
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
            _sqlcom._command_Query("EXEC [SWO_BranchName]", ref cmd);
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
    public DataTable D_Terminal(string branchCode)
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Stored("SWO_NodeName", ref cmd);
            cmd.Parameters.AddWithValue("@BranchCode", branchCode);
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
            _message = ex.Message;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt1;
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
            _message = ex.Message;
        }

        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt1;
    }
    public DataTable D_RP_ATMIncident(string _branchCode , string _Terminal , string _groupType , string _startDate , string _EndDate)
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored("RP_ATMIncident", ref cmd);
            cmd.Parameters.AddWithValue("@Branch_code", _branchCode);
            cmd.Parameters.AddWithValue("@Terminal", _Terminal);
            cmd.Parameters.AddWithValue("@GroupTypeID", _groupType);
            cmd.Parameters.AddWithValue("@start_date", _startDate);
            cmd.Parameters.AddWithValue("@End_date", _EndDate);
            dt1.Load(cmd.ExecuteReader());
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
        return dt1;
    }
    public DataTable D_Radiolist_Issue()
    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_Report_name_ddl", ref cmd);
            dt1.Load(cmd.ExecuteReader());

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
        return dt1;
    }
    public DataTable Dt_PR_P2_ISSUELOG(string Report_Sql, string par1, string par2)

    {
        DataTable dt1 = new DataTable();
        try
        {
            _sqlcom._command_Stored(Report_Sql, ref cmd);
            cmd.Parameters.AddWithValue("@Start_date", par1);
            cmd.Parameters.AddWithValue("@End_date", par2);
            dt1.Load(cmd.ExecuteReader());
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
        return dt1;
    }
    public DataTable Dt_PR_P1_Start_ISSUELOG(string Report_Sql, string par1)

    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored(Report_Sql, ref cmd);
            cmd.Parameters.AddWithValue("@Start_date", par1);
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
    public DataTable Dt_PR_P1_end_ISSUELOG(string Report_Sql, string par2)

    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored(Report_Sql, ref cmd);
            cmd.Parameters.AddWithValue("@End_date", par2);
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
    public DataTable incident_Fundamental(string Report_Sql, string par2)

    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored(Report_Sql, ref cmd);
            cmd.Parameters.AddWithValue("@End_date", par2);
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
    public DataTable Sqlstring_fundamental(string Listview)

    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_excel_report_connstring", ref cmd);
            cmd.Parameters.AddWithValue("@reportcode", Listview);
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
    public string bind_report_sql(string P_report_sql)
    {
      
        SqlCommand cmd = new SqlCommand("", sqlc);
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "Select ReportSQL from sysreport where reportcode ='" + P_report_sql + "'";
        SqlDataReader dr = cmd.ExecuteReader();
        string id = null;
        if (dr.Read())
        {
            id = dr[0].ToString();
            id = dr[1].ToString();
        }
        sqlc.Close();
        sqlc.Dispose();
        SqlConnection.ClearPool(sqlc);
        return id;
    }
    public DataTable D_reportIssuebyDate(string _StartDate , string _EndDate)

    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("ReportIssueByDate", ref cmd);
            cmd.Parameters.AddWithValue("@Start_date", _StartDate);
            cmd.Parameters.AddWithValue("@End_date", _EndDate);
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
    public DataTable D_getReportConnstring(string _listView)

    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("PR_excel_report_connstring", ref cmd);
            cmd.Parameters.AddWithValue("@reportcode", _listView);
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

}