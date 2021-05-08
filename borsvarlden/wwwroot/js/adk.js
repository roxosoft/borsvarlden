(function () {

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