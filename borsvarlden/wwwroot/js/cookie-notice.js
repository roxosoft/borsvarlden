( function ( $ ) {

    $(document).ready(function () {
 
		var cnDomNode = $( '#cookie-notice' );

		// handle set-cookie button click
		$( document ).on( 'click', '.cn-set-cookie', function ( e ) {
			e.preventDefault();
			$( this ).setCookieNotice( $( this ).data( 'cookie-set' ) );
		} );

		// display cookie notice
		if ( document.cookie.indexOf( 'cookie_notice_accepted' ) === -1 ) {
            cnDomNode.fadeIn( 300 );
            $( 'body' ).addClass( 'cookies-not-accepted' );
		} else {
			cnDomNode.removeCookieNotice();
        }

        setTimeout(
            function () {
                $(this).setSplashScreenNotice($(this).data('splashScreen-set'));
            },
            10000  
        );

    });

    function getCookie(cname) {
        var name = cname + "=";
        var decodedCookie = decodeURIComponent(document.cookie);
        var ca = decodedCookie.split(';');
        for (var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }

    // set Cookie Notice
	$.fn.setCookieNotice = function ( cookie_value ) {

		var cnTime		= new Date(),
			cnLater		= new Date(),
			cnDomNode	= $( '#cookie-notice' );
		
		self = this;

		// set expiry time in seconds - two years
        cnLater.setTime(parseInt(cnTime.getTime()) + 64281600 * 1000 );

		// set cookie
		cookie_value = cookie_value === 'accept' ? true : false;
        document.cookie = 'cookie_notice_accepted' + '=' + cookie_value + ';expires=' + cnLater.toGMTString() + ';'; //+ ( /*cnArgs.cookieDomain !== undefined && cnArgs.cookieDomain !== '' ? 'domain=' + cnArgs.cookieDomain + ';' :*/ '' ) + ( /*cnArgs.cookiePath !== undefined && cnArgs.cookiePath !== '' ? 'path=' + cnArgs.cookiePath + ';' :*/ '' );
      
		// trigger custom event
		$.event.trigger( {
			type		: "setCookieNotice",
			value		: cookie_value,
			time		: cnTime,
			expires		: cnLater
		} );

		cnDomNode.fadeOut( 300, function () {
				self.removeCookieNotice();
			} );
    };

    $.fn.setSplashScreenNotice = function (cookie_value) {

        if (document.cookie.indexOf('cookie_notice_accepted') === -1) {

            setTimeout(
                function () {
                    $(this).setSplashScreenNotice($(this).data('splashScreen-set'));
                },
                10000
            );
            return;
        }

        var nextSplashShow = getCookie('next_splash_show');
     
        //var offset = 1 * 60 * 1000; //use for for debug
        var offset = 24 * 60* 60 * 1000; //prod 24h

        if (!nextSplashShow || new Date() > new Date(nextSplashShow)) {
            var dtNextSplashShow = new Date();
            dtNextSplashShow.setTime(parseInt(new Date().getTime()) + offset);
            var expireTime = new Date();
            expireTime.setTime(parseInt(expireTime.getTime()) + 64281600 * 1000);
            var expireTimeSt = expireTime.toGMTString();
            document.cookie = 'next_splash_show=' + encodeURIComponent(dtNextSplashShow) + ';expires=' + expireTimeSt +';';
            $('#splashscreen-overlay').show();
            setTimeout(
                function () {
                    alert('!');
                    $('#splashscreen-overlay').hide();
                },
                100000
            );
        }
    };

	// remove Cookie Notice
	$.fn.removeCookieNotice = function ( cookie_value ) {
		$( '#cookie-notice' ).remove();
		$( 'body' ).removeClass( 'cookies-not-accepted' );
    }

} )( jQuery );
