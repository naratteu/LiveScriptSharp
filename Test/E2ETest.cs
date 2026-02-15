namespace LiveScriptSharp.Test;

using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Runtime.CompilerServices;

public class E2ETest
{
    [Xunit.Fact]
    void Load()
    {
        using var rs = RunspaceFactory.CreateRunspace(); rs.Open();
        var ssp = rs.SessionStateProxy;
        Cfp(); void Cfp([CallerFilePath] string cfp = "") =>
            ssp.Path.SetLocation(Path.GetDirectoryName(cfp));
        ssp.SetVariable("compatibility", /*lang=c#-test*/"""
        var console = new { log = (Action<object>)Console.WriteLine };
        class Promise<T>
        {
            TaskCompletionSource<T> tcs = new();
            public Promise(Action<Action<T>> aat) => aat(tcs.SetResult);
            public System.Runtime.CompilerServices.TaskAwaiter<T> GetAwaiter() => tcs.Task.GetAwaiter();
        }
        class Promise(Action<Action<object>> aat) : Promise<object>(aat);
        var JSON = new { stringify = new Func<object, string>(o => System.Text.Json.JsonSerializer.Serialize(o)) };
        """);
        var runPwsh = (string sc) =>
        {
            using var pwsh = PowerShell.Create(rs);
            return pwsh.AddScript(sc).Invoke();
        };
        _ = runPwsh("dotnet build ../Cli/LiveScriptSharp.Cli.cs"); // 미리빌드해야 warring이 출력에 포함될일이 없음
        bool allright = true;
        foreach (var ls in runPwsh("(ls *.ls).Name"))
        {
            var file = Path.GetFileNameWithoutExtension(ls.ToString());
            Console.Write($"Testing \x1b[1;37m{file}\x1b[0m...".PadRight(37));
            ssp.SetVariable("pre", runPwsh($"cat {file}.pre.csx"));
            ssp.SetVariable("ls", runPwsh($"cat {ls}"));
            bool ok = !file.EndsWith(".NG"),
            diff = runPwsh("$ls | lsc").SequenceEqual(runPwsh("""
               $transpile = $ls | lsc --ast --json | dotnet ../Cli/LiveScriptSharp.Cli.cs -s
               ($compatibility, $pre, $transpile) | csharprepl
               """)),
            right = diff == ok;
            allright &= right;
            Console.WriteLine($"\x1b[1;{(right ? "92m" : "91mNOT ")}{(ok ? "OK" : "NG")}\x1b[0m");
        }
        if (!allright)
            throw new();
    }
}