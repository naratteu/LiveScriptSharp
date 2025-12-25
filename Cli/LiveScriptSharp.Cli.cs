#:project ../Core
using System.Text.Json;
using System.Text.Json.Serialization;

var ast = JsonSerializer.Deserialize(Console.OpenStandardInput(), Jsz.Default.Ast);
foreach (var c in ast?.Cat() ?? [])
    Console.Write(c);

[JsonSerializable(typeof(LiveScriptSharp.Asts.Ast))] partial class Jsz : JsonSerializerContext;