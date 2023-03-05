var l = abp.localization.getResource("Store");
var productSets = {
    defines: {
        service: dev.store.brand,
        createModal: new abp.ModalManager(abp.appPath + 'productSets/createmodal'),
        editModal: new abp.ModalManager(abp.appPath + 'productSets/editmodal'),
        grid: function () { return $("#ProductSetGrid").data("kendoGrid") }
    },
    functions: {
        create: function (e, id) {
            var load = new Loading($(e));
            load.Start();
            productSets.defines.createModal.open({ productId: id });
            productSets.defines.createModal.onOpen(function () {
                load.Done();
            });
        },
        edit: function (e) {
            var load = new Loading($(e.target));
            load.Start();
            productSets.defines.editModal.open({ id: e.currentTarget.dataset["id"] });
            productSets.defines.editModal.onOpen(function () {
                load.Done();
            });
        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("DeletionConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        dev.store.productSets.productSet.delete(recordId)
                            .then(function () {
                                abp.notify.success(l("SuccessfullyDeleted"));
                                productSets.defines.grid().dataSource.read();
                            });
                    }
                });
        }
    },
    init: function () {
        productSets.defines.createModal.onResult(function (e, a) {
            productSets.defines.grid().dataSource.read();
            abp.notify.success(l("SuccessfullyAdded"));
        });
        
     
        productSets.defines.editModal.onResult(function () {
            productSets.defines.grid().dataSource.read();
            abp.notify.success(l("SuccessfullyUpdated"));
        });
    }
}
productSets.init();