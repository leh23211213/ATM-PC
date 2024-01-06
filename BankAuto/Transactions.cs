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
        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int balance = 0;
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
                lbYourBalance.Text = dataRow["ACBal"].ToString();
                balance = Convert.ToInt32(dataRow["ACBal"].ToString());
            }
            sqlConnection.Close();
        }
        private void label15_Click(object sender, EventArgs e)
        {
        }
        private void getNewDepositBalance()
        {
            sqlConnection.Open();
            string Query = "select * from AccountTbl where ACNum=" + txtDepositAccountNumber.Text + "";
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                balance = Convert.ToInt32(dataRow["ACBal"].ToString());
            }
            sqlConnection.Close();
        }
        private void Deposit()
        {
            try
            {
                sqlConnection.Open();
                string Query = "insert into TransactionTbl(TName,TDate,TAmount,TAcNum)values(@TN,@TD,@TA,@TAN)";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@TN", "Deposit");
                sqlCommand.Parameters.AddWithValue("@TD", DateTime.Now.Date);
                sqlCommand.Parameters.AddWithValue("@TA", txtDepositAmount.Text);
                sqlCommand.Parameters.AddWithValue("@TAN", txtDepositAccountNumber.Text);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void btnDeposit_Click(object sender, EventArgs e)
        {
            if (txtDepositAccountNumber.Text == "" || txtDepositAmount.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Deposit();
                getNewDepositBalance();
                int newBalance = balance + Convert.ToInt32(txtDepositAmount.Text);
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("Update AccountTbl set ACbal=@AB where ACNum=@AcKey", sqlConnection);
                    cmd.Parameters.AddWithValue("@AB", newBalance);
                    cmd.Parameters.AddWithValue("@AcKey", txtDepositAccountNumber.Text);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Balance Deposited!");
                    sqlConnection.Close();
                    txtDepositAccountNumber.Text = "";
                    txtDepositAmount.Text = "";
                    lbYourBalance.Text = "YourBalance";
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            MainMenu Obj = new MainMenu();
            Obj.Show();
            this.Hide();
        }

        private void btnCheckBalance_Click(object sender, EventArgs e)
        {
            if (txtBalance.Text == "")
            {
                MessageBox.Show("Enter Account Number");
            }
            else
            {
                checkBalance();
                if (lbYourBalance.Text == "YourBalance")
                {
                    MessageBox.Show("Account Not Found");
                    txtBalance.Text = "";
                }
            }
        }

        private void WithDraw()
        {
            try
            {
                sqlConnection.Open();
                string Query = "insert into TransactionTbl(TName,TDate,TAmount,TAcNum)values(@TN,@TD,@TA,@TAN)";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@TN", "WithDraw");
                sqlCommand.Parameters.AddWithValue("@TD", DateTime.Now.Date);
                sqlCommand.Parameters.AddWithValue("@TA", txtWithDrawAmount.Text);
                sqlCommand.Parameters.AddWithValue("@TAN", txtWithDrawAccountNumber.Text);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void getNewWithdrawBalance()
        {
            sqlConnection.Open();
            string Query = "select * from AccountTbl where ACNum=" + txtWithDrawAccountNumber.Text + "";
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                balance = Convert.ToInt32(dataRow["ACBal"].ToString());
            }
            sqlConnection.Close();
        }
        private void btnWithDrawnAmount_Click(object sender, EventArgs e)
        {
            if (txtWithDrawAccountNumber.Text == "" || txtWithDrawAmount.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                WithDraw();
                getNewWithdrawBalance();
                if (balance < Convert.ToInt32(txtWithDrawAmount.Text))
                {
                    MessageBox.Show("Insufisiant Balance");
                }
                else
                {
                    int newBalance = balance - Convert.ToInt32(txtWithDrawAmount.Text);
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand cmd = new SqlCommand("Update AccountTbl set ACbal=@AB where ACNum=@AcKey", sqlConnection);
                        cmd.Parameters.AddWithValue("@AB", newBalance);
                        cmd.Parameters.AddWithValue("@AcKey", txtWithDrawAccountNumber.Text);
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Balance Withdrew!");
                        sqlConnection.Close();
                        txtWithDrawAccountNumber.Text = "";
                        txtWithDrawAmount.Text = "";
                        lbYourBalance.Text = "YourBalance";
                    }
                    catch (Exception Ex)
                    {
                        MessageBox.Show(Ex.Message);
                    }
                }
            }
        }
        private void checkAvailableBalanceFrom()
        {
            string name = null;
            string Query = "select * from AccountTbl where ACNum=" + txtTransferFrom.Text + "";
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                balance = Convert.ToInt32(dataRow["ACBal"].ToString());
                name = dataRow["ACName"].ToString();
            }
            MessageBox.Show($"Name: {name}\nAccountNumber: {txtTransferFrom.Text}\nBalanceAmount: {balance}");
        }
        private void lbCheckTransferFromTxt_Click(object sender, EventArgs e)
        {
            if (txtTransferFrom.Text == "")
            {
                MessageBox.Show("Enter Source Account");
            }
            else
            {
                sqlConnection.Open();
                string Query = "select count(*) from AccountTbl where ACNum='" + txtTransferFrom.Text + "' ";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Query, sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows[0][0].ToString() == "1")
                {
                    checkAvailableBalanceFrom();
                    sqlConnection.Close();
                }
                else
                {
                    MessageBox.Show("Account Does Not Exist");
                    txtTransferFrom.Text = "";
                }
                sqlConnection.Close();
            }
        }

        private void txtTransferFrom_TextChanged(object sender, EventArgs e)
        {

        }
        private void checkAvailableBalanceTo()
        {
            string name = null;
            string Query = "select * from AccountTbl where ACNum=" + txtTransferTo.Text + "";
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                balance = Convert.ToInt32(dataRow["ACBal"].ToString());
                name = dataRow["ACName"].ToString();
            }
            MessageBox.Show($"Name: {name}\nAccountNumber: {txtTransferTo.Text}\nBalanceAmount: {balance}");
        }
        private void lbCheckTransferToTxt_Click(object sender, EventArgs e)
        {
            if (txtTransferTo.Text == "")
            {
                MessageBox.Show("Enter Source Account");
            }
            else
            {
                sqlConnection.Open();
                string Query = "select count(*) from AccountTbl where ACNum='" + txtTransferTo.Text + "' ";
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Query, sqlConnection);
                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                if (dataTable.Rows[0][0].ToString() == "1")
                {
                    checkAvailableBalanceTo();
                    sqlConnection.Close();
                }
                else
                {
                    MessageBox.Show("Account Does Not Exist");
                    txtTransferTo.Text = "";
                }
                sqlConnection.Close();
            }
        }
    }
}
