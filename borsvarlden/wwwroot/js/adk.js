(function () {
    //if (document.cookie.indexOf('adktest=1') < 0) return
    if (window.location.search === '')
    window.location.search = 'adk_preview=eyJjIjoid3MyZmVESWZMUiIsImEiOiJjb20uYWR2aXNpYmxlLm5hdGl2ZS50ZWFzZXIiLCJpIjoiZmE1ODRkN2YtM2UzNC00NzhiLWJjNDEtMTk2OWVmYTE0YjljIn0%3D';

    function loadScript(src) {
        var scriptElem = document.createElement('SCRIPT');
        scriptElem.setAttribute('src', src);
        document.head.appendChild(scriptElem)
    }
    function loadStyles(href) {
        var linkElem = document.createElement('LINK');
        linkElem.setAttribute('rel', 'stylesheet');
        linkElem.setAttribute('href', href);
        document.head.appendChild(linkElem)
    }

    window.adk = window.adk || { cmd: [] }
    var publicRoot = 'https://source.advisible.com/10124263'

    loadScript('https://cdn.advisible.com/adk-1.5.8.js')
    loadStyles(publicRoot + '/native/style.css')
    loadScript(publicRoot + '/native/setup.js')
})();
