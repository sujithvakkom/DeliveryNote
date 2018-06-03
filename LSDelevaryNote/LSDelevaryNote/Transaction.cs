using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSDelevaryNote
{
    class Transaction
    {
        //tra_h.RECEIPTID,sto.STOREID,sto.NAME,tra_h.TRANSDATE,tra_h.NETAMOUNT
        public string ReceiptID { get; set; }
        public string StoreID { get; set; }
        public string Name { get; set; }
        public DateTime TransDate { get; set; }
        public decimal NetAmount { get; set; }
    }
}
