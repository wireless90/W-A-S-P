using WASP.Common.Interfaces;

namespace WASP.Common.Models
{
    public class LolBin
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public List<IVulnerability> Vulnerabilities { get; private set; }


        public LolBin(string name, string description)
        {
            Name = name;
            Description = description;
            Vulnerabilities = new List<IVulnerability>();
        }

        public LolBin RegisterVulnerability(IVulnerability vulnerability)
        {
            Vulnerabilities.Add(vulnerability);

            return this;
        }
    }
}
