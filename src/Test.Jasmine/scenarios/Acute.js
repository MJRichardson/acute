(function() {
	'use strict';
	var $asm = {};
	global.Acute = global.Acute || {};
	ss.initAssembly($asm, 'Acute');
	////////////////////////////////////////////////////////////////////////////////
	// Acute.Bootstrapper
	var $Acute_$Bootstrapper = function() {
	};
	$Acute_$Bootstrapper.__typeName = 'Acute.$Bootstrapper';
	$Acute_$Bootstrapper.$main = function() {
		$Acute_$Bootstrapper.$init();
	};
	$Acute_$Bootstrapper.$init = function() {
		var $t1 = ss.getAssemblyTypes($asm);
		for (var $t2 = 0; $t2 < $t1.length; $t2++) {
			var type = $t1[$t2];
			if (type.prototype instanceof $Acute_App === false) {
				continue;
			}
			ss.createInstance(type);
		}
	};
	////////////////////////////////////////////////////////////////////////////////
	// Acute.ReflectionExtensions
	var $Acute_$ReflectionExtensions = function() {
	};
	$Acute_$ReflectionExtensions.__typeName = 'Acute.$ReflectionExtensions';
	$Acute_$ReflectionExtensions.$getFunction = function(type, functionName) {
		return ss.cast(type.prototype[functionName], Function);
	};
	$Acute_$ReflectionExtensions.$getConstructorFunction = function(type) {
		return $Acute_$ReflectionExtensions.$getFunction(type, 'constructor');
	};
	$Acute_$ReflectionExtensions.$getInstanceMethodNames = function(type) {
		var result = [];
		var $t1 = ss.getEnumerator(Object.keys(type.prototype));
		try {
			while ($t1.moveNext()) {
				var key = $t1.current();
				if (key !== 'constructor') {
					ss.add(result, key);
				}
			}
		}
		finally {
			$t1.dispose();
		}
		return result;
	};
	$Acute_$ReflectionExtensions.$createFunctionCall = function(fun, parameters) {
		// if no parameters, takes function out of the array
		if (parameters.length === 0) {
			return fun;
		}
		// builds array, but also FIX $injection in the type
		var result = [];
		for (var t = 0; t < parameters.length; t++) {
			if (ss.startsWithString(parameters[t], '_')) {
				parameters[t] = '$' + parameters[t].substring(1);
			}
			ss.add(result, parameters[t]);
		}
		ss.add(result, fun);
		return result;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Acute.App
	var $Acute_App = function() {
		this.$_module = null;
		this.$_module = angular.module(ss.getTypeFullName(ss.getInstanceType(this)), ['ngRoute']);
		this.service($Acute_RouteProvider).call(this);
		//register the config
		var configFunc = $Acute_$ReflectionExtensions.$getFunction($Acute_App, $Acute_App.$configMethodScriptName);
		var parameters = angular.injector().annotate(configFunc);
		var annotatedFunc = $Acute_$ReflectionExtensions.$createFunctionCall(configFunc, parameters);
		this.$_module.config(annotatedFunc);
	};
	$Acute_App.__typeName = 'Acute.App';
	$Acute_App.$buildControllerFunction = function(type) {
		var body = '';
		var scopeVar = '$scope';
		// takes method into $scope, binding "$scope" to "this"                 
		var $t1 = $Acute_$ReflectionExtensions.$getInstanceMethodNames(type);
		for (var $t2 = 0; $t2 < $t1.length; $t2++) {
			var funcname = $t1[$t2];
			body += ss.formatString('{2}.{1} = {0}.prototype.{1}.bind({2});\r\n', ss.getTypeFullName(type), funcname, scopeVar);
		}
		body += ss.formatString("alert('called');\r\n");
		// put call at the end so that methods are defined first
		body += ss.formatString('{0}.apply({1},arguments);\r\n', ss.getTypeFullName(type), scopeVar);
		//get the constructor parameters
		var parameters = angular.injector().annotate($Acute_$ReflectionExtensions.$getConstructorFunction(type));
		//and add $scope as a parameter
		ss.add(parameters, scopeVar);
		return new Function(parameters, body);
	};
	global.Acute.App = $Acute_App;
	////////////////////////////////////////////////////////////////////////////////
	// Acute.Controller
	var $Acute_Controller = function() {
	};
	$Acute_Controller.__typeName = 'Acute.Controller';
	global.Acute.Controller = $Acute_Controller;
	////////////////////////////////////////////////////////////////////////////////
	// Acute.RouteConfig
	var $Acute_RouteConfig = function() {
		this.$1$TemplateUrlField = null;
		this.$1$ControllerField = null;
	};
	$Acute_RouteConfig.__typeName = 'Acute.RouteConfig';
	global.Acute.RouteConfig = $Acute_RouteConfig;
	////////////////////////////////////////////////////////////////////////////////
	// Acute.RouteConfig
	var $Acute_RouteConfig$1 = function(TController) {
		var $type = function() {
			$Acute_RouteConfig.call(this);
			this.set_controller(TController);
		};
		ss.registerGenericClassInstance($type, $Acute_RouteConfig$1, [TController], {}, function() {
			return $Acute_RouteConfig;
		}, function() {
			return [];
		});
		return $type;
	};
	$Acute_RouteConfig$1.__typeName = 'Acute.RouteConfig$1';
	ss.initGenericClass($Acute_RouteConfig$1, $asm, 1);
	global.Acute.RouteConfig$1 = $Acute_RouteConfig$1;
	////////////////////////////////////////////////////////////////////////////////
	// Acute.RouteProvider
	var $Acute_RouteProvider = function(_routeProvider) {
		this.$_angularRouteProvider = null;
		this.$_angularRouteProvider = _routeProvider;
	};
	$Acute_RouteProvider.__typeName = 'Acute.RouteProvider';
	global.Acute.RouteProvider = $Acute_RouteProvider;
	ss.initClass($Acute_$Bootstrapper, $asm, {});
	ss.initClass($Acute_$ReflectionExtensions, $asm, {});
	ss.initClass($Acute_App, $asm, {
		controller: function(T) {
			return function() {
				this.controller$1(T);
			};
		},
		controller$1: function(controllerType) {
			var func = $Acute_App.$buildControllerFunction(controllerType);
			var parameters = controllerType.$inject;
			var fcall = $Acute_$ReflectionExtensions.$createFunctionCall(func, parameters);
			this.$_module.controller('blah', fcall);
		},
		service: function(T) {
			return function() {
				var type = T;
				var parameters = angular.injector().annotate($Acute_$ReflectionExtensions.$getConstructorFunction(type));
				$Acute_$ReflectionExtensions.$createFunctionCall(type, parameters);
				// only used to fix the "_" to "$" in type.$inject
				var servicename = ss.getTypeName(T);
				this.$_module.service(servicename, type);
			};
		},
		config: function(_routeProvider) {
			this.configureRoutes(_routeProvider);
		},
		configureRoutes: function(routeProvider) {
		}
	});
	ss.initClass($Acute_Controller, $asm, {});
	ss.initClass($Acute_RouteConfig, $asm, {
		get_templateUrl: function() {
			return this.$1$TemplateUrlField;
		},
		set_templateUrl: function(value) {
			this.$1$TemplateUrlField = value;
		},
		get_controller: function() {
			return this.$1$ControllerField;
		},
		set_controller: function(value) {
			this.$1$ControllerField = value;
		},
		$toAngularRouteConfig: function() {
			var angularRouteConfig = {};
			if (!ss.isNullOrEmptyString(this.get_templateUrl())) {
				angularRouteConfig.templateUrl = this.get_templateUrl();
			}
			if (ss.isValue(this.get_controller())) {
				angularRouteConfig.controller = this.get_controller();
			}
			return angularRouteConfig;
		}
	});
	ss.initClass($Acute_RouteProvider, $asm, {
		when: function(path, routeConfig) {
			this.$_angularRouteProvider.when(path, routeConfig.$toAngularRouteConfig());
			return this;
		},
		otherwise: function(routeConfig) {
			this.$_angularRouteProvider.otherwise(routeConfig.$toAngularRouteConfig());
			return this;
		}
	});
	$Acute_App.$configMethodScriptName = 'config';
	$Acute_$Bootstrapper.$main();
})();
