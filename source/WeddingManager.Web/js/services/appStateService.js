(function(){
    angular.module('weddingManager')
    .service('appStateService', function($location){
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
            if(!_company){
                $location.path('error');
            }
            return copy(_company);
        }
        
        service.setCompany = function(company){
            _company = copy(company);
        }
        
        service.getCustomer = function(){
            if(!_customer){
                $location.path('error');
            }
            return copy(_customer);            
        }
        
        service.setCustomer = function(customer){
            _customer = copy(customer);
        }     
        
        service.getExpense = function(){
            if(!_expense){
                $location.path('error');
            }
            return copy(_expense);
        }
        
        service.setExpense = function(expense){
            _expense = copy(expense);
        }        
        
        service.getService = function(){
            if(!_service){
                $location.path('error');
            }
            var output = copy(_service);
            output.StartTime = new Date(output.StartTime);
            if(output.EndTime){
                output.EndTime = new Date(output.EndTime);
            } else {
                output.EndTime = null;
            }
            return output;
        }   
        
        service.setService = function(service){
            _service = copy(service);
        }
        
        return service;
    });
})();