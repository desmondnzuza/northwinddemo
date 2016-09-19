(function () {
    'use strict';

    app.controller('ordersReportCtrl', ['orderService', function (orderService) {
        var vm = this;
        vm.isDoneLoading = true;
        vm.shippedOrdersStats = [];

        var countries = { all: 'France, Germany, South Africa, United States of America, London' };
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
                    pointFormat: '{point.name}: <b>100</b>'
                }
            };

        this.makeSeries = function (name, countries) {
            var seriesData = angular.copy(defaultSeriesData);

            seriesData.name = name;
            seriesData.countries = countries;
            seriesData.data = this.makeSeriesData(countries);

            return seriesData;
        };

        this.makeSeriesData = function (string) {
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

        this.setSeriesData = function (series, string) {
            series.data = this.makeSeriesData(string);
        };

        this.addSeries = function () {
            this.config.series.push(this.makeSeries());
        };

        this.config = {
            options: {
                legend: {
                    enabled: false
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
                        verticalAlign: 'bottom'
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

        this.config.series[0].allAreas = true;


        orderService.findOrdersBeingShipped()
        .then(function (results) {
            vm.shippedOrdersStats = results;
            console.log('found results');
            console.log(results);
        });


    }]);
})();