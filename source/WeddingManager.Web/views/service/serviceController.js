(function(){
    angular.module('weddingManager')
    .controller('serviceController', function($scope, $location, appStateService, serviceService, invoiceService, paymentService, serviceDetailService){
        $scope.service = null;
        $scope.invoiceFilter = "";
        $scope.paymentFilter = "";
        $scope.invoices = [];
        $scope.payments = [];
        $scope.serviceDetails = [];
        $scope.isSaveDisabled = true;
        
        $scope.isServiceDetailSaveDisabled = {};
        
        function initialize(){
            $scope.service = appStateService.getService();
            initializeInvoices();
            initializePayments();
            initializeServiceDetails();
        }
        
        function initializeInvoices(){
            invoiceService.refreshInvoices($scope.service.Id, function(invoices){
                $scope.invoices = invoices;
            }, function(){
                $location.path('error');
            });            
        }
        
        function initializePayments(){
            paymentService.refreshPayments($scope.service.Id, function(payments){
                $scope.payments = payments;
            }, function(){
               $location.path('error'); 
            });            
        }
        
        function initializeServiceDetails(){
            serviceDetailService.refreshServiceDetails($scope.service.Id, function(serviceDetails){
                $scope.isServiceDetailSaveDisabled = {};
                $scope.isEditingServiceDetailDetails = {};
                var length = serviceDetails.length;
                for(var index = 0; index < length; index++){
                    var serviceDetail = serviceDetails[index];
                    $scope.isServiceDetailSaveDisabled[serviceDetail.Id] = true;
                }
                $scope.serviceDetails = serviceDetails;
                appStateService.setServiceDetails(serviceDetails);
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
        
        function getServiceDetail(serviceDetailId){
            var length = $scope.serviceDetails.length;
            for(var index = 0; index < length; index++){
                var serviceDetail = $scope.serviceDetails[index];
                if(serviceDetail.Id == serviceDetailId){
                    return serviceDetail;
                }
            }
            return null;
        } 
        
        function isServiceDetailDirty(serviceDetailId){
            var changedServiceDetail = getServiceDetail(serviceDetailId);            
            var serviceDetailChanges = JSON.stringify(changedServiceDetail);
            var serviceDetail = appStateService.getServiceDetail(serviceDetailId);
            serviceDetail.$$hashKey = changedServiceDetail.$$hashKey;
            var serviceDetailString = JSON.stringify(serviceDetail);
            return serviceDetailString != serviceDetailChanges;
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
            var previousRoute = appStateService.popHistory();
            $location.path(previousRoute);
        }
        
        $scope.createInvoice = function(){
            invoiceService.createInvoice($scope.service.Id, function(invoice){
               appStateService.setInvoice(invoice);
               appStateService.pushHistory('service');
               $location.path('invoice'); 
            });
        }
        
        $scope.viewPayment = function(payment){
            appStateService.setPayment(payment);
            appStateService.pushHistory('service');
            $location.path('payment');
        }
        
        $scope.createPayment = function(){
            paymentService.createPayment($scope.service.Id, function(payment){
               appStateService.pushHistory('service');
               $scope.viewPayment(payment); 
            });
        }
        
        $scope.viewInvoice = function(invoice){
            appStateService.setInvoice(invoice);
            appStateService.pushHistory('service');
            $location.path('invoice');
        }
        
        $scope.onServiceDetailFieldChanged = function(serviceDetailId){
            $scope.isServiceDetailSaveDisabled[serviceDetailId] = !isServiceDetailDirty(serviceDetailId);
        }
        
        $scope.deleteServiceDetail = function(serviceDetailId){
            serviceDetailService.deleteServiceDetail(serviceDetailId, function(){
                initializeServiceDetails();
            }, function(){
                $location.path('error');
            });
        }
        
        $scope.updateServiceDetail = function(serviceDetailId){
            var serviceDetail = getServiceDetail(serviceDetailId);
            serviceDetailService.updateServiceDetail(serviceDetail, function(){
                initializeServiceDetails();               
            }, function(){
                $location.path('error');
            })
        }
        
        $scope.createServiceDetail = function(){
            serviceDetailService.createServiceDetail($scope.service.Id, function(serviceDetail){
                initializeServiceDetails(); 
            });
        }
        
        initialize();     
    });
})();