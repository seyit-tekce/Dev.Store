var l = abp.localization.getResource("Store");
var locations = {
    defines: {
        service: dev.store.category,
        createModal: new abp.ModalManager(abp.appPath + 'locations/createmodal'),
        editModal: new abp.ModalManager(abp.appPath + 'locations/editmodal'),
        grid: function () { return $("#locations").data("kendoGrid") }
    },
    functions: {
        create: function (e) {
            var load = new Loading($(e));
            load.Start();
            locations.defines.createModal.onOpen(function () {
                load.Done();
            });
            locations.defines.createModal.open({
                locationParentId: _id
            });
            locations.defines.createModal.onResult(function () {
                locations.defines.grid().dataSource.read();

            });
        },
        edit: function (e) {
            var load = new Loading($(e.target));
            load.Start();
            locations.defines.editModal.onOpen(function () {
                load.Done();
            });
            locations.defines.editModal.open({ id: e.currentTarget.dataset["id"] });
            locations.defines.editModal.onResult(function () {
                locations.defines.grid().dataSource.read();
            });
        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("categoryDeletionConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        dev.store.locations.location.delete(recordId)
                            .then(function () {
                                abp.notify.info(l("SuccessfullyDeleted"));
                                locations.defines.grid().dataSource.read();

                            });
                    }
                });


        },
        detail: function (e) {
            e.preventDefault();
            var recordId = e.currentTarget.dataset["id"];
            window.location.href = abp.appPath + "locations/Index?Id=" + recordId;


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
    locations.functions.nameChange();
}).on("keyup", "#ViewModel_Name", function () {
    locations.functions.nameChange();
}).on("change", "#ViewModel_Link", function () {
    locations.functions.nameChange();
}).on("keyup", "#ViewModel_Link", function () {
    locations.functions.nameChange();
})