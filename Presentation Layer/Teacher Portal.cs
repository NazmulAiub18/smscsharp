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
    
    public partial class Teacher_Portal : Form
    {
        DataAccess a = new DataAccess();
        public Teacher_Portal()
        {
            InitializeComponent();
        }

        public Teacher_Portal(string id,string Name)
        {
            InitializeComponent();
            tID.Text = id;
            tName.Text = Name;
        }

        private void Teacher_Portal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            FTerm.Text = "";
            STerm.Text = "";
            Final.Text = "";
            comboBox3.DataSource = null;
            comboBox3.DataSource = a.GetSubjectOfTeacherByClass(comboBox1.SelectedItem.ToString(), tName.Text);
            comboBox2.DataSource = null;
            comboBox2.DataSource = a.GetAllStudentId(comboBox1.SelectedItem.ToString());
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            sName.Text = "";
            sName.Text = a.GetStudentNameById(comboBox2.SelectedItem.ToString());
            FTerm.Text = "";
            FTerm.Text = a.GetFirstTermMark(comboBox1.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());
            STerm.Text = "";
            STerm.Text = a.GetSecondTermMark(comboBox1.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());
            Final.Text = "";
            Final.Text = a.GetFinalTermMark(comboBox1.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString());
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (a.GetResultValidation(comboBox1.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString()) == "false")
            {
                a.InsertInResult(comboBox1.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(),FTerm.Text,STerm.Text,Final.Text);
                MessageBox.Show("Insert Result Success","Success");
            }
            else
            {
                a.UpdateInResult(comboBox1.SelectedItem.ToString(), comboBox3.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), FTerm.Text, STerm.Text, Final.Text);
                MessageBox.Show("Update Result Success", "Success");
            }
        }

        private void Teacher_Portal_Load(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            FileLocatin.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel1.Visible = true;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox5.DataSource = null;
            comboBox5.DataSource = a.GetSubjectOfTeacherByClass(comboBox4.SelectedItem.ToString(), tName.Text);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (FileLocatin.Text == "" || comboBox5.Text == "")
            {
                MessageBox.Show("Please Select Subject Or File First", "Error");
            }
            else
            {
                a.InsertStudentNote(comboBox4.Text,comboBox5.Text, FileLocatin.Text);
                MessageBox.Show("Note Upload Successfull !", "Success");
                FileLocatin.Text = "";
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "DOC Files(*.doc)|*.doc|PDF Files(*.pdf)|*.pdf|TEXT Files(*.text*)|*.text*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                FileLocatin.Text = dlg.FileName.ToString();
            }﻿
        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox7.DataSource = null;
            comboBox7.DataSource = a.GetSubjectOfTeacherByClass(comboBox6.SelectedItem.ToString(), tName.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (comboBox7.Text == "" || Reason.Text == "" || Notice.Text == "")
            {
                MessageBox.Show("All Fields Must Not Be Empty", "Error");
            }
            else
            {
                a.InsertStudentNotice(comboBox6.Text, comboBox7.Text, Reason.Text, Notice.Text);
                MessageBox.Show("Notice Sent Successfull !", "Success");
                Reason.Text = "";
                Notice.Text = "";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel4.Visible = true;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;

            dataGridView1.DataSource=a.GetTeacherNotificationList(tName.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
            panel6.Visible = false;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (NewPass.Text == NewCPass.Text)
            {
                if (a.Validation(int.Parse(tID.Text), OldPass.Text) != null)
                {
                    a.ChangePassword(int.Parse(tID.Text), NewPass.Text, "T");
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

        private void button7_Click(object sender, EventArgs e)
        {
            Login a = new Login();
            a.Visible = true;
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel6.Visible = true;
            panel5.Visible = false;
            panel4.Visible = false;
            panel3.Visible = false;
            panel2.Visible = false;
            panel1.Visible = false;

            textBox1.Text = a.GetTName(tID.Text);
            tCA.Text = a.GetTCA(tID.Text);
            tPA.Text = a.GetTPA(tID.Text);
            tMail.Text = a.GetTEmail(tID.Text);
            tNationality.Text = a.GetTNationality(tID.Text);
            tDoB.Text = a.GetTDoB(tID.Text);
            tMS.Text = a.GetTMS(tID.Text);
            tSSC.Text = a.GetTSSC(tID.Text);
            tHSC.Text = a.GetTHSC(tID.Text);
            if (a.GetTGender(tID.Text) == "Male")
                radioButton3.Checked = true;
            else
                radioButton4.Checked = true;
            tUnder.Text = a.GetTUnder(tID.Text);
            tGraduate.Text = a.GetTGrade(tID.Text);
            label30.Text = a.GetTImage(tID.Text);
            tImage.ImageLocation = a.GetTImage(tID.Text);


            
        }

        private void button13_Click(object sender, EventArgs e)
        {
            a.UpdateTeacher(textBox1.Text, tCA.Text, tPA.Text, tNationality.Text, tDoB.Text, tMS.Text, tMail.Text, tSSC.Text, tHSC.Text, tUnder.Text, tGraduate.Text, label30.Text, int.Parse(tID.Text));
            MessageBox.Show("Profile Updated Successfully !", "Success");
        }

        private void button14_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "All Image files | *.jpg";
            string filter = openDlg.Filter;
            openDlg.Title = "Open a Image(.jpg) File";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                label30.Text = openDlg.FileName;
            }
            tImage.ImageLocation = label30.Text;
        }
    }
}
