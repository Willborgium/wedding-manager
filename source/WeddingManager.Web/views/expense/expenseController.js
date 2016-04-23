(function(){
    angular.module('weddingManager')
    .controller('expenseController', function($scope, $location, appStateService, expenseService){
        $scope.expense = null;
        $scope.isSaveDisabled = true;
        
        function initialize(){
            $scope.expense = appStateService.getExpense();
        }
        
        function isDirty(){
            var expenseChanges = JSON.stringify($scope.expense);
            var expense = appStateService.getExpense();
            var expenseString = JSON.stringify(expense);
            return expenseString != expenseChanges;
        }
        
        $scope.onFieldChanged = function(){
            $scope.isSaveDisabled = !isDirty();
        }
        
        $scope.clearChanges = function(){
            $scope.expense = appStateService.getExpense();
        }
        
        $scope.updateExpense = function(){
            expenseService.updateExpense($scope.expense, function(){
                appStateService.setExpense($scope.expense);
                $scope.onFieldChanged();               
            }, function(){
               $location.path('error'); 
            });
        }
        
        $scope.deleteExpense = function(){
            expenseService.deleteExpense($scope.expense.Id, function(){
                $location.path('home');
            }, function(){
                $location.path('error');
            });
        }
        
        $scope.return = function(){
            appStateService.setExpense(null);
            $location.path('home');
        }
        
        initialize();     
    });
})();