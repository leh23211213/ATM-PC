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
    public partial class Transactions : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\BankDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
        public Transactions()
        {
            InitializeComponent();
        }

        private void Transactions_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int balance;
        private void checkBalance()
        {
            sqlConnection.Open();
            string Query = "select * from AccountTbl where ACNum=" + txtBalance.Text + "";
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                lbYourBlance.Text =  dataRow["ACBal"].ToString();
                balance = Convert.ToInt32(dataRow["ACBal"].ToString());
            }
            sqlConnection.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (txtBalance.Text == "")
            {
                MessageBox.Show("Enter Account Number");
            }
            else
            {
                checkBalance();
                if(lbYourBlance.Text == "YourBalance")
                {
                    MessageBox.Show("Account Not Found");
                    txtBalance.Text = "";
                }
            }
        }

        private void label15_Click(object sender, EventArgs e)
        {

        }
    }
}
