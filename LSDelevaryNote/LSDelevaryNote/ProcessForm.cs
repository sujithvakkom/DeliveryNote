using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LSDelevaryNote
{
    public partial class ProcessForm : Form
    {
        public List<string> Messages { get; private set; }
        public Task Task { get; internal set; }

        public ProcessForm(String[] Messages)
        {
            this.Cursor = Cursors.WaitCursor;
            InitializeComponent();
            this.Messages = Messages.ToList();
            this.textBox1.Lines = this.Messages.ToArray();
            this.progressBar2.Maximum = this.Messages.Count();
            this.label1.Text="0 of " + this.Messages.Count().ToString() + " is completed";
        }

        

        public void RemoveMessage(int id) {
            this.Messages.RemoveAt(id);
            progressBar2.Value++;

            this.label1.Text = (progressBar2.Value.ToString() +
                " of " +
               this.Messages.Count().ToString() +
                " is completed");
            this.textBox1.Lines = this.Messages.ToArray();
        }
        public void RemoveMessage(string message) {
            int i = 0;
            foreach (var x in Messages)
                if (message == x) { 
                    RemoveMessage(i);
                    return;
                }

        }

        private void ProcessForm_Load(object sender, EventArgs e)
        {
            this.Task.Start();
        }
    }

}
