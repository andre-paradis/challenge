import typeahead from 'angular-ui-bootstrap/src/typeahead';


class AppCtrl {
    constructor($http, $scope) {
        this.$http = $http;
        this.$scope = $scope;
        this.$scope.city = '';

    
    }

    resetCities() {
        this.cities = [];
    }

    /*
     * fetch relevant cities from the api.  Returns a promise used by the bootstrap typeahead component
     */
    searchCities(query) {
        var me = this;
        me.noCities = false;
        return this.$http({
            method: 'GET',
            url: `/suggestions/?q=${query}&lat=12&long=12`
        }).then(function successCallback(response) {
            me.cities = response.data.suggestions;
            return response.data.suggestions;
        }, function errorCallback(response) {
            if(response.status == 404) {
                // no cities found
                me.noCities = true;
                me.cities = [];
            }
        });
    }

    showCity(event) {
        alert(`You selected this city: ${this.city}`);
    }
}

export default AppCtrl;