(function(){
    angular.module('weddingManager')
    .service('summaryService', function(summaryFactory){
        var service = {};
        var _companySummary = null;
        
        service.refreshCompanySummary = function(companyId, onSuccess, onError){
            summaryFactory.retrieveCompanySummary(companyId, function(companySummary){
                _companySummary = companySummary;
                onSuccess(_companySummary);
            }, onError);
        }
        
        return service;
    });
})();