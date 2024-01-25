using System.Data;
using System.Xml.Linq;
using Microsoft.Data.SqlClient;
namespace ATM_PC
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to exits!", "...", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dialogResult == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            txtPassword.Clear();
            txtUserName.Clear();
            cbRole.SelectedIndex = -1;
            cbRole.Text = "Customer";
        }
        // TODO : xem lại phần check password + account ( để check account number trong transaction)
        private void btnLogin_Click(object sender, EventArgs e)
        {
            SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\IT\VSCode\Github\ATM-PC\BankAuto\database\Banking.mdf;Integrated Security=True;Connect Timeout=30");

            if (string.IsNullOrEmpty(txtPassword.Text) || string.IsNullOrEmpty(txtUserName.Text))
            {
                MessageBox.Show("Enter both Name or Password!");
            }
            else
            {
                // TODO : tạo giao diện với customer
                 if (cbRole.SelectedIndex == 0)
                {
                    sqlConnection.Open();
                    string Query = "select * from Account where Name = @adminName and Password = @password";
                    using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@userName", txtUserName.Text));
                        sqlCommand.Parameters.Add(new SqlParameter("@password", txtPassword.Text));
                        int result = (int)sqlCommand.ExecuteScalar();
                        if (result > 0)
                        {
                            Settings Obj = new Settings();
                            Obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong User Name or Password");
                            Reset();
                            sqlConnection.Close();
                        }
                        sqlConnection.Close();
                    }
                }
                else if (cbRole.SelectedIndex == 1)
                {
                    sqlConnection.Open();
                    string Query = "select * from Admin where Name = @adminName and Password = @password";
                    using (SqlCommand sqlCommand = new SqlCommand(Query, sqlConnection))
                    {
                        sqlCommand.Parameters.Add(new SqlParameter("@adminName", txtUserName.Text));
                        sqlCommand.Parameters.Add(new SqlParameter("@password", txtPassword.Text));
                        int result = (int)sqlCommand.ExecuteScalar();
                        if (result > 0)
                        {
                            MainMenu Obj = new MainMenu();
                            Obj.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Wrong Admin Name or Password");
                            Reset();
                            sqlConnection.Close();
                        }
                        sqlConnection.Close();
                    }
                }
            }
        }
    }
}
