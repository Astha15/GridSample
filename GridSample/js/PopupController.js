app.controller("PopupController", function ($scope, $http, $uibModalInstance , EmailService) {
   
    $scope.send = function () {

        var email = $scope.emailID;
        $http({
            method: 'POST',
            url: '/Data/SendMail?recipient=' +email,
           // data: email,
            headers : {'Content-Type' : 'application/x-www-form-urlencoded'}
        })
        .success(function () {
            alert('Email Successful');
        })
                //var email = $scope.emailID;
        //if (email != null) {
        //    EmailService.sendMail(email).success(function () {
        //        alert('Email Successful');
        //    })
        //}
        //else {
        //    $scope.body = "Please enter a valid email id";
        //}
    };
    $scope.close = function () {
        $uibModalInstance.dismiss('cancel');
    };
})

.factory('EmailService', function($http){
    return {
        'sendMail' : function(email)
        {
            console.log(email);
            return $http.post('/Data/SendMail', email);
        }
    }
});