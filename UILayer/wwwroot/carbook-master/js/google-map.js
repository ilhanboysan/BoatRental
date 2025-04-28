
var google;

function init() {
    var myLatlng = new google.maps.LatLng(36.752583, 28.941250); // Marmaris civarý

    var mapOptions = {
        zoom: 15,
        center: myLatlng,
        scrollwheel: false
    };

    var mapElement = document.getElementById('map');
    var map = new google.maps.Map(mapElement, mapOptions);

    var marker = new google.maps.Marker({
        position: myLatlng,
        map: map,
        title: 'Benim Konumum',
        icon: 'images/loc.png' // Özel ikon kullanýyorsan burada belirt
    });
}

google.maps.event.addDomListener(window, 'load', init);