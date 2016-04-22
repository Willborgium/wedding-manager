(function(){
    angular.module('weddingManager')
    .service('expenseService', function(expenseFactory, appStateService){
        var service = {};
        var _expenses = [];
        
        service.createExpense = function(companyId, onSuccess, onError){
            var expense = {
                CreatedDate : new Date(),
                Description : "New Expense"
            };
            expenseFactory.createExpense(companyId, expense, function(expenseId){
                expense.Id = expenseId;
                onSuccess(expense);
            }, onError);
        }
        
        service.refreshExpenses = function(companyId, onSuccess, onError){
            expenseFactory.retrieveExpenses(companyId, function(expenses){
                _expenses = expenses;
                onSuccess(_expenses);
            }, onError);
        }
        
        service.updateExpense = function(expense, onSuccess, onError){
            expenseFactory.updateExpense(expense, function(){
                onSuccess();
            }, onError);
        }
        
        service.deleteExpense = function(expenseId, onSuccess, onError){
            expenseFactory.deleteExpense(expenseId, function(){
                appStateService.setExpense(null);
                onSuccess();
            }, onError);
        }
        
        return service;
    });
})();