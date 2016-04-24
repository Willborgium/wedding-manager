(function(){
    angular.module('weddingManager')
    .controller('invoiceController', function($scope, $location, appStateService, invoiceService){
        $scope.invoice = null;
        $scope.isSaveDisabled = true;
        
        function initialize(){
            $scope.invoice = appStateService.getInvoice();
        }
        
        function isDirty(){
            var invoiceChanges = JSON.stringify($scope.invoice);
            var invoice = appStateService.getInvoice();
            var invoiceString = JSON.stringify(invoice);
            return invoiceString != invoiceChanges;
        }
        
        $scope.onFieldChanged = function(){
            $scope.isSaveDisabled = !isDirty();
        }
        
        $scope.clearChanges = function(){
            $scope.invoice = appStateService.getInvoice();
        }
        
        $scope.updateInvoice = function(){
            invoiceService.updateInvoice($scope.invoice, function(){
                appStateService.setInvoice($scope.invoice);
                $scope.onFieldChanged();               
            }, function(){
               $location.path('error'); 
            });
        }
        
        $scope.deleteInvoice = function(){
            $('#myModal')
            .on('hidden.bs.modal', function(){
                invoiceService.deleteInvoice($scope.invoice.Id, function(){
                    $location.path('service');
                }, function(){
                    $location.path('error');
                });
            })
            .modal('hide');
        }
        
        $scope.return = function(){
            appStateService.setInvoice(null);
            $location.path('service');
        }
        
        initialize();     
    });
})();