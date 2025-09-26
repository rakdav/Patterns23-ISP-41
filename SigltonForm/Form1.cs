namespace SigltonForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormOpen openForm=new FormOpen();
            openForm.Show();
        }
    }
}
