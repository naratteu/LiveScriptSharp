namespace LiveScriptSharp.Asts;

partial record Literal
{
    public override IEnumerable<string> Cat()
    {
        yield return value;
    }
}