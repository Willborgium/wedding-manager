(function(){
	var weddingManager = angular.module('weddingManager', ['ngRoute']);

	weddingManager.config(function($routeProvider){
	   $routeProvider
	   .when('/error', {
		   templateUrl : 'templates/error.html'
	   })
	   .when('/', {
	       templateUrl : 'templates/login.html',
	       controller : 'loginController'
	   })
	   .when('/home', {
	       templateUrl : 'templates/home.html',
	       controller : 'homeController'
	   })
	   .otherwise({
		   redirectTo : "/error"
	   });
	});

	weddingManager.controller('appController', function($scope){
	    $scope.AppTitle = 'Wedding Manager';
	});	
})();