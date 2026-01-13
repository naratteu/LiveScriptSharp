namespace LiveScriptSharp.Asts;

partial record Binary
{
    public override IEnumerable<string> Cat()
    {
        if (partial is true) throw new("항상 false인데 언제 true인지 확인필요" + this);

        foreach (var i in first.Cat())
            yield return i;
        yield return op switch
        {
            "===" => "==",
            var op => op
        };
        foreach (var i in second.Cat())
            yield return i;
    }
}