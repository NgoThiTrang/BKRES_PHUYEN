(function (home) {
    home.controller('deviceCtrl', function deviceCtrl($scope, DTOptionsBuilder, apiService, $ngBootbox, DTColumnDefBuilder, DTColumnBuilder, notificationService) {
        $scope.dtOptions = DTOptionsBuilder.newOptions()
            .withDOM('<"html5buttons"B>lTfgitp')
            .withButtons([
                { extend: 'copy' },
                { extend: 'excel' },
                { extend: 'pdf' },
                {
                    extend: 'print',
                    customize: function (win) {
                        $(win.document.body).addClass('white-bg');
                        $(win.document.body).css('font-size', '10px');

                        $(win.document.body).find('table')
                            .addClass('compact')
                            .css('font-size', 'inherit');
                    }
                }
            ]);
        $scope.dtColumnDefs = [
            DTColumnDefBuilder.newColumnDef(0).notSortable(),
            DTColumnDefBuilder.newColumnDef(1),
            DTColumnDefBuilder.newColumnDef(2),
            DTColumnDefBuilder.newColumnDef(3),
            DTColumnDefBuilder.newColumnDef(4),
            DTColumnDefBuilder.newColumnDef(5),
            DTColumnDefBuilder.newColumnDef(6),
            DTColumnDefBuilder.newColumnDef(7),

        ];
        $('select').chosen({ width: '100%' });


        //$scope.initData = () => {

        //    $scope.getAll();
        //} này e thử gọi thử cái này vào xem có chạy không như cái trang quản tị ấy mà sao nó k nhảy ra cái gf


        //

        $scope.getAll = () => { // k dùng được cái apiservice rồi. cái servic này n set token để authorize. cái kia e k càna n tự authorize bằng cookie khi e dăng nhập home rồi
            $http.get('/device', null).then(function (result) {
                $scope.devices = result;// result k chấm data cũngd dưc ấy hả a
            }, function (error) {
                console.log('Load devices failed.');
            });
        }
    });



})(angular.module('home'));
