// dependent on   <script src="http://maps.googleapis.com/maps/api/js?key=AIzaSyApXY_LzzT8ze9rMkobNKntNvM_oXSIP4o&sensor=true"></script>

// maps tutorial at https://developers.google.com/maps/documentation/javascript/tutorial
// marker placement sample at https://google-developers.appspot.com/maps/documentation/javascript/examples/marker-simple

Window.Whisper = Whisper || {};

// usage:
//var map = new Whiper.Map({
//    id:'map_canvas',
//    zoomLevel:18,
//    callback:function () {
//
//    }
//});


Whisper.Map = (function () {

    var map;

    // store each marker so that we can batch remove them
    var markers = [];

    // options.id - ID of the map div
    // options.callback - callback for when the map is finished initializing
    // options.zoomLevel (optional) - 1 - 20, defeaults to 18
    var initialize = function (options) {
        var zoom = options.zoomLevel || 18;
        navigator.geolocation.getCurrentPosition(function success(position) {
            var location = { lat:position.coords.latitude, lng:position.coords.longitude };
            var mapOptions = {
                center:new google.maps.LatLng(location.lat, location.lng),
                zoom:zoom,
                mapTypeId:google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map($('#' + options.id).get(0), mapOptions);

            placeMarker(location, true);
            if (options.callback) options.callback();
        }, function error(msg) {
            alert('error getting location. Message was: ' + msg);
        });

    };

    // pass single { lat: 0.0, lng: 0.0 } or an array of these objects
    var placeMarker = function (markerInfo, neverClear) {
        // if the argument is an object, put it into an array
        if (!$.isArray(markerInfo)) {
            markerInfo = [ markerInfo ];
        }
        $.each(markerInfo, function (index, element) {
            var marker = new google.maps.Marker({
                position:new google.maps.LatLng(element.Latitude, element.Longitude),
                map:map,
                title: element.StudentId
            });
            if (!neverClear) markers.push(marker);
        });
    };
    var clearMarkers = function () {
        $.each(markers, function (index, marker) {
            marker.setMap(null);
        });
    };

    var test = function () {
        var locations = [
            { lat:0, lng:0 },
            { lat:40, lng:40 }
        ];
        navigator.geolocation.getCurrentPosition(function success(position) {
            locations.push({ lat:position.coords.latitude, lng:position.coords.longitude });
            placeMarker(locations);
            //clearMarkers();

        });
    };

    return function(options) {
        this.initialize = initialize;
        this.placeMarker = placeMarker;
        this.placeMarkers = placeMarker;
        this.clear = clearMarkers;
        this.test = test;

        this.initialize(options);
    };

})();



