using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;

public partial class Reportchart_NodeGroupReason : System.Web.UI.Page
{
    SqlConnection sqlc = new SqlConnection();
    SqlCommand cmd = new SqlCommand();
    NodeDownEvent objEvent = new NodeDownEvent();
    NodeDownReason objdownreason = new NodeDownReason();
    logger _logger = new logger();
    public enum MessageType { Success, Error, Info, Warning };
    DropDownListValues _dropdown = new DropDownListValues();
    SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    string eventid;
    string reasongroup;
    string reasontype;
    string channel; 
    int retval;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        eventid = Request.QueryString["EventID"].ToString();
        channel = Request.QueryString["Channel"].ToString();
        if (!IsPostBack)
        {
            Soure_issue();
            EventID_Fundamentals();
        }
    }
    protected void btnedit_Click(object sender, EventArgs e)
    {
        Linkbtnsave.Enabled = true;
        LinkBtncacel.Enabled = true;
        //Open DropDownList
        ddl_Action.Enabled = true;
        ddl_downtimeplan.Enabled = true;
        ddl_groupreason.Enabled = true;
        ddl_reason.Enabled = true;
        //Open Textbox
        txtDescription.Enabled = true;
        txtResolution.Enabled = true;
        txtReasondesc.Enabled = true;
        Linkbtnedit.Enabled = false;
    }
    private void EventID_Fundamentals()
    {
        try
        {
            DataTable dt = objEvent.getFundamentals(eventid);
            txteventno.Text = dt.Rows[0]["EventID"].ToString();
            txtnodetype.Text = dt.Rows[0]["NodeTypeDesc"].ToString();
            txtbranch.Text = dt.Rows[0]["BranchName"].ToString();
            txtnode.Text = dt.Rows[0]["Search"].ToString();
            txtdowntime.Text = dt.Rows[0]["DownTime"].ToString();
            txtuptime.Text = dt.Rows[0]["Uptime"].ToString();
            txtDescription.Text = dt.Rows[0]["ProblemDesc"].ToString();
            txtResolution.Text = dt.Rows[0]["ResolveDesc"].ToString();
            txtReasondesc.Text = dt.Rows[0]["RootCauseDesc"].ToString();
            ddl_downtimeplan.SelectedValue = dt.Rows[0]["PlanStatusID"].ToString();

            //ddl_groupreason.SelectedValue = dt.Rows[0]["GroupTypeID"].ToString();
            ddl_groupreason.SelectedValue = dt.Rows[0]["ReasonGroupID"].ToString();
            bind_reason(ddl_groupreason.SelectedValue);
            bind_action();
            bind_Plan();
            ddl_reason.SelectedValue = dt.Rows[0]["ReasonTypeID"].ToString();
            ddl_Action.SelectedValue = dt.Rows[0]["ActionTypeID"].ToString();
            ddl_downtimeplan.SelectedValue = dt.Rows[0]["PlanStatusID"].ToString();
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
    }
    private DataTable getReasonGroup()
    {
        DataTable dt1 = new DataTable();
        try
        {
            string query = "Select a.GroupTypeID,a.GFullDesc as ReasonGroupDesc from NodeGroupReason a";
            _sqlcmd._command_Query(query, ref cmd);
            dt1.Load(cmd.ExecuteReader());
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
        return dt1;
    }
    public DataTable getReasonTypes(string strReasonGroupID)
    {
        DataTable dt1 = new DataTable();
        try
        {
            string query = "Select a.ReasonTypeID as ReasonTypeID,a.ReasonFullDesc as Reason from NodeDownReason a where a.ReasonGroupID =isnull (@ReasonGroupID,'ReasonGroupID')";
            _sqlcmd._command_Query(query, ref cmd);
            cmd.Parameters.AddWithValue("@ReasonGroupID", strReasonGroupID);
            dt1.Load(cmd.ExecuteReader());

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
        return dt1;
    }
    public DataTable getActions()
    {
        DataTable dt1 = new DataTable();
        try
        {
            string query = "Select a.ActionTypeID,a.ActionTypeDesc from NodeDownActionType a";
            _sqlcmd._command_Query(query, ref cmd);
            dt1.Load(cmd.ExecuteReader());

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
        return dt1;
    }
    private DataTable getReasons()
    {
        DataTable dt1 = new DataTable();
        try
        {
            string query = "Select a.ReasonTypeID as ReasonTypeID,a.ReasonFullDesc as Reason  from NodeDownReason a ";
            _sqlcmd._command_Query(query, ref cmd);
            dt1.Load(cmd.ExecuteReader());

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
        return dt1;
    }
    private DataTable getPlan()
    {
        DataTable dt1 = new DataTable();
        try
        {
            string query = "Select LookupCode as PlanStatusID , FullDesc as PlanStatusDesc from syslookup where lookupID = 'YON'";
            _sqlcmd._command_Query(query, ref cmd);
            dt1.Load(cmd.ExecuteReader());
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
        return dt1;
    }
 
  
    public void bind_reason(string strReasonGroupID)
    {
        try
        {
            _dropdown.bindDropDownList(ddl_reason, objdownreason.D_getReasonTypes(strReasonGroupID));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {

        }
    }
    public void bind_action()
    {
        try
        {
            _dropdown.bindDropDownList(ddl_Action, objdownreason.D_getActions());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {

        }
    }
    public void bind_Plan()
    {
        try
        {
            _dropdown.bindDropDownList(ddl_downtimeplan, objdownreason.D_getPlan());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {

        }
    }
    public void Soure_issue()
    {
        try
        {

            _dropdown.bindDropDownList(ddl_groupreason, objdownreason.D_getReasonGroup());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {

        }
    }
    public void Reasontype()
    {
        try
        {
            ddl_reason.DataSource = getReasons();
            ddl_reason.DataValueField = "ReasonTypeID";
            ddl_reason.DataTextField = "Reason";
            ddl_reason.DataBind();
            ddl_reason.Items.Insert(0, new ListItem("", ""));


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
    }
    private bool update_nodedown()
    {
        try
        {
            objdownreason.eventno = txteventno.Text;
            objdownreason.reason = ddl_reason.SelectedValue;
            objdownreason.s_desc = txtDescription.Text;
            objdownreason.s_resolution = txtResolution.Text;
            objdownreason.s_action = ddl_Action.SelectedValue;
            objdownreason.s_reasondesc = txtReasondesc.Text;
            objdownreason.s_userid = Session["USER_NAME"].ToString();
            bool retval = objdownreason.update_NodeDownReason();
            if (retval == false)
            {
                ShowMessage(objdownreason.Message, MessageType.Error);
            }
            else
            {
                bool retval_insert = objdownreason.insert_NodeDownReasonHis();
                if (retval_insert == false)
                {
                    ShowMessage("Update record!", MessageType.Error);
                }

                else
                {
                    ShowMessage("Update record!", MessageType.Success);
                    Linkbtnsave.Enabled = false;
                    Linkbtnedit.Enabled = true;
                }

                //MsgBox("Successfful !!", this.Page, this);
                ////Response.Write(@"<script language='javascript'>alert('Update Successful !!')</script>");
                ////Response.Redirect("~/Reportchart/solarwindchar.aspx");
                //Server.Transfer("~/Reportchart/solarwindchar.aspx",true); 

            }
            return retval;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
            return false;
        }
        finally
        {
            sqlc.Close();
            sqlc.Dispose();
            SqlConnection.ClearPool(sqlc);
        }
    }
    protected void ddl_groupreason_SelectedIndexChanged1(object sender, EventArgs e)
    {
        bind_reason(ddl_groupreason.SelectedValue);
    }
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        
        if (channel == "ATM")
        {
            Response.Redirect("~/Reportchart/solarwindchar.aspx");
        }
        if (channel == "STM")
        {
            Response.Redirect("~/Reportchart/solarwindstm.aspx");
        }
        else
        {
            Response.Redirect("~/Reportchart/solarwindbranch.aspx");
        }

    }
    protected void btnsave_Click(object sender, EventArgs e)
    {
        update_nodedown();
    }
    public void MsgBox(String ex, Page pg, Object obj)
    {
        string s = "<SCRIPT language='javascript'>alert('" + ex.Replace("\r\n", "\\n").Replace("'", "") + "'); </SCRIPT>";
        Type cstype = obj.GetType();
        ClientScriptManager cs = pg.ClientScript;
        cs.RegisterClientScriptBlock(cstype, s, s.ToString());
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }
}