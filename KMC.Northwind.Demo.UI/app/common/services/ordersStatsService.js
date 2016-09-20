(function () {
    'use strict';

    app.factory('orderStatsService', ['$', '$rootScope', 'appServiceSettings', function ($, $rootScope, appServiceSettings) {
        var proxy;
        var connection;
            return {
                connect: function () {
                    var backendServerUrl = appServiceSettings.statsServiceUrl;
                    connection = $.hubConnection(backendServerUrl);
                    connection.logging = true;
                    proxy = connection.createHubProxy('ordersBeingShippedHub');
                    
                    proxy.on('broadcastOrderStats', function (note) {
                        $rootScope.$broadcast('broadcastOrderStats', note);
                    });
                    debugger;
                    connection.start();
                },
                isConnecting: function () {
                    return connection.state === 0;
                },
                isConnected: function () {
                    return connection.state === 1;
                },
                connectionState: function () {
                    return connection.state;
                },
            };
    }])
})();