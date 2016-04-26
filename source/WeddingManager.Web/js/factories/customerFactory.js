(function(){
    angular.module('weddingManager')
    .factory('customerFactory', function($http){
       var urlBase = 'http://localhost:81/api/customers';
       var factory = {};
       factory.createCustomer = function(companyId, customer, onSuccess, onError){
           $http({
               method : 'POST',
               url : [urlBase, companyId].join('/'),
               data : JSON.stringify(customer)
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }
       factory.retrieveCustomers = function(companyId, onSuccess, onError){
           $http({
               method : 'GET',
               url : [urlBase, companyId].join('/')
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }    
       factory.updateCustomer = function(customer, onSuccess, onError){
           $http({
               method : 'PUT',
               url : urlBase,
               data : JSON.stringify(customer)
           }).then(onSuccess, onError);
       }      
       factory.deleteCustomer = function(customerId, onSuccess, onError){
           $http({
               method : 'DELETE',
               url : [urlBase, customerId].join('/')
           }).then(onSuccess, onError);
       }    
       factory.retrieveSummary = function(companyId, onSuccess, onError){
           $http({
               method : 'GET',
               url : [urlBase, 'summary', companyId].join('/')
           }).then(function(response){
               onSuccess(response.data);
           }, onError);           
       }
       return factory; 
    });
})();