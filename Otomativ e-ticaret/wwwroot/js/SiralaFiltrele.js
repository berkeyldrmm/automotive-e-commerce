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
    if (getParamFromUrl('marka')) {
        url += "&";
    }
    else {
        url += "?";
    }
    var enaz = $("input[name='enaz']").val();
    var enfazla = $("input[name='enfazla']").val();
    url += "enaz=" + enaz + "&enfazla=" + enfazla;
    
    window.location.href = url;
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
    if (getParamFromUrl('marka') || getParamFromUrl('enaz')) {
        url += "&";
    }
    else {
        url += "?";
    }
    
    url += "sira=" + e.target.id;
    window.location.href = url;
});

function getParamFromUrl(paramName) {
    var urlParams = new URLSearchParams(window.location.search);
    return urlParams.get(paramName);
}