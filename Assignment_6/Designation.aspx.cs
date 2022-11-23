using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_6
{
    public partial class Designation : System.Web.UI.Page
    {
        DBOperation db = new DBOperation();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) //can avoid page refreshing problem
            {
                SqlConnection con1 = new SqlConnection();
                con1.ConnectionString = "Data Source=NTP-LAP-841;Initial Catalog=Assignments;Integrated Security=True;Pooling=False";
                con1.Open();
                /*SqlCommand com = new SqlCommand("Select * from Department", con1);
                SqlDataAdapter da = new SqlDataAdapter(com);
                DataSet ds = new DataSet();
                da.Fill(ds);*/
                DropDownList1.DataSource = db.exedataset("Select * from dep");
                DropDownList1.DataTextField = "depname";
                DropDownList1.DataValueField = "DepartmentId";
                DropDownList1.DataBind();
                GridView1.DataSource = db.exedataset("select * from Designation");
                GridView1.DataBind();

            }

        }
        protected void Gridview1_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridView1.EditIndex = e.NewEditIndex; //set edit index
            GridView1.DataSource = db.exedataset("select * from Designation"); //value taking from table
            GridView1.DataBind(); //binding data extracted from the table to the grid view 
        }

        protected void Gridview1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //take datakey value from grid view
            string Designation_Id = GridView1.DataKeys[e.RowIndex].Value.ToString(); //tacking emp value of the selected row
            //create a text box and initialize
            TextBox txtDesg = new TextBox();
            //access first column and assign to textbox
            txtDesg = (TextBox)GridView1.Rows[e.RowIndex].Cells[1].Controls[0];
            Response.Write("<script>alert(txtDesg);</script>");
            db.exenonquery("update Designation set DesignationName='" + txtDesg.Text + "'where DesignationId='" + Designation_Id + "'");
            GridView1.EditIndex = -1;  //previous view stage -1 indicate previous view only 
            GridView1.DataSource = db.exedataset("select * from Designation");
            GridView1.DataBind();

        }

        protected void Gridview1_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridView1.EditIndex = -1;  //previous view stage -1 indicate previous view only 
            GridView1.DataSource = db.exedataset("select * from Designation");
            GridView1.DataBind();

        }

        protected void Gridview1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string desg_id = GridView1.DataKeys[e.RowIndex].Value.ToString(); //tacking emp value of the selected row
            db.exenonquery("Delete from Designation where DesignationId='" + desg_id + "'");
            GridView1.DataSource = db.exedataset("select * from Designation");
            GridView1.DataBind();
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int id = int.Parse(DropDownList1.SelectedItem.Value);
            string sql = "insert into Designation values('" + textdesg.Text + "','" + id + "')";
            int i = db.exenonquery(sql);
            if (i == 1)
            {
                Response.Write("<script>alert('inserted Successfully ');</script>");
            }
            else
            {
                Response.Write("Insertion Fail");
            }
            GridView1.DataSource = db.exedataset("select * from Designation");
            GridView1.DataBind();
        }
    }
}