namespace AsenkronMultiThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int counter = 0;

        private async void btnRead_Click(object sender, EventArgs e)
        {
            string data = String.Empty;
            Task<string> read = ReadFileAsync2();
            richTextBox2.Text = await new HttpClient().GetStringAsync("https://www.google.com");
            
            data = await read;

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
                Task<string> myTask = streamReader.ReadToEndAsync();

                /* asagýya await keywordunu yazdýk buraya da istediðimiz kodlarý
                gömeribiliriz.
                 */
                await Task.Delay(4000);
                data = await myTask;
                return data;
            }
        }

        private Task<string> ReadFileAsync2()
        {

            using (StreamReader streamReader = new StreamReader("dosya.txt"))
            {
                // Ekstra bir iþlem yoksa direk geri döneriz async ve awaite gerek yok.
                return streamReader.ReadToEndAsync();
                
            }
        }
    }
}