using System;
using TicketClassLibrary;
using System.Data.SqlClient;
using System.Data;
using System.DirectoryServices;
/// <summary>
/// Summary description for USERAD
/// </summary>
public class USERAD
{
    ticketconnection obj2 = new ticketconnection();
    SqlConnection sqlc = new SqlConnection();
    dbcon obj1 = new dbcon();
    logger _logger = new logger();
    DbClientContext _context = new DbClientContext();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public string _msgError { get; set; }


    public bool _userloginAD(string P_LDAP_USER , string P_LDAP_PASSWD)

    {
        string L_DOMAIN = "DC=hkl,DC=com,DC=kh";
        bool L_AUTHENTIC = false;
        try
        {
            System.DirectoryServices.DirectoryEntry L_ROOT = new System.DirectoryServices.DirectoryEntry("LDAP://192.168.0.21/" + L_DOMAIN, P_LDAP_USER, P_LDAP_PASSWD);
            Object L_CHILD = L_ROOT.NativeObject;
            L_AUTHENTIC = true;
            
        }

        catch (Exception ex)
        {
            L_AUTHENTIC = false;

            _logger.LogError(ex);
            _msgError = ex.Message;
        }
        finally
        {

            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return L_AUTHENTIC;
    }

    public bool _userloginAD_second(string P_LDAP_USER, string P_LDAP_PASSWD)

    {
        string L_DOMAIN = "DC=hkl,DC=com,DC=kh";
        bool L_AUTHENTIC = false;
        try
        {
            System.DirectoryServices.DirectoryEntry L_ROOT = new System.DirectoryServices.DirectoryEntry("LDAP://192.168.0.11/" + L_DOMAIN, P_LDAP_USER, P_LDAP_PASSWD);
            Object L_CHILD = L_ROOT.NativeObject;
            L_AUTHENTIC = true;

        }

        catch (Exception ex)
        {
            L_AUTHENTIC = false;

            _logger.LogError(ex);
            _msgError = ex.Message;
        }
        finally
        {

            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
        return L_AUTHENTIC;
    }



}