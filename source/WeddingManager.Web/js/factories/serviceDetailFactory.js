(function(){
    angular.module('weddingManager')
    .factory('serviceDetailFactory', function($http){
       var urlBase = 'http://localhost:81/api/serviceDetails';
       var factory = {};
       factory.createServiceDetail = function(serviceId, serviceDetail, onSuccess, onError){
           $http({
               method : 'POST',
               url : [urlBase, serviceId].join('/'),
               data : JSON.stringify(serviceDetail)
           }).then(function(response){
               onSuccess(response.data);
           }, onError);           
       }
       factory.retrieveServiceDetails = function(serviceId, onSuccess, onError){
           $http({
               method : 'GET',
               url : [urlBase, serviceId].join('/')
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }    
       factory.updateServiceDetail = function(serviceDetail, onSuccess, onError){
           $http({
               method : 'PUT',
               url : urlBase,
               data : JSON.stringify(serviceDetail)
           }).then(onSuccess, onError);
       }
       factory.deleteServiceDetail = function(serviceDetailId, onSuccess, onError){
           $http({
               method : 'DELETE',
               url : [urlBase, serviceDetailId].join('/'),
           }).then(onSuccess, onError);           
       }
       factory.search = function(companyId, searchCriteria, onSuccess, onError){
           $http({
               method : 'POST',
               url : [urlBase, 'search', companyId].join('/'),
               data : JSON.stringify(searchCriteria)
           }).then(function(response){
               onSuccess(response.data);
           }, onError);           
       }
       return factory; 
    });
})();