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
    $scope.inputCarModelDisabled = false;
    $scope.EditCarId = 0;
    $scope.plug = '';
    GetAllBrands();
    GetAllCars();

    $scope.OnCarBrandSelectChange = function (carBrandId) {
        GetAllModels(carBrandId);
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
            $scope.firstNameInput == undefined
            ||
            $scope.lastNameInput == undefined
            ||
            $scope.patronymicInput == undefined
            ||
            $scope.phoneNumberInput == undefined
            ||
            $scope.carNumberInput == undefined
            ||
            $scope.carBrandSelect == undefined
            ||
            $scope.carModelSelect == undefined
            ||
            $scope.carBrandSelect == null
            ||
            $scope.carModelSelect == null
        ) {
            alert('Not all data is entered');
            return;
        } 
        var carModel = {
            FirstName: $scope.firstNameInput,
            LastName: $scope.lastNameInput,
            Patronymic: $scope.patronymicInput,
            PhoneNamber: $scope.phoneNumberInput,
            CarNumber: $scope.carNumberInput,
            CarBrandId: $scope.carBrandSelect,
            CarModelId: $scope.carModelSelect
        };

        $http.put('/api/cars/add', carModel)
            .then(function (response) {
                if (response.status == 200) GetAllCars();;
            }, function (error) {
                $scope.message = 'Unexpected Error while adding Cars data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });

        $scope.firstNameInput = '';
        $scope.lastNameInput = '';
        $scope.patronymicInput = '';
        $scope.phoneNumberInput = '';
        $scope.carNumberInput = '';
        $scope.carBrandSelect = '';
        $scope.carModelSelect = '';
    }

    $scope.OnEditCarInit = function (carId) {
        $scope.inputCarModelDisabled = true;
        $scope.EditCarId = carId;

        var brandSelect = document.getElementById("carBrandEditSelect-" + carId);
        brandSelect.addEventListener("change", function () {

            GetAllModels(document.getElementById("carBrandEditSelect-" + carId).value, function () {
                var modelSelect = document.getElementById("carModelEditSelect-" + carId);
                var length = modelSelect.options.length;
                for (i = length - 1; i >= 0; i--) {
                    modelSelect.options[i] = null;
                }
                if ($scope.carModelsList.length > 0) {
                    $scope.carModelsList.forEach(function (entry) {
                        var opt = document.createElement('option');
                        opt.value = entry.Id;
                        opt.innerHTML = entry.Name;
                        modelSelect.appendChild(opt);
                    }
                    );
                }
            });
        });
        $scope.carBrandsList.forEach(function (entry) {
            var opt = document.createElement('option');
            opt.value = entry.Id;
            opt.innerHTML = entry.Name;
            brandSelect.appendChild(opt);
        }
        );
        $http.get('/api/cars/car/' + carId)
            .then(function (response) {
                var foundBrand = $scope.carBrandsList.find(element => element.Name.startsWith(response.data.Brand));
                if (foundBrand != undefined) {
                    var selectModel = function () {
                        var modelSelect = document.getElementById("carModelEditSelect-" + carId);
                        $scope.carModelsList.forEach(function (entry) {
                            var opt = document.createElement('option');
                            opt.value = entry.Id;
                            opt.innerHTML = entry.Name;
                            modelSelect.appendChild(opt);
                        }
                        );
                        var foundModel = $scope.carModelsList.find(element => element.Name.startsWith(response.data.Model));
                        if (foundModel != undefined) {
                            var sl = document.getElementById("carModelEditSelect-" + carId);
                            sl.value = foundModel.Id;
                        }
                    }
                    GetAllModels(foundBrand.Id, selectModel);

                    var sl = document.getElementById("carBrandEditSelect-" + carId);
                    sl.value = foundBrand.Id;
                }
                document.getElementById("carBrandEditFirstNameInput-" + carId).value = response.data.FirstName;
                document.getElementById("carBrandEditLastNameInput-" + carId).value = response.data.LastName;
                document.getElementById("carBrandEditPatronimicInput-" + carId).value = response.data.Patronymic;
                document.getElementById("carBrandEditPhoneNumberInput-" + carId).value = response.data.PhoneNumber;
                document.getElementById("carBrandEditCarNumberInput-" + carId).value = response.data.Number;
            }, function (error) {
                $scope.message = 'Unexpected Error when loading edit Car data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
    }

    $scope.OnSaveCarEdit = function (carId) {
        $scope.inputCarModelDisabled = false;
        $scope.EditCarId = 0;

        if (
            document.getElementById("carBrandEditFirstNameInput-" + carId).value == ''
            ||
            document.getElementById("carBrandEditLastNameInput-" + carId).value == ''
            ||
            document.getElementById("carBrandEditPatronimicInput-" + carId).value == ''
            ||
            document.getElementById("carBrandEditPhoneNumberInput-" + carId).value == ''
            ||
            document.getElementById("carBrandEditCarNumberInput-" + carId).value == ''
            ||
            document.getElementById("carBrandEditSelect-" + carId).value == ''
            ||
            document.getElementById("carModelEditSelect-" + carId).value == ''
            ||
            document.getElementById("carBrandEditFirstNameInput-" + carId).value == undefined
            ||
            document.getElementById("carBrandEditLastNameInput-" + carId).value == undefined
            ||
            document.getElementById("carBrandEditPatronimicInput-" + carId).value == undefined
            ||
            document.getElementById("carBrandEditPhoneNumberInput-" + carId).value == undefined
            ||
            document.getElementById("carBrandEditCarNumberInput-" + carId).value == undefined
            ||
            document.getElementById("carBrandEditSelect-" + carId).value == undefined
            ||
            document.getElementById("carModelEditSelect-" + carId).value == undefined
        ) {
            alert('Not all data is entered');
            return;
        } 
        var carModel = {
            CarId: carId,
            FirstName: document.getElementById("carBrandEditFirstNameInput-" + carId).value,
            LastName: document.getElementById("carBrandEditLastNameInput-" + carId).value,
            Patronymic: document.getElementById("carBrandEditPatronimicInput-" + carId).value,
            PhoneNamber: document.getElementById("carBrandEditPhoneNumberInput-" + carId).value,
            CarNumber: document.getElementById("carBrandEditCarNumberInput-" + carId).value,
            CarBrandId: document.getElementById("carBrandEditSelect-" + carId).value,
            CarModelId: document.getElementById("carModelEditSelect-" + carId).value
        };

        $http.post('/api/cars/update', carModel)
            .then(function (response) {
                if (response.status == 200) GetAllCars();;
            }, function (error) {
                $scope.message = 'Unexpected Error while adding Cars data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
    }

    $scope.OnDeleteCar = function (carId) {
        var conf = confirm("Сonfirm to delete the entry");
        if (conf) {
            $http.delete('/api/cars/delete/' + carId)
                .then(function (response) {
                    if (response.status == 200) GetAllCars();
                }, function (error) {
                    $scope.message = 'Unexpected Error when deleting Cars data!';
                    $scope.result = "color-red";
                    console.log($scope.message);
                });
        }
    }

    function GetAllBrands() {
        $scope.isViewLoading = true;
        $http.get('/api/brands')
            .then(function (response) {
                $scope.carBrandsList = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error when loading Brands data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
        $scope.isViewLoading = false;
    }

    function GetAllModels(carBrandId, callback) {
        $scope.isViewLoading = true;
        $http.get('/api/models/' + (carBrandId == null ? '0' : carBrandId))
            .then(function (response) {
                $scope.carModelsList = response.data;
                if (callback != undefined && callback != null) {
                    callback();
                }
            }, function (error) {
                $scope.message = 'Unexpected Error when loading Models data!';
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
                $scope.message = 'Unexpected Error when loading Cars data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
        $scope.isViewLoading = false;
    }
});
