namespace LiveScriptSharp.Asts;

using System.Text.Json.Serialization;
[JsonPolymorphic(TypeDiscriminatorPropertyName = "type")]
abstract partial record Ast
{
    public abstract IEnumerable<string> Cat();
}
// Sort Lines Ascending
#pragma warning disable IDE1006 // Naming Styles
#region Asts
partial record Assign(Ast left, string op, string opLoc, Ast right);
partial record Binary(bool partial, string op, Ast first, Ast second);
partial record Block(Ast[] lines);
partial record Call(Ast[] args);
partial record Chain(Ast head, Ast[] tails);
partial record If(Ast @if, Ast then, bool un, Ast? @else);
partial record Index(Ast key, string symbol);
partial record Key(string name);
partial record Literal(string value);
partial record Var(string value);
#endregion Asts
#pragma warning restore IDE1006 // Naming Styles
public abstract partial record Astt : Ast
{
    [JsonInclude] public int first_line, first_column, last_line, last_column, line, column;
}