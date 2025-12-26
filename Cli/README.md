# LiveScriptSharp.Cli

```bash
npm install -g livescript
dotnet tool install -g csharprepl

cat <<EOF > hello.ls
console.log "Hello, World!"
EOF
cat hello.ls | lsc # Hello, World!

cat hello.ls | lsc --ast --json > hello.ls.ast
cat <<EOF > hello.csx
var console = new { log = (Action<object>)Console.WriteLine };
EOF
cat hello.ls.ast | dotnet LiveScriptSharp.Cli.cs -s >> hello.csx
cat hello.csx | csharprepl # Hello, World!
```