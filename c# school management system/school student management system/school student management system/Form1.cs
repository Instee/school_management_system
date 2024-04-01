using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace school_student_management_system
{
    public partial class frmMainMenu : Form
    {
        
        public frmMainMenu()
        {
            InitializeComponent();
            
        }

        private void btnTeachers_Click(object sender, EventArgs e)
        {
            frmTeachers teachers = new frmTeachers();
            teachers.Show();
        }

        private void btnStudent_Click(object sender, EventArgs e)
        {
            frmStudent student = new frmStudent();
            student.Show();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
