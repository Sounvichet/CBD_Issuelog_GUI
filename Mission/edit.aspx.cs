using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Web.UI;
using IncidentDashBoard; 

public partial class Mission_edit : System.Web.UI.Page
{
    string idedit;
    //SqlConnection sqlc = new SqlConnection();
    //logger _logger = new logger();
    //SqlCommand cmd = new SqlCommand();
    //MissionDashBoard _miss = new MissionDashBoard();
    //SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    Mission_Dashboard _miss = new Mission_Dashboard();
    MissionFileUpload _file = new MissionFileUpload();
    public enum MessageType { Success, Error, Info, Warning };
    string filename = "";
    string ext = "";
    string contenttype = "";
    int filesize = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["ticket_no"].ToString();
        if (!IsPostBack)
        {
            BindTextBoxvalues();
        }
    }
    private void BindTextBoxvalues()
    {
        try
        {

            DataTable dt = _miss.D_Mission_Fundamentals(idedit);
            Label8.Text = dt.Rows[0][0].ToString();
            branch_name.Text = dt.Rows[0][1].ToString();
            Source_issue.Text = dt.Rows[0][2].ToString();
            t_status.Text = dt.Rows[0][3].ToString();
            Start_date.Text = dt.Rows[0][4].ToString();
            End_date.Text = dt.Rows[0][5].ToString();
            T_problem_desc.Text = dt.Rows[0][6].ToString();
            T_Solution.Text = dt.Rows[0][7].ToString();
        }
        catch (Exception ex)
        {
            
        }
        finally
        {
            
        }
    }
    private bool _update_mission()
    {
        //string filePath = FileUpload1.PostedFile.FileName;
        //string filename = Path.GetFileName(filePath);
        //string ext = Path.GetExtension(filename);
        //string contenttype = String.Empty;

        _file._filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
        _file._ext  = Path.GetExtension(_file._filename);
        _file._contenttype = String.Empty;

        //SET THE CONTENTTYPE BASE ON FILE EXTENSION
        switch (_file._ext)
        {
            case ".doc":
                _file._contenttype = "application/vnd.ms-word";
                break;
            case ".docx":
                _file._contenttype = "application/vnd.ms-word";
                break;
            case ".xls":
                _file._contenttype = "application/vnd.ms-excel";
                break;
            case ".xlsx":
                _file._contenttype = "application/vnd.ms-excel";
                break;
            case ".jpg":
                _file._contenttype = "image/jpg";
                break;
            case ".png":
                _file._contenttype = "image/png";
                break;
            case ".gif":
                _file._contenttype = "image/gif";
                break;
            case ".pdf":
                _file._contenttype = "application/pdf";
                break;
            case ".rar":
                _file._contenttype = "application/rar";
                break;
        }

        filesize = FileUpload1.PostedFile.ContentLength;

        _miss._ticketno = Label8.Text;
        _miss._sdate = Start_date.Text;
        _miss._edate = End_date.Text;
        _miss._solution = T_Solution.Text;
        bool _update_status = _miss._update_status_mission();
        if (_update_status == false)
        {
            ShowMessage("Update fail with Ticket " + Label8.Text + "", MessageType.Error);
        }
        else
        {
            _file._ticket = Label8.Text;
            bool _file_update = _file._FileUpload_mission(FileUpload1);
            if (_file_update == false)
            {
                ShowMessage("Update ticket success but upload file is empty !! ", MessageType.Info);
            }
            else
            {
                ShowMessage("Ticket and file upload are success", MessageType.Success);
            }
            return _file_update;

        }
        return _update_status;
    }

    protected void Register_Mission(object sender, EventArgs e)
    {
        if (Start_date.Text != "" && End_date.Text != "")
        {
            _update_mission();
        }
        else
        {
            Response.Write(@"<script language='javascript'>alert('DO not allow start_date and End_date NUll')</script>");
        }
    }

    //public bool _FileUpload_mission()
    //{

    //    try
    //    {
    //        if (contenttype != String.Empty)
    //        {

    //            bool _getupload = _file._FileUpload_mission(FileUpload1);
    //            if (_getupload == false)
    //            {
    //                ShowMessage("Ticket and file upload are success" + _file._message, MessageType.Error);
    //            }
    //            else
    //            {
    //                return true;
    //            }
    //            return _getupload;
    //        }
    //        else
    //        {
    //            return false;
    //        }
               
    //    }
    //    catch (Exception ex)
    //    {
    //        ShowMessage("Upload missionfile is error ", MessageType.Info);
    //        return false;
    //    }
    //    finally
    //    {
           
    //    }
    //}
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/mission/index.aspx");
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

}