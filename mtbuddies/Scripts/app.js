(function () {
    var app = angular.module('mtBuddies', []);

	app.controller('TrackController', ['$http', function ($http) {
	    var tracks = this;

	    $http.post('/Tracks/GetTrackDetails', { trackId: 1 }).success(function (data) {
            tracks.track = data;

            tracks.hasRides = function () {
                return tracks.track.Rides.length;
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
		    var newRide = this.ride;
		    newRide.date.setHours(0);
		    newRide.date.setMinutes(0);

		    var data = {
		        trackId: track.Id,
		        rideVM: {
		            date: newRide.date.toISOString(),
		            time: newRide.time.toISOString(),
		            author: newRide.author,
		            comment: newRide.body,
		            participants: []
		        }		        
		    };

            $http({
                method: 'POST',
                url: '/Ride/AddRide',
                data: data,
            }).success(function () {
                newRide.createdOn = Date.now();
                track.Rides.push(newRide);
            });

            this.ride = {
                time: presetTime,
                date: presetDate,
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
	        }).success(function () {
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