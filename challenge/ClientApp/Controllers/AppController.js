

class AppCtrl {
    constructor($http) {
        this.$http = $http;
    }

    searchCities(event) {
        var me = this;
        this.$http({
            method: 'GET',
            url: '/suggestions/?q=as&lat=12&long=12'
        }).then(function successCallback(suggestions) {
            me.suggestions = suggestions;
        }, function errorCallback(response) {
            alert('error:' + response);
        });
    }
}

export default AppCtrl;