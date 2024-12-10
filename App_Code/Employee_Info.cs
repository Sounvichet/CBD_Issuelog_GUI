using System.Data.SqlClient;
using System.Data;
using System;

/// <summary>
/// Summary description for Employee_Info
/// </summary>
public class Employee_Info
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _message {get; set;}
    public string _EmpID { get; set; }

    public DataTable _getEmplyee_Info()
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Stored("PR_Employee_Fundamental", ref cmd);
            cmd.Parameters.AddWithValue("@EmpID", _EmpID);
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
    public DataTable _getEmplyee_contactlist(string _deptID)
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Stored("PR_EmployeeContactList", ref cmd);
            cmd.Parameters.AddWithValue("@deptID", _deptID);
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
    public DataTable _getEmplyeedept(string _deptID)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "Select distinct a.DeptNameU as Officename from v_employeeui a where deptID='" + _deptID + "'";
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
    public DataTable _getEmpsalary_list(string _EmpID)
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Stored_hrm("EmployeeSalary_ListByEmployee", ref cmd);
            cmd.Parameters.AddWithValue("@EmployeeID", _EmpID);
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
    public DataTable _getEmpLeave_ListbyEmp(string _EmpID,string _LTypeID ,string _getYear)
    {
        DataTable dt = new DataTable();
        try
        {

            _sqlcom._command_Stored_hrm("EmployeeLeave_ListByEmployee", ref cmd);
            cmd.Parameters.AddWithValue("@EmployeeID", _EmpID);
            cmd.Parameters.AddWithValue("@LTypeID", _LTypeID);
            cmd.Parameters.AddWithValue("@YearNum", _getYear);

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
    public DataTable _getEmpFamily_listbyEmp(string _EmpID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored_hrm("EmployeeFamily_ListByEmployee", ref cmd);
            cmd.Parameters.AddWithValue("@EmployeeID", _EmpID);
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
    public DataTable _getEmpContact(string _EmpID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored_hrm("EmployeeContact_ListByEmployee", ref cmd);
            cmd.Parameters.AddWithValue("@EmployeeID", _EmpID);
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
    public DataTable _getempacedemic(string _EmpID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored_hrm("EmployeeAcademic_ListByEmployee", ref cmd);
            cmd.Parameters.AddWithValue("@EmployeeID", _EmpID);
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
    public DataTable _getemptraining_list(string _EmpID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored_hrm("TrainingAssessment_ListByEmployee", ref cmd);
            cmd.Parameters.AddWithValue("@EmployeeID", _EmpID);
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
    public DataTable _getempdocument(string _EmpID)
    {
        DataTable dt = new DataTable();
        try
        {
            _sqlcom._command_Stored_hrm("EmployeeDocument_ListByEmployee", ref cmd);
            cmd.Parameters.AddWithValue("@EmployeeID", _EmpID);
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
    public DataTable _getEmployee_ListForContact(string Branchid,string userID)
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "exec Employee_ListForContact 'and branchid = ''"+ Branchid +"''',Null,'"+ userID + "' ";
            _sqlcom._command_Query_hrm(query, ref cmd);
            
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