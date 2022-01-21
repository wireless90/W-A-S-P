using MediatR;
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
            IEnumerable<ExecutionVulnerabilityScanViewModel> results = await _mediator.Send(new ExecutionVulnerabilityScanQuery());

            resultsListView.Items.Clear();

            results.ToList().ForEach(result =>
            {
                int totalTestCases = result.ExecutionVulnerabilityResults.Count;
                int totalSuccess = result.ExecutionVulnerabilityResults.Where(x => x.IsSuccess).Count();

                ListViewItem item = new ListViewItem(new[] { result.Name, result.Description, $"{totalTestCases}/{totalSuccess}" })
                {
                    ForeColor = Color.White
                };

                resultsListView.Items.Add(item);
            });
        }
    }
}