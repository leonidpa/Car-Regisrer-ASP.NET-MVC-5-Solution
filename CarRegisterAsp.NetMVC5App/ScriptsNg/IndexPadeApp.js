var pageApplicationName = 'indexPageApp';
var ngArr = [];

var app = angular.module(pageApplicationName, ngArr);

app.config(function ($locationProvider) {
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
});

app.controller('IndexController', function ($scope, $http, $location, $window) {
    $scope.isViewLoading = false;
    $scope.result = "color-default";
    $scope.message = '';
    $scope.firstNameInput = '';
    $scope.lastNameInput = '';
    $scope.patronymicInput = '';
    $scope.phoneNumberInput = '';
    $scope.carNumberInput = '';
    $scope.carBrandSelect = '';
    $scope.carBrandsList = null;
    $scope.carModelSelect = '';
    $scope.carModelsList = null;
    $scope.carsList = null;
    GetAllBrands();
    GetAllCars();

    $scope.OnCarBrandSelectChange = function () {
        GetAllModels();
    }

    $scope.RegisterCar = function () {
        if (
            $scope.firstNameInput == ''
            ||
            $scope.lastNameInput == ''
            ||
            $scope.patronymicInput == ''
            ||
            $scope.phoneNumberInput == ''
            ||
            $scope.carNumberInput == ''
            ||
            $scope.carBrandSelect == ''
            ||
            $scope.carModelSelect == ''
            ||
            $scope.carBrandSelect == null
            ||
            $scope.carModelSelect == null
            ) return;
        var carModel = {
            FirstName: $scope.firstNameInput,
            LastName: $scope.lastNameInput,
            Patronymic: $scope.patronymicInput,
            PhoneNamber: $scope.phoneNumberInput,
            CarNumber: $scope.carNumberInput,
            CarBrandId: $scope.carBrandSelect,
            CarModelId: $scope.carModelSelect
        };

        $http.post('/api/cars/add', carModel)
            .then(function (response) {
                if (response.status == 200) GetAllCars();;
            }, function (error) {
                $scope.message = 'Unexpected Error while adding Cars data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
    }

    function GetAllBrands() {
        $scope.isViewLoading = true;
        $http.get('/api/brands')
            .then(function (response) {
                $scope.carBrandsList = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error while loading Brands data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
        $scope.isViewLoading = false;
    }

    function GetAllModels() {
        $scope.isViewLoading = true;
        $http.get('/api/models/' + ($scope.carBrandSelect == null ? '0' : $scope.carBrandSelect))
            .then(function (response) {
                $scope.carModelsList = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error while loading Models data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
        $scope.isViewLoading = false;
    }

    function GetAllCars() {
        $scope.isViewLoading = true;
        $http.get('/api/cars')
            .then(function (response) {
                $scope.carsList = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error while loading Cars data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
        $scope.isViewLoading = false;
    }
});
