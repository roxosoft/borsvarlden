(function ($) {
    $(document).ready(function () {
        $('.body-wrapper').removeAttr('background-color').css('background-color', 'white');
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
})(jQuery);