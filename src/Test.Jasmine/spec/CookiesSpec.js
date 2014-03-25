describe("Cookies service", function () {

    var app = new Test.Scenarios.TestApp();
    
    beforeEach(function () {
        module('ngCookies', 'Test.Scenarios.TestApp');
    });
    
    describe('When setting cookie with string value', function () {

        var $cookies;

        beforeEach(inject(function ($rootScope, _$cookies_, AcuteServicesICookies) {
            
            $cookies = _$cookies_;
            $rootScope.$apply();

            AcuteServicesICookies.set_item("foo", "bar");
            
        }));
        
        it("should call Angular $cookies service", function () {
            expect($cookies.foo).toEqual("bar");
        });
        

    });
    
    describe('When getting cookie with string value', function () {

        var $cookies;
        var cookies;

        beforeEach(inject(function ($rootScope, _$cookies_, AcuteServicesICookies) {

            cookies = AcuteServicesICookies;
            $cookies = _$cookies_;
            $cookies.foo = "bar";
            $rootScope.$apply();

        }));
        
        it("should return cookie value", function () {
            expect(cookies.get_item("foo").toEqual("bar");
        });
        

    });
});