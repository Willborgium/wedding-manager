(function(){
    angular.module('weddingManager')
    .controller('customerController', function($scope, $location, appStateService, customerService, serviceService, customerInteractionService){
        $scope.customer = null;
        $scope.serviceFilter = "";
        $scope.services = [];
        $scope.customerInteractions = [];
        $scope.customerInteractionTypes = [];
        $scope.interactionFilter = "";
        $scope.isSaveDisabled = true;
        
        function initialize(){
            $scope.customer = appStateService.getCustomer();
            serviceService.refreshServices($scope.customer.Id, function(services){
                $scope.services = services;
            }, function(){
               $location.path('error'); 
            });
            customerInteractionService.refreshCustomerInteractions($scope.customer.Id, function(customerInteractions){
                $scope.customerInteractions = customerInteractions;
            }, function(){
                $location.path('error');
            });
            customerInteractionService.getCustomerInteractionTypes(function(customerInteractionTypes){
                $scope.customerInteractionTypes = customerInteractionTypes;
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
        
        function goBack(){
            var previousRoute = appStateService.popHistory();
            $location.path(previousRoute);
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
                    goBack();
                }, function(){
                    $location.path('error');
                });
            })
            .modal('hide');
        }
        
        $scope.viewService = function(service){
            appStateService.setService(service);
            appStateService.pushHistory('customer');
            $location.path('service');
        }
        
        $scope.createService = function(){
            serviceService.createService($scope.customer.Id, function(service){
                $scope.viewService(service);                                
            });
        }
        
        $scope.viewCustomerInteraction = function(customerInteraction){
            appStateService.setCustomerInteraction(customerInteraction);
            appStateService.pushHistory('customer');
            $location.path('customerInteraction');
        }
        
        $scope.createInteraction = function(){
            customerInteractionService.createCustomerInteraction($scope.customer.Id, function(customerInteraction){
               $scope.viewCustomerInteraction(customerInteraction); 
            });
        }
        
        $scope.return = function(){
            appStateService.setCustomer(null);
            goBack();       
        }
        
        initialize();     
    });
})();