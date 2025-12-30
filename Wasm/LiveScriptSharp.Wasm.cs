using System.Text.Json.Serialization;

[assembly: System.Runtime.Versioning.SupportedOSPlatform("browser")]
{ }

[JsonSerializable(typeof(LiveScriptSharp.Asts.Ast))]
partial class Js : JsonSerializerContext
{
	[System.Runtime.InteropServices.JavaScript.JSExport]
	static string Csx(string ast)
	{
		return string.Concat(System.Text.Json.JsonSerializer.Deserialize(ast, Default.Ast)?.Cat() ?? []);
	}
}