(function(){
    angular.module('weddingManager')
    .controller('serviceController', function($scope, $location, appStateService, serviceService, invoiceService, paymentService){
        $scope.service = null;
        $scope.invoiceFilter = "";
        $scope.paymentFilter = "";
        $scope.invoices = [];
        $scope.payments = [];
        $scope.isSaveDisabled = true;
        
        function initialize(){
            $scope.service = appStateService.getService();
            invoiceService.refreshInvoices($scope.service.Id, function(invoices){
                $scope.invoices = invoices;
            }, function(){
                $location.path('error');
            });
            paymentService.refreshPayments($scope.service.Id, function(payments){
                $scope.payments = payments;
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
            $('#myModal')
            .on('hidden.bs.modal', function(){
                serviceService.deleteService($scope.service.Id, function(){
                    $location.path('customer');
                }, function(){
                    $location.path('error');
                });
            })
            .modal('hide');
        }
        
        $scope.return = function(){
            appStateService.setService(null);
            $location.path('customer');
        }
        
        $scope.createInvoice = function(){
            invoiceService.createInvoice($scope.service.Id, function(invoice){
               appStateService.setInvoice(invoice);
               $location.path('invoice'); 
            });
        }
        
        $scope.viewPayment = function(payment){
            appStateService.setPayment(payment);
            $location.path('payment');
        }
        
        $scope.createPayment = function(){
            paymentService.createPayment($scope.service.Id, function(payment){
               $scope.viewPayment(payment); 
            });
        }
        
        $scope.viewInvoice = function(invoice){
            appStateService.setInvoice(invoice);
            $location.path('invoice');
        }
        
        initialize();     
    });
})();