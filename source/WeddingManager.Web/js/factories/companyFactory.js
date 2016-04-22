(function(){
    angular.module('weddingManager')
    .factory('companyFactory', function($http){
       var urlBase = 'http://localhost:81/api/companies';
       var factory = {};
       factory.retrieveCompanies = function(onSuccess, onError){
           $http({
               method : 'GET',
               url : urlBase
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }       
       return factory; 
    });
})();