(function(){
    angular.module('weddingManager')
    .service('serviceService', function(serviceFactory, appStateService){
        var output = {};
        var _services = [];
        
        output.createService = function(customerId, onSuccess, onError){
            var service = {
                Description : "New service",
            };
            serviceFactory.createService(customerId, service, function(serviceId){
                service.Id = serviceId;
                onSuccess(service);
            }, onError);
        }
        
        output.refreshServices = function(customerId, onSuccess, onError){
            serviceFactory.retrieveServices(customerId, function(services){
                _services = services;
                onSuccess(_services);
            }, onError);
        }
        
        output.updateService = function(service, onSuccess, onError){
            serviceFactory.updateService(service, function(){
                onSuccess();
            }, onError);
        }
        
        output.deleteService = function(serviceId, onSuccess, onError){
            serviceFactory.deleteService(serviceId, function(){
                appStateService.setService(null);
                onSuccess();
            }, onError);
        }
        
        return output;
    });
})();