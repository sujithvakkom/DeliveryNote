using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSDelevaryNote
{
    internal class TransCust
    {
        public string ReceiptID { get; set; }
        public string Customer { get; set; }
        public string CustomerName { get; internal set; }
        public string CustomerAddredd { get; internal set; }
        public string CustomerPhone { get; internal set; }
        public override string ToString()
        {
            return ReceiptID+'\t'+CustomerName+'\t'+CustomerPhone;
        }
    }
}
