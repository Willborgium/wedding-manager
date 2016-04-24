(function(){
    angular.module('weddingManager')
    .factory('paymentFactory', function($http){
       var urlBase = 'http://localhost:81/api/payments';
       var factory = {};
       factory.createPayment = function(serviceId, payment, onSuccess, onError){
           $http({
               method : 'POST',
               url : [urlBase, serviceId].join('/'),
               data : JSON.stringify(payment)
           }).then(function(response){
               onSuccess(response.data);
           }, onError);           
       }
       factory.retrievePayments = function(serviceId, onSuccess, onError){
           $http({
               method : 'GET',
               url : [urlBase, serviceId].join('/')
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }    
       factory.updatePayment = function(payment, onSuccess, onError){
           $http({
               method : 'PUT',
               url : urlBase,
               data : JSON.stringify(payment)
           }).then(onSuccess, onError);
       }
       factory.deletePayment = function(paymentId, onSuccess, onError){
           $http({
               method : 'DELETE',
               url : [urlBase, paymentId].join('/'),
           }).then(onSuccess, onError);           
       }
       return factory; 
    });
})();