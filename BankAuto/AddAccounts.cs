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
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\IT\VSCode\Github\ATM-PC\BankAuto\database\Banking.mdf;Integrated Security=True;Connect Timeout=30");
        private void btnSubmitTb_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPhone.Text == "" || cbGender.Text == "" || txtAddress.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("insert into Account(Name,Password,Phone,Address,Gender,Balance) values(@AN,@APassword,@APhone,@AA,@AG,@AB)", sqlConnection);
                    cmd.Parameters.AddWithValue("@AN", txtName.Text);
                    cmd.Parameters.AddWithValue("@APassword", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@APhone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@AA", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@AG", cbGender.SelectedItem.ToString());
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
            txtName.Clear();
            txtPhone.Clear();
            cbGender.SelectedIndex = -1;
            txtAddress.Clear();
            txtPassword.Clear();
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }
        int Key = 0;
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            txtName.Text = AccountDGV4.SelectedRows[0].Cells[1].Value.ToString().Trim();
            txtPhone.Text = AccountDGV4.SelectedRows[0].Cells[2].Value.ToString().Trim();
            txtAddress.Text = AccountDGV4.SelectedRows[0].Cells[3].Value.ToString().Trim();
            cbGender.Text = AccountDGV4.SelectedRows[0].Cells[4].Value.ToString().Trim();
            txtPassword.Text = AccountDGV4.SelectedRows[0].Cells[5].Value.ToString().Trim();
            if (txtName.Text == "")
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
            string Query = "select * from Account";
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(Query, sqlConnection);
            SqlCommandBuilder sqlCommandBuilder = new SqlCommandBuilder(sqlDataAdapter);
            var dataSet = new DataSet();
            sqlDataAdapter.Fill(dataSet);
            AccountDGV4.DataSource = dataSet.Tables[0];
            sqlConnection.Close();
        }
        private void btnEditTb_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "" || txtPhone.Text == "" || cbGender.Text == "" || txtAddress.Text == "" || txtPassword.Text == "")
            {
                MessageBox.Show("Missing Information");
            }
            else
            {
                try
                {
                    sqlConnection.Open();
                    SqlCommand cmd = new SqlCommand("update Account set AcName= @AN ,AcPhone= @AP ,AcAddress= @AA, AcGen= @AG, AcOccup= @AO  where AcNum = @AcKey", sqlConnection);
                    cmd.Parameters.AddWithValue("@AN", txtName.Text);
                    cmd.Parameters.AddWithValue("@APassword", txtPassword.Text);
                    cmd.Parameters.AddWithValue("@APhone", txtPhone.Text);
                    cmd.Parameters.AddWithValue("@AA", txtAddress.Text);
                    cmd.Parameters.AddWithValue("@AG", cbGender.SelectedItem.ToString());
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
                    SqlCommand cmd = new SqlCommand("delete from Account where Id = @AcKey", sqlConnection);
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
        private void guna2PictureBox4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void guna2PictureBox5_Click(object sender, EventArgs e)
        {
            MainMenu Obj = new MainMenu();
            Obj.Show();
            this.Hide();
        }
    }
}
