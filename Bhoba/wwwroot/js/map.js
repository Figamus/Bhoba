//*****Begin Code for running the Google Maps API*****

//listOfLocations is a json array created from a C# List<> that concats the full address from the model parameters
let finalList = listOfLocations.map(address => {
    let x = {};
    x.fullAddress = `${address.StreetAddress} ${address.City} ${address.State} ${address.ZipCode}`;
    x.Latitude = address.Latitude;
    x.Longitude = address.Longitude;
    return x;
});

//*****Multiple Geocoding*****
//intialize google maps api with options
function initMap() {
    let infowindow = new google.maps.InfoWindow();
    let latlng = new google.maps.LatLng(36.174465, -86.767960);
    let mapOptions = {
        zoom: 8,
        center: latlng,
        mapTypeId: google.maps.MapTypeId.ROADMAP,
        streetViewControl: false,
        styles: [
            { elementType: 'geometry', stylers: [{ color: '#242f3e' }] },
            { elementType: 'labels.text.stroke', stylers: [{ color: '#242f3e' }] },
            { elementType: 'labels.text.fill', stylers: [{ color: '#746855' }] },
            {
                featureType: 'administrative.locality',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#d59563' }]
            },
            {
                featureType: 'poi',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#d59563' }]
            },
            {
                featureType: 'poi.park',
                elementType: 'geometry',
                stylers: [{ color: '#263c3f' }]
            },
            {
                featureType: 'poi.park',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#6b9a76' }]
            },
            {
                featureType: 'road',
                elementType: 'geometry',
                stylers: [{ color: '#38414e' }]
            },
            {
                featureType: 'road',
                elementType: 'geometry.stroke',
                stylers: [{ color: '#212a37' }]
            },
            {
                featureType: 'road',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#9ca5b3' }]
            },
            {
                featureType: 'road.highway',
                elementType: 'geometry',
                stylers: [{ color: '#746855' }]
            },
            {
                featureType: 'road.highway',
                elementType: 'geometry.stroke',
                stylers: [{ color: '#1f2835' }]
            },
            {
                featureType: 'road.highway',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#f3d19c' }]
            },
            {
                featureType: 'transit',
                elementType: 'geometry',
                stylers: [{ color: '#2f3948' }]
            },
            {
                featureType: 'transit.station',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#d59563' }]
            },
            {
                featureType: 'water',
                elementType: 'geometry',
                stylers: [{ color: '#17263c' }]
            },
            {
                featureType: 'water',
                elementType: 'labels.text.fill',
                stylers: [{ color: '#515c6d' }]
            },
            {
                featureType: 'water',
                elementType: 'labels.text.stroke',
                stylers: [{ color: '#17263c' }]
            }
        ]
    }

    //Set Geocoder, establish map and set bounds and delcare a delay integer
    let geocoder = new google.maps.Geocoder();
    let map = new google.maps.Map(document.getElementById("map"), mapOptions);
    let bounds = new google.maps.LatLngBounds();
    let delay = 100;

    //geocodeAddress takes 2 parameters, a full address that will be geocoded, returns the result and status code
    //contains a catch that is query is too high, it will run a delay.
    function geocodeAddress(address, next) {
        if (address.Latitude != null && address.Longitude != null)
        {
            createMarker(address.fullAddress, address.Latitude, address.Longitude);
            bounds.extend(new google.maps.LatLng(address.Latitude, address.Longitude));
            nextAddress++;
            next();
        }
        else
        {
            geocoder.geocode({ address: address.fullAddress }, function (results, status) {
                console.log(`Geocoding ${address}`);
                if (status == google.maps.GeocoderStatus.OK) {
                    let p = results[0].geometry.location;
                    let lat = p.lat();
                    let lng = p.lng();
                    createMarker(address, lat, lng);
                    bounds.extend(new google.maps.LatLng(lat, lng));
                    nextAddress++
                }
                else {
                    if (status == google.maps.GeocoderStatus.OVER_QUERY_LIMIT) {
                        delay++;
                    } else {
                    }
                }
                next();
            });
        }
    }

    //This creates a pushpin on the map
    function createMarker(add, lat, lng) {
        let contentString = add;
        let marker = new google.maps.Marker({
            position: new google.maps.LatLng(lat, lng),
            map: map,
        });
        google.maps.event.addListener(marker, 'click', function () {
            infowindow.setContent(contentString);
            infowindow.open(map, marker);
        });
        bounds.extend(marker.position);
    }

    //a counter for the index position on the fullList array
    let nextAddress = 0;

    //function to run geoCodeAddress to be used within a setTimeout
    callGeocode = () => {
        geocodeAddress(finalList[nextAddress], theNext);
    }


    function theNext() {
        if (nextAddress < finalList.length) {
            setTimeout(callGeocode, delay);
        } else {
            map.fitBounds(bounds);
        }
    }

    theNext();
}
//*****End Multiple GeoCoding*****