rm -rf temp
npm create vite@latest -- temp -t react-ts --no-interactive
dotnet workload restore ../Wasm/*
dotnet build ../Wasm -o temp/bin
cat <<EOF > temp/bin/AppBundle/package.json
{ "type":"module", "name":"dotnet" }
EOF
cp -rf src temp
cd temp
npm i dockview react-ace ./bin/AppBundle