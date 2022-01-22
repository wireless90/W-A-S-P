using WASP.Domain.Entities;

namespace WASP.Infrastructure.LolBins
{
    public class WmicLolBin : LolBin
    {
        private const string NAME = "wmic.exe";
        private const string DESCRIPTION = "The WMI command-line (WMIC) utility provides a command-line interface for Windows Management Instrumentation (WMI).";
        public WmicLolBin() : base(NAME, DESCRIPTION) { }

    }
}
