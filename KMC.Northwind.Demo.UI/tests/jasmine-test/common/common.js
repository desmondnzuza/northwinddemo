var apiUrl = 'http://localhost:59192/api/';
var appName = 'app';

var failTest = function (error) {
    expect(error).toBeUndefined();
};

var verifyErrorExits = function (error) {
    expect(error).toBeUndefined();
}

var passTheTest = function () {
    expect(1).toBe(1);
};