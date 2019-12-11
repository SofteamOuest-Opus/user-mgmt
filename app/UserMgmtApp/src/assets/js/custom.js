
// Page load
$(document).ready(function () {

    // windows height => min-height content
    var clientHeight = document.body.clientHeight;
    // Client height - (header + footer height)
    $('#sd-content').css('min-height', (clientHeight - 100));
});

