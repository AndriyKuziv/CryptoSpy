using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSpy.Models
{
    public class CryptoCurrList
    {
        public List<CryptoCurrListData> data { get; set; }
    }

    public class CryptoCurrListData
    {
        public int rank { get; set; }
        public string symbol { get; set; }
        public string name { get; set; }
        public decimal volumeUsd24Hr { get; set; }
    }
}
