namespace LiveScriptSharp.Asts;

partial record Assign
{
    public override IEnumerable<string> Cat()
    {
        switch (this)
        {
            case ({ } left, "=", "=", { } right):
                foreach (var l in left.Cat())
                    yield return l;
                yield return "=";
                foreach (var r in right.Cat())
                    yield return r;
                break;
            default:
                throw new(this.ToString());
        }
    }
}