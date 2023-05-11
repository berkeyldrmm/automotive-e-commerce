$("#filtrele").click(function () {
    $("#filtreleDiv").removeClass("d-none");
    $("#filtreleDiv").fadeIn(600);
});

$("#close").click(function () {
    $("#filtreleDiv").fadeOut(600);
});

$("#uygula").click(e => {
    e.preventDefault();
    var url = window.location.href;
    var urlParts = url.split('/');
    var uruncesit;
    var action;
    if (getParamFromUrl('marka') || getParamFromUrl('sira')) {
        uruncesit = urlParts[urlParts.length - 3];
        action = urlParts[urlParts.length - 2];
    }
    else {
        uruncesit = urlParts[urlParts.length - 2];
        action = urlParts[urlParts.length - 1];
    }

    var newurl = "https://localhost:7121/urunler/" + uruncesit + "/" + action + "/?";
    if (getParamFromUrl('marka')) {
        newurl += "marka=" + getParamFromUrl("marka")+"&";
    }
    if (getParamFromUrl('sira')) {
        newurl += "sira=" + getParamFromUrl("sira") + "&";
    }
    var enaz = $("input[name='enaz']").val();
    var enfazla = $("input[name='enfazla']").val();
    newurl += "enaz=" + enaz + "&enfazla=" + enfazla;
    
    window.location.href = newurl;
});

$("#sirala").click(() => {
    if ($("#siralaListe").hasClass("d-none")) {
        $("#siralaListe").removeClass("d-none");
    }
    else {
        $("#siralaListe").addClass("d-none");
    }
});

$("#siralaListe button").click(e => {
    var url = window.location.href;
    var urlParts = url.split('/');
    var uruncesit;
    var action;
    if (getParamFromUrl('marka') || getParamFromUrl('enaz')) {
        uruncesit = urlParts[urlParts.length - 3];
        action = urlParts[urlParts.length - 2];
    }
    else {
        uruncesit = urlParts[urlParts.length - 2];
        action = urlParts[urlParts.length - 1];
    }
    var newurl = "https://localhost:7121/urunler/" + uruncesit + "/" + action + "/?";
    if (getParamFromUrl('marka')) {
        newurl += "marka=" + getParamFromUrl("marka") + "&";
    }
    if (getParamFromUrl('enaz')) {
        newurl += "enaz=" + getParamFromUrl('enaz') + "&enfazla=" + getParamFromUrl('enfazla') + "&";
    }
    newurl += "sira=" + e.target.id;
    window.location.href = newurl;
});

function getParamFromUrl(paramName) {
    var urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(paramName);
}

