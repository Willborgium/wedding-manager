(function(){
    angular.module('weddingManager')
    .service('loginService', function(appStateService){
        var service = {};
        
        service.login = function(credentials, onSuccess, onError){
            if(credentials &&
               credentials.username && credentials.username.length > 0 &&
               credentials.password && credentials.password.length > 0 &&
               credentials.company && credentials.company.Id > 0){
                   appStateService.setCompany(credentials.company);
                   onSuccess(1234);
               }else{
                   onError();
               }
        }
        
        service.logOut = function(onComplete){
            onComplete();
        }
        
        return service;        
    })
})();