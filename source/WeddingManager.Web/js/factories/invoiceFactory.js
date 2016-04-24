(function(){
    angular.module('weddingManager')
    .factory('invoiceFactory', function($http){
       var urlBase = 'http://localhost:81/api/invoices';
       var factory = {};
       factory.createInvoice = function(serviceId, invoice, onSuccess, onError){
           $http({
               method : 'POST',
               url : [urlBase, serviceId].join('/'),
               data : JSON.stringify(invoice)
           }).then(function(response){
               onSuccess(response.data);
           }, onError);           
       }
       factory.retrieveInvoices = function(serviceId, onSuccess, onError){
           $http({
               method : 'GET',
               url : [urlBase, serviceId].join('/')
           }).then(function(response){
               onSuccess(response.data);
           }, onError);
       }    
       factory.updateInvoice = function(invoice, onSuccess, onError){
           $http({
               method : 'PUT',
               url : urlBase,
               data : JSON.stringify(invoice)
           }).then(onSuccess, onError);
       }
       factory.deleteInvoice = function(invoiceId, onSuccess, onError){
           $http({
               method : 'DELETE',
               url : [urlBase, invoiceId].join('/'),
           }).then(onSuccess, onError);           
       }
       return factory; 
    });
})();