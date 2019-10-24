(function (app) {
    'use strict';
    app.service('loginService', ['$http', '$q', 'authenticationService', 'authData','apiService',
    function ($http, $q, authenticationService, authData,apiService) {
        var userInfo;
        var deferred;

        this.login = function (userName, password) {
            deferred = $q.defer();
            var data = "grant_type=password&username=" + userName + "&password=" + password;
            $http.post('/oauth/token', data, { //a ơi a đi ngủ đi mai k đi chơi nữa học thôi hị hị e tắt nhá. đợi tía
                headers:
                   { 'Content-Type': 'application/x-www-form-urlencoded' }
            }).then(function (response) {
                userInfo = {
                    accessToken: response.data.access_token,
                    userName: userName,
                    fullName: response.data.fullName,
                    avatar: response.data.avatar,
                    email: response.data.email,
                    address: response.data.streetAddress,
                    roles: JSON.parse(response.data.roles),
                    groups: JSON.parse(response.data.groups)
                };
                authenticationService.setTokenInfo(userInfo);
                deferred.resolve(null);
            }, function (err, status) {
                authData.authenticationData.IsAuthenticated = false;
                authData.authenticationData.userName = "";
                deferred.resolve(err);
            })
            return deferred.promise;
        }

        this.logOut = function () {          
            authenticationService.removeToken();     
        }
    }]);
})(angular.module('app'));