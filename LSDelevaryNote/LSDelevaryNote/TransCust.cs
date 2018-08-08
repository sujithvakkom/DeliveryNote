using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LSDelevaryNote
{
    internal class TransCust
    {
        private readonly char[] spliters = { '\\', '/' };
        public string ReceiptID { get; set; }
        public string Customer { get; set; }
        public string CustomerName { get; internal set; }
        public string CustomerAddredd { get; internal set; }
        public string CustomerPhone { get; internal set; }
        public override string ToString()
        {
            return ReceiptID + '\t' + SendablePhone +(SendablePhone.Length>0? String.Empty : '\t'.ToString())+'\t' +'\t' + CustomerName ;
        }

        //
        private string _SendablePhone;
        private string SendablePhone
        {
            get
            {
                try
                {
                    _SendablePhone = getDigits(CustomerPhone.Split(spliters)[0]).
                        //Replace("-", String.Empty).
                        //Replace(" ",String.Empty).
                        GetLast(9);
                    Int32.Parse(_SendablePhone);
                }
                catch (Exception) { return ""; }
                return "+971" + _SendablePhone;
            }
        }

        private string getDigits(string a)
        {
            string b = string.Empty;
            for (int i = 0; i < a.Length; i++)
            {
                if (Char.IsDigit(a[i]))
                    b += a[i];
            }
            return b;
        }

        internal string SendMessage(string message)
        {
            using (SMSProvider provider = new SMSProvider("20076790", "4xizrx", "Grand Stores"))
            {
                return CustomerName+'\t'+provider.SMSSend(this.SendablePhone, message).Trim()+'\r'+'\n';
            }
        }

        internal string getSendablePhone()
        {
            return SendablePhone;
        }
    }
    public static class StringExtension
    {
        public static string GetLast(this string source, int tail_length)
        {
            if (tail_length > source.Length)
                return "*********";
            return source.Substring(source.Length - tail_length);
        }
    }

    public static class ListBoxSelectAll
    {
        public static void SelectAll(this System.Windows.Forms.ListBox myListBox)
        {
            for (int i = 0; i < myListBox.Items.Count; i++)
            {
                myListBox.SetSelected(i, true);
            }
        }
    }
}
