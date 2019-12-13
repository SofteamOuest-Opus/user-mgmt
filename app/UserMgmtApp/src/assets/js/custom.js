
// Page load
$(document).ready(function () {

    var headerHeight = $('#header').outerHeight();
    var footerHeight = $('#footer').outerHeight();
    var headerFooterHeight = headerHeight + footerHeight;

    // windows height => min-height content
    var clientHeight = document.body.clientHeight;
    $('#sd-content').css('min-height', (clientHeight - headerFooterHeight));

});


