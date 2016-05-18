(function(){
    angular.module('weddingManager')
    .controller('customerSearchController', function($scope, $location, appStateService, customerService, serviceService){
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