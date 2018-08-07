using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LSDelevaryNote.Provider.Entities
{
    [ComplexType()]
    public class DelivaryTransactionView
    {

        [Column("RECEIPTID")]
        public string RECEIPTID { get; set; }
        [Column("TRANSACTIONID")]
        public string TRANSACTIONID { get; set; }
        [Column("LINENUM")]
        public decimal? LINENUM { get; set; }
        [Column("TRANSDATE")]
        public DateTime TRANSDATE { get; set; }
        [Column("ITEMID")]
        public string ITEMID { get; set; }
        [Column("DESCRIPTION")]
        public string DESCRIPTION { get; set; }
        [Column("QUANTITY")]
        public decimal? QUANTITY { get; set; }
        [Column("SEIINGPRICE")]
        public decimal? SEIINGPRICE { get; set; }
        [Column("COMMENT")]
        public string COMMENT { get; set; }
        [Column("DELIVARYTYPE")]
        public string DELIVARYTYPE { get; set; }
        [Column("ACCOUNTNUM")]
        public string ACCOUNTNUM { get; set; }
        [Column("NAME")]
        public string NAME { get; set; }
        [Column("STREET")]
        public string STREET { get; set; }
        [Column("ADDRESS")]
        public string ADDRESS { get; set; }
        [Column("int_status")]
        public decimal? int_status { get; set; }
        [Column("status")]
        public string status { get; set; }

    }
}
