#:sdk Microsoft.NET.Sdk.WebAssembly

#:property OutputType=Library
#:property WasmBundlerFriendlyBootConfig=true
#:property AllowUnsafeBlocks=true
#:property RunAOTCompilation=true
#:property PublishAot=false
#:property CompressionEnabled=false
// Github Page는 사전압축 파일을 사용하지 않음

#:project ../Core/LiveScriptSharp.csproj
#:package CSharpier.Core@1.2.5

using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

[assembly: System.Runtime.Versioning.SupportedOSPlatform("browser")]

[JsonSerializable(typeof(LiveScriptSharp.Asts.Ast))]
public partial class Js : JsonSerializerContext
{
    [JSExport]
    internal static string Csx(string ast)
    {
        var cs = string.Concat(System.Text.Json.JsonSerializer.Deserialize(ast, Default.Ast)?.Cat() ?? []);
        return CSharpier.Core.CSharp.CSharpFormatter.Format(cs).Code; //todo: csharp-script로 포맷되어야함.
    }
}