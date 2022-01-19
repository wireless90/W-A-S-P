using Autofac;
using WASP.Common.IOC;

namespace WASP
{
    public partial class MainForm : Form
    {
        private readonly IContainer _container;
        public MainForm()
        {
            InitializeComponent();

            _container = ContainerConfig.CreateContainer();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (ILifetimeScope lifetime = _container.BeginLifetimeScope())
            {
                
            }
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