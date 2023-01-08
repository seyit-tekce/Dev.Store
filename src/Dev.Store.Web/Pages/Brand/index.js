var l = abp.localization.getResource("Store");
var brands = {
    defines: {
        service: dev.store.brand,
        createModal: new abp.ModalManager(abp.appPath + 'brand/createmodal'),
        editModal: new abp.ModalManager(abp.appPath + 'brand/editmodal'),
        grid: function () { return $("#brands").data("kendoGrid") }
    },
    functions: {
        create: function (e) {
            var load = new Loading($(e));
            load.Start();
            brands.defines.createModal.onOpen(function () {
                load.Done();
            });
            brands.defines.createModal.open();
            brands.defines.createModal.onResult(function () {
                brands.defines.grid().dataSource.read();



            });
        },
        edit: function (e) {
            var load = new Loading($(e.target));
            load.Start();
            brands.defines.editModal.onOpen(function () {
                load.Done();
            });
            brands.defines.editModal.open({ id: e.currentTarget.dataset["id"] });
            brands.defines.editModal.onResult(function () {
                brands.defines.grid().dataSource.read();
            });
        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("BrandDeletionConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        dev.store.entities.brand.delete(recordId)
                            .then(function () {
                                abp.notify.info(l("SuccessfullyDeleted"));
                                brands.defines.grid().dataSource.read();

                            });
                    }
                });


        }


    },
    init: function () {




    }


}