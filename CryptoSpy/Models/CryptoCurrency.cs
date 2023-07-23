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
        public decimal volumeUsd24Hr { get; set; }

        public decimal priceUsd { get; set; }
        public decimal changePercent24Hr { get; set; }
    }
}
