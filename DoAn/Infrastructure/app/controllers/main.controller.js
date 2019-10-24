(function (app) {
    app.controller('mainCtrl', function mainCtrl($state, authData, loginService, $scope, authenticationService) {  
        $scope.logOut = function () {
            loginService.logOut();
            $state.go('login');
        }

        authenticationService.isAuthenticated().then(function (user) {
            if (!user) {
                $location.path('/login')
            }
            else {
                $scope.authentication = user
                $scope.authentication.avatar = user.avatar || '/Content/admin/img/images_none.png'
            }
        });    
    });
})(angular.module('app'));
