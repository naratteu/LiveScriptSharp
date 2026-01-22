namespace LiveScriptSharp.Asts;

partial record Parens
{
    public override IEnumerable<string> Cat()
    {
        yield return "(";
        foreach (var i in it.Cat())
            yield return i;
        yield return ")";
    }
}