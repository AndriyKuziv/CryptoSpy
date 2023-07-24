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
            ContentArea.Content = new TopCurrenciesView();
        }

        private void HomePage_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new TopCurrenciesView();
        }

        private void SearchPage_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new CryptoSearchView();
        }

        private void CryptoPage_Click(object sender, RoutedEventArgs e)
        {
            ContentArea.Content = new CryptoCurrencyView("bitcoin");
        }
    }
}
