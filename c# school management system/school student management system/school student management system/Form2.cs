using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;
using System.Security.Cryptography;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace school_student_management_system
{

    public partial class frmStudent : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS04; Initial Catalog = 'Student sys'; Integrated Security = True;");


        public frmStudent()
        {
            InitializeComponent();


        }

        SqlCommand cmd;
        DataTable dt;
        DataRow dr;
        string Gender, code;
        DialogResult res;
        SqlDataAdapter adapt;

       

        public void clear()
        {
            txtStudID.Clear();
            txtfirstname.Clear();
            txtmail.Clear();
            txttelno.Clear();
            rbmale.Checked = false;
            rbfemale.Checked = false;
            cmbgrade.Text = "";
        }

        private void label4_Click(object sender, EventArgs e)
        {


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmStudent_Load(object sender, EventArgs e)
        {
            FILLDGV();
            string valuetosearch = txtsearch.Text;
            searchdata(valuetosearch);



        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            clear();

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                object sel = cmbgrade.SelectedValue;
                SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS04; Initial Catalog = 'Student sys'; Integrated Security = True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbstudent(StudentID,firstname,emali,tp,gender,grade) values('" + txtStudID.Text + "','" + txtfirstname.Text + "','" + txtmail.Text + "','" + txttelno.Text + "','" + Gender + "','" + cmbgrade.Text + "')", con);
                cmd.ExecuteNonQuery();
                this.clear();
                MessageBox.Show("Record saved successfully", "save", MessageBoxButtons.OK, MessageBoxIcon.Information);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }

            con.Close();


        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            object sel = cmbgrade.SelectedValue;
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS04; Initial Catalog = 'Student sys'; Integrated Security = True;");
            con.Open();
            SqlCommand cmd = new SqlCommand(@"update dbstudent set firstName = @firstName, emali = @emali, tp = @tp, gender =@gender ,grade =@grade where StudentID = @StudentID  ", con);
            cmd.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = txtStudID.Text;
            cmd.Parameters.Add("@firstname", SqlDbType.VarChar).Value = txtfirstname.Text;
            cmd.Parameters.Add("@emali", SqlDbType.VarChar).Value = txtmail.Text;
            cmd.Parameters.Add("@tp", SqlDbType.VarChar).Value = txttelno.Text;
            cmd.Parameters.Add("@gender", SqlDbType.VarChar).Value = Gender;
            cmd.Parameters.Add("@grade", SqlDbType.VarChar).Value = cmbgrade.Text;



            cmd.ExecuteNonQuery();
            con.Close();



            this.clear();
            MessageBox.Show("Record updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

            con.Close();

                  
        }


        private void btndelete_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS04; Initial Catalog = 'Student sys'; Integrated Security = True;");
            SqlDataAdapter da = new SqlDataAdapter();
            da.UpdateCommand = new SqlCommand(@"delete from dbstudent  where StudentID = @StudentID  ", con);
            da.UpdateCommand.Parameters.Add("@StudentID", SqlDbType.VarChar).Value = txtStudID.Text;


            con.Open();
            da.UpdateCommand.ExecuteNonQuery();

            con.Close();

            this.clear();

            MessageBox.Show("Record deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtStudID_TextChanged(object sender, EventArgs e)
        {

        }

        private void rbmale_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Male";
        }

        private void rbfemale_CheckedChanged(object sender, EventArgs e)
        {
            Gender = "Female";
        }

        private void cmbgrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            con = new SqlConnection();

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {


        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            string valuetosearch = txtsearch.Text.ToString();
             searchdata(valuetosearch);
        }

        private void txtsearch_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
        private void FILLDGV()
        {
            con.Open();
            string query = "Select * From dbstudent";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            con.Close();
        }

        public void searchdata(string valuetosearch)
        {
            string query = "select * from dbstudent where StudentID like '%" + valuetosearch + "%'";
            SqlCommand command = new SqlCommand(query, con);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            dataGridView1.DataSource = dt;



        }
    }
}