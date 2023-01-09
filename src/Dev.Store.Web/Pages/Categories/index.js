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
            var load = new Loading($(e));
            load.Start();
            categories.defines.createModal.onOpen(function () {
                load.Done();
            });
            categories.defines.createModal.open({
                categoryParentId: _id
            });
            categories.defines.createModal.onResult(function () {
                categories.defines.grid().dataSource.read();

            });
        },
        edit: function (e) {
            var load = new Loading($(e.target));
            load.Start();
            categories.defines.editModal.onOpen(function () {
                load.Done();
            });
            categories.defines.editModal.open({ id: e.currentTarget.dataset["id"] });
            categories.defines.editModal.onResult(function () {
                categories.defines.grid().dataSource.read();
            });
        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("categoryDeletionConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        dev.store.categories.category.delete(recordId)
                            .then(function () {
                                abp.notify.info(l("SuccessfullyDeleted"));
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
        nameChange: function () {
            var name = $("#ViewModel_Name").val();
            var code = $("#ViewModel_Link").val();

            if (name == null) {
                return;
            }
            $("#ViewModel_Link").val(name.toLower());
        }

    },
    init: function () {




    }


}
$(document).on("change", "#ViewModel_Name", function () {
    categories.functions.nameChange();
}).on("keyup", "#ViewModel_Name", function () {
    categories.functions.nameChange();
}).on("change", "#ViewModel_Link", function () {
    categories.functions.nameChange();
}).on("keyup", "#ViewModel_Link", function () {
    categories.functions.nameChange();
})