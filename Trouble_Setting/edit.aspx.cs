using System;
using System.Data;
using System.IO;
using System.Data.SqlClient;

public partial class Trouble_Setting_edit : System.Web.UI.Page
{
    string idedit;
    TroubleSetting _seting = new TroubleSetting();
    DropDownListValues _drop = new DropDownListValues();
    GridViewValues _grid = new GridViewValues();
    SqlConnectAndSqlCommand _sqlcom = new SqlConnectAndSqlCommand();
    SqlCommand cmd = new SqlCommand();
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        idedit = Request.QueryString["ReportCode"].ToString();
        if (!this.IsPostBack)
        {
            _trouble_Fundamentals();
        }
    }
    private void _trouble_Fundamentals()
    {
        DataTable dt = _seting.D_TroubleSetting_Fundamentals(Session["USER_NAME"].ToString(), idedit);
        ReportCode.Text = dt.Rows[0][0].ToString();
        t_issuename.Text = dt.Rows[0][1].ToString();
        t_issuedesc.Text = dt.Rows[0][2].ToString();
    }
    private void _update_trouble()
    {
        string filePath = FileUpload1.PostedFile.FileName;
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
        }
        try
        {
            if (contenttype != String.Empty)
            {

                Stream fs = FileUpload1.PostedFile.InputStream;
                BinaryReader br = new BinaryReader(fs);                                 //reads the   binary files
                Byte[] bytes = br.ReadBytes((Int32)fs.Length);

                _sqlcom._command_Stored("PR_TroubleUpdate", ref cmd);
                //dat.UpdateCommand = new SqlCommand("NodeDownEvents_Update", sqlc);
                cmd.Parameters.AddWithValue("@ReportCat", ReportCode.Text);
                cmd.Parameters.AddWithValue("@ReportCatName", t_issuename.Text);
                cmd.Parameters.AddWithValue("@Report_desc", t_issuedesc.Text);
                cmd.Parameters.AddWithValue("@Name", SqlDbType.NVarChar).Value = filename;
                cmd.Parameters.AddWithValue("@type", SqlDbType.NVarChar).Value = contenttype;
                cmd.Parameters.AddWithValue("@Data", SqlDbType.Binary).Value = bytes;
                cmd.Parameters.Add("@retval", SqlDbType.Int, 8).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();

                int retval = Convert.ToInt32(cmd.Parameters["@retval"].Value); //This will 1 or 0
                if (retval >= 1)
                {
                    Response.Write(@"<script language='javascript'>alert(' Update Successful  !!')</script>");
                    Server.Transfer("~/Trouble_Setting/index.aspx");
                }
            }

            else
            {

                Label1.ForeColor = System.Drawing.Color.Red;
                Label1.Text = "Select Only PDF Files  ";                              // if file is other than speified extension 
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
        finally
        {
            sqlc.Close();
        }

    }

    protected void btnedit_Click(object sender, EventArgs e)
    {
        linkbtnsave.Enabled = true;
        
    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        _update_trouble();
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Trouble_Setting/index.aspx");
    }
}