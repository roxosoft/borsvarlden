( function ( $ ) {

	$( document ).ready( function () {

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
    } );

	// set Cookie Notice
	$.fn.setCookieNotice = function ( cookie_value ) {

		var cnTime		= new Date(),
			cnLater		= new Date(),
			cnDomNode	= $( '#cookie-notice' );
		
		self = this;

		// set expiry time in seconds
		cnLater.setTime( parseInt( cnTime.getTime() ) + parseInt( 'month' ) * 1000 );

		// set cookie
		cookie_value = cookie_value === 'accept' ? true : false;
        document.cookie = 'cookie_notice_accepted' + '=' + cookie_value + ';expires=' + cnLater.toGMTString() + ';' + ( /*cnArgs.cookieDomain !== undefined && cnArgs.cookieDomain !== '' ? 'domain=' + cnArgs.cookieDomain + ';' :*/ '' ) + ( /*cnArgs.cookiePath !== undefined && cnArgs.cookiePath !== '' ? 'path=' + cnArgs.cookiePath + ';' :*/ '' );

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

	// remove Cookie Notice
	$.fn.removeCookieNotice = function ( cookie_value ) {
		$( '#cookie-notice' ).remove();
		$( 'body' ).removeClass( 'cookies-not-accepted' );
	}

} )( jQuery );
