using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSpy.Models
{

    public class CryptoCurrency
    {
        public CryptoCurrData data { get; set; }
    }

    public class CryptoCurrData
    {
        public string id { get; set; }
        public int rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public double volumeUsd24Hr { get; set; }

        public double priceUsd { get; set; }
        public double changePercent24Hr { get; set; }
    }
}
