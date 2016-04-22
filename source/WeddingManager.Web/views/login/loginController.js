(function(){
    angular.module('weddingManager')
    .controller('loginController', function($scope, $location, loginService, companyService){
        $scope.username = "";
        $scope.password = "";
        $scope.companyId = "";
        $scope.company = null;
        $scope.companies = [];
        $scope.isSubmitDisabled = true;
        
        function initialize(){
            $scope.AppTitle = "Welcome!";
            companyService.refreshCompanies(function(companies){
                $scope.companies = companies;
            }, function(error){
                $location.path('/error');
            });
        }
        
        $scope.onLoginCredentialsChanged = function(){
            $scope.isSubmitDisabled = $scope.company == null ||
                                      $scope.username.length == 0 ||
                                      $scope.password.length == 0;
        }
        
        $scope.submitCredentials = function(){
            if($scope.company != null &&
               $scope.username.length > 0 &&
               $scope.password.length > 0){
                   loginService.login({
                       username : $scope.username,
                       password : $scope.password,
                       company : $scope.company
                   }, function(userId){
                       $location.path('/home');                       
                   });
            }
        }
        
        $scope.onCompanyChanged = function(){
            $scope.company = companyService.getCompany($scope.companyId);
            $scope.onLoginCredentialsChanged();
        }
        
        initialize();
    });
})();