import 'dockview/dist/styles/dockview.css';
import { DockviewReact } from 'dockview'

import AceEditor from "react-ace"
import "ace-builds/src-noconflict/mode-livescript"
import "ace-builds/src-noconflict/mode-javascript"
import "ace-builds/src-noconflict/mode-csharp"
import { Ls2Js, Ls2Csx } from 'livescriptsharp';

import React from 'react';

export default () => {
  const apisRef = React.useRef([])
  const onChange = (value) => {
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
          api.addPanel({ component: 'ace', id: 'js', params: { mode: "javascript", readOnly: true, transform: Ls2Js }, position: { referencePanel: 'ls', direction: 'right' } }),
          api.addPanel({ component: 'ace', id: 'csx', params: { mode: "csharp",/**/readOnly: true, transform: Ls2Csx }, position: { referencePanel: 'js', direction: 'right' } }),
        ]
        onChange('console.log "hello"')
      }}
    />
  </div>
}