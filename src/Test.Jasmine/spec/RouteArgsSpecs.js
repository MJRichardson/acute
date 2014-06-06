describe("when passing route arguments", function () {
    
    beforeEach(function () {

    });

    it("RouteArgs service should expose actual arguments", function () {
        var routeArgs = new Acute.Services.RouteArgs( { id: 5, name: 'Frodo' });
        expect(routeArgs.get_args().id).toEqual(5);
        expect(routeArgs.get_args().name).toEqual('Frodo');
    });

});