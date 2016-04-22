(function(){
    angular.module('weddingManager')
    .service('customerService', function(customerFactory, appStateService){
        var service = {};
        var _customers = [];
        
        service.createCustomer = function(companyId, onSuccess, onError){
            var customer = {
                FirstName : "New",
                LastName : "Customer",
                PhoneNumber : ""
            };
            customerFactory.createCustomer(companyId, customer, function(customerId){
                customer.Id = customerId;
                onSuccess(customer);
            }, onError);
        }
                
        service.refreshCustomers = function(companyId, onSuccess, onError){
            customerFactory.retrieveCustomers(companyId, function(customers){
                _customers = customers;
                onSuccess(_customers);                
            }, onError);
        }
                
        service.updateCustomer = function(customer, onSuccess, onError){
            customerFactory.updateCustomer(customer, function(){
                onSuccess();
            }, onError);
        }
        
        service.deleteCustomer = function(customerId, onSuccess, onError){
            customerFactory.deleteCustomer(customerId, function(){
                appStateService.setCustomer(null);
                onSuccess();
            }, onError);
        }
        
        return service;
    });
})();