﻿(function() {
	'use strict';
	var $asm = {};
	global.Test = global.Test || {};
	global.Test.Scenarios = global.Test.Scenarios || {};
	global.Test.Scenarios.Controllers = global.Test.Scenarios.Controllers || {};
	global.Test.Scenarios.Http = global.Test.Scenarios.Http || {};
	global.Test.Scenarios.RouteConfiguration = global.Test.Scenarios.RouteConfiguration || {};
	global.Test.Scenarios.RouteConfiguration.When = global.Test.Scenarios.RouteConfiguration.When || {};
	global.Test.Scenarios.RouteConfiguration.When.WithGenericController = global.Test.Scenarios.RouteConfiguration.When.WithGenericController || {};
	global.Test.Scenarios.RouteConfiguration.When.WithTemplateUrl = global.Test.Scenarios.RouteConfiguration.When.WithTemplateUrl || {};
	ss.initAssembly($asm, 'Scenarios');
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Controllers.App
	var $Test_Scenarios_Controllers_App = function() {
		Acute.App.call(this);
		this.controller($Test_Scenarios_Controllers_Controller).call(this);
	};
	$Test_Scenarios_Controllers_App.__typeName = 'Test.Scenarios.Controllers.App';
	global.Test.Scenarios.Controllers.App = $Test_Scenarios_Controllers_App;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Controllers.Controller
	var $Test_Scenarios_Controllers_Controller = function() {
		this.$_simpleString = null;
		Acute.Controller.call(this);
		this.$_simpleString = 'Yabba dabba doo!';
	};
	$Test_Scenarios_Controllers_Controller.__typeName = 'Test.Scenarios.Controllers.Controller';
	global.Test.Scenarios.Controllers.Controller = $Test_Scenarios_Controllers_Controller;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Http.FooBar
	var $Test_Scenarios_Http_FooBar = function() {
	};
	$Test_Scenarios_Http_FooBar.__typeName = 'Test.Scenarios.Http.FooBar';
	$Test_Scenarios_Http_FooBar.createInstance = function() {
		return $Test_Scenarios_Http_FooBar.$ctor();
	};
	$Test_Scenarios_Http_FooBar.$ctor = function() {
		var $this = {};
		$this.id = 0;
		$this.name = null;
		return $this;
	};
	global.Test.Scenarios.Http.FooBar = $Test_Scenarios_Http_FooBar;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Http.HttpTestApp
	var $Test_Scenarios_Http_HttpTestApp = function() {
		Acute.App.call(this);
		this.controller($Test_Scenarios_Http_HttpTestController).call(this);
	};
	$Test_Scenarios_Http_HttpTestApp.__typeName = 'Test.Scenarios.Http.HttpTestApp';
	global.Test.Scenarios.Http.HttpTestApp = $Test_Scenarios_Http_HttpTestApp;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Http.HttpTestController
	var $Test_Scenarios_Http_HttpTestController = function(http) {
		this.$_http = null;
		this.$2$StatusField = 0;
		this.$2$DataField = null;
		this.$2$DataObjectIdField = 0;
		Acute.Controller.call(this);
		this.$_http = http;
	};
	$Test_Scenarios_Http_HttpTestController.__typeName = 'Test.Scenarios.Http.HttpTestController';
	global.Test.Scenarios.Http.HttpTestController = $Test_Scenarios_Http_HttpTestController;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.RouteConfiguration.When.WithGenericController.App
	var $Test_Scenarios_RouteConfiguration_When_WithGenericController_App = function() {
		Acute.App.call(this);
	};
	$Test_Scenarios_RouteConfiguration_When_WithGenericController_App.__typeName = 'Test.Scenarios.RouteConfiguration.When.WithGenericController.App';
	global.Test.Scenarios.RouteConfiguration.When.WithGenericController.App = $Test_Scenarios_RouteConfiguration_When_WithGenericController_App;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.RouteConfiguration.When.WithGenericController.DefaultController
	var $Test_Scenarios_RouteConfiguration_When_WithGenericController_DefaultController = function() {
		Acute.Controller.call(this);
	};
	$Test_Scenarios_RouteConfiguration_When_WithGenericController_DefaultController.__typeName = 'Test.Scenarios.RouteConfiguration.When.WithGenericController.DefaultController';
	global.Test.Scenarios.RouteConfiguration.When.WithGenericController.DefaultController = $Test_Scenarios_RouteConfiguration_When_WithGenericController_DefaultController;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.RouteConfiguration.When.WithTemplateUrl.App
	var $Test_Scenarios_RouteConfiguration_When_WithTemplateUrl_App = function() {
		Acute.App.call(this);
	};
	$Test_Scenarios_RouteConfiguration_When_WithTemplateUrl_App.__typeName = 'Test.Scenarios.RouteConfiguration.When.WithTemplateUrl.App';
	global.Test.Scenarios.RouteConfiguration.When.WithTemplateUrl.App = $Test_Scenarios_RouteConfiguration_When_WithTemplateUrl_App;
	ss.initClass($Test_Scenarios_Controllers_App, $asm, {}, Acute.App);
	ss.initClass($Test_Scenarios_Controllers_Controller, $asm, {
		simpleString: function() {
			return this.$_simpleString;
		}
	}, Acute.Controller);
	ss.initClass($Test_Scenarios_Http_FooBar, $asm, {});
	ss.initClass($Test_Scenarios_Http_HttpTestApp, $asm, {}, Acute.App);
	ss.initClass($Test_Scenarios_Http_HttpTestController, $asm, {
		get_status: function() {
			return this.$2$StatusField;
		},
		set_status: function(value) {
			this.$2$StatusField = value;
		},
		get_data: function() {
			return this.$2$DataField;
		},
		set_data: function(value) {
			this.$2$DataField = value;
		},
		get_dataObjectId: function() {
			return this.$2$DataObjectIdField;
		},
		set_dataObjectId: function(value) {
			this.$2$DataObjectIdField = value;
		},
		getStringData: function() {
			this.$_http.getAsync('/foo/bar').continueWith(ss.mkdel(this, function(task) {
				this.set_status(task.getResult().get_status());
				this.set_data(task.getResult().get_data());
			}));
		},
		getObjectData: function() {
			this.$_http.getAsync('/foo/bar').continueWith(ss.mkdel(this, function(task) {
				this.set_status(task.getResult().get_status());
				var dataObject = task.getResult().get_data();
				this.set_dataObjectId(dataObject.id);
			}));
		}
	}, Acute.Controller);
	ss.initClass($Test_Scenarios_RouteConfiguration_When_WithGenericController_App, $asm, {
		configureRoutes: function(routeProvider) {
			//route-config with default constuctor and no initializers
			routeProvider.when('/path/for/route/config/with/no/initializers', new (ss.makeGenericType(Acute.RouteConfig$1, [$Test_Scenarios_RouteConfiguration_When_WithGenericController_DefaultController]))());
			//route-config with initalizer
			var $t1 = new (ss.makeGenericType(Acute.RouteConfig$1, [$Test_Scenarios_RouteConfiguration_When_WithGenericController_DefaultController]))();
			$t1.set_templateUrl('/a/template.html');
			routeProvider.when('/path/for/route/config/with/initializer', $t1);
		}
	}, Acute.App);
	ss.initClass($Test_Scenarios_RouteConfiguration_When_WithGenericController_DefaultController, $asm, {}, Acute.Controller);
	ss.initClass($Test_Scenarios_RouteConfiguration_When_WithTemplateUrl_App, $asm, {
		configureRoutes: function(routeProvider) {
			var $t1 = new Acute.RouteConfig();
			$t1.set_templateUrl('/this/is/a/template.html');
			routeProvider.when('/this/is/a/path', $t1);
		}
	}, Acute.App);
	ss.setMetadata($Test_Scenarios_Controllers_Controller, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Http_HttpTestController, { members: [{ name: '.ctor', type: 1, params: [Acute.Http.IHttp] }] });
})();
