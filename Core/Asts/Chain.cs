namespace LiveScriptSharp.Asts;

partial record Chain
{
    public override IEnumerable<string> Cat()
    {
        foreach (var c in head.Cat())
            yield return c;
        foreach (var t in tails)
            foreach (var c in t.Cat())
                yield return c;
    }
}