(function(){
    angular.module('weddingManager')
    .service('customerInteractionService', function(customerInteractionFactory, appStateService){
        var service = {};
        var _customerInteractions = [];
        var _customerInteractionTypes = [];
        
        service.createCustomerInteraction = function(customerId, onSuccess, onError){
            var customerInteraction = {
                Date : new Date(),
                InteractionType : 1,
                Notes : ""
            };
            customerInteractionFactory.createCustomerInteraction(customerId, customerInteraction, function(customerInteractionId){
                customerInteraction.Id = customerInteractionId;
                onSuccess(customerInteraction);
            }, onError);
        }
                
        service.refreshCustomerInteractions = function(customerId, onSuccess, onError){
            customerInteractionFactory.retrieveCustomerInteractions(customerId, function(customerInteractions){
                _customerInteractions = customerInteractions;
                onSuccess(_customerInteractions);                
            }, onError);
        }
                
        service.updateCustomerInteraction = function(customerInteraction, onSuccess, onError){
            customerInteractionFactory.updateCustomerInteraction(customerInteraction, function(){
                onSuccess();
            }, onError);
        }
        
        service.deleteCustomerInteraction = function(customerInteractionId, onSuccess, onError){
            customerInteractionFactory.deleteCustomerInteraction(customerInteractionId, function(){
                appStateService.setCustomerInteraction(null);
                onSuccess();
            }, onError);
        }
        
        service.getCustomerInteractionTypes = function(onSuccess, onError){
            if(_customerInteractionTypes.length == 0){
                customerInteractionFactory.retrieveCustomerInteractionTypes(function(customerInteractionTypes){
                    _customerInteractionTypes = customerInteractionTypes;
                    onSuccess(_customerInteractionTypes);                
                }, onError);
            } else {
                onSuccess(_customerInteractionTypes);
            }
        }
        
        return service;
    });
})();