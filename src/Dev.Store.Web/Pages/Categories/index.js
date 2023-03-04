var l = abp.localization.getResource("Store");
var categories = {
    defines: {
        service: dev.store.category,
        createModal: new abp.ModalManager(abp.appPath + 'categories/createmodal'),
        editModal: new abp.ModalManager(abp.appPath + 'categories/editmodal'),
        grid: function () { return $("#categories").data("kendoGrid") }
    },
    functions: {
        create: function (e) {
            categories.defines.createModal.open({
                categoryParentId: _id
            });

        },
        edit: function (e, i) {
            categories.defines.editModal.open({ id: e?.currentTarget?.dataset["id"] ?? i });

        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("DeletionConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        dev.store.categories.category.delete(recordId)
                            .then(function () {
                                abp.notify.success(l("SuccessfullyDeleted"));
                                categories.defines.grid().dataSource.read();
                            });
                    }
                });
        },
        detail: function (e) {
            e.preventDefault();
            var recordId = e.currentTarget.dataset["id"];
            window.location.href = abp.appPath + "categories/Index?Id=" + recordId;
        },
        moveUp: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            dev.store.categories.category.moveUp(recordId).then(function () {
                abp.notify.success(l("SuccessfullyUpdated"));
                categories.defines.grid().dataSource.read();
            });

        },
        moveDown: function (e) {
            var recordId = e.currentTarget.dataset["id"];
            dev.store.categories.category.moveDown(recordId).then(function () {
                abp.notify.success(l("SuccessfullyUpdated"));
                categories.defines.grid().dataSource.read();
            });
        },
        image: function (path) {
            window.open(path);
        }
    },
    init: function () {
        categories.defines.createModal.onResult(function () {
            abp.notify.success(l("SuccessfullyCreated"));
            categories.defines.grid().dataSource.read();
        });
        categories.defines.editModal.onResult(function () {
            abp.notify.success(l("SuccessfullyEdited"));
            categories.defines.grid().dataSource.read();
        });
    }
}
categories.init();