import 'dockview/dist/styles/dockview.css';
import { DockviewReact, type IDockviewPanel } from 'dockview'

import AceEditor from "react-ace"
import "ace-builds/src-noconflict/mode-livescript"
import "ace-builds/src-noconflict/mode-javascript"
import "ace-builds/src-noconflict/mode-csharp"
import { ast, compile } from "https://esm.sh/livescript"
import { Csx } from "dotnet/LiveScriptSharp.Wasm.mjs"

import { useRef } from "react"

export default () => {
  const apisRef = useRef<IDockviewPanel[]>([])
  const onChange = (value: string) => {
    for (const { api, params } of apisRef.current) {
      const p = params ?? {};
      try { p.value = p.transform?.(value) ?? value } catch (err) { }
      api.updateParameters(p);
    }
  }
  return <div style={{ width: "100vw", height: "100vh" }}>
    <DockviewReact
      components={{
        ace: ({ params }) => <AceEditor {...params} />,
      }}
      onReady={({ api }) => {
        apisRef.current = [
          api.addPanel({ component: 'ace', id: 'ls', params: { mode: "livescript", onChange } }),
          api.addPanel({ component: 'ace', id: 'js', params: { mode: "javascript", readOnly: true, transform: (v: string) => compile(v) }, position: { referencePanel: 'ls', direction: 'right' } }),
          api.addPanel({ component: 'ace', id: 'csx', params: { mode: "csharp",/**/readOnly: true, transform: (v: string) => Csx(JSON.stringify(ast(v))) }, position: { referencePanel: 'js', direction: 'right' } }),
        ]
        onChange('console.log "hello"')
      }}
    />
  </div>
}