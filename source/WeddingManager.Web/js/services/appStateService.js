(function(){
    angular.module('weddingManager')
    .service('appStateService', function($location){
        var service = {};
        var _company = null;
        var _customer = null;
        var _expense = null;
        var _service = null;
        var _invoice = null;
        var _payment = null;
        
        function copy(target){
            return JSON.parse(JSON.stringify(target));
        }
        
        function getDate(date){
            return date ? new Date(date) : null;
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
            var output = copy(_expense);
            output.CreatedDate = getDate(output.CreatedDate);
            return output;
        }
        
        service.setExpense = function(expense){
            _expense = copy(expense);
        }        
        
        service.getService = function(){
            if(!_service){
                $location.path('error');
            }
            var output = copy(_service);
            output.StartTime = getDate(output.StartTime);
            output.EndTime = getDate(output.EndTime);
            return output;
        }   
        
        service.setService = function(service){
            _service = copy(service);
        }        
        
        service.getInvoice = function(){
            if(!_invoice){
                $location.path('error');
            }
            var output = copy(_invoice);
            output.CreatedDate = getDate(output.CreatedDate);
            output.DueDate = getDate(output.DueDate);
            return output;
        }   
        
        service.setInvoice = function(invoice){
            _invoice = copy(invoice);
        }        
        
        service.getPayment = function(){
            if(!_payment){
                $location.path('error');
            }
            var output = copy(_payment);
            output.DateReceived = getDate(output.DateReceived);
            return output;
        }   
        
        service.setPayment = function(payment){
            _payment = copy(payment);
        }
        
        return service;
    });
})();