using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.OracleClient;
using MasterReportClass;

/// <summary>
/// Summary description for SqlConnectAndSqlCommand
/// </summary>
public class SqlConnectAndSqlCommand
{
    SqlConnection sqlc = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    masterreport_connect _oracon = new masterreport_connect();
    OracleConnection _orac = new OracleConnection();
    OracleCommand oracmd = new OracleCommand();
    public string getConnectionString()
    {
        string conString = ConfigurationManager.ConnectionStrings["AppConString"].ConnectionString;
        return conString;
    }
    public string getConnectionString_hrmdb()
    {
        string conString = ConfigurationManager.ConnectionStrings["AppConString_hrmdb"].ConnectionString;
        return conString;
    }
    public void sqlcon_open(SqlConnection sqlcon)
    {
        this.sqlc = sqlc = new SqlConnection();
        sqlc.ConnectionString = getConnectionString();
        sqlc.Open();
    }
    public void sqlcon_open_hrmdb(SqlConnection sqlcon)
    {
        this.sqlc = sqlc = new SqlConnection();
        sqlc.ConnectionString = getConnectionString_hrmdb();
        sqlc.Open();
    }
    public void oracon_open(OracleConnection sqlcon, string _getcon)
    {
        this._orac = _orac = new OracleConnection();
        _orac.ConnectionString = _getcon;
        _orac.Open();
    }
    public void _command_Query(string Sql_query, ref SqlCommand cmd)
    {
        sqlcon_open(sqlc);
        this.cmd = cmd = new SqlCommand(Sql_query, sqlc);
        this.cmd.CommandType = CommandType.Text;
    }
    public void _command_Query_hrm(string Sql_query, ref SqlCommand cmd)
    {
        sqlcon_open_hrmdb(sqlc);
        this.cmd = cmd = new SqlCommand(Sql_query, sqlc);
        this.cmd.CommandType = CommandType.Text;
    }
    public void _command_Stored(string Sql_query, ref SqlCommand cmd)
    {
        sqlcon_open(sqlc);
        this.cmd = cmd = new SqlCommand(Sql_query, sqlc);
        this.cmd.CommandType = CommandType.StoredProcedure;
    }
    public void _command_Stored_hrm(string Sql_query, ref SqlCommand cmd)
    {
        sqlcon_open_hrmdb(sqlc);
        this.cmd = cmd = new SqlCommand(Sql_query, sqlc);
        this.cmd.CommandType = CommandType.StoredProcedure;
    }

    public void _command_Orac_stored_BO(string Sql_query, ref OracleCommand cmd)
    {
        oracon_open(_orac, _oracon.oracleconbo());
        this.oracmd = cmd = new OracleCommand(Sql_query, _orac);
        this.cmd.CommandType = CommandType.StoredProcedure;
    }
    public void _command_Orac_stored_fe(string Sql_query, ref OracleCommand cmd)
    {
        oracon_open(_orac, _oracon.oraclecon());
        this.oracmd = cmd = new OracleCommand(Sql_query, _orac);
        this.cmd.CommandType = CommandType.StoredProcedure;
    }
    public void _command_Orac_stored_cbs(string Sql_query, ref OracleCommand cmd)
    {
        oracon_open(_orac, _oracon.oracleconcbs());
        this.oracmd = cmd = new OracleCommand(Sql_query, _orac);
        this.cmd.CommandType = CommandType.StoredProcedure;
    }

}