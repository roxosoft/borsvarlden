(function ($) {
    $(document).ready(function () {
        $('#subscribe-widget-form-5eb0132bd5c09 #signup-submit-1').click(function (e) {
            e.preventDefault();
            $("#subscribe-widget-form-5eb0132bd5c09 #signup-submit").click();
            return false;
        });

        $('#subscribe-widget-form-5eb0132bd5c09').validator().on('submit', function (e) {
            if (e.isDefaultPrevented()) {
                // Show terms if checkbox is not checked
                if (!$('#checkbox-terms-5eb0132bd5c09').is(":checked")) {
                    $('#single-collapse-5eb0132bd5c09').collapse('show');
                }
            } else {
                e.preventDefault(); // don't submit multiple times
                this.submit(); // use the native submit method of the form element
                setTimeout(function () { // Delay for Chrome
                    $('#subscribe-widget-form-5eb0132bd5c09 #mce-EMAIL').val(''); // blank the input
                }, 100);
            }
        })
    });// End of document ready

    $(window).scroll(function () {
        var top = $(document).scrollTop();
        if (top > 0) {
            $('.sticky-right').css('top', '70px');
        } else {
            $('.sticky-right').css('top', '100px');
        }
    });
})(jQuery);