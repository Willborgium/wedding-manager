(function(){
    angular.module('weddingManager')
    .factory('companyFactory', function($http){
       var urlBase = 'http://localhost:81/api/companies';
       var factory = {};
       factory.retrieveCompanies = function(onSuccess, onError){
           $http.get(urlBase)
           .then(function(response){
               onSuccess(response.data);
           }, onError);
       }       
       return factory; 
    });
})();