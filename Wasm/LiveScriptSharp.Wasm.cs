#:sdk Microsoft.NET.Sdk.WebAssembly

#:property OutputType=Library
#:property WasmBundlerFriendlyBootConfig=true
#:property AllowUnsafeBlocks=true
#:property RunAOTCompilation=true
#:property PublishAot=false
#:property CompressionEnabled=false 
//false를 해야 압축이 됨

#:project ../Core/LiveScriptSharp.csproj

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