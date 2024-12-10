using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;


/// <summary>
/// Summary description for EmployeeDashboard
/// </summary>
public class EmployeeDashboard
{
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _BranchID { get; set; }
    public string _EMPDATE { get; set; }
    public string _FName { get; set; }
    public string _LName { get; set; }
    public string _NameKhmer { get; set; }
    public string _Gender { get; set; }
    public string _EMPStatus { get; set; }
    public string _JobTitle { get; set; }
    public string _Phone { get; set; }
    public string _Email { get; set; }
    public string _UserID { get; set; }
    public string _RemoteAddr { get; set; }
    public string _getempID { get; set; }
    public string _message { get; set; }
    public string _EmployeeID { get; set; }
    public string _deptid { get; set; }

    public DataTable _getEmployeelisting()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetEmployeesListing";
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
    public DataTable _getEmpContactlist()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GETEMPContactList";
            _sqlcom._command_Stored(query, ref cmd);
            cmd.Parameters.AddWithValue("@deptID", _deptid);
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
    public DataTable _getEmpBranch()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select top 1 a.DeptNameU from v_employeeui a  where a.DeptID = '"+ _deptid + "' ";
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
    public DataTable _getBranchID()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select BranchID , BranchNameK from sysBranch order by BranchNumber";
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
    public DataTable _getEMPSTATUS()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select EmpStatusID , EmpStatus from tblEmpStatus";
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
    public DataTable _getEMPGENDER()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "PR_GetGender";
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
    public DataTable _getEMPJobtitle()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select JobTitleID , JobTitleU from [tblJobTitle] Where JobState = '1' And JobTitleID <> 'FOUND' ";
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
    public DataTable _getAutoIncrementID()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "SELECT ISNULL(MAX(SIDCARD),0) + 1 from [tblemployees] Where SIDCARD <> '02237'";
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
    public static string ZeroAppend(string data, int idLimit)
    {
        return data.Substring(data.Length - idLimit);
    }
    public bool _EMPLOYEE_ADD()
    {
        try
        {
            DataTable dr = _getAutoIncrementID();
            string _ID = dr.Rows[0][0].ToString();
            //string _ID = AutoIncrementID();
            int _IdLimit = 5;
            string _EMPID = ZeroAppend("00000" + _ID, _IdLimit);
            _sqlcom._command_Stored("PR_EMPLOYEE_ADD", ref cmd);
            cmd.Parameters.AddWithValue("@BranchID", _BranchID);
            cmd.Parameters.AddWithValue("@EmployeeID", _EMPID);
            cmd.Parameters.AddWithValue("@Empdate", _EMPDATE);
            cmd.Parameters.AddWithValue("@Fname", _FName);
            cmd.Parameters.AddWithValue("@Lname", _LName);
            cmd.Parameters.AddWithValue("@NameKhmer", _NameKhmer);
            cmd.Parameters.AddWithValue("@Gender", _Gender);
            cmd.Parameters.AddWithValue("@EmpStatusID", _EMPStatus);
            cmd.Parameters.AddWithValue("@JobTitleID", _JobTitle);
            cmd.Parameters.AddWithValue("@Phone", _Phone);
            cmd.Parameters.AddWithValue("@Email", _Email);
            cmd.Parameters.AddWithValue("@userid", _UserID);
            cmd.Parameters.AddWithValue("@RemoteAddr", _RemoteAddr);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            string retval = cmd.Parameters["@retval"].Value.ToString();
            _getempID = retval;
            if (retval != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _message = ex.Message;
            return false;

        }
        finally
        {
            //sqlc.Close();
            //sqlc.Dispose();
            //SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _EMPPHO_DELETE()
    {
        try
        {
            _sqlcom._command_Stored("PR_EMPPHOTO_DELETE", ref cmd);
            cmd.Parameters.AddWithValue("@EmployeeID", _EmployeeID);
            cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            //string retval = cmd.Parameters["@retval"].Value.ToString();
            if (retval == 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _message = ex.Message;
            return false;

        }
        finally
        {
            //sqlc.Close();
            //sqlc.Dispose();
            //SqlConnection.ClearPool(sqlc);
        }
    }
}