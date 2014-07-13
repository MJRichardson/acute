(function() {
	'use strict';
	var $asm = {};
	global.Test = global.Test || {};
	global.Test.Scenarios = global.Test.Scenarios || {};
	global.Test.Scenarios.Controllers = global.Test.Scenarios.Controllers || {};
	global.Test.Scenarios.Directives = global.Test.Scenarios.Directives || {};
	global.Test.Scenarios.Directives.InterDirectiveDependency = global.Test.Scenarios.Directives.InterDirectiveDependency || {};
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
	var $Test_Scenarios_Controllers_Controller = function(scope) {
		this.$_simpleString = null;
		Acute.Controller.call(this);
		this.$_simpleString = 'Yabba dabba doo!';
		var simpleStringFunc = ss.mkdel(this, function() {
			return this.$_simpleString;
		});
		scope.get_model().SimpleString = simpleStringFunc;
		var $t1 = [];
		ss.add($t1, 'Eenie');
		null;
		ss.add($t1, 'Meenie');
		null;
		scope.get_model().FromObjectInitializer = $t1;
	};
	$Test_Scenarios_Controllers_Controller.__typeName = 'Test.Scenarios.Controllers.Controller';
	global.Test.Scenarios.Controllers.Controller = $Test_Scenarios_Controllers_Controller;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Directives.TestDirectiveRestrictedToAttribute
	var $Test_Scenarios_Directives_TestDirectiveRestrictedToAttribute = function() {
		Acute.Directive.call(this);
	};
	$Test_Scenarios_Directives_TestDirectiveRestrictedToAttribute.__typeName = 'Test.Scenarios.Directives.TestDirectiveRestrictedToAttribute';
	global.Test.Scenarios.Directives.TestDirectiveRestrictedToAttribute = $Test_Scenarios_Directives_TestDirectiveRestrictedToAttribute;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Directives.TestDirectiveRestrictedToAttributeOrElement
	var $Test_Scenarios_Directives_TestDirectiveRestrictedToAttributeOrElement = function() {
		Acute.Directive.call(this);
	};
	$Test_Scenarios_Directives_TestDirectiveRestrictedToAttributeOrElement.__typeName = 'Test.Scenarios.Directives.TestDirectiveRestrictedToAttributeOrElement';
	global.Test.Scenarios.Directives.TestDirectiveRestrictedToAttributeOrElement = $Test_Scenarios_Directives_TestDirectiveRestrictedToAttributeOrElement;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Directives.TestDirectiveRestrictedToClass
	var $Test_Scenarios_Directives_TestDirectiveRestrictedToClass = function() {
		Acute.Directive.call(this);
	};
	$Test_Scenarios_Directives_TestDirectiveRestrictedToClass.__typeName = 'Test.Scenarios.Directives.TestDirectiveRestrictedToClass';
	global.Test.Scenarios.Directives.TestDirectiveRestrictedToClass = $Test_Scenarios_Directives_TestDirectiveRestrictedToClass;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Directives.TestDirectiveRestrictedToElement
	var $Test_Scenarios_Directives_TestDirectiveRestrictedToElement = function() {
		Acute.Directive.call(this);
	};
	$Test_Scenarios_Directives_TestDirectiveRestrictedToElement.__typeName = 'Test.Scenarios.Directives.TestDirectiveRestrictedToElement';
	global.Test.Scenarios.Directives.TestDirectiveRestrictedToElement = $Test_Scenarios_Directives_TestDirectiveRestrictedToElement;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Directives.TestDirectiveWhichModifiesScope
	var $Test_Scenarios_Directives_TestDirectiveWhichModifiesScope = function(scope) {
		Acute.Directive.call(this);
		scope.get_model().DuckCount = 5;
	};
	$Test_Scenarios_Directives_TestDirectiveWhichModifiesScope.__typeName = 'Test.Scenarios.Directives.TestDirectiveWhichModifiesScope';
	global.Test.Scenarios.Directives.TestDirectiveWhichModifiesScope = $Test_Scenarios_Directives_TestDirectiveWhichModifiesScope;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Directives.TestDirectiveWithBoundProperties
	var $Test_Scenarios_Directives_TestDirectiveWithBoundProperties = function() {
		Acute.Directive.call(this);
	};
	$Test_Scenarios_Directives_TestDirectiveWithBoundProperties.__typeName = 'Test.Scenarios.Directives.TestDirectiveWithBoundProperties';
	global.Test.Scenarios.Directives.TestDirectiveWithBoundProperties = $Test_Scenarios_Directives_TestDirectiveWithBoundProperties;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Directives.TestDirectiveWithEvaluatedProperty
	var $Test_Scenarios_Directives_TestDirectiveWithEvaluatedProperty = function() {
		Acute.Directive.call(this);
	};
	$Test_Scenarios_Directives_TestDirectiveWithEvaluatedProperty.__typeName = 'Test.Scenarios.Directives.TestDirectiveWithEvaluatedProperty';
	global.Test.Scenarios.Directives.TestDirectiveWithEvaluatedProperty = $Test_Scenarios_Directives_TestDirectiveWithEvaluatedProperty;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Directives.TestDirectiveWithTemplate
	var $Test_Scenarios_Directives_TestDirectiveWithTemplate = function() {
		Acute.Directive.call(this);
	};
	$Test_Scenarios_Directives_TestDirectiveWithTemplate.__typeName = 'Test.Scenarios.Directives.TestDirectiveWithTemplate';
	global.Test.Scenarios.Directives.TestDirectiveWithTemplate = $Test_Scenarios_Directives_TestDirectiveWithTemplate;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Directives.InterDirectiveDependency.DirectiveA
	var $Test_Scenarios_Directives_InterDirectiveDependency_DirectiveA = function(scope) {
		this.$_scope = null;
		Acute.Directive.call(this);
		this.$_scope = scope;
	};
	$Test_Scenarios_Directives_InterDirectiveDependency_DirectiveA.__typeName = 'Test.Scenarios.Directives.InterDirectiveDependency.DirectiveA';
	global.Test.Scenarios.Directives.InterDirectiveDependency.DirectiveA = $Test_Scenarios_Directives_InterDirectiveDependency_DirectiveA;
	////////////////////////////////////////////////////////////////////////////////
	// Test.Scenarios.Directives.InterDirectiveDependency.DirectiveB
	var $Test_Scenarios_Directives_InterDirectiveDependency_DirectiveB = function(directiveA) {
		Acute.Directive.call(this);
		directiveA.set_animal('sheep');
	};
	$Test_Scenarios_Directives_InterDirectiveDependency_DirectiveB.__typeName = 'Test.Scenarios.Directives.InterDirectiveDependency.DirectiveB';
	global.Test.Scenarios.Directives.InterDirectiveDependency.DirectiveB = $Test_Scenarios_Directives_InterDirectiveDependency_DirectiveB;
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
	var $Test_Scenarios_Http_HttpTestController = function(http, scope) {
		Acute.Controller.call(this);
		scope.get_model().getStringData = function() {
			http.getAsync('/foo/bar').continueWith(function(task) {
				scope.get_model().status = task.getResult().get_status();
				scope.get_model().data = task.getResult().get_data();
			});
		};
		scope.get_model().getObjectData = function() {
			http.getAsync('/foo/bar').continueWith(function(task1) {
				scope.get_model().status = task1.getResult().get_status();
				var dataObject = task1.getResult().get_data();
				scope.get_model().dataObjectId = dataObject.id;
			});
		};
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
		}
	}, Acute.Controller);
	ss.initClass($Test_Scenarios_Directives_TestDirectiveRestrictedToAttribute, $asm, {
		get_template: function() {
			return 'incy wincy spider';
		}
	}, Acute.Directive);
	ss.initClass($Test_Scenarios_Directives_TestDirectiveRestrictedToAttributeOrElement, $asm, {
		get_template: function() {
			return 'incy wincy spider';
		}
	}, Acute.Directive);
	ss.initClass($Test_Scenarios_Directives_TestDirectiveRestrictedToClass, $asm, {
		get_template: function() {
			return '{{MiceCount}} blind mice';
		}
	}, Acute.Directive);
	ss.initClass($Test_Scenarios_Directives_TestDirectiveRestrictedToElement, $asm, {
		get_template: function() {
			return 'incy wincy spider';
		}
	}, Acute.Directive);
	ss.initClass($Test_Scenarios_Directives_TestDirectiveWhichModifiesScope, $asm, {
		get_template: function() {
			return '{{DuckCount}} little ducks went out one day';
		}
	}, Acute.Directive);
	ss.initClass($Test_Scenarios_Directives_TestDirectiveWithBoundProperties, $asm, {
		get_template: function() {
			return '{{lowercaseword}} {{Uppercaseword}} {{multiWordCamelCase}} {{MultiWordPascalCase}}';
		}
	}, Acute.Directive);
	ss.initClass($Test_Scenarios_Directives_TestDirectiveWithEvaluatedProperty, $asm, {
		get_template: function() {
			return "And all the people sing '{{song}}'.";
		}
	}, Acute.Directive);
	ss.initClass($Test_Scenarios_Directives_TestDirectiveWithTemplate, $asm, {
		get_template: function() {
			return 'three blind mice';
		}
	}, Acute.Directive);
	ss.initClass($Test_Scenarios_Directives_InterDirectiveDependency_DirectiveA, $asm, {
		set_animal: function(value) {
			this.$_scope.get_model().Animal = value;
		},
		get_template: function() {
			return 'Old MacDonald has a farm, E-I-E-I-O. And on that farm he had a {{Animal}}';
		}
	}, Acute.Directive);
	ss.initClass($Test_Scenarios_Directives_InterDirectiveDependency_DirectiveB, $asm, {}, Acute.Directive);
	ss.initClass($Test_Scenarios_Http_FooBar, $asm, {});
	ss.initClass($Test_Scenarios_Http_HttpTestApp, $asm, {}, Acute.App);
	ss.initClass($Test_Scenarios_Http_HttpTestController, $asm, {}, Acute.Controller);
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
	ss.initClass($Test_Scenarios_Scenarios_Location_LocationTestApp, $asm, {}, Acute.App);
	ss.initClass($Test_Scenarios_Scenarios_Location_LocationTestController, $asm, {}, Acute.Controller);
	ss.setMetadata($Test_Scenarios_TestApp, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Controllers_App, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Controllers_Controller, { members: [{ name: '.ctor', type: 1, params: [Acute.Scope] }] });
	ss.setMetadata($Test_Scenarios_Directives_TestDirectiveRestrictedToAttribute, { attr: [new Acute.DirectiveDomTypesAttribute(1)], members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Directives_TestDirectiveRestrictedToAttributeOrElement, { attr: [new Acute.DirectiveDomTypesAttribute(3)], members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Directives_TestDirectiveRestrictedToClass, { attr: [new Acute.DirectiveDomTypesAttribute(4), new Acute.BindDomAttributeToDirectiveScopeAttribute('MiceCount', 0)], members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Directives_TestDirectiveRestrictedToElement, { attr: [new Acute.DirectiveDomTypesAttribute(2)], members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Directives_TestDirectiveWhichModifiesScope, { members: [{ name: '.ctor', type: 1, params: [Acute.Scope] }] });
	ss.setMetadata($Test_Scenarios_Directives_TestDirectiveWithBoundProperties, { attr: [new Acute.BindDomAttributeToDirectiveScopeAttribute('lowercaseword', 0), new Acute.BindDomAttributeToDirectiveScopeAttribute('Uppercaseword', 0), new Acute.BindDomAttributeToDirectiveScopeAttribute('multiWordCamelCase', 0), new Acute.BindDomAttributeToDirectiveScopeAttribute('MultiWordPascalCase', 0)], members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Directives_TestDirectiveWithEvaluatedProperty, { attr: [new Acute.BindDomAttributeToDirectiveScopeAttribute('song', 1)], members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Directives_TestDirectiveWithTemplate, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Directives_InterDirectiveDependency_DirectiveA, { attr: [new Acute.BindDomAttributeToDirectiveScopeAttribute('Animal', 0)], members: [{ name: '.ctor', type: 1, params: [Acute.Scope] }] });
	ss.setMetadata($Test_Scenarios_Directives_InterDirectiveDependency_DirectiveB, { members: [{ name: '.ctor', type: 1, params: [$Test_Scenarios_Directives_InterDirectiveDependency_DirectiveA] }] });
	ss.setMetadata($Test_Scenarios_Http_FooBar, { members: [{ name: '.ctor', type: 1, params: [], sname: '$ctor', sm: true }] });
	ss.setMetadata($Test_Scenarios_Http_HttpTestApp, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Http_HttpTestController, { members: [{ name: '.ctor', type: 1, params: [Acute.Services.IHttp, Acute.Scope] }] });
	ss.setMetadata($Test_Scenarios_RouteConfiguration_When_WithGenericController_App, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_RouteConfiguration_When_WithGenericController_DefaultController, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_RouteConfiguration_When_WithTemplateUrl_App, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Scenarios_Location_LocationTestApp, { members: [{ name: '.ctor', type: 1, params: [] }] });
	ss.setMetadata($Test_Scenarios_Scenarios_Location_LocationTestController, { members: [{ name: '.ctor', type: 1, params: [Acute.Services.Location] }] });
})();
Acute.Bootstrap();