using System.Data.SqlClient;
using System.Data;
using System;

/// <summary>
/// Summary description for UserFundamentals
/// </summary>
public class UserFundamentals
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _msgerror { set; get; }
    public string _userid { set; get; }
    public DataTable _Account_Fundamentals(string _UserID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored("Account_Fundamentals", ref cmd);
            cmd.Parameters.AddWithValue("@USERID", _UserID);
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
    public DataTable _UserAD_Fundamentals(string _UserID)
    {
        DataTable dt = new DataTable();
        try
        {
            //string query = "Select isnull (e.namekhmerU,e.fullName)  as FamilyName, e.EmployeeID as Employeeid ,isnull (e.Email,'UnRegister') as Email, e.FullName , e.Branchname as office  , e.ExtBranchID, e.OfficeRange ,e.deptID, e.BranchID    from v_employeeui e Where e.Active = 1 and e.SIDCARD = " + _UserID + "";
            string query = "UserActiveDirectory_GetByUserAD"; //Account_FundamentalsAD  
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@UserAD", _UserID);
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _msgerror = ex.Message;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
    }
    public DataTable _get_Languagetype()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select LanType,LanName from sysLanguageType";
            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _msgerror = ex.Message;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
    }
    public DataTable _get_groupNameDDL()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select GroupID ,GName from sysGroup WHere GStatus = 'A'";
            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _msgerror = ex.Message;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
    }
    public DataTable _get_UserGroupName()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select a.UserID,B.GName from [sysUserGroup] a  left join sysGroup b on B.GroupID = a.GroupID Where a.Userid = '"+ _userid + "'";
            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _msgerror = ex.Message;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
    }
    public DataTable _get_UserGrouprolebyUserid()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select a.GroupID , g.GName  from [sysUserGroup] a inner join sysGroup g on g.GroupID = a.GroupID where a.UserID = '"+_userid+"'";

            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _msgerror = ex.Message;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return dt;
    }
    public DataTable _get_sysgrouplist()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select Groupid , GName from sysGroup Where GStatus = '1' order by GroupID";

            _sqlcom._command_Query(query, ref cmd);
            dt.Load(cmd.ExecuteReader());

        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _msgerror = ex.Message;
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