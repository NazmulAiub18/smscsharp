using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data_Access_Layer;

namespace Presentation_Layer
{
    public partial class Login : Form
    {
        DataAccess a = new DataAccess();
        public Login()
        {
            InitializeComponent();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            Id.Text = "";
            Pass.Text = "";
        }

        public void InitialForm()
        {
            Id.Text = "";
            Pass.Text = "";
        }


        private void button2_Click(object sender, EventArgs e)
        {
            Registration a = new Registration();
            a.Visible = true;
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (a.Validation(int.Parse(Id.Text), Pass.Text) == null)
            {
                MessageBox.Show("Invalid Id Or Password !!", "Error");
            }
            else if (a.Validation(int.Parse(Id.Text), Pass.Text) == "P")
            {
                MessageBox.Show("Your Registration Still Pending For Admin Approval !!","Error");
                InitialForm();
            }
            else if (a.Validation(int.Parse(Id.Text), Pass.Text) == "R")
            {
                MessageBox.Show("Your Registration Rejected By Admin !!", "Error");
                InitialForm();
            }
            else if (a.Validation(int.Parse(Id.Text), Pass.Text) == "A")
            {
                if (a.ToGUI(int.Parse(Id.Text), Pass.Text) == "A")
                {
                    Admin_Portal g = new Admin_Portal(Id.Text);
                    g.Visible = true;
                    this.Hide();
                }
                else if (a.ToGUI(int.Parse(Id.Text), Pass.Text) == "T")
                {

                    Teacher_Portal h = new Teacher_Portal(Id.Text, a.GetTeacherNameById(Id.Text));
                    h.Visible = true;
                    this.Hide();
                }
                else if (a.ToGUI(int.Parse(Id.Text), Pass.Text) == "S")
                {
                    Student_Portal s = new Student_Portal(Id.Text);
                    s.Visible = true;
                    this.Hide();
                }
            }
        }
    }
}
