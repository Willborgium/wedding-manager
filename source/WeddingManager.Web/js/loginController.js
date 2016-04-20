(function(){
    angular.module('weddingManager')
    .controller('loginController', function($scope, companyFactory){
        $scope.isHidden = false;
        $scope.username = "";
        $scope.password = "";
        $scope.companyId = "";
        $scope.company = null;
        $scope.companies = [];
        $scope.isSubmitDisabled = true;
        
        function initialize(){
            companyFactory.getCompanies()
            .then(function(response){
                $scope.companies = response.data;
            }, function(error){
                // goto error
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
               $scope.isHidden = true;
            }
        }
        
        $scope.onCompanyChanged = function(){
            if($scope.companyId == ""){
                $scope.company = null;
            } else {
                var length = $scope.companies.length;
                for(var companyIndex = 0; companyIndex < length; companyIndex++){
                    var company = $scope.companies[companyIndex];
                    if(company.Id == $scope.companyId){
                        $scope.company = company;
                        break; 
                    }
                }
            }
            $scope.onLoginCredentialsChanged();
        }
        
        initialize();
    });
})();