//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LSDelevaryNote
{
    using System;
    using System.Collections.Generic;
    
    public partial class RBOTRANSACTIONINFOCODETRANS
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string TRANSACTIONID { get; set; }
        public decimal LINENUM { get; set; }
        public int TYPE { get; set; }
        public string INFOCODEID { get; set; }
        public string INFORMATION { get; set; }
        public Nullable<decimal> INFOAMOUNT { get; set; }
        public Nullable<System.DateTime> TRANSDATE { get; set; }
        public Nullable<int> TRANSTIME { get; set; }
        public string STORE { get; set; }
        public string TERMINAL { get; set; }
        public string STAFF { get; set; }
        public string ITEMTENDER { get; set; }
        public Nullable<decimal> AMOUNT { get; set; }
        public Nullable<int> INPUTTYPE { get; set; }
        public string SUBINFOCODEID { get; set; }
        public string STATEMENTID { get; set; }
        public string STATEMENTCODE { get; set; }
        public string SOURCECODE { get; set; }
        public Nullable<int> COUNTER { get; set; }
        public Nullable<byte> REPLICATED { get; set; }
        public string DATAAREAID { get; set; }
        public string SOURCECODE2 { get; set; }
        public string SOURCECODE3 { get; set; }
        public int REPLICATIONCOUNTER { get; set; }
        public string PROMPT { get; set; }
        public Nullable<byte> PRINTPROMPTONRECEIPT { get; set; }
        public Nullable<byte> PRINTINPUTONRECEIPT { get; set; }
        public Nullable<byte> PRINTINPUTNAMEONRECEIPT { get; set; }
        public Nullable<decimal> LINEID { get; set; }
    }
}
