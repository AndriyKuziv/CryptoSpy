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
using CryptoSpy.Models;
using Newtonsoft.Json;

namespace CryptoSpy
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CryptoCurrency currency = new CryptoCurrency();

        public MainWindow()
        {
            InitializeComponent();
            MainPage.Content = new TopCurrenciesView();
        }

        private async void test()
        {
            currency = await GetData<CryptoCurrency>("https://api.coincap.io/v2/assets/bitcoin");
        }

        public static async Task<CryptoCurrency> GetData<T>(string url)
        {
            var myRoot = new CryptoCurrency();
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

                        MessageBox.Show("id: " + ResponseObject.data.id + " rank:" + ResponseObject.data.rank, "Information", MessageBoxButton.OK);

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

        

        private void HomeButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = new TopCurrenciesView();
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            MainPage.Content = new CryptoSearchView();
        }
    }
}
