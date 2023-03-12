var l = abp.localization.getResource("Store");
var productsizes = {
    defines: {
        service: dev.store.brand,
        createModal: new abp.ModalManager(abp.appPath + 'productsizes/createmodal'),
        editModal: new abp.ModalManager(abp.appPath + 'productsizes/editmodal'),
        grid: function () { return $("#ProductSizeGrid").data("kendoGrid") }
    },
    functions: {
        create: function (e, id) {
            var load = new Loading($(e));
            load.Start();
            productsizes.defines.createModal.open({ productId: id });
            productsizes.defines.createModal.onOpen(function () {
                load.Done();
            });
        },
        edit: function (e) {
            var load = new Loading($(e.target));
            load.Start();
            productsizes.defines.editModal.open({ id: e.currentTarget.dataset["id"] });
            productsizes.defines.editModal.onOpen(function () {
                load.Done();
            });
        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("DeletionConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        dev.store.productSizes.productSize.delete(recordId)
                            .then(function () {
                                abp.notify.success(l("SuccessfullyDeleted"));
                                productsizes.defines.grid().dataSource.read();
                            });
                    }
                });
        }
    },
    init: function () {
        productsizes.defines.createModal.onResult(function (e, a) {
            productsizes.defines.grid().dataSource.read();
            abp.notify.success(l("SuccessfullyAdded"));
        });
      
      
        productsizes.defines.editModal.onResult(function () {
            productsizes.defines.grid().dataSource.read();
            abp.notify.success(l("SuccessfullyUpdated"));
        });
    }
}
productsizes.init();