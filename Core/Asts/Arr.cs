namespace LiveScriptSharp.Asts;

partial record Arr
{
    public override IEnumerable<string> Cat()
    {
        yield return "new[]{";
        foreach (var i in items)
        {
            switch (i)
            {
                case Assign(Literal("void"), "=", "=", var right):
                    foreach (var r in right.Cat())
                        yield return r;
                    break;
                default:
                    foreach (var v in i.Cat())
                        yield return v;
                    break;
            }
            yield return ",";
        }
        yield return "}";
    }
}