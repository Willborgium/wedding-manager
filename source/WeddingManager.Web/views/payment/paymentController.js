(function(){
    angular.module('weddingManager')
    .controller('paymentController', function($scope, $location, appStateService, paymentService){
        $scope.payment = null;
        $scope.isSaveDisabled = true;
        $scope.methods = [
          {Id: 1, Name: 'Cash'},
          {Id: 2, Name: 'Check'}
        ];
        
        function initialize(){
            $scope.payment = appStateService.getPayment();
        }
        
        function isDirty(){
            var paymentChanges = JSON.stringify($scope.payment);
            var payment = appStateService.getPayment();
            var paymentString = JSON.stringify(payment);
            return paymentString != paymentChanges;
        }
        
        $scope.onFieldChanged = function(){
            $scope.isSaveDisabled = !isDirty();
        }
        
        $scope.clearChanges = function(){
            $scope.payment = appStateService.getPayment();
        }
        
        $scope.updatePayment = function(){
            paymentService.updatePayment($scope.payment, function(){
                appStateService.setPayment($scope.payment);
                $scope.onFieldChanged();               
            }, function(){
               $location.path('error'); 
            });
        }
        
        $scope.deletePayment = function(){
            paymentService.deletePayment($scope.payment.Id, function(){
                $location.path('service');
            }, function(){
                $location.path('error');
            });
        }
        
        $scope.return = function(){
            appStateService.setPayment(null);
            $location.path('service');
        }
        
        initialize();     
    });
})();