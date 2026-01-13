namespace LiveScriptSharp.Asts;

partial record Fun
{
    public override IEnumerable<string> Cat()
    {
        switch (this)
        {
            case ([..] @params, Block body, false, false, false, false, false):
                yield return $$"""({{string.Join(',',@params.Select(p => string.Concat(p.Cat())))}})=>{""";
                foreach (var b in body.Cat())
                    yield return b;
                yield return "}";
                break;
            default:
                yield return this.ToString();
                throw new();
        }
    }
}