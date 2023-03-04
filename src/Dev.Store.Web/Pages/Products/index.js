var l = abp.localization.getResource("Store");
var products = {
    defines: {
        service: dev.store.brand,
        createModal: new abp.ModalManager(abp.appPath + 'products/createmodal'),
        editModal: new abp.ModalManager(abp.appPath + 'products/editmodal'),
        grid: function () { return $("#products").data("kendoGrid") }
    },
    functions: {
        create: function (e) {
            var load = new Loading($(e));
            load.Start();
            products.defines.createModal.onOpen(function () {
                load.Done();
            });
            products.defines.createModal.open();
        },
        detail: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            location.href = "/Products/Detail?id=" + recordId;
        },
        edit: function (e) {
            var load = new Loading($(e.target));
            load.Start();
            products.defines.editModal.onOpen(function () {
                load.Done();
            });
            products.defines.editModal.open({ id: e.currentTarget.dataset["id"] });
        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("DeletionConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        dev.store.products.product.delete(recordId)
                            .then(function () {
                                abp.notify.success(l("SuccessfullyDeleted"));
                                products.defines.grid().dataSource.read();
                            });
                    }
                });
        }
    },
    init: function () {
        products.defines.createModal.onResult(function (e, a) {
            products.defines.grid().dataSource.read();
            abp.notify.success(l("SuccessfullyAdded"));
        });
        products.defines.editModal.onResult(function () {
            products.defines.grid().dataSource.read();
            abp.notify.success(l("SuccessfullyUpdated"));
        });
    }
}
products.init();