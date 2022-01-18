using System.Diagnostics;
using WASP.Common.Interfaces;

namespace WASP.Common.Vulnerabilities.Executions.Mshta
{
    public class MshtaExecuteJScriptExecutionVulnerability : ExecutionVulnerability
    {
        public override bool TryExploit()
        {
            string jscript = @"
                                <script LANGUAGE=""JScript"">
                                    new ActiveXObject(""WScript.Shell"").run(""calc.exe"");
                                </script >
                            ";

            string jscriptName = $"{nameof(MshtaExecuteJScriptExecutionVulnerability)}.hta";

            File.WriteAllText(jscriptName, jscript);

            Process.GetProcessesByName("calc.exe").ToList().ForEach(p => p.Close());

            Process.Start(new ProcessStartInfo(jscriptName) {  UseShellExecute = true });

            Thread.Sleep(2000);
            Process[] processes = Process.GetProcessesByName("Calculator");

            bool success = processes.Any(p => p.ProcessName == "Calculator");


            if(success)
            {
                Process.GetProcessesByName("Calculator").ToList().ForEach(p => p.Close());
            }

            return success;
        }
    }
}
