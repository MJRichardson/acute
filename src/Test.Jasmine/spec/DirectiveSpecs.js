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
});