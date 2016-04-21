(function(){
	var weddingManager = angular.module('weddingManager', ['ngRoute']);

	weddingManager.config(function($routeProvider){
	   $routeProvider
	   .when('/error', {
		   templateUrl : 'views/error/error.html'
	   })
	   .when('/', {
	       templateUrl : 'views/login/login.html',
	       controller : 'loginController'
	   })
	   .when('/home', {
	       templateUrl : 'views/home/home.html',
	       controller : 'homeController'
	   })
	   .otherwise({
		   redirectTo : '/error'
	   });
	});

	weddingManager.controller('appController', function($scope){
	    $scope.AppTitle = 'Wedding Manager';
	});	
})();