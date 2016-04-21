(function(){
    angular.module('weddingManager')
    .service('loginService', function(){
        var service = {};
        
        service.login = function(credentials, onSuccess, onError){
            if(credentials &&
               credentials.username && credentials.username.length > 0 &&
               credentials.password && credentials.password.length > 0 &&
               credentials.companyId && credentials.companyId > 0){
                   onSuccess(1234);
               }else{
                   onError();
               }
        }
        
        return service;        
    })
})();