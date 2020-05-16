var pageApplicationName = 'brandModelPageApp';
var ngArr = [];

var app = angular.module(pageApplicationName, ngArr);

app.config(function ($locationProvider) {
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false});
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
        $http.get('/Home/AddBrand?brandName=' + $scope.inputBrand)
            .then(function (response) {
                if (response.status == 200) GetAllBrands();
            }, function (error) {
                $scope.message = 'Unexpected Error while adding Brands data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
    }

    $scope.deleteBrand = function () {
        $http.get('/Home/DeleteBrand?brandId=' + GetSelectedBrandId())
            .then(function (response) {
                if (response.status == 200) GetAllBrands();
            }, function (error) {
                $scope.message = 'Unexpected Error while deleting Brands data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
    }

    $scope.addModel = function () {
        if ($scope.inputModel == '') return;
        var selectedModel = GetSelectedModelName();
        if ($scope.inputModel == selectedModel) return;
        $http.get('/Home/AddModel?brandId=' + $scope.selectedBrandId + '&modelName=' + $scope.inputModel)
            .then(function (response) {
                if (response.status == 200) GetAllModels();
            }, function (error) {
                $scope.message = 'Unexpected Error while adding Models data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
    }

    $scope.deleteModel = function () {
        $http.get('/Home/DeleteModel?modelId=' + GetSelectedModelId())
            .then(function (response) {
                if (response.status == 200) GetAllModels();
            }, function (error) {
                    $scope.message = 'Unexpected Error while deleting Models data!';
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
        $http.get('/Home/GetAllBrandsData')
            .then(function (response) {
                $scope.BrandsList = response.data;
            }, function (error) {
                $scope.message = 'Unexpected Error while loading Brands data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
    }

    function GetAllModels() {
        $http.get('/Home/GetAllModelsData/?brandId=' + $scope.selectedBrandId)
            .then(function (response) {
                $scope.ModelsList = response.data;
                if ($scope.ModelsList != null) {
                    $scope.inputModelDisabled = false;
                } else {
                    $scope.inputModelDisabled = true;
                }
                    
            }, function (error) {
                $scope.message = 'Unexpected Error while loading Models data!';
                $scope.result = "color-red";
                console.log($scope.message);
            });
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
    