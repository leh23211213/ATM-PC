using Microsoft.Data.SqlClient;
using System.Data;
namespace ATM_PC
{
    public partial class Transactions : Form
    {
        decimal balance = 0;
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\IT\VSCode\Github\ATM-PC\BankAuto\database\Banking.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
        public Transactions()
        {
            InitializeComponent();
        }
        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void checkBalance()
        {
            balance = 0;
            sqlConnection.Open();
            string Query = "SELECT * FROM Account WHERE Number = @AB";
            using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@AB", txtBalance.Text);
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    lbYourBalance.Text = dataRow["Balance"].ToString();
                }
            }
            sqlConnection.Close();
        }
        private void getNewBalance(string BalanceText)
        {
            try{
               if(sqlConnection.State == ConnectionState.Open)
                {
                    sqlConnection.Close();
                }
                sqlConnection.Open();
                string Query = "SELECT * FROM Account WHERE Number = @AN";
                using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@AN", BalanceText);
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    sqlDataAdapter.Fill(dataTable);
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        balance = decimal.Parse(dataRow["Balance"].ToString());
                    }
                }
                sqlConnection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                sqlConnection.Close();
            }
        }
        private void Deposit()
        {
            try
            {
                sqlConnection.Open();
                string Query = "INSERT INTO Transactions(Type,SourceAccountNumber,Date,Amount) VALUES(@TT,@TDAN,@TD,@TA)";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@TT", "Deposit");
                sqlCommand.Parameters.AddWithValue("@TDAN", txtDepositAccountNumber.Text);
                sqlCommand.Parameters.AddWithValue("@TD", DateTime.Now);
                sqlCommand.Parameters.AddWithValue("@TA", txtDepositAmount.Text);
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
            if (string.IsNullOrEmpty(txtDepositAccountNumber.Text) || string.IsNullOrEmpty(txtDepositAmount.Text))
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Deposit();
                getNewBalance(txtDepositAccountNumber.Text);
                decimal newBalance = balance + decimal.Parse(txtDepositAmount.Text);
                try
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("UPDATE Account SET Balance = @AB WHERE Number = @AcKey", sqlConnection);
                    sqlCommand.Parameters.AddWithValue("@AB", newBalance);
                    sqlCommand.Parameters.AddWithValue("@AcKey", txtDepositAccountNumber.Text);
                    sqlCommand.ExecuteNonQuery();
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
                string Query = "INSERT INTO Transactions(Type,SourceAccountNumber,Date,Amount) VALUES(@TWT,@TWAN,@TWD,@TWA)";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@TWT", "WithDraw");
                sqlCommand.Parameters.AddWithValue("@TWAN", txtWithDrawAccountNumber.Text);
                sqlCommand.Parameters.AddWithValue("@TWD", DateTime.Now);
                sqlCommand.Parameters.AddWithValue("@TWA", txtWithDrawAmount.Text);
                sqlCommand.ExecuteNonQuery();
                sqlConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void btnWithDrawnAmount_Click(object sender, EventArgs e)
        {
            if (txtWithDrawAccountNumber.Text == "" || txtWithDrawAmount.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                getNewBalance(txtWithDrawAccountNumber.Text);
                if (balance < decimal.Parse(txtWithDrawAmount.Text))
                {
                    MessageBox.Show("Insufisiant Balance");
                }
                else
                {
                    decimal newBalance = balance - decimal.Parse(txtWithDrawAmount.Text);
                    try
                    {
                        sqlConnection.Open();
                        SqlCommand sqlCommand = new SqlCommand("UPDATE Account SET Balance = @AB WHERE Number = @AcKey", sqlConnection);
                        sqlCommand.Parameters.AddWithValue("@AB", newBalance);
                        sqlCommand.Parameters.AddWithValue("@AcKey", txtWithDrawAccountNumber.Text);
                        sqlCommand.ExecuteNonQuery();
                        MessageBox.Show("Balance Withdraw Success!");
                        WithDraw();
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
        private void checkAvailableBalance(string text)
        {
            string name = null;
            string Query = "SELECT * FROM Account WHERE Number = @AN";
            using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
            {
                sqlCommand.Parameters.AddWithValue("@AN", text);
                DataTable dataTable = new DataTable();
                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    balance = decimal.Parse(dataRow["Balance"].ToString());
                    name = dataRow["Number"].ToString();
                }
                MessageBox.Show($"Name: {name}\nAccountNumber: {text}\nBalanceAmount: {balance}");
            }
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
                string Query = "SELECT COUNT(*) FROM Account WHERE Number = @ATS";
                using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ATS", txtTransferFrom.Text);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0].ToString() == "1")
                    {
                        checkAvailableBalance(txtTransferFrom.Text);
                        sqlConnection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Account Does Not Exist");
                        txtTransferFrom.Text = "";
                    }
                }
                sqlConnection.Close();
            }
        }
        private void lbCheckTransferToTxt_Click(object sender, EventArgs e)
        {
            if (txtTransferTo.Text == "")
            {
                MessageBox.Show("Enter Destination Account");
            }
            else
            {
                sqlConnection.Open();
                string Query = "SELECT COUNT(*) FROM Account WHERE Number = @ATD";
                using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ATD", txtTransferTo.Text);
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    if (dataTable.Rows[0][0].ToString() == "1")
                    {
                        checkAvailableBalance(txtTransferTo.Text);
                        sqlConnection.Close();
                    }
                    else
                    {
                        MessageBox.Show("Account Does Not Exist");
                        txtTransferTo.Text = "";
                    }
                }
                sqlConnection.Close();
            }
        }
        private void updateDataTransfer()
        {
            try
            {
                sqlConnection.Open();
                string Query = "INSERT INTO Transactions(Type,SourceAccountNumber,Date,Amount,DestinationAccount) VALUES(@TTT,@TTS,@TTD,@TTA,@TTDes)";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@TTT", "Transfer");
                sqlCommand.Parameters.AddWithValue("@TTS", txtTransferFrom.Text);
                sqlCommand.Parameters.AddWithValue("@TTD", DateTime.Now);
                sqlCommand.Parameters.AddWithValue("@TTA", txtTransferAmount.Text);
                sqlCommand.Parameters.AddWithValue("@TTDes", txtTransferTo.Text);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Transfer Success");
                sqlConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void resetTransferText()
        {
            txtTransferFrom.Text = "";
            txtTransferTo.Text = "";
            txtTransferAmount.Text = "";
        }
        private void updateBalanceTransfer()
        {
            getNewBalance(txtTransferFrom.Text);
            decimal substractBalance = balance - decimal.Parse(txtTransferAmount.Text);
            string addBalanceQuery = "UPDATE Account SET Balance = @AB WHERE Number = @AcKey1";
            string substractBalanceQuery = "UPDATE Account SET Balance = @AC WHERE Number = @AcKey2";
            decimal addBalance = balance + decimal.Parse(txtTransferAmount.Text);
            try
            {
                sqlConnection.Open();
                SqlCommand cmd1 = new SqlCommand(addBalanceQuery, sqlConnection);
                SqlCommand cmd2 = new SqlCommand(substractBalanceQuery, sqlConnection);
                cmd1.Parameters.AddWithValue("@AB", substractBalance);
                cmd2.Parameters.AddWithValue("@AC", addBalance);
                cmd1.Parameters.AddWithValue("@AcKey1", txtTransferFrom.Text);
                cmd2.Parameters.AddWithValue("@AcKey2", txtTransferTo.Text);
                cmd1.ExecuteNonQuery();
                cmd2.ExecuteNonQuery();
                sqlConnection.Close();
                resetTransferText();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void btnTransfer_Click(object sender, EventArgs e)
        {
            if (txtTransferFrom.Text == "" || txtTransferTo.Text == "" || txtTransferAmount.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                sqlConnection.Open();
                string Query = "SELECT COUNT(*) FROM Account WHERE Number = @ANTS or Number = @ANTD";
                using(SqlCommand sqlCommand = new SqlCommand(Query,sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@ANTS", txtTransferTo.Text);
                    sqlCommand.Parameters.AddWithValue("@ANTD", txtTransferFrom.Text);
                    int check = (int)sqlCommand.ExecuteScalar();
                    if (check == 2)
                    {
                        getNewBalance(txtTransferFrom.Text);
                        if (decimal.Parse(txtTransferAmount.Text) > balance)
                        {
                            MessageBox.Show($"Insufisiant Balance {balance}");
                            sqlConnection.Close();
                        }
                        else
                        {
                            updateDataTransfer();
                            updateBalanceTransfer();
                            sqlConnection.Close();
                        }
                    }
                    else
                    {
                        MessageBox.Show($"Account Not Exists");
                        sqlConnection.Close();
                    }
                }
            }
        }
    }
}
