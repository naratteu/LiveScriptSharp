namespace LiveScriptSharp.Asts;

partial record Var
{
    public override IEnumerable<string> Cat()
    {
        yield return value;
    }
}