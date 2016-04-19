var app = angular.module('weddingManager');

app.controller('loginController', function($scope){
    $scope.isHidden = false;
    $scope.username = "";
    $scope.password = "";
    $scope.isSubmitDisabled = true;
    
    $scope.tryDisableSubmit = function(){
        $scope.isSubmitDisabled = $scope.username.length == 0 ||
                                  $scope.password.length == 0;
    }
    
    $scope.submitCredentials = function(){
        if($scope.username.length > 0 &&
           $scope.password.length > 0){
            $scope.isHidden = true;
        }
    }
});