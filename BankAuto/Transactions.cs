using Microsoft.Data.SqlClient;
using Microsoft.IdentityModel.Tokens;
using System.Data;
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
            balance = 0;
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
        private void getNewBalance(string BalanceText)
        {
            balance = 0;
            sqlConnection.Open();
            string Query = "select * from AccountTbl where ACNum=" + BalanceText + "";
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
            if (string.IsNullOrEmpty(txtDepositAccountNumber.Text) || string.IsNullOrEmpty(txtDepositAmount.Text))
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                Deposit();
                getNewBalance(txtDepositAccountNumber.Text);
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
        private void btnWithDrawnAmount_Click(object sender, EventArgs e)
        {
            if (txtWithDrawAccountNumber.Text == "" || txtWithDrawAmount.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                balance = 0;
                WithDraw();
                getNewBalance(txtWithDrawAccountNumber.Text);
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
        private void checkAvailableBalance(string text)
        {
            string name = null;
            string Query = "select * from AccountTbl where ACNum=" + text + "";
            SqlCommand cmd = new SqlCommand(Query, sqlConnection);
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            sqlDataAdapter.Fill(dataTable);
            foreach (DataRow dataRow in dataTable.Rows)
            {
                balance = Convert.ToInt32(dataRow["ACBal"].ToString());
                name = dataRow["ACName"].ToString();
            }
            MessageBox.Show($"Name: {name}\nAccountNumber: {text}\nBalanceAmount: {balance}");
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
                    checkAvailableBalance(txtTransferFrom.Text);
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
                    checkAvailableBalance(txtTransferTo.Text);
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
        private void updateDataTransfer()
        {
            try
            {
                sqlConnection.Open();
                string Query = "insert into TransferTbl(TfSource,TfDestination,TfAmount,TfDate)values(@TfS,@TfD,@TfA,@TfT)";
                SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection);
                sqlCommand.Parameters.AddWithValue("@TfS", txtTransferFrom.Text);
                sqlCommand.Parameters.AddWithValue("@TfD", txtTransferTo.Text);
                sqlCommand.Parameters.AddWithValue("@TfA", txtTransferAmount.Text);
                sqlCommand.Parameters.AddWithValue("@TfT", DateTime.Now.Date);
                sqlCommand.ExecuteNonQuery();
                MessageBox.Show("Transfer Success");
                sqlConnection.Close();
            }
            catch (Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }
        private void resetTransferText() {
            txtTransferFrom.Text = "";
            txtTransferTo.Text = "";
            txtTransferAmount.Text = "";
        }
        private void transferBalance()
        {
            balance = 0;
            getNewBalance(txtTransferFrom.Text);
            int addBalance = balance + Convert.ToInt32(txtTransferAmount.Text);
            int substractBalance = balance - Convert.ToInt32(txtTransferAmount.Text);
            string addBalanceQuery = "UPDATE AccountTbl SET ACBal = @AB WHERE ACNum = @AcKey1";
            string substractBalanceQuery = "UPDATE AccountTbl SET ACBal = @AC WHERE ACNum = @AcKey2";
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
            balance = 0;
            if(txtTransferFrom.Text == "" || txtTransferTo.Text == "" || txtTransferAmount.Text == "")
            {
                MessageBox.Show("Missing Information");
            } 
            else if(Convert.ToInt16(txtTransferAmount.Text) < balance) 
            {
                MessageBox.Show("Insufisiant Balance");
            } 
            else
            {
                updateDataTransfer();
                transferBalance();
            }
        }
     }
 }
