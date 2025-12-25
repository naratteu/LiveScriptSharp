namespace LiveScriptSharp.Asts;

partial record Block
{
    public override IEnumerable<string> Cat()
    {
        return lines.SelectMany(line => line.Cat().Append(";"));
    }
}