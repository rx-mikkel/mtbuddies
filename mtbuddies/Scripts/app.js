(function () {    
	var app = angular.module('mtBuddies', []);

	app.controller('TrackController', ['$http', function ($http) {
	    tracks = this;

	    /*var mtbTracks = this;
		mtbTracks.tracks = [ ];
		
		$http.get('js/tracks.json').success(function(data) {
	        mtbTracks.tracks = data;
	    });*/	    

	    $http.post('/Tracks/GetTrackDetails').success(function (data) {
            data[0].reviews = [];

            tracks.track = data[0];            

            tracks.hasRides = function () {
                return tracks.track.Rides.length;
            };

            tracks.hasReviews = function () {
                return tracks.track.reviews.length;
            };

        }).error(function () {
            //TODO Handle errors
        });        
	}]);

	app.controller('TabController', function () {
		this.tab = "rides";

		this.setTab = function (activeTab) {
			this.tab = activeTab;
		};

		this.tabSelected = function(currentTab) {
			return this.tab === currentTab;
		};
	});

	app.controller('RideController', ['$http', function ($http) {
		var presetTime = new Date(2015, 0, 1, 10, 0, 0);
		var presetDate = new Date();

		this.date = presetDate;

		this.ride = {
			time: presetTime,
			date: presetDate,
			participants: []
		};

        

		this.addRide = function (track) {

		    //TODO Add the right data here.
		    $http({
		        method: 'POST',
		        url: '/Ride/AddRide',
		        data: {
		            date: '02-07-2015',
		            time: '22.00',
		            author: 'Johnny Testen',
		            comment: 'Dette er en test comment.'                    
		        }
		    }).success(function (data) {
		        //TODO update stuff here when server returns.
		    });

			this.ride.createdOn = Date.now();
			track.rides.push(this.ride);
			this.ride = {
				time: presetTime,
				date: presetDate
			};
		};
	}]);

	app.controller('SignupController', ['$http', function ($http) {
	    this.participant = {};        	    

	    this.addParticipant = function (ride) {

            console.log(this.participant)

            //TODO Get rideId and entered name.
	        $http({
	            method: 'POST',
	            url: '/Ride/AddParticipant',
	            data: {
	                rideId: ride.Id,
                    name: this.participant.name
	            }
	        }).success(function (data) {
	            
	        });

	        this.participant.createdOn = Date.now();
	        ride.Participant.push(this.participant);
	        this.participant = {};
	    };
	}]);

	app.controller('ReviewController', function () {
		this.review = {};

		this.addReview = function (track) {
			this.review.createdOn = Date.now();
			track.reviews.push(this.review);
			this.review = {};
		};
	});

	app.directive('trackRides', function () {
		return {
			restrict: 'E',
			templateUrl: '/SubViews/Rides.html'
		};
	});

	app.directive('trackReviews', function () {
		return {
			restrict: 'E',
			templateUrl: '/SubViews/Reviews.html'
		};
	});
    /*
	var tracks = [
	{
	    name: 'Kongshøj',
	    map: "/Content/images/kongshoej.png",
	    length: 7.5,
	    difficulty: 3,
	    direction: "cw",
	    lat: 57.003186,
	    lon: 9.920193,
	    description: "MTB-ruten i Kongshøj er en begyndervenlig rute, som samtidig er attraktiv for mere garvede ryttere, der gerne vil presse sig selv mod uret.",
	    reviews: [],
	    rides: []
	},
	{
	    name: 'Hammer bakker',
	    map: "/Content/images/hammer-bakker.png",
	    length: 13,
	    difficulty: 4,
	    direction: "ccw",
	    lat: 57.122455,
	    lon: 10.024561,
	    description: "Sporet Hammer bakker er en tur for de øvede ryttere. Det er en smuk, men hård rute igennem kuperet skov. Der er garanti for sved på panden!",
	    reviews: [],
	    rides: []
	}];
    */
})();