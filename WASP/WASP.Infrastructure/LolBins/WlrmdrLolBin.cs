using WASP.Domain.Entities;

namespace WASP.Infrastructure.LolBins
{
    public class WlrmdrLolBin : LolBin
    {
        public const string NAME = "wlrmdr.exe";
        public const string DESCRIPTION = "Windows logon reminder process";
            
        public WlrmdrLolBin() : base(NAME, DESCRIPTION) { }

    }
}
