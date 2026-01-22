namespace LiveScriptSharp.Asts;

partial record Prop
{
    public override IEnumerable<string> Cat()
    {
        foreach (var v in key.Cat())
            yield return v;
        yield return "=";
        foreach (var v in val.Cat())
            yield return v;
    }
}