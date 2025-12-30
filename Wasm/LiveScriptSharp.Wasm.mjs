import { dotnet } from "./_framework/dotnet.js";
const { getAssemblyExports, getConfig } = await dotnet.create();
export const { Js: { Csx } } = await getAssemblyExports(getConfig().mainAssemblyName);