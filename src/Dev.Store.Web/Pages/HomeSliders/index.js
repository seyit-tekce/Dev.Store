var l = abp.localization.getResource("Store");

var homeSliders = {
    defines: {
        createModal: new abp.ModalManager(abp.appPath + 'HomeSliders/CreateModal'),
        editModal: new abp.ModalManager(abp.appPath + 'HomeSliders/EditModal'),
        detailModal: new abp.ModalManager(abp.appPath + 'HomeSliders/DetailModal'),
        load: null,
        grid: function (e) {
            return $("#homeSliderGrid").data("kendoGrid")
        }
    },
    functions: {
        detail: function (e) {
            e.preventDefault();
            var recordId = e.currentTarget.dataset["id"];
            homeSliders.defines.detailModal.open({ id: recordId });
        },
        edit: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            homeSliders.defines.editModal.open({ id: recordId });
        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("DeletionConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        dev.store.homeSliders.homeSlider.delete(recordId)
                            .then(function () {
                                abp.notify.success(l("SuccessfullyDeleted"));
                                homeSliders.defines.grid().dataSource.read();
                            });
                    }
                });
        },
        create: function (e, type) {
            homeSliders.defines.load = new Loading($(e));
            homeSliders.defines.load.Start();
            homeSliders.defines.createModal.open({ type: type });
        }
    },
    init: function () {
        homeSliders.defines.createModal.onResult(function (e, a) {
            homeSliders.defines.grid().dataSource.read();
            abp.notify.success(l("SuccessfullyAdded"));
        });
        homeSliders.defines.editModal.onResult(function () {
            homeSliders.defines.grid().dataSource.read();
            abp.notify.success(l("SuccessfullyUpdated"));
        });
        homeSliders.defines.createModal.onOpen(function () {
            homeSliders.defines.load.Done();
        });

    }
}
homeSliders.init();