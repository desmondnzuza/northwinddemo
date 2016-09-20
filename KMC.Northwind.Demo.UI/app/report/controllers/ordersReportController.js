(function () {
    'use strict';

    app.controller('ordersReportCtrl', ['orderService', 'orderStatsService', '$scope', function (orderService, orderStatsService, $scope) {
        var vm = this;
        vm.isDoneLoading = false;
        vm.shippedOrdersStats = [];

        var countries = { all: '' };
        var defaultSeriesData = {
                allAreas: false,
                name: '',
                countries: '',
                data: [],
                dataLabels: {
                    enabled: true,
                    color: 'white',
                    formatter: function () {
                        if (this.point.value) {
                            return this.point.name;
                        }
                    }
                },
                tooltip: {
                    enabled: true,
                    headerFormat: '',
                    pointFormat: '{point.name}: {point.y}'
                }
            };

        vm.makeSeries = function (name, countries) {
            var seriesData = angular.copy(defaultSeriesData);

            seriesData.name = name;
            seriesData.countries = countries;
            seriesData.data = this.makeSeriesData(countries);

            return seriesData;
        };

        vm.makeSeriesData = function (string) {
            var list = ('' + string).split(','),
                data = []
            ;

            angular.forEach(list, function (country) {
                data.push({
                    name: country.replace(/^\s+|\s+$/, ''),
                    value: 1,
                    drilldown: true
                });
            });

            return data;
        };

        vm.config = {
            options: {
                legend: {
                    enabled: false
                },
                colorAxis: {
                    min: 0,
                    stops: [
                        [0, '#EFEFFF'],
                        [0.5, Highcharts.getOptions().colors[0]],
                        [1, Highcharts.Color(Highcharts.getOptions().colors[0]).brighten(-0.5).get()]
                    ]
                },
                legend: {
                    layout: 'vertical',
                    align: 'left',
                    verticalAlign: 'bottom'
                },
                plotOptions: {
                    map: {
                        mapData: Highcharts.maps['custom/world'],
                        joinBy: ['name']
                    }
                },
                mapNavigation: {
                    enabled: true,
                    buttonOptions: {
                        verticalAlign: 'top'
                    }
                },
                colorAxis: {
                    min: 0,
                    minColor: '#E6E7E8',
                    maxColor: '#005645'
                },
                drilldown: {
                    series: []
                },
            },
            chartType: 'map',
            title: {
                text: 'Orders being shipped'
            },
            subtitle: {
                text: 'World',
                floating: true,
                align: 'right',
                y: 50,
                style: {
                    fontSize: '16px'
                }
            },

            legend:  {
                layout: 'vertical',
                align: 'right',
                verticalAlign: 'middle'
            },

            
            plotOptions: {
                map: {
                    states: {
                        hover: {
                            color: '#EEDD66'
                        }
                    }
                }
            },
            series: [
                this.makeSeries('shipping orders', countries.all)
            ]
        };

        vm.config.series[0].allAreas = true;


        orderService.findOrdersBeingShipped()
        .then(function (results) {
            var newSeriesData = vm.toDataPoints(results);
            vm.config.series[0].data = newSeriesData;

            vm.isDoneLoading = true;

            orderStatsService.connect();
        });

        var updateStats = function (newData) {            
            var newSeriesData = vm.toDataPoints(newData);
            vm.config.series[0].data = newSeriesData;
        }

        //orderStatsService.connect();
        vm.stats = $scope.stats;

        $scope.$on('broadcastOrderStats', function (event, data) {
            updateStats(data);
            $scope.$apply();
        });

        vm.toDataPoints = function (stats) {
            var dataPoints = new Array();

            for (var i = 0; i < stats.length; ++i) {
                var stat = stats[i];

                //hack due to the fact that USA does not work with highcharts yet.
                var title = stat.title;
                if (title === "USA")
                {
                    title = "United States Of America";
                }

                var itemToAdd =
                    {
                        name: title,
                        y: stat.total,
                        drilldown: false,
                        visible: true,
                    };

                dataPoints.push(itemToAdd);
            }

            return dataPoints;
        };


    }]);
})();