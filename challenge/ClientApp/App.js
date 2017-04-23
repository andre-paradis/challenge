import angular from 'angular';
import AppCtrl from './Controllers/AppController';
import typeahead from 'angular-ui-bootstrap/src/typeahead';



let app = () => {
    return {
        template: require('./app.html'),
        controller: 'AppCtrl',
        controllerAs: 'app'
    }
};


const MODULE_NAME = 'app';

angular.module(MODULE_NAME, [typeahead])
  .directive('app', app)
  .controller('AppCtrl', AppCtrl);

export default MODULE_NAME;