(function ($) {
$(document).ready(function () {
    var carousel = $(".owl-carousel").owlCarousel({
        margin: 30,
        responsiveClass: true,
        responsive: {
            0: {
                items: 2
            },
            768: {
                items: 3
            },
            1020: {
                items: 4
            }
        }
    });
});
})(jQuery);