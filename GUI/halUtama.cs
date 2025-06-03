namespace GUI
{
    public partial class halUtama : Form
    {
        public halUtama()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button_regis_Click(object sender, EventArgs e)
        {
            regis regisForm = new regis();
            regisForm.Show();
            this.Hide();
        }

        private void button_login_Click(object sender, EventArgs e)
        {
            login loginForm = new login();
            loginForm.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
