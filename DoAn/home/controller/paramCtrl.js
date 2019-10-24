(function () {
    'use strict';

    angular
        .module('home')
        .controller('paramCtrl', paramCtrl);

    paramCtrl.$inject = ['$location'];

    function paramCtrl($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'paramCtrl';

        activate();

        function activate() { }
    }
})(angular.module('home'));
