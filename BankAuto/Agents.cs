using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_PC
{
    public partial class Agents : Form
    {
        public Agents()
        {
            InitializeComponent();
            DisplayAgents();
        }
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\BankDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
        private void Reset()
        {
            txtName.Text = "";
            txtPassword.Text = "";
            txtAddress.Text = "";
            txtPhone.Text = "";
        }
        private void DisplayAgents()
        {
            sqlConnection.Open();
            string Query = "select * from AgentTbl";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Query, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            var dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            AccountDGV4.DataSource = dataSet.Tables[0];
            sqlConnection.Close();
        }

        private void btnSubmitTb_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPhone.Text == "" || txtAddress.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("insert into AgentTbl(AName,APassword,APhone,AAddress)values(@AN,@APA,@AP,@AA)", sqlConnection);
                    cmd.Parameters.AddWithValue("@AN", txtName.Text);
                    cmd.Parameters.AddWithValue("@APA", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@AP", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@AA", txtAddress.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Agent Added!");
                    sqlConnection.Close();
                    Reset();
                    DisplayAgents();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }

        private void txtNameTb_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int Key = 0;
        private void AccountDGV4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = AccountDGV4.SelectedRows[0].Cells[1].Value.ToString().Trim();
            txtPassword.Text = AccountDGV4.SelectedRows[0].Cells[2].Value.ToString().Trim();
            txtPhone.Text = AccountDGV4.SelectedRows[0].Cells[3].Value.ToString().Trim();
            txtAddress.Text = AccountDGV4.SelectedRows[0].Cells[4].Value.ToString().Trim();
            if (txtName.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(AccountDGV4.SelectedRows[0].Cells[0].Value.ToString());
            }
        }

        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            MainMenu Obj = new MainMenu();
            Obj.Show();
            this.Hide();
        }

        private void guna2PictureBox4_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
