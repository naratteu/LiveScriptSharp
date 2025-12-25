namespace LiveScriptSharp.Asts;

partial record Index
{
    public override IEnumerable<string> Cat()
    {
        yield return symbol;
        foreach (var c in key.Cat())
            yield return c;
    }
}