namespace LiveScriptSharp.Asts;

partial record Yield
{
    public override IEnumerable<string> Cat()
    {
        switch (this)
        {
            case ("await", { } it):
                yield return "await ";
                foreach (var i in it.Cat())
                    yield return i;
                break;
            default:
                yield return this.ToString();
                throw new();
        }
    }
}