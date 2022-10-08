namespace TestSQPhoto
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sqPhoto1.ReSize();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            sqPhoto1.PicZoomSize(100);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sqPhoto1.PicZoomSize(-100);
        }
    }
}