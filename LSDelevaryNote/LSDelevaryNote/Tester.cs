using LSDelevaryNote.Provider.ReportProvider;
using MyExtentions.DIalogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace LSDelevaryNote
{
    public partial class Tester : Form
    {
        private string encoding;
        private string filenameExtension;
        private string mimeType;
        private string[] streamids;
        private Warning[] warnings;

        public Tester()
        {
            InitializeComponent();
        }

        private void Tester_Load(object sender, EventArgs e)
        {
            using (ReportViewProvider provider = new ReportViewProvider(
                SettingsProvider.GetDataSource(),
                SettingsProvider.GetDatabase(),
                SettingsProvider.GetUserName(),
                SettingsProvider.GetPassword()
                ))
            {
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Filter = "Excel Documents (*.pdf)|*.pdf";
                sfd.FileName = "export.pdf";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                     string FileName = sfd.FileName;
                    byte[] bytes = provider.GetDelivaryReport("GS295-0405702").Render(
                        "PDF", null, out mimeType, out encoding, out filenameExtension,
                        out streamids, out warnings);

                    using (FileStream fs = new FileStream(FileName, FileMode.Create))
                    {
                        fs.Write(bytes, 0, bytes.Length);
                    }
                }
            }
                this.reportViewer1.RefreshReport();
        }
    }
}
