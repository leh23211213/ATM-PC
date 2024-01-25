namespace ATM_PC
{
    public partial class Splash : Form
    {
        public Splash()
        {
            InitializeComponent();
        }
        int startP = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            ProgressBar Myprogress = new ProgressBar();
            startP += 1;
            Myprogress.Value = startP;
            if (Myprogress.Value == 100)
            {
                Myprogress.Value = 0;
                Login Obj = new Login();
                Obj.Show();
                this.Hide();
            }
        }

        private void guna2GradientPanel1_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }
    }
}
