
var app = angular.module('compartidos', [])

//      /________________servicios______________________
//**************************************************************************

app.service('like', function ($http) {
    this.getData = function (carga) {

        var resp = $http.post("http://localhost:37438/Datos/Like", carga);
        return resp;
    };
});

app.service('comentario', function ($http) {
    this.getData = function (dato) {

        var resp = $http.post("http://localhost:37438/Datos/Comentar", dato);
        return resp;
    };
});

app.service('come', function ($http) {
    this.getData = function () {
        var resp = $http.post("http://localhost:37438/Datos/Comentarios");
        return resp;
    };
});

//___________llamada solo para traer datos de publicaciones______________________

app.service('ca', function ($http) {
    this.getData = function () {

        var resp = $http.post("http://localhost:37438/Datos/Compartir");
        return resp;
    };
});

//_______________llamada al servidor para enviar datos_____________________________________

app.service('publ', function ($http) {
    this.getData = function (datos) {
        var resp = $http.post("http://localhost:37438/Datos/Datos", datos);
        return resp;
    };
});

//***************************************************************************
//______________________________controlador_____________________
app.controller('CompartirController', function ($scope, publ, comentario, come, ca, $interval, like) {

    //funcion actualizar datos________________________________________

    actualizar();
    var a = $interval(function () {
        actualizar();

    }, 15000);

    var b = $interval(function () {
        $scope.visible = false;
        ;

    }, 15000);

    $scope.visible = false;
    $scope.comentarios = function () {
        $scope.visible = true;
    }

    $scope.Likes = function () {
        $scope.envio = JSON.stringify({ PublicationId: $scope.publicacion });
        Like($scope.envio);
    }

    //_____________________funcion del boton publicar_____________________________
    $scope.enter = function () {
        $scope.datos = JSON.stringify({ publicationId: 0, User: $scope.com, Publication: $scope.publicacion, Picture: $scope.imagen, Video: $scope.video });
        loadData($scope.datos);
        $scope.publicacion = "";
        $scope.picture = "";
        $scope.video = "";
    }

    //_____________________funcion del boton comentar_____________________________
    $scope.comentar = function () {
        $scope.comentario = JSON.stringify({ Comments_id: 0, Publication_id: $scope.id, Publication: $scope.come, user: $scope.com })
        ComentarioData($scope.comentario);
    }

    //_________________________________________
    //funcion para monstrar los datos
    function data(datos) {
        $scope.a = { "datos": angular.fromJson(datos) }
        $scope.cantidad = $scope.a.datos.length;
        $scope.compartidoss = [];
        $scope.compartir = [];
        for (var i = 1; i <= $scope.cantidad ; i++) {

     //[id-publicacion,usuario,imagen,publicacion,imagen,video,comentarios,like]
            $scope.compartidoss.push({ text: [$scope.a.datos[$scope.cantidad - i].publicationId, $scope.a.datos[$scope.cantidad - i].User, $scope.a.datos[$scope.cantidad - i].userimg, $scope.a.datos[$scope.cantidad - i].Publication, $scope.a.datos[$scope.cantidad - i].Picture, $scope.a.datos[$scope.cantidad - i].Video, $scope.a.datos[$scope.cantidad - i].comments, $scope.a.datos[$scope.cantidad - i].Like] })
        }
        actuaCom();
    }
    //_______________________________________________________________

    function Like(envio) {
        var promiseGetData = like.getData(envio);
        promiseGetData.then(function (res) {
            data(res.data);
            $scope.Message = "Call Completed Successfully...";
        }, function (err) {
            $scope.Message = "Call failed" + err.status + "  " + err.statusText;

        });
    }
    //funcion para cargar datos

    function loadData(datos) {
        var promiseGetData = publ.getData(datos);
        promiseGetData.then(function (res) {
            data(res.data);
            $scope.Message = "Call Completed Successfully...";
        }, function (err) {
            $scope.Message = "Call failed" + err.status + "  " + err.statusText;
        });
    }

    //____________________________________________________________________
    function ComentarioData(datos) {
        var promiseGetData = comentario.getData(datos);
        promiseGetData.then(function (res) {
            actualizar();
            $scope.Message = "Call Completed Successfully...";
        }, function (err) {
            $scope.Message = "Call failed" + err.status + "  " + err.statusText;
        });
    }
    //  ______________________________comentarios___________________________________________________________________________
    function MostrarCom(datos) {
        $scope.c = { "comentarios": angular.fromJson(datos) }
        $scope.tamaño = $scope.c.comentarios.length;
        $scope.comentados = [];
        for (var i = 1; i <= $scope.tamaño ; i++) {
            //[id-publicacion,usuario,imagen,comentario,like]
            $scope.comentados.push({ text: [$scope.c.comentarios[$scope.tamaño - i].Publication_id, $scope.c.comentarios[$scope.tamaño - i].user, $scope.c.comentarios[$scope.tamaño - i].userimg, $scope.c.comentarios[$scope.tamaño - i].Publication, $scope.c.comentarios[$scope.tamaño - i].Like] })
        }
    }

    //  _______________________actualizar datos___________________________
    function actualizar() {
        var promiseGetData = ca.getData();
        promiseGetData.then(function (res) {
            data(res.data)
            $scope.Message = "Call Completed Successfully...";
        }, function (err) {
            $scope.Message = "Call failed" + err.status + "  " + err.statusText;
        });
    }

    //__________________________________________________________________________
    function actuaCom() {
        var promiseGetData = come.getData();
        promiseGetData.then(function (res) {
            MostrarCom(res.data)
            $scope.Message = "Call Completed Successfully...";
        }, function (err) {
            $scope.Message = "Call failed" + err.status + "  " + err.statusText;
        });
    }
})

//__________________________________________________________________________
//funcion tecla enter
app.directive('enter', function () {
    return function (scope, element, attrs) {
        element.bind("keydown keypress", function (event) {
            if (event.which === 13) {
                scope.$apply(function () {
                    scope.$eval(attrs.enter);
                });
                event.preventDefault();
            }
        });
    };
})