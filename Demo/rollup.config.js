import nodeResolve from '@rollup/plugin-node-resolve';
import commonjs from '@rollup/plugin-commonjs';
import babel from '@rollup/plugin-babel';
import replace from '@rollup/plugin-replace';
import files from 'rollup-plugin-import-file';
import postcss from 'rollup-plugin-postcss';
import cssimport from 'postcss-import';

export default {
   input: 'src/index.js',
   output: {
      file: 'public/bundle.js',
   },
   plugins: [
      files({
         output: 'public',
         extensions: /\.(wasm|dat)$/,
         hash: true,
      }),
      nodeResolve({
         extensions: ['.js', '.jsx'],
         dedupe: ['react', 'react-dom']
      }),
      babel({
         babelHelpers: 'bundled',
         presets: ['@babel/preset-react'],
         extensions: ['.js', '.jsx'],
         generatorOpts: {
            // Increase the size limit from 500KB to 10MB
            compact: true,
            retainLines: true,
            maxSize: 10000000
         }
      }),
      commonjs(),
      replace({
         preventAssignment: true,
         'process.env.NODE_ENV': '"production"'
      }),
      postcss({
         plugins: [
            cssimport()
         ]
      })
   ]
}