(function(){
    angular.module('weddingManager')
    .service('companyService', function(companyFactory){
        var service = {};
        var _companies = [];
        
        service.refreshCompanies = function(onSuccess, onError){
            companyFactory.retrieveCompanies(function(companies){
                _companies = companies;
                onSuccess(_companies);
            }, onError);
        }
        
        service.getCompany = function(companyIdString){
            if(companyIdString == ""){
                return null;
            } else {
                var length = _companies.length;
                for(var companyIndex = 0; companyIndex < length; companyIndex++){
                    var company = _companies[companyIndex];
                    if(company.Id == companyIdString){
                        return company;
                    }
                }
            }
        }
        
        return service;
    });
})();