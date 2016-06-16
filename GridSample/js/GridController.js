app.controller("GridController", function ($scope, DataService) {
    DataService.GetResult().then(function (d) {
        //console.log(d);
        $scope.Alerts = d.data;
    }, function () {
        alert('Failed');
    });
    $scope.test = "test";
    $scope.severityValues = function (Items,property) {
        if (Items == null)
        {
            return null;
        }
        console.log(Items)
        var items = null;
        items = Items.map(function (a) { return a[property]; });
        var unique = jQuery.unique(items);
        console.log(unique);
        return unique;
    };
    $scope.sortType = 'Priority';
    $scope.sortReverse = false;
})
.factory('DataService', function($http){
    var fac = {};
    fac.GetResult = function(){
        return $http.get('/Data/GetResult');
    }
    return fac;
});