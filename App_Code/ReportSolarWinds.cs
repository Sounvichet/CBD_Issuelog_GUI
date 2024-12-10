using System.Data.SqlClient;
using System.Data;
using System;

/// <summary>
/// Summary description for ReportSolarWinds
/// </summary>
public class ReportSolarWinds
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _Sqlquery { get; set; }
    public string _message { get; set; }
    public DataTable D_View_Type()
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Query("select ListViewCode , ListViewDesc from sysListviewType where formcode='SWD21'", ref cmd);
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
    public DataTable D_ActionType()
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Query("SELECT ActionTypeID , ActionTypeDesc FROM NodeDownActionType", ref cmd);
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
    public DataTable D_SelectString_NotAction(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID, string _ReasonGroupID)
    {
        DataTable dt = new DataTable();
        try
        {
            //_Sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','001','v_NodeDownEvents','and DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " and Eventid not in (Select timenull.EventID from v_NodeDownEvents timenull Where timenull.uptime is null And timenull.EventID not in (Select dbo.GetNodeLastEvent(c.NodeID) from V_NodeDowns c where c.Status <>1 and c.NodeTypeID = 2 )) And DownMinute > 30 order by downtime ',default,default";
            _Sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','001','v_NodeDownEvents','and DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " And ReasonGroupID =" + _ReasonGroupID + " and Eventid not in (Select timenull.EventID from v_NodeDownEvents timenull Where timenull.uptime is null And timenull.EventID not in (Select dbo.GetNodeLastEvent(c.NodeID) from V_NodeDowns c where c.Status <>1 and c.NodeTypeID = 2 )) And DownMinute > 30 order by downtime',default,default";
            _sqlcom._command_Query(_Sqlquery, ref cmd);
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
    public DataTable D_SelectString(string _formCode ,string _listViewCode , string _StartDate ,string _End_date,string NodeTypeID,string _ActionType , string _ReasonGroupID)
    {
        DataTable dt = new DataTable();
        try
        {
            _Sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','and DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " And ReasonGroupID = ''"+ _ReasonGroupID + "'' And  ActionTypeDesc =''" + _ActionType+ "'''";
            _sqlcom._command_Query(_Sqlquery, ref cmd);
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

    public DataTable D_SelectString_NullActionType(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID) //string _ReasonGroupID
    {
        DataTable dt = new DataTable();
        try
        {
            _Sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','001','v_NodeDownEvents','and DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " and Eventid not in (Select timenull.EventID from v_NodeDownEvents timenull Where timenull.uptime is null And timenull.EventID not in (Select dbo.GetNodeLastEvent(c.NodeID) from V_NodeDowns c where c.Status <>1 and c.NodeTypeID = 2 )) And DownMinute > 30 order by downtime ',default,default";
           // _Sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','and DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " order by downtime ',default,default,default";
            _sqlcom._command_Query(_Sqlquery, ref cmd);
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
    public DataTable D_SelectString_NullActionType001(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID) //string _ReasonGroupID
    {
        DataTable dt = new DataTable();
        try
        {
            _Sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','and DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + "',default,default,default";
            _sqlcom._command_Query(_Sqlquery, ref cmd);
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
    public DataTable _Full_input_values(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID, string _ReasonGroupID, string _ActionType) //string _ReasonGroupID
    {
        DataTable dt = new DataTable();
        try
        {
            _Sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','and DayID between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " And ReasonGroupID = ''" + _ReasonGroupID + "'' And  ActionTypeID =''" + _ActionType + "''',default,default,default";
            _sqlcom._command_Query(_Sqlquery, ref cmd);
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
    public DataTable D_SelectString_002(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _Sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And Cast(DownTime  as Date) between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + "',default,default,default";
            _sqlcom._command_Query(_Sqlquery, ref cmd);
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
    public DataTable D_SelectString_T00(string _formCode, string _listViewCode, string _StartDate, string _End_date, string NodeTypeID)
    {
        DataTable dt = new DataTable();
        try
        {
            _Sqlquery = "exec SelectString '" + _formCode + "','" + _listViewCode + "','And Cast(DownTime  as Date) between dbo.GetDateCode(''" + _StartDate + "'') and dbo.GetDateCode(''" + _End_date + "'') and nodetypeid=" + NodeTypeID + " ',default,default,default";
            _sqlcom._command_Query(_Sqlquery, ref cmd);
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
    public DataTable D_ListViewCode(string _FormCode , string _listViewDesc)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("select FormCode ,ListViewCode , ListViewDesc from sysListviewType where ListViewCode='" + _FormCode+"' and ListViewDesc = '"+_listViewDesc+"'", ref cmd);
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
    public DataTable D_NodeDownMinute(string _branchID, string _NodeID, string _S_date, string _E_date)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("SWO_NodeDownMinute", ref cmd);
            cmd.Parameters.AddWithValue("@branchID", _branchID);
            cmd.Parameters.AddWithValue("@NodeID", _NodeID);
            cmd.Parameters.AddWithValue("@Start_date", _S_date);
            cmd.Parameters.AddWithValue("@End_date", _E_date);
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
    public DataTable D_STMNodeDownMinute(string _branchID, string _NodeID, string _S_date, string _E_date)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("SWO_STMNodeDownMinute", ref cmd);
            cmd.Parameters.AddWithValue("@branchID", _branchID);
            cmd.Parameters.AddWithValue("@NodeID", _NodeID);
            cmd.Parameters.AddWithValue("@Start_date", _S_date);
            cmd.Parameters.AddWithValue("@End_date", _E_date);
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
    public string _getStartPeriod(string Termcode)
    {
        
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        string sqlquery = "Select dbo.getstartperiod('"+Termcode+"','"+currentdate+"')";
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