(function(){
    angular.module('weddingManager')
    .controller('homeController', function($scope, $location, appStateService, customerService, expenseService, summaryService){
        $scope.company = null;
        $scope.expenseFilter = "";
        $scope.customerFilter = "";
        $scope.customers = [];
        $scope.expenses = [];
        $scope.companySummary = {};
        
        function initialize(){
            $scope.company = appStateService.getCompany();
            $scope.$parent.AppTitle = $scope.company.Name;
            customerService.refreshCustomers($scope.company.Id, function(customers){
                $scope.customers = customers;
            }, function(error){
                $location.path('error');
            });
            summaryService.refreshCompanySummary($scope.company.Id, function(companySummary){
                $scope.companySummary = companySummary;
            }, function(error){
                $location.path('error');
            });
            expenseService.refreshExpenses($scope.company.Id, function(expenses){
                $scope.expenses = expenses;
            }, function(error){
                $location.path('error');
            });
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
            expenseService.createExpense($scope.company.Id, function(expense){
                $scope.viewExpense(expense);
            })
        }
        
        $scope.createCustomer = function(){
            customerService.createCustomer($scope.company.Id, function(customer){
                $scope.viewCustomer(customer);
            })
        }
        
        initialize();
    });
})();