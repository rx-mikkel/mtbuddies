(function () {
    var app = angular.module('mtBuddies', ['ngRoute']);

    app.controller('TrackController', ['$scope', '$http', '$routeParams', function ($scope, $http, $routeParams) {        
        $http.get('api/Track/GetTrackDetailsById',
            {
                params:
                   { trackId: $routeParams.trackId }
            }).success(function (data) {
	            $scope.Track = data;
	            $scope.Track.hasRides = function () {
	                return $scope.Track.rides.length;
	            };
            }).error(function () {
                //TODO Handle errors
            });
	}]);

    app.controller('TrackOverviewController', ['$scope', '$filter', '$http', function ($scope, $filter, $http) {
        $http.get('api/Track/GetTracksOverview').success(function (data) {
            var orderBy = $filter('orderBy');
            $scope.tracks = data;

            $scope.order = function (predicate, reverse) {
                $scope.tracks = orderBy($scope.tracks, predicate, reverse);
            };
            $scope.order('name', false);

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
		    		   		        
		    var rideVM = {
		        date: newRide.date.toISOString(),
		        time: newRide.time.toISOString(),
		        author: newRide.author,
		        comment: newRide.comment,
		        participants: [],
		        trackId: track.id,
		    };

            $http({
                method: 'POST',
                url: 'api/Ride/AddRide',
                contentType: "application/json",
                data: JSON.stringify(rideVM),
            }).success(function (rideId) {
                newRide.createdOn = Date.now();
                newRide.id = rideId;
                track.rides.push(newRide);
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
	            url: 'api/Ride/AddParticipant?rideId=' + ride.id + '&name=' + newParticipant.name,	            
	        }).success(function () {
	            ride.participants.push(newParticipant.name);	            
	        });

	        this.participant = {};
	    };
	}]);

	app.controller('HomeController', ['$scope', function ($scope) {
	    $scope.aboutText = 'This is about MTBuddies.com More here soon.';
	    $scope.roadMapText = 'This is about our dev. plan. More here soon.';
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
            }).when('/About', {
                templateUrl: '/SubViews/About.html',
                controller: 'HomeController'
            }).when('/RoadMap', {
                templateUrl: '/SubViews/roadMap.html',
                controller: 'HomeController'
            }).when('/', {
                templateUrl: '/SubViews/TrackOverview.html',
                controller: 'TrackOverviewController'
            });
        }
	]);
})();
