(function(){
    angular.module('weddingManager')
    .service('serviceService', function(serviceFactory, appStateService){
        var output = {};
        var _services = [];
        var _searchResults = [];
        
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
                onSuccess(services);
            }, onError);
        }
        
        output.getServices = function(){
            return _services;
        }
        
        output.retrieveService = function(companyId, serviceId, onSuccess, onError){
            serviceFactory.retrieveService(companyId, serviceId, onSuccess, onError);
        }
        
        output.updateService = function(service, onSuccess, onError){
            serviceFactory.updateService(service, onSuccess, onError);
        }
        
        output.deleteService = function(serviceId, onSuccess, onError){
            serviceFactory.deleteService(serviceId, function(){
                appStateService.setService(null);
                onSuccess();
            }, onError);
        }
        
        output.search = function(companyId, searchCriteria, onSuccess, onError){
            serviceFactory.search(companyId, searchCriteria, function(searchResults){
                _searchResults = searchResults;
                onSuccess(searchResults);
            }, onError);
        }
        
        output.getSearchResults = function(){
            return _searchResults;
        }
        
        return output;
    });
})();