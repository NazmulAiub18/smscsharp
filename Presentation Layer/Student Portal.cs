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
    public partial class Student_Portal : Form
    {
        DataAccess a = new DataAccess();
        public Student_Portal()
        {
            InitializeComponent();
        }
        public Student_Portal(string Id)
        {
            InitializeComponent();
            sID.Text = Id;
            sNam.Text = a.GetSName(Id);
            sClass.Text = a.GetSClass(Id);
        }

        private void Student_Portal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login a = new Login();
            a.Visible = true;
            this.Hide();
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (NewPass.Text == NewCPass.Text)
            {
                if (a.Validation(int.Parse(sID.Text), OldPass.Text) != null)
                {
                    a.ChangePassword(int.Parse(sID.Text), NewPass.Text, "S");
                    MessageBox.Show("Password Changed Successfull !", "Success");
                }
                else
                {
                    MessageBox.Show("Incorrect Old Password !", "Error");
                }
            }
            else
            {
                MessageBox.Show("New and Confirm Password Doesnot Match !", "Warning");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Visible = false;
            sName.Text = a.GetSName(sID.Text);
            sFName.Text = a.GetSFName(sID.Text);
            sMName.Text = a.GetSMName(sID.Text);
            sDOB.Text = a.GetSDoB(sID.Text);
            sAdd.Text = a.GetSAdd(sID.Text);
            sMail.Text = a.GetSMail(sID.Text);
            if (a.GetSGender(sID.Text) == "Male")
                radioButton1.Checked = true;
            else
                radioButton2.Checked = true;
            ImageLoc.Text = a.GetSImage(sID.Text);
            sImage.ImageLocation = ImageLoc.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "All Image files | *.jpg";
            string filter = openDlg.Filter;
            openDlg.Title = "Open a Image(.jpg) File";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                ImageLoc.Text = openDlg.FileName;
            }
            sImage.ImageLocation = ImageLoc.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            a.UpdateStudent(sName.Text, sFName.Text, sMName.Text, sDOB.Text, sAdd.Text, sMail.Text, ImageLoc.Text, int.Parse(sID.Text));
            MessageBox.Show("Profile Updated Successfully !", "Success");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            panel3.Visible = false;
            ComboSubject.DataSource = null;
            ComboSubject.DataSource = a.GetSubjectOfStudentByClass(sClass.Text);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = a.GetStudentNotice(sClass.Text,ComboSubject.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = null;
            dataGridView2.DataSource = a.GetStudentNote(sClass.Text, ComboSubject.Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel3.Visible = false;
            comboBox1.DataSource = null;
            comboBox1.DataSource = a.GetSubjectOfStudentByClass(sClass.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel3.Visible = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel3.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            comboBox3.DataSource = null;
            comboBox3.DataSource = a.GetSubjectOfStudentByClass(sClass.Text);
        }

        private void button11_Click(object sender, EventArgs e)
        {
            FirstResult.Text = "";
            SecondResult.Text = "";
            FinalResult.Text = "";
            FirstResult.Text = a.GetFirstTermMark(sClass.Text, comboBox3.Text, sID.Text);
            SecondResult.Text = a.GetSecondTermMark(sClass.Text, comboBox3.Text, sID.Text);
            FinalResult.Text = a.GetFinalTermMark(sClass.Text, comboBox3.Text, sID.Text);




        }
    }
}
