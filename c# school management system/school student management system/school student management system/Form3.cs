using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using school_student_management_system.Student_sysDataSet1TableAdapters;

namespace school_student_management_system
{
    public partial class frmTeachers : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=localhost\\SQLEXPRESS04;Initial Catalog=Student sys;Integrated Security=True;");
        public frmTeachers()
        {
            InitializeComponent();



        }
        public void clear()
        {
            txtFullName.Clear();
            txtAdd.Clear();
            txtContactNo.Clear();
            txtNIC.Clear();
            cmbGender.ResetText();
            txtPEmail.Clear();
            cmbMarital.ResetText();
            cmbReligion.ResetText();
            txtENumber.Clear();
            txtEntityName.Clear();
            dtpDOJ.ResetText();
            txtLocation.Clear();
            txtEmail.Clear();
            cmbEmType.ResetText();
        }
        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void frmTeachers_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'student_sysDataSet2.dbteachers' table. You can move, or remove it, as needed.
            this.dbteachersTableAdapter1.Fill(this.student_sysDataSet2.dbteachers);
            // TODO: This line of code loads data into the 'student_sysDataSet1.dbteachers' table. You can move, or remove it, as needed.
            this.dbteachersTableAdapter.Fill(this.student_sysDataSet1.dbteachers);
            FILLDGV();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                object sel = cmbEmType.SelectedValue;
                object sel2 = cmbGender.SelectedValue;
                object sel3 = cmbMarital.SelectedValue;
                object sel4 = cmbReligion.SelectedValue;
                SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS04; Initial Catalog = 'Student sys'; Integrated Security = True;");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO dbteachers(Full_Name,Address,Contact_Number,NIC,Gender,Personal_Email,Marital_Status,Religion,Employee_Number,Entity_Name,DOJ,Primary_Location,Email,Employment_Type) values('" + txtFullName.Text + "','" + txtAdd.Text + "','" + txtContactNo.Text + "','" + txtNIC.Text + "','" + cmbGender.Text + "','" + txtPEmail.Text + "','" + cmbMarital.Text + "','" + cmbReligion.Text + "','" + txtENumber.Text + "','" + txtEntityName.Text + "','" + dtpDOJ.Value.Date + "','" + txtLocation.Text + "','" + txtEmail.Text + "','" + cmbEmType.Text + "')", con);
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

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            clear();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
           
                object sel = cmbEmType.SelectedValue;
                object sel2 = cmbGender.SelectedValue;
                object sel3 = cmbMarital.SelectedValue;
                object sel4 = cmbReligion.SelectedValue;
                SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS04; Initial Catalog = 'Student sys'; Integrated Security = True;");

                con.Open();

                SqlCommand cmd = new SqlCommand(@"update dbteachers set  Full_Name=@Full_Name, Address= @Address, Contact_Number=@Contact_Number,NIC=@NIC,Gender=@Gender,Personal_Email=@Personal_Email,Marital_Status=@Marital_Status,Religion=@Religion,Entity_Name=@Entity_Name,DOJ=@DOJ,Primary_Location=@Primary_Location,Email=@Email,Employment_Type=@Employment_Type where Employee_Number=@Employee_Number ", con);
                cmd.Parameters.Add("@Employee_Number", SqlDbType.VarChar).Value = txtENumber.Text;
                cmd.Parameters.Add("@Full_Name", SqlDbType.VarChar).Value = txtFullName.Text;
                cmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = txtAdd.Text;
                cmd.Parameters.Add("@Contact_Number", SqlDbType.VarChar).Value = txtContactNo.Text;
                cmd.Parameters.Add("@NIC", SqlDbType.VarChar).Value = txtNIC.Text;
                cmd.Parameters.Add("@Gender", SqlDbType.VarChar).Value = cmbGender.Text;
                cmd.Parameters.Add("@Personal_Email", SqlDbType.VarChar).Value = txtPEmail.Text;
                cmd.Parameters.Add("@Marital_Status", SqlDbType.VarChar).Value = cmbMarital.Text;
                cmd.Parameters.Add("@Religion", SqlDbType.VarChar).Value = cmbReligion.Text;

                cmd.Parameters.Add("@Entity_Name", SqlDbType.VarChar).Value = txtEntityName.Text;
                cmd.Parameters.Add("@DOJ", SqlDbType.VarChar).Value = dtpDOJ.Value.Date;
                cmd.Parameters.Add("@Primary_Location", SqlDbType.VarChar).Value = txtLocation.Text;
                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = txtEmail.Text;
                cmd.Parameters.Add("@Employment_Type", SqlDbType.VarChar).Value = cmbEmType.Text;


                cmd.ExecuteNonQuery();
                MessageBox.Show("Record updated successfully", "Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                con.Close();
           


            this.clear();
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS04; Initial Catalog = 'Student sys'; Integrated Security = True;");
            SqlDataAdapter da = new SqlDataAdapter();
            da.UpdateCommand = new SqlCommand(@"delete from dbteachers  where Employee_Number = @Employee_Number  ", con);
            da.UpdateCommand.Parameters.Add("@Employee_Number", SqlDbType.VarChar).Value = txtENumber.Text;


            con.Open();
            da.UpdateCommand.ExecuteNonQuery();

            con.Close();

            this.clear();

            MessageBox.Show("Record deleted successfully", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


        private void FILLDGV()
        {
            SqlConnection con = new SqlConnection(@"Data Source = localhost\SQLEXPRESS04; Initial Catalog = 'Student sys'; Integrated Security = True;");
            con.Open();
            string query = "Select * From dbteachers";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.AllowUserToAddRows = false;
            con.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

