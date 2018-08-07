using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LSDelevaryNote.Provider.Entities
{
    [ComplexType]
    public class ReplishmentView
    {
        [Column("ITEMID")]
        public string ITEMID { get; set; }
        [Column("DESCRIPTION")]
        public string DESCRIPTION { get; set; }
        [Column("HOMEDELIVERYQUANTITY")]
        public decimal HOMEDELIVERYQUANTITY{get;set;}
        [Column("HOMEDELIVERYQUANTITY")]
        public decimal STOREPICKUPQUANTITY { get; set; }
    }
}
