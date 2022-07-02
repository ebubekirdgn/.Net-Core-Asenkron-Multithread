namespace AsenkronMultiThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int counter = 0;

        private void btnRead_Click(object sender, EventArgs e)
        {
            string data = ReadFile();
            richTextBox1.Text = data;
        }

        private void btnCounter_Click(object sender, EventArgs e)
        {
            textBoxCounter.Text = counter++.ToString();
        }

        private string ReadFile()
        {
            string data = string.Empty;

            using (StreamReader streamReader = new StreamReader("dosya.txt"))
            {
                Thread.Sleep(5000);
                data = streamReader.ReadToEnd();
            }
            return data;
        }

        //void ->> Task
        // string ->> Task<string>

        private async Task<string> ReadFileAsync()
        {
            string data = string.Empty;

            using (StreamReader streamReader = new StreamReader("dosya.txt"))
            {
                Thread.Sleep(5000);
                data = streamReader.ReadToEnd();
            }
            return data;
        }

    }
}