using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace LSDelevaryNote.Provider.Entities
{
    [ComplexType()]
    public class DelevaryRelanishment
    {

        [Column("ItemCode")]
        public string ItemCode { get; set; }
        
        [Column("Description")]
        public string Description { get; set; }
        
        [Column("SoldDelivarableQuantity")]
        public decimal? SoldDelivarableQuantity { get; set; }

        [Column("SoldPickedQuantity")]
        public decimal? SoldPickedQuantity { get; set; }

        [Column("OnHandQuantity")]
        public decimal? OnHandQuantity { get; set; }

    }
}
