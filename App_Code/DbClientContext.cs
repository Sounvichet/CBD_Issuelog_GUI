
using System.Configuration;


/// <summary>
/// Summary description for DbClientContext
/// </summary>
public class DbClientContext
{
    public DbClientContext()
    {
        //
        // TODO: Add constructor logic here
        //
    }
    public string getConnectionString()
    {
        string conString = ConfigurationManager.ConnectionStrings["AppConString"].ConnectionString;
        return conString;
    }
}