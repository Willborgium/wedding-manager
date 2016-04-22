(function(){
    angular.module('weddingManager')
    .service('appStateService', function(){
        var service = {};
        var _company = null;
        var _customer = null;
        var _expense = null;
        var _service = null;
        
        function copy(target){
            return JSON.parse(JSON.stringify(target));
        }
        
        service.clearState = function(){
            _company = null;
            _customer = null;
        }
        
        service.getCompany = function(){
            return copy(_company);
        }
        
        service.setCompany = function(company){
            _company = copy(company);
        }
        
        service.getCustomer = function(){
            return copy(_customer);            
        }
        
        service.setCustomer = function(customer){
            _customer = copy(customer);
        }
        
        service.setExpense = function(expense){
            _expense = copy(expense);
        }        
        
        service.getExpense = function(){
            return copy(_expense);
        }
        
        service.setService = function(service){
            _service = copy(service);
        }        
        
        service.getService = function(){
            var output = copy(_service);
            output.StartTime = new Date(output.StartTime);
            if(output.EndTime){
                output.EndTime = new Date(output.EndTime);
            } else {
                output.EndTime = null;
            }
            return output;
        }
        
        return service;
    });
})();