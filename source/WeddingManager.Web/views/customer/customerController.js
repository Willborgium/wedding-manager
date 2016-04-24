(function(){
    angular.module('weddingManager')
    .controller('customerController', function($scope, $location, appStateService, customerService, serviceService){
        $scope.customer = null;
        $scope.serviceFilter = "";
        $scope.services = [];
        $scope.isSaveDisabled = true;
        
        function initialize(){
            $scope.customer = appStateService.getCustomer();
            serviceService.refreshServices($scope.customer.Id, function(services){
                $scope.services = services;
            }, function(){
               $location.path('error'); 
            });
        }
        
        function isDirty(){
            var customerChanges = JSON.stringify($scope.customer);
            var customer = appStateService.getCustomer();
            var customerString = JSON.stringify(customer);
            return customerString != customerChanges;
        }
        
        $scope.onFieldChanged = function(){
            $scope.isSaveDisabled = !isDirty();
        }
        
        $scope.clearChanges = function(){
            $scope.customer = appStateService.getCustomer();
        }
        
        $scope.updateCustomer = function(){
            customerService.updateCustomer($scope.customer, function(){
                appStateService.setCustomer($scope.customer);
                $scope.onFieldChanged();               
            }, function(){
               $location.path('error'); 
            });
        }
        
        $scope.deleteCustomer = function(){
            $('#myModal')
            .on('hidden.bs.modal', function(){
                customerService.deleteCustomer($scope.customer.Id, function(){
                    $location.path('home');
                }, function(){
                    $location.path('error');
                });
            })
            .modal('hide');
        }
        
        $scope.viewService = function(service){
            appStateService.setService(service);
            $location.path('service');
        }
        
        $scope.createService = function(){
            serviceService.createService($scope.customer.Id, function(service){
                $scope.viewService(service);                                
            });
        }
        
        $scope.return = function(){
            appStateService.setCustomer(null);
            $location.path('home');            
        }
        
        initialize();     
    });
})();