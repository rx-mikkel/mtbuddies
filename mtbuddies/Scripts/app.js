(function () {
    var app = angular.module('mtBuddies', ['ngRoute']);

    app.controller('TrackController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {        
        $http.post('/Tracks/GetTrackDetails', { trackId: $routeParams.trackId }).success(function (data) {
	        $scope.Track = data;
	        $scope.Track.hasRides = function () {
	            return $scope.Track.Rides.length;
	        };
        }).error(function () {
            //TODO Handle errors
        });
	}]);

    app.controller('TrackOverviewController', ['$scope', '$filter', '$http', function ($scope, $filter, $http) {
        $http.post('/Tracks/GetTracksOverview').success(function (data) {
            var orderBy = $filter('orderBy');
            $scope.tracks = data;

            $scope.order = function (predicate, reverse) {
                $scope.tracks = orderBy($scope.tracks, predicate, reverse);
            }
            $scope.order('Name', false);

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

		this.Date = presetDate;

		this.ride = {
			Time: presetTime,
			Date: presetDate,
			Participants: []
		};
       
		this.addRide = function (track) {
		    var newRide = this.ride;
		    newRide.Date.setHours(0);
		    newRide.Date.setMinutes(0);

		    var data = {
		        trackId: track.Id,
		        rideVM: {
		            date: newRide.Date.toISOString(),
		            time: newRide.Time.toISOString(),
		            author: newRide.Author,
		            comment: newRide.Comment,
		            participants: []
		        }		        
		    };

            $http({
                method: 'POST',
                url: '/Ride/AddRide',
                data: data,
            }).success(function (rideId) {
                newRide.createdOn = Date.now();
                newRide.Id = rideId;
                track.Rides.push(newRide);
            });

            this.ride = {
                Time: presetTime,
                Date: presetDate,
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

	app.config([
        '$routeProvider',
        function ($routeProvider) {
            $routeProvider.when('/Tracks/Track/:trackId', {
                templateUrl: '/SubViews/Track.html',
                controller: 'TrackController'
            }).when('/', {
                templateUrl: '/SubViews/TrackOverview.html',
                controller: 'TrackOverviewController'
            })
        }
	]);
})();
