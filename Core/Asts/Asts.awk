/region Asts/,/endregion Asts/ { 
    if (match($0, /^partial record ([^ ]+)\(/, Ast))
        Asts[a++]=Ast[1]
}

END {
    print "namespace LiveScriptSharp.Asts;"
    print "using System.Text.Json.Serialization;"
    for (i=0; i<a; i++)
        print sprintf("[JsonDerivedType(typeof(%s), nameof(%s))]", ast = Asts[i], ast)
    print "public partial record Ast;"
    for (i=0; i<a; i++)
        print sprintf("public partial record %-8s : %s;", Asts[i], Asts[i] == "Arr" ? "Ast" : "Astt")
}