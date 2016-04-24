(function(){
    angular.module('weddingManager')
    .controller('serviceController', function($scope, $location, appStateService, serviceService, invoiceService){
        $scope.service = null;
        $scope.invoiceFilter = "";
        $scope.invoices = [];
        $scope.isSaveDisabled = true;
        
        function initialize(){
            $scope.service = appStateService.getService();
            invoiceService.refreshInvoices($scope.service.Id, function(invoices){
                $scope.invoices = invoices;
            }, function(){
                $location.path('error');
            });
        }
        
        function isDirty(){
            var serviceChanges = JSON.stringify($scope.service);
            var service = appStateService.getService();
            var serviceString = JSON.stringify(service);
            return serviceString != serviceChanges;
        }
        
        $scope.onFieldChanged = function(){
            $scope.isSaveDisabled = !isDirty();
        }
        
        $scope.clearChanges = function(){
            $scope.service = appStateService.getService();
        }
        
        $scope.updateService = function(){
            serviceService.updateService($scope.service, function(){
                appStateService.setService($scope.service);
                $scope.onFieldChanged();               
            }, function(){
               $location.path('error'); 
            });
        }
        
        $scope.deleteService = function(){
            serviceService.deleteService($scope.service.Id, function(){
                $location.path('customer');
            }, function(){
                $location.path('error');
            });
        }
        
        $scope.return = function(){
            appStateService.setService(null);
            $location.path('customer');
        }
        
        $scope.viewInvoice = function(invoice){
            appStateService.setInvoice(invoice);
            $location.path('invoice');
        }
        
        $scope.createInvoice = function(){
            invoiceService.createInvoice($scope.service.Id, function(invoice){
               appStateService.setInvoice(invoice);
               $location.path('invoice'); 
            });
        }
        
        initialize();     
    });
})();