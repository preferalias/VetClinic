function isNumberKey(evt) {
        var charCode = (evt.which) ? evt.which : event.keyCode
        if (charCode > 31 && (charCode < 48 || charCode > 57))
            return false;
        return true;
}
function isNumberKeyDecimal(evt) {
        var charCode = (evt.which) ? evt.which : evt.keyCode;
        if (charCode !== 46 && charCode > 31
            && (charCode < 48 || charCode > 57))
            return false;
        return true;
}
function onInitEdit(s, e) {
    $("th").css('text-align', 'center');
    $("tr td:first-child").css('text-align', 'center');
    $("tr td:nth-child(3)").css('text-align', 'center');
    $("tr td:nth-child(7)").css('text-align', 'center');
}

function onInitEdit2(s, e) {
    $("th").css('text-align', 'center');
    $("tr td:first-child").css('text-align', 'center');
    $("tr td:nth-child(2)").css('text-align', 'center');
    $("tr td:nth-child(3)").css('text-align', 'center');
    $("tr td:nth-child(5)").css('text-align', 'center');
    $("tr td:nth-child(9)").css('text-align', 'center');
}

function onInitHome(s, e) {
    $("th").css('text-align', 'center');
    $("tr td:first-child").css('text-align', 'center');
    $("tr td:nth-child(3)").css('text-align', 'center');
    $("tr td:nth-child(4)").css('text-align', 'center');
    $("tr td:nth-child(5)").css('text-align', 'center');
    $("tr td:nth-child(6)").css('text-align', 'center');
    $("tr td:nth-child(8)").css('text-align', 'center');
    $("tr td:nth-child(9)").css('text-align', 'center');
}

function onInitSearch(s, e) {
    $("th").css('text-align', 'center');
    $("tr td:first-child").css('text-align', 'center');
    $("tr td:nth-child(3)").css('text-align', 'center');
    $("tr td:nth-child(4)").css('text-align', 'center');
    $("tr td:nth-child(5)").css('text-align', 'center');
    $("tr td:nth-child(6)").css('text-align', 'center');
    $("tr td:nth-child(8)").css('text-align', 'center');
    $("tr td:nth-child(10)").css('text-align', 'center');
}

function changeGlyph(s, e) {
    $('div.calendar-row tr td:first-child').hide();
    $('span .glyphicon.glyphicon-triangle-left').removeClass('glyphicon glyphicon-triangle-left').addClass('glyphicon glyphicon-chevron-left')
    $('span .glyphicon.glyphicon-triangle-right').removeClass('glyphicon glyphicon-triangle-right').addClass('glyphicon glyphicon-chevron-right')
}

function onInitAdmit(s, e) {
    $("th").css('text-align', 'center');
    $("tr td:first-child").css('text-align', 'center');
    $("tr td:nth-child(2)").css('text-align', 'center');
    $("tr td:nth-child(3)").css('text-align', 'center');
    $("tr td:nth-child(4)").css('text-align', 'center');
    $("tr td:nth-child(5)").css('text-align', 'center');
    $("tr td:nth-child(6)").css('text-align', 'center');
    $("tr td:nth-child(7)").css('text-align', 'center');
    $("tr td:nth-child(8)").css('text-align', 'center');
    $("tr td:nth-child(9)").css('text-align', 'center');
    $("tr td:nth-child(10)").css('text-align', 'center');
}