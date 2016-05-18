(function(){
    angular.module('weddingManager')
    .controller('serviceSearchController', function($scope, $location, appStateService, serviceService){
        $scope.searchResults = [];
        
        function initialize(){
        }
        
        $scope.return = function(){
            appStateService.setCustomer(null);
            $location.path('home');            
        }
        
        initialize();     
    });
})();