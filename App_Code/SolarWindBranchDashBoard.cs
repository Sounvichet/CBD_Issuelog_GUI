using System.Data.SqlClient;
using System.Data;
using System;

/// <summary>
/// Summary description for SolarWindBranchDashBoard
/// </summary>
public class SolarWindBranchDashBoard
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public DataTable D_NodeName(string branchCode)
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Stored("SWO_NodeNamebrn", ref cmd);
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
    public DataTable D_BranchTYPE_By_Status()
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Query("Select 'Branch',Count(*) as Num from v_NodeBranch where NodeTypeID = '1'", ref cmd);
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
    public DataTable D_NodeDowns()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.STATUSFULLDESC as  Name , Count (a.NODEID) as num  from V_NodeDowns a WHERE a.NodeTypeID = '1'  GROUP BY STATUSFULLDESC", ref cmd);
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
    public DataTable D_NodeDownhourly()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SWO_getHourchartbrn";
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
    public DataTable D_NodeDownsbycause()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select isnull (a.ReasonGroupDesc,'Unknown') , SUM (isnull (a.DownMinute,0)) as NUM  from v_NodeDownEvents a Where a.NodeTypeID = '1' and A.DayID = dbo.GetDateCode(getdate()) GROUP BY a.ReasonGroupDesc", ref cmd);
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
    public DataTable D_NodeDownsbyweek()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.WeekDayDesc,sum (a.DownMinute) as num  from V_NodeDownDaily a where a.NodeTypeID = '1' and  a.WeekID = datepart(ww,getdate()) group by a.WeekDayDesc,a.WeekDayID order by  a.WeekDayID", ref cmd);
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
    public DataTable D_NodeDownsbymonth()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.MonthDayDesc, sum (a.DownMinute) as num  from V_NodeDownDaily a where a.NodeTypeID = '1' and  a.monthID = MONTH(getdate()) group by a.MonthDayDesc,a.DayID order by a.DayID", ref cmd);
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
    public DataTable D_NodeDownsbyyear()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.WeekDesc , sum (isnull(a.DownMinute,0)) as num from V_NodeDownDaily a where a.NodeTypeID = '1' and   a.YEARID = YEAR(getdate()) group by a.WeekDesc order by a.WeekDesc", ref cmd);
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
    public DataTable D_NodeDownsreasonbyweek()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select isnull (a.ReasonGroupDesc,'unknown'),isnull (sum(a.downminute),0) as num  from v_NodeDownEvents a  where a.NodeTypeID = '1' and   a.WeekID = datepart(ww,getdate()) group by a.ReasonGroupDesc order by a.ReasonGroupDesc", ref cmd);
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
    public DataTable D_NodeDownsreasonbyday()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("select b.ReasonGroupDesc , isnull (b.num,0) as NUM from (Select isnull (a.ReasonGroupDesc,'Unknown') as ReasonGroupDesc,sum(a.downminute) as num  from v_NodeDownEvents a  where a.NodeTypeID = '1' and  a.monthID = MONTH(getdate()) group by a.ReasonGroupDesc) b  order by b.num desc", ref cmd);
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
    public DataTable D_NodeDownsreasonbyyear()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select b.ReasonGroupDesc , isnull(b.num,0) as Num from (Select isnull (a.ReasonGroupDesc,'Unknown') as ReasonGroupDesc,sum(a.downminute) as num  from v_NodeDownEvents a  where a.NodeTypeID = '1' and  a.YEARID = YEAR(getdate()) group by a.ReasonGroupDesc) b order by b.num desc", ref cmd);
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
    public DataTable D_Downsbymonth()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select left (a.monthdesc,3) as Monthdesc , sum (a.DownMinute) as num from V_NodeDownDaily a where a.NodeTypeID = '1' and a.YEARID = YEAR(getdate()) group by a.monthdesc ,a.MonthID  order by a.MonthID", ref cmd);
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
    public DataTable D_Branchbymodel()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.Modeldesc , sum (a.DownMinute) as num from V_NodeDownDaily a where a.NodeTypeID = '1' and a.DayID = dbo.GetDateCode (getdate()) group by a.Modeldesc", ref cmd);
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
    public DataTable D_bylocation()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select b.LocationTypeDesc , b.DownMinute from (Select a.LocationTypeDesc , sum (a.DownMinute) as DownMinute from V_NodeDownDaily a where a.NodeTypeID = '1' and a.DayID = dbo.GetDateCode (getdate()) group by a.LocationTypeDesc) b order by b.DownMinute desc", ref cmd);
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
    public DataTable D_bybranchtype()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select a.BranchTypeDesc , sum (a.DownMinute) as num from V_NodeDownDaily a where a.NodeTypeID = '1' and a.DayID = dbo.GetDateCode (getdate()) group by a.BranchTypeDesc", ref cmd);
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
    public DataTable D_branch()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select b.branchName , b.DownMinute from (Select a.branchName , sum (a.DownMinute) as DownMinute from V_NodeDownDaily a where a.NodeTypeID = '1' and a.DayID = dbo.GetDateCode (getdate()) group by a.branchName ) b order by b.DownMinute DESC", ref cmd);
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
    public DataTable D_Quarter()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("select b.QuarterDesc , b.num from  (Select a.QuarterDesc , sum (a.DownMinute) as num from V_NodeDownDaily a where a.NodeTypeID = '1' and a.YEARID = YEAR(getdate()) group by a.QuarterDesc ) b order by b.num desc", ref cmd);
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
    public DataTable D_Top10_BranchDown_Thisyear()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select top 10 a.NodeName , a.DownTime , a.UpTime , a.DownMinute ,a.ReasonGroupDesc , a.ReasonTypeDesc,a.RootCauseDesc  from v_NodeDownEvents a where a.NodeTypeID='1' and  a.YearID = year (getdate()) order by a.DownMinute  desc", ref cmd);
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
    public DataTable D_Top10_BranchDown_ThisMonth()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select top 10 a.NodeName , a.DownTime , a.UpTime , a.DownMinute ,a.ReasonGroupDesc , a.ReasonTypeDesc,a.RootCauseDesc  from v_NodeDownEvents a where a.NodeTypeID='1' and a.monthid =  month (getdate()) and  a.YearID = year (getdate()) order by a.DownMinute  desc", ref cmd);
            dt.Load(cmd.ExecuteReader());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
            sqlc.Close();
        }
        return dt;
    }
    public DataTable D_Top10_BranchDown_ThisWeek()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select top 10 a.NodeName , a.DownTime , a.UpTime , a.DownMinute ,a.ReasonGroupDesc , a.ReasonTypeDesc,a.RootCauseDesc  from v_NodeDownEvents a where a.NodeTypeID='1' and a.WeekID = datepart(ww,getdate()) order by a.DownMinute  desc", ref cmd);
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
    public DataTable D_top10_BranchDown()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select a.EventID,a.NodeName , a.DownTime , a.UpTime , a.DownMinute ,a.ReasonGroupDesc , a.ReasonTypeDesc,a.RootCauseDesc,Case when dbo.IsWeekend(a.DownTime) = 0 then 'WorkingDay' When dbo.IsWeekend(a.DownTime) = 1 then 'WeekendDay' end as GetDays  from v_NodeDownEvents a where a.NodeTypeID='1' and a.DayID = dbo.GetDateCode (getdate()) And a.DownMinute >=30 order by a.DownMinute  desc";
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
    public DataTable D_current_Branch_Down()
    {
        DataTable dt = new DataTable();
        try
        {

            string query = "Select a.EventID ,a.NodeID,a.Caption,a.Status,a.LastDownTime,a.LastDownMinute,a.BranchContact,a.Action,a.ReasonGroup,a.ReasonType,a.PlanStatus from V_getNodecurrentdown a WHERE a.NodeTypeID = '1'  ";
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
    public DataTable D_current_Branch_Down_byBrn(string _brn)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Query("Select dbo.GetNodeLastEvent(a.NodeID) as EventID,a.NodeID,a.Caption,a.StatusFullDesc as Status,a.LastDownTime,a.LastDownMinute,a.BranchContact,a.actiontypedesc as Action,a.ReasonGroupDesc as ReasonGroup , a.ReasonTypeDesc as ReasonType,a.planstatusdesc as PlanStatus From V_NodeDowns a WHERE a.NodeTypeID = '1' and a.Status <> '1' and BranchCode = "+ _brn + "", ref cmd);
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
    public DataTable D_strDailyuppercent()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select cast(cast(sum(a.UpMinute) as numeric(19,2))/sum(a.ServMinute)*100 as  numeric(19,2)) as Uppercent from V_NodeUpDaily a WHERE a.NodeTypeID = '2' and a.DayID = dbo.GetDateCode (getdate())";
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
    public DataTable D_NodeDownMinute(string _branchID, string _NodeID, string _S_date, string _E_date)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("SWO_NodeDownMinutebybrn", ref cmd);
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
    public DataTable D_BranchName()
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("SWO_BranchNameBrn", ref cmd);
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
    public DataTable D_CurBranchdownPercent()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select * from [V_PercentCurBrnDown]";
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