import { dotnet } from './_framework/dotnet.js'
import { ast, compile } from "https://esm.sh/livescript" //todo: 컴파일에 포함

const { getAssemblyExports, getConfig } = await dotnet.create(); //todo: Lazy Init
const exports = await getAssemblyExports(getConfig().mainAssemblyName);

export const Ls2Csx = ls => exports.Js.Csx(JSON.stringify(ast(ls)));
export const Ls2Js = compile;