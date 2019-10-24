(function (app) {
    app.controller('dashboardCtrl', function dashboardCtrl(authenticationService, $location ) {
        authenticationService.isAuthenticated().then(function (user) {
            if (!user) {
                $location.path('/login')
            }
        });
       
    });
})(angular.module('app'));