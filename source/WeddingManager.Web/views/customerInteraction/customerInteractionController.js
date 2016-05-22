(function(){
    angular.module('weddingManager')
    .controller('customerInteractionController', function($scope, $location, appStateService, customerInteractionService){
        $scope.customerInteraction = null;
        $scope.interactionTypes = [];
        $scope.isSaveDisabled = true;
        
        function initialize(){
            $scope.customerInteraction = appStateService.getCustomerInteraction();
            customerInteractionService.getCustomerInteractionTypes(function(interactionTypes){
                for(var interactionType in interactionTypes){
                    $scope.interactionTypes.push({
                        key : parseInt(interactionType),
                        value : interactionTypes[interactionType]
                    });
                }                
            }, function(){
                $location.path('error');
            })
        }
        
        function isDirty(){
            var customerInteractionChanges = JSON.stringify($scope.customerInteraction);
            var customerInteraction = appStateService.getCustomerInteraction();
            var customerInteractionString = JSON.stringify(customerInteraction);
            return customerInteractionString != customerInteractionChanges;
        }
        
        function goBack(){
            var previousRoute = appStateService.popHistory();
            $location.path(previousRoute);
        }
        
        $scope.onFieldChanged = function(){
            $scope.isSaveDisabled = !isDirty();
        }
        
        $scope.clearChanges = function(){
            $scope.customerInteraction = appStateService.getCustomerInteraction();
        }
        
        $scope.updateCustomerInteraction = function(){
            customerInteractionService.updateCustomerInteraction($scope.customerInteraction, function(){
                appStateService.setCustomerInteraction($scope.customerInteraction);
                $scope.onFieldChanged();
            }, function(){
               $location.path('error'); 
            });
        }
        
        $scope.deleteCustomerInteraction = function(){
            $('#myModal')
            .on('hidden.bs.modal', function(){
                customerInteractionService.deleteCustomerInteraction($scope.customerInteraction.Id, function(){
                    goBack();
                }, function(){
                    $location.path('error');
                });
            })
            .modal('hide');
        }
        
        $scope.getInteractionType = function(interactionTypeId){
            var length = $scope.interactionTypes.length;
            for(var index = 0; index < length; index++){
                var interactionType = $scope.interactionTypes[index];
                if(interactionType.key == interactionTypeId){
                    return interactionType.value;
                }
            }
            return null;
        }
        
        $scope.return = function(){
            appStateService.setCustomerInteraction(null);
            goBack();
        }
        
        initialize();     
    });
})();