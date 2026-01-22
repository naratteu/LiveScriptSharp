namespace LiveScriptSharp.Asts;

partial record Obj
{
    public override IEnumerable<string> Cat()
    {
        yield return "new{";
        foreach (var i in items)
        {
            foreach (var v in i.Cat())
                yield return v;
            yield return ",";
        }
        yield return "}";
    }
}