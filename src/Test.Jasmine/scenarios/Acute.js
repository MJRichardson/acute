﻿(function() {
	'use strict';
	var $asm = {};
	global.Acute = global.Acute || {};
	global.Acute.Http = global.Acute.Http || {};
	global.System = global.System || {};
	global.System.Net = global.System.Net || {};
	global.System.Net.Http = global.System.Net.Http || {};
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
	$Acute_$ReflectionExtensions.$asAngularServiceName = function(type) {
		var angularServiceAttributes = ss.getAttributes(type, $Acute_Angular_$AngularServiceAttribute, false);
		return ((angularServiceAttributes.length > 0) ? ss.cast(angularServiceAttributes[0], $Acute_Angular_$AngularServiceAttribute).get_$serviceName() : ss.replaceAllString(ss.getTypeFullName(type), '.', ''));
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
	$Acute_$ReflectionExtensions.$createFunctionArray = function(type) {
		var constructorInfo = ss.getMembers(type, 1, 28)[0];
		//todo: assert only one constructor
		//var constructorInfo = type.GetMember(null, BindingFlags.Default)[0];
		return $Acute_$ReflectionExtensions.$createFunctionArray$1(type, constructorInfo);
	};
	$Acute_$ReflectionExtensions.$createFunctionArray$1 = function(type, method) {
		var func = ((ss.isValue(method) && method.type === 1) ? $Acute_$ReflectionExtensions.$getConstructorFunction(type) : $Acute_$ReflectionExtensions.$getFunction(type, ss.cast(method, ss.isValue(method) && method.type === 8).sname));
		var parameterTypes = method.params;
		var functionArrayNotation = [];
		for (var $t1 = 0; $t1 < parameterTypes.length; $t1++) {
			var parameterType = parameterTypes[$t1];
			ss.add(functionArrayNotation, $Acute_$ReflectionExtensions.$asAngularServiceName(parameterType));
		}
		ss.add(functionArrayNotation, func);
		return functionArrayNotation;
	};
	////////////////////////////////////////////////////////////////////////////////
	// Acute.App
	var $Acute_App = function() {
		this.$_module = null;
		this.$_module = angular.module(ss.getTypeFullName(ss.getInstanceType(this)), ['ngRoute']);
		//Provider<RouteProvider>();
		this.$registerRouteProvider();
		this.service$1($Acute_Http_IHttp, $Acute_Http_HttpDefault).call(this);
		//register the config
		//var configFunc = typeof (App).GetFunction(ConfigMethodScriptName);
		//var parameters = GlobalApi.Injector().Annotate(configFunc);
		//var annotatedFunc = configFunc.CreateFunctionCall(parameters);
		//_module.Config(annotatedFunc);
		//var configFunc = typeof (App).GetFunction(ConfigureRoutesScriptName);
		//var parameters = GlobalApi.Injector().Annotate(configFunc);
		//var annotatedFunc = configFunc.CreateFunctionArray(parameters);
		//_module.Config(annotatedFunc);
		var appType = ss.getInstanceType(this);
		var configMethod = ss.getMembers(appType, 8, 284, 'ConfigureRoutes');
		this.$_module.config($Acute_$ReflectionExtensions.$createFunctionArray$1(appType, configMethod));
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
		// put call at the end so that methods are defined first
		body += ss.formatString('{0}.apply({1},arguments);\r\n', ss.getTypeFullName(type), scopeVar);
		//get the constructor parameters
		var parameters = angular.injector().annotate($Acute_$ReflectionExtensions.$getConstructorFunction(type));
		var functionArrayNotation = $Acute_$ReflectionExtensions.$createFunctionArray(type);
		//and add $scope as a parameter
		ss.insert(functionArrayNotation, ss.count(functionArrayNotation) - 1, scopeVar);
		//and add $scope as a parameter
		ss.add(parameters, scopeVar);
		var modifiedFunc = new Function(parameters, body);
		ss.setItem(functionArrayNotation, parameters.length, modifiedFunc);
		return functionArrayNotation;
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
	////////////////////////////////////////////////////////////////////////////////
	// Acute.Angular.AngularServiceAttribute
	var $Acute_Angular_$AngularServiceAttribute = function(serviceName) {
		this.$2$ServiceNameField = null;
		this.set_$serviceName(serviceName);
	};
	$Acute_Angular_$AngularServiceAttribute.__typeName = 'Acute.Angular.$AngularServiceAttribute';
	////////////////////////////////////////////////////////////////////////////////
	// Acute.Angular.Http
	var $Acute_Angular_$Http = function() {
	};
	$Acute_Angular_$Http.__typeName = 'Acute.Angular.$Http';
	////////////////////////////////////////////////////////////////////////////////
	// Acute.Angular.RouteProvider
	var $Acute_Angular_$RouteProvider = function() {
	};
	$Acute_Angular_$RouteProvider.__typeName = 'Acute.Angular.$RouteProvider';
	////////////////////////////////////////////////////////////////////////////////
	// Acute.Http.HttpDefault
	var $Acute_Http_HttpDefault = function(_http) {
		this.$_angularHttp = null;
		this.$_angularHttp = _http;
	};
	$Acute_Http_HttpDefault.__typeName = 'Acute.Http.HttpDefault';
	global.Acute.Http.HttpDefault = $Acute_Http_HttpDefault;
	////////////////////////////////////////////////////////////////////////////////
	// Acute.Http.HttpRequest
	var $Acute_Http_HttpRequest = function(httpMethod, url) {
		this.$1$HttpMethodField = null;
		this.$1$UrlField = null;
		this.set_httpMethod(httpMethod);
		this.set_url(url);
	};
	$Acute_Http_HttpRequest.__typeName = 'Acute.Http.HttpRequest';
	global.Acute.Http.HttpRequest = $Acute_Http_HttpRequest;
	////////////////////////////////////////////////////////////////////////////////
	// Acute.Http.HttpResponse
	var $Acute_Http_HttpResponse = function(status) {
		this.$1$StatusField = 0;
		this.set_status(status);
	};
	$Acute_Http_HttpResponse.__typeName = 'Acute.Http.HttpResponse';
	global.Acute.Http.HttpResponse = $Acute_Http_HttpResponse;
	////////////////////////////////////////////////////////////////////////////////
	// Acute.Http.IHttp
	var $Acute_Http_IHttp = function() {
	};
	$Acute_Http_IHttp.__typeName = 'Acute.Http.IHttp';
	global.Acute.Http.IHttp = $Acute_Http_IHttp;
	////////////////////////////////////////////////////////////////////////////////
	// System.Net.Http.HttpMethod
	var $System_Net_Http_HttpMethod = function(method) {
		this.$_method = null;
		if (ss.isNullOrEmptyString(method)) {
			throw new ss.ArgumentNullException('method');
		}
		this.$_method = method;
	};
	$System_Net_Http_HttpMethod.__typeName = 'System.Net.Http.HttpMethod';
	$System_Net_Http_HttpMethod.get_get = function() {
		return $System_Net_Http_HttpMethod.$getMethod;
	};
	$System_Net_Http_HttpMethod.get_put = function() {
		return $System_Net_Http_HttpMethod.$putMethod;
	};
	$System_Net_Http_HttpMethod.get_post = function() {
		return $System_Net_Http_HttpMethod.$postMethod;
	};
	$System_Net_Http_HttpMethod.get_delete = function() {
		return $System_Net_Http_HttpMethod.$deleteMethod;
	};
	$System_Net_Http_HttpMethod.get_head = function() {
		return $System_Net_Http_HttpMethod.$headMethod;
	};
	$System_Net_Http_HttpMethod.get_options = function() {
		return $System_Net_Http_HttpMethod.$optionsMethod;
	};
	$System_Net_Http_HttpMethod.get_trace = function() {
		return $System_Net_Http_HttpMethod.$traceMethod;
	};
	$System_Net_Http_HttpMethod.op_Equality = function(left, right) {
		if ($System_Net_Http_HttpMethod.op_Equality(left, null)) {
			return $System_Net_Http_HttpMethod.op_Equality(right, null);
		}
		if ($System_Net_Http_HttpMethod.op_Equality(right, null)) {
			return $System_Net_Http_HttpMethod.op_Equality(left, null);
		}
		else {
			return left.equalsT(right);
		}
	};
	$System_Net_Http_HttpMethod.op_Inequality = function(left, right) {
		return !$System_Net_Http_HttpMethod.op_Equality(left, right);
	};
	global.System.Net.Http.HttpMethod = $System_Net_Http_HttpMethod;
	////////////////////////////////////////////////////////////////////////////////
	// System.Net.Http.HttpStatusCode
	var $System_Net_Http_HttpStatusCode = function() {
	};
	$System_Net_Http_HttpStatusCode.__typeName = 'System.Net.Http.HttpStatusCode';
	global.System.Net.Http.HttpStatusCode = $System_Net_Http_HttpStatusCode;
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
			this.$_module.controller($Acute_$ReflectionExtensions.$asAngularServiceName(controllerType), func);
		},
		service: function(T) {
			return function() {
				this.service$1(T, T).call(this);
			};
		},
		service$1: function(TInterface, TImplementation) {
			return function() {
				var implementation = TImplementation;
				var contract = TInterface;
				var functionArrayNotation = $Acute_$ReflectionExtensions.$createFunctionArray(implementation);
				this.$_module.service($Acute_$ReflectionExtensions.$asAngularServiceName(contract), functionArrayNotation);
			};
		},
		$registerRouteProvider: function() {
			var routeProviderType = $Acute_RouteProvider;
			var functionArrayNotation = $Acute_$ReflectionExtensions.$createFunctionArray(routeProviderType);
			this.$_module.provider('AcuteRoute', functionArrayNotation);
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
		},
		$get: function() {
		}
	});
	ss.initClass($Acute_Angular_$AngularServiceAttribute, $asm, {
		get_$serviceName: function() {
			return this.$2$ServiceNameField;
		},
		set_$serviceName: function(value) {
			this.$2$ServiceNameField = value;
		}
	});
	ss.initClass($Acute_Angular_$Http, $asm, {});
	ss.initClass($Acute_Angular_$RouteProvider, $asm, {});
	ss.initInterface($Acute_Http_IHttp, $asm, { getAsync: null });
	ss.initClass($Acute_Http_HttpDefault, $asm, {
		getAsync: function(url) {
			return ss.Task.fromPromise(this.$_angularHttp.get(url), function(data, status) {
				return new $Acute_Http_HttpResponse(status);
			});
		}
	}, null, [$Acute_Http_IHttp]);
	ss.initClass($Acute_Http_HttpRequest, $asm, {
		get_httpMethod: function() {
			return this.$1$HttpMethodField;
		},
		set_httpMethod: function(value) {
			this.$1$HttpMethodField = value;
		},
		get_url: function() {
			return this.$1$UrlField;
		},
		set_url: function(value) {
			this.$1$UrlField = value;
		}
	});
	ss.initClass($Acute_Http_HttpResponse, $asm, {
		get_status: function() {
			return this.$1$StatusField;
		},
		set_status: function(value) {
			this.$1$StatusField = value;
		}
	});
	ss.initClass($System_Net_Http_HttpMethod, $asm, {
		get_method: function() {
			return this.$_method;
		},
		equalsT: function(other) {
			if ($System_Net_Http_HttpMethod.op_Equality(other, null)) {
				return false;
			}
			if (ss.referenceEquals(this.$_method, other.$_method)) {
				return true;
			}
			return ss.referenceEquals(this.$_method, other.$_method);
		},
		equals: function(obj) {
			return this.equalsT(ss.safeCast(obj, $System_Net_Http_HttpMethod));
		},
		getHashCode: function() {
			return ss.getHashCode(this.$_method.toLowerCase());
		},
		toString: function() {
			return this.$_method;
		}
	}, null, [ss.IEquatable]);
	ss.initEnum($System_Net_Http_HttpStatusCode, $asm, { continue$1: 100, switchingProtocols: 101, OK: 200, created: 201, accepted: 202, nonAuthoritativeInformation: 203, noContent: 204, resetContent: 205, partialContent: 206, ambiguous: 300, multipleChoices: 300, moved: 301, movedPermanently: 301, found: 302, redirect: 302, redirectMethod: 303, seeOther: 303, notModified: 304, useProxy: 305, unused: 306, redirectKeepVerb: 307, temporaryRedirect: 307, badRequest: 400, unauthorized: 401, paymentRequired: 402, forbidden: 403, notFound: 404, methodNotAllowed: 405, notAcceptable: 406, proxyAuthenticationRequired: 407, requestTimeout: 408, conflict: 409, gone: 410, lengthRequired: 411, preconditionFailed: 412, requestEntityTooLarge: 413, requestUriTooLong: 414, unsupportedMediaType: 415, requestedRangeNotSatisfiable: 416, expectationFailed: 417, upgradeRequired: 426, internalServerError: 500, notImplemented: 501, badGateway: 502, serviceUnavailable: 503, gatewayTimeout: 504, httpVersionNotSupported: 505 });
	ss.setMetadata($Acute_App, { members: [{ name: 'ConfigureRoutes', type: 8, sname: 'configureRoutes', returnType: Object, params: [$Acute_RouteProvider] }] });
	ss.setMetadata($Acute_RouteProvider, { members: [{ name: '.ctor', type: 1, params: [$Acute_Angular_$RouteProvider] }] });
	ss.setMetadata($Acute_Angular_$Http, { attr: [new $Acute_Angular_$AngularServiceAttribute('$http')] });
	ss.setMetadata($Acute_Angular_$RouteProvider, { attr: [new $Acute_Angular_$AngularServiceAttribute('$routeProvider')] });
	ss.setMetadata($Acute_Http_HttpDefault, { members: [{ name: '.ctor', type: 1, params: [$Acute_Angular_$Http] }] });
	$System_Net_Http_HttpMethod.$getMethod = new $System_Net_Http_HttpMethod('GET');
	$System_Net_Http_HttpMethod.$putMethod = new $System_Net_Http_HttpMethod('PUT');
	$System_Net_Http_HttpMethod.$postMethod = new $System_Net_Http_HttpMethod('POST');
	$System_Net_Http_HttpMethod.$deleteMethod = new $System_Net_Http_HttpMethod('DELETE');
	$System_Net_Http_HttpMethod.$headMethod = new $System_Net_Http_HttpMethod('HEAD');
	$System_Net_Http_HttpMethod.$optionsMethod = new $System_Net_Http_HttpMethod('OPTIONS');
	$System_Net_Http_HttpMethod.$traceMethod = new $System_Net_Http_HttpMethod('TRACE');
	$Acute_$Bootstrapper.$main();
})();
