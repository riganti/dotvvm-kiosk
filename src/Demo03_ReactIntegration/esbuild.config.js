const esbuild = require('esbuild')

async function main() {
    await esbuild.build({
        format: 'esm',
        entryPoints: ['Scripts/RechartsModule.tsx'],
        bundle: true,
        outfile: 'wwwroot/js/RechartsModule.js',
        minify: false,
        loader: {
            '.js_commonjs-exports': 'js',
            '.js_commonjs-module': 'js'
        },
        sourcemap: true
    });
}

main();