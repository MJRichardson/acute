describe("When creating a directive", function () {

    beforeEach(function() {
            module('Test.Scenarios.TestApp');
    });

    describe("With a template", function () {

        var element;

        beforeEach(function() {

            var html = "<div test-directive-with-template></div>";

            inject(function($compile, $rootScope) {
                var scope = $rootScope.$new();
                element = angular.element(html);
                var compiled = $compile(element);
                compiled(scope);
                scope.$digest();
            });
        });

        it("Should set the element content to the template", function() {
            expect(element.text()).toBe("three blind mice");
        });
    });

    describe("With a bound property", function () {

        var element;

        beforeEach(function() {

            var html = "<div test-directive-with-bound-properties lowercaseword=\"do\" Uppercaseword=\"rae\" multi-word-camel-case=\"mi\" multi-word-pascal-case=\"fa\"></div>";

            inject(function($compile, $rootScope) {
                var scope = $rootScope.$new();
                scope.do = "do";
                scope.rae = "rae";
                scope.mi = "mi";
                scope.fa = "fa";
                element = angular.element(html);
                var compiled = $compile(element);
                compiled(scope);
                scope.$digest();
            });
        });

        it("Should bind the attribute values to the template", function() {
            expect(element.text()).toBe("do rae mi fa");
        });
    });

    describe("With an evaluated property", function () {

        var element;

        beforeEach(function() {

            var html = "<div test-directive-with-evaluated-property song=\"Old MacDonald had a farm, E-I-E-I-O. And on that farm he had a {{animal}}, E-I-E-I-O\"></div>";

            inject(function($compile, $rootScope) {
                var scope = $rootScope.$new();
                scope.animal = "duck";
                element = angular.element(html);
                var compiled = $compile(element);
                compiled(scope);
                scope.$digest();
            });
        });

        it("Should evaluate the attribute values", function() {
            expect(element.text()).toBe("And all the people sing 'Old MacDonald had a farm, E-I-E-I-O. And on that farm he had a duck, E-I-E-I-O'.");
        });
    });

    describe("Restricted to attribute", function () {

        var element;

        beforeEach(function() {

            var html = "<test-directive-restricted-to-attribute>mary had a little lamb</test-directive-restricted-to-attribute>";

            inject(function($compile, $rootScope) {
                var scope = $rootScope.$new();
                element = angular.element(html);
                var compiled = $compile(element);
                compiled(scope);
                scope.$digest();
            });
        });

        it("should not bind to matching element", function() {
            expect(element.text()).toBe("mary had a little lamb");
            expect(element.text()).not.toBe("incy wincy spider");
        });
    });

    describe("restricted to element", function () {

        var elementDom;
        var attributeDom;

        beforeEach(function() {

            var elementHtml = "<test-directive-restricted-to-element>mary had a little lamb</test-directive-restricted-to-element>";
            var attributeHtml = "<div test-directive-restricted-to-element>mary had a little lamb</div>";

            inject(function($compile, $rootScope) {
                var scope = $rootScope.$new();
                elementDom = angular.element(elementHtml);
                attributeDom = angular.element(attributeHtml);
                $compile(elementDom);
                $compile(attributeDom);
            });
        });

        it("should bind to matching element", function() {
            expect(elementDom.text()).toBe("incy wincy spider");
        });

        it("should not bind to matching attribute", function() {
            expect(attributeDom.text()).not.toBe("incy wincy spider");
        });
    });

    describe("restricted to element or attribute", function () {

        var elementDom;
        var attributeDom;

        beforeEach(function() {

            var elementHtml = "<test-directive-restricted-to-attribute-or-element>mary had a little lamb</test-directive-restricted-to-attribute-or-element>";
            var attributeHtml = "<div test-directive-restricted-to-attribute-or-element>mary had a little lamb</div>";

            inject(function($compile, $rootScope) {
                var scope = $rootScope.$new();
                elementDom = angular.element(elementHtml);
                attributeDom = angular.element(attributeHtml);
                $compile(elementDom);
                $compile(attributeDom);
            });
        });

        it("should bind to matching element", function() {
            expect(elementDom.text()).toBe("incy wincy spider");
        });

        it("should bind to matching attribute", function() {
            expect(attributeDom.text()).toBe("incy wincy spider");
        });
    });

    describe("restricted to class", function () {

        var element;

        beforeEach(function() {

            var html = "<div class=\"test-directive-restricted-to-class\" mice-count=\"3\"></div>";

            inject(function($compile, $rootScope) {
                var scope = $rootScope.$new();
                element = angular.element(html);
                var compiled = $compile(element);
                compiled(scope);
                scope.$digest();
            });
        });

        it("Should apply the directive", function() {
            expect(element.text()).toBe("3 blind mice");
        });
    });
});