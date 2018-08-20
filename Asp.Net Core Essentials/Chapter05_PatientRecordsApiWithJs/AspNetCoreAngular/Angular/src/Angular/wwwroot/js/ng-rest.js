(function () {
    'use strict';
    var prApp = angular.module('patientsApp', []);
})();

(function () {
    'use strict';

    var pService = 'patientFactory';

    angular.module('patientsApp').factory(pService,
        ['$http', patientFactory]);

    function patientFactory($http) {

        function getPatientsFromApi() {
            // NOTE: the port number should be changed as necessary  
            return $http.get('http://localhost:61433/api/Patient');
        }

        var patientService = {
            getPatientsFromApi: getPatientsFromApi
        };
        return patientService;
    }
})();

(function () {
    'use strict';

    var pController = 'patientController';

    angular.module('patientsApp').controller(pController,
        ['$scope', 'patientFactory', patientController]);

    function patientController($scope, patientFactory) {
        $scope.patients = [];

        patientFactory.getPatientsFromApi().then(function (patientData) {
            $scope.patients = patientData.data;
            console.log("Data obtained successfully.");
        }, function (error) {
            console.log("An error has occured.");
        });
    }
})(); 