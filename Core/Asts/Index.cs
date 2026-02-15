namespace LiveScriptSharp.Asts;

partial record Index
{
    public override IEnumerable<string> Cat()
    {
        switch (this)
        {
            case (Parens({ }, null, null, null, null), "."):
                yield return "[";
                foreach (var c in key.Cat())
                    yield return c;
                yield return "]";
                break;
            default:
                yield return symbol;
                foreach (var c in key.Cat())
                    yield return c;
                break;
        }
    }
}