import typeahead from 'angular-ui-bootstrap/src/typeahead/index-nocss.js';


class AppCtrl {
    constructor($http) {
        this.$http = $http;
    }

    /*
     * fetch relevant cities from the api.  Returns a promise used by the bootstrap typeahead component
     */
    searchCities(query) {
        return this.$http({
            method: 'GET',
            url: `/suggestions/?q=${query}&lat=12&long=12`
        }).then(function successCallback(response) {
            return response.data.suggestions;
        }, function errorCallback(response) {
            alert('error:' + response);
        });
    }

    showCity(event) {
        alert(`You selected this city: ${this.city}`);
    }
}

export default AppCtrl;