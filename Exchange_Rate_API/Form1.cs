using SQLitePCL;
using System.Text.Json;
using static Exchange_Rate_API.DataExchange;

namespace Exchange_Rate_API
{
    public partial class Form1 : Form
    {
        private HttpClient client;
        private DataExchange _dataExchanges;
        long _unixTimeSeconds;
        private ExchangeHouse _house;
        public Form1()
        {
            InitializeComponent();
            client = new HttpClient();
            _ = get_Api();
            _house = new ExchangeHouse();
            listBox2.DataSource = _house.ExchangeData.ToList<DbExchangeData>();
        }

        private async Task get_Api()
        {
            string call = "https://openexchangerates.org/api/latest.json?app_id=1fed4d198f104193bd12046055119b21";
            string response = await client.GetStringAsync(call);
            _dataExchanges = JsonSerializer.Deserialize<DataExchange>(response);
            _unixTimeSeconds = _dataExchanges.timestamp;

            print_date();
            foreach (KeyValuePair<string, decimal> rate in _dataExchanges.rates)
            {
                comboBox1.Items.Add(rate.Key);
                comboBox2.Items.Add(rate.Key);
                comboBox3.Items.Add(rate.Key);
            }
        }

        private void print_date()
        {

            DateTimeOffset dateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(_unixTimeSeconds);
            string formattedDate = dateTimeOffset.ToString("yyyy-MM-dd HH:mm:ss");
            listBox1.Items.Add("Pobrane dane z: " + formattedDate);

        }


        private async void button1_Click(object sender, EventArgs e)
        {
            _ = get_Api();
            print_date();

        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem != null && comboBox2.SelectedItem != null)
            {
                var someItem = comboBox1.SelectedItem.ToString();
                var someItem2 = comboBox2.SelectedItem.ToString();
                decimal endvalue = _dataExchanges.rates[someItem2] / _dataExchanges.rates[someItem];
                decimal amount = textBox1.Text.Trim() == "" ? 1 : decimal.Parse(textBox1.Text);
                endvalue *= amount;
                endvalue = Math.Round(endvalue, 2);

                string v = endvalue.ToString();

                string printvalue = amount + " " + someItem + " = " + v + " " + someItem2;
                listBox1.Items.Add(printvalue);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            textBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var keyvalue = comboBox3.SelectedItem.ToString();
            var valuedb = _dataExchanges.rates[keyvalue];
            valuedb = Math.Round(valuedb, 2);
            _house.ExchangeData.Add(new DbExchangeData()
            {
                key = keyvalue,
                value = valuedb,
                timestamp = _dataExchanges.timestamp,
            });
            _house.SaveChanges();

            listBox2.DataSource = _house.ExchangeData.ToList<DbExchangeData>();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            _house.ExchangeData.RemoveRange(_house.ExchangeData);
            _house.SaveChanges();
            listBox2.DataSource = _house.ExchangeData.ToList<DbExchangeData>();
        }
    }
}