namespace LiveScriptSharp.Asts;
using System.Text.Json.Serialization;
[JsonDerivedType(typeof(Block), nameof(Block))]
[JsonDerivedType(typeof(Call), nameof(Call))]
[JsonDerivedType(typeof(Chain), nameof(Chain))]
[JsonDerivedType(typeof(Index), nameof(Index))]
[JsonDerivedType(typeof(Key), nameof(Key))]
[JsonDerivedType(typeof(Literal), nameof(Literal))]
[JsonDerivedType(typeof(Var), nameof(Var))]
public partial record Ast;
public partial record Block    : Astt;
public partial record Call     : Astt;
public partial record Chain    : Astt;
public partial record Index    : Astt;
public partial record Key      : Astt;
public partial record Literal  : Astt;
public partial record Var      : Astt;
