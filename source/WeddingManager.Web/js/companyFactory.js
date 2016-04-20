(function(){
    angular.module('weddingManager')
    .factory('companyFactory', ['$http', function($http){
       var urlBase = 'http://localhost:81/api/companies';
       var factory = {};
       factory.getCompanies = function(){
           return $http.get(urlBase);
       }       
       return factory; 
    }]);
})();