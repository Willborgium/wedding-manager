(function(){
    angular.module('weddingManager')
    .factory('customerInteractionFactory', function($http){
       var urlBase = 'http://localhost:81/api/customerInteractions';
       var factory = {};
       factory.createCustomerInteraction = function(customerId, customerInteraction, onSuccess, onError){
           $http({
               method : 'POST',
               url : [urlBase, customerId].join('/'),
               data : JSON.stringify(customerInteraction)
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }
       factory.retrieveCustomerInteractions = function(customerId, onSuccess, onError){
           $http({
               method : 'GET',
               url : [urlBase, customerId].join('/')
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }    
       factory.updateCustomerInteraction = function(customerInteraction, onSuccess, onError){
           $http({
               method : 'PUT',
               url : urlBase,
               data : JSON.stringify(customerInteraction)
           }).then(onSuccess, onError);
       }      
       factory.deleteCustomerInteraction = function(customerInteractionId, onSuccess, onError){
           $http({
               method : 'DELETE',
               url : [urlBase, customerInteractionId].join('/')
           }).then(onSuccess, onError);
       }      
       factory.retrieveCustomerInteractionTypes = function(onSuccess, onError){
           $http({
               method : 'GET',
               url : [urlBase, 'types'].join('/')
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }
       return factory; 
    });
})();