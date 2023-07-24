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
    /// Interaction logic for CryptoCurrencyView.xaml
    /// </summary>
    public partial class CryptoCurrencyView : UserControl
    {
        CryptoCurrency cryptoCurrency { get; set; }

        public CryptoCurrencyView(string id)
        {
            InitializeComponent();
            cryptoCurrency = new CryptoCurrency();
            Update(id);
        }

        public async Task Update(string id)
        {
            cryptoCurrency = await GetCryptoCurrency<CryptoCurrency>("https://api.coincap.io/v2/assets/" + id);
            this.DataContext = cryptoCurrency;
            MessageBox.Show($"Name: {cryptoCurrency.data.name}; Id: {cryptoCurrency.data.id}; PriceUsd: {cryptoCurrency.data.priceUsd}");
        }

        public static async Task<CryptoCurrency> GetCryptoCurrency<T>(string url)
        {
            var crypto = new CryptoCurrency();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var ResponseString = await response.Content.ReadAsStringAsync();
                        var ResponseObject = JsonConvert.DeserializeObject<CryptoCurrency>(ResponseString);

                        return ResponseObject;
                    }

                    return crypto;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return crypto;
            }
        }
    }
}
