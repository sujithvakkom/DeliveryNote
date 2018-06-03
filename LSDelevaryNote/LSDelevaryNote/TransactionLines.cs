using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSDelevaryNote
{
    public class TransactionLines : List<TransactionLine>
    {
        public TransactionLines(List<TransactionLine> trans)
        {
            if (trans != null)
                foreach (var x in trans)
                {
                    this.Add(x);
                }
        }
        public int Test { get; set; }
    }
}