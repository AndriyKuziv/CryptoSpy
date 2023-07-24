using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSpy.Models
{
    public class SearchResult
    {
        public List<Coin> coins { get; set; }
    }

    public class Coin
    {
        public string id { get; set; }
        public string name { get; set; }
        public string symbol { get; set; }
    }
}
