using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

public partial class Reportchart_ViewNodeDownEvent : System.Web.UI.Page
{
    NodeDownEvent objEvent = new NodeDownEvent();
    NodeDownReason objdownreason = new NodeDownReason();
    DropDownListValues _dropdown = new DropDownListValues();
    GridViewValues _gridview = new GridViewValues();
    SqlConnection sqlc = new SqlConnection();
    logger _logger = new logger();
    string eventid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["USER_NAME"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        eventid = Request.QueryString["EventID"].ToString();
        if (!IsPostBack)
        {
            Soure_issue();
            EventID_Fundamentals();
            _getgridview_Fundamentals();
        }
    }
    public void Soure_issue()
    {
        try
        {
            _dropdown.bindDropDownList(d_groupReason, objdownreason.D_getReasonGroup());
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
    private void EventID_Fundamentals()
    {
        try
        {
            DataTable dt = objEvent.getFundamentals(eventid);
            txtEventno.Text = dt.Rows[0]["EventID"].ToString();
            txtNodetype.Text = dt.Rows[0]["NodeTypeDesc"].ToString();
            txtbranchname.Text = dt.Rows[0]["BranchName"].ToString();
            txtNodeName.Text = dt.Rows[0]["Search"].ToString();
            txtdowntime.Text = dt.Rows[0]["DownTime"].ToString();
            txtuptime.Text = dt.Rows[0]["Uptime"].ToString();
            txtdesc.Text = dt.Rows[0]["ProblemDesc"].ToString();
            txtResolution.Text = dt.Rows[0]["ResolveDesc"].ToString();
            txtreasondesc.Text = dt.Rows[0]["RootCauseDesc"].ToString();
            D_DownTimePlan.SelectedValue = dt.Rows[0]["PlanStatusID"].ToString();
            //ddl_groupreason.SelectedValue = dt.Rows[0]["GroupTypeID"].ToString();
            d_groupReason.SelectedValue = dt.Rows[0]["ReasonGroupID"].ToString();
            bind_reason(d_groupReason.SelectedValue);
            bind_action();
            bind_Plan();
            D_reason.SelectedValue = dt.Rows[0]["ReasonTypeID"].ToString();
            D_action.SelectedValue = dt.Rows[0]["ActionTypeID"].ToString();
            D_DownTimePlan.SelectedValue = dt.Rows[0]["PlanStatusID"].ToString();
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
    private void _getgridview_Fundamentals()
    {
        _gridview._GridviewBinding(GridView2, objEvent.getFundamentalsHis(eventid));
        Label10.Text = GridView2.Rows.Count.ToString();
    }
    public void bind_action()
    {
        try
        {
            _dropdown.bindDropDownList(D_action, objdownreason.D_getActions());
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
            _dropdown.bindDropDownList(D_DownTimePlan, objdownreason.D_getPlan());
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {

        }
    }
    public void bind_reason(string strReasonGroupID)
    {
        try
        {
            _dropdown.bindDropDownList(D_reason, objdownreason.D_getReasonTypes(strReasonGroupID));
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
        finally
        {
        }
    }
    protected void btncancel_Click1(object sender, EventArgs e)
    {
        if (txtNodetype.Text == "ATM")
        {
            Response.Redirect("~/Reportchart/solarwindchar.aspx");
        }
        else
        {
            Response.Redirect("~/Reportchart/solarwindbranch.aspx");
        }

    }
}