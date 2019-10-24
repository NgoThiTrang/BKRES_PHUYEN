(function () {
    angular.module('home',
        ['common'])
        .config(config)
      
    config.$inject = ['$stateProvider'];

    function config($stateProvider,  $ocLazyLoadProvider, IdleProvider, KeepaliveProvider, $locationProvider) { // a vẫn chưa hiểu e hỏi à, ở controller mình addview thì view đó sinh ra như mvs ấy ạ thì e nfhix là nó đi liền vs Ctrl rồi nên k đẫn cái lin =k template kìa 

       
        $stateProvider
          
            .state('device', {
                url: "/giam-sat-truc-tuyen",
                controller: "deviceCtrl",// thì e ngĩ là k cần cái template này vì view nó đi vs cái controller mình add add trong đây còn gì lamd gì còn chỗ nào add nữa
                templateUrl: "/home/views/deviceView.html", // để vầy n miowis ăn chứ view đây thôi dẫn url gì nữa
            })
            .state('params', {
                url: "/thong-so-quan-trac",
                templateUrl: "/home/views/paramView.html",
              
                controller: "paramCtrl"
            })
            .state('history', {
               
                url: "/lich-su-quan-trac",
                templateUrl: "/home/views/historyView.html",

                controller: "historyCtrl"
            })// ok hiểu 

          


    };
})();