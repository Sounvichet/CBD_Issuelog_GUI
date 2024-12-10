using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using IncidentDashBoard; 

public partial class Mission_delete : System.Web.UI.Page
{
    string idedit;
    //SqlConnection sqlc = new SqlConnection();
    //logger _logger = new logger();
    //SqlCommand cmd = new SqlCommand();
    //dbcon obj1 = new dbcon();
    //MissionDashBoard _Miss = new MissionDashBoard();
    Mission_Dashboard _Miss = new Mission_Dashboard();
    public enum MessageType { Success, Error, Info, Warning };
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
            DataTable dt = _Miss.D_Missiondelete_Fundamentals(idedit);
            Problem_ID.Text = dt.Rows[0][0].ToString();
            Branch_name.Text = dt.Rows[0][1].ToString();
        }
        catch (Exception ex)
        {
            ShowMessage("Error Mission fundamental..!", MessageType.Error);
        }
        finally
        {
          
        }
    }

    private bool _deletemission()
    {
        bool retval = _Miss.Delete_mission(idedit);

        if (retval == false)
        {
            //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + _Miss._message + "\");", true);
            // Response.Write("<script>alert('" + _miss._message + "')</script>");
             ShowMessage("Registerd Fail please try again..!", MessageType.Error);

        }
        else
        {
           // ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"Deleted Successful!\");", true);
             ShowMessage("Delete Successfully ..!", MessageType.Success);
            //Response.Redirect("~/mission/index.aspx");
        }
        return retval;
    }

    protected void Btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/mission/index.aspx");
    }

    protected void Btndelete_Click(object sender, EventArgs e)
    {
        _deletemission();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}