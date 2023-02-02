var l = abp.localization.getResource("Store");
var cloudinarySettings = {
    defines: {
        service: dev.store.cloudinarySettings.cloudinarySetting,
        createModal: new abp.ModalManager(abp.appPath + 'cloudinarySettings/createmodal'),
        editModal: new abp.ModalManager(abp.appPath + 'cloudinarySettings/editmodal'),
        grid: function () { return $("#cloudinarySettings").data("kendoGrid") }
    },
    functions: {
        create: function (e) {
            var load = new Loading($(e));
            load.Start();
            cloudinarySettings.defines.createModal.onOpen(function () {
                load.Done();
            });
            cloudinarySettings.defines.createModal.open();
            cloudinarySettings.defines.createModal.onResult(function (e, a) {
                cloudinarySettings.defines.grid().dataSource.read();
                abp.notify.success(l("SuccessfullyAdded"));

            });
        },
        edit: function (e) {
            var load = new Loading($(e.target));
            load.Start();
            cloudinarySettings.defines.editModal.onOpen(function () {
                load.Done();
            });
            cloudinarySettings.defines.editModal.open({ id: e.currentTarget.dataset["id"] });
            cloudinarySettings.defines.editModal.onResult(function () {
                cloudinarySettings.defines.grid().dataSource.read();
                abp.notify.success(l("SuccessfullyUpdated"));

            });
        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("DeletionConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        dev.store.cloudinarySettings.cloudinarySetting.delete(recordId)
                            .then(function () {
                                abp.notify.success(l("SuccessfullyDeleted"));
                                cloudinarySettings.defines.grid().dataSource.read();

                            });
                    }
                });


        }


    },
    init: function () {




    }


}