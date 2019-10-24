(function () {
    'use strict';

    angular
        .module('home')
        .controller('historyCtrl', historyCtrl);

    historyCtrl.$inject = ['$location'];

    function historyCtrl($location) {
        /* jshint validthis:true */
        var vm = this;
        vm.title = 'historyCtrl';

        activate();

        function activate() { }
    }
})(angular.module('home'));
