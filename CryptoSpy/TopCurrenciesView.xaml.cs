using CryptoSpy.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CryptoSpy
{
    /// <summary>
    /// Interaction logic for TopCurrenciesView.xaml
    /// </summary>
    public partial class TopCurrenciesView : UserControl
    {
        public TopCurrenciesView()
        {
            InitializeComponent();
            Update();
        }

        public async Task Update()
        {

            var topCurrencies = await GetTopCurrencies<CryptoCurrList>("https://api.coincap.io/v2/assets");
            StackPanel stackPanel = (StackPanel)FindName("TopList");

            foreach (var currency in topCurrencies.data.Take(10))
            {
                Label cryptoCurrency = new Label();
                cryptoCurrency.Content = currency.rank + " " + currency.name;
                stackPanel.Children.Add(cryptoCurrency);
            }
        }

        public static async Task<CryptoCurrList> GetTopCurrencies<T>(string url)
        {
            var myRoot = new CryptoCurrList();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var ResponseString = await response.Content.ReadAsStringAsync();
                        var ResponseObject = JsonConvert.DeserializeObject<CryptoCurrList>(ResponseString);

                        return ResponseObject;
                    }

                    return myRoot;
                }
            }
            catch
            {
                return myRoot;
            }
        }
    }
}
