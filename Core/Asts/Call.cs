namespace LiveScriptSharp.Asts;

partial record Call
{
    public override IEnumerable<string> Cat()
    {
        yield return "(";
        for (int i = 0, l = args.Length; i < l; i++)
        {
            if (i > 0)
                yield return ",";
            foreach (var c in args[i].Cat())
                yield return c;
        }
        yield return ")";
    }
}