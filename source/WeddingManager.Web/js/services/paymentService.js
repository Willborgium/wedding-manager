(function(){
    angular.module('weddingManager')
    .service('paymentService', function(paymentFactory, appStateService){
        var service = {};
        var _payments = [];
        
        service.createPayment = function(serviceId, onSuccess, onError){
            var payment = {
                Method : 1,
                Notes : "New payment",
                DateReceived : new Date()
            };
            paymentFactory.createPayment(serviceId, payment, function(paymentId){
                payment.Id = paymentId;
                onSuccess(payment);
            }, onError);
        }
        
        service.refreshPayments = function(serviceId, onSuccess, onError){
            paymentFactory.retrievePayments(serviceId, function(payments){
                _payments = payments;
                onSuccess(_payments);
            }, onError);
        }
        
        service.updatePayment = function(payment, onSuccess, onError){
            paymentFactory.updatePayment(payment, function(){
                onSuccess();
            }, onError);
        }
        
        service.deletePayment = function(paymentId, onSuccess, onError){
            paymentFactory.deletePayment(paymentId, function(){
                appStateService.setPayment(null);
                onSuccess();
            }, onError);
        }
        
        return service;
    });
})();