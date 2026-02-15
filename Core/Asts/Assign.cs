namespace LiveScriptSharp.Asts;

partial record Assign
{
    public override IEnumerable<string> Cat()
    {
        switch (this)
        {
            case ((Obj or Arr) and { } left, "=", "=", { } right):
                var tmp = "ref_" + Random.Shared.Next();
                yield return $"var {tmp}=";
                foreach (var r in right.Cat())
                    yield return r;
                yield return ";";
                switch (left)
                {
                    case Obj({ } items):
                        foreach (var item in items)
                        {
                            var (assign, key) = item switch
                            {
                                Prop(Key(var name), var val) => (val, name),
                                Prop(null, Var(var value) val) => (val, value),
                                _ => throw new Exception("Invalid destructuring key")
                            };
                            foreach (var a in assign.Cat())
                                yield return a;
                            yield return $"={tmp}.{key};";
                        }
                        break;
                    case Arr({ } items):
                        foreach (var (assign, i) in items.Select((v, i) => (v, i)))
                        {
                            foreach (var a in assign.Cat())
                                yield return a;
                            yield return $"={tmp}[{i}];";
                        }
                        break;
                }
                break;
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