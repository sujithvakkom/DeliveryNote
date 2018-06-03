using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSDelevaryNote
{
    class TransactionCustomer
    {
        // tra_h.RECEIPTID, CUSTACCOUNT = string.IsNullOrEmpty(info.INFORMATION)? tra_h.CUSTACCOUNT: info.INFORMATION,cust.NAME,
        //cust.ADDRESS,cust.PHONE, ADDRESS1= address.ADDRESS ,address.STREET
        public string ReceiptID { get; set; }
        public string CustAccount { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Address1 { get; set; }
        public string Street { get; set; }

        public String ConcatanateAddress
        {
            get {
                return
                    this.Phone
                    + (string.IsNullOrEmpty(Address) ? "" : Environment.NewLine + Address)
                    + (string.IsNullOrEmpty(Address1) ? "" : Environment.NewLine + Address1)
                    + (string.IsNullOrEmpty(Street) ? "" : Environment.NewLine + Street);
            }
        }

    }
}
