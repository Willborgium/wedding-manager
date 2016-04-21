(function(){
    angular.module('weddingManager')
    .service('companyService', function(companyFactory){
        var service = {};
        
        service.companies = [];
        
        service.refreshCompanies = function(onSuccess, onError){
            companyFactory.retrieveCompanies(function(companies){
                service.companies = companies;
                onSuccess(service.companies);
            }, onError);
        }
        
        service.getCompany = function(companyIdString){
            if(companyIdString == ""){
                return null;
            } else {
                var length = service.companies.length;
                for(var companyIndex = 0; companyIndex < length; companyIndex++){
                    var company = service.companies[companyIndex];
                    if(company.Id == companyIdString){
                        return company;
                    }
                }
            }            
        }
        
        return service;
    });
})();