describe("Cookies service", function () {

    //var app = new Test.Scenarios.TestApp();

    var $cookies;
    var $cookieStore;
    var acuteCookiesService;
    
    beforeEach(function () {
        module('Test.Scenarios.TestApp');

        inject(function ($rootScope, _$cookies_, _$cookieStore_) {
            
            $cookies = _$cookies_;
            $cookieStore = _$cookieStore_;
            acuteCookiesService = new Acute.Services.Cookies($cookieStore, $cookies);
            
        });
    });
    
    describe('When setting cookie with string value', function () {

        beforeEach(function() {
            acuteCookiesService.set_item("foo", "bar");
        });
        
        it("should call Angular $cookies service", function () {
            expect($cookies.foo).toEqual("bar");
        });
        

    });
    
    describe('When getting cookie with string value', function () {

        beforeEach(function () {
            $cookies.foo = "bar";
        });
        
        it("should return cookie value", function () {
            expect(acuteCookiesService.get_item("foo")).toEqual("bar");
        });
        

    });
});