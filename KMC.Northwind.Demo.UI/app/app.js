'use strict';
var app = angular.module('app', [
    'ui.router',
    'highcharts-ng',
    'ui.bootstrap',
    'angularMoment',
    'ui.grid'
]);

app.value('$', $);

app.constant('appServiceSettings', {
    apiServiceBaseUri: apiUrl + 'api/',
    statsServiceUrl: apiUrl
});

app.config(['$httpProvider', function ($httpProvider) {
    $httpProvider.defaults.useXDomain = true;
    $httpProvider.defaults.withCredentials = true;
    $httpProvider.defaults.headers.post['Content-Type'] = 'application/x-www-form-urlencoded;charset=UTF-8';
}]);
app.run(['$http', '$httpParamSerializerJQLike', function ($http, $httpParamSerializerJQLike) {
    $http.defaults.transformRequest = $httpParamSerializerJQLike;
}]);