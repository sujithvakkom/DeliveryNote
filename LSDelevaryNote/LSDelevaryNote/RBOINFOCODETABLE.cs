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
    
    public partial class RBOINFOCODETABLE
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string INFOCODEID { get; set; }
        public string DESCRIPTION { get; set; }
        public string PROMPT { get; set; }
        public Nullable<byte> ONCEPERTRANSACTION { get; set; }
        public Nullable<byte> VALUEISAMOUNTORQUANTITY { get; set; }
        public Nullable<byte> PRINTPROMPTONRECEIPT { get; set; }
        public Nullable<byte> PRINTINPUTONRECEIPT { get; set; }
        public Nullable<byte> PRINTINPUTNAMEONRECEIPT { get; set; }
        public Nullable<int> INPUTTYPE { get; set; }
        public Nullable<decimal> MINIMUMVALUE { get; set; }
        public Nullable<decimal> MAXIMUMVALUE { get; set; }
        public Nullable<int> MINIMUMLENGTH { get; set; }
        public Nullable<int> MAXIMUMLENGTH { get; set; }
        public Nullable<byte> INPUTREQUIRED { get; set; }
        public Nullable<byte> STD1INVALUE { get; set; }
        public string LINKEDINFOCODEID { get; set; }
        public Nullable<decimal> RANDOMFACTOR { get; set; }
        public Nullable<decimal> RANDOMCOUNTER { get; set; }
        public string DATATYPEID { get; set; }
        public Nullable<System.DateTime> MODIFIEDDATE { get; set; }
        public Nullable<int> MODIFIEDTIME { get; set; }
        public string MODIFIEDBY { get; set; }
        public string DATAAREAID { get; set; }
        public Nullable<int> ADDITIONALCHECK { get; set; }
        public Nullable<int> USAGECATEGORY { get; set; }
        public Nullable<int> DISPLAYOPTION { get; set; }
        public Nullable<byte> LINKITEMLINESTOTRIGGERLINE { get; set; }
        public Nullable<byte> MULTIPLESELECTION { get; set; }
        public Nullable<byte> TRIGGERING { get; set; }
        public Nullable<int> MINSELECTION { get; set; }
        public Nullable<int> MAXSELECTION { get; set; }
        public Nullable<byte> CREATEINFOCODETRANSENTRIES { get; set; }
        public string EXPLANATORYHEADERTEXT { get; set; }
        public Nullable<int> OKPRESSEDACTION { get; set; }
    }
}
