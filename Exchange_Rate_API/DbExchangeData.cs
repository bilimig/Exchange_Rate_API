using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Rate_API
{
    internal class DbExchangeData
    {
        public int Id { get; set; }
        public string? key { get; set; }

        public decimal value { get; set; }

        public long timestamp { get; set; }

        public override string ToString()
        {
            return $"Id: {Id}, key: {key}, value: {value}, timestamp: {timestamp}";
        }
    }
}
