using CryptoSpy.Models;
using Newtonsoft.Json;
using System;
using System.Collections;
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
    /// Interaction logic for CryptoSearchView.xaml
    /// </summary>
    public partial class CryptoSearchView : UserControl
    {
        class CryptoName
        {
            public string currencyName { get; set; }
        }

        CryptoName cName = new CryptoName()
        {
            currencyName = ""
        };

        public CryptoSearchView()
        {
            InitializeComponent();

            this.DataContext = cName;
        }

        private async void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(cName.currencyName))
            {
                MessageBox.Show("Cryptocurrency name must not be empty");
                return;
            }

            var searchRes = await GetSearchResult("https://api.coingecko.com/api/v3/search?query=" + cName.currencyName);

            ListBox listBox = (ListBox)FindName("SearchResultList");
            listBox.ItemsSource = searchRes.coins;
        }

        public static async Task<SearchResult> GetSearchResult(string url)
        {
            var searchResult = new SearchResult();
            try
            {
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(1);
                    HttpResponseMessage response = await client.GetAsync(url);
                    if (response.IsSuccessStatusCode)
                    {
                        var ResponseString = await response.Content.ReadAsStringAsync();
                        var ResponseObject = JsonConvert.DeserializeObject<SearchResult>(ResponseString);

                        return ResponseObject;
                    }

                    return searchResult;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return searchResult;
            }
        }

        public void ListBoxItem_DoubleClick(object sender, RoutedEventArgs e)
        {
            Coin coin = (Coin)(sender as ListBoxItem).DataContext;
        }
    }
}
