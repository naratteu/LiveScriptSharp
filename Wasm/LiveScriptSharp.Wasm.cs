#:sdk Microsoft.NET.Sdk.WebAssembly
#:property OutputType=Library
#:property AllowUnsafeBlocks=true
#:property WasmBundlerFriendlyBootConfig=true
#:property WasmFingerprintAssets=false
#:property CompressionEnabled=false
#:project ../Core/LiveScriptSharp.csproj

#:property PublishAot=false
#:property PublishTrimmed=false
// -p:) # -p:RunAOTCompilation=true)

using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;

[assembly: System.Runtime.Versioning.SupportedOSPlatform("browser")]

[JsonSerializable(typeof(LiveScriptSharp.Asts.Ast))]
public partial class Js : JsonSerializerContext
{
    [JSExport]
    internal static string Csx(string ast)
    {
        return string.Concat(System.Text.Json.JsonSerializer.Deserialize(ast, Default.Ast)?.Cat() ?? []);
    }
}