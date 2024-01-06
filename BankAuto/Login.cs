using System.Data;
using Microsoft.Data.SqlClient;
namespace ATM_PC
{
    public partial class Login : Form
    {
        SqlConnection sqlConnection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\lenovo\Documents\BankDb.mdf;Integrated Security=True;Connect Timeout=30;Encrypt=True");
        public Login()
        {
            InitializeComponent();
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void Reset()
        {
            txtPassword.Text = "";
            txtUserName.Text = "";
            cbRole.SelectedIndex = -1;
            cbRole.Text = "Role";
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbRole.SelectedIndex == -1)
            {
                MessageBox.Show("Select the Role");
            }
            else if (cbRole.SelectedIndex == 0)
            {
                if (txtPassword.Text == "" || txtUserName.Text == "")
                {
                    MessageBox.Show("Enter both admin name and password!");
                }
                else
                {
                    sqlConnection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select count(*) from AdminTbl where AdName ='" + txtUserName.Text + "'and AdPassword ='" + txtPassword.Text + "'", sqlConnection);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    if(dataTable.Rows[0][0].ToString() == "1")
                    {
                        Agents Obj = new Agents();
                        Obj.Show();
                        this.Hide();
                    }else {
                        MessageBox.Show("Wrong Admin Name or Password");
                        Reset();
                    }
                    sqlConnection.Close();
                }
            }
            else
            {
                if (txtPassword.Text == "" || txtUserName.Text == "")
                {
                    MessageBox.Show("Enter both User Name or Password!");
                }
                else
                {
                    sqlConnection.Open();
                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("select count(*) from AgentTbl where AName ='" + txtUserName.Text + "'and APassword ='" + txtPassword.Text + "'", sqlConnection);
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    if(dataTable.Rows[0][0].ToString() == "1")
                    {
                        MainMenu Obj = new MainMenu();
                        Obj.Show();
                        this.Hide();
                    }else {
                        MessageBox.Show("Wrong User Name or Password");
                        Reset();
                    }
                    sqlConnection.Close();
                }
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
