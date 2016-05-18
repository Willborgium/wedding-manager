(function(){
	angular.module('weddingManager', ['ngRoute'])
	.config(function($routeProvider){
	   $routeProvider
	   .when('/error', {
		   templateUrl : 'views/error/error.html'
	   })
	   .when('/', {
	       templateUrl : 'views/login/login.html',
	       controller : 'loginController'
	   })
	   .when('/home', {
	       templateUrl : 'views/home/home.html',
	       controller : 'homeController'
	   })
	   .when('/customer', {
	       templateUrl : 'views/customer/customer.html',
	       controller : 'customerController'
	   })
	   .when('/expense', {
	       templateUrl : 'views/expense/expense.html',
	       controller : 'expenseController'
	   })
	   .when('/service', {
	       templateUrl : 'views/service/service.html',
	       controller : 'serviceController'
	   })
	   .when('/invoice', {
	       templateUrl : 'views/invoice/invoice.html',
	       controller : 'invoiceController'
	   })
	   .when('/payment', {
	       templateUrl : 'views/payment/payment.html',
	       controller : 'paymentController'
	   })
	   .when('/search', {
		   templateUrl : 'views/search/search.html',
		   controller : 'searchController'
	   })
	   .otherwise({
		   redirectTo : '/error'
	   });
	});
})();