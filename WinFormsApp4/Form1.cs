using System.Xml.Linq;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        private Dictionary<string, float> _rates = new Dictionary<string, float>();
        public Form1()
        {
            InitializeComponent();
        }

     
        private void ex()
        {
            XDocument api = XDocument.Load("https://api.nbp.pl/api/exchangerates/tables/a/?format=xml");

            //richTextBox1.Text = api.ToString(); //daje ca³¹ zawartoœæ api do RichTextBoxa

            var rates = api.Descendants("Rate");
            _rates.Clear();
            // Descendants Daje zawartoœæ Rate'ów

            foreach (var rate in rates)
            {
                string code = rate.Element("Code").Value;
                float mid = float.Parse(rate.Element("Mid").Value, System.Globalization.CultureInfo.InvariantCulture);
                _rates.Add(code, mid);

            }

            //richTextBox1.Text = _rates.ToString();

            textBox1.Text = _rates["USD"].ToString();
            textBox2.Text = _rates["EUR"].ToString();
            textBox3.Text = _rates["CHF"].ToString();
        }

        private void clickRadioButton(object sender, EventArgs e)
        {
            ex();
            RadioButton radio = sender as RadioButton;
            string code = radio.Text;
            float pln = float.Parse(textBox4.Text);
            float exchanged = pln / _rates[code];
            textBox5.Text = exchanged.ToString();
        }
    }
}