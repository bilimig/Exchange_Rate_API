using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exchange_Rate_API
{

    public class DataExchange
    {
        public long timestamp { get; set; }
        public Dictionary<string, decimal> rates { get; set; }

    }

}
