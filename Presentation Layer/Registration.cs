using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Data_Access_Layer;

namespace Presentation_Layer
{
    public partial class Registration : Form
    {
        DataAccess a = new DataAccess();
        //private Image curImage = null;
        //private string curFileName = null;
        public Registration()
        {
            InitializeComponent();
            panel1.Visible = false;
            panel2.Visible = false;
        }

        public void InitialForm()
        {
            sName.Text = "";
            comboBox1.Text = "1";
            sFName.Text = "";
            sMName.Text = "";
            sDOB.Text = "";
            sAdd.Text = "";
            sMail.Text=""; 
            sPass.Text="";
            sCPass.Text="";
            radioButton1.Checked = true;

            tName.Text = "";
            tCA.Text = "";
            tPA.Text = "";
            tMail.Text = "";
            tNationality.Text = "";
            tDoB.Text = "";
            tMS.Text = "Married";
            tPass.Text = "";
            tCPass.Text = "";
            radioButton3.Checked = true;
            tSSC.Text = "";
            tHSC.Text = "";
            tUnder.Text = "";
            tGraduate.Text = "";
        }

        private void Registration_Load(object sender, EventArgs e)
        {
            InitialForm();
        }

        private void Registration_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "Student")
            {
                panel1.Visible = true;
                panel2.Visible = false;
            }
            else if (comboBox3.Text == "Teacher")
            {
                panel2.Visible = true;
                panel1.Visible = false;
            }
            InitialForm();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (a.InsertInAll(sPass.Text, sCPass.Text, sMail.Text, "S"))
                {
                    a.InsertStudent(sName.Text, int.Parse(comboBox1.Text), sFName.Text, sMName.Text, sDOB.Text, sAdd.Text, sMail.Text, sPass.Text, sCPass.Text, radioButton1.Text, ImageName.Text,a.GetId(sMail.Text));
                    MessageBox.Show("Registration Successfull Your Id Is : " + a.GetId(sMail.Text), "Success");
                    InitialForm();
                }
                else
                {
                    MessageBox.Show("Password does not match", "Warning");
                }
            }
            else
            {
                if (a.InsertInAll(sPass.Text, sCPass.Text, sMail.Text,"S"))
                {
                    a.InsertStudent(sName.Text, int.Parse(comboBox1.Text), sFName.Text, sMName.Text, sDOB.Text, sAdd.Text, sMail.Text, sPass.Text, sCPass.Text, radioButton2.Text, ImageName.Text, a.GetId(sMail.Text));
                    MessageBox.Show("Registration Successfull Your Id Is : " + a.GetId(sMail.Text), "Success");
                    InitialForm();
                }
                else
                {
                    MessageBox.Show("Password does not match", "Warning");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "All Image files | *.jpg";
            string filter = openDlg.Filter;
            openDlg.Title = "Open a Image(.jpg) File";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                ImageName.Text = openDlg.FileName; 
            }
            sImage.ImageLocation = ImageName.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login l = new Login();
            l.Visible = true;
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            OpenFileDialog openDlg = new OpenFileDialog();
            openDlg.Filter = "All Image files | *.jpg";
            string filter = openDlg.Filter;
            openDlg.Title = "Open a Image(.jpg) File";
            if (openDlg.ShowDialog() == DialogResult.OK)
            {
                label26.Text = openDlg.FileName;
            }
            tImage.ImageLocation = label26.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (radioButton3.Checked == true)
            {
                if (a.InsertInAll(tPass.Text, tCPass.Text, tMail.Text,"T"))
                {
                    a.InsertTeacher(tName.Text, tCA.Text, tPA.Text, tNationality.Text, tDoB.Text, tMS.Text, tMail.Text, tSSC.Text, tHSC.Text, tUnder.Text, tGraduate.Text, tPass.Text, tCPass.Text, radioButton3.Text, label26.Text, a.GetId(tMail.Text));
                    MessageBox.Show("Registration Successfull Your Id Is : " + a.GetId(tMail.Text), "Success");
                    InitialForm();
                }
                else
                {
                    MessageBox.Show("Password does not match", "Warning");
                }
            }
            else
            {
                if (a.InsertInAll(tPass.Text, tCPass.Text, tMail.Text,"T"))
                {
                    a.InsertTeacher(tName.Text, tCA.Text, tPA.Text, tNationality.Text, tDoB.Text, tMS.Text, tMail.Text, tSSC.Text, tHSC.Text, tUnder.Text, tGraduate.Text, tPass.Text, tCPass.Text, radioButton4.Text, label26.Text, a.GetId(tMail.Text));
                    MessageBox.Show("Registration Successfull Your Id Is :" + a.GetId(tMail.Text), "Success");
                    InitialForm();
                }
                else
                {
                    MessageBox.Show("Password does not match", "Warning");
                }
            }
        }
    }
}
