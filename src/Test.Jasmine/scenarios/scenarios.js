(function() {
	'use strict';
	var $asm = {};
	global.Test = global.Test || {};
	global.Test.Scenarios = global.Test.Scenarios || {};
	global.Test.Scenarios.RouteConfiguration = global.Test.Scenarios.RouteConfiguration || {};
	global.Test.Scenarios.RouteConfiguration.When = global.Test.Scenarios.RouteConfiguration.When || {};
	global.Test.Scenarios.RouteConfiguration.When.WithGenericController = global.Test.Scenarios.RouteConfiguration.When.WithGenericController || {};
	global.Test.Scenarios.RouteConfiguration.When.WithTemplateUrl = global.Test.Scenarios.RouteConfiguration.When.WithTemplateUrl || {};
	ss.initAssembly($asm, 'Scenarios');
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.RouteConfiguration.When.WithGenericController.App
	var $Test_Scenarios_RouteConfiguration_When_WithGenericController_App = function(routeProvider) {
		Acute.App.call(this);
		//route-config with default constuctor and no initializers
		routeProvider.when('/path/for/route/config/with/no/initializers', new (ss.makeGenericType(Acute.RouteConfig$1, [$Test_Scenarios_RouteConfiguration_When_WithGenericController_DefaultController]))());
		//route-config with initalizer
		var $t1 = new (ss.makeGenericType(Acute.RouteConfig$1, [$Test_Scenarios_RouteConfiguration_When_WithGenericController_DefaultController]))();
		$t1.set_templateUrl('/a/template.html');
		routeProvider.when('/path/for/route/config/with/initializer', $t1);
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
	ss.initClass($Test_Scenarios_RouteConfiguration_When_WithGenericController_App, $asm, {}, Acute.App);
	ss.initClass($Test_Scenarios_RouteConfiguration_When_WithGenericController_DefaultController, $asm, {}, Acute.Controller);
	ss.initClass($Test_Scenarios_RouteConfiguration_When_WithTemplateUrl_App, $asm, {
		configureRoutes: function(routeProvider) {
			var $t1 = new Acute.RouteConfig();
			$t1.set_templateUrl('/this/is/a/template.html');
			routeProvider.when('/this/is/a/path', $t1);
		}
	}, Acute.App);
})();
