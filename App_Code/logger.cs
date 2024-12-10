using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
/// <summary>
/// Summary description for logger
/// </summary>
public class logger
{
    public string ResponeMessage { get; set; }
    public string _message { get; set; }
    public logger()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    string date = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');

    //string date = DateTime.Now.AddDays(-1).ToString("dd/MMM/yyyy").Replace('/', '-');
    public void LogError(Exception ex)
    {
        ResponeMessage = ex.Message;

        string message = string.Format("Time : {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
        message += Environment.NewLine;
        message += ".................................................................................";
        message += Environment.NewLine;
        message += string.Format("Message : {0}", ex.Message);
        message += Environment.NewLine;
        //message += string.Format("Stacktrace : {0}", ex.StackTrace);
        //message += Environment.NewLine;
        //message += string.Format("Source : {0}", ex.Source);
        //message += Environment.NewLine;
        //message += string.Format("Targetsite : {0}", ex.TargetSite.ToString());
        //message += Environment.NewLine;
        message += ".................................................................................";
        message += Environment.NewLine;

        // string path = HttpContext.Current.Request.MapPath("/Outfile/")+ DateTime.Now.Year.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Day.ToString() + "/logfile.txt";
        string path = HttpContext.Current.Request.MapPath("~/Outfile/" + date + ".txt");
        //string path = HttpContext.Current.Server.MapPath("~/Outfile/logfile.txt");
        using (StreamWriter writer = new StreamWriter(path, true))
        {
            writer.WriteLine(message);
            writer.Close();
        }
    }
}