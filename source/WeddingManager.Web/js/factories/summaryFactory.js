(function(){
    angular.module('weddingManager')
    .factory('summaryFactory', function($http){
       var urlBase = 'http://localhost:81/api/summaries';
       var factory = {};
       factory.retrieveCompanySummary = function(companyId, onSuccess, onError){
           $http({
               method : 'GET',
               url : [urlBase, 'company', companyId].join('/')
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }       
       return factory; 
    });
})();