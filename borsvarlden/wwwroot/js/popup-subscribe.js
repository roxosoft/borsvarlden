var scrollCount = 0;

(function ($) {
    $(document).ready(function () {

        $('#close-popup').click(function() {
            $('#pum-2918').css('display', 'none');
            // set expiry time in seconds - two years
            var cnTime = new Date();
            cnTime.setTime(parseInt(cnTime.getTime()) + 64281600 * 1000);
            document.cookie = 'cookie_subscribe_accepted=true;expires=' + cnTime.toGMTString() + ';';
        });

        $(window).scroll(function() {
            scrollCount++;
            if (scrollCount > 50) {
                if (document.cookie.indexOf('cookie_subscribe_accepted') === -1) {
                    $('#pum-2918').css('display', 'block');
                }
            }
        });

    });// End of document ready
})(jQuery);