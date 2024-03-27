
using System.Text.Json;
using static Exchange_Rate_API.DataExchange;

namespace Exchange_Rate_API
{
    public partial class Form1 : Form
    {
        private HttpClient client;
        private DataExchange _dataExchanges;

        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Clear();
            string call = "https://openexchangerates.org/api/latest.json?app_id=1fed4d198f104193bd12046055119b21";
            string response = await client.GetStringAsync(call);
            _dataExchanges = JsonSerializer.Deserialize<DataExchange>(response);

            long unixTimeSeconds = _dataExchanges.timestamp;
            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(unixTimeSeconds);
            string formattedDate = dateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss");
            listBox1.Items.Add("Data: " + formattedDate);
            listBox1.Items.Add("Base: USD");

            foreach (var rate in _dataExchanges.rates)
            {
               
                {
                    listBox1.Items.Add($"{rate.Key}: {rate.Value}");
                    comboBox1.Items.Add(rate.Key);
                }
            }

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null)
            {
                var someItem = comboBox1.SelectedItem.ToString();
                textBox1.Text = _dataExchanges.rates[someItem].ToString();
            }

        }
    }
}