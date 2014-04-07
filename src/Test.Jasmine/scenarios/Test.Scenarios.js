(function() {
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
	global.Test.Scenarios.Scenarios = global.Test.Scenarios.Scenarios || {};
	global.Test.Scenarios.Scenarios.Location = global.Test.Scenarios.Scenarios.Location || {};
	ss.initAssembly($asm, 'Test.Scenarios');
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.TestApp
	var $Test_Scenarios_TestApp = function() {
		Acute.App.call(this);
	};
	$Test_Scenarios_TestApp.__typeName = 'Test.Scenarios.TestApp';
	global.Test.Scenarios.TestApp = $Test_Scenarios_TestApp;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Controllers.App
	var $Test_Scenarios_Controllers_App = function() {
		Acute.App.call(this);
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
	};
	$Test_Scenarios_Http_HttpTestApp.__typeName = 'Test.Scenarios.Http.HttpTestApp';
	global.Test.Scenarios.Http.HttpTestApp = $Test_Scenarios_Http_HttpTestApp;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Http.HttpTestController
	var $Test_Scenarios_Http_HttpTestController = function(http) {
		this.$_http = null;
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
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Scenarios.Location.LocationTestApp
	var $Test_Scenarios_Scenarios_Location_LocationTestApp = function() {
		Acute.App.call(this);
	};
	$Test_Scenarios_Scenarios_Location_LocationTestApp.__typeName = 'Test.Scenarios.Scenarios.Location.LocationTestApp';
	global.Test.Scenarios.Scenarios.Location.LocationTestApp = $Test_Scenarios_Scenarios_Location_LocationTestApp;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Scenarios.Location.LocationTestController
	var $Test_Scenarios_Scenarios_Location_LocationTestController = function(location) {
		this.$_location = null;
		Acute.Controller.call(this);
		this.$_location = location;
	};
	$Test_Scenarios_Scenarios_Location_LocationTestController.__typeName = 'Test.Scenarios.Scenarios.Location.LocationTestController';
	global.Test.Scenarios.Scenarios.Location.LocationTestController = $Test_Scenarios_Scenarios_Location_LocationTestController;
	ss.initClass($Test_Scenarios_TestApp, $asm, {}, Acute.App);
	ss.initClass($Test_Scenarios_Controllers_App, $asm, {}, Acute.App);
	ss.initClass($Test_Scenarios_Controllers_Controller, $asm, {
		simpleString: function() {
			return this.$_simpleString;
		},
		control: function(scope) {
			var simpleStringFunc = ss.mkdel(this, function() {
				return this.$_simpleString;
			});
			scope.SimpleString = simpleStringFunc;
		}
	}, Acute.Controller);
	ss.initClass($Test_Scenarios_Http_FooBar, $asm, {});
	ss.initClass($Test_Scenarios_Http_HttpTestApp, $asm, {}, Acute.App);
	ss.initClass($Test_Scenarios_Http_HttpTestController, $asm, {
		control: function(scope) {
			scope.getStringData = ss.mkdel(this, function() {
				this.$_http.getAsync('/foo/bar').continueWith(function(task) {
					scope.status = task.getResult().get_status();
					scope.data = task.getResult().get_data();
				});
			});
			scope.getObjectData = ss.mkdel(this, function() {
				this.$_http.getAsync('/foo/bar').continueWith(function(task1) {
					scope.status = task1.getResult().get_status();
					var dataObject = task1.getResult().get_data();
					scope.dataObjectId = dataObject.id;
				});
			});
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
	ss.initClass($Test_Scenarios_RouteConfiguration_When_WithGenericController_DefaultController, $asm, {
		control: function(scope) {
		}
	}, Acute.Controller);
	ss.initClass($Test_Scenarios_RouteConfiguration_When_WithTemplateUrl_App, $asm, {
		configureRoutes: function(routeProvider) {
			var $t1 = new Acute.RouteConfig();
			$t1.set_templateUrl('/this/is/a/template.html');
			routeProvider.when('/this/is/a/path', $t1);
		}
	}, Acute.App);
	ss.initClass($Test_Scenarios_Scenarios_Location_LocationTestApp, $asm, {}, Acute.App);
	ss.initClass($Test_Scenarios_Scenarios_Location_LocationTestController, $asm, {
		control: function(scope) {
		}
	}, Acute.Controller);
	ss.setMetadata($Test_Scenarios_TestApp, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Controllers_App, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Controllers_Controller, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Http_FooBar, { members: [{ name: '.ctor', type: 1, params: [], sname: '$ctor', sm: true }] });
	ss.setMetadata($Test_Scenarios_Http_HttpTestApp, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Http_HttpTestController, { members: [{ name: '.ctor', type: 1, params: [Acute.Services.IHttp] }] });
	ss.setMetadata($Test_Scenarios_RouteConfiguration_When_WithGenericController_App, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_RouteConfiguration_When_WithGenericController_DefaultController, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_RouteConfiguration_When_WithTemplateUrl_App, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Scenarios_Location_LocationTestApp, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Scenarios_Location_LocationTestController, { members: [{ name: '.ctor', type: 1, params: [Acute.Services.Location] }] });
})();
Acute.Bootstrap();