using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

/// <summary>
/// Summary description for UserDashboard
/// </summary>
public class UserDashboard
{
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _Fname { get; set; }
    public string _Lname { get; set; }
    public string _gender { get; set; }
    public string _DBO { get; set; }
    public string _IDCard { get; set; }
    public string _EMPDATE { get; set; }
    public string _Email { get; set; }
    public string _UserID { get; set; }
    public string _Password { get; set; }
    public string _Remoteaddr { get; set; }
    public string _message { get; set; }
    public string _name { get; set; }
    public string _CreatedBy { get; set; }
    public string _getuser { get; set; }
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
    public DataTable _getUserlisting()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "select  UserID AS [UserID], AccName AS [AccName],FullName AS [FullName],GName AS [Group],UDesc AS [Description],GLevel AS [Level],BranchName AS [Branch],LanName AS [Language],GrantWebAcc AS [GrantWeb],ULocked AS [Logged In],ComputerName AS [Computer Name],TimeIn AS [TimeIn],TimeOut AS [TimeOut]  from v_user where 1=1 and UALogin='0'";
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
    public DataTable _getUserbysearch()
    {
        DataTable dt = new DataTable();
        try
        {
            string query = "select  UserID AS [UserID], AccName AS [AccName],FullName AS [FullName],GName AS [Group],UDesc AS [Description],GLevel AS [Level],BranchName AS [Branch],LanName AS [Language],GrantWebAcc AS [GrantWeb],ULocked AS [Logged In],ComputerName AS [Computer Name],TimeIn AS [TimeIn],TimeOut AS [TimeOut]  from v_user where 1=1 and UALogin='0' and userid like '%"+ _UserID + "%'";
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
    public bool _Account_Logout()
    {
        try
        {
            _sqlcom._command_Stored("Account_Logout", ref cmd);
            cmd.Parameters.AddWithValue("@UserID", _UserID);
            cmd.Parameters.AddWithValue("@RemoteAddr", _Remoteaddr);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            ///string retval = cmd.Parameters["@retval"].Value.ToString();
            //_customerID = retval;
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
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _ACCOUNT_CREATE()
    {
        try
        {
            _sqlcom._command_Stored("Account_Create", ref cmd);
            cmd.Parameters.AddWithValue("@sidcard", _UserID);
            cmd.Parameters.AddWithValue("@Email", _Email);
            cmd.Parameters.AddWithValue("@FullName", _Fname + "" + _Lname);
            cmd.Parameters.AddWithValue("@UserID", _UserID);
            cmd.Parameters.AddWithValue("@Password", _Password);
            cmd.Parameters.AddWithValue("@RemoteAddr", _Remoteaddr);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            ///string retval = cmd.Parameters["@retval"].Value.ToString();
            //_customerID = retval;
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
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _ACCOUNT_REGISTER()
    {
        try
        {
            _sqlcom._command_Stored("Account_Register", ref cmd);
            cmd.Parameters.AddWithValue("@sidcard", _UserID);
            cmd.Parameters.AddWithValue("@Email", _Email);
            cmd.Parameters.AddWithValue("@FullName", _Fname +' '+ _Lname);
            cmd.Parameters.AddWithValue("@UserID", _UserID);
            cmd.Parameters.AddWithValue("@Password", _Password);
            cmd.Parameters.AddWithValue("@RemoteAddr", _Remoteaddr);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            ///string retval = cmd.Parameters["@retval"].Value.ToString();
            //_customerID = retval;
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
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _USER_BRANCH_UPDATE()
    {
        try
        {
            _sqlcom._command_Stored("PR_USER_BRANCH_UPDATE", ref cmd);
            cmd.Parameters.AddWithValue("@UserID", _name);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            ///string retval = cmd.Parameters["@retval"].Value.ToString();
            //_customerID = retval;
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
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _SysuserEmployee_ADD()
    {
        try
        {
            _sqlcom._command_Stored("PR_SysuserEmployee_ADD", ref cmd);
            cmd.Parameters.AddWithValue("@UserID", _name);
            cmd.Parameters.AddWithValue("@EmployeeID", _IDCard);
            cmd.Parameters.AddWithValue("@DefPwd", _Password);
            cmd.Parameters.AddWithValue("@CreatedBy", _CreatedBy);
            cmd.Parameters.AddWithValue("@RemoteAddr", _Remoteaddr);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            //int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            string retval = cmd.Parameters["@retval"].Value.ToString();
            _getuser = retval;
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
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    public bool _AccountRegister_Create()
    {
        try
        {
            _sqlcom._command_Stored("AccountRegister_Create", ref cmd);
            cmd.Parameters.AddWithValue("@FName", _Fname);
            cmd.Parameters.AddWithValue("@LName", _Lname);
            cmd.Parameters.AddWithValue("@Gender", _gender);
            cmd.Parameters.AddWithValue("@dob", _DBO);
            cmd.Parameters.AddWithValue("@IDCard", _IDCard);
            cmd.Parameters.AddWithValue("@EmpDate", _EMPDATE);
            cmd.Parameters.AddWithValue("@Email", _Email);
            cmd.Parameters.AddWithValue("@UserID", _UserID);
            cmd.Parameters.AddWithValue("@Password", _Password);
            cmd.Parameters.AddWithValue("@Address", _Email);
           // cmd.Parameters.AddWithValue("@RemoteAddr", _Remoteaddr);
            cmd.Parameters.Add("@retval", SqlDbType.NVarChar, 50).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();
            int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
            ///string retval = cmd.Parameters["@retval"].Value.ToString();
            //_customerID = retval;
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
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
}