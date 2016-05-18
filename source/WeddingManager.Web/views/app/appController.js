(function(){
    angular.module('weddingManager')
    .controller('appController', function($scope, $location, loginService, appStateService){
		$scope.navigateHome = function(){
                  $location.path('home');
		}
            
            $scope.navigateToSearch = function(){
                  $location.path('search');
            }
            
		$scope.logOut = function(){
                  loginService.logOut(function(){
                        appStateService.clearState();
                        $location.path('');
                  });
		}
	});	
})();