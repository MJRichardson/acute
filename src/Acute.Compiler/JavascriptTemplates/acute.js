﻿//define the namespace
Acute = {};

//define App class
Acute.App = function (){};


var acute = angular.module('Acute.App', [])

    .factory('Acute.RouteProvider', ['$routeProvider', function($routeProvider) {
        return {
            'When': function (path, routeConfig) {
                $routeProvider.when(path,
                    {
                        templateUrl: routeConfig.get_TemplateUrl(),
                    });
            }
        };
    }] );