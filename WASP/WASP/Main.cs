using Autofac;
using MediatR;
using WASP.Common.IOC;
using WASP.Core.MainContext.Commands.ExecutionVulnerabilityScan;

namespace WASP
{
    public partial class MainForm : Form
    {
        private readonly IMediator _mediator;

        public MainForm(IMediator mediator)
        {
            InitializeComponent();

            _mediator = mediator;
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

        private async void scanButton_Click(object sender, EventArgs e)
        {
            await _mediator.Send(new ExecutionVulnerabilityScanQuery());
        }
    }
}