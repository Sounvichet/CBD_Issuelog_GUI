using System;
using System.Data;
using System.Web.UI;
using IncidentDashBoard; 

public partial class Mission_new : System.Web.UI.Page
{
    //SqlConnection sqlc = new SqlConnection();
    //logger _logger = new logger();
    //SqlCommand cmd = new SqlCommand();
    DropDownListValues _drop = new DropDownListValues();
    //SqlConnectAndSqlCommand _sqlcmd = new SqlConnectAndSqlCommand();
    //MissionDashBoard _miss = new MissionDashBoard();
    Mission_Dashboard _miss = new Mission_Dashboard();
    string ticket;
    public enum MessageType { Success, Error, Info, Warning };
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["User_Name"] == null)
        {
            ClientScript.RegisterStartupScript(GetType(), "Load", "<script type='text/javascript'>window.location.href = '../issuelog/Default.aspx'; </script>");
        }
        if (!IsPostBack)
        {
            bind_Channel_infor();
            bind_FC_1();
            bind_FC_2();
            bind_problem_type();
            _getAction();
        }
    }
    public void bind_Channel_infor()
    {
        _drop.bindDropDownList(d_Branch_Name, _miss.D_branch_name());
    }
    public void bind_problem_type()
    {
        _drop.bindDropDownList(d_Problem_Type, _miss.D_problem_type());
    }
    public void bind_FC_1()
    {
        _drop.bindDropDownList(d_Name_1, _miss.D_FC_STAFFNAME());
    }
    public void bind_FC_2()
    {
        _drop.bindDropDownList(d_Name_2, _miss.D_FC_STAFFNAME());
    }
    public void _getAction()
    {
        _drop.bindDropDownList(D_ActionType, _miss.D_getActions());
    }
    public void bind_Terminal_info()
    {

        try
        {
            DataTable dt = _miss.D_Mission_Terminal_info(t_Terminal.SelectedValue);
            if (dt.Rows.Count > 0)
            {
                t_Product_Type.Text = dt.Rows[0]["ATM_TYPE"].ToString();
                t_Model_Type.Text = dt.Rows[0]["ATM_SERIES"].ToString();
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert(\"" + _miss._message + "\");", true);
            }

        }
        catch (Exception ex)
        {
            ShowMessage("Mission Terminal info is error!!", MessageType.Success);
        }
        finally
        {
           
        }
    }
    private string AutoIncrementID()
    {
        DataTable dt = _miss.D_get_AutoIncrementID();
        string id = dt.Rows[0][0].ToString();
        return id;
    }
    private DataTable D_bind_terminalName()
    {
        DataTable dt = new DataTable();

        return dt;
    }
    private bool _RegisterMIssion()
    {
        _miss._branch_name = d_Branch_Name.SelectedValue;
        _miss._terminal = t_Terminal.SelectedValue;
        _miss._product_type = t_Product_Type.Text;
        _miss._model_type = t_Model_Type.Text;
        _miss._problem_type = d_Problem_Type.SelectedValue;
        _miss._equitment = t_Equitment.Text;
        _miss._start_date = t_Start_date.Text;
        _miss._end_date = t_End_date.Text;
        _miss._day = D_days.Text;
        _miss._night = d_nights.Text;
        _miss._name_1 = d_Name_1.SelectedValue;
        _miss._position1 = "N'" + t_Position_1.Text + "'";
        _miss._company1 = t_Company_1.Text;
        _miss._phone1 = t_Phone_1.Text;
        _miss._staff_id1 = t_Staff_ID_1.Text;
        _miss._gender1 = t_Gender_1.Text;
        _miss._name_2 = d_Name_2.SelectedValue;
        _miss._position2 = "N'" + t_Position_2.Text + "'";
        _miss._company2 = t_Company_2.Text;
        _miss._phone2 = t_Phone_2.Text;
        _miss._staff_id2 = t_Staff_ID_2.Text;
        _miss._gender2 = t_Gender_2.Text;
        _miss._Status = D_ActionType.SelectedValue;
        _miss._Problem_desc = T_Problem_desc.Text;
        _miss._username = Session["User_Name"].ToString();
        bool retval = _miss.Register_mission();

        if (retval == false)
        {
            ShowMessage("Registerd Fail please try again..!", MessageType.Error);
        }
        else
        {
            ShowMessage("registerd mission is successful with ticket : "+_miss._getTicketno+"..!", MessageType.Success);

        }
        return retval;
    }
    protected void d_Branch_Name_SelectedIndexChanged(object sender, EventArgs e)
    {
        //bind_Branch_name("tblinfoproduct", "P_Branch_name_sub_Mission", d_Branch_Name.SelectedValue);
        //t_Terminal.DataSource = obj1.D_bind_Terminal_mission(d_Branch_Name.SelectedValue);
        //t_Terminal.DataTextField = "TerminalIDName";
        //t_Terminal.DataBind();
        //t_Terminal.Items.Insert(0, new ListItem("", ""));

        _drop.bindDropDownList(t_Terminal, _miss.D_Mission_get_Terminal(d_Branch_Name.SelectedValue));
    }
    protected void d_Name_1_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = _miss.D_FC_Fundamental(d_Name_1.SelectedValue);
        t_Position_1.Text = dt.Rows[0][3].ToString();
        t_Company_1.Text = dt.Rows[0][4].ToString();
        t_Phone_1.Text = dt.Rows[0][09].ToString();
        t_Staff_ID_1.Text = dt.Rows[0][0].ToString();
        t_Gender_1.Text = dt.Rows[0][2].ToString();

    }
    protected void d_Name_2_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable dt = _miss.D_FC_Fundamental(d_Name_2.SelectedValue);
        t_Position_2.Text = dt.Rows[0][3].ToString();
        t_Company_2.Text = dt.Rows[0][4].ToString();
        t_Phone_2.Text = dt.Rows[0][09].ToString();
        t_Staff_ID_2.Text = dt.Rows[0][0].ToString();
        t_Gender_2.Text = dt.Rows[0][2].ToString();
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string _get_term_id = t_Terminal.SelectedItem.ToString();
        if (_get_term_id != "")
        {
            _RegisterMIssion();
        }
        else
        {
            ShowMessage("Not require Terminal null please check again!!", MessageType.Error);
        }

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Mission/index.aspx");
    }
    protected void t_Terminal_SelectedIndexChanged(object sender, EventArgs e)
    {
        bind_Terminal_info();
    }
    protected void ShowMessage(string Message, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, this.GetType(), System.Guid.NewGuid().ToString(), "ShowMessage('" + Message + "','" + type + "');", true);
    }

    protected void t_End_date_TextChanged(object sender, EventArgs e)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(t_Start_date.Text))
            {
                DateTime d1 = DateTime.Parse(t_End_date.Text);
                DateTime d2 = DateTime.Parse(t_Start_date.Text);

                if (d1 == d2)
                {
                    D_days.Text = "1";
                    d_nights.Text = "0";
                }
                
                else
                {
                    D_days.Text = "" + ((d1 > d2) ? (d1 - d2).TotalDays : (d1 - d2).TotalDays);
                    int days = Convert.ToInt32(D_days.Text);
                    D_days.Text = (days + 1).ToString();
                    d_nights.Text = days.ToString();
                }
                     
                 
            }
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}