(function(){
    angular.module('weddingManager')
    .controller('searchController', function($scope, $location, appStateService, serviceService, serviceDetailService){
        $scope.company = null;
        $scope.serviceDetails = [];
        $scope.serviceDetailSearchCriteria = {
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
            appStateService.clearHistory();
        }
        
        $scope.switchTo = function(panelName){
            for(var panel in _visibilities){
                _visibilities[panel] = panel == panelName;
            }
        }
        
        $scope.getVisibility = function(panelName){
            return _visibilities[panelName];
        }
        
        $scope.searchServiceDetails = function(){
            serviceDetailService.search($scope.company.Id, $scope.serviceDetailSearchCriteria, function(searchResults){
                $scope.serviceDetails = searchResults;
            }, function(){
               $location.path('error'); 
            });
        }
        
        $scope.navigateToService = function(serviceId){
            serviceService.retrieveService($scope.company.Id, serviceId, function(service){
                appStateService.setService(service);
                appStateService.pushHistory('search');
                $location.path('service');
            }, function(){
               $location.path('error'); 
            });
        }
        
        initialize();     
    });
})();