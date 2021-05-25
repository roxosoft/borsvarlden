// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
(function($) {
        $(document).ready(function() {
            // Recalc sticky right elements when subscribe widget terms is shown / hiden
            $('#single-collapse-').on('shown.bs.collapse',
                function() {
                    $('.sticky-right').trigger("sticky_kit:recalc");
                });

            $('#single-collapse-').on('hidden.bs.collapse',
                function() {
                    $('.sticky-right').trigger("sticky_kit:recalc");
                });

            // Handle form events / validations
            $('#sidebar-widget-form- #signup-submit-1').click(function(e) {
                e.preventDefault();
                $("#sidebar-widget-form- #signup-submit").click();
                return false;
            });

        $('#sidebar-widget-form-').validator().on('submit',
            function(e) {
                if (e.isDefaultPrevented()) {
                    // Show terms if checkbox is not checked
                    if (!$('#checkbox-terms-').is(":checked")) {
                        $('#single-collapse-').collapse('show');
                    }
                } else {
                    e.preventDefault(); // don't submit multiple times
                    this.submit(); // use the native submit method of the form element

                    setTimeout(function() { // Delay for Chrome
                            $('#sidebar-widget-form- #mce-EMAIL').val(''); // blank the input
                        },
                        100);
                }
            });

        $('iframe[name="f16aa1e321034e4"]').each(function () {
            function injectCSS() {
                $iframe.contents().find('head').append(
                    $('<link/>', { rel: 'stylesheet', href: 'iframe.css', type: 'text/css' })
                );
            }

            var $iframe = $(this);
            $iframe.on('load', injectCSS);
            injectCSS();
        });

        $('table.article-table').stacktable();
    });// End of document ready
})(jQuery);

(function ($) {
    $('iframe[name = "f16aa1e321034e4"]').ready(function() {
        function injectCSS() {
            $iframe.contents().find('head').append(
                $('<link/>', { rel: 'stylesheet', href: '/css/site.min.css', type: 'text/css' })
            );
        }
        alert('foo !')
        var $iframe = $(this);
        $iframe.on('load', injectCSS);
        injectCSS();
    });
})(jQuery);