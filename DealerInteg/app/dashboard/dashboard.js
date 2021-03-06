﻿(function () {
    'use strict';
    var controllerId = 'dashboard';
    angular.module('app').controller(controllerId, ['common', 'dealerportalService', dashboard]);

    function dashboard(common, dealerportalService) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.news = {
            title: 'Hot Towel Angular',
            description: 'Hot Towel Angular is a SPA template for Angular developers.'
        };
        vm.messageCount = 0;
        vm.people = [];
        vm.title = 'Dashboard';

        activate();

        function activate() {
            var promises = [getMessageCount(), getPeople()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Dashboard View'); });
        }

        function getMessageCount() {
            return dealerportalService.deleteItem().then(function (data) {
                return vm.messageCount = data;
            });
        }

        function getPeople() {
            return dealerportalService.deleteItem().then(function (data) {
                return vm.people = data;
            });
        }
    }
})();