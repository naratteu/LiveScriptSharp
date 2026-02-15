namespace LiveScriptSharp.Asts;

partial record Prop
{
    public override IEnumerable<string> Cat()
    {
        switch (this)
        {
            case (null, Var val):
                foreach (var v in val.Cat())
                    yield return v;
                break;
            case ({ } key, { } val):
                foreach (var v in key.Cat())
                    yield return v;
                yield return "=";
                foreach (var v in val.Cat())
                    yield return v;
                break;
            default:
                yield return ToString();
                throw new NotImplementedException();
        }
    }
}