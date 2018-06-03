using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSDelevaryNote
{
    public class TransactionLine
    {
        //tra_l.ITEMID, tra_l.DESCRIPTION, tra_l.QTY, tra_l.TAXINCLINPRICE ,tra_l.COMMENT, EXTRAINFO=info_s.DESCRIPTION
        public string ReceiptID { get; set; }
        public string ItemId { get; set; }
        public string Description { get; set; }
        public decimal Qty { get; set; }
        public decimal TaxInckInPrice { get; set; }
        public string Comment { get; set; }
        public string ExtraInfo { get; set; }
    }

}
