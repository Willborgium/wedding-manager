(function(){
    angular.module('weddingManager')
    .factory('expenseFactory', function($http){
       var urlBase = 'http://localhost:81/api/expenses';
       var factory = {};
       factory.createExpense = function(companyId, expense, onSuccess, onError){
           $http({
               method : 'POST',
               url : [urlBase, companyId].join('/'),
               data : JSON.stringify(expense)
           }).then(function(response){
               onSuccess(response.data);
           }, onError);           
       }
       factory.retrieveExpenses = function(companyId, onSuccess, onError){
           $http({
               method : 'GET',
               url : [urlBase, companyId].join('/')
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }    
       factory.updateExpense = function(expense, onSuccess, onError){
           $http({
               method : 'PUT',
               url : urlBase,
               data : JSON.stringify(expense)
           }).then(onSuccess, onError);
       }
       factory.deleteExpense = function(expenseId, onSuccess, onError){
           $http({
               method : 'DELETE',
               url : [urlBase, expenseId].join('/'),
           }).then(onSuccess, onError);           
       }
       return factory; 
    });
})();