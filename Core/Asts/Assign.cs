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
                if (left is Obj obj)
                {
                    foreach (var item in obj.items)
                    {
                        if (item is Prop prop)
                        {
                            var key = prop.key switch
                            {
                                Key k => k.name,
                                null when prop.val is Var v => v.value,
                                _ => throw new Exception("Invalid destructuring key")
                            };
                            var nestedAssign = new Assign(prop.val, "=", "=", new Literal($"{tmp}.{key}"));
                            foreach (var s in nestedAssign.Cat()) yield return s;
                            yield return ";";
                        }
                    }
                }
                else if (left is Arr arr)
                {
                    var i = 0;
                    foreach (var item in arr.items)
                    {
                        var nestedAssign = new Assign(item, "=", "=", new Literal($"{tmp}[{i++}]"));
                        foreach (var s in nestedAssign.Cat()) yield return s;
                        yield return ";";
                    }
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