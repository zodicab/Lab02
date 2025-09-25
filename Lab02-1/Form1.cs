namespace Lab02_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += new EventHandler(button1_Click);
            button2.Click += new EventHandler(button2_Click);
            button3.Click += new EventHandler(button3_Click);
            button4.Click += new EventHandler(button4_Click);
        }
        //cong
        private void button1_Click(object sender, EventArgs e){
            float s1 = float.Parse(textBox1.Text);
            float s2 = float.Parse(textBox2.Text);
            float x = s1 + s2;
            textBox3.Text = x.ToString();
        }
        //tru
        private void button2_Click(object sender, EventArgs e){
            float s1 = float.Parse(textBox1.Text);
            float s2 = float.Parse(textBox2.Text);
            float x = s1 - s2;
            textBox3.Text = x.ToString();
        }
        //nhan
        private void button3_Click(object sender, EventArgs e){
            float s1 = float.Parse(textBox1.Text);
            float s2 = float.Parse(textBox2.Text);
            float x = s1 * s2;
            textBox3.Text = x.ToString();
        }
        //chia
        private void button4_Click(object sender, EventArgs e){
            float s1 = float.Parse(textBox1.Text);
            float s2 = float.Parse(textBox2.Text);
            float x = s1 / s2;
            textBox3.Text = x.ToString();
        }
    }
}