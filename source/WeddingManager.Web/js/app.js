var weddingManager = angular.module('weddingManager', ['ngRoute']);

weddingManager.config(function($routeProvider){
   $routeProvider
   .when('/', {
       templateUrl : 'templates/login.html',
       controller : 'loginController'
   });
});

weddingManager.controller('appController', function($scope){
    $scope.message = 'poop';
});