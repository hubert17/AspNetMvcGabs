// Disable button and start dot animation
var form = $('form');
form.submit(function () {
    if (form.valid()) {
        //alert('The form is valid!!');
        var $el = $(":submit", this);
        submitAnimator($el);
    }
});

$(document).on('click', '.btn-submit', function () {
    submitAnimator(this);
});

var submitAnimator = function (e) {
    var $el = $(e);
    $el.prop('disabled', true); // Disables visually + functionally

    $el.attr('style', 'text-align: left');
    var elW = $el.width();
    $el.animate({
        width: elW + 40
    }, 200);

    // Animation will start at once
    $el.dotAnimation({
        speed: 300,
        dotElement: '.',
        numDots: 3
    });
}
