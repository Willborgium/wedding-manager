(function(){
    angular.module('weddingManager')
    .controller('searchController', function($scope, $location, appStateService, serviceService){
        $scope.company = null;
        $scope.services = [];
        $scope.service = {
            StartDate : null,
            EndDate : null
        }
        
        var _visibilities = {
            services : true,
            customers : false,
            invoices : false
        };
        
        function initialize(){
            $scope.company = appStateService.getCompany();
            if(!$scope.company){
                $location.path('error');
            }
        }
        
        $scope.return = function(){
            appStateService.setCustomer(null);
            $location.path('home');
        }
        
        $scope.switchTo = function(panelName){
            for(var panel in _visibilities){
                _visibilities[panel] = panel == panelName;
            }
        }
        
        $scope.getVisibility = function(panelName){
            return _visibilities[panelName];
        }
        
        $scope.serviceSearch = function(){
            serviceService.search($scope.company.Id, $scope.service, function(searchResults){
                $scope.services = searchResults;
            }, function(){
               $location.path('error'); 
            });
        }
        
        initialize();     
    });
})();