namespace LiveScriptSharp.Asts;

partial record Key
{
    public override IEnumerable<string> Cat()
    {
        yield return name;
    }
}