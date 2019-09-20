console.log("This is service worker talking");
var cacheName = 'blazor-pwa-sample';
var filesToCache = [
    '/',
    // Static Html and css files
    '/index.html',
    '/favicon.ico',
    '/css/site.css',
    '/css/bootstrap/bootstrap.min.css',
    '/css/open-iconic/font/css/open-iconic-bootstrap.min.css',
    '/css/open-iconic/font/fonts/open-iconic.woff',
    '/open-iconic',
    // Blazor framework
    '/_framework/blazor.webassembly.js',
    '/_framework/blazor.boot.json',
    // Our additional files
    '/manifest.json',
    '/serviceworker.js',
    '/icons/icona.png',
    // The web assembly/.net dll's
    '/_framework/wasm/mono.js',
    '/_framework/wasm/mono.wasm',
    

    '/_framework/_bin/Microsoft.AspNetCore.Authorization.dll',
    '/_framework/_bin/Microsoft.AspNetCore.Blazor.dll',
    '/_framework/_bin/Microsoft.AspNetCore.Blazor.HttpClient.dll',
    '/_framework/_bin/Microsoft.AspNetCore.Components.dll',
    '/_framework/_bin/Microsoft.AspNetCore.Components.Web.dll',
    '/_framework/_bin/Microsoft.AspNetCore.Metadata.dll',
    '/_framework/_bin/Microsoft.Bcl.AsyncInterfaces.dll',

    '/_framework/_bin/Microsoft.Extensions.DependencyInjection.Abstractions.dll',
    '/_framework/_bin/Microsoft.Extensions.DependencyInjection.dll',
    '/_framework/_bin/Microsoft.Extensions.Logging.Abstractions.dll',
    '/_framework/_bin/Microsoft.Extensions.Options.dll',
    '/_framework/_bin/Microsoft.Extensions.Primitives.dll',

    '/_framework/_bin/Microsoft.JSInterop.dll',
    '/_framework/_bin/Mono.Security.dll',
    '/_framework/_bin/Mono.WebAssembly.Interop.dll',
    '/_framework/_bin/mscorlib.dll',
    '/_framework/_bin/System.Buffers.dll',


    '/_framework/_bin/System.ComponentModel.Annotations.dll',
    '/_framework/_bin/System.Core.dll',
    '/_framework/_bin/System.dll',
    '/_framework/_bin/System.Memory.dll',
    '/_framework/_bin/System.Net.Http.dll',
    '/_framework/_bin/System.Numerics.Vectors.dll',
    '/_framework/_bin/System.Runtime.CompilerServices.Unsafe.dll',
    '/_framework/_bin/System.Text.Encodings.Web.dll',
   
    '/_framework/_bin/System.Text.Json.dll',
    '/_framework/_bin/System.Threading.Tasks.Extensions.dll',
    // The compiled project .dll's
    '/_framework/_bin/BlazorPWA.Client.dll',
    '/_framework/_bin/BlazorPWA.Shared.dll'
];

self.addEventListener('install', function (e) {
    console.log('[ServiceWorker] Install');
    e.waitUntil(
        caches.open(cacheName).then(function (cache) {
            console.log('[ServiceWorker] Caching app shell');
            return cache.addAll(filesToCache);
        })
    );
});

self.addEventListener('activate', event => {
    event.waitUntil(self.clients.claim());
});

self.addEventListener('fetch', event => {


    console.log('fetch: ' + event.request.url);
    event.respondWith(
        fetch(event.request).then(function (r) {
            response = r;
            caches.open(cacheName).then(function (cache) {
                cache.put(event.request, response);
            });
            return response.clone();
        })
            .catch(function () {
                    console.log('fetch - recupero da cache: ' + event.request.url);
                    return caches.match(event.request);
                })
        
    );



});