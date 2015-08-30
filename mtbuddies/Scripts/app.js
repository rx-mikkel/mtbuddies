(function () {
    var app = angular.module('mtBuddies', []);

	app.controller('TrackController', ['$http', function ($http) {
	    var tracks = this;

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
		this.tab = 'rides';

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
	        var newParticipant = this.participant;

	        $http({
	            method: 'POST',
	            url: '/Ride/AddParticipant',
	            data: {
	                rideId: ride.Id,
	                name: newParticipant.name
	            }
	        }).success(function (data) {
	            ride.Participants.push(newParticipant.name);	            
	        });

	        this.participant = {};
	    };
	}]);

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
})();