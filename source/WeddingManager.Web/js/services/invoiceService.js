(function(){
    angular.module('weddingManager')
    .service('invoiceService', function(invoiceFactory, appStateService){
        var service = {};
        var _invoices = [];
        
        service.createInvoice = function(serviceId, onSuccess, onError){
            var invoice = {
                CreatedDate : new Date(),
                DueDate : new Date(),
                Description : "New invoice"
            };
            invoiceFactory.createInvoice(serviceId, invoice, function(invoiceId){
                invoice.Id = invoiceId;
                onSuccess(invoice);
            }, onError);
        }
        
        service.refreshInvoices = function(serviceId, onSuccess, onError){
            invoiceFactory.retrieveInvoices(serviceId, function(invoices){
                _invoices = invoices;
                onSuccess(_invoices);
            }, onError);
        }
        
        service.updateInvoice = function(invoice, onSuccess, onError){
            invoiceFactory.updateInvoice(invoice, function(){
                onSuccess();
            }, onError);
        }
        
        service.deleteInvoice = function(invoiceId, onSuccess, onError){
            invoiceFactory.deleteInvoice(invoiceId, function(){
                appStateService.setInvoice(null);
                onSuccess();
            }, onError);
        }
        
        return service;
    });
})();