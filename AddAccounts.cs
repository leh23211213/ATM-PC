namespace ATM_PC
{
    using Microsoft.Data.SqlClient;
    public partial class AddAccounts : Form
    {
        public AddAccounts()
        {
            InitializeComponent();
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
                    SqlCommand cmd = new SqlCommand("insert into AccountTbl(AcName,AcPhone,AcAddress,AcGen,AcOccup,AcBal)values(@AN,@AP,@AA,@AG,@AO,@AB)", sqlConnection);
                    sqlConnection.Open();
                    cmd.Parameters.AddWithValue("@AN", txtNameTb.Text);
                    cmd.Parameters.AddWithValue("@AP", txtPhoneTb.Text);
                    cmd.Parameters.AddWithValue("@AA", txtAddressTb.Text);
                    cmd.Parameters.AddWithValue("@AG", cbGenderTb.SelectedItem.ToString());
                    cmd.Parameters.AddWithValue("@AO", txtOccupTb.Text);
                    cmd.Parameters.AddWithValue("@AB", 0);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Account Created!");
                    sqlConnection.Close();
                }
                catch (Exception Ex)
                {
                    MessageBox.Show(Ex.Message);
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditTb_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelTb_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
