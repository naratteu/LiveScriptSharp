namespace LiveScriptSharp.Asts;

partial record Unary
{
    public override IEnumerable<string> Cat()
    {
        switch (this)
        {
            case ("do", { } it):
                foreach (var i in it.Cat())
                    yield return i;
                yield return "()";
                break;
            default:
                yield return this.ToString();
                throw new();
        }
    }
}