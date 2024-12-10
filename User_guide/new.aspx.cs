using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.IO;


public partial class User_guide_new : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    DropDownListValues _drop = new DropDownListValues();
    GridViewValues _grid = new GridViewValues();
    FormUserGuide _guide = new FormUserGuide();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        string currentdate = DateTime.Now.ToString("dd/MMM/yyyy").Replace('/', '-');
        if (!this.IsPostBack)
        {
            t_userid.Text = Session["USER_NAME"].ToString();
            t_post_date.Text = currentdate;
        }
    }

    private void _INSERT_FORM()
    {
        string filePath = file_attach1.PostedFile.FileName;
        string filename = Path.GetFileName(filePath);
        string ext = Path.GetExtension(filename);
        string contenttype = String.Empty;

        //SET THE CONTENTTYPE BASE ON FILE EXTENSION
        switch (ext)
        {
            case ".doc":
                contenttype = "application/vnd.ms-word";
                break;
            case ".docx":
                contenttype = "application/vnd.ms-word";
                break;
            case ".xls":
                contenttype = "application/vnd.ms-excel";
                break;
            case ".xlsx":
                contenttype = "application/vnd.ms-excel";
                break;
            case ".jpg":
                contenttype = "image/jpg";
                break;
            case ".png":
                contenttype = "image/png";
                break;
            case ".gif":
                contenttype = "image/gif";
                break;
            case ".pdf":
                contenttype = "application/pdf";
                break;
            case ".rar":
                contenttype = "application/rar";
                break;
            case ".msg":
                contenttype = "application/msg";
                break;
            case ".zip":
                contenttype = "application/zip";
                break;
        }
        try
        {
            int filesize = file_attach1.PostedFile.ContentLength;


            if (contenttype != String.Empty)
            {

                Stream fs = file_attach1.PostedFile.InputStream;

                BinaryReader br = new BinaryReader(fs);                                 //reads the   binary files

                Byte[] bytes = br.ReadBytes((Int32)fs.Length);                           //counting the file length into bytes


                _sqlcmd._command_Stored("PR_Upload_UserGuide", ref cmd);
                cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = filename;
                cmd.Parameters.AddWithValue("@file_size", filesize); 
                cmd.Parameters.AddWithValue("@file_type", SqlDbType.NVarChar).Value = contenttype;
                cmd.Parameters.AddWithValue("@Data", SqlDbType.Binary).Value = bytes;
                cmd.Parameters.AddWithValue("@Form_Name", txtform_Name.Text);
                cmd.Parameters.AddWithValue("@Post_date", t_post_date.Text);
                cmd.Parameters.AddWithValue("@Post_by", t_userid.Text);
                cmd.Parameters.AddWithValue("@indicator", D_Indicator.Text);
                cmd.Parameters.AddWithValue("@Channel", D_service.SelectedValue);
                cmd.Parameters.Add("@retval", SqlDbType.Int, 8).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
                if (retval >= 1)
                {
                    ShowMessage("Successful Upload file", MessageType.Success);
                }
                else
                {

                    ShowMessage("Error upload file", MessageType.Error); 
                }

            }

            else
            {

                Label lbl1 = new Label();

                lbl1.ForeColor = System.Drawing.Color.Red;
                lbl1.Text = "Select Only PDF Files  ";                              // if file is other than speified extension 

            }
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            _logger._message = ex.Message;
            // Response.Write(@"<script language='javascript'>alert('" + _logger._message + " !!')</script>");
        }
        finally
        {
            sqlc.Close();
        }
    }
    protected void btn_save_Click(object sender, EventArgs e)
    {
        _INSERT_FORM();
    }

    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("Form_userguide.aspx");
    }
    public void _drop_Indicator()
    {
        _drop.bindDropDownList(D_service, _guide.D_bind_indicatorbyService(D_Indicator.Text));
    }
    protected void D_Indicator_SelectedIndexChanged(object sender, EventArgs e)
    {
        _drop_Indicator();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}