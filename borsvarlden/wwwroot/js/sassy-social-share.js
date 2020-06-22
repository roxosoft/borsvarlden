function heateorSssLoadEvent(e) {
    var t = window.onload;
    if (typeof window.onload != "function") {
        window.onload = e;
    } else {
         window.onload = function () { t(); e() }
    }
};

function heateorSssPopup(e) {
     window.open(e, "popUpWindow", "height=400,width=600,left=400,top=100,resizable,scrollbars,toolbar=0,personalbar=0,menubar=no,location=no,directories=no,status")
};
var heateorSssWhatsappShareAPI = "web";
