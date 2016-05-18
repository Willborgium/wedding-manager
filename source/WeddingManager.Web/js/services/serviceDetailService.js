(function(){
    angular.module('weddingManager')
    .service('serviceDetailService', function(serviceDetailFactory){
        var output = {};
        var _serviceDetails = [];
        
        output.createServiceDetail = function(serviceId, onSuccess, onError){
            var serviceDetail = {
                Details : "New service detail",
                Location : "",
                StartTime : new Date()
            };
            serviceDetailFactory.createServiceDetail(serviceId, serviceDetail, function(serviceDetailId){
                serviceDetail.Id = serviceDetailId;
                onSuccess(serviceDetail);
            }, onError);
        }
        
        output.refreshServiceDetails = function(serviceId, onSuccess, onError){
            serviceDetailFactory.retrieveServiceDetails(serviceId, function(serviceDetails){
                var serviceDetailCount = serviceDetails.length;
                for(var index = 0; index < serviceDetailCount; index++){
                    var serviceDetail = serviceDetails[index];
                    serviceDetail.StartTime = new Date(serviceDetail.StartTime);
                    if(serviceDetail.EndTime){
                        serviceDetail.EndTime = new Date(serviceDetail.EndTime);
                    }else{
                        serviceDetail.EndTime = null;
                    }
                }
                _serviceDetails = serviceDetails;
                onSuccess(_serviceDetails);
            }, onError);
        }
        
        output.updateServiceDetail = function(serviceDetail, onSuccess, onError){
            serviceDetailFactory.updateServiceDetail(serviceDetail, function(){
                onSuccess();
            }, onError);
        }
        
        output.deleteServiceDetail = function(serviceDetailId, onSuccess, onError){
            serviceDetailFactory.deleteServiceDetail(serviceDetailId, function(){
                onSuccess();
            }, onError);
        }
        
        output.search = function(companyId, searchCriteria, onSuccess, onError){
            serviceDetailFactory.search(companyId, searchCriteria, function(searchResults){
                onSuccess(searchResults);
            }, onError);
        }
        
        return output;
    });
})();