namespace LiveScriptSharp.Asts;

partial record If
{
    public override IEnumerable<string> Cat()
    {
        if (un is true) throw new("항상 false인데 언제 true인지 확인필요" + this);

        yield return "if";
        yield return "(";
        foreach (var i in @if.Cat())
            yield return i;
        yield return ")";
        yield return "{";
        foreach (var i in then.Cat())
            yield return i;
        yield return "}";
        if (@else is { })
        {
            yield return "else";
            yield return "{";
            foreach (var i in @else.Cat())
                yield return i;
            yield return "}";
        }
    }
}