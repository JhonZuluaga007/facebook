
app.service('mss', function ($http) {
    this.getData = function (id) {
        //alert(id);
        var resp = $http.post("http://localhost:37438/Datos/Comentar", id);
        console.log(resp)
        return resp;
    };
});

//*******************************************************************
//_______________________controlador comentarios_______________________
app.controller('ComentarioController', function ($scope,mss) {
    $scope.comentar = function () {
        $scope.datos = JSON.stringify({ Comments_id: 0, Publication_id: $scope.id, Usuario_id: $scope.com, Publication: $scope.come });
        loadData($scope.datos)
       


    }


 function loadData(id) {

        var promiseGetData = mss.getData(id);

        promiseGetData.then(function (res) {
         

            $scope.Message = "Call Completed Successfully...";
        }, function (err) {
            $scope.Message = "Call failed" + err.status + "  " + err.statusText;
        });
    }
})