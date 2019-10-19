(function () {

    // Pagina Layout (rota Angular) //
    var app = angular.module('MacApp', []);

    // Controle Airplane //
    app.controller('Airplane', function ($scope, $http) {
        Airplane($scope, $http);
    });

    // Controle Passangers //
    app.controller('Passangers', function ($scope, $http) {
        Passangers($scope, $http);
    });

})();