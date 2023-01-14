var l = abp.localization.getResource("Store");
var keywords = {
    defines: {
        service: dev.store.brand,
        createModal: new abp.ModalManager(abp.appPath + 'keywords/createmodal'),
        editModal: new abp.ModalManager(abp.appPath + 'keywords/editmodal'),
        grid: function () { return $("#keywords").data("kendoGrid") }
    },
    functions: {
        create: function (e) {
            var load = new Loading($(e));
            load.Start();
            keywords.defines.createModal.onOpen(function () {
                load.Done();
            });
            keywords.defines.createModal.open();
            keywords.defines.createModal.onResult(function () {
                keywords.defines.grid().dataSource.read();



            });
        },
        edit: function (e) {
            var load = new Loading($(e.target));
            load.Start();
            keywords.defines.editModal.onOpen(function () {
                load.Done();
            });
            keywords.defines.editModal.open({ id: e.currentTarget.dataset["id"] });
            keywords.defines.editModal.onResult(function () {
                keywords.defines.grid().dataSource.read();
            });
        },
        delete: function (e) {
            e.preventDefault();
            abp.message.confirm(l("KeywordDeletionConfirmationMessage"))
                .then(function (confirmed) {
                    if (confirmed) {
                        var recordId = e.currentTarget.dataset["id"];
                        dev.store.keywords.brand.delete(recordId)
                            .then(function () {
                                abp.notify.info(l("SuccessfullyDeleted"));
                                keywords.defines.grid().dataSource.read();

                            });
                    }
                });


        }


    },
    init: function () {




    }


}