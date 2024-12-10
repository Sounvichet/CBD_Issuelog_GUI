using System.Data.SqlClient;
using System.Data;
using System;

/// <summary>
/// Summary description for ReportNodeDownDaily
/// </summary>
public class ReportNodeDownDaily
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _sqlquery { get; set; }
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
    public DataTable D_View_Type()
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Query("select ListViewCode , ListViewDesc from sysListviewType where formcode='SWD22'", ref cmd);
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
    public DataTable D_ActionType()
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Query("SELECT ActionTypeCode , ActionTypeDesc FROM NodeDownActionType", ref cmd);
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
    public DataTable D_NodeType()
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Query("Select NodeTypeID , NodeFullDesc from NodeDownType", ref cmd);
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
    public DataTable D_ListViewCode(string _FormCode, string _listViewDesc)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("select FormCode ,ListViewCode , ListViewDesc from sysListviewType where ListViewCode='" + _FormCode + "' and ListViewDesc = '" + _listViewDesc + "'", ref cmd);
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
    public DataTable D_SelectString(string _formCode, string _listViewCode, string _StartDate, string _End_date , string _NodeType)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','and downtime between ''" + _StartDate + "'' and ''" + _End_date + "'' and nodetypeid=" + _NodeType + " AND DownMinute>AllowMinute'";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22000(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22001(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22002(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22003(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22004(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22005(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22006(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22007(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22008(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22009(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22010(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22011(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22012(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22013(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22014(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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
    public DataTable D_SelectStringSWD22999(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " '";
            _sqlcom._command_Query(_sqlquery, ref cmd);
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