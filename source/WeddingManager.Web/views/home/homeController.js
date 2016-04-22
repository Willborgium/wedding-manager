(function(){
    angular.module('weddingManager')
    .controller('homeController', function($scope, $location, appStateService, customerService, expenseService){
        $scope.expenseFilter = "";
        $scope.customerFilter = "";
        $scope.customers = [];
        $scope.expenses = [];
        var _company = null;
        
        function initialize(){
            _company = appStateService.getCompany();
            if(!_company){
                $location.path('error');
            }
            $scope.$parent.AppTitle = _company.Name;
            customerService.refreshCustomers(_company.Id, function(customers){
                $scope.customers = customers;
            }, function(error){
                $location.path('error');
            });
            expenseService.refreshExpenses(_company.Id, function(expenses){
                $scope.expenses = expenses;
            }, function(error){
                $location.path('error');
            })
        }
        
        $scope.viewCustomer = function(customer){
            appStateService.setCustomer(customer);
            $location.path('customer');
        }
        
        $scope.viewExpense = function(expense){
            appStateService.setExpense(expense);
            $location.path('expense');
        }
        
        $scope.createExpense = function(){
            expenseService.createExpense(_company.Id, function(expense){
                $scope.viewExpense(expense);
            })
        }
        
        $scope.createCustomer = function(){
            customerService.createCustomer(_company.Id, function(customer){
                $scope.viewCustomer(customer);
            })
        }
        
        initialize();
    });
})();