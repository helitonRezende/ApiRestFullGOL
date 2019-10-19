function Airplane($scope, $http) {

    // lista Aeronaves //
    $scope.LoadAirplane = function () {
        var req = {
            method: 'GET',
            url: '/Api/Airplane'
        }

        $http(req).then(function (reponse) {
            $scope.lista = reponse.data;
        });
    }

}