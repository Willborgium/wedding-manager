(function(){
    angular.module('weddingManager')
    .controller('serviceDetailController', function($scope, $location, appStateService, serviceDetailService){
        $scope.serviceDetail = null;
        $scope.isSaveDisabled = true;
        $scope.test = "POO OO O P";
        
        function initialize(){
            console.dir($scope.serviceDetail);
        }
        
        function isDirty(){
            var serviceDetailChanges = JSON.stringify($scope.serviceDetail);
            var serviceDetail = appStateService.getServiceDetail();
            var serviceDetailString = JSON.stringify(serviceDetail);
            return serviceDetailString != serviceDetailChanges;
        }
        
        $scope.onFieldChanged = function(){
            $scope.isSaveDisabled = !isDirty();
        }
        
        initialize();     
    })
    .component('wmServiceDetail', {
        templateUrl : 'views/serviceDetail/serviceDetail.html',
        controller : angular.module('serviceDetailController'),
        bindings : {
            serviceDetail : '='
        }        
    });
})();