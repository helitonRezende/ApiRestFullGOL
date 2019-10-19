function Passangers($scope, $http) {

    var idAeronaveSel = 0;

    // lista Passageriros //
    $scope.LoadPassangers = function () {
        AtualizaTelaPassangers($scope, $http);
    }

    // Salvar Passageiros X Aeronaves //
    $scope.adicionaItem = function () {
        var json = {
            "AIRPLANE": {
                "ID": idAeronaveSel
            },
            "PASSAGEIRO": {
                "NOME": $scope.nome,
                "CPF": $scope.cpf
            }
        };

        var req = {
            method: 'POST',
            data: json,
            url: '/Api/Passangers/AdicionarPassangers'
        }

        if ($scope.cpf != "" && $scope.nome != "") {
            $http(req).then(function () {
                req = {
                    method: 'PUT',
                    data: json,
                    url: '/Api/Passangers/AlterarPassangers'
                }

                $http(req).then(function () {
                    AtualizaTelaPassangers($scope, $http);
                });
            });
        }
    };

    // Set Selecao Passageiros //
    $scope.setAeronaveSel = function (item) {
        idAeronaveSel = item;
    };

    // Editar Passageiros //
    $scope.editaItem = function (cpf, nome, idaeronave) {
        $scope.cpf = cpf;
        $scope.nome = nome;
        //for (var i = 0; i < $scope.lista.length; i++) {
        //    if ($scope.lista[i].AIRPLANE.ID == idaeronave) {
        //        $scope.repeatSelect = idaeronave;
        //        break;
        //    }
        //}
    };
}

function AtualizaTelaPassangers($scope, $http) {

    var req = {
        method: 'GET',
        url: '/Api/Passangers'
    }

    $http(req).then(function (reponse) {
        $scope.lista = reponse.data;
    });

    $scope.cpf = "";
    $scope.nome = "";

}