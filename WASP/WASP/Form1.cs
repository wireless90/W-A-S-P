using WASP.Common.Models;
using WASP.Common.Vulnerabilities.Executions.Mshta;

namespace WASP
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case 0x84:
                    base.WndProc(ref m);
                    if ((int)m.Result == 0x1)
                        m.Result = (IntPtr)0x2;
                    return;
            }

            base.WndProc(ref m);
        }

        private void scanButton_Click(object sender, EventArgs e)
        {
            LolBin mshtaLolBin = new LolBin("mshta.exe", "A html application program")
                                    .RegisterVulnerability(new MshtaExecuteJScriptExecutionVulnerability());

            bool isSuccess = mshtaLolBin.Vulnerabilities.First().TryExploit();

            if (isSuccess)
            {
                MessageBox.Show("Exploited...");
            }
            else
            {
                MessageBox.Show("Failed...");
            }
        }
    }
}