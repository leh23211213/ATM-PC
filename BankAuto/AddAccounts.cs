namespace ATM_PC
{
    using System.Data;
    using Microsoft.Data.SqlClient;
    public partial class AddAccounts : Form
    {
        public AddAccounts()
        {
            InitializeComponent();
            DisplayAccounts();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\BankDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
        private void btnSubmitTb_Click(object sender, EventArgs e)
        {
            if (txtNameTb.Text == "" || txtPhoneTb.Text == "" || cbGenderTb.Text == "" || txtAddressTb.Text == "" || txtOccupTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("insert into AccountTbl(AcName,AcPhone,AcAddress,AcGen,AcOccup,AcBal)values(@AN,@AP,@AA,@AG,@AO,@AB)", sqlConnection);
                    cmd.Parameters.AddWithValue("@AN", txtNameTb.Text);
                    cmd.Parameters.AddWithValue("@AP", txtPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@AA", txtAddressTb.Text);
                    cmd.Parameters.AddWithValue("@AG", cbGenderTb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@AO", txtOccupTb.Text);
                    cmd.Parameters.AddWithValue("@AB", 0);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created!");
                    sqlConnection.Close();
                    Reset();
                    DisplayAccounts();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void Reset()
        {
            txtNameTb.Text = "";
            txtPhoneTb.Text = "";
            cbGenderTb.SelectedIndex = -1;
            txtAddressTb.Text = "";
            txtOccupTb.Text = "";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        int Key = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtNameTb.Text = AccountDGV4.SelectedRows[0].Cells[1].Value.ToString().Trim();
            txtPhoneTb.Text = AccountDGV4.SelectedRows[0].Cells[2].Value.ToString().Trim();
            txtAddressTb.Text = AccountDGV4.SelectedRows[0].Cells[3].Value.ToString().Trim();
            cbGenderTb.Text = AccountDGV4.SelectedRows[0].Cells[4].Value.ToString().Trim();
            txtOccupTb.Text = AccountDGV4.SelectedRows[0].Cells[5].Value.ToString().Trim();
            if (txtNameTb.Text == "")
            {
                Key = 0;
            }
            else
            {
                Key = Convert.ToInt32(AccountDGV4.SelectedRows[0].Cells[0].Value.ToString());
            }
        }
        private void DisplayAccounts()
        {
            sqlConnection.Open();
            string Query = "select * from AccountTbl";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Query, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            var dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            AccountDGV4.DataSource = dataSet.Tables[0];
            sqlConnection.Close();
        }
        private void btnEditTb_Click(object sender, EventArgs e)
        {
            if (txtNameTb.Text == "" || txtPhoneTb.Text == "" || cbGenderTb.Text == "" || txtAddressTb.Text == "" || txtOccupTb.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("update AccountTbl set AcName= @AN ,AcPhone= @AP ,AcAddress= @AA, AcGen= @AG, AcOccup= @AO  where AcNum = @AcKey", sqlConnection);
                    cmd.Parameters.AddWithValue("@AN", txtNameTb.Text);
                    cmd.Parameters.AddWithValue("@AP", txtPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@AA", txtAddressTb.Text);
                    cmd.Parameters.AddWithValue("@AG", cbGenderTb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@AO", txtOccupTb.Text);
                    cmd.Parameters.AddWithValue("@AcKey", Key);
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Account Update!");
                    Reset();
                    DisplayAccounts();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void btnCancelTb_Click(object sender, EventArgs e)
        {
            if (Key == 0)
            {
                MessageBox.Show("Select The Account");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("delete from AccountTbl where AcNum = @AcKey", sqlConnection);
                    cmd.Parameters.AddWithValue("@AcKey", Key);
                    cmd.ExecuteNonQuery();
                    sqlConnection.Close();
                    MessageBox.Show("Account Deleted!");
                    Reset();
                    DisplayAccounts();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtNameTb_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
