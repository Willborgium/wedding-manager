(function(){
    angular.module('weddingManager')
    .controller('serviceController', function($scope, $location, appStateService, serviceService){
        $scope.service = null;
        $scope.isSaveDisabled = true;
        
        function initialize(){
            $scope.service = appStateService.getService();
        }
        
        function isDirty(){
            var serviceChanges = JSON.stringify($scope.service);
            var service = appStateService.getService();
            var serviceString = JSON.stringify(service);
            return serviceString != serviceChanges;
        }
        
        $scope.onFieldChanged = function(){
            $scope.isSaveDisabled = !isDirty();
        }
        
        $scope.clearChanges = function(){
            $scope.service = appStateService.getService();
        }
        
        $scope.updateService = function(){
            serviceService.updateService($scope.service, function(){
                appStateService.setService($scope.service);
                $scope.onFieldChanged();               
            }, function(){
               $location.path('error'); 
            });
        }
        
        $scope.deleteService = function(){
            serviceService.deleteService($scope.service.Id, function(){
                $location.path('customer');
            }, function(){
                $location.path('error');
            });
        }
        
        $scope.return = function(){
            appStateService.setService(null);
            $location.path('customer');
        }
        
        initialize();     
    });
})();