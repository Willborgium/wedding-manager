(function(){
    angular.module('weddingManager')
    .factory('serviceFactory', function($http){
       var urlBase = 'http://localhost:81/api/services';
       var factory = {};
       factory.createService = function(customerId, service, onSuccess, onError){
           $http({
               method : 'POST',
               url : [urlBase, customerId].join('/'),
               data : JSON.stringify(service)
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }
       factory.retrieveServices = function(customerId, onSuccess, onError){
           $http({
               method : 'GET',
               url : [urlBase, customerId].join('/')
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }    
       factory.retrieveService = function(companyId, serviceId, onSuccess, onError){
           $http({
               method : 'GET',
               url : [urlBase, companyId, serviceId].join('/')
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }    
       factory.updateService = function(service, onSuccess, onError){
           $http({
               method : 'PUT',
               url : urlBase,
               data : JSON.stringify(service)
           }).then(onSuccess, onError);
       }
       factory.deleteService = function(serviceId, onSuccess, onError){
           $http({
               method : 'DELETE',
               url : [urlBase, serviceId].join('/'),
           }).then(onSuccess, onError);
       }
       return factory; 
    });
})();