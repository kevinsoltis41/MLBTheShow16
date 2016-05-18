(function () {
    'use strict';
    var controllerId = 'market';
    angular.module('app').controller(controllerId, ['common', 'datacontext', market]);

    function market(common, datacontext) {
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);

        var vm = this;
        vm.title = 'Dashboard';
        vm.bids = [];

        activate();

        function activate() {
            var promises = [getAllBids()];
            common.activateController(promises, controllerId)
                .then(function () { log('Activated Dashboard View'); });
        }

        function getAllBids() {
            return datacontext.getAllBids().then(function (data) {
                debugger;
                return vm.bids = data;
            });
        }
    }
})();