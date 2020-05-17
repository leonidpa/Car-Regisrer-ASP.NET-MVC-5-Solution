var pageApplicationName = 'brandModelPageApp';
var ngArr = [];

var app = angular.module(pageApplicationName, ngArr);

app.config(function ($locationProvider) {
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    });
});


app.controller('BrandModelController', function ($scope, $http, $location, $window) {
    $scope.isViewLoading = false;
    $scope.result = "color-default";
    $scope.message = '';
    $scope.BrandsList = null;
    $scope.ModelsList = null;
    $scope.selectedBrandId = null;
    $scope.selectedModelId = null;
    $scope.inputBrand = '';
    $scope.inputModel = '';
    $scope.brandDeleteVisble = false;
    $scope.modelDeleteVisible = false;
    $scope.inputModelDisabled = true;
    GetAllBrands();

    $scope.addBrand = function () {
        if ($scope.inputBrand == '') return;
        var selectedBrand = GetSelectedBrandName();
        if ($scope.inputBrand == selectedBrand) return;
        $http.post('/api/brands/add/' + $scope.inputBrand)
            .then(function (response) {
                if (response.status == 200) GetAllBrands();
            }, function (error) {
                $scope.message = 'Unexpected Error when adding Brands data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
    }

    $scope.deleteBrand = function () {
        $http.delete('/api/brands/delete/' + GetSelectedBrandId())
            .then(function (response) {
                if (response.status == 200) GetAllBrands();
            }, function (error) {
                $scope.message = 'Unexpected Error when deleting Brands data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
    }

    $scope.addModel = function () {
        if ($scope.inputModel == '') return;
        var selectedModel = GetSelectedModelName();
        if ($scope.inputModel == selectedModel) return;
        $http.post('/api/models/add/' + $scope.selectedBrandId + '/' + $scope.inputModel)
            .then(function (response) {
                if (response.status == 200) GetAllModels();
            }, function (error) {
                $scope.message = 'Unexpected Error when adding Models data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
    }

    $scope.deleteModel = function () {
        $http.delete('/api/models/delete/' + GetSelectedModelId())
            .then(function (response) {
                if (response.status == 200) GetAllModels();
            }, function (error) {
                $scope.message = 'Unexpected Error when deleting Models data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
    }

    $scope.selectBrandChanged = function () {
        $scope.brandDeleteVisble = true;
        $scope.modelDeleteVisible = false;
        $scope.inputBrand = GetSelectedBrandName();
        GetAllModels();
    };

    $scope.setBrandSelect = function () {
        if ($scope.inputBrand == '') return;
        var found = $scope.BrandsList.find(element => element.Name.startsWith($scope.inputBrand));
        $scope.brandDeleteVisble = false;
        if (found != undefined) {
            $scope.brandDeleteVisble = true;
            var sl = document.getElementById("brandsSelectList");
            sl.value = found.Id;
            $scope.selectedBrandId = found.Id;
            GetAllModels();
        }

    };

    $scope.selectModelChanged = function () {
        var selectedModelName = GetSelectedModelName();
        if (selectedModelName != '')
            $scope.modelDeleteVisible = true;
        $scope.inputModel = selectedModelName;
    };

    $scope.setModelSelect = function () {
        if ($scope.inputModel == '') return;
        var found = $scope.ModelsList.find(element => element.Name.startsWith($scope.inputModel));
        $scope.modelDeleteVisible = false;
        if (found != undefined) {
            $scope.modelDeleteVisible = true;
            var sl = document.getElementById("modelsSelectList");
            sl.value = found.Id;
        }
    };

    function GetAllBrands() {
        $scope.isViewLoading = true;
        $http.get('/api/brands')
            .then(function (response) {
                $scope.BrandsList = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error when loading Brands data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
        $scope.isViewLoading = false;
    }

    function GetAllModels() {
        $scope.isViewLoading = true;
        $http.get('/api/models/' + ($scope.selectedBrandId == null ? '0' : $scope.selectedBrandId))
            .then(function (response) {
                $scope.ModelsList = response.data;
                if ($scope.ModelsList != null) {
                    $scope.inputModelDisabled = false;
                } else {
                    $scope.inputModelDisabled = true;
                }

            }, function (error) {
                $scope.message = 'Unexpected Error when loading Models data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
        $scope.isViewLoading = false;
    }

    function GetSelectedBrandName() {
        var sl = document.getElementById("brandsSelectList");
        return sl.options[sl.selectedIndex].text;
    }

    function GetSelectedBrandId() {
        var sl = document.getElementById("brandsSelectList");
        return sl.value;
    }

    function GetSelectedModelName() {
        var sl = document.getElementById("modelsSelectList");
        return sl.options[sl.selectedIndex].text;
    }

    function GetSelectedModelId() {
        var sl = document.getElementById("modelsSelectList");
        return sl.value;
    }
});