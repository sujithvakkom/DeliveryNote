using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace LSDelevaryNote
{
    static class Program
    {
        public static bool KeepOpen { get; private set; }
        public static string customerInfoCode = "INF00005";
        public static string isDelevary = "INF00004";
        public static string isDelevaryValue = "HOME DELIVERY";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Program.KeepOpen = !(args.Length == 0);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FormDeliveryNote());
        }
    }
}
