(function (app) {
    'use strict';
    app.service('authenticationService', ['$http', '$q', '$window', 'localStorageService','authData',
        function ($http, $q, $window, localStorageService, authData) {
            this.isAuthenticated = function () {
                var deferred = $q.defer();
                let tokenInfo = JSON.parse(localStorageService.get("TokenInfo"));
                let user;
                if (tokenInfo) {
                    user = {
                        userName : tokenInfo.userName,
                        fullName : tokenInfo.fullName,
                        avatar : tokenInfo.avatar,
                        email : tokenInfo.email,
                        address : tokenInfo.address,
                        roles : tokenInfo.roles,
                        groups : tokenInfo.groups
                    }                   
                }             
                deferred.resolve(user);
                return deferred.promise;
            };

            var tokenInfo;
            this.setTokenInfo = function (data) {
                tokenInfo = data;
                localStorageService.set("TokenInfo", JSON.stringify(tokenInfo));                            
            }

            this.getTokenInfo = function () {
                return tokenInfo;
            }

            this.removeToken = function () {
                tokenInfo = null;
                localStorageService.set("TokenInfo", null);
            }
         
            this.setHeader = function () {
                delete $http.defaults.headers.common['X-Requested-With'];
                if ((authData.authenticationData != undefined) && (authData.authenticationData.accessToken != undefined) && (authData.authenticationData.accessToken != null) && (authData.authenticationData.accessToken != "")) {
                    $http.defaults.headers.common['Authorization'] = 'Bearer ' + authData.authenticationData.accessToken;
                    $http.defaults.headers.common['Content-Type'] = 'application/x-www-form-urlencoded;charset=utf-8';
                }
            }          
        }
    ]);
})(angular.module('app'));