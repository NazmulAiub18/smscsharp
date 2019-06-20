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
    public partial class Admin_Portal : Form
    {
        DataAccess a = new DataAccess();
        public Admin_Portal()
        {
            InitializeComponent();
        }

        public Admin_Portal(string Id)
        {
            InitializeComponent();
            AdminId.Text = Id;
        }

        public void InitialStudentPanel()
        {
            sName.Text = "";
            comboBox1.Text = "1";
            sFName.Text = "";
            sMName.Text = "";
            sDOB.Text = "";
            sAdd.Text = "";
            sMail.Text = "";
            radioButton1.Checked = true;
            sImage.Image = null;
        }

        public void InitialTeacherPanel()
        {
            tName.Text = "";
            tCA.Text = "";
            tPA.Text = "";
            tMail.Text = "";
            tNationality.Text = "";
            tDoB.Text = "";
            tMS.Text = "Married";
            tSSC.Text = "";
            tHSC.Text = "";
            tUnder.Text = "";
            tGraduate.Text = "";
            radioButton3.Checked = true;
            tImage.Image = null;
        }

        private void Admin_Portal_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Admin_Portal_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = a.GetStudentList();
            dataGridView2.DataSource = a.GetTeacherList();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Login b = new Login();
            b.Visible = true;
            this.Hide();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = a.SearchStudentById(int.Parse(textBox1.Text));

            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No result found");
                InitialStudentPanel();
            }
            else
            {
                sName.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[1].Value.ToString();
                comboBox1.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[2].Value.ToString();
                sFName.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[3].Value.ToString();
                sMName.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[4].Value.ToString();
                sDOB.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[5].Value.ToString();
                sAdd.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[6].Value.ToString();
                sMail.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[7].Value.ToString();

                if (dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[8].Value.ToString() == "Male")
                {
                    radioButton1.Checked = true;
                }
                else
                    radioButton2.Checked = true;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Id Field Empty ! Please Select Student First", "Error");
                InitialStudentPanel();
            }
            else
            {
                a.ApproveStudent(int.Parse(textBox1.Text));
                MessageBox.Show("Student Approved !", "Error");
            }



        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //i = (int)dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[0].Value;
            textBox1.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[0].Value.ToString();

            sName.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[1].Value.ToString();
            comboBox1.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[2].Value.ToString();
            sFName.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[3].Value.ToString();
            sMName.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[4].Value.ToString();
            sDOB.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[5].Value.ToString();
            sAdd.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[6].Value.ToString();
            sMail.Text = dataGridView1.Rows[(dataGridView1.SelectedCells[0].RowIndex)].Cells[7].Value.ToString();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Id Field Empty ! Please Select Student First", "Error");
                InitialStudentPanel();
            }
            else
            {
                a.RejectStudent(int.Parse(textBox1.Text));
                MessageBox.Show("Student Rejected !", "Error");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            dataGridView1.DataSource = a.GetStudentList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            panel2.Visible = true;
            panel1.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            dataGridView2.DataSource = a.GetTeacherList();
        }

        private void button12_Click(object sender, EventArgs e)
        {
            dataGridView2.DataSource = a.SearchTeacherById(int.Parse(textBox2.Text));

            if (dataGridView2.Rows.Count == 0)
            {
                MessageBox.Show("No result found");
                InitialTeacherPanel();
            }
            else
            {
                tName.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[1].Value.ToString();
                tCA.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[2].Value.ToString();
                tPA.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[3].Value.ToString();
                tNationality.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[4].Value.ToString();
                tDoB.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[5].Value.ToString();
                tMS.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[6].Value.ToString();
                tMail.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[7].Value.ToString();
                tSSC.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[8].Value.ToString();
                tHSC.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[9].Value.ToString();
                tUnder.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[10].Value.ToString();
                tGraduate.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[11].Value.ToString();

                if (dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[14].Value.ToString() == "Male")
                {
                    radioButton3.Checked = true;
                }
                else
                    radioButton4.Checked = true;
            }
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox2.Text = tName.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[0].Value.ToString();
            tName.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[1].Value.ToString();
            tCA.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[2].Value.ToString();
            tPA.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[3].Value.ToString();
            tNationality.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[4].Value.ToString();
            tDoB.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[5].Value.ToString();
            tMS.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[6].Value.ToString();
            tMail.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[7].Value.ToString();
            tSSC.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[8].Value.ToString();
            tHSC.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[9].Value.ToString();
            tUnder.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[10].Value.ToString();
            tGraduate.Text = dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[11].Value.ToString();

            if (dataGridView2.Rows[(dataGridView2.SelectedCells[0].RowIndex)].Cells[14].Value.ToString() == "Male")
            {
                radioButton3.Checked = true;
            }
            else
                radioButton4.Checked = true;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Id Field Empty ! Please Select Teacher First", "Error");
                InitialTeacherPanel();
            }
            else
            {
                a.ApproveTeacher(int.Parse(textBox2.Text));
                MessageBox.Show("Teacher Approved !", "Error");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Id Field Empty ! Please Select Teacher First", "Error");
                InitialTeacherPanel();
            }
            else
            {
                a.RejectTeacher(int.Parse(textBox2.Text));
                MessageBox.Show("Teacher Rejected !", "Error");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel5.Visible = false;
            panel4.Visible = false;
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = true;
            comboTeacher.DataSource = a.GetAllTeacherName();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            MessageBox.Show(a.AddAssign(SubjectName.Text,comboTeacher.Text,comboClass.Text),"Message");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = true;
            panel5.Visible = false;
            cmbTeacher.DataSource = a.GetAllTeacherName();
        }

        private void button14_Click(object sender, EventArgs e)
        {
            MessageBox.Show(a.SendNoticeToTeacher(cmbTeacher.Text,Subject.Text,Notice.Text),"Message");
            cmbTeacher.Text = "";
            Subject.Text = "";
            Notice.Text = "";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = true;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            if (NewPass.Text == NewCPass.Text)
            {
                if (a.Validation(int.Parse(AdminId.Text), OldPass.Text) != null)
                {
                    a.ChangePassword(int.Parse(AdminId.Text),NewPass.Text,"A");
                    MessageBox.Show("Password Changed Successfull !", "Success");
                }
                else
                {
                    MessageBox.Show("Incorrect Old Password !", "Error");
                }
            }
            else
            {
                MessageBox.Show("New and Confirm Password Doesnot Match !","Warning");
            }
        }
    }
}
